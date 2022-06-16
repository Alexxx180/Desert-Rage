using System;
using System.Globalization;
using System.Windows.Data;
using DesertRage.Model.Helpers;

namespace DesertRage.Decorators.UI.Bindings.Converters
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToDouble() / 100.00;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToDouble() * 100.00;
        }
    }
}