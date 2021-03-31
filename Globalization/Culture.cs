using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Energetic.Globalization.ValueObjects
{
    /// <summary>
    /// Represents an ISO 639-1 alpha-2 code for a language
    /// </summary>
    [JsonConverter(typeof(WrappedStringJsonConverter<Culture>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Culture>))]
    public record Culture : WrappedStringValueObject<Culture>
    {
        private readonly Language2CharIsoCode _language;
        private readonly Country2CharIsoCode? _locale = null;
        private readonly CultureInfo _cultureInfo;

        /// <summary>
        /// Constructor for this class
        /// </summary>
        /// <param name="name">The name of a culture including at least the language and optionally the locale. E.g. "en" or "en-GB".</param>
        public Culture(string name) :
            base(name)
        {
            _cultureInfo = GetCultureInfoFromName(name);
            _language = new Language2CharIsoCode(_cultureInfo.TwoLetterISOLanguageName);

            if (!_cultureInfo.IsNeutralCulture)
            {
                string country = GetLocaleFromSpecificCulture(_cultureInfo.Name);
                _locale = new Country2CharIsoCode(country);
            }
        }

        public static string GetLocaleFromSpecificCulture(string cultureName)
        {
            string[] split = cultureName.Split('-');

            if (split.Length != 2)
                throw new FormatException($"{cultureName} is not a specific culture. It needs to be a two character ISO language code " +
                    $"followed by a dash followed by a two character ISO country code (e.g. \"en-GB\").");

            string secondPart = split[1];

            if (secondPart.Length != 2)
                throw new FormatException($"{cultureName} is not a specific culture. It needs to be a two character ISO language code " +
                    $"followed by a dash followed by a two character ISO country code (e.g. \"en-GB\").");

            return secondPart;
        }

        private static CultureInfo GetCultureInfoFromName(string name)
        {
            CultureInfo cultureInfo;

            try
            {
                cultureInfo = new CultureInfo(name);
            }
            catch (CultureNotFoundException)
            {
                throw new FormatException($"{name} is not a valid name for a culture. " +
                    $"It should be a two character ISO language code (e.g. \"en\") " +
                    $"or a two character ISO language code followed by a dash followed by a two character ISO country code (e.g. \"en-GB\").");
            }
            catch (ArgumentNullException)
            {
                throw new FormatException($"A valid culture cannot be constructed from a null or empty string. " +
                    $"It should be a two character ISO language code (e.g. \"en\") " +
                    $"or a two character ISO language code followed by a dash followed by a two character ISO country code (e.g. \"en-GB\").");
            }

            return cultureInfo;
        }

        /// <summary>
        /// Constructs and instance of <see cref="Culture" /> from a manadatory <see cref="Language2CharIsoCode" />
        /// and optional <see cref="Country2CharIsoCode" />
        /// </summary>
        /// <param name="language"></param>
        /// <param name="locale"></param>
        public static Culture FromLanguage(Language2CharIsoCode language, Country2CharIsoCode? locale = null)
        {
            if (language is null)
                throw new ArgumentNullException(nameof(language));

            string cultureInfoString = locale is null ? language.Value : $"{language.Value}-{locale.Value}";
            return new Culture(cultureInfoString);
        }

        /// <summary>
        /// Constructs and instance of <see cref="Culture" /> from a manadatory <see cref="Language2CharIsoCode" />
        /// and <see cref="Country2CharIsoCode" />
        /// </summary>
        /// <param name="language">A mandatory language code.</param>
        /// <param name="locale">A mandatory locale.</param>
        /// <remarks>If you wish the locale to be optional, use <see cref="FromLanguage(Language2CharIsoCode, Country2CharIsoCode?)"/> instead.</remarks>
        public static Culture FromLanguageAndLocale(Language2CharIsoCode language, Country2CharIsoCode locale)
        {
            if (locale is null)
                throw new ArgumentNullException(nameof(locale));

            return FromLanguage(language, locale);
        }

        /// Constructs and instance of <see cref="Culture" /> from a manadatory <see cref="Language2CharIsoCode" />
        /// and optional <see cref="Country2CharIsoCode" />
        /// </summary>
        /// <param name="language"></param>
        /// <param name="locale"></param>
        public static Culture FromCultureInfo(CultureInfo info)
        {
            if (info is null)
                throw new ArgumentNullException(nameof(info));

            return new Culture(info.Name);
        }

        /// <summary>Constructs and instance of <see cref="Culture" /> from the current UI culture
        /// (as found in <see cref="CultureInfo.CurrentUICulture"/>).
        /// </summary>
        public static Culture FromCurrentUICulture
        {
            get
            {
                return FromCultureInfo(CultureInfo.CurrentUICulture);
            }
        }

        public Language2CharIsoCode Language
        {
            get
            {
                return _language;
            }
        }

        public Country2CharIsoCode? Locale
        {
            get
            {
                return _locale;
            }
        }

        public CultureInfo ToCultureInfo()
        {
            return _cultureInfo;
        }
    }
}