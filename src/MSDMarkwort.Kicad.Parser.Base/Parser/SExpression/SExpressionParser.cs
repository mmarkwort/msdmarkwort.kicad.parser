using System;
using System.IO;
using System.Linq;

namespace MSDMarkwort.Kicad.Parser.Base.Parser.SExpression
{
    internal class SExpressionParser
    {
        private readonly Stream _stream;
        private Mode _mode;

        private Element _rootElement;
        private Element _currentElement;

        private enum Mode
        {
            Element,
            ElementName,
            BeforeParameter,
            InParameter,
            InParameterInDoubleQuotationMarks
        }

        private static class TokenLibrary
        {
            public const char OpenToken = '(';
            public const char CloseToken = ')';
            public const char DoubleQuotesToken = '"';
            public const char SpaceToken = ' ';
            public const char TabToken = '\t';
            public const char NewlineToken = '\n';
            public const char CarriageReturnToken = '\r';
            public const char BackslashToken = '\\';
        }

        public SExpressionParser(Stream stream)
        {
            _stream = stream;
        }

        private string[] _unexpectedClosingBracketsIndicators = Array.Empty<string>();

        public Element Parse(string[] unexpectedClosingBracketsIndicators)
        {
            _unexpectedClosingBracketsIndicators = unexpectedClosingBracketsIndicators;

            _rootElement = new Element();
            _currentElement = _rootElement;
            _mode = Mode.Element;

            var level = 0;
            var lineNumber = 1;
            var characterInLine = 0;

            while (Advance(out var currentToken))
            {
                ++characterInLine;

                switch (currentToken)
                {
                    case TokenLibrary.TabToken:
                        {
                            ++level;
                            break;
                        }
                    case TokenLibrary.OpenToken:
                        {
                            if (lineNumber == 348)
                            {

                            }

                            if (_mode == Mode.Element || _mode == Mode.BeforeParameter)
                            {
                                HandleStartElement(level, lineNumber);
                                _mode = Mode.ElementName;
                            }
                            else
                            {
                                AppendTokenToLastParameter(currentToken);
                            }

                            break;
                        }
                    case TokenLibrary.CloseToken:
                        {
                            if (_mode == Mode.Element || _mode == Mode.ElementName || _mode == Mode.BeforeParameter)
                            {
                                if (HandleCloseElement(level))
                                {
                                    _mode = Mode.Element;
                                }
                            }
                            else
                            {
                                AppendTokenToLastParameter(currentToken);
                            }

                            break;
                        }
                    case TokenLibrary.SpaceToken:
                        {
                            if (_mode == Mode.ElementName)
                            {
                                HandleNewParameter();

                                _mode = Mode.BeforeParameter;
                            }
                            else if (_mode == Mode.BeforeParameter)
                            {
                                HandleNewParameter();
                            }
                            else if (_mode == Mode.InParameter ||
                                    _mode == Mode.InParameterInDoubleQuotationMarks)
                            {
                                AppendTokenToLastParameter(currentToken);
                            }
                            break;
                        }
                    case TokenLibrary.DoubleQuotesToken:
                        {
                            switch (_mode)
                            {
                                case Mode.BeforeParameter:
                                    {
                                        _mode = Mode.InParameterInDoubleQuotationMarks;
                                        break;
                                    }
                                case Mode.InParameterInDoubleQuotationMarks:
                                    {
                                        _mode = Mode.BeforeParameter;
                                        break;
                                    }
                                default:
                                    {
                                        AppendTokenToLastParameter(currentToken);
                                        break;
                                    }
                            }
                            break;
                        }
                    case TokenLibrary.NewlineToken:
                    case TokenLibrary.CarriageReturnToken:
                        {
                            HandleNewline();

                            _mode = Mode.Element;
                            level = 0;
                            characterInLine = 0;

                            ++lineNumber;
                            break;
                        }
                    case TokenLibrary.BackslashToken:
                        {
                            if (_mode == Mode.InParameter)
                            {
                                HandleBackslash();
                            }

                            break;
                        }
                    default:
                        {
                            switch (_mode)
                            {
                                case Mode.ElementName:
                                    {
                                        AppendTokenToElementName(currentToken);
                                        break;
                                    }
                                case Mode.BeforeParameter:
                                case Mode.InParameter:
                                case Mode.InParameterInDoubleQuotationMarks:
                                    {
                                        AppendTokenToLastParameter(currentToken);
                                        break;
                                    }
                            }

                            break;
                        }
                }
            }

            return _rootElement.Children.FirstOrDefault();
        }

        private void HandleStartElement(int level, int lineNumber)
        {
            var newElement = new Element { ParentElement = _currentElement, Level = level, LineNumber = lineNumber };

            _currentElement.Children.Add(newElement);
            _currentElement = newElement;
        }

        private void AppendTokenToElementName(char token)
        {
            _currentElement.ElementName += token;
        }

        private void HandleNewParameter()
        {
            _currentElement.Parameters.Add("");
        }

        private void AppendTokenToLastParameter(char token)
        {
            _currentElement.Parameters[^1] += token;
        }

        private void HandleNewline()
        {
            if (Advance(out var predictionToken))
            {
                if (predictionToken != TokenLibrary.NewlineToken &&
                    predictionToken != TokenLibrary.CarriageReturnToken)
                {
                    Back();
                }
            }
        }

        private void HandleBackslash()
        {
            if (Advance(out var predictionToken))
            {
                if (predictionToken == TokenLibrary.DoubleQuotesToken)
                {
                    AppendTokenToLastParameter(predictionToken);
                }
                else
                {
                    Back();
                }
            }
        }

        private bool HandleCloseElement(int level)
        {
            if (!Advance(out var predictionToken))
            {
                return false;
            }

            Back();

            if (predictionToken == TokenLibrary.SpaceToken &&
                _unexpectedClosingBracketsIndicators.Contains(_currentElement.ElementName))
            {
                _mode = Mode.BeforeParameter;
                return false;
            }

            var levelDiff = Math.Abs(level - _currentElement.Level);

            for (; !(levelDiff < 0); --levelDiff)
            {
                _currentElement = _currentElement.ParentElement;
            }

            return true;
        }

        private bool Advance(out char token)
        {
            int readToken = _stream.ReadByte();
            if (readToken == -1)
            {
                token = '\0';
                return false;
            }

            token = (char)readToken;
            return true;
        }

        private void Back()
        {
            _stream.Seek(-1, SeekOrigin.Current);
        }
    }
}
