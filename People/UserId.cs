using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.People.ValueObjects
{
    [JsonConverter(typeof(WrappedGuidJsonConverter<UserId>))]
    [TypeConverter(typeof(WrappedGuidTypeConverter<UserId>))]
    public record UserId : WrappedGuidValueObject<UserId>
    {
        public UserId(Guid guid) : base(guid) { }
        public UserId(string guid) : base(guid) { }
    }
}