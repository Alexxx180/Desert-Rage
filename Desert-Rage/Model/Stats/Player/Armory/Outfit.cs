using System;

namespace DesertRage.Model.Stats.Player.Armory
{
    [Serializable]
    public struct Outfit
    {
        public Outfit(byte suit)
        {
            Weapon = suit;
            Armor = suit;
            Pants = suit;
            Boots = suit;
        }

        public byte Weapon { get; set; }
        public byte Armor { get; set; }
        public byte Pants { get; set; }
        public byte Boots { get; set; }
    }
}