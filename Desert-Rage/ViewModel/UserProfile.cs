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
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.Resources.Media.OST.Noises.Info;
using DesertRage.ViewModel.Battle;
using DesertRage.ViewModel.Battle.Components.Actions;

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

        public void AddEquipment
            (ArmoryElement armor,
            Equipment[][] equipment)
        {
            int kind = armor.Kind.Int();
            Equipment piece = equipment
                [kind][armor.Set.Int()];

            Equip[kind].Add(piece);
        }

        private void AddEquipment(ArmoryElement armor)
        {
            if (Hero.Equipment.Contains(armor))
                return;

            Hero.Equipment.Add(armor);
            OnPropertyChanged(nameof(Hero));

            AddEquipment(armor, Bank.GetEqupment());
        }

        private void PlayerEquipment()
        {
            Equipment[][] equipment = Bank.GetEqupment();

            Hero.Equipment.ForEach(AddEquipment, equipment);
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
                Battle.SetFoes(value.StageFoes);
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

        public void Hit(int value)
        {
            value -= Equip[ArmoryKind.Torso.Int()]
                [Hero.SelectedArmor.Defence].Power;
            value -= Equip[ArmoryKind.Legs.Int()]
                [Hero.SelectedArmor.Speed].Power;
            value -= Equip[ArmoryKind.Feet.Int()]
                [Hero.SelectedArmor.Special].Power;

            Hero.Hit(value);
            //UpdateHero();
        }

        public void AddExperience(int experience)
        {
            if (Hero.Experience.IsSealed)
                return;

            int toNext;

            do
            {
                toNext = Hero.Experience.Max - experience;

                Hero.Experience.Fill(experience.ToUShort());

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
            NextStats stats = Bank.GetNextStats("Ray");
            byte level = Hero.Level;

            Hero.Hp.Set(stats.Hp[level]);
            Hero.Ap.Set(stats.Ap[level]);
            Hero.Stats = stats.Stats[level];
            Hero.Experience.Set(stats.Experience[level]);
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
        private void NewCharacter
            (string name, bool condition)
        {
            //if (condition)
            //    Bank.SaveCharacter(name);
        }

        private void NextChapter()
        {
            Location next = Bank.LoadLevel(Level.NextChapter);
            if (next is null)
            {
                //NewCharacter("Rock", Hero.Name.Length == 0);
                //NewCharacter("Sam", Hero.SelectedArmor.Equals
                //    (new BattleStats(Sets.SERIOUS.ToByte())));
                Battle.Entry.RaiseEscape();
            }
            else
            {
                Level.SetChapter(next);
                Hero.SetPlace(Level.Start);
                OnPropertyChanged(nameof(Level));
                Battle.SetFoes(Level.StageFoes);
            }
        }

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

        private ArmoryElement Chest
            (Position front, char frontTile)
        {
            Level.Map.SetTile(front, frontTile);
            OnPropertyChanged(nameof(Level));
            return Level.Equipment[front.ToString()];
        }

        public void Interact()
        {
            Position front = Hero.Front;

            switch (Level.Map.Tile(front))
            {
                case '$':
                    ArmoryElement armor = Chest(front, 'E');
                    AddEquipment(armor);
                    break;
                case 'I':
                    ArmoryElement secret = Chest(front, '.');
                    AddEquipment(secret);
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
                case 'X':
                    NextChapter();
                    break;
                default:
                    break;
            }
        }

        public void Go(Direction move)
        {
            if (Hero.Hp.IsEmpty)
                return;

            bool fight = Hero.Go(Level.Map, move.Int());
            Position current = Hero.Place;

            switch (Level.Map.Tile(current))
            {
                case ':':
                    Hero.Hp.Drain(1);
                    if (Hero.Hp.IsEmpty)
                    {
                        Battle.Entry.RaiseEscape();
                        return;
                    }
                    break;
                case '_':
                    Gates(current, '.', '.');
                    break;
                case 'T':
                    Hero.SetPlace(Level.Warps[current.ToString()]);
                    break;
                default:
                    break;
            }

            if (fight)
            {
                IsFighting = true;
                SoundPlayer.PlayNoise(InfoNoises.EnemyWind);
            }
        }

        internal void ResetDanger()
        {
            Hero.ToBattle = Level.Danger.Random();
            IsFighting = false;
        }

        public void Stand()
        {
            Hero.Stand();
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