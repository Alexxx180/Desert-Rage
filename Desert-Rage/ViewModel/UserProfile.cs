using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using DesertRage.Controls;
using DesertRage.Controls.Menu.Game;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Things.Storage;
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

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

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

        private ObservableCollection<Foe> _bestiary;
        public ObservableCollection<Foe> Bestiary
        {
            get => _bestiary;
            set
            {
                _bestiary = value;
                OnPropertyChanged();
            }
        }

        private DispatcherTimer _deadlyTimer;

        private void PauseLevel()
        {
            _deadlyTimer.Stop();
        }

        private void ResumeLevel()
        {
            _deadlyTimer.Start();
        }

        public UserProfile()
        {
            _deadlyTimer = new DispatcherTimer();
            _deadlyTimer.Interval = new TimeSpan(0, 0, 1);
            _deadlyTimer.Tick += Countdown;

            _chance = new Random();
            Preferences = Bank.LoadPreferences();

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

        public void AnalyzeFoe(EnemyBestiary id)
        {
            if (Hero.Learned.Contains(id))
                return;

            Hero.Learn(id);
            AddFoe(id);
        }

        private void AddFoe(EnemyBestiary id)
        {
            if (Battle.FoeEnumeration.ContainsKey(id))
            {
                AddFoe(Battle.FoeEnumeration[id]);
            }
            else if (Battle.BossesEnumeration.ContainsKey(id))
            {
                AddFoe(Battle.BossesEnumeration[id]);
            }
        }

        private void AddFoe(Foe foe)
        {
            foe.Analyze(true);
            Bestiary.Add(foe);
        }

        private void LoadHeroBestiary()
        {
            Bestiary = new ObservableCollection<Foe>();
            foreach (EnemyBestiary id in Hero.Learned)
            {
                AddFoe(id);
            }
        }

        public void LoadHeroCommands()
        {
            Skills = new ObservableCollection<ConsumeCommand>();
            AddSkills();

            Items = new ObservableCollection<ConsumeCommand>();
            AddItems();

            _itemSurprise = new Position(0, Items.Count);
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
            Dictionary<SkillsID, ConsumeCommand> skills = Bank.AllSkills();

            foreach (SkillsID id in Hero.Skills)
            {
                AddSkill(skills[id]);
            }
        }

        private void AddItems()
        {
            List<ConsumeCommand> items = Bank.AllItems();

            for (byte i = 0; i < items.Count; i++)
            {
                items[i].Subject.SetValue(Hero.Items[i]);
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
            if (!Hero.Equipment.Add(armor))
                return;

            UpdateHero();
            AddEquipment(armor, Bank.GetEqupment());
        }

        private void PlayerEquipment()
        {
            Equipment[][] equipment = Bank.GetEqupment();

            Hero.Equipment.ForEach(AddEquipment, equipment);
        }
        #endregion

        #region Model Members

        #region Serializable Members
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
                LoadHeroBestiary();
                LoadHeroCommands();
            }
        }

        public Settings Preferences { get; set; }

        public void SetHeroStart()
        {
            Hero.SetPlace(Level.Start);
        }

        public void SetHero(Character hero)
        {
            Hero = hero;
        }

        public void SetLevel(Location level)
        {
            Level = level;
            Resume();
        }

        public void Resume()
        {
            if (Level.IsTimeChamber)
                ResumeLevel();
        }

        public void Pause()
        {
            if (Level.IsTimeChamber)
                PauseLevel();
        }

        private void SaveProfileName()
        {
            Bank.SavePreferences(Preferences);
        }

        public void SetName(string name)
        {
            Preferences.Name = name;
            SaveProfileName();
        }

        public void SetPreferences(Settings preferences)
        {
            Preferences.Set(preferences);
            SaveProfileName();
        }

        public void UpdateHero()
        {
            OnPropertyChanged(nameof(Hero));
        }

        public void UpdateLevel()
        {
            OnPropertyChanged(nameof(Level));
        }
        #endregion

        public void IncreaseItemCount(ItemsID item)
        {
            int id = item.Int();
            IncreaseItemCount(id);
        }

        private void IncreaseItemCount(int id)
        {
            if (Hero.Items[id] < byte.MaxValue)
                Items[id].Subject.SetValue(++Hero.Items[id]);
        }

        public void DecreaseItemCount(ItemsID item)
        {
            int id = item.Int();
            if (Hero.Items[id] <= 0)
                return;

            Items[id].Subject.SetValue(--Hero.Items[id]);
        }

        internal void SaveGame()
        {
            Sound("Info/Map/Save.mp3");
            Hero.Cure();
            Hero.Rest();

            string profile = Preferences.Name;

            //System.Diagnostics.Trace.WriteLine(profile);
            //System.Diagnostics.Trace.WriteLine(Preferences);

            if (profile == string.Empty)
                return;

            Bank.SaveProfileHero(profile, Hero);
            Bank.SaveProfileLevel(profile, Level);
            Bank.SaveProfilePreferences(profile, Preferences);
        }

        public void Hit(int value)
        {
            value -= Equip[ArmoryKind.Torso.Int()]
                [Hero.SelectedArmor.Defence].Power;
            value -= Equip[ArmoryKind.Legs.Int()]
                [Hero.SelectedArmor.Speed].Power;
            value -= Equip[ArmoryKind.Feet.Int()]
                [Hero.SelectedArmor.Special].Power;

            Hero.Hit(value);
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

        private Position _itemSurprise;
        #endregion

        private ObservableCollection
            <ObservableCollection<Equipment>> _equip;
        public ObservableCollection
            <ObservableCollection<Equipment>> Equip
        {
            get => _equip;
            set
            {
                _equip = value;
                OnPropertyChanged();
            }
        }

        private Encounter _isFighting;
        public Encounter IsFighting
        {
            get => _isFighting;
            set
            {
                _isFighting = value;
                OnPropertyChanged();
            }
        }

        #region OST Members
        public void Stop()
        {
            SoundPlayer.Sound1.Stop();
        }

        public void Peace()
        {
            Music(Level.MusicPeace);
        }

        public void Fight()
        {
            Music(Level.MusicFight);
        }

        public void Music(string name)
        {
            SoundPlayer.PlayMusic(name.ToFull());
        }

        public void Sound(string name)
        {
            SoundPlayer.PlaySound
                ($"/Resources/Media/OST/Sounds/{name}".ToFull());
        }

        public void Noise(string name)
        {
            SoundPlayer.PlayNoise
                ($"/Resources/Media/OST/Noises/{name}".ToFull());
        }
        #endregion

        #region Map Members
        private void NewCharacter
            (string name, bool condition)
        {
            //if (condition)
            //    Bank.SaveCharacter(name);
        }

        private void NextChapter()
        {
            Sound("Info/Map/Teleport.mp3");
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
                UpdateLevel();
                Battle.SetFoes(Level.StageFoes);
                Peace();

                Resume();
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

            UpdateLevel();
        }

        private void MessageToUser(string prefix, Position place)
        {
            MessageToUser(prefix + Level.Messages[place.ToString()]);
        }

        private void MessageToUser(Position place)
        {
            MessageToUser(Level.Messages[place.ToString()]);
        }

        private void MessageToUser(string message)
        {
            Message = message;
        }

        private ArmoryElement Chest
            (Position front, char frontTile)
        {
            Sound("Info/Map/Chest.mp3");
            SetTile(front, frontTile);
            MessageToUser(front);
            return Level.Equipment[front.ToString()];
        }

        private void SetTile(Position front, char frontTile)
        {
            Level.Map.SetTile(front, frontTile);
            UpdateLevel();
        }

        private void Surprise(Position front, char frontTile)
        {
            Sound("Info/Map/Chest.mp3");
            SetTile(front, frontTile);
            IncreaseItemCount(_chance.Next(_itemSurprise));
        }

        public void Countdown(object sender, object o)
        {
            if (Level.Danger.IsZero)
            {
                _deadlyTimer.Tick -= Countdown;
                Battle.Entry.RaiseEscape();
                return;
            }

            Level.Danger.Countdown();
        }

        public void Interact()
        {
            Position front = Hero.Front;

            switch (Level.Map.Tile(front))
            {
                case '?':
                    Surprise(front, '.');
                    break;
                case '@':
                    MessageToUser(front);
                    break;
                case '$':
                    ArmoryElement armor = Chest(front, 'E');
                    AddEquipment(armor);
                    break;
                case 'E':
                    MessageToUser("Когда-то... ", front);
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
                case 'S':
                    SaveGame();
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

            Hero.Go(Level.Map, move.Int());
            bool fight = !Level.IsTimeChamber && Hero.IsBattle();

            Position current = Hero.Place;
            switch (Level.Map.Tile(current))
            {
                case ':':
                    Sound("Info/Map/Wound.mp3");
                    Hero.Hp.Drain(1);
                    if (Hero.Hp.IsEmpty)
                    {
                        Battle.Entry.RaiseEscape();
                        return;
                    }
                    break;
                case '_':
                    Sound("Info/Map/Door.mp3");
                    Gates(current, '.', '.');
                    break;
                case 'T':
                    Sound("Info/Map/Teleport.mp3");
                    Hero.SetPlace(Level.Warps[current.ToString()]);
                    break;
                case '!':
                    EnemyAppearing("BossStorm.mp3", Encounter.BOSS);
                    return;
                default:
                    break;
            }

            if (fight)
            {
                EnemyAppearing("EnemyWind.mp3", Encounter.REGULAR);
                Fight();
            }
        }

        private void EnemyAppearing
            (string noise, Encounter encounter)
        {
            Noise($"Info/{noise}.mp3");
            IsFighting = encounter;
        }

        internal void ResetDanger()
        {
            System.Diagnostics.Trace.WriteLine(Level.Danger);
            Hero.ToBattle = _chance.Next(Level.Danger);
            IsFighting = Encounter.PEACE;
        }

        public void FoesBattle()
        {
            Battle.Start();
        }

        public void BossBattle()
        {
            string tile = Hero.Place.ToString();
            EnemyBestiary id = Level.Bosses[tile];

            Boss boss = Battle.BossesEnumeration[id];
            Music(boss.Theme);

            Battle.Start(boss);
        }

        public void Stand()
        {
            Hero.Stand();
        }
        #endregion

        private readonly Random _chance;

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