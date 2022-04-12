using System;
using System.Globalization;
using System.Windows.Data;

namespace DesertRage.Customing.Converters.Binds
{
    public class AccessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToUShort() >= parameter.ToUShort();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
