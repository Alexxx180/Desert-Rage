using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency
{
    public class SpeedFormula : Battle, IFormula, INotifyPropertyChanged
    {
        public int Power => ViewModel.Player.Hero.Stats.Speed;
    }
}