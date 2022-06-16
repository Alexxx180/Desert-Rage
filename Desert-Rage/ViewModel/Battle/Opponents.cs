using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.ViewModel.Battle.Components.Participation;
using DesertRage.ViewModel.Battle.Components.Strategy.Fight;

namespace DesertRage.ViewModel.Battle
{
    public abstract class Opponents : Timing
    {
        private protected Opponents() : base()
        {
            Style = Bank.Fights();
            _enemiesPool = new Stack<Enemy>();
            Enemies = new ObservableCollection<Enemy>();
            _flee = new Random();

            FoeEnumeration = new Dictionary<EnemyBestiary, Foe>();
            BossesEnumeration = new Dictionary<EnemyBestiary, Boss>();

            SetFoes();
            SetBosses();
        }

        private protected void Setup
            (in BattleViewModel viewModel)
        {
            for (byte i = 0; i < Max; i++)
                _enemiesPool.Push(new Enemy(viewModel));

            for (byte i = 0; i < Style.Length; i++)
                Style[i].SetViewModel(viewModel);
        }

        private protected abstract void End();
        public abstract void Won();

        #region Option Members
        public void RunAway()
        {
            base.Pause();
            CleanBattlefield();
            End();
        }

        public void SafeFreeze()
        {
            if (IsBattle)
                Freeze();
        }

        private protected virtual void Freeze()
        {
            base.Pause();
            DenyEnemyTurns();
        }

        internal override void Pause()
        {
            if (IsBattle)
                base.Pause();
        }

        internal override void Resume()
        {
            if (IsBattle)
                base.Resume();
        }

        public void Escape(int barrier)
        {
            if (_flee.Next(1, barrier + 1) == 1)
                RunAway();
        }
        #endregion

        #region Enemy Management
        private protected void AllowEnemyTurns()
        {
            for (byte i = 0; i < Enemies.Count; i++)
            {
                StartTurns(Enemies[i]);
            }
        }

        private void DenyEnemyTurns()
        {
            for (byte i = 0; i < Enemies.Count; i++)
                EndTurns(Enemies[i]);
        }

        private protected void RemoveEnemy(in Enemy enemy)
        {
            EndTurns(enemy);
            _ = Enemies.Remove(enemy);
            _enemiesPool.Push(enemy);

            TrapLevel -= enemy.Unit.Stats.Speed;
        }

        internal void EnemyDefeat(in Enemy enemy)
        {
            RemoveEnemy(enemy);

            if (!IsBattle)
                Won();
        }

        private protected void CleanBattlefield()
        {
            while (IsBattle)
                RemoveEnemy(Enemies[0]);
        }
        #endregion

        #region Enemy Properties
        internal readonly IParticipantFight[] Style;

        private ObservableCollection<Enemy> _enemies;
        public ObservableCollection<Enemy> Enemies
        {
            get => _enemies;
            set
            {
                _enemies = value;
                OnPropertyChanged();
            }
        }
        private protected readonly Stack<Enemy> _enemiesPool;

        public bool IsBattle => Enemies.Count > 0;
        private readonly Random _flee;

        public ushort Experience { get; set; }
        public ushort TrapLevel { get; set; }
        
        public const byte Max = 5;
        #endregion

        #region Foe Data Properties
        private void SetFoes()
        {
            Foe[] foes = Bank.Foes();

            for (byte i = 0; i < foes.Length; i++)
            {
                Foe foe = foes[i];
                FoeEnumeration.Add(foe.ID, foe);
            }
        }

        private void SetBosses()
        {
            Boss[] bosses = Bank.Bosses();

            for (byte i = 0; i < bosses.Length; i++)
            {
                Boss boss = bosses[i];
                BossesEnumeration.Add(boss.ID, boss);
            }
        }

        public Dictionary<EnemyBestiary, Foe> FoeEnumeration { get; }
        public Dictionary<EnemyBestiary, Boss> BossesEnumeration { get; }
        #endregion
    }
}