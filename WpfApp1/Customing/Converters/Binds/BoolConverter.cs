using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using static WpfApp1.Customing.Converters.Converters;

namespace WpfApp1.Customing.Converters.Binds
{
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Bool(value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
