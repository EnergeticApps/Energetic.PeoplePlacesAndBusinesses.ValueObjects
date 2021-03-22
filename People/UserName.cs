using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using System.ComponentModel.DataAnnotations;
using Energetic.ValueObjects.TypeConverters;

namespace Energetic.People.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<UserName>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<UserName>))]
    public record UserName : WrappedStringValueObject<UserName>
    {
        private UserName() : base(string.Empty)
        {
            IsUnknown = true;
        }

        public UserName(string userName) : base(userName)
        {
            Validate();
        }

        public static UserName Unknown => new UserName();

        public bool IsUnknown
        {
            get;
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
