using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Business.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<BrandName>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<BrandName>))]
    public record BrandName : WrappedStringValueObject<BrandName>
    {
        public BrandName(string value) : base(value) { }
    }
}
