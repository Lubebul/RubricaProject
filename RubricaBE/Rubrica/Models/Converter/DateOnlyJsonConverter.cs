using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rubrica.API.Models.Converter
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var val = reader.GetString();

            if (val == null)
                return new DateOnly();

            return DateOnly.ParseExact(val, Format);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            if (writer == null)
                throw new ArgumentNullException($" variable{nameof(value)} has null value");

            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
