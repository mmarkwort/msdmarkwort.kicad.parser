using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MSDMarkwort.Kicad.Parser.Project.Model.PartProject;
using NUnit.Framework;

namespace MSDMarkwort.Kicad.Parser.Project.Tests
{
    public class KicadProjectWriterTests
    {
        [Test]
        public async Task WriteAsync_ValidProject_WritesToStream()
        {
            var project = new KicadProject();
            await using var stream = new MemoryStream();
            
            var writer = new KicadProjectWriter();
            await writer.WriteAsync(project, stream);
            
            stream.Position = 0;
            var result = await new StreamReader(stream).ReadToEndAsync();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Does.Contain("{"));
            Assert.That(result, Does.Contain("}"));
            Assert.That(result, Does.EndWith("\r\n"));
        }

        [Test]
        public async Task WriteAsync_ValidProject_WritesToFile()
        {
            var project = new KicadProject();
            var tempFile = Path.GetTempFileName();
            
            try
            {
                var writer = new KicadProjectWriter();
                await writer.WriteAsync(project, tempFile);
                
                Assert.That(File.Exists(tempFile), Is.True);
                
                var content = await File.ReadAllTextAsync(tempFile);
                Assert.That(content, Is.Not.Null);
                Assert.That(content, Is.Not.Empty);
                Assert.That(content, Does.Contain("{"));
                Assert.That(content, Does.Contain("}"));
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Test]
        public async Task WriteAsync_ProjectWithComplexData_ProducesValidJson()
        {
            var project = new KicadProject
            {
                Meta = new Model.PartCommon.Meta { Version = 1 },
                NetSettings = new Model.PartNetSettings.NetSettings()
            };
            
            await using var stream = new MemoryStream();
            
            var writer = new KicadProjectWriter();
            await writer.WriteAsync(project, stream);
            
            stream.Position = 0;
            var jsonContent = await new StreamReader(stream).ReadToEndAsync();
            
            // Verify it produces valid JSON that can be parsed back
            Assert.DoesNotThrow(() => JsonDocument.Parse(jsonContent));
        }

        [Test]
        public async Task WriteAsync_NullProject_WritesNull()
        {
            var writer = new KicadProjectWriter();
            await using var stream = new MemoryStream();
            
            // JsonSerializer.SerializeAsync actually writes "null" for null values
            await writer.WriteAsync(null!, stream);
            
            stream.Position = 0;
            var result = await new StreamReader(stream).ReadToEndAsync();
            
            Assert.That(result, Does.Contain("null"));
        }

        [Test]
        public void WriteAsync_NullStream_ThrowsException()
        {
            var project = new KicadProject();
            var writer = new KicadProjectWriter();
            
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await writer.WriteAsync(project, (Stream)null!));
        }

        [Test]
        public void WriteAsync_NullFilePath_ThrowsException()
        {
            var project = new KicadProject();
            var writer = new KicadProjectWriter();
            
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await writer.WriteAsync(project, (string)null!));
        }

        [Test]
        public async Task WriteAsync_ReadOnlyStream_ThrowsException()
        {
            var project = new KicadProject();
            var data = Encoding.UTF8.GetBytes("test");
            await using var readOnlyStream = new MemoryStream(data, false);
            
            var writer = new KicadProjectWriter();
            
            Assert.ThrowsAsync<NotSupportedException>(async () =>
                await writer.WriteAsync(project, readOnlyStream));
        }

        [Test]
        public async Task WriteAsync_FileToInvalidPath_ThrowsException()
        {
            var project = new KicadProject();
            var invalidPath = "/invalid/path/that/does/not/exist/file.kicad_pro";
            
            var writer = new KicadProjectWriter();
            
            Assert.ThrowsAsync<DirectoryNotFoundException>(async () =>
                await writer.WriteAsync(project, invalidPath));
        }

        [Test]
        public async Task WriteAsync_OutputIsIndented()
        {
            var project = new KicadProject
            {
                Meta = new Model.PartCommon.Meta { Version = 1 }
            };
            
            await using var stream = new MemoryStream();
            
            var writer = new KicadProjectWriter();
            await writer.WriteAsync(project, stream);
            
            stream.Position = 0;
            var content = await new StreamReader(stream).ReadToEndAsync();
            
            // Check that the JSON is indented (contains newlines and spaces)
            Assert.That(content, Does.Contain("\n"));
            Assert.That(content, Does.Contain("  ")); // Should have indentation spaces
        }

        [Test]
        public async Task WriteAsync_RoundTripTest_PreservesData()
        {
            var originalProject = new KicadProject
            {
                Meta = new Model.PartCommon.Meta { Version = 1 }
            };
            
            // Write to stream
            await using var writeStream = new MemoryStream();
            var writer = new KicadProjectWriter();
            await writer.WriteAsync(originalProject, writeStream);
            
            // Read back from stream
            writeStream.Position = 0;
            var parser = new KicadProjectParser();
            var parseResult = await parser.ParseAsync(writeStream);
            
            Assert.That(parseResult.Success, Is.True);
            Assert.That(parseResult.Result, Is.Not.Null);
            Assert.That(parseResult.Result.Meta?.Version, Is.EqualTo(originalProject.Meta.Version));
        }
    }
}