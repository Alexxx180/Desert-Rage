using System;
using DesertRage.Customing.Converters;

namespace DesertRage.Model.Locations.Battle.Stats
{
    public struct Bar
    {
        #region Bar Constructor Members
        public Bar(
            ushort minimum,
            ushort current,
            ushort maximum)
        {
            Minimum = minimum;
            Current = current;
            Max = maximum;
        }

        public Bar(ushort current, ushort maximum) :
            this(0, current, maximum)
        { }

        public Bar(ushort value) : this(value, value) { }

        public Bar
            (ushort minimum, int current, ushort maximum)
        {
            Minimum = minimum;
            Current = Clamp(minimum, current, maximum);
            Max = maximum;
        }
        #endregion

        #region Bar Behaviour Members
        public Bar Drain(int value)
        {
            return new Bar(Minimum, Current - value, Max);
        }

        public Bar Restore(int value)
        {
            return new Bar(Minimum, Current + value, Max);
        }

        public Bar Drain()
        {
            return new Bar(Minimum, Minimum, Max);
        }

        public Bar Restore()
        {
            return new Bar(Minimum, Max, Max);
        }
        #endregion

        #region Overriden Members
        public override string ToString()
        {
            return $"{ Current } / { Max } ({ Minimum } - { Max })";
        }
        #endregion

        public static ushort Clamp
            (ushort minimum, int current, ushort maximum)
        {
            return Math.Clamp(current, minimum, maximum).ToUShort();
        }

        public bool IsMax => Current >= Max;
        public bool IsEmpty => Current <= Minimum;

        public ushort Minimum { get; set; }
        public ushort Current { get; set; }
        public ushort Max { get; set; }
    }
}