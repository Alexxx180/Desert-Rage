namespace DesertRage.Model.Menu.Things
{
    public class Skill : ValuableUnit
    {
        public Skill(float power) : base(power) { }
        public Skill() : base() { }

        public string Noise { get; set; }
        public byte Level { get; set; }

        public string[] Animation { get; set; }
        public string[] IconAnimation { get; set; }
    }
}