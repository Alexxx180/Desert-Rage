using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using DesertRage.Model.Helpers;

namespace DesertRage.Decorators.UI.Bindings.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToBool() ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}