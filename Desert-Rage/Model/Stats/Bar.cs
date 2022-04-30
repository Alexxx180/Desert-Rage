using System;
using DesertRage.Customing.Converters;

namespace DesertRage.Model.Stats
{
    public struct Bar
    {
        public Bar(
            ushort minimum,
            ushort current,
            ushort maximum
            )
        {
            Minimum = minimum;
            Current = current;
            Max = maximum;
        }

        public Bar(
            ushort current,
            ushort maximum
            ) : this(0, current, maximum)
        {

        }

        public Bar(ushort value) : this(value, value)
        {

        }

        public void Drain(int value)
        {
            ushort downTo = (Current - value).ToUShort();
            Current = Math.Max(downTo, Minimum);
        }

        public void Restore(int value)
        {
            ushort upTo = (Current + value).ToUShort();
            Current = Math.Min(upTo, Max);
        }

        public void Restore()
        {
            Current = Max;
        }

        public ushort Minimum { get; set; }
        public ushort Current { get; set; }
        public ushort Max { get; set; }
    }
}