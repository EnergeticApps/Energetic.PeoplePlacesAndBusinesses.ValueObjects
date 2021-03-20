using Serious.ValueObjects;
using Serious.ValueObjects.JsonConverters;
using Serious.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Serious.Globalization.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<Language3CharBibliographicIsoCode>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Language3CharBibliographicIsoCode>))]
    public record Language3CharBibliographicIsoCode : ValueObjectBase<Language3CharBibliographicIsoCode, string>
    {
        public Language3CharBibliographicIsoCode() : base() { }

        public Language3CharBibliographicIsoCode(char char1, char char2, char char3) :
            base(new string(new char[] { char1, char2, char3 }).ToLowerInvariant())
        {

        }

        public Language3CharBibliographicIsoCode(string code) : this(code[0], code[1], code[2])
        {
            if (code.Length != 3)
                throw new FormatException($"{code} is the wrong format for a three-letter ISO language code.");
        }
    }
}
