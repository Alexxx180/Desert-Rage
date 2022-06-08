using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency
{
    public class AttackFormula : Battle, IFormula, INotifyPropertyChanged
    {
        public AttackFormula() { }

        static AttackFormula()
        {
            _weapon = ArmoryKind.Hands.Int();
        }

        private static readonly int _weapon;
        protected int Boost => Hero.Boost(StatusID.REINFORCEMENT);

        protected UserProfile User => ViewModel.Human.Player;
        protected Character Hero => User.Hero;

        public int Power => (Hero.Stats.Attack + User.Equip[_weapon]
            [Hero.SelectedArmor.Attack].Power) * Boost;
    }
}