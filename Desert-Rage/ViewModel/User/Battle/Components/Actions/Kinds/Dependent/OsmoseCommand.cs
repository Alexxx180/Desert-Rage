using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class OsmoseCommand : DrainCommand
    {
        public OsmoseCommand(IFormula dependency) : base(dependency)
        {
            UnitCursor = Targeting.ONE;
        }

        /// <summary>
        /// Hit selected enemy and
        /// fill with its lost HPs
        /// hero APs
        /// </summary>
        /// <param name="dependency">Damage power formula</param>
        /// <param name="thing">Thing info</param>
        public OsmoseCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.ONE;
        }

        protected override void Restore(ushort points)
        {
            Hero.Rest(points);
        }
    }
}
