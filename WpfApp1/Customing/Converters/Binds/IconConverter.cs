using System;
using System.Globalization;
using System.Windows.Data;
using static WpfApp1.Customing.Decorators;
using static WpfApp1.Customing.Converters.Converters;
using static WpfApp1.Helpers.Paths.Static.Icon;

namespace WpfApp1.Customing.Converters.Binds
{
    public class IconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte status = Bits(value);
            return status switch
            {
                1 => Bmper(Poison),
                _ => Bmper(Usual),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
