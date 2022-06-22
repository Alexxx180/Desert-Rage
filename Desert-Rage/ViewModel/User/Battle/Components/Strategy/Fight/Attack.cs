using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Strategy.Fight
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
            ushort power = Stats.Attack;
            power += Stats.Special;

            Victim.Hit(power);
        }

        public virtual void Dispose()
        {
            Unit = null;
            SetModel(null);
        }

        public virtual IParticipantFight Clone()
        {
            return new Attack
            {
                Unit = Unit,
                ViewModel = ViewModel
            };
        }

        public Participant Victim => ViewModel.Human;
        public BattleStats Stats => Unit.Stats;

        public BattleUnit Unit { get; set; }
    }
}