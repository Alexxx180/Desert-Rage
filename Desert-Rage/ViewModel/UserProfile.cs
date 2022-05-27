using DesertRage.Controls;
using DesertRage.Controls.Menu.Game;
using DesertRage.Controls.Scenes;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Customing.Converters;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.Resources.OST.Noises.Info;
using DesertRage.ViewModel.Battle;
using DesertRage.ViewModel.Battle.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel
{
    public class UserProfile : INotifyPropertyChanged
    {
        private BattleViewModel _battle;
        public BattleViewModel Battle
        {
            get => _battle;
            set
            {
                _battle = value;
                OnPropertyChanged();
            }
        }

        #region UI Members
        public GameMenu Menu { get; set; }

        private SoundGroup _soundPlayer;
        public SoundGroup SoundPlayer
        {
            get => _soundPlayer;
            set
            {
                _soundPlayer = value;
                OnPropertyChanged();
            }
        }

        private LevelMap _location;
        public LevelMap Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }
        #endregion

        internal void SetSoundPlayer(SoundGroup sounds)
        {
            SoundPlayer = sounds;
        }

        public UserProfile()
        {
            Preferences = new Settings();

            Menu = new GameMenu(this);
            Location = new LevelMap(this);
            Battle = new BattleViewModel(this);

            //BattleStart += EnemyApproaches;
        }

        public void LoadHeroCommands()
        {
            Skills = new ObservableCollection<ConsumeCommand>();
            AddSkills();

            Items = new ObservableCollection<ConsumeCommand>();
            AddItems();
        }

        #region Command Members
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

        public void UpdateItems()
        {
            OnPropertyChanged(nameof(Items));
        }

        private void AddSkill(ConsumeCommand skill)
        {
            skill.SetViewModel(Battle);
            Skills.Add(skill);
        }

        private void AddItem(ConsumeCommand item)
        {
            item.SetViewModel(Battle);
            Items.Add(item);
        }

        private void AddSkills()
        {
            List<SkillsID> keys = Hero.Skills;
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
        #endregion

        #region Model Members
        public string Name { get; set; }

        private Location _level;
        public Location Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged();
            }
        }

        private Character _hero;
        public Character Hero
        {
            get => _hero;
            set
            {
                _hero = value;
                OnPropertyChanged();
            }
        }

        public Settings Preferences { get; set; }
        #endregion

        #region Equipment Members
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Equipment> Armor { get; set; }
        public ObservableCollection<Equipment> Pants { get; set; }
        public ObservableCollection<Equipment> Boots { get; set; }
        #endregion

        private bool _isFighting;
        public bool IsFighting
        {
            get => _isFighting;
            set
            {
                _isFighting = value;
                OnPropertyChanged();
            }
        }

        public void Go(Direction move)
        {
            if (Hero.Go(Level.Map, move.Int()))
            {
                IsFighting = true;
                SoundPlayer.PlayNoise(InfoNoises.EnemyWind);
            }

            UpdateHero();
        }

        internal void ResetDanger()
        {
            Hero.ToBattle = Level.Danger.Random();
            IsFighting = false;
        }

        public void Stand()
        {
            Hero.Stand();
            UpdateHero();
        }

        public void UpdateHero()
        {
            OnPropertyChanged(nameof(Hero));
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