using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Project.Model.PartProject;

namespace MSDMarkwort.Kicad.Parser.Project
{
    public class KicadProjectParser
    {
        public async Task<ParserResult<KicadProject>> ParseAsync(string filePath)
        {
            await using var fileStream = File.OpenRead(filePath);

            return await ParseAsync(fileStream);
        }

        public async Task<ParserResult<KicadProject>> ParseAsync(Stream input)
        {
            KicadProject project = null;
            ParserError error = null;

            try
            {
                project = await JsonSerializer.DeserializeAsync<KicadProject>(input);
            }
            catch (Exception e)
            {
                error = new ParserError { Exception = e };
            }

            return new ParserResult<KicadProject>
            {
                Success = error == null,
                Result = project,
                Warnings = Array.Empty<ParserWarning>(),
                Error = error
            };
        }
    }
}
