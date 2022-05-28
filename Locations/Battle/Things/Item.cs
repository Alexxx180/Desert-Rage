namespace DesertRage.Model.Locations.Battle.Things
{
    public class Item : PowerUnit
    {
        public Item() { }

        public Item(float power) : base(power) { }

        public Item(float power, string meaning) : this(power)
        {
            Description = $"+{ power} {meaning}";
        }

        public ushort Cost { get; set; }
    }
}