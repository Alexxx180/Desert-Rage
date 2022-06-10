using System;
using System.ComponentModel;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.ViewModel.Battle.Components.Strategy.Fight;

namespace DesertRage.ViewModel.Battle.Components.Participation
{
    public class Enemy : Participant, INotifyPropertyChanged
    {
        private Enemy() : base()
        {
            _foe = new Foe();
            _strategy = new Attack();
        }

        public Enemy(BattleViewModel viewModel) : this()
        {
            SetViewModel(viewModel);
        }

        public void Reset(Tuple<Position, Foe> unit)
        {
            Tile = unit.Item1;
            _foe.Set(unit.Item2);

            _strategy.Dispose();
            _strategy = ViewModel.Style
                [_foe.Strategy.Int()].Clone();
            _strategy.SetUnit(_foe);
        }

        private protected override void Damage(int value)
        {
            _foe.Hit(value);
            OnPropertyChanged(nameof(Unit));
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
        private IParticipantFight _strategy;

        public Position Tile { get; set; }
        public Position Size => _foe.Size;
    }
}