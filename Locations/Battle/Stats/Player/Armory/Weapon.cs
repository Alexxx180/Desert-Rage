namespace DesertRage.Model.Locations.Battle.Stats.Player.Armory
{
    public class Weapon : Equipment
    {
        public Weapon() { }

        public Weapon(byte power) : base(power) { }

        public Weapon(byte power, string name) : this(power)
        {
            Name = name;
        }

        public string Noise { get; set; }
    }
}