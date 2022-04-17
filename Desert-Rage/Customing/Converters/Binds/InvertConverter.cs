using System;
using System.Globalization;
using System.Windows.Data;

namespace DesertRage.Customing.Converters.Binds
{
    public class InvertConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 1.ToDouble() - (value ?? 0).ToDouble();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
