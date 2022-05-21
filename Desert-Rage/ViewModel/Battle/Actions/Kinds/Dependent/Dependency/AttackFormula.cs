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

        public int Power => ViewModel.Player.Hero.Stats.Attack + _applier;
    }
}