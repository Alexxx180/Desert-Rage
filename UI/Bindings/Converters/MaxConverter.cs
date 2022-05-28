using System;
using System.Globalization;
using System.Windows.Data;
using DesertRage.Model.Helpers;

namespace DesertRage.Decorators.UI.Bindings.Converters
{
    public class MaxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Max(value.ToInt(), parameter.ToInt());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Min(value.ToInt(), parameter.ToInt());
        }
    }
}