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

        public Bar(
            ushort current,
            ushort maximum) :
            this(0, current, maximum)
        { }

        public Bar(ushort value) :
            this(value, value) { }
        #endregion

        #region Overriden Members
        public override string ToString()
        {
            return $"{ Current } / { Max } ({ Minimum } - { Max })";
        }
        #endregion

        public ushort Minimum { get; set; }
        public ushort Current { get; set; }
        public ushort Max { get; set; }
    }
}