using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesertRage.Controls.Scenes.Map.Avatar
{
    /// <summary>
    /// Логика взаимодействия для Ray.xaml
    /// </summary>
    public partial class Ray : UserControl
    {
        public Ray()
        {
            InitializeComponent();
        }

        ////[EN] Movement and map interaction
        ////[RU] Передвижение и взаимодействие с картой.
        //private byte CheckGuy()
        //{
        //    string compare = Img2.Source.ToString();
        //    string[] Direction = {
        //        Paths.Static.Map.Models.Guy.StaticRight,
        //        Paths.Static.Map.Models.Guy.GoRight,

        //        Paths.Static.Map.Models.Guy.StaticDown,
        //        Paths.Static.Map.Models.Guy.GoDown1,
        //        Paths.Static.Map.Models.Guy.GoDown2,

        //        Paths.Static.Map.Models.Guy.StaticLeft,
        //        Paths.Static.Map.Models.Guy.GoLeft,

        //        Paths.Static.Map.Models.Guy.StaticUp,
        //        Paths.Static.Map.Models.Guy.GoUp1,
        //        Paths.Static.Map.Models.Guy.GoUp2
        //    };
        //    sbyte[,] Dir1 = {
        //        { 0, 0,  1, 1, 1,  0, 0,  -1, -1, -1 },
        //        { 1, 1,  0, 0, 0,  -1, -1,  0, 0, 0 }
        //    };
        //    for (byte i = 0; i < Direction.Length; i++)
        //        if (compare.Contains(Direction[i]))
        //            return MapScheme[MainHero.Y + Dir1[0, i], MainHero.X + Dir1[1, i]];
        //    return 0;
        //}

        //private void Movement(in BitmapImage bmp)
        //{
        //    Img2.Source = bmp;
        //    GroundCheck(MapScheme[MainHero.Y, MainHero.X]);

        //    if (MainHero.PlayerStatus == 1)
        //        Pain(1);

        //    TablesSetInfo();
        //    if (CurrentLocation >= 3)
        //        return;
        //    string[] dangers = {
        //        Paths.OST.Music.AncientPyramidDanger,
        //        Paths.OST.Music.WaterTempleDanger,
        //        Paths.OST.Music.LavaTempleDanger
        //    };

        //    if (CurrentLocation < 3 && Sets.StepsToBattle == rnd / 2)
        //        PlayMusic(dangers[CurrentLocation]);

        //    if (Sets.StepsToBattle >= rnd)
        //    {
        //        AnyHideX(PainImg, Img2, HPhelper);
        //        Sound1.Stop();
        //        PlayNoise(Paths.OST.Noises.Danger);
        //        LetsBattle();
        //    }
        //    Sets.StepsToBattle++;
        //}

        //private void Pain(int damage)
        //{
        //    IhurtMyLegKit(damage);
        //    string[] pains = {
        //        Paths.Static.Map.Messages.Pain1,
        //        Paths.Static.Map.Messages.Pain2,
        //        Paths.Static.Map.Messages.Pain3,
        //        Paths.Static.Map.Messages.Pain2
        //    };
        //    PainImg.Source = Bmper(pains[PainIndex]);
        //    PainIndex++;
        //    if (PainIndex >= 4)
        //        PainIndex = 0;
        //}

        //private void IhurtMyLegKit(int damage)
        //{
        //    GetHP = Shrt(Math.Max(GetHP - damage, 0));
        //    AnyGrid(HPhelper, Bits(Img2.GetValue(Grid.RowProperty)) - 1,
        //        Bits(Img2.GetValue(Grid.ColumnProperty)) - 1);
        //    AnyShowX(HPhelper, PainImg);
        //}

        //private void TablesSetInfo()
        //{
        //    if (Sets.TableEN || TableMessage1.IsEnabled)
        //        AnyHide(TableMessage1);
        //    Sets.TableEN = !Sets.TableEN && !TableMessage1.IsEnabled;
        //    byte Interaction = CheckGuy();
        //    byte[] Conditions = { 171, 172, 173, 174, 175, 176, 177, 178, 179 };
        //    BitmapImage[] images = BmpersToX(Paths.Static.Map.Messages.Tb1_Msg1,
        //        Paths.Static.Map.Messages.Tb2_Msg1, Paths.Static.Map.Messages.Tb3_Msg1,
        //        Paths.Static.Map.Messages.Tb1_Msg2, Paths.Static.Map.Messages.Tb2_Msg2,
        //        Paths.Static.Map.Messages.Tb3_Msg2, Paths.Static.Map.Messages.Tb1_Msg3,
        //        Paths.Static.Map.Messages.Tb2_Msg3, Paths.Static.Map.Messages.Tb3_Msg3);
        //    Image[] Mess = { Table1, Table2, Table3, Table1,
        //        Table2, Table3, Table1, Table2, Table3 };
        //    for (byte i = 0; i < Conditions.Length; i++)
        //        if (Interaction == Conditions[i])
        //            SetTablesMessage(images[i], CheckRow(Mess[i], 8), CheckColumn(Mess[i], 5));
        //}

        //private void SetTablesMessage(BitmapImage image, int X, int Y)
        //{
        //    TableMessage1.Source = image;
        //    if (!Sets.TableEN) Sets.TableEN = true;
        //    AnyGrid(TableMessage1, X, Y);
        //    AnyShow(TableMessage1);
        //}

        //private void StateGuy()
        //{
        //    string image = Img2.Source.ToString();
        //    if (image.Contains(Paths.Static.Map.Models.Guy.GoUp1)
        //        || image.Contains(Paths.Static.Map.Models.Guy.GoUp2))
        //        Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticUp);
        //    else if (image.Contains(Paths.Static.Map.Models.Guy.GoLeft))
        //        Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticLeft);
        //    else if (image.Contains(Paths.Static.Map.Models.Guy.GoRight))
        //        Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticRight);
        //    else if (image.Contains(Paths.Static.Map.Models.Guy.GoDown1)
        //        || image.Contains(Paths.Static.Map.Models.Guy.GoDown2))
        //        Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticDown);
        //}



        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    StateGuy();
        //}

        //#region Controllers Members
        ////[EN] Check what is under person foot.
        ////[RU] Проверить на что герой наступил.
        //private void GroundCheck(in byte Interaction)
        //{
        //    switch (Interaction)
        //    {
        //        case 0: break;
        //        case 6: Pain(1); break;
        //        case 8: Pain(10); break;
        //        case 9: Pain(25); break;
        //        case 104:
        //            ChangeMap(0, 104, 134);
        //            AnyHide(JailImg1);
        //            Sets.EnemyRate = 5;
        //            MainHero.MenuTask++;
        //            break;
        //        case 105:
        //            ChangeMap(0, 105, 135);
        //            AnyHide(JailImg2);
        //            if (CurrentLocation == 1)
        //                AnyHide(JailImg3);
        //            TimerOn(ref RRoll);
        //            break;
        //        case 106:
        //            ChangeMap(0, 106, 136);
        //            AnyHide(JailImg5);
        //            if (CurrentLocation == 1)
        //                MainHero.MenuTask++;
        //            break;
        //        case 107: ChangeMap(0, 107, 137); AnyHide(JailImg6); break;
        //        case 108: ChangeMap(0, 108, 138); AnyHide(JailImg7); break;
        //        case 150: SavePlayer(); break;
        //        case 151: GetHP = GetMHP; PlayNoise(Paths.OST.Noises.Cure2); break;
        //        case 152: GetAP = GetMAP; PlayNoise(Paths.OST.Noises.ApUp); break;
        //        case 170:
        //            if (TRout.IsEnabled)
        //                TimerOff(ref TRout);
        //            FleeTime = new byte[] { 2, 30 };
        //            TimerFlees.Content = "2:30";
        //            AnyHideX(Img2, TimerFlees, Img1);
        //            MainHero.MenuTask++;
        //            AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Ending),
        //                new TimeSpan(0, 0, 0, 0, 0));
        //            AnyShow(Skip1);
        //            PlayMusic(Paths.OST.Music.PutTheEnd);
        //            Img1.Source = Bmper(Paths.Static.Map.Normal);
        //            break;
        //        case 191: WhatsGoingOn(200); LetsBattle(); break;
        //        case 192: ChangeMapToVoid(192); PlayerSetLocation(1, 57); break;
        //        default: break;
        //    }
        //}

        ////[EN] Movement (W,A,S,D)/target select (W,A,S,D); actions on map (E); open menu (LCtrl).
        ////[RU] Передвижение (W,A,S,D)/выбор цели (W,A,S,D); действия при нахождении на локации (E); открыть меню (LCtrl).
        //private void Window_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Escape)
        //        Form1.Close();
        //    if (e.Key == Key.P)
        //    {
        //        if (Pause.IsEnabled)
        //            Resume();
        //        else
        //            PauseGame();
        //    }
        //    if (Pause.IsEnabled)
        //        return;
        //    AnyHideX(ChestMessage1, TaskCompletedImg, PainImg, HPhelper);
        //    if (Img2.IsEnabled)
        //    {
        //        string guy = Img2.Source.ToString();
        //        if (e.Key == Key.W || e.Key == Key.Up)
        //        {
        //            if (IsWayNext(MapScheme[MainHero.Y - 1, MainHero.X]))
        //                PlayerSetLocation(MainHero.Y - 1, MainHero.X);
        //            Movement(guy.Contains(Paths.Static.Map.Models.Guy.GoUp1)
        //                ? Bmper(Paths.Static.Map.Models.Guy.GoUp2)
        //                : Bmper(Paths.Static.Map.Models.Guy.GoUp1));
        //        }
        //        if (e.Key == Key.A || e.Key == Key.Left)
        //        {
        //            if (IsWayNext(MapScheme[MainHero.Y, MainHero.X - 1]))
        //                PlayerSetLocation(MainHero.Y, MainHero.X - 1);
        //            Movement(guy.Contains(Paths.Static.Map.Models.Guy.StaticLeft)
        //                ? Bmper(Paths.Static.Map.Models.Guy.GoLeft)
        //                : Bmper(Paths.Static.Map.Models.Guy.StaticLeft));
        //        }
        //        if (e.Key == Key.S || e.Key == Key.Down)
        //        {
        //            if (IsWayNext(MapScheme[MainHero.Y + 1, MainHero.X]))
        //                PlayerSetLocation(MainHero.Y + 1, MainHero.X);
        //            Movement(guy.Contains(Paths.Static.Map.Models.Guy.GoDown1)
        //                ? Bmper(Paths.Static.Map.Models.Guy.GoDown2)
        //                : Bmper(Paths.Static.Map.Models.Guy.GoDown1));
        //        }
        //        if (e.Key == Key.D || e.Key == Key.Right)
        //        {
        //            if (IsWayNext(MapScheme[MainHero.Y, MainHero.X + 1]))
        //                PlayerSetLocation(MainHero.Y, MainHero.X + 1);
        //            Movement(guy.Contains(Paths.Static.Map.Models.Guy.StaticRight)
        //                ? Bmper(Paths.Static.Map.Models.Guy.GoRight)
        //                : Bmper(Paths.Static.Map.Models.Guy.StaticRight));
        //        }

        //        if (e.Key == Key.E)
        //        {
        //            string[] ChestOp = { Paths.Static.Map.Models.ChestOpened1,
        //                Paths.Static.Map.Models.ChestOpened2,
        //                Paths.Static.Map.Models.ChestOpened3 };
        //            string[,] EquipmentAll = new string[,] { {
        //                    Paths.Static.Map.Messages.Knucleduster,
        //                    Paths.Static.Map.Messages.LeatherArmor,
        //                    Paths.Static.Map.Messages.FeatherWears,
        //                    Paths.Static.Map.Messages.BandageBoots
        //                }, { Paths.Static.Map.Messages.AncientKnife,
        //                    Paths.Static.Map.Messages.AncientArmor,
        //                    Paths.Static.Map.Messages.AncientPants,
        //                    Paths.Static.Map.Messages.StrongBoots }, {
        //                    Paths.Static.Map.Messages.LegendSword,
        //                    Paths.Static.Map.Messages.LegendArmor,
        //                    Paths.Static.Map.Messages.LegendPants,
        //                    Paths.Static.Map.Messages.LegendBoots
        //                }
        //            };
        //            int[] LocItem = new int[] {
        //                guy.Contains(Paths.Static.Map.Models.Guy.StaticDown) ?
        //                MainHero.Y + 1 :
        //                (guy.Contains(Paths.Static.Map.Models.Guy.StaticUp) ?
        //                MainHero.Y - 1 : MainHero.Y),
        //                guy.Contains(Paths.Static.Map.Models.Guy.StaticRight) ?
        //                MainHero.X + 1 :
        //                (guy.Contains(Paths.Static.Map.Models.Guy.StaticLeft) ?
        //                MainHero.X - 1 : MainHero.X)
        //            };
        //            byte Interaction = MapScheme[LocItem[0], LocItem[1]];
        //            switch (Interaction)
        //            {
        //                case 101:
        //                    AnyGrid(TaskCompletedImg, CheckRow(KeyImg1, 5),
        //                        CheckColumn(KeyImg1, 3));
        //                    CollectKey(KeyImg1, LockImg1);
        //                    ChangeMap(0, 101, 131);
        //                    break;
        //                case 102:
        //                    AnyGrid(TaskCompletedImg, CheckRow(KeyImg2, 5),
        //                        CheckColumn(KeyImg2, 3));
        //                    CollectKey(KeyImg2, LockImg2);
        //                    ChangeMap(0, 102, 132);
        //                    break;
        //                case 103:
        //                    AnyGrid(TaskCompletedImg, CheckRow(KeyImg3, 5),
        //                        CheckColumn(KeyImg3, 3));
        //                    CollectKey(KeyImg3, LockImg3);
        //                    ChangeMap(0, 103, 133);
        //                    break;
        //                case 111:
        //                    AnyGrid(TaskCompletedImg, CheckRow(KeyImg3, 5), 39);
        //                    PullTheLever(Lever1, Bridge1, Bridge2, Bridge3, Bridge4);
        //                    ChangeMapToWall(111);
        //                    ChangeMapToVoid(138);
        //                    MainHero.MenuTask = 8;
        //                    break;
        //                case 109:
        //                    PullTheLever(Lever2, Bridge5, Bridge6);
        //                    ChangeMapToWall(109);
        //                    ChangeMapToVoid(139);
        //                    break;
        //                case 110:
        //                    PullTheLever(Lever3, Bridge7, Bridge8);
        //                    ChangeMapToWall(110);
        //                    ChangeMapToVoid(140); break;
        //                case 161:
        //                    SomeRudeAppears(1, Paths.OST.Noises.Horror);
        //                    AnyShow(PharaohAppears);
        //                    SimpleCutScene(PharaohAppears, 0.01, 250);
        //                    break;
        //                case 162:
        //                    SomeRudeAppears(2, Paths.OST.Noises.EgoRage);
        //                    AnyShowX(Ancient, Warrior);
        //                    ComplexCutScene(Ancient, 0.25, 250);
        //                    break;
        //                case 163:
        //                    SomeRudeAppears(3, Paths.OST.Noises.EgoRage);
        //                    AnyShow(FinalAppears);
        //                    SimpleCutScene(FinalAppears, 0.05, 250);
        //                    break;
        //                case 201:
        //                case 208:
        //                    ChestOpen(ChestImg1, EquipmentAll[CurrentLocation, 1],
        //                        ChestOp[CurrentLocation], 1, CurrentLocation);
        //                    break;
        //                case 202:
        //                case 207:
        //                    ChestOpen(ChestImg2, EquipmentAll[CurrentLocation, 3],
        //                        ChestOp[CurrentLocation], 3, CurrentLocation);
        //                    break;
        //                case 203:
        //                case 206:
        //                    ChestOpen(ChestImg3, EquipmentAll[CurrentLocation, 0],
        //                        ChestOp[CurrentLocation], 0, CurrentLocation);
        //                    break;
        //                case 204:
        //                case 205:
        //                    ChestOpen(ChestImg4, EquipmentAll[CurrentLocation, 2],
        //                        ChestOp[CurrentLocation], 2, CurrentLocation);
        //                    break;
        //                case 209:
        //                    ChestOpen(ChestImg1, EquipmentAll[CurrentLocation, 0],
        //                        ChestOp[CurrentLocation], 0, CurrentLocation);
        //                    break;
        //                case 210:
        //                    ChestOpen(ChestImg2, EquipmentAll[CurrentLocation, 1],
        //                        ChestOp[CurrentLocation], 1, CurrentLocation);
        //                    break;
        //                case 211:
        //                    ChestOpen(ChestImg3, EquipmentAll[CurrentLocation, 2],
        //                        ChestOp[CurrentLocation], 2, CurrentLocation);
        //                    break;
        //                case 212:
        //                    ChestOpen(ChestImg4, EquipmentAll[CurrentLocation, 3],
        //                        ChestOp[CurrentLocation], 3, CurrentLocation);
        //                    break;
        //                case 213:
        //                    ChestOpen(SecretChestImg1,
        //                        Paths.Static.Map.Messages.SeriousPants,
        //                        ChestOp[CurrentLocation], 2, 3);
        //                    break;
        //                case 221:
        //                    ChangeMapToVoid(LocItem[0], LocItem[1], SpDmg1,
        //                    SpDmg2, SpDmg3, SpDmg4, SpDmg5);
        //                    Pain(50);
        //                    break;
        //                case 222:
        //                    ChangeMapToVoid(LocItem[0], LocItem[1], SpHrb1, SpHrb2,
        //                        SpHrb3, SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8,
        //                        SpHrb9, SpHrb10, SpHrb11, SpHrb12, SpHrb13, SpHrb14);
        //                    if (GetBag.Herbs.Count < 255)
        //                        GetBag.Herbs.Count++;
        //                    OnPropertyChanged(nameof(GetBag));
        //                    break;
        //                case 223:
        //                    ChangeMapToVoid(LocItem[0], LocItem[1], SpEtr1, SpEtr2,
        //                        SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7, SpEtr8,
        //                        SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14,
        //                        SpEtr15, SpEtr16, SpEtr17, SpEtr18);
        //                    if (GetBag.Ether2.Count < 255)
        //                        GetBag.Ether2.Count++;
        //                    OnPropertyChanged(nameof(GetBag));
        //                    break;
        //                case 224:
        //                    ChangeMapToVoid(LocItem[0], LocItem[1], SpElx1,
        //                        SpElx2, SpElx3, SpElx4, SpElx5, SpElx6);
        //                    if (GetBag.Elixir.Count < 255)
        //                        GetBag.Elixir.Count++;
        //                    OnPropertyChanged(nameof(GetBag));
        //                    break;
        //                case 225:
        //                    ChangeMapToVoid(LocItem[0], LocItem[1], SpSbg1,
        //                        SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6,
        //                        SpSbg7, SpSbg8, SpSbg9, SpSbg10, SpSbg11);
        //                    if (GetBag.SleepBag.Count < 255)
        //                        GetBag.SleepBag.Count++;
        //                    OnPropertyChanged(nameof(GetBag));
        //                    break;
        //                case 226:
        //                    ChangeMapToVoid(LocItem[0], LocItem[1], SpSer);
        //                    GetBag.Weapons[3] = true;
        //                    OnPropertyChanged(nameof(GetBag));
        //                    break;
        //                case 232:
        //                    ChangeMapToWall(232);
        //                    SecretChestImg2.Source = Bmper(ChestOp[CurrentLocation]);
        //                    AnyGrid(TaskCompletedImg, CheckRow(SecretChestImg2, 5),
        //                        CheckColumn(SecretChestImg2, 3));
        //                    AnyShow(TaskCompletedImg);
        //                    GetSecretReward();
        //                    break;
        //                case 233:
        //                    ChangeMapToVoid(LocItem[0], LocItem[1], SpTsk);
        //                    GetSecretReward();
        //                    break;
        //                default: break;
        //            }
        //        }
        //        else if (e.Key == Key.LeftCtrl)
        //        {
        //            PlayNoise(Paths.OST.Noises.BagOpen);
        //            AnyHide(Img2);
        //            AnyShow(GameMenu);
        //        }
        //        else if (e.Key == Key.I)
        //            Bestiary();
        //    }
        //    else
        //        switch (e.Key)
        //        {
        //            case Key.W:
        //            case Key.Up:
        //            case Key.A:
        //            case Key.Left:
        //                if (SelectMenuFight.IsEnabled || SelectMenuSkills.IsEnabled)
        //                    SelectKeyLeft();
        //                break;
        //            case Key.S:
        //            case Key.Down:
        //            case Key.D:
        //            case Key.Right:
        //                if (SelectMenuFight.IsEnabled || SelectMenuSkills.IsEnabled)
        //                    SelectKeyRight();
        //                break;
        //            case Key.LeftCtrl:
        //            case Key.I:
        //                if (GameMenu.IsEnabled)
        //                {
        //                    AnyHide(GameMenu);
        //                    PlayNoise(Paths.OST.Noises.BagClose);
        //                }
        //                else if (BestiaryImg.IsEnabled)
        //                {
        //                    AnyHide(BestiaryImg);
        //                    HideBestiary();
        //                }
        //                if (Img1.IsEnabled && !Med2.IsEnabled)
        //                    AnyShow(Img2);
        //                break;
        //        }
        //}
        //#endregion
    }
}
