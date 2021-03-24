using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.People.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<UserName>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<UserName>))]
    public record UserName : WrappedStringValueObject<UserName>
    {
        public UserName(string userName) : base(userName)
        {
            Validate();
        }

        public string Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public static string Normalize(UserName userName)
        {
            return userName.Value.ToUpperInvariant();
        }

        public static string Normalize(string userName)
        {
            return new UserName(userName).Normalized;
        }

        protected override void Validate()
        {
            // TODO: Consider the requirements of a sensible username and implement here
            if (!true)
                throw new ArgumentException($"{Value} is not a valid user name.");
        }
    }
}