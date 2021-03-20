using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Globalization.ValueObjects
{
    /// <summary>
    /// Represents an ISO 639-1 alpha-2 code for a language
    /// </summary>
    [JsonConverter(typeof(WrappedStringJsonConverter<Language2CharIsoCode>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Language2CharIsoCode>))]
    public record Language2CharIsoCode : WrappedStringValueObject<Language2CharIsoCode>
    {
        public Language2CharIsoCode(char char1, char char2) :
            base(new string(new char[] { char1, char2 }).ToLowerInvariant()) { }

        public Language2CharIsoCode(string code) : this(code[0], code[1])
        {
            if (code.Length != 2)
                throw new FormatException($"{code} is the wrong format for a two-letter ISO language code.");
        }
    }
}
