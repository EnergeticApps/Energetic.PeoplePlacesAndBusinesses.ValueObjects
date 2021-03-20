using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Energetic.Globalization.ValueObjects
{
    public abstract record LocalizableStringBase : ValueObject<LocalizableStringBase, (string, CultureInfoName)>
    {
        public LocalizableStringBase(string content, CultureInfoName locale) : base((content, locale)) { }

        public LocalizableStringBase(string content, Language2CharIsoCode language) : base((content, new CultureInfoName(language))) { }
    }
}
