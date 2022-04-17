using System;
using DesertRage.Customing.Converters;

namespace DesertRage.Model.Stats
{
    public struct Bar
    {
        public Bar(ushort value)
        {
            Current = value;
            Max = value;
        }

        public void Drain(int value)
        {
            ushort downTo = (Current - value).ToUShort();
            Current = Math.Max(downTo, ushort.MinValue);
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

        public ushort Current { get; set; }
        public ushort Max { get; set; }
    }
}