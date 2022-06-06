using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Controls;
using DesertRage.Controls.Menu.Game;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.Resources.Media.OST.Noises.Info;
using DesertRage.ViewModel.Battle;
using DesertRage.ViewModel.Battle.Actions;
using DesertRage.Model;
using System.IO;

namespace DesertRage.ViewModel
{
    public class UserProfile : INotifyPropertyChanged
    {
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

        internal void SetSoundPlayer(SoundGroup sounds)
        {
            SoundPlayer = sounds;
        }
        #endregion

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

        public UserProfile()
        {
            Preferences = new Settings();

            Menu = new GameMenu(this);
            Location = new LevelMap(this);
            Battle = new BattleViewModel(this);

            Equip = new ObservableCollection
                <ObservableCollection<Equipment>>
            {
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>()
            };
            //Equip[ArmoryKind.Hands.Int()].Add(Bank.AllWeapons()[Sets.EMPTY]);
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
            Dictionary<SkillsID, ConsumeCommand> skills = Bank.AllSkills();

            for (byte i = 0; i < keys.Count; i++)
            {
                SkillsID id = keys[i];
                AddSkill(skills[id]);
            }
        }

        private void AddItems()
        {
            List<ConsumeCommand> items = Bank.AllItems();

            for (byte i = 0; i < items.Count; i++)
            {
                AddItem(items[i]);
            }
        }

        private void PlayerEquipment()
        {
            Equipment[][] equipment = Bank.GetEqupment();

            foreach (ArmoryElement element in Hero.Equipment)
            {
                int kind = element.Kind.Int();
                Equipment[] category = equipment[kind];
                Equip[kind].Add(category[element.Set.Int()]);
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
                Battle.SetFoes();
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
                PlayerEquipment();
            }
        }

        public Settings Preferences { get; set; }

        public void AddExperience(int experience)
        {
            if (Hero.Experience.IsSealed)
                return;

            int toNext;

            do
            {
                toNext = Hero.Experience.Max - experience;

                Hero.Experience = Hero.Experience.Restore(experience);

                if (Hero.Experience.IsMax)
                {
                    LevelUp();
                    experience = -toNext;
                }
            }
            while (!Hero.Experience.IsSealed && toNext < 0);

            UpdateHero();
        }

        private void LevelUp()
        {
            NextStats stats = App.Processor.Read
                <NextStats>(Environment.CurrentDirectory +
                "/Resources/Media/Data/Characters/Ray/Next.json");

            Hero.Hp = stats.Hp[Hero.Level];
            Hero.Ap = stats.Ap[Hero.Level];
            Hero.Stats = stats.Stats[Hero.Level];
            Hero.Experience = stats.Experience[Hero.Level];
            Hero.Level++;
        }

        public void UpdateHero()
        {
            OnPropertyChanged(nameof(Hero));
        }
        #endregion

        private ObservableCollection<
            ObservableCollection<Equipment>> _equip;
        public ObservableCollection<
            ObservableCollection<Equipment>> Equip
        {
            get => _equip;
            set
            {
                _equip = value;
                OnPropertyChanged();
            }
        }

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

        #region Map Members
        private void Gates(Position front, 
            char frontTile, char gateTile)
        {
            Level.Map.SetTile(front, frontTile);
            string next = front.ToString();

            if (Level.Gates.ContainsKey(next))
            {
                Position gate = Level.Gates[next];
                Level.Map.SetTile(gate, gateTile);
            }

            OnPropertyChanged(nameof(Level));
        }

        public void Interact()
        {
            Position front = Hero.Front;

            switch (Level.Map.Tile(front))
            {
                case '$':
                    break;
                case 'K':
                    Gates(front, '.', '.');
                    break;
                case '>':
                    Gates(front, '<', '.');
                    break;
                case '<':
                    Gates(front, '>', 'H');
                    break;
                default:
                    break;
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
        #endregion

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