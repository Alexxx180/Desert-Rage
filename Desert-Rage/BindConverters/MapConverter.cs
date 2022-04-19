using DesertRage.Customing.Converters;
using DesertRage.Model.Locations.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace DesertRage.BindConverters
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
                return "/Resources/Images/Locations/Total/Dark.svg";

            string tile = tiles["."];

            if (map is null)
                return tile;

            current.Increment(parameter.ToString().ToPosition());

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
