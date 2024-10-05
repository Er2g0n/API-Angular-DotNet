using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace DemoSession1_WebAPI_C2209L.Converters;

public class DateConverters : JsonConverter<DateTime>
{
    private string dateFormat = "dd/MM/yyyy";
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString(),dateFormat,CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(dateFormat));
    }
}
