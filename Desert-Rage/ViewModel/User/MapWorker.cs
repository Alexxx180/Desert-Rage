using System;
using System.ComponentModel;
using System.Windows.Threading;
using DesertRage.Controls.Menu.Game;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Map;
using DesertRage.ViewModel.User.Battle;
using Serilog;

namespace DesertRage.ViewModel.User
{
    public class MapWorker : UserMenu, INotifyPropertyChanged
    {
        internal void SaveGame()
        {
            string profile = Preferences.Name;
            Log.Information("Player profile: " + profile);

            if (profile == string.Empty)
                return;

            Bank.SaveProfileLevel(profile, Level);
            base.SaveGame(profile);
        }

        public MapWorker()
        {
            _collapse = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            _collapse.Tick += Countdown;

            _chance = new Random();

            Menu = new GameMenu(this);
            Location = new LevelMap(this);
            ViewModel = new BattleViewModel(this);

            MessageToUser("'E' для взаимодействия");
        }

        private Location _level;
        public Location Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged();
                ViewModel.SetFoes(value.StageFoes);
                Resume();
            }
        }

        public void SetLevel(Location level)
        {
            Level = level;
        }

        public void UpdateLevel()
        {
            OnPropertyChanged(nameof(Level));
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

        public override void LoadHeroCommands()
        {
            base.LoadHeroCommands();
            _itemSurprise = new Position(0, Items.Count);
        }

        #region Location Members

        #region Chapter Members
        //private void NewCharacter
        //    (string name, bool condition)
        //{
        //    if (condition)
        //        Bank.SaveCharacter(name);
        //}

        public void SetHeroStart()
        {
            Hero.SetPlace(Level.Start);
        }

        private void SetChapter(Location chapter)
        {
            Level.SetChapter(chapter);
            ViewModel.SetFoes(Level.StageFoes);
        }

        private void NextChapter()
        {
            Location next = Bank.LoadLevel(Level.NextChapter);

            if (next is null)
            {
                //NewCharacter("Rock", Hero.Name.Length == 0);
                //NewCharacter("Sam", Hero.SelectedArmor.Equals
                //    (new BattleStats(Sets.SERIOUS.ToByte())));
                ViewModel.Entry.RaiseEscape();
            }
            else
            {
                SetChapter(next);
                Warp(Level.Start);
                UpdateLevel();
                SaveGame();

                Peace();
                Resume();
            }
        }
        #endregion

        #region Level Message Members
        private string LevelText(string place)
        {
            return Level.Messages[place];
        }

        private string LevelText(Position place)
        {
            return LevelText(place);
        }

        private void MessageToUser(string prefix, Position place)
        {
            MessageToUser(prefix + LevelText(place.ToString()));
        }

        private void MessageToUser(Position place)
        {
            string message = LevelText(place.ToString());
            MessageToUser(message);
        }

        private void MessageToUser(string message)
        {
            Message = message;
        }
        #endregion

        #region Map Interaction Members
        private void Gates
            (Position front, char frontTile,
            char gateTile, string audio)
        {
            Sound($"Info/Map/{audio}");

            Level.Map.SetTile(front, frontTile);
            string next = front.ToString();

            Log.Debug("Opening gate with key at: " + next);

            Position gate = Level.Gates[next];

            Log.Debug("Gate at: " + gate);

            Level.Map.SetTile(gate, gateTile);

            UpdateLevel();
        }

        private void Chest(Position front, char frontTile)
        {
            Sound("Info/Map/Chest.mp3");
            SetTile(front, frontTile);

            string info = front.ToString();

            Log.Debug("Opening chest at: " + info);

            MessageToUser(LevelText(info));
            AddEquipment(Level.Equipment[info]);
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

            Log.Debug("Opening surprise. Random: " + _itemSurprise);

            IncreaseItemCount(_chance.Next(_itemSurprise));
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
                    Chest(front, 'E');
                    break;
                case 'E':
                    MessageToUser("Когда-то... ", front);
                    break;
                case 'I':
                    Chest(front, '.');
                    break;
                case 'K':
                    Gates(front, '.', '.', "Door.mp3");
                    break;
                case '>':
                    Gates(front, '<', '.', "Lever.mp3");
                    break;
                case '<':
                    Gates(front, '>', 'H', "Lever.mp3");
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
                    Wound(1);
                    break;
                case '_':
                    Gates(current, '.', '.', "Door.mp3");
                    break;
                case 'T':
                    Warp(Level.Warps[current.ToString()]);
                    break;
                case '!':
                    SetTile(current, '.');
                    EnemyEncounter("BossStorm.mp3", Encounter.BOSS);
                    return;
                default:
                    break;
            }

            if (fight)
            {
                EnemyEncounter("EnemyWind.mp3", Encounter.REGULAR);
                Fight();
            }
        }
        #endregion

        #endregion

        #region Audio Members
        public void Peace()
        {
            Music(Level.MusicPeace);
        }

        public void Fight()
        {
            Music(Level.MusicFight);
        }
        #endregion

        #region Danger Factor Members
        public void BossBattle()
        {
            string tile = Hero.Place.ToString();
            BossBattle(Level.Bosses[tile]);
        }

        private void EnemyEncounter(string noise, Encounter encounter)
        {
            Noise($"Info/{noise}.mp3");
            IsFighting = encounter;
        }

        internal void ResetDanger()
        {
            Hero.ToBattle = _chance.Next(Level.Danger);
            IsFighting = Encounter.PEACE;
        }

        public void Countdown(object sender, object o)
        {
            if (Level.Danger.IsZero)
            {
                _collapse.Tick -= Countdown;
                ViewModel.Entry.RaiseEscape();
                return;
            }

            Level.Danger.Countdown();
        }
        #endregion

        #region IPauseable Members
        public void Resume()
        {
            if (Level.IsTimeChamber)
                _collapse.Start();
        }

        public void Pause()
        {
            if (Level.IsTimeChamber)
                _collapse.Stop();
        }
        #endregion

        private DispatcherTimer _collapse;
        private Position _itemSurprise;
        private readonly Random _chance;
    }
}