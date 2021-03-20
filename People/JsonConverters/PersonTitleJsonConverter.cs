using Serious.People.ValueObjects;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serious.Globalization.ValueObjects.JsonConverters
{
    public class PersonTitleJsonConverter : JsonConverter<PersonTitle>
    {
        public override void Write(Utf8JsonWriter writer, PersonTitle title, JsonSerializerOptions options)
        {
            writer.WriteStringValue(title.Value);
        }

        public override PersonTitle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new PersonTitle(reader.GetString());
        }
    }
}
