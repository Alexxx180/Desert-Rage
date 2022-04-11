namespace WpfApp1.Model.Stats
{
    public struct Bar
    {
        public Bar(ushort value)
        {
            Current = value;
            Max = value;
        }

        public ushort Current { get; set; }
        public ushort Max { get; set; }
    }
}