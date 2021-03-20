using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Globalization.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<Country2CharIsoCode>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Country2CharIsoCode>))]
    public record Country2CharIsoCode : WrappedStringValueObject<Country2CharIsoCode>
    {
        public Country2CharIsoCode(char char1, char char2) :
            base(new string(new char[] { char1, char2 }).ToUpperInvariant()) { }

        public Country2CharIsoCode(string code) : this(code[0], code[1])
        {
            if (code.Length != 2)
                throw new FormatException($"{code} is the wrong format for a two-letter ISO country code.");
        }
    }
}
