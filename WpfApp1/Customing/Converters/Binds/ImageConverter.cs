using System;
using System.Globalization;
using System.Windows.Data;
using static DesertRage.Customing.Decorators;
using static DesertRage.Helpers.Paths.Static.Foes;

namespace DesertRage.Customing.Converters.Binds
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Bmper(DeadIcon);
            return Bmper(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
