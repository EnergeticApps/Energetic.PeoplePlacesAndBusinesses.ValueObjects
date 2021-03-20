using Energetic.Globalization.ValueObjects;
using Energetic.Text;
using Energetic.ValueObjects;
using System;

namespace Energetic.People.ValueObjects
{
    //TODO: I think we can just use default JSON serialization for this class. Check if that's right
    public record Address : ValueObject<Address, (string, string?, string?, string?, string?, Country2CharIsoCode)>
    {
        public Address(string line1,
            string? line2,
            string? townOrCity,
            string? countyOrRegion,
            string? stateOrTerritory,
            Country2CharIsoCode countryIsoCode) : base((line1, line2, townOrCity, countyOrRegion, stateOrTerritory, countryIsoCode))
        {
            Line1 = line1.Trim();
            Line2 = line2?.Trim();
            TownOrCity = townOrCity?.Trim();
            CountyOrRegion = countyOrRegion?.Trim();
            StateOrTerritory = stateOrTerritory?.Trim();
            Country2CharIsoCode = countryIsoCode;

            Validate();
        }


        public string Line1 { get; init; }
        public string? Line2 { get; init; }
        public string? TownOrCity { get; init; }
        public string? CountyOrRegion { get; init; }
        public string? StateOrTerritory { get; init; }
        public Country2CharIsoCode Country2CharIsoCode { get; init; }


        protected virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(Line1))
                throw new StringArgumentNullOrWhiteSpaceException(nameof(Line1));

            if (string.IsNullOrWhiteSpace(TownOrCity) &&
                string.IsNullOrWhiteSpace(CountyOrRegion) &&
                string.IsNullOrWhiteSpace(StateOrTerritory))
                throw new ArgumentException($"Must specify a value for at least one of the properties {nameof(TownOrCity)}, " +
                    $"{nameof(CountyOrRegion)} or {nameof(StateOrTerritory)}.");
        }
    }
}
