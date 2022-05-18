using DesertRage.Controls.Scenes;
using DesertRage.Controls.Scenes.Battle.Strategy.Appear;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Locations;
using DesertRage.Customing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Model.Stats.Enemy;
using System.Windows.Input;
using DesertRage.ViewModel.Actions;
using DesertRage.Model.Menu.Things;
using DesertRage.ViewModel.Actions.Dependent;
using DesertRage.ViewModel.Actions.Independent;
using System.Windows.Threading;
using System;
using DesertRage.ViewModel.Battle;
using DesertRage.Model.Menu.Things.Logic;

namespace DesertRage.ViewModel
{
    public class BattleViewModel : INotifyPropertyChanged
    {
        private readonly EnemyAppearing _drawStrategy;

        private UserProfile _player;
        public UserProfile Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged();
            }
        }

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

        private ObservableCollection<ActCommand> _skills;
        public ObservableCollection<ActCommand> Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                _skills.SetViewModel(this);
                OnPropertyChanged();
            }
        }

        private void AddSkill(ActCommand skill)
        {
            skill.SetViewModel(this);
            Skills.Add(skill);
        }

        private void AddSkills()
        {
            List<SkillsID> keys = Player.Hero.Skills;
            Dictionary<SkillsID, ActCommand> skills = Bank.Skills();

            for (byte i = 0; i < keys.Count; i++)
            {
                SkillsID id = keys[i];
                AddSkill(skills[id]);
            }
        }
        
        #region Timing Members
        private DispatcherTimer _timing;

        public void SetTurns()
        {
            _timing = new DispatcherTimer();
            _timing.Tick += BattleTurns;
            _timing.Interval = new TimeSpan(0, 0, 0, 0, 50);
        }

        private void BattleTurns(object sender, object o)
        {
            for (byte i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].WaitForTurn();
            }
        }

        public void Start()
        {
            Enemies.Refresh(_drawStrategy.Build());
            _timing.Start();

            foreach(Enemy enemy in Enemies)
            {
                System.Diagnostics.Trace.WriteLine(enemy.Foe.Name);
            }
        }
        #endregion

        public BattleViewModel()
        {
            Player = LevelMap.GetUserData();
            
            Skills = new ObservableCollection<ActCommand>();
            AddSkills();

            Dictionary<EnemyBestiary, Foe> allEnemies = Bank.Foes();
            EnemyBestiary[] bestiary = Location.GetFoes();
            Foe[] foes = new Foe[bestiary.Length];

            for (byte i = 0; i < foes.Length; i++)
            {
                EnemyBestiary id = bestiary[i];
                foes[i] = allEnemies[id];
            }

            _drawStrategy = new DockStrategy
                (this, BattleScene.SceneArea, foes);

            Enemies = new ObservableCollection<Enemy>();

            SetTurns();

            Start();
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