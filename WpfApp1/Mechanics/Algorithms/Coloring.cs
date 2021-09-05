using System.Windows.Media;
using static WpfApp1.Customing.Converters.Converters;

namespace WpfApp1.Mechanics.Algorithms
{
    public static class Coloring
    {
        public static Color LinearStrategy(int current, int maxValue)
        {
            double all = (current - maxValue * 0.1) <= 0 ? 0 : (current - maxValue * 0.1) / (maxValue * 0.3);
            double crgrad = all >= 1.0 ? 1.0 : all;
            all = all > 1.0 ? all - 1.0 : 0;
            double mdgrad = all >= 1.0 ? 1.0 : all;
            all = all > 1.0 ? all - 1.0 : 0;
            double mxgrad = all >= 1.0 ? 1.0 : all;
            byte max = Bits(Shrt(255 * mxgrad));
            byte medium = Bits(Shrt(255 * crgrad));
            byte critical = Bits(255 - Bits(255 * mdgrad));
            return Color.FromRgb(critical, medium, max);
        }

        public static void LinearStrategy(out byte max, out byte medium, out byte critical, int current, int maxValue)
        {
            double all = (current - maxValue * 0.1) <= 0 ? 0 : (current - maxValue * 0.1) / (maxValue * 0.3);
            double crgrad = all >= 1.0 ? 1.0 : all;
            all = all > 1.0 ? all - 1.0 : 0;
            double mdgrad = all >= 1.0 ? 1.0 : all;
            all = all > 1.0 ? all - 1.0 : 0;
            double mxgrad = all >= 1.0 ? 1.0 : all;
            max = Bits(Shrt(255 * mxgrad));
            medium = Bits(Shrt(255 * crgrad));
            critical = Bits(255 - Bits(255 * mdgrad));
        }

        public static Color Flashing(int current, Color color)
        {
            return (current % 2 == 0) ? color : Color.FromRgb(255, 255, 255);
        }
    }
}
