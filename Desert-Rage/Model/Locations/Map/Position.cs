namespace DesertRage.Model.Locations.Map
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position(Position start, int increment)
        {
            X = start.X + increment;
            Y = start.Y + increment;
        }

        public void Increment(Position distance)
        {
            X += distance.X;
            Y += distance.Y;
        }

        public bool IsOverflow(int min, string[] map)
        {
            bool overFlow = Y < min || Y >= map.Length;

            if (!overFlow)
            {
                overFlow = X < min || X >= map[Y].Length;
            }

            return overFlow;
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}