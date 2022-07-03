using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Participation;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class DrainCommand : FightCommand
    {
        public DrainCommand(IFormula dependency) : base(dependency)
        {
            UnitCursor = Targeting.ONE;
        }

        public DrainCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.ONE;
        }

        protected virtual void Restore(ushort points)
        {
            Hero.Cure(points);
        }

        public void Drain(in Enemy enemy)
        {
            ushort points = enemy.Unit.Hp.Current;
            Act();
            Damage(enemy);
            points -= enemy.Unit.Hp.Current;
            Restore(points);
        }

        public override void Use(object parameter)
        {
            Enemy enemy = parameter as Enemy;
            Drain(enemy);
        }
    }
}