using DesertRage.Model.Menu.Things.Commands;

namespace DesertRage.Model.Menu.Things
{
    public class Skill : DescriptionUnit
    {
        public string Noise { get; set; }

        public float Power { get; set; }

        public byte Level { get; set; }
        public byte Cost { get; set; }

        public string[] Animation { get; set; }
        public string[] IconAnimation { get; set; }

        public ActionCommand Action { get; set; }
    }
}