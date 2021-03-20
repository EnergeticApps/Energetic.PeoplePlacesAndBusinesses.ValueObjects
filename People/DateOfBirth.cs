using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.People.ValueObjects
{
    [JsonConverter(typeof(WrappedDateTimeJsonConverter<DateOfBirth>))]
    [TypeConverter(typeof(WrappedDateTimeTypeConverter<DateOfBirth>))]
    public record DateOfBirth : WrappedDateTimeValueObject<DateOfBirth>
    {
        private DateOfBirth() : base(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day)
        {
            IsUnknown = true;
        }

        public DateOfBirth(int year, int month, int day) : base(year, month, day) { }

        public bool IsUnknown
        {
            get;
        }
    }
}