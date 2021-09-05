using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Customing.Converters.Binds
{
    public class LeftTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{parameter}{value ?? ""}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
