using DesertRage.Customing.Converters;

namespace DesertRage.Model.Menu.Things
{
    public class Skill : Thing
    {
        public void Use(ushort special)
        {
            UseAction((special * Power).ToInt());
        }

        public string Noise { get; set; }

        public float Power { get; set; }

        public byte Level { get; set; }
        public byte Cost { get; set; }

        public string[] Animation { get; set; }
        public string[] IconAnimation { get; set; }
    }
}
