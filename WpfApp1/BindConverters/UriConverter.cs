using DesertRage.Customing.Converters;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DesertRage.BindConverters
{
    public class UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value ?? "/Resources/Images/Locations/Total/Dark.png").ToString().ToUri(UriKind.Relative);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as Uri).AbsoluteUri;
        }

    }
}