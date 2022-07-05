using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.Collections.ObjectModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class DrainAllCommand : DrainCommand
    {
        public DrainAllCommand(IFormula dependency) : base(dependency)
        {
            UnitCursor = Targeting.ONE;
        }

        /// <summary>
        /// Damage all enemies and give
        /// their lost HPs to hero
        /// </summary>
        /// <param name="dependency">Damage power formula</param>
        /// <param name="thing">Thing info</param>
        public DrainAllCommand(IFormula dependency,
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
