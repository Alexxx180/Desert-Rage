namespace DesertRage.Model.Stats
{
    public class Item
    {
        public delegate void Action(int power);
        public Action UseAction;

        public void Use()
        {
            UseAction(Power);
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public byte Power { get; set; }

        public ushort Cost { get; set; }
        public byte Count { get; set; }
    }
}