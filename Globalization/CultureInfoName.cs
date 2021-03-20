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
    /// TODO: Make typeconverters appropriate to this class
    //[JsonConverter(typeof(WrappedStringJsonConverter<Language2CharIsoCode>))]
    //[TypeConverter(typeof(WrappedStringTypeConverter<Language2CharIsoCode>))]
    public record CultureInfoName : ValueObject<CultureInfoName, (Language2CharIsoCode, Country2CharIsoCode?)>
    {
        public CultureInfoName(Language2CharIsoCode language, Country2CharIsoCode? country = null) :
            base((language, country)) { }

        public override string ToString()
        {
            var (language, country) = Value;

            if (country is null)
                return language.ToString();

            return $"{language} {country}";
        }
    }
}
