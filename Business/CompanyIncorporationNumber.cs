using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Business.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<CompanyIncorporationNumber>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<CompanyIncorporationNumber>))]
    public record CompanyIncorporationNumber : WrappedStringValueObject<CompanyIncorporationNumber>
    {
        public CompanyIncorporationNumber(string value) : base(value) { }
    }
}
