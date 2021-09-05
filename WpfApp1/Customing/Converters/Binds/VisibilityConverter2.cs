using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using static WpfApp1.Customing.Converters.Converters;

namespace WpfApp1.Customing.Converters.Binds
{
    public class VisibilityConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Bits(value) < Bits(parameter) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
