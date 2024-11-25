using System;
using System.IO;
using System.Linq;
using MSDMarkwort.Kicad.Parser.Base.Parser.SExpression.Models;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.SExpression
{
    internal class SExpressionParser
    {
        private Stream _stream;
        private int _lineNumber;
        private char _token;

        private static class TokenLibrary
        {
            public const char OpenToken = '(';
            public const char CloseToken = ')';
            public const char DoubleQuotesToken = '"';
            public const char NewlineToken = '\n';
            public const char BackslashToken = '\\';
            public static readonly char[] WhitespaceCharacters = { ' ', '\t', '\n', '\r', '\b', '\f', '\v'};
            public static readonly char[] WhitespaceCharactersWithBrackets = { ' ', '\t', '\n', '\r', '\b', '\f', '\v', OpenToken, CloseToken };
        }

        public SExpr ParseStream(Stream stream)
        {
            _stream = stream;
            _lineNumber = 1;

            return Parse();
        }

        public SExpr Parse()
        {
            while (Advance(out _token))
            {
                if (_token == TokenLibrary.NewlineToken)
                {
                    ++_lineNumber;
                }

                if (TokenLibrary.WhitespaceCharacters.Contains(_token))
                {
                    continue;
                }

                switch (_token)
                {
                    case TokenLibrary.OpenToken:
                    {
                        Advance(out _token);

                        var sexprList = new SExprList { LineNumber = _lineNumber };

                        while (Peek() && _token != TokenLibrary.CloseToken)
                        {
                            if (_token == TokenLibrary.NewlineToken)
                            {
                                ++_lineNumber;
                            }

                            if (TokenLibrary.WhitespaceCharacters.Contains(_token))
                            {
                                Advance(out _token);
                                continue;
                            }

                            Back();

                            var child = Parse();
                            sexprList.Children.Add(child);
                        }

                        if (Peek())
                        {
                            Advance(out _token);
                        }

                        return sexprList;
                    }
                    case TokenLibrary.CloseToken:
                    {
                        return null;
                    }
                    case TokenLibrary.DoubleQuotesToken:
                    {
                        var sexprString = new SExprString
                        {
                            LineNumber = _lineNumber
                        };

                        while (Advance(out _token))
                        {
                            if (_token == TokenLibrary.BackslashToken)
                            {
                                sexprString.Value += _token;

                                if (!Advance(out _token))
                                {
                                    break;
                                }

                                sexprString.Value += _token;
                                continue;
                            }

                            if (_token == TokenLibrary.DoubleQuotesToken)
                            {
                                break;
                            }

                            sexprString.Value += _token;
                        }

                        if (!Peek())
                        {
                            throw new InvalidOperationException("No closing quote found");
                        }

                        Advance(out _token);
                        return sexprString;
                    }
                    default:
                    {
                        PeekTokenBefore(out var tokenBefore);

                        var tmp = string.Empty;
                        var endReached = false;
                        while (!TokenLibrary.WhitespaceCharactersWithBrackets.Contains(_token))
                        {
                            tmp += _token;

                            if (!Advance(out _token)) 
                            {
                                endReached = true;
                                break;
                            }
                        }

                        if (!endReached)
                        {
                            if (tokenBefore == TokenLibrary.OpenToken)
                            {
                                return new SExprSymbol { LineNumber = _lineNumber, Value = tmp };
                            }

                            return new SExprString { LineNumber = _lineNumber, Value = tmp };
                        }

                        throw new InvalidOperationException("Format error");
                    }
                }
            }

            return null;
        }

        private bool Advance(out char token)
        {
            var readToken = _stream.ReadByte();
            if (readToken == -1)
            {
                token = '\0';
                return false;
            }

            token = (char)readToken;
            return true;
        }

        private bool Peek()
        {
            var peekToken = _stream.ReadByte();
            Back();

            if (peekToken == -1)
            {
                return false;
            }

            return true;
        }

        private bool PeekTokenBefore(out char peekTokenBefore)
        {
            peekTokenBefore = '\0';

            if (!Back(-2))
            {
                return false;
            }

            var readTokenBefore = _stream.ReadByte();
            _stream.ReadByte();
            if (readTokenBefore == -1)
            {
                return false;
            }

            peekTokenBefore = (char)readTokenBefore;
            return true;
        }

        private bool Back(int bytes = -1)
        {
            if (bytes >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes), "Must be negative");
            }

            if (_stream.Position > 0)
            {
                _stream.Seek(bytes, SeekOrigin.Current);
                return true;
            }

            return false;
        }
    }
}
