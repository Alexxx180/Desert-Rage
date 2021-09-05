using System;
using System.Globalization;
using System.Windows.Data;
using static WpfApp1.Customing.Decorators;
using static WpfApp1.Helpers.Paths.Static.Foes;

namespace WpfApp1.Customing.Converters.Binds
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
