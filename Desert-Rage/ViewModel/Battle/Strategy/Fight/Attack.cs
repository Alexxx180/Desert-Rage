using DesertRage.Model.Locations.Battle.Stats;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Strategy.Fight
{
    public class Attack : Battle, IParticipantFight, INotifyPropertyChanged
    {
        public Attack(BattleUnit unit)
        {
            Unit = unit;
        }

        public virtual void Fight()
        {
            ushort power = Unit.Stats.Attack;
            power += Unit.Stats.Special;

            System.Diagnostics.Trace.WriteLine(power);

            System.Diagnostics.Trace.WriteLine(ViewModel.Human.Player.Hero.Hp);
            ViewModel.Human.Hit(power);
            System.Diagnostics.Trace.WriteLine(ViewModel.Human.Player.Hero.Hp);
        }

        public BattleUnit Unit { get; }
    }
}