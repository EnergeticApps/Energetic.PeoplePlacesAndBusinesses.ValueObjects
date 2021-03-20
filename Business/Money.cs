using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Energetic.Business.ValueObjects
{
    public record Money : ValueObject<Money, (decimal, Currency3CharIsoCode)>
    {
        public Money(decimal amount, Currency3CharIsoCode currency) :
            base((amount, currency))
        { }

        public override string ToString()
        {
            var (amount, currency) = Value;

            return $"{currency} {amount:0.00}";
        }
    }
}
