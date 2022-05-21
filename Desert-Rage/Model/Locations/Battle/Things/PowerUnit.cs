namespace DesertRage.Model.Locations.Battle.Things
{
    public class PowerUnit : DescriptionUnit
    {
        public PowerUnit(float power)
        {
            Power = power;
        }

        public PowerUnit() : this(0f) { }

        public float Power { get; }
    }
}