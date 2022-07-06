namespace DesertRage.Model.Locations.Battle.Things
{
    [StructLayout(LayoutKind.Explicit)] 
    public struct Attribute
    {
        [FieldOffset(0)] public float Power { get; set; }
        [FieldOffset(0)] public int Value;
    }
}
