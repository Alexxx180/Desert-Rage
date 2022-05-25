using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using DesertRage.Controls.Menu.Game;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Locations;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.ViewModel;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats;

namespace DesertRage.Controls.Scenes.Map
{
    /// <summary>
    /// Location map
    /// </summary>
    public partial class LevelMap : UserControl, INotifyPropertyChanged, IControllable
    {
        private UserProfile _userData;
        public UserProfile UserData
        {
            get => _userData;
            set
            {
                _userData = value;
                OnPropertyChanged();
            }
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
                Hero = hero,
                Menu = new GameMenu()
            };
        }

        public LevelMap()
        {
            InitializeComponent();
            UserData = GetUserData();
            UserData.Menu.SetLocation(this);
        }

        //public string[] Map
        //{
        //    get => _map;
        //    set
        //    {
        //        _map = value;
        //        OnPropertyChanged();
        //    }
        //}



        ////[EN] Complete tasks
        ////[RU] Завершение задач.
        //private void CollectKey(Image Key, Image Lock)
        //{
        //    AnyHideX(Key, Lock);
        //    AnyShow(TaskCompletedImg);
        //    PlaySound(Paths.OST.Sounds.DoorOpened);
        //    Sets.LockIndex--;
        //    Sets.EnemyRate++;
        //    MainHero.MenuTask++;
        //}

        //private void PullTheLever(Image Lever, params Image[] Imgs)
        //{
        //    AnyShowX(Imgs);
        //    Lever.Source = Bmper(Paths.Static.Map.Models.LeverOn);
        //    PlaySound(Paths.OST.Sounds.DoorOpened);
        //}

        ////[EN] Objects interaction
        ////[RU] Взаимодействие с объектами.
        //private void ChestOpen(Image Chest, in string Message, in string ChestOpened, in byte Class, in byte Quality)
        //{
        //    AnyShow(ChestMessage1);
        //    ChestMessage1.Source = Bmper(Message);
        //    Chest.Source = Bmper(ChestOpened);
        //    switch (Class)
        //    {
        //        case 0: GetBag.Hands = MainHero.Weapon.Power == 0; GetBag.Weapons[Quality] = true; break;
        //        case 1: GetBag.Jacket = MainHero.Armor.Power == 0; GetBag.Armors[Quality] = true; break;
        //        case 2: GetBag.Leggings = MainHero.Legs.Power == 0; GetBag.Panties[Quality] = true; break;
        //        case 3: GetBag.Foots = MainHero.Boots.Power == 0; GetBag.ArmBoots[Quality] = true; break;
        //        default: break;
        //    }
        //    PlaySound(Paths.OST.Sounds.ChestOpened);
        //    AnyGrid(ChestMessage1, Bits(Bits(Chest.GetValue(Grid.RowProperty)) - 5), Bits(Bits(Chest.GetValue(Grid.ColumnProperty)) - 3));
        //}

        //private void RRoll_L_T48(object sender, EventArgs e)
        //{
        //    if (RockRoll()) TimerOff(ref RRoll);
        //}

        //private void TRout_F_T59(object sender, EventArgs e)
        //{
        //    if (TimeChamber())
        //        TimerOff(ref TRout);
        //}

        //#region DetermineBattle
        ////[EN] Determine a battle
        ////[RU] Определение битвы.
        //private void LetsBattle()
        //{
        //    Sets.StepsToBattle--;
        //    string[] dng = { Paths.OST.Noises.Danger, Paths.OST.Noises.Danger2, Paths.OST.Noises.Danger3 };
        //    PlayNoise(dng[CurrentLocation]);
        //    AnyShow(Med2);
        //}

        //private void WhatsGoingOn(in byte SecretBattlesIndex)
        //{
        //    MapScheme[MainHero.Y, MainHero.X] = 0;
        //    Sets.SpecialBattle = SecretBattlesIndex;
        //    TargetImage = BossSlot1;
        //}
        //#endregion

        ////[EN] Creating a location instances.
        ////[RU] Создание локаций.
        //#region OldMap Members

        //private void SeeMap()
        //{
        //    byte locs = Bits(TSql.CheckTask());
        //    ChangeBackground(LocationDecode(locs), locs);
        //}

        //private bool TimeChamber()
        //{
        //    if (FleeTime[0] <= 0 && FleeTime[1] <= 0)
        //    {
        //        AnyHideX(TimerFlees, TimerFlees1);
        //        WonOrDied();
        //        AnyShow(GameOver);
        //        return true;
        //    }

        //    if (FleeTime[1] <= 0)
        //    {
        //        FleeTime[0]--;
        //        FleeTime[1] = 60;
        //    }

