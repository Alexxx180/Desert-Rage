namespace DesertRage.Model.Locations.Battle.Stats
{
    public class Armor
    {
        public Armor() { }

        public Armor(byte set)
        {
            Weapon = set;
            Torso = set;
            Legs = set;
            Feet = set;
        }

        public byte Weapon { get; set; }
        public byte Torso { get; set; }
        public byte Legs { get; set; }
        public byte Feet { get; set; }
    }
}