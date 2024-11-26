using MSDMarkwort.Kicad.Parser.Project.Model.PartProject;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MSDMarkwort.Kicad.Parser.Project.JsonConverter;

namespace MSDMarkwort.Kicad.Parser.Project
{
    public class KicadProjectWriter
    {
        public async Task WriteAsync(KicadProject project, string filePath)
        {
            await using var fileStream = File.OpenWrite(filePath);
            await WriteAsync(project, fileStream);
        }

        public async Task WriteAsync(KicadProject project, Stream input)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonConverterDouble() }
            };

            await JsonSerializer.SerializeAsync(input, project, serializerOptions);
        }
    }
}
