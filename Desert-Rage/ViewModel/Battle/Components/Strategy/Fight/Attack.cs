using DesertRage.Model.Locations.Battle.Stats;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Components.Strategy.Fight
{
    public class Attack : Battle, IParticipantFight, INotifyPropertyChanged
    {
        public Attack() { }

        public void SetUnit(BattleUnit unit)
        {
            Unit = unit;
        }

        public virtual void Fight()
        {
            ushort power = Unit.Stats.Attack;
            power += Unit.Stats.Special;

            System.Diagnostics.Trace.WriteLine(ViewModel.Human.Player.Hero.Hp);
            System.Diagnostics.Trace.WriteLine(power);
            ViewModel.Human.Hit(power);
        }

        public virtual void Dispose()
        {
            Unit = null;
            SetViewModel(null);
        }

        public virtual IParticipantFight Clone()
        {
            return new Attack
            {
                Unit = Unit,
                ViewModel = ViewModel
            };
        }

        public BattleUnit Unit { get; set; }
    }
}