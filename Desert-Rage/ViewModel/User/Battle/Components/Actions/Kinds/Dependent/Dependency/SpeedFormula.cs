using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class SpeedFormula : Battle, IFormula, INotifyPropertyChanged
    {
        public int Power => ViewModel.Human.Unit.Stats.Speed;
    }
}