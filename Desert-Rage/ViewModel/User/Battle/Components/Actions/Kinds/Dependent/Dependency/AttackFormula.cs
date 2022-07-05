﻿using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class AttackFormula : Battle, IFormula, INotifyPropertyChanged
    {
        /// <summary>
        /// Power dependency, based on hero equipment and attack stat
        /// </summary>
        public AttackFormula() { }

        static AttackFormula()
        {
            _class = ArmoryKind.Hands;
        }

        private protected static readonly ArmoryKind _class;
        protected int Boost => Hero.Boost(StatusID.REINFORCEMENT);

        protected MapWorker User => ViewModel.Human.Player;
        protected Character Hero => User.Hero;

        public virtual int Power
        {
            get
            {
                int power = Hero.Stats.Attack;
                byte selection = Hero.Equipped.Weapon;
                power += User.Resist(_class, selection);
                power *= Boost;
                return power;
            }
        }
    }
}
