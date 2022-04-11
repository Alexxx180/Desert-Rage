﻿using System.Collections;
using WpfApp1.Model.Stats.Player.Armory;

namespace WpfApp1.Model.Stats
{
    internal class Character
    {
        public Character()
        {
            Status = new BitArray(1);
        }

        #region Hp Management Members
        public void Hit(int value)
        {
            Hp.Drain(value);
        }

        public void Cure()
        {
            Hp.Restore();
        }

        public void Cure(int value)
        {
            Hp.Restore(value);
        }
        #endregion

        #region Ap Management Members
        public void Act(int value)
        {
            Ap.Drain(value);
        }

        public void Rest()
        {
            Ap.Restore();
        }

        public void Rest(int value)
        {
            Ap.Restore(value);
        }
        #endregion

        public string Name { get; set; }
        public Profile HeroProfile;

        public byte Level { get; set; }
        public ushort Experience { get; set; }

        public Bar Hp;
        public Bar Ap;

        public BattleStats Stats;
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
