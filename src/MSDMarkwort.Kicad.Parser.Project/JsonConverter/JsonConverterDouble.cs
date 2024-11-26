using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace MSDMarkwort.Kicad.Parser.Project.JsonConverter
{
    public class JsonConverterDouble : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDouble();
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value - (int)value != 0
                ? value.ToString(CultureInfo.GetCultureInfo("en-US"))
                : value.ToString("0.0", CultureInfo.GetCultureInfo("en-US")));
        }
    }
}
