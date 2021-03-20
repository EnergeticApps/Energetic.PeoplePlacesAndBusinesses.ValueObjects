using Energetic.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Energetic.ValueObjects;

namespace Energetic.People.ValueObjects
{
    //TODO: I think we can just use default JSON serialization for this class. Check if that's right
    //[JsonConverter(typeof(PersonNameJsonConverter))]
    //[TypeConverter(typeof(PersonNameTypeConverter))]
    public record PersonName : ValueObject<PersonName, (PersonTitle?, string?, IEnumerable<string>?, string?, IEnumerable<string>?, string?, string?)>
    {
        private PersonName() : base((PersonTitle.None, string.Empty, null, null, null, null, null)) 
        {
            IsUnknown = true;
        }

        public PersonName(string givenName) : this(PersonTitle.None, givenName)
        {
            if (string.IsNullOrWhiteSpace(givenName))
                throw new StringArgumentNullOrWhiteSpaceException(nameof(givenName));
        }

        public PersonName(string givenName,
            string familyName) : this(PersonTitle.None, givenName, null, familyName)
        {
        }

        public PersonName(PersonTitle title,
            string familyName) : this(title, string.Empty, familyName)
        {
        }

        public PersonName(PersonTitle title,
            string givenName,
            string familyName) : this(title, givenName, null, familyName)
        {
        }

        public PersonName(PersonTitle title,
            string? givenName = null,
            IEnumerable<string>? middleNames = null,
            string? familyName = null,
            IEnumerable<string>? nickNames = null,
            string? preferredName = null,
            string? fullName = null) : base((title, givenName, middleNames, familyName, nickNames, preferredName, fullName))
        {
            Title = title;
            GivenName = givenName?.Trim();
            MiddleNames = middleNames;
            FamilyName = familyName?.Trim();
            FullName = fullName ?? MakeFullName( title, givenName, middleNames, familyName);
            NickNames = nickNames;
            PreferredName = preferredName ?? MakePreferredName(title, givenName, middleNames, familyName);
        }

        public static PersonName Unknown => new PersonName(string.Empty);

        public PersonTitle Title { get; }
        public string? GivenName { get; }
        public IEnumerable<string>? MiddleNames { get; }
        public string? FamilyName { get; }
        public string FullName { get; }
        public IEnumerable<string>? NickNames { get; }
        public string PreferredName { get; }
        public bool HasTitle => !Title.HasNone();

        public bool IsKnown
        {
            get
            {
                return !IsUnknown;
            }
        }

        public bool IsUnknown
        {
            get; init;
        }


        private static string MakePreferredName(
            PersonTitle? title,
            string? givenName,
            IEnumerable<string>? middleNames,
            string? familyName)
        {
            if (!string.IsNullOrWhiteSpace(title?.Value) && !string.IsNullOrWhiteSpace(familyName))
                return $"{title.Value} {familyName}";

            if (!string.IsNullOrWhiteSpace(title?.Value) && !string.IsNullOrWhiteSpace(givenName))
                return $"{title.Value} {givenName}";

            if (!string.IsNullOrWhiteSpace(givenName))
                return givenName;

            if (!string.IsNullOrWhiteSpace(familyName))
                return familyName;

            if (middleNames is { })
                return middleNames.FirstOrDefault(m => !string.IsNullOrWhiteSpace(m));
            
            throw new ArgumentException("Not enough information about this person was passed to generate a value for" +
                    $"his/her {nameof(PreferredName)}.");
        }

        private static string MakeFullName(
            PersonTitle? title,
            string? givenName,
            IEnumerable<string>? middleNames,
            string? familyName)
        {
            StringBuilder builder = new StringBuilder(title?.Value);
            builder.Append($" {givenName}");

            if (middleNames is { })
            {
                foreach (string middleName in middleNames)
                {
                    builder.Append($" {middleName}");
                }
            }

            if(!string.IsNullOrWhiteSpace(familyName))
            {
                builder.Append($" {familyName}");
            }

            return builder.ToString().CollapseMultipleSpaces().Trim();
        }
    }
}
