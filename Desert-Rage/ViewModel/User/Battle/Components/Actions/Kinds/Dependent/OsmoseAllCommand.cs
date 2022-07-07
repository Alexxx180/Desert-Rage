using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.Collections.ObjectModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class OsmoseAllCommand : OsmoseCommand
    {
        /// <summary>
        /// Damage all enemies and
        /// fill with their lost HPs
        /// hero APs
        /// </summary>
        public OsmoseAllCommand()
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
