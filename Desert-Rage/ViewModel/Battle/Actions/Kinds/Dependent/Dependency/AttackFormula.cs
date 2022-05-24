using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency
{
    public class AttackFormula : Battle, IFormula, INotifyPropertyChanged
    {
        public AttackFormula(int applier)
        {
            _applier = applier;
        }

        private readonly int _applier;

        protected int Boost => Hero.Boost(StatusID.REINFORCEMENT);
        protected Character Hero => ViewModel.Human.Player.Hero;

        public int Power => Hero.Stats.Attack * Boost + _applier;
    }
}