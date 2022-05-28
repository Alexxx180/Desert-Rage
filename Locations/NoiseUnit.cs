namespace DesertRage.Model.Locations
{
    public class NoiseUnit : DescriptionUnit
    {
        public NoiseUnit() { }

        public NoiseUnit(string meaning) : base(meaning) { }

        public NoiseUnit(int value,
            string meaning) : base($"+{value} {meaning}") { }

        public string Noise { get; set; }
    }
}