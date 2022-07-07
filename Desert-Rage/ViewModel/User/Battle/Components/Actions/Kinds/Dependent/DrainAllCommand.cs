using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.Collections.ObjectModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class DrainAllCommand : DrainCommand
    {
        /// <summary>
        /// Damage all enemies and give
        /// their lost HPs to hero
        /// </summary>
        public DrainAllCommand()
        {
            UnitCursor = Targeting.ALL;
        }

        public override void Use(object parameter)
        {
            Act();

            for (int i = Enemies.Count - 1; i > -1; i--)
            {
                Drain(Enemies[i]);
            }
        }

        protected ObservableCollection<Enemy> Enemies => ViewModel.Enemies;
    }
}