        //    FleeTime[1]--;
        //    string content = string.Format("{0:0}:{1:00}", FleeTime[0], FleeTime[1]);
        //    TimerFlees.Content = content;
        //    int time = (FleeTime[0] * 60) + FleeTime[1];
        //    Color foreColor = LinearStrategy(time, 150);
        //    TimerFlees.Foreground = new SolidColorBrush(Flashing(time, foreColor));
        //    TimerFlees.BorderBrush = new SolidColorBrush(foreColor);
        //    return false;
        //}
        //private void MapCheck(in byte Loc)
        //{
        //    switch (Loc)
        //    {
        //        case 0: Location1_AncientPyramid(); break;
        //        case 1: Location2_WaterTemple(); break;
        //        case 2: Location3_LavaTemple(); break;
        //        default: Location4_BigRun(); break;
        //    }
        //}

        //private void Map1EnableModels()
        //{
        //    switch (Sets.LockIndex)
        //    {
        //        case 0: break;
        //        case 1: AnyShowX(new Image[] { KeyImg3, LockImg3 }); break;
        //        case 2:
        //            AnyShowX(new Image[] { KeyImg2,
        //            LockImg2, KeyImg3, LockImg3 }); break;
        //        default:
        //            AnyShowX(new Image[] { KeyImg1, KeyImg2, KeyImg3,
        //            LockImg1, LockImg2, LockImg3 }); break;
        //    }
        //}

        //private void Location1_AncientPyramid()
        //{
        //    AnyShowX(ChestImg1, ChestImg2, ChestImg3,
        //        ChestImg4, Table1, Table2, Table3);
        //    Sets.EnemyRate += MainHero.MenuTask;
        //    switch (MainHero.MenuTask)
        //    {
        //        case 0:
        //            AnyShowX(KeyImg1, KeyImg2, KeyImg3,
        //                LockImg1, LockImg2, LockImg3);
        //            break;
        //        case 1:
        //            AnyShowX(KeyImg3, LockImg3, KeyImg2, LockImg2);
        //            ChangeMap(0, 101, 131);
        //            break;
        //        case 2:
        //            AnyShowX(KeyImg3, LockImg3);
        //            ChangeMap(0, 101, 131, 102, 132);
        //            break;
        //        case 3:
        //            ChangeMap(0, 101, 131, 102, 132, 103, 133);
        //            break;
        //    }
        //    AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1,
        //        Table2, Table3, Threasure1, SaveProgress },
        //        new int[] { 27, 24, 7, 9, 33, 25, 10, 4, 17 },
        //        new int[] { 19, 11, 21, 20, 18, 15, 38, 36, 29 });
        //    PlayerSetLocation(MainHero.MenuTask <= 0 ? 34 : 17,
        //        MainHero.MenuTask <= 0 ? 18 : 29);
        //    Sets.LockIndex = Bits(3 - MainHero.MenuTask);
        //    if (GetBag.Armors[3])
        //        ChangeMapToVoid(191);
        //    TheEnd.Source = Ura(Paths.CutScenes.Victory);
        //}

        //private void Location2_WaterTemple()
        //{
        //    byte[] EnemyRates = { 2, 3, 4, 5, 3, 5, 5 };
        //    Sets.EnemyRate = EnemyRates[Ray.MenuTask];
        //    Img1.Source = Bmper(Paths.Static.Map.Location2);
        //    AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4,
        //        Table1, Table2, Table3, Threasure1, SaveProgress },
        //        new int[] { 9, 21, 10, 8, 29, 22, 22, 16, 28 },
        //        new int[] { 8, 10, 24, 35, 49, 23, 2, 4, 20 });
        //    AnyShowX(Img1, ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1,
        //        Table2, Table3, Threasure1, SaveProgress, SecretChestImg1,
        //        SecretChestImg2, JailImg2, JailImg3, Boulder1);
        //    ChestsCheck(GetBag.Panties[3], 213, SecretChestImg1);
        //    ChestsCheck(MainHero.MiniTask, 232, SecretChestImg2);
        //    bool task1 = MainHero.MenuTask > 4;
        //    bool task2 = MainHero.MenuTask > 5;
        //    if (!task2)
        //        AnyShowX(JailImg1, JailImg5, JailImg6, JailImg7);
        //    else if (!task1)
        //        AnyShow(JailImg1);
        //    if (task1)
        //        ChangeMap(0, task2 ? new byte[] {
        //            134, 136, 137, 138, 104, 106, 107, 108
        //            } : new byte[] { 134, 104 });
        //    PlayerSetLocation(task1 ? 28 : 34, task1 ? 20 : 51);
        //    TheEnd.Source = Ura(Paths.CutScenes.WasteTime);
        //}

