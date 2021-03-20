using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Business.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<TaxRegistrationNumber>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<TaxRegistrationNumber>))]
    public record TaxRegistrationNumber : WrappedStringValueObject<TaxRegistrationNumber>
    {
        public TaxRegistrationNumber(string value) : base(value) { }
    }
}
