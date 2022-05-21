namespace DesertRage.Model.Locations.Battle.Things
{
    public class ValuableUnit : PowerUnit
    {
        public ValuableUnit(float power) : base(power) { }

        public ValuableUnit() : this(0f) { }

        public byte Value { get; set; }
    }
}