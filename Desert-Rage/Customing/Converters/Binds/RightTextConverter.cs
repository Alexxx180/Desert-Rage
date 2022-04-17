using System;
using System.Globalization;
using System.Windows.Data;

namespace DesertRage.Customing.Converters.Binds
{
    public class RightTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (value ?? 0.0).ToDouble() * 100;
            return $"{Math.Round(number, 2)}{parameter}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}