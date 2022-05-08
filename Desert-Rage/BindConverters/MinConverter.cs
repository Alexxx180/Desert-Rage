using DesertRage.Customing.Converters;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DesertRage.BindConverters
{
    public class MinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Min(value.ToInt(), parameter.ToInt());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Max(value.ToInt(), parameter.ToInt());
        }
    }
}