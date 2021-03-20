using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Business.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<Currency3CharIsoCode>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Currency3CharIsoCode>))]
    public record Currency3CharIsoCode : WrappedStringValueObject<Currency3CharIsoCode>
    {
        public Currency3CharIsoCode(char char1, char char2, char char3) :
            base(new string(new char[] { char1, char2, char3 }).ToUpperInvariant()){  }

        public Currency3CharIsoCode(string code) : this(code[0], code[1], code[2])
        {
            if (code.Length != 3)
                throw new FormatException($"{code} is the wrong format for a three-letter ISO currency code.");
        }
    }
}
