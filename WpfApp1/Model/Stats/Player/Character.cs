using System.Collections;
using WpfApp1.Model.Stats.Player.Armory;

namespace WpfApp1.Model.Stats
{
    internal class Character
    {
        public Character()
        {
            Status = new BitArray(1);
        }

        public void Cure(int value)
        {

        }

        public string Name { get; set; }
        public Profile HeroProfile { get; set; }

        public byte Level { get; set; }
        public ushort Experience { get; set; }

        public Bar Hp { get; set; }
        public Bar Ap { get; set; }

        public BattleStats Stats { get; set; }
        public byte Special { get; set; }

        public BitArray Status { get; set; }

        public Weapon Weapon { get; set; }
        public Equipment Armor { get; set; }
        public Equipment Legs { get; set; }
        public Equipment Boots { get; set; }

        public BitArray Learned { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
