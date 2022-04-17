using DesertRage.Customing.Converters;

namespace DesertRage.Model.Stats
{
    public class Skill
    {
        public delegate void Action(int power);
        public Action UseAction;

        public void Use(ushort special)
        {
            UseAction((special * Power).ToInt());
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Noise { get; set; }

        public float Power { get; set; }

        public byte Level { get; set; }
        public byte Cost { get; set; }

        public string[] Animation { get; set; }
        public string[] IconAnimation { get; set; }
    }
}
