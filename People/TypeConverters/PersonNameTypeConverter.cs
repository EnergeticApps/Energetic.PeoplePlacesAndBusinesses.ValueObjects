using System;
using System.ComponentModel;
using System.Globalization;

namespace Serious.People.ValueObjects.TypeConverters
{
    public class PersonNameTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            try
            {
                return PersonName.FromArray(value as object[]);
            }
            catch(ArgumentException)
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}