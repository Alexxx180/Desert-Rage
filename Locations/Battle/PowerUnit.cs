namespace DesertRage.Model.Locations.Battle
{
    public class PowerUnit : DescriptionUnit
    {
        public PowerUnit() { }

        public PowerUnit(byte power)
        {
            Power = power;
        }

        public byte Power { get; set; }
    }
}