using System;
using System.Globalization;
using System.Windows.Data;
using static WpfApp1.Customing.Converters.Converters;

namespace WpfApp1.Customing.Converters.Binds
{
    public class RightTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{Math.Round(Dble(value ?? 0) * 100, 2)}{parameter}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
