using DesertRage.Model.Locations.Battle;
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
        public FightAllCommand()
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
