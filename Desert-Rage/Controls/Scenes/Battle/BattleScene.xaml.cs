using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace DesertRage.Controls.Scenes
{
    /// <summary>
    /// Логика взаимодействия для BattleScene.xaml
    /// </summary>
    public partial class BattleScene : UserControl, INotifyPropertyChanged
    {
        public static readonly Range SceneArea;

        private System.Uri _battleBackground;
        public System.Uri BattleBackground
        {
            get => _battleBackground;
            set
            {
                _battleBackground = value;
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty
            BattleModelProperty = DependencyProperty.Register(
                nameof(BattleModel), typeof(BattleViewModel),
                typeof(BattleScene));

        public BattleViewModel BattleModel
        {
            get => GetValue(BattleModelProperty) as BattleViewModel;
            set => SetValue(BattleModelProperty, value);
        }

        static BattleScene()
        {
            SceneArea = new Range
            {
                Point1 = new Position(1, 1),
                Point2 = new Position(5, 3)
            };
        }

        public BattleScene(BattleViewModel battle)
        {
            InitializeComponent();
            //
            BattleModel = battle;
        }

        public void SetFoes()
        {

        }

        ////[EN] Initialize random mechanic
        ////[RU] Инициализация механики ведения случайных величин.
        //public static Random Random1 = new Random();
        //public static int rnd = Random1.Next(5, 20);
        //public static int poison = 0;

        //private async void PoisonHurts()
        //{
        //    ushort time = Shrt(2000 / GameSpeed.Value);
        //    while (!(FoesFighting() || Pause.IsEnabled))
        //    {
        //        GetHP--;
        //        await Task.Delay(time);
        //    }
        //}

        //private void PhysicalAttack(Equipment.Weapon weapon)
        //{
        //    string[] person = weapon.Animation;
        //    string[] icon = weapon.IconAnimate;
        //    PlayNoise(weapon.Noise);
        //    ShowAction(person, icon);
        //}

        //private void Skills1(FightSkills skill)
        //{
        //    Foe foe = foes[Sets.SelectedTarget];
        //    int power = foe.Weak.Equals(skill.Name) ? skill.Power * 2 : skill.Power;
        //    int EnemyAura = foe.Speed + foe.Special;
        //    ushort total = Shrt(Math.Max(power - EnemyAura, 0));
        //    FoesKickedOne(Sets.SelectedTarget, total, Shrt(500 / GameSpeed.Value));
        //    FoesRefresh();
        //}

        //DispatcherTimer Targt = new DispatcherTimer();

        //private void PTurn_I_T42(object sender, EventArgs e)
        //{
        //    Time1.Value++;
        //    if (Time1.Value < Time1.Maximum)
        //        return;
        //    TimerOff(ref PTurn);
        //    Time();
        //}

        //private void Targt_D_T28(object sender, EventArgs e)
        //{
        //    UnlimitedActionsTickCheck(Paths.Dynamic.Misc.Target);
        //}

        ////[EN] Initialize way to success the escape and get experience/materials.
        ////[RU] Инициализация состояний получения опыта/материалов и успеха побега.
        //public static int speed = 0;
        //public static ushort Exp = 0;
        //public static ushort Mat = 0;
        //private static byte PainIndex = 0;
        //Dictionary<string, int> RecordFoes = new Dictionary<string, int>();

        //#region EnemiesSet Members
        ////[EN] Battle : Usual.
        ////[RU] Сражение : Обычное.
        //private void RegularBattle()
        //{
        //    Image[] images = { Img6, Img7, Img8 };
        //    string[] themes = { Paths.OST.Music.FoesChase,
        //        Paths.OST.Music.HandleThis, Paths.OST.Music.StampSmth };
        //    PlayMusic(themes[CurrentLocation]);
        //    Sets.StepsToBattle = 0;
        //    byte[] LEncounter = { 5, 10, 15 };
        //    byte[] HEncounter = { 20, 30, 40 };
        //    rnd = Random1.Next(LEncounter[CurrentLocation],
        //        HEncounter[CurrentLocation]);
        //    TargetImage = TrgtImg;

        //    Sets.Rnd1 = Random1.Next(0, 3);
        //    for (byte no = 0; no <= Sets.Rnd1; no++)
        //    {
        //        Sets.Rnd2 = Random1.Next(0, Sets.EnemyRate - 1);
        //        foes[no] = new Foe(FoesOnLocation[Sets.Rnd2]);
        //        foes[no].HP = foes[no].MaxHP;
        //        Mat += foes[no].Materials;
        //        Exp += foes[no].Experience;
        //        images[no].Source = Bmper(foes[no].Image);
        //        AnyShow(images[no]);
        //        CheckFoesTurns(no);
        //        if (SetFoes(FoesOnLocation[Sets.Rnd2]))
        //            continue;
        //        RecordFoes.Add(FoesOnLocation[Sets.Rnd2].Name, 1);
        //    }
        //    EnemiesShow(RecordFoes);
        //    CalculateBattleStatus();
        //    FoesRefresh();
        //}

        //private bool SetFoes(Foe foe)
        //{
        //    byte i = 0;
        //    foreach (KeyValuePair<string, int> entry in RecordFoes)
        //    {
        //        if (entry.Key == foe.Name)
        //        {
        //            RecordFoes[entry.Key]++;
        //            return true;
        //        }
        //        i++;
        //    }
        //    return false;
        //}

        //private void EnemiesTotal(in Dictionary<string, int> foesCounts)
        //{
        //    Label[] labels = { FoesCount1, FoesCount2, FoesCount3 };
        //    byte i = 0;
        //    foreach (KeyValuePair<string, int> entry in foesCounts)
        //    {
        //        if (labels[i].Content.ToString().Contains(entry.Key))
        //        {
        //            string content = entry.Key + ": " + entry.Value;
        //            labels[i].Content = content;
        //        }
        //        i++;
        //    }
        //    FlashLabels(labels);
        //}

        //private void EnemiesShow(in Dictionary<string, int> foesCounts)
        //{
        //    Label[] labels = { FoesCount1, FoesCount2, FoesCount3 };
        //    byte i = 0;
        //    foreach (KeyValuePair<string, int> entry in foesCounts)
        //    {
        //        string content = entry.Key + ": " + entry.Value;
        //        labels[i].Content = content;
        //        AnyShow(labels[i]);
        //        i++;
        //    }
        //}

        //private async void FlashLabels(Label[] labs)
        //{
        //    for (byte i = 0; i < labs.Length; i++)
        //    {
        //        FlashLabel(labs[i], Brushes.Gold);
        //        await Task.Delay(20);
        //    }
        //}

        //private async void FlashLabel(Label lab, Brush brush)
        //{
        //    SolidColorBrush memoryColor = lab.Foreground as SolidColorBrush;
        //    lab.Foreground = brush;
        //    await Task.Delay(20);
        //    lab.Foreground = memoryColor;
        //}
        //#endregion

        //#region TargetSelection Members
        ////[EN] Target select mech
        ////[RU] Механика выбора цели.
        //private void NormalTarget()
        //{
        //    AnyGrid(TargetImage, 1 - Sets.SelectedTarget % 2,
        //        Sets.SelectedTarget);
        //}

        //private void BossTarget()
        //{
        //    AnyGrid(TargetImage, 0, Sets.SelectedTarget);
        //}

        //private void MouseSelect(object sender, MouseButtonEventArgs e)
        //{
        //    if (TargetImage == null || !TargetImage.IsEnabled)
        //        return;
        //    Image image = sender as Image;
        //    Sets.SelectedTarget = Bits(image.Tag);
        //    InfoAboutEnemies();
        //}

        //private void SelectKeyLeft()
        //{
        //    if (Sets.SelectedTarget <= 0)
        //        return;

        //    sbyte optimization = SBits(Math.Max(0, Sets.SelectedTarget - 1));
        //    for (sbyte i = optimization; i >= 0; i--)
        //    {
        //        if (foes[i].HP > DeadFoe.HP)
        //        {
        //            Sets.SelectedTarget = Bits(i);
        //            break;
        //        }
        //    }
        //    InfoAboutEnemies();
        //}

        //private void SelectKeyRight()
        //{
        //    if (Sets.SelectedTarget >= Sets.Rnd1)
        //        return;

        //    byte optimization = Bits(Math.Min(2, Sets.SelectedTarget + 1));
        //    for (byte i = optimization; i <= Sets.Rnd1; i++)
        //        if (foes[i].HP > DeadFoe.HP)
        //        {
        //            Sets.SelectedTarget = i;
        //            break;
        //        }
        //    InfoAboutEnemies();
        //}

        //private byte ReSelect()
        //{
        //    for (byte i = 0; i <= Sets.Rnd1; i++)
        //        if (foes[i].HP > DeadFoe.HP)
        //        {
        //            byte[,] grRowColumn = new byte[,] { { 1, 0, 1 }, { 0, 1, 2 } };
        //            AnyGrid(TargetImage, grRowColumn[0, i], grRowColumn[1, i]);
        //            return i;
        //        }
        //    return 0;
        //}

        //public void SelectTarget()
        //{
        //    AnyShowX(TargetImage, EnemyStatus);
        //    InfoAboutEnemies();
        //    TimerOn(ref Targt);
        //}
        //#endregion

        //#region EnemiesInformation
        ////[EN] Info about enemies
        ////[RU] Информация по врагам.
        //private void InfoAboutEnemies()
        //{
        //    ReCheck();
        //    if (Sets.SpecialBattle == 0)
        //        NormalTarget();
        //    else
        //        BossTarget();
        //}
        //private void ReCheck()
        //{
        //    Image[] images = { EnemyImg, EnemyImg2, EnemyImg3 };
        //    ProgressBar[] bars = { HPenemyBar, HPenemyBar2, HPenemyBar3 };
        //    Label[] names = { Enemy, Enemy2, Enemy3 };
        //    Label[] hps = { HPenemy, HPenemy2, HPenemy3 };
        //    AnyHideX(images, bars, names, hps);
        //    AnyShowX(names[Sets.SelectedTarget], images[Sets.SelectedTarget],
        //        bars[Sets.SelectedTarget], hps[Sets.SelectedTarget]);
        //}
        //#endregion

        //#region BattleEnd Members
        ////[EN] Battle : After action.
        ////[RU] Сражение : Последействие.
        //private void AfterAction()
        //{
        //    HP.Foreground = Brushes.White;
        //    AnyHideX(BattleText1, BattleText2);
        //    if (speed > 0)
        //    {
        //        Sound1.Stop();
        //        SpeedDown();
        //        if (PRegn.IsEnabled)
        //            TimerOff(ref PRegn);
        //        if (PCtrl.IsEnabled)
        //            TimerOff(ref PCtrl);

        //        Exp = 0;
        //        Mat = 0;
        //        speed = 0;
        //        AnyHide(BattleScene);
        //        AnyHideX(BattleText2, Img6, Img7, Img8, FoesCount1, FoesCount2, FoesCount3,
        //            BattleText6, BuffsUpImg, BuffUpTxt, ToughUpImg, ToughUpTxt);
        //        AnyShowX(Img1, Img2, Threasure1, SaveProgress);
        //        CheckMapX(new byte[] { 104, 105, 105, 106, 107, 108 },
        //            new Image[] { JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });

        //        AnyShowX(ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3);
        //        if (CurrentLocation == 0)
        //            switch (Sets.LockIndex)
        //            {
        //                case 0: break;
        //                case 1: AnyShowX(KeyImg3, LockImg3); break;
        //                case 2: AnyShowX(KeyImg2, LockImg2, KeyImg3, LockImg3); break;
        //                default:
        //                    AnyShowX(KeyImg1, KeyImg2, KeyImg3, LockImg1,
        //               LockImg2, LockImg3); break;
        //            }
        //        else if (CurrentLocation == 1)
        //            AnyShowX(SecretChestImg1, SecretChestImg2);
        //        if (CheckMap(7))
        //            AnyShow(Boulder1);
        //        Sets.Rnd1 = 0;
        //        Sets.SelectedTarget = 0;
        //        string[] music = new string[] { Paths.OST.Music.AncientPyramid,
        //            Paths.OST.Music.WaterTemple, Paths.OST.Music.LavaTemple };
        //        PlayMusic(music[CurrentLocation]);
        //        for (byte i = 0; i < foes.Length; i++)
        //            foes[i] = DeadFoe;
        //        RecordFoes.Clear();
        //    }
        //    else if (foes[0].HP <= 0 && foes[1].HP <= 0 && foes[2].HP <= 0)
        //    {
        //        Sound1.Stop();
        //        SpeedDown();
        //        if (PRegn.IsEnabled)
        //            TimerOff(ref PRegn);
        //        if (PCtrl.IsEnabled)
        //            TimerOff(ref PCtrl);

        //        PlaySound(Paths.OST.Sounds.NowTheWinnerIs);
        //        Sets.Rnd1 = 0;
        //        Sets.SelectedTarget = 0;
        //        AnyShowX(BattleText1, textOk2, WonTxt);
        //        RecordFoes.Clear();
        //    }
        //    else if (GetHP > 0)
        //    {
        //        Time1.Value = 0;
        //        TimerOn(ref PTurn);
        //        AnyHideX(BattleText1, BattleText2);
        //    }
        //}
        //#endregion

        //#region Timing Members
        ////[EN] Player and GetFoes timing.
        ////[RU] Соблюдение времени игроком и врагами.
        //public ushort TimeFormula => Shrt((305 - GetAGL) / GameSpeed.Value);
        //private void Time()
        //{
        //    MainHero.DefenseState = 1;
        //    Img5.Source = Bmper(MainHero.Icon);
        //    Lab2.Foreground = Brushes.Yellow;
        //    if (AutoTurn.IsEnabled && !FoesFighting())
        //        BadTime();
        //    else
        //        AnyShow(FightMenu);
        //}

        //private ushort TimeFoeFormula(in byte speed) => Shrt(10000 - speed * 20);
        //private async void FoeTurns(byte foeNo)
        //{
        //    ushort PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
        //    ushort turn = TimeFoeFormula(foes[foeNo].Speed);
        //    await Task.Delay(turn);
        //    while (GetHP > 0 && foes[foeNo].HP > 0 && PlayerDef < foes[foeNo].Attack && !Pause.IsEnabled)
        //    {
        //        PlayerDef = Shrt(GetDEF + (GetSPL * GetAGL * 0.005));
        //        ushort dmg = Shrt(foes[foeNo].Attack - PlayerDef);
        //        EnemyOnAttack(dmg);
        //        await FoesShowDown(foeNo, Shrt(50 / GameSpeed.Value));
        //        AnyHide(BattleText6);
        //        await Task.Delay(turn);
        //    }
        //}

        //private async void PoisonFoeTurns(byte foeNo)
        //{
        //    ushort PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
        //    ushort turn = TimeFoeFormula(foes[foeNo].Speed);
        //    await Task.Delay(turn);
        //    while (GetHP > 0 && foes[foeNo].HP > 0 && PlayerDef < foes[foeNo].Attack && !Pause.IsEnabled)
        //    {
        //        PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
        //        ushort dmg = Shrt(foes[foeNo].Attack - PlayerDef);
        //        if (Random1.Next(1, 13) == 7)
        //            GetStatus = 1;
        //        EnemyOnAttack(dmg);
        //        await FoesShowDown(foeNo, Shrt(50 / GameSpeed.Value));
        //        AnyHide(BattleText6);
        //        await Task.Delay(turn);
        //    }
        //}

        //private async void BossTurns(byte foeNo)
        //{
        //    ushort PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
        //    ushort turn = TimeFoeFormula(foes[foeNo].Speed);
        //    await Task.Delay(turn);
        //    while (GetHP > 0 && foes[foeNo].HP > 0 && PlayerDef < foes[foeNo].Attack && !Pause.IsEnabled)
        //    {
        //        PlayerDef = Shrt(GetDEF + (GetSPL * GetAGL * 0.005));
        //        ushort dmg = Shrt(foes[foeNo].Attack - PlayerDef);
        //        EnemyOnAttack(dmg);
        //        await BossShowDown(foeNo, Shrt(50 / GameSpeed.Value));
        //        AnyHide(BattleText6);
        //        await Task.Delay(turn);
        //    }
        //}

        //private void CheckFoesTurns(byte foeNo)
        //{
        //    if (Sets.SpecialBattle != 0)
        //        BossTurns(foeNo);
        //    else if ((foes[foeNo].No == 0) || (foes[foeNo].No == 8))
        //        PoisonFoeTurns(foeNo);
        //    else
        //        FoeTurns(foeNo);
        //}

        //private void EnemyOnAttack(in ushort dmg)
        //{
        //    if (Sets.SpecialBattle != 200)
        //        GetHP = Shrt(Math.Max(GetHP - dmg, 0));
        //    else
        //    {
        //        GetHP = Shrt(Math.Max(Math.Min(GetHP - dmg +
        //            Math.Min(Shrt(10), GetAP), GetHP), 0));
        //        GetAP = Shrt(Math.Max(GetAP - 10, 0));
        //    }
        //    BattleText6.Content = "-" + dmg;
        //    AnyShow(BattleText6);
        //    if (Sets.SpecialBattle == 200)
        //        return;
        //    if (Img4.Source.ToString().Contains(Paths.Static.Person.Usual))
        //        ShowAction(Paths.Dynamic.Person.Hurt);
        //    //FlashLabel(BattleText6,Brushes.Red);
        //}

        //private void UnlimitedActionsTickCheck(in string[] spec)
        //{
        //    TargetImage.Source = Bmper(spec[trgt]);
        //    trgt = Bits(trgt >= spec.Length - 1 ? 0 : trgt + 1);
        //}
        //#endregion

        //#region EnemiesShowdown Members
        //private async Task BossShowDown(byte no, ushort time)
        //{
        //    string[] enemyAnimate = foes[no].Animate;
        //    string ememyImg = foes[no].Image;
        //    for (byte i = 0; i < enemyAnimate.Length; i++)
        //    {
        //        Trace.WriteLine(enemyAnimate[i]);
        //        BossSlot1.Source = Bmper(enemyAnimate[i]);
        //        await Task.Delay(time);
        //    }
        //    BossSlot1.Source = Bmper(ememyImg);
        //}

        //private async Task FoesShowDown(byte no, ushort time)
        //{
        //    string[] enemyAnimate = foes[no].Animate;
        //    string ememyImg = foes[no].Image;
        //    Image[] enemiesImg = { Img6, Img7, Img8 };
        //    for (byte i = 0; i < enemyAnimate.Length; i++)
        //    {
        //        enemiesImg[no].Source = Bmper(enemyAnimate[i]);
        //        await Task.Delay(time);
        //    }
        //    enemiesImg[no].Source = Bmper(ememyImg);
        //}
        //#endregion

        //#region EnemiesPain Members
        //private async void FoesKickedAll(ushort strength, ushort time)
        //{
        //    AnyShow(DamageFoe);
        //    for (byte target = 0; target < foes.Length; target++)
        //        if (foes[target].HP > 0)
        //            await FoesKicked(target, strength, time);
        //    AnyHide(DamageFoe);
        //    AfterAction();
        //}

        //private async void FoesKickedOne(byte target, ushort strength, ushort time)
        //{
        //    AnyShow(DamageFoe);
        //    await FoesKicked(target, strength, time);
        //    AnyHide(DamageFoe);
        //    AfterAction();
        //}

        //private async Task FoesKicked(byte target, ushort strength, ushort time)
        //{
        //    FrameworkElement[][] elements = new FrameworkElement[][] {
        //        new FrameworkElement[] { HPenemyBar, HPenemy, Enemy, EnemyImg },
        //        new FrameworkElement[] { HPenemyBar2, HPenemy2, Enemy2, EnemyImg2 },
        //        new FrameworkElement[] { HPenemyBar3, HPenemy3, Enemy3, EnemyImg3 }
        //    };
        //    AnyShowX(elements[target]);
        //    DamageConcretelyFoe(strength, target);
        //    if (foes[target].HP <= 0)
        //        SuperCheckFoes(target);
        //    else
        //        FoesRefresh();
        //    await Task.Delay(time);
        //    AnyHideX(elements[target]);
        //}

        //private void DamageConcretelyFoe(in ushort strength, int no)
        //{
        //    foes[no].HP = Shrt(Math.Max(foes[no].HP - strength, 0));
        //    DamageFoe.Content = foes[no].HP > 0 ? $"-{strength}" : "Убит";
        //}
        //#endregion

        //private bool FoesFighting()
        //{
        //    return (GetHP <= 0) || (foes[0].HP <= 0 && foes[1].HP <= 0 && foes[2].HP <= 0);
        //}

        //private void FoesRefresh()
        //{
        //    OnPropertyChanged(nameof(GetFoe1));
        //    OnPropertyChanged(nameof(GetFoe2));
        //    OnPropertyChanged(nameof(GetFoe3));
        //}

        //#region Bosses Members
        ////[EN] Battle : Boss 1 (Pharaoh).
        ////[RU] Сражение : Босс 1 (Фараон).
        //private void BossBattle1()
        //{
        //    TargetImage = BossTrgt;
        //    Sets.Rnd1 = 1;
        //    foes[0] = BossNo1;
        //    BossSlot1.Source = Bmper(Paths.Static.Bosses.Pharaoh);
        //    AnyShow(BossSlot1);
        //    Exp += 125;
        //    Mat += 250;
        //    PlayMusic(Paths.OST.Music.LookWhoAwake);
        //    CalculateBattleStatus();
        //    Button4.IsEnabled = false;
        //    CheckFoesTurns(0);
        //    RecordFoes.Add(BossNo1.Name, 1);
        //    EnemiesShow(RecordFoes);
        //    FoesRefresh();
        //}

        ////[EN] Battle : Boss 2 (????).
        ////[RU] Сражение : Босс 2 (????).
        //private void BossBattle2()
        //{
        //    TargetImage = BossTrgt;
        //    Sets.Rnd1 = 1;
        //    foes[0] = BossNo2;
        //    BossSlot1.Source = Bmper(Paths.Static.Bosses.Warrior);
        //    AnyShow(BossSlot1);
        //    Exp += 255;
        //    Mat += 255;
        //    PlayMusic(Paths.OST.Music.SayHello);
        //    CalculateBattleStatus();
        //    CheckFoesTurns(0);
        //    RecordFoes.Add(BossNo2.Name, 1);
        //    EnemiesShow(RecordFoes);
        //    Button4.IsEnabled = false;
        //    FoesRefresh();
        //}

        ////[EN] Battle : Boss 3 (The Lord).
        ////[RU] Сражение : Босс 3 (Владыка).
        //private void BossBattle3()
        //{
        //    TargetImage = BossTrgt;
        //    Sets.Rnd1 = 1;
        //    foes[0] = BossNo3;
        //    BossSlot1.Source = Bmper(Paths.Static.Bosses.MrOfAll);
        //    AnyShow(BossSlot1);
        //    Exp += 255;
        //    Mat += 255;
        //    PlayMusic(Paths.OST.Music.SeriousTalk);
        //    CalculateBattleStatus();
        //    CheckFoesTurns(0);
        //    RecordFoes.Add(BossNo3.Name, 1);
        //    EnemiesShow(RecordFoes);
        //    Button4.IsEnabled = false;
        //    FoesRefresh();
        //}

        ////[EN] Battle : Secret boss 1 (Ugh Zan I). + Remember true params.
        ////[RU] Сражение : Секретный босс 1 (Угх Зан I). + Запоминание настоящих параметров.
        //public static ushort[] RememberHPAP = { 0, 0, 0, 0 };
        //public static byte[] RememberParams = { 0, 0, 0, 0 };
        //private void SecretBossBattle1()
        //{
        //    TargetImage = BossTrgt;
        //    AnyHideX(Button4, Items, Abilities);
        //    Sets.Rnd1 = 1;
        //    foes[0] = SBoss;
        //    BossSlot1.Source = Bmper(Paths.Static.Bosses.UghZan);
        //    AnyShow(BossSlot1);
        //    ShowAction(Paths.Dynamic.Person.SSwitch, Paths.Dynamic.Icon.SSwitch);
        //    APtext.Content = "БР";
        //    GetHero = Sam;
        //    RefreshHeroFully();
        //    Exp += 250;
        //    Mat += 500;
        //    PlayMusic(Paths.OST.Music.SeriousIsMe);
        //    CalculateBattleStatus();
        //    CheckFoesTurns(0);
        //    RecordFoes.Add(SBoss.Name, 1);
        //    EnemiesShow(RecordFoes);
        //    FoesRefresh();
        //}
        //#endregion

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
