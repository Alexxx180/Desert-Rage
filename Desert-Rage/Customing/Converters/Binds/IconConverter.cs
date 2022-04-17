using System;
using System.Globalization;
using System.Windows.Data;
using static DesertRage.Customing.Decorators;
using static DesertRage.Customing.Converters.Converters;
using static DesertRage.Helpers.Paths.Static.Icon;

namespace DesertRage.Customing.Converters.Binds
{
    public class IconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte status = value.ToByte();
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
