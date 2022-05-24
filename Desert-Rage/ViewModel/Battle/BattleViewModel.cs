﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using DesertRage.Controls.Scenes;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Customing;
using DesertRage.Model.Locations;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.ViewModel.Battle.Actions;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Strategy.Appear;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.ViewModel.Battle.Actions.Kinds;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using DesertRage.Model;
using DesertRage.ViewModel.Battle.Actions.Kinds.Independent;
using System.Diagnostics;
using DesertRage.Resources.OST.Noises.Weapons;
using DesertRage.Resources.OST.Noises.Actions;
using System.Windows;

namespace DesertRage.ViewModel.Battle
{
    public class BattleViewModel : INotifyPropertyChanged
    {
        private readonly EnemyAppearing _drawStrategy;

        private Person _human;
        public Person Human
        {
            get => _human;
            set
            {
                _human = value;
                OnPropertyChanged();
            }
        }

        #region Enemy Members
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

        private Foe[] GetFoes()
        {
            Dictionary<EnemyBestiary, Foe> allEnemies = Bank.Foes();
            EnemyBestiary[] bestiary = Location.GetFoes();
            Foe[] foes = new Foe[bestiary.Length];

            for (byte i = 0; i < foes.Length; i++)
            {
                EnemyBestiary id = bestiary[i];
                foes[i] = allEnemies[id];
            }
            return foes;
        }

        public bool IsBattle => Enemies.Count > 0;
        #endregion

        #region Timing Members
        private DispatcherTimer _timing;

        public void SetTurns()
        {
            _timing = new DispatcherTimer();
            _timing.Interval = new TimeSpan(0, 0, 0, 0, 50);
            BattleTurns();
        }

        private void BattleTurns()
        {
            _timing.Tick += Human.WaitForTurn;
            for (byte i = 0; i < Enemies.Count; i++)
                _timing.Tick += Enemies[i].WaitForTurn;
        }

        public void EnemyTurnsOver(in Enemy enemy)
        {
            _timing.Tick -= enemy.WaitForTurn;
        }

        public void Start()
        {
            Enemies.Refresh(_drawStrategy.Build());
            _timing.Start();

            foreach (Enemy enemy in Enemies)
            {
                Trace.WriteLine(enemy.Foe.Name);
            }
        }
        #endregion

        public ushort EnemySpeed()
        {
            ushort overallSpeed = 0;
            for (byte i = 0; i < Enemies.Count; i++)
            {
                overallSpeed += Enemies[i].Foe.Stats.Speed;
            }
            return overallSpeed;
        }

        public BattleViewModel(UserProfile profile)
        {
            Human = new Person(this, profile);
            Enemies = new ObservableCollection<Enemy>();

            _drawStrategy = new DockStrategy
                (this, BattleScene.SceneArea, GetFoes());

            SetTurns();
            Start();
        }

        public void End()
        {
            _timing.Stop();
            Trace.WriteLine("YOHOO!");
        }

        public void Lose()
        {
            _timing.Stop();
            Application.Current.Shutdown();
        }

        public void RunAway()
        {
            Enemies.Clear();
            End();
        }

        public void Escape(int barrier)
        {
            Random fleeChance = new Random();

            if (fleeChance.Next(1, barrier + 1) == 1)
            {
                End();
            }
            else
            {
                Trace.WriteLine("NO....");
            }
        }

        public void Pause()
        {
            if (IsBattle)
                _timing.Stop();
        }

        public void Resume()
        {
            if (IsBattle)
                _timing.Start();
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}