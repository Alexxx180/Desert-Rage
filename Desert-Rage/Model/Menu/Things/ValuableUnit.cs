namespace DesertRage.Model.Menu.Things
{
    public class ValuableUnit : DescriptionUnit
    {
        public ValuableUnit(float power)
        {
            Power = power;
        }

        public ValuableUnit() : this(0f) { }

        public float Power { get; }
        public byte Value { get; set; }
    }
}