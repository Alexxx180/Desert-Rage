namespace DesertRage.Model.Locations.Battle.Things
{
    public class Item : PowerUnit
    {
        public Item() { }

        public Item(byte power) : base(power) { }

        public Item(byte power, string meaning) : this(power)
        {
            Description = $"+{ power} {meaning}";
        }

        public ushort Cost { get; set; }
    }
}