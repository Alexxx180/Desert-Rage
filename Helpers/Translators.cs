using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using System;

namespace DesertRage.Model.Helpers
{
    public static class Translators
    {
        public static int Boost
            (this bool status, int min, int max)
        {
            return status ? max : min;
        }

        public static int Boost
            (this bool status, int multiply)
        {
            return status.Boost(1, multiply);
        }

        public static char Tile
            (this char[][] map, Position place)
        {
            return map[place.Y][place.X];
        }

        public static void SetTile
            (this char[][] map,
            Position place, char setTo)
        {
            map[place.Y][place.X] = setTo;
        }

        public static bool From
            (this Random random, Bar chance)
        {
            return random.Next(chance.Minimum,
                chance.Max) == chance.Current;
        }

        public static int Next
            (this Random random, IPlaceAble chance)
        {
            return random.Next(chance.X, chance.Y);
        }
    }
}