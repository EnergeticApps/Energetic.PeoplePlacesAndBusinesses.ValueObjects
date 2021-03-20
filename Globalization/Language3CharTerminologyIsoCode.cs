using Serious.ValueObjects;
using Serious.ValueObjects.JsonConverters;
using Serious.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Serious.Globalization.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<Language3CharTerminologyIsoCode>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Language3CharTerminologyIsoCode>))]
    public record Language3CharTerminologyIsoCode : ValueObjectBase<Language3CharTerminologyIsoCode, string>
    {
        public Language3CharTerminologyIsoCode() : base() { }

        public Language3CharTerminologyIsoCode(char char1, char char2, char char3) :
            base(new string(new char[] { char1, char2, char3 }).ToLowerInvariant())
        {

        }

        public Language3CharTerminologyIsoCode(string code) : this(code[0], code[1], code[2])
        {
            if (code.Length != 3)
                throw new FormatException($"{code} is the wrong format for a three-letter ISO language code.");
        }
    }
}
