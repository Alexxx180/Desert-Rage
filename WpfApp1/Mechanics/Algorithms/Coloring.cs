using System.Windows.Media;
using static DesertRage.Customing.Converters.Converters;

namespace DesertRage.Mechanics.Algorithms
{
    public static class Coloring
    {
        public static Color LinearStrategy(int current, int maxValue)
        {
            double all = (current - maxValue * 0.1) <= 0 ? 0 :
                (current - (maxValue * 0.1)) / (maxValue * 0.3);
            double crgrad = all >= 1.0 ? 1.0 : all;
            all = all > 1.0 ? all - 1.0 : 0;
            double mdgrad = all >= 1.0 ? 1.0 : all;
            all = all > 1.0 ? all - 1.0 : 0;
            double mxgrad = all >= 1.0 ? 1.0 : all;
            byte max = (255 * mxgrad).ToByte();
            byte medium = (255 * crgrad).ToByte();
            byte critical = (255 - (255 * mdgrad)).ToByte();
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
            max = (255 * mxgrad).ToByte();
            medium = (255 * crgrad).ToByte();
            critical = (255 - (255 * mdgrad)).ToByte();
        }

        public static Color Flashing(int current, Color color)
        {
            return (current % 2 == 0) ? color :
                Color.FromRgb(255, 255, 255);
        }
    }
}
