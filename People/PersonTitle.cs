using Energetic.Text;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;

namespace Energetic.People.ValueObjects
{
    /// <summary>
    /// Represents the title in a person's name e.g. "Mr", "Mrs", "Dr"
    /// </summary>
    [JsonConverter(typeof(WrappedStringJsonConverter<PersonTitle>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<PersonTitle>))]
    public record PersonTitle : WrappedStringValueObject<PersonTitle>
    {
        public PersonTitle(string title) :
            base(title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new StringArgumentNullOrWhiteSpaceException(nameof(title));
        }

        private PersonTitle() :
            base(string.Empty) { }

        public bool HasNone() => Value == string.Empty;

        public static PersonTitle None => new PersonTitle();

        public static bool IsNone(PersonTitle title) => title.HasNone();
    }
}
