namespace DesertRage.Model.Locations.Battle
{
    public struct Range
    {
        public Range(Position start, Position size)
        {
            Point1 = start;
            Point2 = start + size - 1;
        }

        public Position BottomLeft()
        {
            return new Position
                (Point1.X, Point2.Y);
        }

        public Position TopRight()
        {
            return new Position
                (Point2.X, Point1.Y);
        }

        public Position Size()
        {
            return Point2 - Point1 + 1;
        }

        public override string ToString()
        {
            return $"{{ {Point1}, {Point2} }}";
        }

        public bool IsOverflow(Range mask)
        {
            return Point1.IsOutTop(mask.Point1)
                || Point2.IsOutBottom(mask.Point2);
        }

        public Position Point1 { get; set; }
        public Position Point2 { get; set; }
    }
}