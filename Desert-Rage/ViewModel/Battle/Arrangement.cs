﻿using System;
using System.Collections.Generic;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.ViewModel.Battle.Components.Strategy.Appear;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations;
using DesertRage.ViewModel.Battle.Components.Participation;
using DesertRage.Model.Helpers;

namespace DesertRage.ViewModel.Battle
{
    public abstract class Arrangement : Opponents
    {
        private protected Arrangement() : base()
        {
            _drawStrategy = new DockStrategy
                (BattleScene.SceneArea);
        }

        public virtual void Start()
        {
            Experience = 0;
            CleanBattlefield();

            List<Tuple<Position, Foe>>
                foes = _drawStrategy.Build();

            for (byte i = 0; i < foes.Count; i++)
            {
                Enemy enemy = _enemiesPool.Pop();
                enemy.Reset(foes[i]);

                Experience += enemy.Experience;
                TrapLevel += enemy.Unit.Stats.Speed;

                Enemies.Add(enemy);
            }

            AllowEnemyTurns();
        }

        internal void SetFoes(EnemyBestiary[] bestiary)
        {
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