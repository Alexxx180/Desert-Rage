using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class AnnihilateAllCommand : AnnihilateCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Defeat all enemies on the field
        /// </summary>        

        public override void Use(object parameter)
        {
            Act();

            for (int i = Enemies.Count - 1; i > -1; i--)
            {
                Defeat(Enemies[i]);
            }
        }

        protected ObservableCollection<Enemy> Enemies => ViewModel.Enemies;
    }
}
