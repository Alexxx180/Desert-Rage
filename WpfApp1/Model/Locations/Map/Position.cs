using DesertRage.Customing.Converters;

namespace DesertRage.Model.Locations.Map
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }

        public static Position ToPosition(string position)
        {
            string[] units = position.Split(':');
            return new Position
            {
                X = units[0].ToInt(),
                Y = units[1].ToInt()
            };
        }
    }
}