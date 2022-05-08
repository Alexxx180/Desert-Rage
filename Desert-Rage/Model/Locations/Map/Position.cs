﻿namespace DesertRage.Model.Locations.Map
{
    public struct Position
    {
        public Position(int size)
        {
            X = size;
            Y = size;
        }

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

        public bool IsOutTop(Position mask)
        {
            return X < mask.X
                || Y < mask.Y;
        }

        public bool IsOutBottom(Position mask)
        {
            return X > mask.X
                || Y > mask.Y;
        }

        #region Override Methods Members
        public override string ToString()
        {
            return $"{X}:{Y}";
        }
        #endregion

        #region Override Operators Members
        public static Position operator +
            (Position start, int increment)
        {
            return new Position
            {
                X = start.X + increment,
                Y = start.Y + increment
            };
        }

        public static Position operator +
            (Position start, Position increment)
        {
            return new Position
            {
                X = start.X + increment.X,
                Y = start.Y + increment.Y
            };
        }

        public static Position operator -
            (Position end, int decrement)
        {
            return new Position
            {
                X = end.X - decrement,
                Y = end.Y - decrement
            };
        }

        public static Position operator -
            (Position end, Position decrement)
        {
            return new Position
            {
                X = end.X - decrement.X,
                Y = end.Y - decrement.Y
            };
        }

        public static bool operator <=
            (Position original, Position compareTo)
        {
            return original.X <= compareTo.X
                && original.Y <= compareTo.Y;
        }

        public static bool operator >=
            (Position original, Position compareTo)
        {
            return original.X >= compareTo.X
                && original.Y >= compareTo.Y;
        }

        public static bool operator <
            (Position original, Position compareTo)
        {
            return original.X < compareTo.X
                && original.Y < compareTo.Y;
        }

        public static bool operator >
            (Position original, Position compareTo)
        {
            return original.X > compareTo.X
                && original.Y > compareTo.Y;
        }
        #endregion

        public int X { get; set; }
        public int Y { get; set; }
    }
}