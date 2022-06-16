using System;
using System.Globalization;
using System.Windows.Data;
using DesertRage.Model.Helpers;

namespace DesertRage.Decorators.UI.Bindings.Converters
{
    public class InvertConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (parameter.ToInt() - value.ToInt()) / 100.00;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter.ToInt() + value.ToDouble() * 100;
        }
    }
}