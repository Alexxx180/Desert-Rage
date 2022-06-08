using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle
{
    public class Enemy : Participant, INotifyPropertyChanged, IViewModelObservable<BattleViewModel>
    {
        public Enemy(Foe foe)
        {
            _foe = foe;
            Time = new Bar(0, 1000);
            OnPropertyChanged(nameof(Unit));
            OnPropertyChanged(nameof(Size));
            OnPropertyChanged(nameof(Experience));
        }

        public Enemy(BattleViewModel viewModel, Foe foe) : this(foe)
        {
            SetViewModel(viewModel);
            
        }

        private Foe _foe;

        public override BattleUnit Unit => _foe;
        public byte Experience => _foe.Experience;

        private protected override void Damage(int value)
        {
            Unit.Hit(value);
        }

        private protected override void Defeat()
        {
            ViewModel.EnemyDefeat(this);
        }

        public override void WaitForTurn(object sender, object o)
        {
            base.WaitForTurn(sender, o);
            if (Time.IsMax)
            {
                Time = Time.Drain();
                Turn();
            }
        }

        private void Turn()
        {
            Attack();
        }

        private void Attack()
        {
            IsAct = true;

            ushort attack = Unit.Stats.Attack;
            attack += Unit.Stats.Special;

            ViewModel.Human.Hit(attack);

            IsAct = false;
        }

        public Position Tile { get; set; }
        public Position Size => _foe.Size;
    }
}