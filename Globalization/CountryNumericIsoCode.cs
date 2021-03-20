using Serious.ValueObjects;
using Serious.ValueObjects.JsonConverters;
using Serious.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Serious.Globalization.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<CountryNumericIsoCode>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<CountryNumericIsoCode>))]
    public record CountryNumericIsoCode : ValueObjectBase<CountryNumericIsoCode, string>
    {
        public CountryNumericIsoCode() : base() { }

        public CountryNumericIsoCode(int numericCode) :
            base(numericCode.ToString())
        {
            if (numericCode < 0 || numericCode > 999)
                throw new FormatException($"{numericCode} is the wrong format for a three-digit numeric ISO country code.");
        }

        public CountryNumericIsoCode(string numericCode) : base(numericCode)
        {
            if (numericCode.Length != 3 || !int.TryParse(numericCode, out _))
                throw new FormatException($"{numericCode} is the wrong format for a three-digit numeric ISO country code.");
        }

        public CountryNumericIsoCode(char char1, char char2, char char3) :
           base(new string(new char[] { char1, char2, char3 }).ToUpperInvariant())
        {

        }
    }
}
