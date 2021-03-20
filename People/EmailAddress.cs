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
using Energetic.Text;

namespace Energetic.People.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<EmailAddress>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<EmailAddress>))]
    public record EmailAddress : WrappedStringValueObject<EmailAddress>
    {
        private EmailAddress() : base(string.Empty)
        {
            IsUnknown = true;
        }

        public EmailAddress(string email) : base(email)
        {
            Validate();
        }

        public static EmailAddress Unknown => new EmailAddress();

        public string Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public static string Normalize(EmailAddress email)
        {
            return email.Value.ToLowerInvariant();
        }

        public static string Normalize(string email)
        {
            return new EmailAddress(email).Normalized;
        }

        public bool IsUnknown
        {
            get;
        }

        protected virtual void Validate()
        {
            if(string.IsNullOrWhiteSpace(Value))
                throw new StringArgumentNullOrWhiteSpaceException(nameof(Value));

            var validator = new EmailAddressAttribute();
            if (!validator.IsValid(Value))
                throw new ArgumentException($"{Value} is not a valid email address.");
        }
    }
}
