using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DesertRage.Customing.Converters.Binds
{
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToBool() ?
                Visibility.Collapsed :
                Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}