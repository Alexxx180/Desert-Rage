namespace DesertRage.Model.Locations.Battle
{
    public class NoiseUnit : PowerUnit
    {
        public NoiseUnit() { }

        public NoiseUnit(byte power) : base(power) { }

        public string Noise { get; set; }
    }
}