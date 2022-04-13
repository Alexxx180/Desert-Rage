namespace DesertRage.Model.Locations.Map
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public override string ToString()
        {
            return $"{X}:{Y}";
        }
    }
}