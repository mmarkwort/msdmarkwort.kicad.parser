using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MSDMarkwort.Kicad.Parser.Base.Parser.Result;
using MSDMarkwort.Kicad.Parser.Project.Model.PartProject;

namespace MSDMarkwort.Kicad.Parser.Project
{
    public class KicadProjectParser
    {
        public async Task<ParserResult<KicadProject>> ParseAsync(string filePath, JsonUnmappedMemberHandling unmappedMemberHandling = JsonUnmappedMemberHandling.Skip)
        {
            await using var fileStream = File.OpenRead(filePath);

            return await ParseAsync(fileStream, unmappedMemberHandling);
        }

        public async Task<ParserResult<KicadProject>> ParseAsync(Stream input, JsonUnmappedMemberHandling unmappedMemberHandling = JsonUnmappedMemberHandling.Skip)
        {
            KicadProject project = null;
            ParserError error = null;

            try
            {
                var options = new JsonSerializerOptions(JsonSerializerDefaults.General)
                {
                    UnmappedMemberHandling = unmappedMemberHandling
                };

                project = await JsonSerializer.DeserializeAsync<KicadProject>(input, options);
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
