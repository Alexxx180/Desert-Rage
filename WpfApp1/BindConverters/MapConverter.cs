using DesertRage.Customing.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DesertRage.BindConverters
{
    public class MapConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, string> tiles = values[0] as Dictionary<string, string>;

            //int x = values[1];

            return values.ToBool() ?
                Visibility.Visible :
                Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
