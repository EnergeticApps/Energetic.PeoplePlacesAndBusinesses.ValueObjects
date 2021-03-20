using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Business.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<CompanyName>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<CompanyName>))]
    public record CompanyName : WrappedStringValueObject<CompanyName>
    {
        public CompanyName(string value) : base(value) { }
    }
}
