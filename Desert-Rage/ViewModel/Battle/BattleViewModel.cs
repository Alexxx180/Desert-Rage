using System;
using System.Collections.Generic;
using System.ComponentModel;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.ViewModel.Battle.Strategy.Appear;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Decorators;

namespace DesertRage.ViewModel.Battle
{
    public class BattleViewModel : BattleOptions, INotifyPropertyChanged
    {
        private BattleViewModel() : base()
        {
            Experience = 0;
            _drawStrategy = new DockStrategy
                (this, BattleScene.SceneArea);
            Scene = new BattleScene(this);
        }

        public BattleViewModel(UserProfile profile) : this()
        {
            Human = new Person(this, profile);
            _timing.Tick += Human.WaitForTurn;
        }

        #region UI Members
        public BattleScene Scene { get; set; }
        public MainWindow Entry { get; set; }
        #endregion

        #region Hero Members
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

        internal ushort Experience { get; set; }
        #endregion

        #region Enemy Members
        internal void SetFoes()
        {
            Dictionary<EnemyBestiary, Foe> allEnemies = Bank.Foes();
            EnemyBestiary[] bestiary = Human.Player.Level.StageFoes;
            Foe[] foes = new Foe[bestiary.Length];

            for (byte i = 0; i < foes.Length; i++)
            {
                EnemyBestiary id = bestiary[i];
                foes[i] = allEnemies[id];
            }

            _drawStrategy.ResetEnemies(foes);
        }

        private readonly EnemyAppearing _drawStrategy;
        #endregion

        #region Option Members
        public override void Start()
        {
            Entry.Display.Content = Scene;

            Enemies.Refresh(_drawStrategy.Build());
            for (byte i = 0; i < Enemies.Count; i++)
            {
                Experience += Enemies[i].Foe.Experience;
            }

            EnemyTurns();
            Scene.RaiseEnter();
        }

        private protected override void End()
        {
            Experience = 0;
            Scene.RaiseEscape();
        }

        private protected override void Freeze()
        {
            base.Freeze();
            _timing.Tick -= Human.WaitForTurn;
        }

        public override void Won()
        {
            Human.Player.AddExperience(Experience);
            End();
        }

        public override void Lose()
        {
            Freeze();
            Entry.RaiseEscape();
        }

        public void Escape(int barrier)
        {
            Random fleeChance = new Random();

            if (fleeChance.Next(1, barrier + 1) == 1)
                RunAway();
        }
        #endregion
    }
}