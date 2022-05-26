using System.Collections;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Helpers;
using static DesertRage.Writers.Processors;
using DesertRage.ViewModel;
using DesertRage.Model.Locations;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Controls.Scenes.Map;
using DesertRage.ViewModel.Battle;
using DesertRage.Resources.OST.Noises.Actions;
using DesertRage.Helpers.Attach;
using DesertRage.Controls;
using System.Collections.Generic;
using DesertRage.Model.Menu.Things.Logic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DesertRage
{
    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private BattleViewModel _adventure;
        public BattleViewModel Adventure
        {
            get => _adventure;
            set
            {
                _adventure = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            UserProfile user = GetUserData();
            user.SetSoundPlayer(SoundTrack);
            user.LoadHeroCommands();

            Adventure = user.Battle;
            Display.Content = Adventure.Scene;
        }

        internal UserProfile Player { get; set; }

        internal Character Ray = new Character
        {
            Level = 1,
            Place = new Position(18, 34),

            Icon = Paths.Static.Person.Usual,
            Image = Paths.Static.Person.Usual,

            Hp = new Bar(100),
            Ap = new Bar(40),

            Stats = new BattleStats(25, 15, 15, 25),

            Learned = new BitArray(16),

            Gear = new Outfit(0)
        };

        internal Character Sam = new Character
        {
            Level = 1,

            Icon = Paths.Static.Person.Usual,
            Image = Paths.Static.Person.Usual,

            Hp = new Bar(100),
            Ap = new Bar(100),

            Stats = new BattleStats(50),

            Learned = new BitArray(16),

            Gear = new Outfit(0)
        };

        internal Character MainHero { get; set; }

        private void New_game()
        {
            Player.Hero = ReadJson<Character>("Ray/Beginner.json");
            Player.Level = ReadJson<Location>("SecretTemple.json");
            
        }

        private void SaveGame()
        {
            //PlaySound(Paths.OST.Sounds.ControlSave);
            SaveProfile("Ray.json", Player);
        }

        public static UserProfile GetUserData()
        {
            string back = "/Resources/Images/Locations/1-Secret-Temple/Way.svg";

            Dictionary<string, string> tiles = new Dictionary<string, string>
            {
                { ".", back },
                { "H", "/Resources/Images/Locations/1-Secret-Temple/Wall.svg" },
                { "X", "/Resources/Images/Locations/1-Secret-Temple/Artifact.svg" },
                { "!", "/Resources/Images/Locations/1-Secret-Temple/Way.svg" },
                { "S", "/Resources/Images/Locations/Total/SafeArea.svg" },
                { "$", "/Resources/Images/Locations/Total/Chest/Closed.svg" },
                { "E", "/Resources/Images/Locations/Total/Chest/Opened.svg" },
                { "K", "/Resources/Images/Locations/Total/Key.svg" },
                { "#", "/Resources/Images/Locations/Total/Lock.svg" },
                { "@", "/Resources/Images/Locations/Total/Table.svg" }
            };

            string[] map = new string[] {
                "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH",
                "H............H................H..........H.....H...........H",
                "H..H.H..H.H...HHHHHH.HHH....H.H..........H.....H.....HHH...H",
                "H...H....H...H..........H.HHH.H.....H....H.HH..H....H......H",
                "HHH.HHHH.H..H.H.HHHHHHHH..H.H.H....HXH...H..HH.H..HH..HHH..H",
                "H...H....HH..H..........H.H.H.HH........HHH.H..H.HH.....HH.H",
                "HH.HH.HHHH.HH.HHHH.HHH..H......HH......HHH..H.HH.H..HHHH.H.H",
                "H...H.........H...H..$H..HH.H...HHHH#HHH....H..H.H.HH..H.H.H",
                "H.HHHHHHHHHHH.H.H...HHH.H..H...H...H.......HHH.H.H.H...H.H.H",
                "H.H.........H.H.HHHH$....HH...H....HHHH.....H..H.H.H!H.H.H.H",
                "H.H.HHHHHHH.H.H.H...HH..H..H.H..H.....@HHHHHH.HH.H..HH.H.H.H",
                "H.H.H.....H.H...H....H.H..H...H..HHH...HHH.....H.HH.....HH.H",
                "H.H.H.HHH.H.HHHHH.H...H...H.H.H.....H........H.H..HHHHHHH..H",
                "H.H.H.H...H.......H...H..H.....HHHH..HHHHHH..H.H...........H",
                "H.H.H.H.H.H.......H..H...H..H......H.......HHHHHHHHHHHHH...H",
                "H.H.H.H.H.H...HHHHH..H.HHHHH.HHHH..HHHHHHH..H......H.......H",
                "H.H.H.H.HHHHH........H...H.......H.......H........H.H......H",
                "H.....H......HH...H...HH.H..HSH.H.HHHHH..HHHHH.HH...H......H",
                "H.HH#H..HH.HH..H.......H..............H......H.....H.......H",
                "HHH..HH..H......H...H..HHHHHH#HH.HHH..H..HHH.HHHH..H.......H",
                "H.....HHH..H....H......H.......H...H...HH..H....H..HHHHHH..H",
                "H.H....HHHHK....H.H..HH........HHH.H.H....H.HHH.........H..H",
                "H.H.......HH....H......H.HH......H.H.....HH...H.........H..H",
                "H.H.HHH....H....H...H.H.H..H.....HHHHHHH.H..H..HHHH.....H..H",
                "H.H.H.....H$..HHH.....H..........H.....H....H.....H.....H..H",
                "HHH.HHHH..HH..H@H......H..H......H..H.HHHHHHH.H.........H..H",
                "H...H......HHHH.HHHHHH..H..H...HHH.HH........HHHH..........H",
                "H.HHH......H.....H.$H....H..HHHH....HH..H.....H..HHH.H..H..H",
                "H...H..HHH....H..H.H...H..H..H...HHHHHHHHHH.H..H.....H..HH.H",
                "H.H.H....H..H....H..HH..H.H..H...H...HH....H.H..HHHHHHH.H..H",
                "H.H.H....HHHH....HH.H..H..H.HH...H.H.H...H.H..H...........HH",
                "HHH.HHH..H..........H.HHHHH..H...H.H.H.HHH.HH..HHHH..HH.H..H",
                "H...H....HH..H..H...H.H...H.HH.....H....H...HH....H..H..HH.H",
                "H.K.H.............@.H.H.H.H..H.....H....H.K.H...H....H..H..H",
                "H...H...............H...H....H.............................H",
                "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH"
            };

            Location location = new Location
            {
                TileCodes = tiles,
                BackCover = back,
                Map = map
            };

            Character hero = new Character
            {
                Hp = new Bar(20, 100),
                Ap = new Bar(50),
                Stats = new BattleStats(25),
                Icon = "/Resources/Images/Menu/Topics/Status.svg",
                Image = "/Resources/Images/Fight/Character/Ray/Idle.svg",
                Action = "/Resources/Images/Fight/Character/Ray/Action.svg",
                Step = new Position[4]
                {
                    new Position(0, -1),
                    new Position(-1, 0),
                    new Position(0, 1),
                    new Position(1, 0)

                },
                StandImage = new string[4]
                {
                    "/Resources/Images/Locations/Total/Person/Static/Up.svg",
                    "/Resources/Images/Locations/Total/Person/Static/Left.svg",
                    "/Resources/Images/Locations/Total/Person/Static/Down.svg",
                    "/Resources/Images/Locations/Total/Person/Static/Right.svg"
                },
                MapImage = "/Resources/Images/Locations/Total/Person/Static/Down.svg",
                GoingImage = new string[4][]
                {
                    new string[] {
                        "/Resources/Images/Locations/Total/Person/Walk/Up/1.svg",
                        "/Resources/Images/Locations/Total/Person/Walk/Up/2.svg"
                    },
                    new string[] {
                        "/Resources/Images/Locations/Total/Person/Static/Left.svg",
                        "/Resources/Images/Locations/Total/Person/Walk/Left/1.svg",
                        "/Resources/Images/Locations/Total/Person/Static/Left.svg",
                        "/Resources/Images/Locations/Total/Person/Walk/Left/2.svg"
                    },
                    new string[] {
                        "/Resources/Images/Locations/Total/Person/Walk/Down/1.svg",
                        "/Resources/Images/Locations/Total/Person/Walk/Down/2.svg"
                    },
                    new string[] {
                        "/Resources/Images/Locations/Total/Person/Static/Right.svg",
                        "/Resources/Images/Locations/Total/Person/Walk/Right/1.svg",
                        "/Resources/Images/Locations/Total/Person/Static/Right.svg",
                        "/Resources/Images/Locations/Total/Person/Walk/Right/2.svg"
                    }
                },
                WalkThrough = new HashSet<string>
                    { ".", ",", ":", "_" },
                Place = new Position(1, 3)
            };

            hero.Skills = new List<SkillsID>
            {
                SkillsID.Cure,
                SkillsID.Cure2,

                SkillsID.Torch,
                SkillsID.Whip,
                SkillsID.Sling,

                SkillsID.Combo,
                SkillsID.Whirl,
                SkillsID.Quake
            };

            return new UserProfile
            {
                Level = location,
                Hero = hero
            };
        }

        #region RoutedEvent Members
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Close();
                    break;
                default:
                    TransferKeyDown(sender, e);
                    break;
            };
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            TransferKeyUp(sender, e);
        }

        private void TransferKeyDown(object sender, KeyEventArgs e)
        {
            if (Display.Content is IControllable keyPad)
            {
                keyPad.KeyHandle(sender, e);
            }
        }

        private void TransferKeyUp(object sender, KeyEventArgs e)
        {
            if (Display.Content is IControllable keyPad)
            {
                keyPad.KeyRelease(sender, e);
            }
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