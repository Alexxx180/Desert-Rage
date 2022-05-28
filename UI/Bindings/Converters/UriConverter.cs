using System;
using System.Globalization;
using System.Windows.Data;

namespace DesertRage.Decorators.UI.Bindings.Converters
{
    public class UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value ?? parameter).ToString().ToUri(UriKind.Relative);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as Uri).AbsoluteUri;
        }
    }
}