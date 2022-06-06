using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class FightAllCommand : FightCommand, IAction, INotifyPropertyChanged
    {
        public FightAllCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.ALL;
        }

        protected ObservableCollection<Enemy> Enemies => ViewModel.Enemies;

        public override void Use(object parameter)
        {
            Act();

            for (int i = Enemies.Count - 1; i > -1; i--)
            {
                Damage(Enemies[i]);
            }
        }
    }
}