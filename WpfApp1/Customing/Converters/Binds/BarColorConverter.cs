using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using static WpfApp1.Customing.Converters.Converters;
using static WpfApp1.Mechanics.Algorithms.Coloring;

namespace WpfApp1.Customing.Converters.Binds
{
    public class BarColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 0)
                return new SolidColorBrush(Color.FromRgb(0, 255, 255));
            foreach (object val in values)
                if (val == null)
                    return new SolidColorBrush(Color.FromRgb(0, 255, 255));
            
            int current = Numb(values[0]);
            int maxValue = Numb(values[1]);
            int variant = Numb(parameter);
            LinearStrategy(out byte max, out byte medium, out byte critical, current, maxValue);
            return variant switch
            {
                1 => new SolidColorBrush(Color.FromRgb(max, critical, medium)),
                _ => new SolidColorBrush(Color.FromRgb(critical, medium, max))
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
        //R 0   G 255 B 255 100%
        //R 0   G 255 B 127 85%
        //R 0   G 255 B 0   70%
        //R 127 G 255 B 0   55%
        //R 255 G 255 B 0   40%
        //R 255 G 127 B 0   25%
        //R 255 G 0   B 0   10%
        //  crit, medium, max
    }
}
