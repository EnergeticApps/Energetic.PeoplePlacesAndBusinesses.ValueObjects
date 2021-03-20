using Serious.ValueObjects;
using Serious.ValueObjects.JsonConverters;
using Serious.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Serious.Globalization.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<Country3CharIsoCode>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Country3CharIsoCode>))]
    public record Country3CharIsoCode : ValueObjectBase<Country3CharIsoCode, string>
    {
        public Country3CharIsoCode() : base() { }

        public Country3CharIsoCode(char char1, char char2, char char3) :
            base(new string(new char[] { char1, char2, char3 }).ToUpperInvariant()){  }

        public Country3CharIsoCode(string code) : this(code[0], code[1], code[2])
        {
            if (code.Length != 3)
                throw new FormatException($"{code} is the wrong format for a three-letter ISO country code.");
        }
    }
}
