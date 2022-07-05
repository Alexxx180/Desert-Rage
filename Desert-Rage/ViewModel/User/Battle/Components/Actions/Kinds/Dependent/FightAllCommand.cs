using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class FightAllCommand : FightCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Damage all enemies on the field
        /// </summary>
        /// <param name="dependency">Damage power formula</param>
        /// <param name="thing">Thing info</param>
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
