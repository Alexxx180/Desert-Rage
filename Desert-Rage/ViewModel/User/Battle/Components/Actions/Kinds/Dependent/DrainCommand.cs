using DesertRage.ViewModel.User.Battle.Components.Participation;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class DrainCommand : FightCommand
    {
        /// <summary>
        /// Hit selected enemy and
        /// give its lost HPs to hero
        /// </summary>

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
