namespace DesertRage.Model.Menu.Things
{
    public class Thing : DescriptionUnit
    {
        public delegate void Action(int power);
        public Action UseAction { get; set; }
    }
}