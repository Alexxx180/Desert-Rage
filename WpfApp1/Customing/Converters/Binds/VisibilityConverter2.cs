using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace DesertRage.Customing.Converters.Binds
{
    public class VisibilityConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToByte() < parameter.ToByte() ?
                Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}