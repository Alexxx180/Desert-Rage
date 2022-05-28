using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;

namespace DesertRage.Decorators.UI.Bindings.Converters
{
    public class MapConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string[] map = values[0] as string[];

            Dictionary<string, string>
                tiles = values[1] as
                Dictionary<string, string>;

            if (values[2] is not
                Position current
                || tiles is null)
                return null;

            string tile = tiles["."];

            if (map is null)
                return tile;

            current += parameter.ToString().ToPosition();

            if (current.IsOverflow(0, map))
                return tile;

            string code = map.Tile(current);
            if (tiles.ContainsKey(code))
            {
                tile = tiles[code];
            }

            return tile;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
