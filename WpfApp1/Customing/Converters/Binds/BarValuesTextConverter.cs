using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Customing.Converters.Binds
{
    public class BarValuesTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 0)
                return "0/0";
            foreach (object val in values)
                if (val == null)
                    return "0/0";
            return $"{parameter ?? ""}{values[0]}/{values[1]}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
