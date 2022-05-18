namespace DesertRage.Model.Menu.Things
{
    public class Item : ValuableUnit
    {
        public Item() { }

        public Item(float power) : base(power) { }

        public Item(float power, string meaning)
        {
            Description = $"+{ power} {meaning}";
        }

        public ushort Cost { get; set; }
    }
}