        //private void Threasures()
        //{
        //    string[] ambushed = {
        //        Paths.CutScenes.Ambushed, Paths.CutScenes.BattleStations,
        //        Paths.CutScenes.NotAgain
        //    };
        //    string[] battlegrounds = {
        //        Paths.Static.Battle.Battle1, Paths.Static.Battle.Battle2,
        //        Paths.Static.Battle.Battle3, Paths.Static.Battle.Battle3
        //    };
        //    string[] threasures = {
        //        Paths.Static.Map.Models.Artifact1, Paths.Static.Map.Models.Artifact2,
        //        Paths.Static.Map.Models.Artifact3, Paths.Static.Map.Models.Artifact3
        //    };
        //    ChestsCheck(GetBag.Weapons[CurrentLocation], 203, ChestImg3);
        //    ChestsCheck(GetBag.Armors[CurrentLocation], 201, ChestImg1);
        //    ChestsCheck(GetBag.Panties[CurrentLocation], 204, ChestImg4);
        //    ChestsCheck(GetBag.ArmBoots[CurrentLocation], 202, ChestImg2);
        //    FastImgChange(BmpersToX(battlegrounds[CurrentLocation],
        //        threasures[CurrentLocation]), Img3, Threasure1);
        //    AnyShowX(Threasure1, SaveProgress, ChestImg1, ChestImg2,
        //        ChestImg3, ChestImg4, Table1, Table2, Table3);
        //    Med2.Source = Ura(ambushed[CurrentLocation]);
        //}

        //private void ChestsCheck(in bool CheckValue, in byte OnMap, Image Chest)
        //{
        //    string[] chestvercl = new string[] { Paths.Static.Map.Models.ChestClosed1,
        //        Paths.Static.Map.Models.ChestClosed2, Paths.Static.Map.Models.ChestClosed3 };
        //    string[] chestverop = new string[] { Paths.Static.Map.Models.ChestOpened1,
        //        Paths.Static.Map.Models.ChestOpened2, Paths.Static.Map.Models.ChestOpened3 };
        //    Chest.Source = Bmper(CheckValue ? chestverop[CurrentLocation]
        //        : chestvercl[CurrentLocation]);
        //    if (CheckValue)
        //        ChangeMapToWall(OnMap);
        //}

        //private void SurpriseCheck(in bool CheckValue, in byte OnMap, Image Chest)
        //{
        //    if (CheckValue)
        //    {
        //        AnyHide(Chest);
        //        ChangeMapToVoid(OnMap);
        //    }
        //}

        //private void ContinueCheckPoints()
        //{
        //    AnyHide(MainMenu);
        //    HeroStatus();
        //}

        //private bool RockRoll()
        //{
        //    byte[] MapModel = CheckModelCoord(7);
        //    if ((MapModel[0] == MainHero.Y) && (MapModel[1] == MainHero.X))
        //        Pain(50);
        //    ChangeMapToVoid(7);
        //    if (MapScheme[MapModel[0] + 1, MapModel[1]] != 1)
        //    {
        //        MapModel[0]++;
        //        MapScheme[MapModel[0], MapModel[1]] = 7;
        //        AnyGrid(Boulder1, MapModel[0], MapModel[1]);
        //        Boulder1.RenderTransform = new RotateTransform(45 * Adoptation.Width
        //            * MapModel[0], 16 * Adoptation.Width, 15 * Adoptation.Height);
        //    }
        //    else
        //    {
        //        AnyHide(Boulder1);
        //        return true;
        //    }
        //    return false;
        //}
        //#endregion

        //private void GetSecretReward()
        //{
        //    Exp += 250;
        //    Mat += 250;
        //    MainHero.MiniTask = true;
        //    ShowAfterBattleMenu();
        //}
        
        public void KeyHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                case Key.NumPad8:
                    UserData.Go(Direction.UP);
                    break;
                case Key.A:
                case Key.Left:
                case Key.NumPad4:
                    UserData.Go(Direction.LEFT);
                    break;
                case Key.S:
                case Key.Down:
                case Key.NumPad2:
                    UserData.Go(Direction.DOWN);
                    break;
                case Key.D:
                case Key.Right:
                case Key.NumPad6:
                    UserData.Go(Direction.RIGHT);
                    break;
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    Label container = Parent as Label;
                    container.Content = UserData.Menu;
                    break;
                default:
                    break;
            }
        }

        public void KeyRelease(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.A:
                case Key.S:
                case Key.D:
                case Key.Up:
                case Key.Left:
                case Key.Down:
                case Key.Right:
                case Key.NumPad2:
                case Key.NumPad4:
                case Key.NumPad6:
                case Key.NumPad8:
                    UserData.Stand();
                    break;
                default:
                    break;
            }
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
