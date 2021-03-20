using Serious.People.ValueObjects;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Serious.Globalization.ValueObjects.TypeConverters
{
    public class PersonTitleTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return new PersonTitle(value as string);
        }
    }
}