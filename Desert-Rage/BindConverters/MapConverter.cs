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

            string tile = "/Resources/Images/Locations/Total/Dark.png";

            if (values[2] is not Position current)
                return tile;

            if (map is null ||
                tiles is null)
                return tile;

            current.Increment(parameter.ToString().ToPosition());

            if (current.IsOverflow(0, map))
                return tile;

            string code = map.Tile(current);
            if (tiles.ContainsKey(code))
            {
                tile = tiles[code];
            }

            //System.Diagnostics.Trace.WriteLine(tiles.Count);

            //System.Diagnostics.Trace.WriteLine(tiles.ContainsKey(code));

            //System.Diagnostics.Trace.WriteLine(current.ToString());

            //System.Diagnostics.Trace.WriteLine(tile);

            return tile;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
