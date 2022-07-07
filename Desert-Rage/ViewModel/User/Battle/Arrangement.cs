using System;
using System.Collections.Generic;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations;
using DesertRage.ViewModel.User.Battle.Components.Strategy.Appear;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using Serilog;

namespace DesertRage.ViewModel.User.Battle
{
    public abstract class Arrangement : Opponents
    {
        /// <summary>
        /// Opponents battle field arrangement 
        /// </summary>
        private protected Arrangement() : base()
        {
            _drawStrategy = new DockStrategy
                (BattleScene.SceneArea);
        }

        private protected virtual void Prepare()
        {
            Experience = 0;
            CleanBattlefield();
        }

        private void Charge
            (Tuple<Position, Foe> foeNavigation)
        {
            Enemy enemy = _enemiesPool.Pop();
            enemy.Reset(foeNavigation);

            Experience += enemy.Experience;
            TrapLevel += enemy.Unit.Stats.Speed;
            Enemies.Add(enemy);
        }

        public virtual void Start(Boss boss)
        {
            Prepare();

            Charge(new Tuple<Position, Foe>
                (new Position(), boss));

            AllowEnemyTurns();
        }

        public virtual void Start()
        {
            Prepare();

            List<Tuple<Position, Foe>>
                foes = _drawStrategy.Build();

            for (byte i = 0; i < foes.Count; i++)
            {
                Charge(foes[i]);
            }

            AllowEnemyTurns();
        }

        internal void SetFoes(EnemyBestiary[] bestiary)
        {
            Log.Debug("Loading stage enemies...");
            Foe[] stageFoes = new Foe[bestiary.Length];

            for (byte i = 0; i < stageFoes.Length; i++)
            {
                EnemyBestiary id = bestiary[i];
                stageFoes[i] = FoeEnumeration[id];
            }

            _drawStrategy.ResetEnemies(stageFoes);
        }

        private readonly IEnemyAppearing _drawStrategy;
    }
}
