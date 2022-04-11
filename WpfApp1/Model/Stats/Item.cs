namespace WpfApp1.Model.Stats
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public byte Power { get; set; }

        public delegate void Action(int power);
        public Action UseAction;

        public ushort Cost { get; set; }
        public byte Count { get; set; }

        public void Use()
        {
            UseAction(Power);
        }
    }
}