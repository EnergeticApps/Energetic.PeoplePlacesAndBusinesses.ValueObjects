using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Business.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<DunsNumber>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<DunsNumber>))]
    public record DunsNumber : WrappedStringValueObject<DunsNumber>
    {
        public DunsNumber(string value) : base(value) { }
    }
}
