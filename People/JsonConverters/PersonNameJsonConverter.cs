using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serious.People.ValueObjects.JsonConverters
{
    public class PersonNameJsonConverter : JsonConverter<PersonName>
    {
        public override void Write(Utf8JsonWriter writer, PersonName name, JsonSerializerOptions options)
        {
            writer.WriteString(nameof(PersonName), JsonSerializer.Serialize(name, options));
        }

        public override PersonName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<PersonName>(reader.GetString(), options);
        }
    }
}
