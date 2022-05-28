namespace DesertRage.Model.Locations.Battle.Things
{
    public class Skill : PowerUnit
    {
        public Skill(float power) : base(power) { }
        public Skill() : base() { }

        public string Noise { get; set; }

        public string[] Animation { get; set; }
        public string[] IconAnimation { get; set; }
    }
}