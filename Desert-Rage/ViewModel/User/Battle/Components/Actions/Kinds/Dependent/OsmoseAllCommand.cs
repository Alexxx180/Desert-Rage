using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.Collections.ObjectModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class OsmoseAllCommand : OsmoseCommand
    {
        public OsmoseAllCommand(IFormula dependency) : base(dependency)
        {
            UnitCursor = Targeting.ONE;
        }

        public OsmoseAllCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.ONE;
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