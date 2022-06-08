using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.ViewModel.Battle.Strategy.Fight;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle
{
    public class Enemy : Participant, INotifyPropertyChanged, IViewModelObservable<BattleViewModel>
    {
        private Enemy(Foe foe) : base()
        {
            _foe = foe;
            _strategy = Bank.FightStrategy(foe);
            
            OnPropertyChanged(nameof(Size));
            OnPropertyChanged(nameof(Experience));
        }

        public Enemy(BattleViewModel viewModel, Foe foe) : this(foe)
        {
            SetViewModel(viewModel);
            _strategy.SetViewModel(viewModel);
        }

        private protected override void Damage(int value)
        {
            Unit.Hit(value);
        }

        private protected override void Defeat()
        {
            ViewModel.EnemyDefeat(this);
        }

        private void Turn()
        {
            IsAct = true;

            _strategy.Fight();

            IsAct = false;
        }

        public override void WaitForTurn(object sender, object o)
        {
            base.WaitForTurn(sender, o);
            if (Time.IsMax)
            {
                Time.Drain();
                Turn();
            }
        }

        private Foe _foe;
        public override BattleUnit Unit => _foe;

        public byte Experience => _foe.Experience;
        private readonly IParticipantFight _strategy;

        public Position Tile { get; set; }
        public Position Size => _foe.Size;
    }
}