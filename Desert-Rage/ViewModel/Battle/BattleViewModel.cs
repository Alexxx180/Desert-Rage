using System;
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

namespace DesertRage.ViewModel.Battle
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

        #region Battle Commands
        private ObservableCollection<ConsumeCommand> _skills;
        public ObservableCollection<ConsumeCommand> Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ConsumeCommand> _items;
        public ObservableCollection<ConsumeCommand> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private void AddSkill(ConsumeCommand skill)
        {
            skill.SetViewModel(this);
            Skills.Add(skill);
        }

        private void AddItem(ConsumeCommand item)
        {
            item.SetViewModel(this);
            Items.Add(item);
        }

        private void AddSkills()
        {
            List<SkillsID> keys = Player.Hero.Skills;
            Dictionary<SkillsID, ConsumeCommand> skills = Bank.Skills();

            for (byte i = 0; i < keys.Count; i++)
            {
                SkillsID id = keys[i];
                AddSkill(skills[id]);
            }
        }

        private void AddItems()
        {
            List<ConsumeCommand> items = Bank.Items();

            for (byte i = 0; i < items.Count; i++)
            {
                AddItem(items[i]);
            }
        }

        private InstantCommand _fight;
        public InstantCommand Fight
        {
            get => _fight;
            set
            {
                _fight = value;
                OnPropertyChanged();
            }
        }

        private InstantCommand _shield;
        public InstantCommand Shield
        {
            get => _shield;
            set
            {
                _shield = value;
                OnPropertyChanged();
            }
        }

        private InstantCommand _flee;
        public InstantCommand Flee
        {
            get => _flee;
            set
            {
                _flee = value;
                OnPropertyChanged();
            }
        }

        private InstantCommand _auto;
        public InstantCommand Auto
        {
            get => _auto;
            set
            {
                _auto = value;
                OnPropertyChanged();
            }
        }
        #endregion

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

            foreach (Enemy enemy in Enemies)
            {
                System.Diagnostics.Trace.WriteLine(enemy.Foe.Name);
            }
        }
        #endregion

        public void UpdateItems()
        {
            OnPropertyChanged(nameof(Items));
        }

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
            Player = profile;
            //Player = LevelMap.GetUserData();

            Skills = new ObservableCollection<ConsumeCommand>();
            AddSkills();

            Items = new ObservableCollection<ConsumeCommand>();
            AddItems();

            _drawStrategy = new DockStrategy
                (this, BattleScene.SceneArea, GetFoes());

            Enemies = new ObservableCollection<Enemy>();

            Fight = new InstantCommand(
                new FightCommand(
                    new AttackFormula(0),
                    new NoiseUnit("Пустой слот")
                    {
                        Name = "Пусто",
                        Noise = WeaponNoises.Punch
                    }
                )
            );

            Shield = new InstantCommand(
                new StatusCommand(StatusID.DEFENCE, true,
                    new NoiseUnit()
                    {
                        Noise = ActionNoises.DefenceBoost
                    }
                )
            );

            Flee = new InstantCommand(
                new EscapeCommand(
                    new SpeedFormula(),
                    new NoiseUnit()
                    {
                        Noise = ActionNoises.Flee
                    }
                )
            );

            Auto = new InstantCommand(
                new StatusCommand(StatusID.BERSERK, true,
                    new NoiseUnit()
                    {
                        Noise = ActionNoises.PowerBoost
                    }
                )
            );

            Shield.SetViewModel(this);
            Fight.SetViewModel(this);
            Flee.SetViewModel(this);
            Auto.SetViewModel(this);

            SetTurns();

            Start();
        }

        public void End()
        {
            Trace.WriteLine("YOHOO!");
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