using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Helpers;
using WpfApp1.Helpers.Attach;
using static WpfApp1.Customing.Decorators;
using static WpfApp1.Mechanics.MapBuilder;
using static WpfApp1.Customing.Converters.Converters;
using static WpfApp1.Mechanics.Algorithms.Coloring;
using static WpfApp1.Mechanics.Algorithms.Encoding;
using static WpfApp1.Helpers.Abilities;
using static WpfApp1.Helpers.Characteristics;
using static WpfApp1.Helpers.Bag;
using static WpfApp1.Exceptions.ErrorList;
using System.Diagnostics;

namespace WpfApp1
{

    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //[EN] Initialize MainWindow (Main Constructor)
        //[RU] Инициализация ГлавногоЭкрана (Главный Конструктор).
        public MainWindow()
        {
            InitializeComponent();
            Functionality();
        }
        private void Functionality()
        {
            DataContext = this;
            DispatcherTimer[] timers = new DispatcherTimer[] {
                Targt, PRegn, PCtrl, PTurn, WRecd, RRoll, TRout
            };
            SetAllTimeTriggers(ref timers);
            ShowFoesStats();
            PlayMusic(Paths.OST.Music.MainTheme);
            Adaptate();
            try {
                Autorization();
                SeeMap();
            } catch (Exception ex) {
                _ = new Reload(Numb(CONECTION_ERROR), ex.Message).ShowDialog();
                Close();
            }
            Anonymous();

        }
        private Image TargetImage;
        public ushort GetHP
        {
            get => MainHero.CurrentHP;
            set
            {
                MainHero.CurrentHP = value;
                OnPropertyChanged();
                if (MainHero.CurrentHP <= 0)
                {
                    GetStatus = 0;
                    AnyHideX(Img2, GameMenu, BattleScene);
                    Sound1.Stop();
                    Sound2.Stop();
                    Sound3.Stop();
                    AnyShow(GameOver);
                    if (PTurn.IsEnabled)
                        TimerOff(ref PTurn);
                    if (RRoll.IsEnabled)
                        TimerOff(ref RRoll);
                    if (TRout.IsEnabled)
                        TimerOff(ref TRout);
                }
            }
        }
        public ushort GetMHP
        {
            get => MainHero.MaxHP;
            set
            {
                MainHero.MaxHP = value;
                OnPropertyChanged();
            }
        }
        public ushort GetAP
        {
            get => MainHero.CurrentAP;
            set
            {
                MainHero.CurrentAP = value;
                OnPropertyChanged();
            }
        }
        public ushort GetMAP
        {
            get => MainHero.MaxAP;
            set
            {
                MainHero.MaxAP = value;
                OnPropertyChanged();
            }
        }
        public ushort GetATK
        {
            get => Shrt(MainHero.Attack + MainHero.Weapon.Power + AbilityBonuses[0]);
            set
            {
                MainHero.Attack = Bits(value);
                OnPropertyChanged();
            }
        }
        public ushort GetDEF
        {
            get => Shrt((MainHero.Defence * MainHero.DefenseState) + MainHero.Armor.Power
                    + MainHero.Legs.Power + MainHero.Boots.Power + AbilityBonuses[1]);
            set
            {
                MainHero.Defence = Bits(value);
                OnPropertyChanged();
            }
        }
        public byte GetAGL
        {
            get => MainHero.Speed;
            set
            {
                MainHero.Speed = value;
                OnPropertyChanged();
            }
        }
        public byte GetSPL
        {
            get => GetHero.Special;
            set
            {
                GetHero.Special = value;
                OnPropertyChanged();
            }
        }
        public byte GetStatus
        {
            get => MainHero.PlayerStatus;
            set
            {
                MainHero.PlayerStatus = value;
                if (MainHero.PlayerStatus == 1)
                    PoisonHurts();
                OnPropertyChanged();
            }
        }
        public ushort GetExp
        {
            get => MainHero.Experience;
            set
            {
                MainHero.Experience = value;
                OnPropertyChanged();
            }
        }
        public byte GetLV
        {
            get => MainHero.CurrentLevel;
            set
            {
                MainHero.CurrentLevel = Math.Min(Bits(25), value);
                byte lvl = Bits(value - 1);
                GetMHP = MainHero.MaxHPNxt[lvl];
                GetMAP = MainHero.MaxAPNxt[lvl];
                GetATK = MainHero.AttackNxt[lvl];
                GetDEF = MainHero.DefenseNxt[lvl];
                GetAGL = MainHero.SpeedNxt[lvl];
                GetSPL = MainHero.SpecialNxt[lvl];
                if (GetLV >= 25)
                {
                    NextExpBar.Value = NextExpBar.Maximum;
                    Exp1.Content = ExpText.Content = Txts.Common.Expert;
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(TimeFormula));
                RefreshSkills();
            }
        }
        public ushort GetNlvl => GetHero.NextLevel[GetLV - 1];
        public ushort GetMaterials
        {
            get { return GetBag.Materials; }
            set
            {
                GetBag.Materials = value;
                OnPropertyChanged();
            }
        }
        public Bag GetBag { get; set; } = new Bag();
        public Characteristics GetHero
        {
            get { return MainHero; }
            set
            {
                MainHero = value;
                OnPropertyChanged();
            }
        }
        Foe[] foes = { DeadFoe, DeadFoe, DeadFoe };
        static Foe DeadFoe = new Foe(1, Paths.Static.Foes.DeadIcon, "Цель уничтожена");
        public Foe GetFoe1
        {
            get { return foes[0] ?? DeadFoe; }
            set
            {
                foes[0] = value;
                OnPropertyChanged();
            }
        }
        public Foe GetFoe2
        {
            get { return foes[1] ?? DeadFoe; }
            set
            {
                foes[1] = value;
                OnPropertyChanged();
            }
        }
        public Foe GetFoe3
        {
            get { return foes[2] ?? DeadFoe; }
            set
            {
                foes[2] = value;
                OnPropertyChanged();
            }
        }

        //[EN] Connection to database and show progress feature
        //[RU] Подключение к базе данных и особенность показа прогресса.
        Sql TSql = new Sql();
        public void Autorization()
        {
            TSql.CheckAllRecordedPlayers();
            CurrentPlayer.Content = TSql.GetCurrentPlayer();
            Continue.IsEnabled = TSql.CheckIfPlayerCanContinue();
            ConAdv.Source = Bmper(Continue.IsEnabled ?
                Paths.Static.Menu.Adventures.BeforeConAdv :
                Paths.Static.Menu.Adventures.AdventureLock);
        }
        private void SeeMap()
        {
            byte locs = Bits(TSql.CheckTask());
            ChangeBackground(LocationDecode(locs), locs);
        }
        private bool TimeChamber()
        {
            if (FleeTime[0] <= 0 && FleeTime[1] <= 0)
            {
                AnyHideX(TimerFlees, TimerFlees1);
                WonOrDied();
                AnyShow(GameOver);
                return true;
            }
            if (FleeTime[1] <= 0)
            {
                FleeTime[0]--;
                FleeTime[1] = 60;
            }
            FleeTime[1]--;
            string content = string.Format("{0:0}:{1:00}", FleeTime[0], FleeTime[1]);
            TimerFlees.Content = content;
            int time = (FleeTime[0] * 60) + FleeTime[1];
            Color foreColor = LinearStrategy(time, 150);
            TimerFlees.Foreground = new SolidColorBrush(Flashing(time, foreColor));
            TimerFlees.BorderBrush = new SolidColorBrush(foreColor);
            return false;
        }
        private bool WorldRecord()
        {
            TimeWorldRecord[2]++;
            for (int i = TimeWorldRecord.Length - 1; i > 0; i--) {
                byte[] Conds = { 23, 60, 60 };
                if (TimeWorldRecord[i] >= Conds[i])
                {
                    TimeWorldRecord[i - 1]++;
                    TimeWorldRecord[i] = 0;
                }
            }
            string content = string.Format("{0:0}:{1:00}:{2:00}",
                TimeWorldRecord[0], TimeWorldRecord[1], TimeWorldRecord[2]);
            TimeRecordText.Content = content;
            return TimeWorldRecord[0] > 23;
        }

        static Characteristics Ray = new Characteristics
        {
            MaxHP = 100,
            MaxAP = 40,
            Attack = 25,
            Defence = 15,
            Speed = 15,
            Special = 25,
            Image = Paths.Static.Person.Usual,
            Icon = Paths.Static.Icon.Usual,
        };
        static Characteristics Sam = new Characteristics
        {
            MaxHP = 200,
            MaxAP = 200,
            CurrentHP = 200,
            CurrentAP = 200,
            Attack = 50,
            Defence = 50,
            Speed = 50,
            Special = 50,
            Image = Paths.Static.Person.Serious,
            Icon = Paths.Static.Icon.Serious,
            Weapon = new Equipment.Weapon(Txts.Equipment.Hands.Minigun,
                "Weapon", Txts.Hints.EqWpn4, Paths.OST.Noises.Minigun,
                50, 254, Paths.Dynamic.Person.SeriousMg,
                Paths.Dynamic.Icon.SeriousMg)
        };
        Characteristics MainHero = Ray;

        Foe[] FoesOnLocation => LocationsFoes[CurrentLocation];

        public FightSkills ATorch => new FightSkills("Факел",
            Txts.Abililities.Torch, Paths.Dynamic.Person.Torch,
            Paths.Dynamic.Icon.Torch, 3, 4, Shrt(GetSPL * 1.25),
            Paths.OST.Noises.Torch);
        public FightSkills AWhip => new FightSkills("Кнут",
            Txts.Abililities.Whip, Paths.Dynamic.Person.Whip,
            Paths.Dynamic.Icon.Whip, 6, 6, Shrt(GetSPL * 1.5),
            Paths.OST.Noises.Whip);
        public FightSkills ASling => new FightSkills("Рогатка",
            Txts.Abililities.Throw, Paths.Dynamic.Person.Thrower,
            Paths.Dynamic.Icon.Thrower, 11, 15, Shrt(GetSPL * 2.5),
            Paths.OST.Noises.Thrower);
        public FightSkills ACombo => new FightSkills("Супер",
            Txts.Abililities.Spec1, Paths.Dynamic.Person.Super,
            Paths.Dynamic.Icon.Super, 7, 10, Shrt(GetSPL * 2),
            Paths.OST.Noises.Super);
        public FightSkills AWhirl => new FightSkills("Буря",
            Txts.Abililities.Spec2, Paths.Dynamic.Person.Tornado,
            Paths.Dynamic.Icon.Tornado, 13, 20, Shrt(GetSPL * 3),
            Paths.OST.Noises.Whirl);
        public FightSkills AQuake => new FightSkills("Обвал",
            Txts.Abililities.Spec3, Paths.Dynamic.Person.Quake,
            Paths.Dynamic.Icon.Quake, 18, 30, Shrt(GetSPL * 4),
            Paths.OST.Noises.Quake);
        public MedicineSkills ACure => new MedicineSkills("Лечение",
            Txts.Abililities.Cure, Paths.Dynamic.Person.Cure,
            Paths.Dynamic.Icon.Cure, 2, 5, Shrt(GetSPL * 2),
            Paths.OST.Noises.Cure);
        public MedicineSkills ACure2 => new MedicineSkills("Лечение 2",
            Txts.Abililities.Cure2, Paths.Dynamic.Person.Cure2,
            Paths.Dynamic.Icon.Cure2, 21, 10, GetMHP,
            Paths.OST.Noises.Cure2);
        public MedicineSkills AHeal => new MedicineSkills("Исцеление",
            Txts.Abililities.Heal, Paths.Dynamic.Person.Heal,
            Paths.Dynamic.Icon.Heal, 4, 3, Paths.OST.Noises.Heal);
        public MedicineSkills AHpup => new MedicineSkills("Время лечит",
            Txts.Abililities.Regen, Paths.Dynamic.Person.Regen,
            Paths.Dynamic.Icon.Regen, 20, 15, 1, Paths.OST.Noises.HpUp);
        public MedicineSkills AApup => new MedicineSkills("Контроль",
            Txts.Abililities.Control, Paths.Dynamic.Person.Control,
            Paths.Dynamic.Icon.Control, 25, 0, 1, Paths.OST.Noises.ApUp);
        public SupportSkills ATemper => new SupportSkills("Усиление",
            Txts.Abililities.Buffs, Paths.Dynamic.Person.BuffUp,
            Paths.Dynamic.Icon.BuffUp, 16, 12,
            Paths.OST.Noises.StrongStand);
        public SupportSkills ASecure => new SupportSkills("Охрана",
            Txts.Abililities.Tough, Paths.Dynamic.Person.ToughenUp,
            Paths.Dynamic.Icon.ToughenUp, 14, 8,
            Paths.OST.Noises.Shield);
        public SupportSkills ALearn => new SupportSkills("Изучение",
            Txts.Abililities.Learn, Paths.Dynamic.Person.Learn,
            Paths.Dynamic.Icon.Learn, 5, 2, Paths.OST.Noises.Learn);

        Misc Sets = new Misc();
        Misc.Adopt Adoptation = new Misc.Adopt();

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

        //[EN] Initialize timers for events
        //[RU] Инициализация таймеров для событий.

        DispatcherTimer Targt = new DispatcherTimer();
        DispatcherTimer PRegn = new DispatcherTimer();
        DispatcherTimer PCtrl = new DispatcherTimer();
        DispatcherTimer PTurn = new DispatcherTimer();

        DispatcherTimer WRecd = new DispatcherTimer();
        DispatcherTimer RRoll = new DispatcherTimer();
        DispatcherTimer TRout = new DispatcherTimer();

        //[EN] Initialize way to success the escape and get experience/materials.
        //[RU] Инициализация состояний получения опыта/материалов и успеха побега.
        public static int speed = 0;
        public static ushort Exp = 0;
        public static ushort Mat = 0;
        private static byte PainIndex = 0;
        Dictionary<string, int> RecordFoes = new Dictionary<string, int>();

        //[EN] Initialize random mechanic
        //[RU] Инициализация механики ведения случайных величин.
        public static Random Random1 = new Random();
        public static int rnd = Random1.Next(5, 20);
        public static int poison = 0;

        //[EN] Injuries.
        //[RU] Ранения.
        public static byte PlayerHurt = 0;
        public static byte PlayerHurtM = 0;
        public static byte trgt = 0;
        public static byte[] EnemyAtck = new byte[] { 0, 0, 0 };

        //[EN] Values for stopwatch and timer
        //[RU] Значения времени для секундомера и таймера.
        public static byte[] TimeWorldRecord = new byte[] { 0, 0, 0 };
        public static byte[] FleeTime = new byte[] { 2, 30 };

        //[EN] Animation variables.
        //[RU] Переменные анимации.
        public static byte Appearance = 0;
        private void ShowFoesStats()
        {
            FastTextChange(new Label[] { FoeAtk1, FoeAtk2, FoeAtk3, FoeAtk4, FoeAtk5,
                FoeAtk6, FoeAtk7, FoeAtk8, FoeAtk9, FoeAtk10, FoeAtk11, FoeAtk12,
                FoeAtk13, FoeAtk14, FoeAtk15, FoeAtk16 },
                Strs(Spider.Attack, Mummy.Attack, Mummy.Attack, Bones.Attack,
                Vulture.Attack, Ghoul.Attack, GrimReaper.Attack, Scarab.Attack,
                KillerMole.Attack, Imp.Attack, Worm.Attack, Master.Attack,
                BossNo1.Attack, BossNo2.Attack, BossNo3.Attack, SBoss.Attack));

            FastTextChange(new Label[] { FoeDef1, FoeDef2, FoeDef3, FoeDef4, FoeDef5,
                FoeDef6, FoeDef7, FoeDef8, FoeDef9, FoeDef10, FoeDef11, FoeDef12,
                FoeDef13, FoeDef14, FoeDef15, FoeDef16 },
                Strs(Spider.Defence, Mummy.Defence, Mummy.Defence, Bones.Defence,
                Vulture.Defence, Ghoul.Defence, GrimReaper.Defence, Scarab.Defence,
                KillerMole.Defence, Imp.Defence, Worm.Defence, Master.Defence,
                BossNo1.Defence, BossNo2.Defence, BossNo3.Defence, SBoss.Defence ));

            FastTextChange(new Label[] { FoeSpd1, FoeSpd2, FoeSpd3, FoeSpd4, FoeSpd5,
                FoeSpd6, FoeSpd7, FoeSpd8, FoeSpd9, FoeSpd10, FoeSpd11, FoeSpd12,
                FoeSpd13, FoeSpd14, FoeSpd15, FoeSpd16 },
                Strs(Spider.Speed, Mummy.Speed, Mummy.Speed, Bones.Speed,
                Vulture.Speed, Ghoul.Speed, GrimReaper.Speed, Scarab.Speed,
                KillerMole.Speed, Imp.Speed, Worm.Speed, Master.Speed,
                BossNo1.Speed, BossNo2.Speed, BossNo3.Speed, SBoss.Speed ));

            FastTextChange(new Label[] { FoeSpc1, FoeSpc2, FoeSpc3, FoeSpc4, FoeSpc5,
                FoeSpc6, FoeSpc7, FoeSpc8, FoeSpc9, FoeSpc10, FoeSpc11, FoeSpc12,
                FoeSpc13, FoeSpc14, FoeSpc15, FoeSpc16 },
                Strs(Spider.Agility, Mummy.Agility, Mummy.Agility, Bones.Agility,
                Vulture.Agility, Ghoul.Agility, GrimReaper.Agility, Scarab.Agility,
                KillerMole.Agility, Imp.Agility, Worm.Agility, Master.Agility,
                BossNo1.Agility, BossNo2.Agility, BossNo3.Agility, SBoss.Agility));
        }

        //[EN] Adaptate mechanics, sreen elements formula: CurrentScreenSize/Recomended(1920X1080)
        //[RU] Механика адаптации, формула расположения элементов: ТекущееРазрешениеЭкрана/Рекомендуемое(1920Х1080)
        private void Adaptate()
        {
            Adoptation.Width = SystemParameters.PrimaryScreenWidth / 1920;
            Adoptation.Height = SystemParameters.PrimaryScreenHeight / 1080;
            ScaleTransform[] scales = { MuLd, SnLd, NsLd, Gs, Brgt, TmOn };
            for (byte i = 0; i < scales.Length; i++)
                Scales(scales[i], scales[i].ScaleX * Adoptation.Width, scales[i].ScaleY * Adoptation.Height);
        }

        //[EN] Set events on triggers
        //[RU] Установка событий на триггеры
        private void SetAllTimeTriggers(ref DispatcherTimer[] timers)
        {
            EventHandler[] events = new EventHandler[]
            {
                 Targt_D_T28,  //[EN] Active target  | [RU] Активная цель
                 PRegn_F_T37,  //[EN] Regeneration   | [RU] Регенерация
                 PCtrl_F_T38,  //[EN] Control        | [RU] Контроль
                 PTurn_I_T42,  //[EN] Player turns   | [RU] Ходы игрока

                 WRecd_R_T44,  //[EN] Walk record    | [RU] Скорость прохождения
                 RRoll_L_T48,  //[EN] Rock roll trap | [RU] Ловушка перекати шар
                 TRout_F_T59   //[EN] Get away time  | [RU] Время до обвала
            };

            int timeBit = Numb(250_000 / GameSpeed.Value);   //25 миллисекунд
            int timeShort = Numb(500_000 / GameSpeed.Value); //50 миллисекунд

            TimeSpan[] spans = new TimeSpan[]
            {
                new TimeSpan(timeShort), new TimeSpan(timeBit),
                new TimeSpan(timeBit), TimeSpan.FromMilliseconds(1),
                new TimeSpan(timeBit), TimeSpan.FromMilliseconds(500),
                TimeSpan.FromSeconds(1)
            };
            for (byte i = 0; i < timers.Length; i++)
                ChangeTimer(ref timers[i], events[i], spans[i]);
        }

        //[EN] New game start and return to normal stats
        //[RU] Начало новой игры и возврат к исходным значениям.
        private void New_game()
        {
            RefreshSkills();
            TSql.DeselectAllPlayers();
            TSql.NewGameStart(TSql.CurrentLogin);

            Exp = 0;

            PharaohAppears.Opacity = 0.1;
            Ancient.Opacity = 0.25;
            FinalAppears.Opacity = 0.1;
            Sets.SpecialBattle = 0;
            TargetImage = TrgtImg;
            TheEnd.Source = Ura(Paths.CutScenes.Victory);

            MapScheme = MapBuild(0);
            AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4,
                Table1, Table2, Table3, Threasure1, SaveProgress, PharaohAppears },
                new int[] { 27, 24, 7, 9, 33, 25, 10, 4, 17, 8 },
                new int[] { 19, 11, 21, 20, 18, 13, 38, 36, 29, 36 });
            
            MainHero.SetStats(0);
            GetHP = 100;
            GetAP = 40;
            GetMaterials = 0;

            PlayerSetLocation(34, 18);
            HeroStatus();
            GetBag.EquipWearSet(false);
            OnPropertyChanged(nameof(GetBag));
            MainHero.MenuTask = 0;
            FastImgChange(Bmper(Paths.Static.Map.Models.ChestClosed1),
                ChestImg1, ChestImg2, ChestImg3, ChestImg4);
            Threasure1.Source = Bmper(Paths.Static.Map.Models.Artifact1);
        }

        //[EN] Play original soundtrack (OST)
        //[RU] Проигрывание оригинального саундтрека
        private void PlayMusic(in string Path) => PlayOST(Sound1, Path);
        private void PlayNoise(in string Path) => PlayOST(Sound2, Path);
        private void PlaySound(in string Path) => PlayOST(Sound3, Path);

        private void NewAdventure_Click(object sender, RoutedEventArgs e)
        {
            New_game();
            AnyShow(Med1);
            AnyHide(MainMenu);
            PlayMusic(Paths.OST.Music.Prologue);
        }

        //[EN] After game intro has been ended
        //[RU] После завершения пролога.
        private void Med1_MediaEnded(object sender, RoutedEventArgs e)
        {
            Img1.Source = Bmper(Paths.Static.Map.Normal);
            AnyShow(Img1);
            AnyShow(ChapterIntroduction);
            AnyHide(Med1);
            AnyHide(Skip1);
            PlayMusic(Paths.OST.Music.AncientPyramid);
        }
        
        //[EN] Complete tasks
        //[RU] Завершение задач.
        private void CollectKey(Image Key, Image Lock)
        {
            AnyHideX(Key, Lock);
            AnyShow(TaskCompletedImg);
            PlaySound(Paths.OST.Sounds.DoorOpened);
            Sets.LockIndex--;
            Sets.EnemyRate++;
            MainHero.MenuTask++;
        }
        private void PullTheLever(Image Lever, params Image[] Imgs)
        {
            AnyShowX(Imgs);
            Lever.Source = Bmper(Paths.Static.Map.Models.LeverOn);
            PlaySound(Paths.OST.Sounds.DoorOpened);
        }
        private void SpeedUp()
        {
            Sound2.SpeedRatio = GameSpeed.Value;
            Sound3.SpeedRatio = GameSpeed.Value;
        }
        private void SpeedDown()
        {
            Sound2.SpeedRatio = 1;
            Sound3.SpeedRatio = 1;
        }

        //[EN] Movement and map interaction
        //[RU] Передвижение и взаимодействие с картой.
        private byte CheckGuy()
        {
            string compare = Img2.Source.ToString();
            string[] Direction = {
                Paths.Static.Map.Models.Guy.StaticRight,
                Paths.Static.Map.Models.Guy.GoRight,

                Paths.Static.Map.Models.Guy.StaticDown,
                Paths.Static.Map.Models.Guy.GoDown1,
                Paths.Static.Map.Models.Guy.GoDown2,

                Paths.Static.Map.Models.Guy.StaticLeft,
                Paths.Static.Map.Models.Guy.GoLeft,

                Paths.Static.Map.Models.Guy.StaticUp,
                Paths.Static.Map.Models.Guy.GoUp1,
                Paths.Static.Map.Models.Guy.GoUp2
            };
            sbyte[,] Dir1 = {
                { 0, 0,  1, 1, 1,  0, 0,  -1, -1, -1 },
                { 1, 1,  0, 0, 0,  -1, -1,  0, 0, 0 }
            };
            for (byte i = 0; i < Direction.Length; i++)
                if (compare.Contains(Direction[i]))
                    return MapScheme[MainHero.Y + Dir1[0, i], MainHero.X + Dir1[1, i]];
            return 0;
        }
        private void Movement(in BitmapImage bmp)
        {
            Img2.Source = bmp;
            GroundCheck(MapScheme[MainHero.Y, MainHero.X]);
            if (MainHero.PlayerStatus == 1)
                Pain(1);
            TablesSetInfo();
            if (CurrentLocation >= 3)
                return;
            string[] dangers = {
                Paths.OST.Music.AncientPyramidDanger,
                Paths.OST.Music.WaterTempleDanger,
                Paths.OST.Music.LavaTempleDanger
            };
            if (CurrentLocation < 3 && Sets.StepsToBattle == rnd / 2)
                PlayMusic(dangers[CurrentLocation]);
            if (Sets.StepsToBattle >= rnd)
            {
                AnyHideX(PainImg, Img2, HPhelper);
                Sound1.Stop();
                PlayNoise(Paths.OST.Noises.Danger);
                LetsBattle();
            }
            Sets.StepsToBattle++;
        }
        private void Pain(int damage)
        {
            IhurtMyLegKit(damage);
            string[] pains = {
                Paths.Static.Map.Messages.Pain1,
                Paths.Static.Map.Messages.Pain2,
                Paths.Static.Map.Messages.Pain3,
                Paths.Static.Map.Messages.Pain2
            };
            PainImg.Source = Bmper(pains[PainIndex]);
            PainIndex++;
            if (PainIndex >= 4)
                PainIndex = 0;
        }
        private void IhurtMyLegKit(int damage)
        {
            GetHP = Shrt(Math.Max(GetHP - damage, 0));
            AnyGrid(HPhelper, Bits(Img2.GetValue(Grid.RowProperty)) - 1,
                Bits(Img2.GetValue(Grid.ColumnProperty)) - 1);
            AnyShowX(HPhelper, PainImg);
        }
        
        private void TablesSetInfo()
        {
            if (Sets.TableEN || TableMessage1.IsEnabled)
                AnyHide(TableMessage1);
            Sets.TableEN = !Sets.TableEN && !TableMessage1.IsEnabled;
            byte Interaction = CheckGuy();
            byte[] Conditions = { 171, 172, 173, 174, 175, 176, 177, 178, 179 };
            BitmapImage[] images = BmpersToX(Paths.Static.Map.Messages.Tb1_Msg1,
                Paths.Static.Map.Messages.Tb2_Msg1, Paths.Static.Map.Messages.Tb3_Msg1,
                Paths.Static.Map.Messages.Tb1_Msg2, Paths.Static.Map.Messages.Tb2_Msg2,
                Paths.Static.Map.Messages.Tb3_Msg2, Paths.Static.Map.Messages.Tb1_Msg3,
                Paths.Static.Map.Messages.Tb2_Msg3, Paths.Static.Map.Messages.Tb3_Msg3);
            Image[] Mess = { Table1, Table2, Table3, Table1,
                Table2, Table3, Table1, Table2, Table3 };
            for (byte i = 0; i < Conditions.Length; i++)
                if (Interaction == Conditions[i])
                    SetTablesMessage(images[i], CheckRow(Mess[i], 8), CheckColumn(Mess[i], 5));
        }
        private void SetTablesMessage(BitmapImage image, int X, int Y)
        {
            TableMessage1.Source = image;
            if (!Sets.TableEN) Sets.TableEN = true;
            AnyGrid(TableMessage1, X, Y);
            AnyShow(TableMessage1);
        }

        //[EN] Determine a battle
        //[RU] Определение битвы.
        private void LetsBattle()
        {
            Sets.StepsToBattle--;
            string[] dng = { Paths.OST.Noises.Danger, Paths.OST.Noises.Danger2, Paths.OST.Noises.Danger3 };
            PlayNoise(dng[CurrentLocation]);
            AnyShow(Med2);
        }
        private void WhatsGoingOn(in byte SecretBattlesIndex)
        {
            MapScheme[MainHero.Y, MainHero.X] = 0;
            Sets.SpecialBattle = SecretBattlesIndex;
            TargetImage = BossSlot1;
        }
        
        //[EN] Check what is under person foot.
        //[RU] Проверить на что герой наступил.
        private void GroundCheck(in byte Interaction)
        {
            switch (Interaction)
            {
                case 0: break;
                case 6: Pain(1); break;
                case 8: Pain(10); break;
                case 9: Pain(25); break;
                case 104:
                    ChangeMap(0, 104, 134);
                    AnyHide(JailImg1);
                    Sets.EnemyRate = 5;
                    MainHero.MenuTask++;
                    break;
                case 105:
                    ChangeMap(0, 105, 135);
                    AnyHide(JailImg2);
                    if (CurrentLocation == 1)
                        AnyHide(JailImg3);
                    TimerOn(ref RRoll);
                    break;
                case 106:
                    ChangeMap(0, 106, 136);
                    AnyHide(JailImg5);
                    if (CurrentLocation == 1)
                        MainHero.MenuTask++;
                    break;
                case 107: ChangeMap(0, 107, 137); AnyHide(JailImg6); break;
                case 108: ChangeMap(0, 108, 138); AnyHide(JailImg7); break;
                case 150: SavePlayer(); break;
                case 151: GetHP = GetMHP; PlayNoise(Paths.OST.Noises.Cure2); break;
                case 152: GetAP = GetMAP; PlayNoise(Paths.OST.Noises.ApUp); break;
                case 170:
                    if (TRout.IsEnabled)
                        TimerOff(ref TRout);
                    FleeTime = new byte[] { 2, 30 };
                    TimerFlees.Content = "2:30";
                    AnyHideX(Img2, TimerFlees, Img1);
                    MainHero.MenuTask++;
                    AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Ending),
                        new TimeSpan(0, 0, 0, 0, 0));
                    AnyShow(Skip1);
                    PlayMusic(Paths.OST.Music.PutTheEnd);
                    Img1.Source = Bmper(Paths.Static.Map.Normal);
                    break;
                case 191: WhatsGoingOn(200); LetsBattle(); break;
                case 192: ChangeMapToVoid(192); PlayerSetLocation(1, 57); break;
                default: break;
            }
        }

        //[EN] Movement (W,A,S,D)/target select (W,A,S,D); actions on map (E); open menu (LCtrl).
        //[RU] Передвижение (W,A,S,D)/выбор цели (W,A,S,D); действия при нахождении на локации (E); открыть меню (LCtrl).
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Form1.Close();
            if (e.Key == Key.P)
            {
                if (Pause.IsEnabled)
                    Resume();
                else
                    PauseGame();
            }
            if (Pause.IsEnabled)
                return;
            AnyHideX(ChestMessage1, TaskCompletedImg, PainImg, HPhelper);
            if (Img2.IsEnabled)
            {
                string guy = Img2.Source.ToString();
                if (e.Key == Key.W || e.Key == Key.Up)
                {
                    if (IsWayNext(MapScheme[MainHero.Y - 1, MainHero.X]))
                        PlayerSetLocation(MainHero.Y - 1, MainHero.X);
                    Movement(guy.Contains(Paths.Static.Map.Models.Guy.GoUp1)
                        ? Bmper(Paths.Static.Map.Models.Guy.GoUp2)
                        : Bmper(Paths.Static.Map.Models.Guy.GoUp1));
                }
                if (e.Key == Key.A || e.Key == Key.Left)
                {
                    if (IsWayNext(MapScheme[MainHero.Y, MainHero.X - 1]))
                        PlayerSetLocation(MainHero.Y, MainHero.X - 1);
                    Movement(guy.Contains(Paths.Static.Map.Models.Guy.StaticLeft)
                        ? Bmper(Paths.Static.Map.Models.Guy.GoLeft)
                        : Bmper(Paths.Static.Map.Models.Guy.StaticLeft));
                }
                if (e.Key == Key.S || e.Key == Key.Down)
                {
                    if (IsWayNext(MapScheme[MainHero.Y + 1, MainHero.X]))
                        PlayerSetLocation(MainHero.Y + 1, MainHero.X);
                    Movement(guy.Contains(Paths.Static.Map.Models.Guy.GoDown1)
                        ? Bmper(Paths.Static.Map.Models.Guy.GoDown2)
                        : Bmper(Paths.Static.Map.Models.Guy.GoDown1));
                }
                if (e.Key == Key.D || e.Key == Key.Right)
                {
                    if (IsWayNext(MapScheme[MainHero.Y, MainHero.X + 1]))
                        PlayerSetLocation(MainHero.Y, MainHero.X + 1);
                    Movement(guy.Contains(Paths.Static.Map.Models.Guy.StaticRight)
                        ? Bmper(Paths.Static.Map.Models.Guy.GoRight)
                        : Bmper(Paths.Static.Map.Models.Guy.StaticRight));
                }

                if (e.Key == Key.E)
                {
                    string[] ChestOp = { Paths.Static.Map.Models.ChestOpened1,
                        Paths.Static.Map.Models.ChestOpened2,
                        Paths.Static.Map.Models.ChestOpened3 };
                    string[,] EquipmentAll = new string[,] { {
                            Paths.Static.Map.Messages.Knucleduster,
                            Paths.Static.Map.Messages.LeatherArmor,
                            Paths.Static.Map.Messages.FeatherWears,
                            Paths.Static.Map.Messages.BandageBoots
                        }, { Paths.Static.Map.Messages.AncientKnife,
                            Paths.Static.Map.Messages.AncientArmor,
                            Paths.Static.Map.Messages.AncientPants,
                            Paths.Static.Map.Messages.StrongBoots }, {
                            Paths.Static.Map.Messages.LegendSword,
                            Paths.Static.Map.Messages.LegendArmor,
                            Paths.Static.Map.Messages.LegendPants,
                            Paths.Static.Map.Messages.LegendBoots
                        }
                    };
                    int[] LocItem = new int[] {
                        guy.Contains(Paths.Static.Map.Models.Guy.StaticDown) ?
                        MainHero.Y + 1 :
                        (guy.Contains(Paths.Static.Map.Models.Guy.StaticUp) ?
                        MainHero.Y - 1 : MainHero.Y),
                        guy.Contains(Paths.Static.Map.Models.Guy.StaticRight) ?
                        MainHero.X + 1 :
                        (guy.Contains(Paths.Static.Map.Models.Guy.StaticLeft) ?
                        MainHero.X - 1 : MainHero.X)
                    };
                    byte Interaction = MapScheme[LocItem[0], LocItem[1]];
                    switch (Interaction)
                    {
                        case 101:
                            AnyGrid(TaskCompletedImg, CheckRow(KeyImg1, 5),
                                CheckColumn(KeyImg1, 3));
                            CollectKey(KeyImg1, LockImg1);
                            ChangeMap(0, 101, 131);
                            break;
                        case 102:
                            AnyGrid(TaskCompletedImg, CheckRow(KeyImg2, 5),
                                CheckColumn(KeyImg2, 3));
                            CollectKey(KeyImg2, LockImg2);
                            ChangeMap(0, 102, 132);
                            break;
                        case 103:
                            AnyGrid(TaskCompletedImg, CheckRow(KeyImg3, 5),
                                CheckColumn(KeyImg3, 3));
                            CollectKey(KeyImg3, LockImg3);
                            ChangeMap(0, 103, 133);
                            break;
                        case 111:
                            AnyGrid(TaskCompletedImg, CheckRow(KeyImg3, 5), 39);
                            PullTheLever(Lever1, Bridge1, Bridge2, Bridge3, Bridge4);
                            ChangeMapToWall(111);
                            ChangeMapToVoid(138);
                            MainHero.MenuTask = 8;
                            break;
                        case 109:
                            PullTheLever(Lever2, Bridge5, Bridge6);
                            ChangeMapToWall(109);
                            ChangeMapToVoid(139);
                            break;
                        case 110:
                            PullTheLever(Lever3, Bridge7, Bridge8);
                            ChangeMapToWall(110);
                            ChangeMapToVoid(140); break;
                        case 161:
                            SomeRudeAppears(1, Paths.OST.Noises.Horror);
                            AnyShow(PharaohAppears);
                            SimpleCutScene(PharaohAppears, 0.01, 250);
                            break;
                        case 162:
                            SomeRudeAppears(2, Paths.OST.Noises.EgoRage);
                            AnyShowX(Ancient, Warrior);
                            ComplexCutScene(Ancient, 0.25, 250);
                            break;
                        case 163:
                            SomeRudeAppears(3, Paths.OST.Noises.EgoRage);
                            AnyShow(FinalAppears);
                            SimpleCutScene(FinalAppears, 0.05, 250);
                            break;
                        case 201:
                        case 208:
                            ChestOpen(ChestImg1, EquipmentAll[CurrentLocation, 1],
                                ChestOp[CurrentLocation], 1, CurrentLocation);
                            break;
                        case 202:
                        case 207:
                            ChestOpen(ChestImg2, EquipmentAll[CurrentLocation, 3],
                                ChestOp[CurrentLocation], 3, CurrentLocation);
                            break;
                        case 203:
                        case 206:
                            ChestOpen(ChestImg3, EquipmentAll[CurrentLocation, 0],
                                ChestOp[CurrentLocation], 0, CurrentLocation);
                            break;
                        case 204:
                        case 205:
                            ChestOpen(ChestImg4, EquipmentAll[CurrentLocation, 2],
                                ChestOp[CurrentLocation], 2, CurrentLocation);
                            break;
                        case 209:
                            ChestOpen(ChestImg1, EquipmentAll[CurrentLocation, 0],
                                ChestOp[CurrentLocation], 0, CurrentLocation);
                            break;
                        case 210:
                            ChestOpen(ChestImg2, EquipmentAll[CurrentLocation, 1],
                                ChestOp[CurrentLocation], 1, CurrentLocation);
                            break;
                        case 211:
                            ChestOpen(ChestImg3, EquipmentAll[CurrentLocation, 2],
                                ChestOp[CurrentLocation], 2, CurrentLocation);
                            break;
                        case 212:
                            ChestOpen(ChestImg4, EquipmentAll[CurrentLocation, 3],
                                ChestOp[CurrentLocation], 3, CurrentLocation);
                            break;
                        case 213:
                            ChestOpen(SecretChestImg1,
                                Paths.Static.Map.Messages.SeriousPants,
                                ChestOp[CurrentLocation], 2, 3);
                            break;
                        case 221:
                            ChangeMapToVoid(LocItem[0], LocItem[1], SpDmg1,
                            SpDmg2, SpDmg3, SpDmg4, SpDmg5);
                            Pain(50);
                            break;
                        case 222:
                            ChangeMapToVoid(LocItem[0], LocItem[1], SpHrb1, SpHrb2,
                                SpHrb3, SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8,
                                SpHrb9, SpHrb10, SpHrb11, SpHrb12, SpHrb13, SpHrb14);
                            if (GetBag.Herbs.Count < 255)
                                GetBag.Herbs.Count++;
                            OnPropertyChanged(nameof(GetBag));
                            break;
                        case 223:
                            ChangeMapToVoid(LocItem[0], LocItem[1], SpEtr1, SpEtr2,
                                SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7, SpEtr8,
                                SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14,
                                SpEtr15, SpEtr16, SpEtr17, SpEtr18);
                            if (GetBag.Ether2.Count < 255)
                                GetBag.Ether2.Count++;
                            OnPropertyChanged(nameof(GetBag));
                            break;
                        case 224:
                            ChangeMapToVoid(LocItem[0], LocItem[1], SpElx1,
                                SpElx2, SpElx3, SpElx4, SpElx5, SpElx6);
                            if (GetBag.Elixir.Count < 255)
                                GetBag.Elixir.Count++;
                            OnPropertyChanged(nameof(GetBag));
                            break;
                        case 225:
                            ChangeMapToVoid(LocItem[0], LocItem[1], SpSbg1,
                                SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6,
                                SpSbg7, SpSbg8, SpSbg9, SpSbg10, SpSbg11);
                            if (GetBag.SleepBag.Count < 255)
                                GetBag.SleepBag.Count++;
                            OnPropertyChanged(nameof(GetBag));
                            break;
                        case 226:
                            ChangeMapToVoid(LocItem[0], LocItem[1], SpSer);
                            GetBag.Weapons[3] = true;
                            OnPropertyChanged(nameof(GetBag));
                            break;
                        case 232:
                            ChangeMapToWall(232);
                            SecretChestImg2.Source = Bmper(ChestOp[CurrentLocation]);
                            AnyGrid(TaskCompletedImg, CheckRow(SecretChestImg2, 5),
                                CheckColumn(SecretChestImg2, 3));
                            AnyShow(TaskCompletedImg);
                            GetSecretReward();
                            break;
                        case 233:
                            ChangeMapToVoid(LocItem[0], LocItem[1], SpTsk);
                            GetSecretReward();
                            break;
                        default: break;
                    }
                }
                else if (e.Key == Key.LeftCtrl)
                {
                    PlayNoise(Paths.OST.Noises.BagOpen);
                    AnyHide(Img2);
                    AnyShow(GameMenu);
                }
                else if (e.Key == Key.I)
                    Bestiary();
            }
            else
                switch (e.Key)
                {
                    case Key.W:
                    case Key.Up:
                    case Key.A:
                    case Key.Left:
                        if (SelectMenuFight.IsEnabled || SelectMenuSkills.IsEnabled)
                            SelectKeyLeft();
                        break;
                    case Key.S:
                    case Key.Down:
                    case Key.D:
                    case Key.Right:
                        if (SelectMenuFight.IsEnabled || SelectMenuSkills.IsEnabled)
                            SelectKeyRight();
                        break;
                    case Key.LeftCtrl:
                    case Key.I:
                        if (GameMenu.IsEnabled)
                        {
                            AnyHide(GameMenu);
                            PlayNoise(Paths.OST.Noises.BagClose);
                        }
                        else if (BestiaryImg.IsEnabled)
                        {
                            AnyHide(BestiaryImg);
                            HideBestiary();
                        }
                        if (Img1.IsEnabled && !Med2.IsEnabled)
                            AnyShow(Img2);
                        break;
                }
        }

        private void PauseGame()
        {
            AnyShow(Pause);
            Sound1.Pause();
            if (Med1.IsEnabled)
                Med1.Pause();
            if (Med2.IsEnabled)
                Med2.Pause();
            if (Win.IsEnabled)
                Win.Pause();
            if (TheEnd.IsEnabled)
                TheEnd.Pause();
            if (ChapterIntroduction.IsEnabled)
                ChapterIntroduction.Pause();
            if (GameOver.IsEnabled)
                GameOver.Pause();
            if (!FoesFighting())
                TimerOff(ref PTurn);
            if (CurrentLocation == 3 && !TheEnd.IsEnabled) 
                TimerOff(ref TRout);
        }
        private void Resume()
        {
            AnyHide(Pause);
            Sound1.Play();
            if (Med1.IsEnabled)
                Med1.Play();
            if (Med2.IsEnabled)
                Med2.Play();
            if (Win.IsEnabled)
                Win.Play();
            if (TheEnd.IsEnabled)
                TheEnd.Play();
            if (ChapterIntroduction.IsEnabled)
                ChapterIntroduction.Play();
            if (GameOver.IsEnabled)
                GameOver.Play();
            if (!FoesFighting())
            {
                TimerOn(ref PTurn);
                if (GetStatus == 1)
                    PoisonHurts();
            }
            if (CurrentLocation == 3 && !TheEnd.IsEnabled)
                TimerOn(ref TRout);
            for (byte i = 0; i < 3; i++)
                if (foes[i].HP > 0)
                    CheckFoesTurns(i);
        }
        private void HideMenuSections()
        {
            AnyHideX(GameStatus, GameSkills, GameItems, GameEquip, GameTasks, HelpHints, GameSettings, SwitchPanel);
        }
        private void HideBestiary()
        {
            AnyHideX(FoeImg1, FoeAImg1, FoeDImg1, FoeGImg1, FoeSImg1, FoeAtk1, FoeDef1, FoeSpc1, FoeSpd1, FoeWkn1, FoeNam1, FoeDsc1,
                FoeImg2, FoeAImg2, FoeDImg2, FoeGImg2, FoeSImg2, FoeAtk2, FoeDef2, FoeSpc2, FoeSpd2, FoeWkn2, FoeNam2, FoeDsc2,
                FoeImg3, FoeAImg3, FoeDImg3, FoeGImg3, FoeSImg3, FoeAtk3, FoeDef3, FoeSpc3, FoeSpd3, FoeWkn3, FoeNam3, FoeDsc3,
                FoeImg4, FoeAImg4, FoeDImg4, FoeGImg4, FoeSImg4, FoeAtk4, FoeDef4, FoeSpc4, FoeSpd4, FoeWkn4, FoeNam4, FoeDsc4,
                FoeImg5, FoeAImg5, FoeDImg5, FoeGImg5, FoeSImg5, FoeAtk5, FoeDef5, FoeSpc5, FoeSpd5, FoeWkn5, FoeNam5, FoeDsc5,
                FoeImg6, FoeAImg6, FoeDImg6, FoeGImg6, FoeSImg6, FoeAtk6, FoeDef6, FoeSpc6, FoeSpd6, FoeWkn6, FoeNam6, FoeDsc6,
                FoeImg7, FoeAImg7, FoeDImg7, FoeGImg7, FoeSImg7, FoeAtk7, FoeDef7, FoeSpc7, FoeSpd7, FoeWkn7, FoeNam7, FoeDsc7,
                FoeImg8, FoeAImg8, FoeDImg8, FoeGImg8, FoeSImg8, FoeAtk8, FoeDef8, FoeSpc8, FoeSpd8, FoeWkn8, FoeNam8, FoeDsc8,
                FoeImg9, FoeAImg9, FoeDImg9, FoeGImg9, FoeSImg9, FoeAtk9, FoeDef9, FoeSpc9, FoeSpd9, FoeWkn9, FoeNam9, FoeDsc9, BestiaryImg,
                FoeImg10, FoeAImg10, FoeDImg10, FoeGImg10, FoeSImg10, FoeAtk10, FoeDef10, FoeSpc10, FoeSpd10, FoeWkn10, FoeNam10, FoeDsc10,
                FoeImg11, FoeAImg11, FoeDImg11, FoeGImg11, FoeSImg11, FoeAtk11, FoeDef11, FoeSpc11, FoeSpd11, FoeWkn11, FoeNam11, FoeDsc11,
                FoeImg12, FoeAImg12, FoeDImg12, FoeGImg12, FoeSImg12, FoeAtk12, FoeDef12, FoeSpc12, FoeSpd12, FoeWkn12, FoeNam12, FoeDsc12,
                FoeImg13, FoeAImg13, FoeDImg13, FoeGImg13, FoeSImg13, FoeAtk13, FoeDef13, FoeSpc13, FoeSpd13, FoeWkn13, FoeNam13, FoeDsc13,
                FoeImg14, FoeAImg14, FoeDImg14, FoeGImg14, FoeSImg14, FoeAtk14, FoeDef14, FoeSpc14, FoeSpd14, FoeWkn14, FoeNam14, FoeDsc14,
                FoeImg15, FoeAImg15, FoeDImg15, FoeGImg15, FoeSImg15, FoeAtk15, FoeDef15, FoeSpc15, FoeSpd15, FoeWkn15, FoeNam15, FoeDsc15,
                FoeImg16, FoeAImg16, FoeDImg16, FoeGImg16, FoeSImg16, FoeAtk16, FoeDef16, FoeSpc16, FoeSpd16, FoeWkn16, FoeNam16, FoeDsc16);
        }
        private void FastTextChange(Label[] Labs, in string[] texts)
        {
            for (byte i = 0; i < Labs.Length; i++)
                Labs[i].Content = texts[i];
        }
        private void Bestiary()
        {
            ushort cipher = MainHero.Learned;
            BitArray learned = Decoder(new BitArray(new bool[16]), cipher);
            AnyHide(Img2);
            AnyShow(BestiaryImg);
            AnyShowX2(learned, new FrameworkElement[] { FoeImg1, FoeAImg1, FoeDImg1, FoeGImg1, FoeSImg1, FoeAtk1, FoeDef1, FoeSpc1, FoeSpd1, FoeWkn1, FoeNam1, FoeDsc1 },
                new FrameworkElement[] { FoeImg2, FoeAImg2, FoeDImg2, FoeGImg2, FoeSImg2, FoeAtk2, FoeDef2, FoeSpc2, FoeSpd2, FoeWkn2, FoeNam2, FoeDsc2 },
                new FrameworkElement[] { FoeImg3, FoeAImg3, FoeDImg3, FoeGImg3, FoeSImg3, FoeAtk3, FoeDef3, FoeSpc3, FoeSpd3, FoeWkn3, FoeNam3, FoeDsc3 },
                new FrameworkElement[] { FoeImg4, FoeAImg4, FoeDImg4, FoeGImg4, FoeSImg4, FoeAtk4, FoeDef4, FoeSpc4, FoeSpd4, FoeWkn4, FoeNam4, FoeDsc4 },
                new FrameworkElement[] { FoeImg5, FoeAImg5, FoeDImg5, FoeGImg5, FoeSImg5, FoeAtk5, FoeDef5, FoeSpc5, FoeSpd5, FoeWkn5, FoeNam5, FoeDsc5 },
                new FrameworkElement[] { FoeImg6, FoeAImg6, FoeDImg6, FoeGImg6, FoeSImg6, FoeAtk6, FoeDef6, FoeSpc6, FoeSpd6, FoeWkn6, FoeNam6, FoeDsc6 },
                new FrameworkElement[] { FoeImg7, FoeAImg7, FoeDImg7, FoeGImg7, FoeSImg7, FoeAtk7, FoeDef7, FoeSpc7, FoeSpd7, FoeWkn7, FoeNam7, FoeDsc7 },
                new FrameworkElement[] { FoeImg8, FoeAImg8, FoeDImg8, FoeGImg8, FoeSImg8, FoeAtk8, FoeDef8, FoeSpc8, FoeSpd8, FoeWkn8, FoeNam8, FoeDsc8 },
                new FrameworkElement[] { FoeImg9, FoeAImg9, FoeDImg9, FoeGImg9, FoeSImg9, FoeAtk9, FoeDef9, FoeSpc9, FoeSpd9, FoeWkn9, FoeNam9, FoeDsc9 },
                new FrameworkElement[] { FoeImg10, FoeAImg10, FoeDImg10, FoeGImg10, FoeSImg10, FoeAtk10, FoeDef10, FoeSpc10, FoeSpd10, FoeWkn10, FoeNam10, FoeDsc10 },
                new FrameworkElement[] { FoeImg11, FoeAImg11, FoeDImg11, FoeGImg11, FoeSImg11, FoeAtk11, FoeDef11, FoeSpc11, FoeSpd11, FoeWkn11, FoeNam11, FoeDsc11 },
                new FrameworkElement[] { FoeImg12, FoeAImg12, FoeDImg12, FoeGImg12, FoeSImg12, FoeAtk12, FoeDef12, FoeSpc12, FoeSpd12, FoeWkn12, FoeNam12, FoeDsc12 },
                new FrameworkElement[] { FoeImg13, FoeAImg13, FoeDImg13, FoeGImg13, FoeSImg13, FoeAtk13, FoeDef13, FoeSpc13, FoeSpd13, FoeWkn13, FoeNam13, FoeDsc13 },
                new FrameworkElement[] { FoeImg14, FoeAImg14, FoeDImg14, FoeGImg14, FoeSImg14, FoeAtk14, FoeDef14, FoeSpc14, FoeSpd14, FoeWkn14, FoeNam14, FoeDsc14 },
                new FrameworkElement[] { FoeImg15, FoeAImg15, FoeDImg15, FoeGImg15, FoeSImg15, FoeAtk15, FoeDef15, FoeSpc15, FoeSpd15, FoeWkn15, FoeNam15, FoeDsc15 },
                new FrameworkElement[] { FoeImg16, FoeAImg16, FoeDImg16, FoeGImg16, FoeSImg16, FoeAtk16, FoeDef16, FoeSpc16, FoeSpd16, FoeWkn16, FoeNam16, FoeDsc16 }); ;
        }
        
        //[EN] Objects interaction
        //[RU] Взаимодействие с объектами.
        private void ChestOpen(Image Chest, in string Message, in string ChestOpened, in byte Class, in byte Quality)
        {
            AnyShow(ChestMessage1);
            ChestMessage1.Source = Bmper(Message);
            Chest.Source = Bmper(ChestOpened);
            switch (Class)
            {
                case 0: GetBag.Hands = MainHero.Weapon.Power == 0; GetBag.Weapons[Quality] = true; break;
                case 1: GetBag.Jacket = MainHero.Armor.Power == 0; GetBag.Armors[Quality] = true; break;
                case 2: GetBag.Leggings = MainHero.Legs.Power == 0; GetBag.Panties[Quality] = true; break;
                case 3: GetBag.Foots = MainHero.Boots.Power == 0; GetBag.ArmBoots[Quality] = true; break;
                default: break;
            }
            PlaySound(Paths.OST.Sounds.ChestOpened);
            AnyGrid(ChestMessage1, Bits(Bits(Chest.GetValue(Grid.RowProperty)) - 5), Bits(Bits(Chest.GetValue(Grid.ColumnProperty)) - 3));
        }

        private void GetSecretReward() {
            Exp += 250;
            Mat += 250;
            MainHero.MiniTask = true;
            ShowAfterBattleMenu();
        }

        //[EN] Menu : Player status
        //[RU] Меню : Статус игрока
        private void HeroStatus()
        {
            AnyShow(GameStatus);
            PlayerSetLocation(MainHero.Y, MainHero.X);
            FastTextChange(new Label[] { Describe1, Describe2 },
                new string[] { Txts.Hints.Status, Txts.Sections.Status });
        }
        private void StateGuy()
        {
            string image = Img2.Source.ToString();
            if (image.Contains(Paths.Static.Map.Models.Guy.GoUp1)
                || image.Contains(Paths.Static.Map.Models.Guy.GoUp2))
                Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticUp);
            else if (image.Contains(Paths.Static.Map.Models.Guy.GoLeft))
                Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticLeft);
            else if (image.Contains(Paths.Static.Map.Models.Guy.GoRight))
                Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticRight);
            else if (image.Contains(Paths.Static.Map.Models.Guy.GoDown1)
                || image.Contains(Paths.Static.Map.Models.Guy.GoDown2))
                Img2.Source = Bmper(Paths.Static.Map.Models.Guy.StaticDown);
        }
        private void CalculateBattleStatus()
        {
            StateGuy();
            if (Sets.TableEN)
                AnyHide(TableMessage1);
            speed = 0;
            Lab2.Foreground = Brushes.Yellow;
            AnyShow(BattleScene);
            AnyHideX(Threasure1, Med2, Img2, PharaohAppears, SaveProgress, JailImg1,
                JailImg2, JailImg3, JailImg5, JailImg6, JailImg7, Boulder1, Ancient,
                Warrior, FinalAppears, LockImg1, LockImg2, LockImg3, KeyImg1, KeyImg2,
                KeyImg3, ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2,
                Table3);
            AbilityBonuses[0] = 0;
            AbilityBonuses[1] = 0;
            if (AutoTurn.IsEnabled)
                BadTime();
            else
            {
                AnyShow(FightMenu);
                Time1.Value = Time1.Maximum;
            }
            if (GetStatus == 1)
                PoisonHurts();
        }

        //[EN] Battle : Usual.
        //[RU] Сражение : Обычное.
        private void RegularBattle()
        {

            Image[] images = { Img6, Img7, Img8 };
            string[] themes = { Paths.OST.Music.FoesChase,
                Paths.OST.Music.HandleThis, Paths.OST.Music.StampSmth };
            PlayMusic(themes[CurrentLocation]);
            Sets.StepsToBattle = 0;
            byte[] LEncounter = { 5, 10, 15 };
            byte[] HEncounter = { 20, 30, 40 };
            rnd = Random1.Next(LEncounter[CurrentLocation],
                HEncounter[CurrentLocation]);
            TargetImage = TrgtImg;

            Sets.Rnd1 = Random1.Next(0, 3);
            for (byte no = 0; no <= Sets.Rnd1; no++)
            {
                Sets.Rnd2 = Random1.Next(0, Sets.EnemyRate - 1);
                foes[no] = new Foe(FoesOnLocation[Sets.Rnd2]);
                foes[no].HP = foes[no].MaxHP;
                Mat += foes[no].Materials;
                Exp += foes[no].Experience;
                images[no].Source = Bmper(foes[no].Image);
                AnyShow(images[no]);
                CheckFoesTurns(no);
                if (SetFoes(FoesOnLocation[Sets.Rnd2]))
                    continue;
                RecordFoes.Add(FoesOnLocation[Sets.Rnd2].Name, 1);
            }
            EnemiesShow(RecordFoes);
            CalculateBattleStatus();
            FoesRefresh();
        }
        private bool SetFoes(Foe foe)
        {
            byte i = 0;
            foreach (KeyValuePair<string, int> entry in RecordFoes)
            {
                if (entry.Key == foe.Name)
                {
                    RecordFoes[entry.Key]++;
                    return true;
                }
                i++;
            }
            return false;
        }

        private void EnemiesTotal(in Dictionary<string, int> foesCounts)
        {
            Label[] labels = { FoesCount1, FoesCount2, FoesCount3 };
            byte i = 0;
            foreach (KeyValuePair<string, int> entry in foesCounts)
            {
                if (labels[i].Content.ToString().Contains(entry.Key))
                {
                    string content = entry.Key + ": " + entry.Value;
                    labels[i].Content = content;
                }
                i++;
            }
            FlashLabels(labels);
        }
        private void EnemiesShow(in Dictionary<string, int> foesCounts)
        {
            Label[] labels = { FoesCount1, FoesCount2, FoesCount3 };
            byte i = 0;
            foreach (KeyValuePair<string, int> entry in foesCounts)
            {
                string content = entry.Key + ": " + entry.Value;
                labels[i].Content = content;
                AnyShow(labels[i]);
                i++;
            }
        }
        private async void FlashLabels(Label[] labs)
        {
            for (byte i = 0; i < labs.Length; i++)
            {
                FlashLabel(labs[i], Brushes.Gold);
                await Task.Delay(20);
            }
        }
        private async void FlashLabel(Label lab, Brush brush)
        {
            SolidColorBrush memoryColor = lab.Foreground as SolidColorBrush;
            lab.Foreground = brush;
            await Task.Delay(20);
            lab.Foreground = memoryColor;
        }

        //[EN] Battle : Boss 1 (Pharaoh).
        //[RU] Сражение : Босс 1 (Фараон).
        private void BossBattle1()
        {
            TargetImage = BossTrgt;
            Sets.Rnd1 = 1;
            foes[0] = BossNo1;
            BossSlot1.Source = Bmper(Paths.Static.Bosses.Pharaoh);
            AnyShow(BossSlot1);
            Exp += 125;
            Mat += 250;
            PlayMusic(Paths.OST.Music.LookWhoAwake);
            CalculateBattleStatus();
            Button4.IsEnabled = false;
            CheckFoesTurns(0);
            RecordFoes.Add(BossNo1.Name, 1);
            EnemiesShow(RecordFoes);
            FoesRefresh();
        }

        //[EN] Battle : Boss 2 (????).
        //[RU] Сражение : Босс 2 (????).
        private void BossBattle2()
        {
            TargetImage = BossTrgt;
            Sets.Rnd1 = 1;
            foes[0] = BossNo2;
            BossSlot1.Source = Bmper(Paths.Static.Bosses.Warrior);
            AnyShow(BossSlot1);
            Exp += 255;
            Mat += 255;
            PlayMusic(Paths.OST.Music.SayHello);
            CalculateBattleStatus();
            CheckFoesTurns(0);
            RecordFoes.Add(BossNo2.Name, 1);
            EnemiesShow(RecordFoes);
            Button4.IsEnabled = false;
            FoesRefresh();
        }

        //[EN] Battle : Boss 3 (The Lord).
        //[RU] Сражение : Босс 3 (Владыка).
        private void BossBattle3()
        {
            TargetImage = BossTrgt;
            Sets.Rnd1 = 1;
            foes[0] = BossNo3;
            BossSlot1.Source = Bmper(Paths.Static.Bosses.MrOfAll);
            AnyShow(BossSlot1);
            Exp += 255;
            Mat += 255;
            PlayMusic(Paths.OST.Music.SeriousTalk);
            CalculateBattleStatus();
            CheckFoesTurns(0);
            RecordFoes.Add(BossNo3.Name, 1);
            EnemiesShow(RecordFoes);
            Button4.IsEnabled = false;
            FoesRefresh();
        }

        //[EN] Battle : Secret boss 1 (Ugh Zan I). + Remember true params.
        //[RU] Сражение : Секретный босс 1 (Угх Зан I). + Запоминание настоящих параметров.
        public static ushort[] RememberHPAP = { 0, 0, 0, 0 };
        public static byte[] RememberParams = { 0, 0, 0, 0 };
        private void SecretBossBattle1()
        {
            TargetImage = BossTrgt;
            AnyHideX(Button4, Items, Abilities);
            Sets.Rnd1 = 1;
            foes[0] = SBoss;
            BossSlot1.Source = Bmper(Paths.Static.Bosses.UghZan);
            AnyShow(BossSlot1);
            ShowAction(Paths.Dynamic.Person.SSwitch, Paths.Dynamic.Icon.SSwitch);
            APtext.Content = "БР";
            GetHero = Sam;
            RefreshHeroFully();
            Exp += 250;
            Mat += 500;
            PlayMusic(Paths.OST.Music.SeriousIsMe);
            CalculateBattleStatus();
            CheckFoesTurns(0);
            RecordFoes.Add(SBoss.Name, 1);
            EnemiesShow(RecordFoes);
            FoesRefresh();
        }
        private void RefreshHeroFully()
        {
            OnPropertyChanged(nameof(GetHP));
            OnPropertyChanged(nameof(GetAP));
            OnPropertyChanged(nameof(GetMHP));
            OnPropertyChanged(nameof(GetMAP));
            OnPropertyChanged(nameof(GetATK));
            OnPropertyChanged(nameof(GetDEF));
            OnPropertyChanged(nameof(GetAGL));
            OnPropertyChanged(nameof(GetSPL));
        }
        private void Med2_MediaEnded(object sender, RoutedEventArgs e)
        {
            AnyHide(Med2);
            switch (Sets.SpecialBattle)
            {
                case 0: RegularBattle(); SpeedUp(); break;
                case 1: BossBattle1(); SpeedUp(); break;
                case 2: BossBattle2(); SpeedUp(); break;
                case 3: BossBattle3(); SpeedUp(); break;
                case 200: SecretBossBattle1(); SpeedUp(); break;
                default: Close(); break;
            }
        }

        //[EN] Battle : Person attack.
        //[RU] Сражение : Атака героя.
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(FightMenu);
            AnyShow(SelectMenuFight);
            SelectTarget();
        }
        
        //[EN] Target select mech
        //[RU] Механика выбора цели.
        private void NormalTarget()
        {
            AnyGrid(TargetImage, 1 - Sets.SelectedTarget % 2,
                Sets.SelectedTarget);
        }
        private void BossTarget()
        {
            AnyGrid(TargetImage, 0, Sets.SelectedTarget);
        }
        private void MouseSelect(object sender, MouseButtonEventArgs e)
        {
            if (TargetImage == null || !TargetImage.IsEnabled)
                return;
            Image image = sender as Image;
            Sets.SelectedTarget = Bits(image.Tag);
            InfoAboutEnemies();
        }
        private void SelectKeyLeft()
        {
            if (Sets.SelectedTarget <= 0)
                return;

            sbyte optimization = SBits(Math.Max(0, Sets.SelectedTarget - 1));
            for (sbyte i = optimization; i >= 0; i--)
            {
                if (foes[i].HP > DeadFoe.HP)
                {
                    Sets.SelectedTarget = Bits(i);
                    break;
                }
            }
            InfoAboutEnemies();
        }
        private void SelectKeyRight()
        {
            if (Sets.SelectedTarget >= Sets.Rnd1)
                return;

            byte optimization = Bits(Math.Min(2, Sets.SelectedTarget + 1));
            for (byte i = optimization; i <= Sets.Rnd1; i++)
                if (foes[i].HP > DeadFoe.HP)
                {
                    Sets.SelectedTarget = i;
                    break;
                }
            InfoAboutEnemies();
        }
        private byte ReSelect()
        {
            for (byte i = 0; i <= Sets.Rnd1; i++)
                if (foes[i].HP > DeadFoe.HP)
                {
                    byte[,] grRowColumn = new byte[,] { { 1, 0, 1 }, { 0, 1, 2 } };
                    AnyGrid(TargetImage, grRowColumn[0, i], grRowColumn[1, i]);
                    return i;
                }
            return 0;
        }

        //[EN] Info about enemies
        //[RU] Информация по врагам.
        private void InfoAboutEnemies()
        {
            ReCheck();
            if (Sets.SpecialBattle == 0)
                NormalTarget();
            else
                BossTarget();
        }
        private void ReCheck()
        {
            Image[] images = { EnemyImg, EnemyImg2, EnemyImg3 };
            ProgressBar[] bars = { HPenemyBar, HPenemyBar2, HPenemyBar3 };
            Label[] names = { Enemy, Enemy2, Enemy3 };
            Label[] hps = { HPenemy, HPenemy2, HPenemy3 };
            AnyHideX(images, bars, names, hps);
            AnyShowX(names[Sets.SelectedTarget], images[Sets.SelectedTarget],
                bars[Sets.SelectedTarget], hps[Sets.SelectedTarget]);
        }
        public void SelectTarget()
        {
            AnyShowX(TargetImage, EnemyStatus);
            InfoAboutEnemies();
            TimerOn(ref Targt);
        }

        //[EN] Battle : After action.
        //[RU] Сражение : Последействие.
        private void AfterAction()
        {
            HP.Foreground = Brushes.White;
            AnyHideX(BattleText1, BattleText2);
            if (speed > 0)
            {
                Sound1.Stop();
                SpeedDown();
                if (PRegn.IsEnabled)
                    TimerOff(ref PRegn);
                if (PCtrl.IsEnabled)
                    TimerOff(ref PCtrl);
                
                Exp = 0;
                Mat = 0;
                speed = 0;
                AnyHide(BattleScene);
                AnyHideX(BattleText2, Img6, Img7, Img8, FoesCount1, FoesCount2, FoesCount3,
                    BattleText6, BuffsUpImg, BuffUpTxt, ToughUpImg, ToughUpTxt);
                AnyShowX(Img1, Img2, Threasure1, SaveProgress);
                CheckMapX(new byte[] { 104, 105, 105, 106, 107, 108 },
                    new Image[] { JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });
                
                AnyShowX(ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3);
                if (CurrentLocation == 0)
                    switch (Sets.LockIndex)
                    {
                        case 0: break;
                        case 1: AnyShowX(KeyImg3, LockImg3); break;
                        case 2: AnyShowX(KeyImg2, LockImg2, KeyImg3, LockImg3); break;
                        default: AnyShowX(KeyImg1, KeyImg2, KeyImg3, LockImg1,
                            LockImg2, LockImg3); break;
                    }
                else if (CurrentLocation == 1)
                    AnyShowX(SecretChestImg1, SecretChestImg2);
                if (CheckMap(7))
                    AnyShow(Boulder1);
                Sets.Rnd1 = 0;
                Sets.SelectedTarget = 0;
                string[] music = new string[] { Paths.OST.Music.AncientPyramid,
                    Paths.OST.Music.WaterTemple, Paths.OST.Music.LavaTemple };
                PlayMusic(music[CurrentLocation]);
                for (byte i = 0; i < foes.Length; i++)
                    foes[i] = DeadFoe;
                RecordFoes.Clear();
            }
            else if (foes[0].HP <= 0 && foes[1].HP <= 0 && foes[2].HP <= 0)
            {
                Sound1.Stop();
                SpeedDown();
                if (PRegn.IsEnabled)
                    TimerOff(ref PRegn);
                if (PCtrl.IsEnabled)
                    TimerOff(ref PCtrl);
                
                PlaySound(Paths.OST.Sounds.NowTheWinnerIs);
                Sets.Rnd1 = 0;
                Sets.SelectedTarget = 0;
                AnyShowX(BattleText1, textOk2, WonTxt);
                RecordFoes.Clear();
            }
            else if (GetHP > 0)
            {
                Time1.Value = 0;
                TimerOn(ref PTurn);
                AnyHideX(BattleText1, BattleText2);
            }
        }

        //[EN] Battle : Person defence.
        //[RU] Сражение : Защита героя.
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Ray.DefenseState = 2;
            AnyHide(FightMenu);
            HP.Foreground = Brushes.White;
            Lab2.Foreground = Brushes.White;
            if (Sets.SpecialBattle == 200)
            {
                GetHP = Shrt(Math.Min(GetHP + 40, GetMHP));
                GetAP = Shrt(Math.Min(GetAP + 40, GetMAP));
                ushort cipher = MainHero.Learned;
                BitArray learned = Decoder(new BitArray(new bool[16]), cipher);
                if (!learned[15])
                {
                    MainHero.Learned += ALearn.Learn(15);
                    PlayNoise(ALearn.Noise);
                }
                else
                    PlayNoise(Paths.OST.Noises.StrongStand);
            }
            else
            {
                FastImgChange(BmpersToX(Paths.Static.Person.Defensive, Paths.Static.Icon.Defensive), Img4, Img5);
                PlayNoise(Paths.OST.Noises.StrongStand);
            }
            
            AfterAction();
        }

        //[EN] Player and GetFoes timing.
        //[RU] Соблюдение времени игроком и врагами.
        public ushort TimeFormula => Shrt((305 - GetAGL) / GameSpeed.Value);
        private void Time()
        {
            MainHero.DefenseState = 1;
            Img5.Source = Bmper(MainHero.Icon);
            Lab2.Foreground = Brushes.Yellow;
            if (AutoTurn.IsEnabled && !FoesFighting())
                BadTime();
            else
                AnyShow(FightMenu);
        }
        
        private ushort TimeFoeFormula(in byte speed) => Shrt(10000 - speed * 20);
        private async void FoeTurns(byte foeNo)
        {
            ushort PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
            ushort turn = TimeFoeFormula(foes[foeNo].Speed);
            await Task.Delay(turn);
            while (GetHP > 0 && foes[foeNo].HP > 0 && PlayerDef < foes[foeNo].Attack && !Pause.IsEnabled)
            {
                PlayerDef = Shrt(GetDEF + (GetSPL * GetAGL * 0.005));
                ushort dmg = Shrt(foes[foeNo].Attack - PlayerDef);
                EnemyOnAttack(dmg);
                await FoesShowDown(foeNo, Shrt(50 / GameSpeed.Value));
                AnyHide(BattleText6);
                await Task.Delay(turn);
            }
        }
        private async void PoisonFoeTurns(byte foeNo)
        {
            ushort PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
            ushort turn = TimeFoeFormula(foes[foeNo].Speed);
            await Task.Delay(turn);
            while (GetHP > 0 && foes[foeNo].HP > 0 && PlayerDef < foes[foeNo].Attack && !Pause.IsEnabled)
            {
                PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
                ushort dmg = Shrt(foes[foeNo].Attack - PlayerDef);
                if (Random1.Next(1, 13) == 7)
                    GetStatus = 1;
                EnemyOnAttack(dmg);
                await FoesShowDown(foeNo, Shrt(50 / GameSpeed.Value));
                AnyHide(BattleText6);
                await Task.Delay(turn);
            }
        }
        private async void BossTurns(byte foeNo)
        {
            ushort PlayerDef = Shrt(GetDEF + GetSPL * GetAGL * 0.005);
            ushort turn = TimeFoeFormula(foes[foeNo].Speed);
            await Task.Delay(turn);
            while (GetHP > 0 && foes[foeNo].HP > 0 && PlayerDef < foes[foeNo].Attack && !Pause.IsEnabled)
            {
                PlayerDef = Shrt(GetDEF + (GetSPL * GetAGL * 0.005));
                ushort dmg = Shrt(foes[foeNo].Attack - PlayerDef);
                EnemyOnAttack(dmg);
                await BossShowDown(foeNo, Shrt(50 / GameSpeed.Value));
                AnyHide(BattleText6);
                await Task.Delay(turn);
            }
        }
        private void CheckFoesTurns(byte foeNo)
        {
            if (Sets.SpecialBattle != 0)
                BossTurns(foeNo);
            else if ((foes[foeNo].No == 0) || (foes[foeNo].No == 8))
                PoisonFoeTurns(foeNo);
            else
                FoeTurns(foeNo);
        }
        private void EnemyOnAttack(in ushort dmg)
        {
            if (Sets.SpecialBattle != 200)
                GetHP = Shrt(Math.Max(GetHP - dmg, 0));
            else
            {
                GetHP = Shrt(Math.Max(Math.Min(GetHP - dmg +
                    Math.Min(Shrt(10), GetAP), GetHP), 0));
                GetAP = Shrt(Math.Max(GetAP - 10, 0));
            }
            BattleText6.Content = "-" + dmg;
            AnyShow(BattleText6);
            if (Sets.SpecialBattle == 200)
                return;
            if (Img4.Source.ToString().Contains(Paths.Static.Person.Usual))
                ShowAction(Paths.Dynamic.Person.Hurt);
            //FlashLabel(BattleText6, Brushes.Red);
        }

        private async Task BossShowDown(byte no, ushort time)
        {
            string[] enemyAnimate = foes[no].Animate;
            string ememyImg = foes[no].Image;
            for (byte i = 0; i < enemyAnimate.Length; i++)
            {
                Trace.WriteLine(enemyAnimate[i]);
                BossSlot1.Source = Bmper(enemyAnimate[i]);
                await Task.Delay(time);
            }
            BossSlot1.Source = Bmper(ememyImg);
        }

        private async Task FoesShowDown(byte no, ushort time)
        {
            string[] enemyAnimate = foes[no].Animate;
            string ememyImg = foes[no].Image;
            Image[] enemiesImg = { Img6, Img7, Img8 };
            for (byte i = 0; i < enemyAnimate.Length; i++)
            {
                enemiesImg[no].Source = Bmper(enemyAnimate[i]);
                await Task.Delay(time);
            }
            enemiesImg[no].Source = Bmper(ememyImg);
        }
        private void Skip1_Click(object sender, RoutedEventArgs e) {
            AnyHide(Skip1);
            MediaElement[] media = { Med1, TheEnd };
            for (byte i = 0; i < media.Length; i++)
                if (media[i].IsEnabled)
                {
                    media[i].Stop();
                    media[i].RaiseEvent(new RoutedEventArgs(MediaElement.MediaEndedEvent));
                    break;
                }
        }
        private void Sound1_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound1.Stop();
            Sound1.Position = TimeSpan.Zero;
            Sound1.Play();
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(FightMenu);
            byte fagl = Math.Max(GetFoe3.Speed, Math.Max(GetFoe1.Speed, GetFoe2.Speed));
            Lab2.Foreground = Brushes.White;
            if (GetAGL > fagl)
                speed = 1;
            ShowAction(Paths.Dynamic.Person.Escape, Paths.Dynamic.Icon.Escape);
            PlayNoise(Paths.OST.Noises.FleeAway);
            AnyHide(BattleText2);
            WaitForEnd(Shrt(500 / GameSpeed.Value));
        }
        private async void WaitForEnd(ushort time)
        {
            await Task.Delay(time);
            AfterAction();
        }
        
        private void FoesRefresh()
        {
            OnPropertyChanged(nameof(GetFoe1));
            OnPropertyChanged(nameof(GetFoe2));
            OnPropertyChanged(nameof(GetFoe3));
        }
        private void BadTime()
        {
            int strength = GetATK + (GetATK * GetAGL / 100);
            ushort EnemyDefence = foes[Sets.SelectedTarget].Defence;
            ushort total = Shrt(Math.Max(strength - EnemyDefence, 0));
            AnyHideX(SelectMenuFight, TargetImage);
            Lab2.Foreground = Brushes.White;
            FoesKickedOne(Sets.SelectedTarget, total, Shrt(500 / GameSpeed.Value));
            PhysicalAttack(MainHero.Weapon);
            FoesRefresh();
        }
        //[EN] Battle : Person attack, calculate.
        //[RU] Сражение : Атака героя, подсчёт.
        private void Fight_Click(object sender, RoutedEventArgs e)
        {
            TimerOff(ref Targt);
            BadTime();
        }
        private async void ShowAndHide(Label label, string content, ushort time)
        {
            label.Content = content;
            AnyShow(label);
            await Task.Delay(time);
            AnyHide(label);
        }
        
        private void UnlimitedActionsTickCheck(in string[] spec)
        {
            TargetImage.Source = Bmper(spec[trgt]);
            trgt = Bits(trgt >= spec.Length - 1 ? 0 : trgt + 1);
        }
        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            if (Targt.IsEnabled)
                TimerOff(ref Targt);
            AnyHideX(EnemyStatus, SelectMenuFight, TargetImage);
            AnyShow(FightMenu);
        }
        private void Win_MediaEnded(object sender, RoutedEventArgs e)
        {
            WinStop();
            AnyHide(NewLevelGet);
        }
        private void WinStop()
        {
            WonOrDied();
            CheckMapX(new byte[] { 104, 105, 105, 106, 107, 108 }, new Image[] {
                JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });
            if (CurrentLocation < 3)
                AnyShowX(ChestImg1, ChestImg2, ChestImg3,
                    ChestImg4, Table1, Table2, Table3);
            if (CurrentLocation == 0)
                Map1EnableModels();
            if (CheckMap(7))
                AnyShow(Boulder1);
            AnyShowX(Threasure1, Img2, Img1, SaveProgress);
            AnyHide(Win);
            Win.Position = TimeSpan.Zero;
            string[] music = new string[] { Paths.OST.Music.AncientPyramid,
                Paths.OST.Music.WaterTemple, Paths.OST.Music.LavaTemple };
            PlayMusic(music[CurrentLocation]);
        }
        private void Map1EnableModels()
        {
            switch (Sets.LockIndex)
            {
                case 0: break;
                case 1: AnyShowX(new Image[] { KeyImg3, LockImg3 }); break;
                case 2: AnyShowX(new Image[] { KeyImg2,
                    LockImg2, KeyImg3, LockImg3 }); break;
                default: AnyShowX(new Image[] { KeyImg1, KeyImg2, KeyImg3,
                    LockImg1, LockImg2, LockImg3 }); break;
            }
        }
        private void Sounds_Ended(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Stop();
        }
        private void Win_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            WonOrDied();
            Win.Stop();
            AnyShow(Img2);
        }
        private void TextOk1_Click(object sender, RoutedEventArgs e)
        {
            HeroSetStatus(MainHero.PlayerStatus);
            TargetImage = TrgtImg;
            string[] win = new string[] { Paths.CutScenes.Victory,
                Paths.CutScenes.WasteTime, Paths.CutScenes.PowerRanger };
            Win.Source = Ura(win[CurrentLocation]);
            MaterialsAdd.Content = "";
            Mat = 0;
            if (Sets.SpecialBattle == 0)
            {
                AnyShow(Win);
                AnyHideX(BattleText1, BattleText2, Img1);
            }
            else
            {
                AnyHideX(BattleText1, BattleText2);
                switch (Sets.SpecialBattle)
                {
                    case 1:
                    case 2:
                    case 3:
                        Sound1.Stop();
                        AnyShow(TheEnd);
                        AnyShow(Skip1);
                        Img1.Source = Bmper(Paths.Static.Map.Normal);
                        break;
                    default:
                        AnyShow(Win);
                        string[] music = new string[] { Paths.OST.Music.AncientPyramid,
                            Paths.OST.Music.WaterTemple, Paths.OST.Music.LavaTemple };
                        PlayMusic(music[CurrentLocation]);
                        break;
                }
                Sets.SpecialBattle = 0;
            }
            AnyHideX(NewLevelGet, FightResults);
            AnyShow(Img1);
        }
        private void WonOrDied()
        {
            Sound1.Stop();
            AnyHideX(BattleText1, BattleText2, Img6, Img7, Img8,
                TextOk1, FightMenu, textOk2, WonTxt, BattleScene,
                BuffsUpImg, BuffUpTxt, ToughUpImg, ToughUpTxt);
        }
        private void FightStaticButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            BattleText2.Content = b.Tag.ToString();
            AnyShow(BattleText2);
        }
        private void FightStaticButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            AnyHide(BattleText2);
        }
        private void FightDynamicButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            Button fightButton = sender as Button;
            Image img = fightButton.Content as Image;
            img.Source = Bmper(MiscText.GetPath(img));
            AnyHide(BattleText2);
        }
        private void FightDynamicButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button fightButton = sender as Button;
            Image img = fightButton.Content as Image;
            img.Source = Bmper(img.Tag.ToString());
            BattleText2.Content = fightButton.Tag.ToString();
            AnyShow(BattleText2);
        }
        private void SelectDynamicButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Image img = btn.Content as Image;
            img.Source = Bmper(Paths.Static.BtnImgs.After.Select);
            BattleText2.Content = SkillInfo.GetDescription(btn);
            AnyShow(BattleText2);
        }
        private void SelectDynamicButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Image img = btn.Content as Image;
            img.Source = Bmper(Paths.Static.BtnImgs.Before.Select);
            AnyHide(BattleText2);
        }
        private void GameOver_MediaEnded(object sender, RoutedEventArgs e)
        {
            Reload.Reloading();
            Form1.Close();
        }
        public static byte[] AbilityBonuses = new byte[] { 0, 0, 0, 0 };
        private void Back1_Click(object sender, RoutedEventArgs e) {
            AnyHide(SkillsMenu);
            AnyShow(FightMenu);
            Button4.IsEnabled = Sets.SpecialBattle == 0;
        }
        private void MedicineSkill_Click(object sender, RoutedEventArgs e)
        {
            Lab2.Foreground = Brushes.White;
            ushort time = Shrt(1000 / GameSpeed.Value);
            MedicineSkills skill = (sender as Button).Tag as MedicineSkills;
            MedicineCure(skill);
            ShowAction(skill.Animation, skill.IconAnimate);
            PlayNoise(skill.Noise);
            ShowAndHide(CureHealTxt, "+" + skill.Cure(), time);
            AnyHide(SkillsMenu);
            WaitForEnd(time);
        }
        private void MedicineCure(MedicineSkills skill)
        {
            GetHP = Shrt(Math.Min(GetMHP, GetHP + skill.Cure()));
            GetAP -= skill.Cost;
        }
        private void Abilities_Click(object sender, RoutedEventArgs e)
        {
            AnyShow(SkillsMenu);
            FastEnableDisableBtn(new bool[] { AbilityBonuses[0] <= 0,
                AbilityBonuses[1] <= 0 }, BuffUp, ToughenUp);
            AnyHide(FightMenu);
        }

        public static byte LevelUpCount = 1;
        private void textOk2_Click(object sender, RoutedEventArgs e)
        {
            SpeedDown();
            ItemsGetSlot1.Content = "";
            if (Sets.SpecialBattle == 200)
            {
                APtext.Content = "ОД";
                GetHero = Ray;
                RefreshHeroFully();
                Sets.SpecialBattle = 0;
                FastImgChange(BmpersToX(MainHero.Image, MainHero.Icon), Img4, Img5);
                GetBag.Armors[3] = true;
                GetBag.Jacket = MainHero.Armor.Power == 0;
                ItemsGetSlot1.Content += $"{Txts.Equipment.Torso.Serious}\n";
                Ray.MiniTask = true;
                Button4.IsEnabled = true;
                AnyShowX(Button4, Items, Abilities);
                AnyShow(ItemsGetSlot1);
            }
            AnyHideX(BattleScene, BattleText1, BattleText2,
                BattleText6, textOk2, WonTxt);
            ShowAfterBattleMenu();
            WonOrDied();
        }
        
        private void ShowAfterBattleMenu()
        {
            LevelUpCount = 1;
            MaterialsAdd.Content = "+" + Mat;
            ItemsGetSlot1.Content = "";
            AnyShow(FightResults);
            LevelUps();
            MaterialsAnimation();
            for (byte no = 0; no < 8; no++)
                NewItems(no);
        }
        private void NewItems(in byte no)
        {
            byte item = 0;
            while (Sets.ItemsDropRate[no] > 0)
            {
                item = Bits(Random1.Next(0, 8) == 4 ? item + 1 : item);
                Sets.ItemsDropRate[no]--;
            }
            if (item <= 0)
                return;
            string[] ItemNamesEn = { "Antidote", "Bandage", "Ether",
                "Fused", "Herbs", "SleepBag", "Ether2", "Elixir" };
            string[] ItemNamesRu = { "Антидот", "Бинт", "Эфир", "Смесь",
                "Целебные травы", "Спальный мешок", "Бутыль эфира", "Эликсир" };
            byte value = Bits(GetBag.GetType().
                GetProperty(ItemNamesEn[no]).GetType().GetProperty("Count"));
            ItemsGetSlot1.Content += ItemNamesRu[no] + ": " + item + "\n";
            GetBag.GetType().GetProperty(ItemNamesEn[no]).
                SetValue("Count", Bits(Math.Min(value + item, 255)));
        }

        private async void MaterialsAnimation()
        {
            for (int digit = 1; (Mat > 0) && (GetMaterials +
                Math.Min(Mat, digit) < 65535); digit *= 2)
            {
                await Task.Delay(50);
                ushort materials = Shrt(Math.Min(Mat, digit));
                GetMaterials += materials;
                Mat -= materials;
                MaterialsAdd.Content = $"+{Mat}";
            }
        }
        private async Task LevelUp(ushort exp)
        {
            while (GetExp + exp >= GetNlvl && GetLV < 25)
            {
                exp = Shrt(GetExp + exp - GetNlvl);
                GetLV = Bits(Math.Min(GetLV + 1, 25));
                GetExp = 0;
                NewLevelGet.Content = Txts.Common.NewLv;
                if (LevelUpCount > 1)
                    NewLevelGet.Content += " X" + LevelUpCount;
                LevelUpCount += 1;
                AnyShow(NewLevelGet);
                AfterIcon.Source = Bmper(Paths.Static.Icon.LevelUp);
                PlayNoise(Paths.OST.Noises.LevelUp);
                OnPropertyChanged(nameof(GetNlvl));
                await Task.Delay(500);
                AfterIcon.Source = Bmper(Paths.Static.Icon.Usual);
                await Task.Delay(125);
            }
            GetExp += exp;
            Exp -= exp;
            await Task.Delay(50);
        }
        private async void LevelUps()
        {
            for (int digit = 1; (Exp > 0) && (GetLV < 25) &&
                (GetExp + Math.Min(Exp, digit) < 65535); digit *= 2)
            {
                ushort exp = Shrt(Math.Min(Exp, digit));
                await LevelUp(exp);
            }
            LevelUpCount = 1;
            AnyShow(TextOk1);
        }

        private void Cancel2_Click(object sender, RoutedEventArgs e)
        {
            if (Targt.IsEnabled)
                TimerOff(ref Targt);
            AnyHideX(EnemyStatus, TargetImage, SelectMenuSkills, ACT1, ACT2, ACT3, ACT4);
            AnyShow(SkillsMenu);
        }
        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            Lab2.Foreground = Brushes.White;
            HeroSetStatus(AHeal.HealStatus());
            AfterStatus.Content = StatusP.Content = Txts.Common.Hlthy + " ♫";
            GetAP -= AHeal.Cost;
            AnyHide(SkillsMenu);
            ShowAction(Paths.Dynamic.Person.Heal, Paths.Dynamic.Icon.Heal);
            ShowAndHide(CureHealTxt, "-Яд", Shrt(1000 / GameSpeed.Value));
            PlayNoise(Paths.OST.Noises.Heal);
            WaitForEnd(Shrt(500 / GameSpeed.Value));
        }
        private void SelectSkill_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button).Tag as Button;
            SelectTarget();
            AnyHide(SkillsMenu);
            AnyShowX(SelectMenuSkills, btn);
        }
        private void SuperCheckFoes(in byte seltrg)
        {
            PlaySound(foes[seltrg].Death);
            Image[] images = { Img6, Img7, Img8 };
            string name = foes[seltrg].Name;
            RecordFoes[name]--;
            int count = RecordFoes[name];
            if (count <= 0)
            {
                _ = RecordFoes.Remove(name);
                AnyHide(HideCheck(name));
            }
            if (Sets.SpecialBattle == 0)
                AnyHide(images[seltrg]);
            else
                AnyHide(BossSlot1);
            foes[seltrg] = DeadFoe;
            FoesRefresh();
            Sets.SelectedTarget = ReSelect();
            EnemiesTotal(RecordFoes);
        }
        private Label HideCheck(string name)
        {
            Label[] labels = { FoesCount1, FoesCount2, FoesCount3 };
            for (byte i = 0; i < labels.Length; i++)
            {
                if (labels[i].Content.ToString().Contains(name))
                    return labels[i];
            }
            return labels[2];
        }
        private void AbilitySupers()
        {
            AnyHideX(TargetImage, SelectMenuSkills, SkillsMenu);
            Lab2.Foreground = Brushes.White;
            Sets.SelectedTarget = ReSelect();
            Time1.Value = 0;
        }
        private void Items_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(FightMenu);
            AnyShow(ItemsMenu);
            PlayNoise(Paths.OST.Noises.BagOpen);
        }
        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(ItemsMenu);
            AnyShow(FightMenu);
            PlayNoise(Paths.OST.Noises.BagClose);
        }
        private void Status_Click(object sender, RoutedEventArgs e)
        {
            HideMenuSections();
            AnyShow(GameMenuSelect);
            HeroStatus();
        }
        private void HeroAbilities()
        {
            AnyShow(GameMenuSelect);
            AnyShowX(GameSkills);
        }
        private void Abils_Click(object sender, RoutedEventArgs e)
        {
            HideMenuSections();
            HeroAbilities();
            FastTextChange(new Label[] { Describe1, Describe2 },
                new string[] { Txts.Hints.Skills, Txts.Sections.Skills });
            AnyShowX(Describe2, DescribeHeader, Describe1);
        }
        private void HeroItems()
        {
            AnyShow(GameMenuSelect);
            CraftSwitchLab.Content = "Создание";
            FastTextChange(new Label[] { Describe1, Describe2 },
                new string[] { Txts.Hints.Items, Txts.Sections.Items });
            AnyShow(GameItems);
        }
        private void Items0_Click(object sender, RoutedEventArgs e)
        {
            HideMenuSections();
            HeroItems();
        }
        private void CountHide(object sender, MouseEventArgs e)
        {
            AnyHide(CountText);
        }
        private void HeroEquip()
        {
            AnyShow(GameMenuSelect);
            AnyShowX(GameEquip);
            FastEnableDisableBtn(false, Remove1, Remove2, Remove3,
                Remove4, Equip1, Equip2, Equip3, Equip4);
            FastTextChange(new Label[] { Describe1, Describe2 },
                new string[] { Txts.Hints.Equip, Txts.Sections.Equip });
        }
        
        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            HideMenuSections();
            HeroEquip();
            EquipWatch();
        }
        private void EquipWatch()
        {
            FastEnableDisableBtn(new bool[] {
                GetBag.Hands && (GetHero.Weapon.Power == 0),
                GetBag.Jacket && (GetHero.Armor.Power == 0),
                GetBag.Leggings && (GetHero.Legs.Power == 0),
                GetBag.Foots && (GetHero.Boots.Power == 0),
                !GetBag.Hands && (GetHero.Weapon.Power != 0),
                !GetBag.Jacket && (GetHero.Armor.Power != 0),
                !GetBag.Leggings && (GetHero.Legs.Power != 0),
                !GetBag.Foots && (GetHero.Boots.Power != 0) },
                Equip1, Equip2, Equip3, Equip4, Remove1,
                Remove2, Remove3, Remove4);
        }
        private void OnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            Equipment equipment = btn.Tag as Equipment;
            Equipment bare = EquipInfo.GetEquip(btn);
            if (equipment.Name == GetHero.Weapon.Name)
                GetHero.Weapon = (Equipment.Weapon)bare;
            else if (equipment.Name == GetHero.Armor.Name)
                GetHero.Armor = (Equipment.Armor)bare;
            else if (equipment.Name == GetHero.Legs.Name)
                GetHero.Legs = (Equipment.Armor)bare;
            else
                GetHero.Boots = (Equipment.Armor)bare;
            GetBag.ReEquip(bare.Name, true);
            OnPropertyChanged(nameof(GetBag));
            OnPropertyChanged(nameof(GetHero));
            OnPropertyChanged(nameof(GetATK));
            OnPropertyChanged(nameof(GetDEF));
            EquipWatch();
        }
        private void OnEquip_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            BitmapImage[][] bitmapImages = {
                BmpersToX(Paths.Static.BtnImgs.Usual.Knucleduster,
                Paths.Static.BtnImgs.Usual.AncientKnife,
                Paths.Static.BtnImgs.Usual.LegendSword,
                Paths.Static.BtnImgs.Usual.SeriousMinigun),
                BmpersToX(Paths.Static.BtnImgs.Usual.LeatherArmor,
                Paths.Static.BtnImgs.Usual.AncientArmor,
                Paths.Static.BtnImgs.Usual.LegendArmor,
                Paths.Static.BtnImgs.Usual.SeriousTshirt),
                BmpersToX(Paths.Static.BtnImgs.Usual.FeatherWears,
                Paths.Static.BtnImgs.Usual.AncientPants,
                Paths.Static.BtnImgs.Usual.LegendPants,
                Paths.Static.BtnImgs.Usual.SeriousPants),
                BmpersToX(Paths.Static.BtnImgs.Usual.BandageBoots,
                Paths.Static.BtnImgs.Usual.StrongBoots,
                Paths.Static.BtnImgs.Usual.LegendBoots,
                Paths.Static.BtnImgs.Usual.SeriousBoots)
            };
            Equipment[][] equipment = {
                new Equipment.Weapon[] { Knuckle, Knife, Sword, Minigun },
                new Equipment.Armor[] { BlackCoat, AncientArmor,
                    LegendArmor, CoolTShirt },
                new Equipment.Armor[] { FeatherPants, WarriorPants,
                    LegendPants, SeriousPants },
                new Equipment.Armor[] { BandageBoots, ManBoots,
                    LegendBoots, SeriousBoots }
            };
            Equipment[] BareEq = { BareHands, Shirt, Pants, CleanBoots };
            Button[] EqButtons = { Equipments, Equipments2,
                Equipments3, Equipments4 };
            BitArray[] SomeEquipHave = { GetBag.Weapons, GetBag.Armors,
                GetBag.Panties, GetBag.ArmBoots };
            Sets.EquipmentClass = Bits(btn.Tag);
            for (int i = 0; i < SomeEquipHave[Sets.EquipmentClass].Length; i++)
                if (SomeEquipHave[Sets.EquipmentClass][i])
                {
                    AnyShow(EqButtons[i]);
                    EqButtons[i].Tag = equipment[Sets.EquipmentClass][i];
                    EquipInfo.SetEquip(EqButtons[i], BareEq[Sets.EquipmentClass]);
                }
            FastImgChange(bitmapImages[Sets.EquipmentClass], EquipmentsImg,
                Equipments2Img, Equipments3Img, Equipments4Img);
            AnyShow(CancelEq);
        }
        private void CancelEq_Click(object sender, RoutedEventArgs e)
        {
            AnyHideX(Equipments, Equipments2, Equipments3, Equipments4, CancelEq);
        }
        private void ShowSomeTasks(Label[] labs, Image[] imgs,
            in string[] texts, in string[] bmps)
        {
            AnyShowX(labs);
            AnyShowX(imgs);
            FastTextChange(labs, texts);
            FastImgChange(BmpersToX(bmps), imgs);
        }
        private void ShowSomeTasks(Label labs, Image imgs,
            in string texts, in string bmps)
        {
            AnyShowX(labs, imgs);
            labs.Content = texts;
            imgs.Source = Bmper(bmps);
        }
        private void RealTasks()
        {
            string[] TasksText = { Txts.Goals.T1, Txts.Goals.T2, Txts.Goals.T3,
                Txts.Goals.T4, Txts.Goals.T5, Txts.Goals.T6, Txts.Goals.T7,
                Txts.Goals.T8, Txts.Goals.T9, Txts.Goals.T10 };
            string[] uriSources = new string[] { Paths.Static.Menu.MTasks.UsualTask,
                Paths.Static.Menu.MTasks.Completed };
            switch (Ray.MenuTask)
            {
                case 0: ShowSomeTasks(Task1, Task1Img, TasksText[0], uriSources[0]);
                    break;
                case 1:
                    ShowSomeTasks(new Label[] { Task1, Task2 },
                        new Image[] { Task1Img, Task2Img },
                        new string[] { TasksText[0], TasksText[1] },
                        new string[] { uriSources[1], uriSources[0] });
                    break;
                case 2:
                    ShowSomeTasks(new Label[] { Task1, Task2, Task3 },
                        new Image[] { Task1Img, Task2Img, Task3Img },
                        new string[] { TasksText[0], TasksText[1], TasksText[2] },
                        new string[] { uriSources[1], uriSources[1], uriSources[0] });
                    break;
                case 3:
                    ShowSomeTasks(new Label[] { Task1, Task2, Task3, Task4 },
                        new Image[] { Task1Img, Task2Img, Task3Img, Task4Img },
                        new string[] { TasksText[0], TasksText[1],
                            TasksText[2], TasksText[3] },
                        new string[] { uriSources[1], uriSources[1],
                            uriSources[1], uriSources[0] });
                    break;
                case 4: ShowSomeTasks(Task1, Task1Img, TasksText[4], uriSources[0]);
                    break;
                case 5:
                    ShowSomeTasks(new Label[] { Task1, Task2 },
                        new Image[] { Task1Img, Task2Img },
                        new string[] { TasksText[4], TasksText[5] },
                        new string[] { uriSources[1], uriSources[0] });
                    break;
                case 6:
                    ShowSomeTasks(new Label[] { Task1, Task2, Task3 },
                        new Image[] { Task1Img, Task2Img, Task3Img },
                        new string[] { TasksText[4], TasksText[5], TasksText[6] },
                        new string[] { uriSources[1], uriSources[1], uriSources[0] });
                    break;
                case 7:
                    ShowSomeTasks(Task1, Task1Img, TasksText[7], uriSources[0]);
                    break;
                case 8:
                    ShowSomeTasks(new Label[] { Task1, Task2 },
                        new Image[] { Task1Img, Task2Img },
                        new string[] { TasksText[7], TasksText[8] },
                        new string[] { uriSources[1], uriSources[0] });
                    break;
                default: ShowSomeTasks(Task1, Task1Img, TasksText[9], uriSources[0]);
                    break;
            }
        }
        private void MiniTasks()
        {
            string[] TasksText = { Txts.Goals.E1, Txts.Goals.E2, Txts.Goals.E3 };
            string[] uriSources = new string[] {
                Paths.Static.Menu.MTasks.ExperTask,
                Paths.Static.Menu.MTasks.Completed };
            if (CurrentLocation < 3)
                ShowSomeTasks(Task5, Task5Img, TasksText[CurrentLocation],
                    uriSources[Ray.MiniTask ? 1 : 0]);
        }
        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            HideMenuSections();
            AnyShow(GameTasks);
            AnyShow(GameMenuSelect);
            RealTasks();
            MiniTasks();
            FastTextChange(new Label[] { Describe1, Describe2 },
                new string[] { Txts.Hints.Tasks, Txts.Sections.Tasks });
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            HideMenuSections();
            AnyShowX(HelpHints);
            Txts.Docs.InfoChange1 = 0;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 },
                new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 },
                new string[] { Txts.Docs.HelpInfo2[0, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo2[1, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo2[2, Txts.Docs.InfoChange1] },
                new string[] { Txts.Docs.HelpInfo1[0, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo1[1, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo1[2, Txts.Docs.InfoChange1] });
            FastTextChange(new Label[] { InfoIndex, Describe1, Describe2 },
                new string[] { Txts.Docs.InfoChange1 + 1 + "/19", 
                    Txts.Hints.Infos, Txts.Sections.Infos });
            AnyShow(SwitchPanel);
            GameHint();
        }
        private void FastInfoChange(TextBlock[] Texts, Label[] Headers, in string[] text, in string[] content)
        {
            for (byte i = 0; i < Headers.Length; i++)
            {
                Headers[i].Content = content[i];
                Texts[i].Text = text[i];
            }
        }
        private void FastImgChange(BitmapImage bitmapImage, params Image[] ImageArray)
        {
            for (byte i = 0; i < ImageArray.Length; i++)
                ImageArray[i].Source = bitmapImage;
        }
        private void FastImgChange(BitmapImage[] bitmapImage, params Image[] ImageArray)
        {
            for (byte i = 0; i < ImageArray.Length; i++)
                ImageArray[i].Source = bitmapImage[i];
        }
        private void InfoIndexPlus_Click(object sender, RoutedEventArgs e)
        {
            Txts.Docs.InfoChange1 += 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 },
                new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 },
                new string[] { Txts.Docs.HelpInfo2[0, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo2[1, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo2[2, Txts.Docs.InfoChange1] },
                new string[] { Txts.Docs.HelpInfo1[0, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo1[1, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo1[2, Txts.Docs.InfoChange1] });
            InfoIndex.Content = $"{Txts.Docs.InfoChange1 + 1}/19";
            AnyShow(InfoIndexMinus);
            if (Txts.Docs.InfoChange1 >= 18)
                AnyHide(InfoIndexPlus);
            GameHint();
        }
        private void InfoIndexMinus_Click(object sender, RoutedEventArgs e)
        {
            Txts.Docs.InfoChange1 -= 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 },
                new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 },
                new string[] { Txts.Docs.HelpInfo2[0, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo2[1, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo2[2, Txts.Docs.InfoChange1] },
                new string[] { Txts.Docs.HelpInfo1[0, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo1[1, Txts.Docs.InfoChange1],
                    Txts.Docs.HelpInfo1[2, Txts.Docs.InfoChange1] });
            InfoIndex.Content = $"{Txts.Docs.InfoChange1 + 1}/19";
            AnyShow(InfoIndexPlus);
            if (Txts.Docs.InfoChange1 <= 0)
                AnyHide(InfoIndexMinus);
            GameHint();
        }
        private async void ShowAutoSave()
        {
            AnyShow(AutoSave);
            for (byte i = 0; i < 2; i++)
            {
                double op = 1.0;
                for (; op >= 0.7; op -= 0.01)
                {
                    AutoSave.Opacity = op;
                    await Task.Delay(20);
                }
                for (; op <= 1.0; op += 0.01)
                {
                    AutoSave.Opacity = op;
                    await Task.Delay(20);
                }
            }
            AnyHide(AutoSave);
        }
        private void TheEnd_MediaEnded(object sender, RoutedEventArgs e)
        {
            TargetImage = TrgtImg;
            AnyHideX(EnemyStatus, BattleText6, ItemsMenu, TargetImage,
                SkillsMenu, FightMenu, SelectMenuFight, SelectMenuSkills);
            WonOrDied();
            AnyHide(Skip1);
            switch (Ray.MenuTask)
            {
                case 3:
                    Button4.IsEnabled = true;
                    AnyHide(BossSlot1);
                    AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Fin_Chapter1),
                        TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.AncientKey);
                    Ray.MenuTask++;
                    Img1.Source = Bmper(Paths.Static.Map.Normal);
                    AnyShow(Skip1);
                    break;
                case 4:
                    ShowAutoSave();
                    AnyShowAdvanced(ChapterIntroduction, Ura(Paths.CutScenes.PreChapter2),
                        TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.WaterTemple);
                    break;
                case 6:
                    Button4.IsEnabled = true;
                    AnyHide(BossSlot1);
                    AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Fin_Chapter2),
                        TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.Conversation);
                    Ray.MenuTask++;
                    Img1.Source = Bmper(Paths.Static.Map.Normal);
                    AnyShow(Skip1);
                    break;
                case 7:
                    ShowAutoSave();
                    AnyShowAdvanced(ChapterIntroduction, Ura(Paths.CutScenes.PreChapter3),
                        TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.LavaTemple);
                    break;
                case 8:
                    AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Fin_Chapter3), TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.Threasures);
                    Ray.MenuTask++;
                    Img1.Source = Bmper(Paths.Static.Map.Normal);
                    AnyShow(Skip1);
                    break;
                case 9:
                    ShowAutoSave();
                    AnyShowAdvanced(ChapterIntroduction, Ura(Paths.CutScenes.PreChapter4),
                        TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.GetAway);
                    break;
                case 10:
                    if (CurrentPlayer.Content.ToString() == "????")
                    {
                        AddNewPlayer("SeriousMan");
                        SaveCool("SeriousMan");
                        PlaySound(Paths.OST.Sounds.ControlSave);
                    }
                    AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Titres),
                        TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.SayGoodbye);
                    Ray.MenuTask++;
                    break;
                default: Close(); break;
            }
        }
        private void Sound3_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound3.Stop();
            Sound3.Position = TimeSpan.Zero;
        }
        private void Win_MediaOpened(object sender, RoutedEventArgs e)
        {
            WonOrDied();
        }
        private void Med1_MediaOpened(object sender, RoutedEventArgs e)
        {
            AnyHideX(NewAdventure, Img1, Lab1, Skip1);
            AnyShow(Skip1);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            StateGuy();
        }
        private void SwitchAbils_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Grid currentSkills = b.Parent as Grid;
            Grid nextSkills = b.Tag as Grid;
            AnyHide(currentSkills);
            AnyShow(nextSkills);
        }
        private void RemoveButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Equipment equipment = btn.Tag as Equipment;
            Label current = sender.Equals(Remove1) ? AddATK1 : AddDEF1;
            current.Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
            current.Content = $"-{equipment.Power}";
            AnyShow(current);
        }
        private void RemoveButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            AnyHide(sender.Equals(Remove1) ? AddATK1 : AddDEF1);
        }
        private void CraftSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (CraftSwitchLab.Content.ToString() == "Создание") {
                AnyShow(CraftItemsMenu);
                CraftSwitchLab.Content = "Сумка";
            }
            else
            {
                AnyHide(CraftItemsMenu);
                HeroItems();
            }
        }
        private void AbilsMenu_Click(object sender, RoutedEventArgs e)
        {
            Button[] abils = new Button[] { Cure1, Cure2Out, Heal1,
                Torch1, Whip1, Thrower1, Super0, Tornado1, Quake1,
                Learn1, BuffUp1, ToughenUp1, Regen1, Control1 };
            string[] uris = new string[] { Paths.OST.Noises.Cure,
                Paths.OST.Noises.Cure2, Paths.OST.Noises.Heal,
                Paths.OST.Noises.Torch, Paths.OST.Noises.Whip,
                Paths.OST.Noises.Thrower, Paths.OST.Noises.Super,
                Paths.OST.Noises.Whirl, Paths.OST.Noises.Quake,
                Paths.OST.Noises.Learn, Paths.OST.Noises.PowUp,
                Paths.OST.Noises.Shield, Paths.OST.Noises.HpUp,
                Paths.OST.Noises.ApUp };
            for (byte i = 0; i < abils.Length; i++)
                if (sender.Equals(abils[i]))
                    PlayNoise(uris[i]);
            if (sender.Equals(Cure1))
            {
                GetHP = Math.Min(GetMHP, Shrt(GetHP + ACure.Cure()));
                GetAP -= ACure.Cost;
            }
            if (sender.Equals(Cure2Out))
            {
                GetHP = ACure2.Cure();
                GetAP -= ACure2.Cost;
            }
            if (sender.Equals(Heal1))
            {
                HeroSetStatus(AHeal.HealStatus());
                GetAP -= AHeal.Cost;
            }
        }
        //[EN] Game settings
        //[RU] Настройки игры.
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            HideMenuSections();
            AnyShow(TimerTurnOn);
            HeroSettings();
        }
        private void SoundsLoud_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            if (!NewAdventure.IsEnabled)
                PlaySound(Paths.OST.Sounds.ChestOpened);
        }
        private void NoiseLoud_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            if (!NewAdventure.IsEnabled)
                PlayNoise(Paths.OST.Noises.Torch);
        }
        private void HeroSettings()
        {
            AnyShow(GameMenuSelect);
            AnyShow(GameSettings);
            FastTextChange(new Label[] { Describe1, Describe2 },
                new string[] { Txts.Hints.Setts, Txts.Sections.Setts });
        }
        private void TimerTurnOn_Checked(object sender, RoutedEventArgs e)
        {
            if (WRecd.IsEnabled) 
                TimerOff(ref WRecd);
        }
        private void TimerTurnOn_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!WRecd.IsEnabled)
                TimerOn(ref WRecd); 
        }
        private void AnyEquipments_MouseLeave(object sender, MouseEventArgs e)
        {
            AnyHideX(AddATK1, AddDEF1);
        }
        private void ChangeTimer(ref DispatcherTimer timer,
            EventHandler SomeEvent, TimeSpan timeSpan)
        {
            timer.Tick += new EventHandler(SomeEvent);
            timer.Interval = timeSpan;
        }
        
        private void ListPlayers(object sender, RoutedEventArgs e)
        {
            bool listed = AutorizeImg.Source.ToString().
                Contains(Paths.Static.Map.UnRegister);
            Grid addPlayer = AddPlayer.Parent as Grid;
            if (listed)
                AnyHideX(AddProfile, DeleteProfile, Player1, Player2,
                    Player3, Player4, Player5, Player6, addPlayer);
            else
                CheckRecords();
            AutorizeImg.Source = Bmper(listed ? Paths.Static.Map.Register
                : Paths.Static.Map.UnRegister);
        }
        private void AddProfile_Click(object sender, RoutedEventArgs e)
        {
            AnyHideX(NobodyNotAllowed, AlreadyHaveOne);
            if (AddPlayer.Text == "")
            {
                AnyShow(NobodyNotAllowed);
                return;
            }
            if (TSql.PlayerLogins.Contains(AddPlayer.Text))
            {
                AnyShow(AlreadyHaveOne);
                return;
            }
            AddNewPlayer(AddPlayer.Text);
            Grid addPlayer = AddPlayer.Parent as Grid;
            AnyHideX(addPlayer, AddProfile);
            AddPlayer.Text = "";
            CheckRecords();
        }
        private void AddNewPlayer(string name)
        {
            try
            {
                TSql.NewPlayer(name);
                TSql.CheckAllRecordedPlayers();
                _ = TSql.GetCurrentPlayer();
            }
            catch (Exception ex)
            {
                _ = new Reload(Numb(CONECTION_ERROR), ex.Message).ShowDialog();
                Close();
            }
        }
        private void AddPlayer_PreviewTextInput(object sender,
            TextCompositionEventArgs e)
        {
            AnyHideX(NobodyNotAllowed, AlreadyHaveOne);
            Regex regex = new Regex("[^0-9a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void CheckRecords()
        {
            Button[] Profiles = new Button[] { Player1, Player2,
                Player3, Player4, Player5, Player6 };
            if (TSql.PlayerLogins.Count < 6)
            {
                for (byte i = 0; i < TSql.PlayerLogins.Count; i++)
                {
                    Profiles[i].Content = TSql.PlayerLogins[i];
                    AnyShow(Profiles[i]);
                    AnyGrid(AddProfile, Bits(i + 1), 0);
                }
                int optimization = TSql.PlayerLogins.Count + 1;
                Grid addPlayer = AddPlayer.Parent as Grid;
                Grid.SetRow(AddProfile, optimization);
                Grid.SetRow(addPlayer, optimization);
                Grid.SetRow(NobodyNotAllowed, optimization);
                Grid.SetRow(AlreadyHaveOne, optimization);
                AnyShowX(AddProfile, addPlayer);
            }
            else
                for (byte i = 0; i < TSql.PlayerLogins.Count; i++)
                {
                    Profiles[i].Content = TSql.PlayerLogins[i];
                    AnyShow(Profiles[i]);
                }
        }
        private void PlayersSelecting(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            byte select = Bits(btn.GetValue(Grid.RowProperty));
            int optimization = select - 1;
            TSql.CurrentLogin = TSql.PlayerLogins[optimization];
            CurrentPlayer.Content = TSql.CurrentLogin;
            AnyGrid(DeleteProfile, select, 0);
            AnyShow(DeleteProfile);
            Continue.IsEnabled = TSql.CheckIfPlayerCanContinue();
            ConAdv.Source = Bmper(Continue.IsEnabled ?
                Paths.Static.Menu.Adventures.BeforeConAdv :
                Paths.Static.Menu.Adventures.AdventureLock);
            SeeMap();
        }
        private void Anonymous()
        {
            if (CurrentPlayer.Content.ToString() == "????")
                Continue.IsEnabled = false;
            ConAdv.Source = Bmper(Continue.IsEnabled ?
                Paths.Static.Menu.Adventures.BeforeConAdv :
                Paths.Static.Menu.Adventures.AdventureLock);
        }
        private void DeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            TSql.DeletePlayer(TSql.CurrentLogin);
            TSql.CheckAllRecordedPlayers();
            CurrentPlayer.Content = TSql.GetCurrentPlayer();
            Anonymous();
            SeeMap();
            AnyHideX(Player1, Player2, Player3, Player4,
                Player5, Player6, DeleteProfile);
            CheckRecords();
        }
        private void SaveGame()
        {
            try
            {
                byte[] CipherValue = new byte[] { 1, 2, 4, 8 };
                TSql.SavePlayerBag(new string[] { "@LOGIN", "@BAN", "@ETR",
                    "@ANT", "@FUS", "@HRB", "@ER2", "@SLB", "@ELX", "@MAT" },
                    new object[] { TSql.CurrentLogin, GetBag.Bandage.Count,
                        GetBag.Ether.Count, GetBag.Antidote.Count, GetBag.Fused.Count,
                        GetBag.Herbs.Count, GetBag.Ether2.Count, GetBag.SleepBag.Count,
                        GetBag.Elixir.Count, GetBag.Materials});
                TSql.SavePlayerEquip(new string[] { "@LOGIN", "@WPN", "@ARR",
                    "@PNT", "@BOO", "@WPS", "@ARS", "@PTS", "@BTS" },
                    new object[] { TSql.CurrentLogin, MainHero.Weapon.Power,
                        MainHero.Armor.Power, MainHero.Legs.Power,
                        MainHero.Boots.Power, Encoder(GetBag.Weapons),
                        Encoder(GetBag.Armors), Encoder(GetBag.Panties),
                        Encoder(GetBag.ArmBoots) });
                TSql.SavePlayerSettings(new string[] { "@LOGIN", "@MUS",
                    "@SND", "@NS", "@FS", "@BR", "@TMR" },
                    new object[] { TSql.CurrentLogin,
                        Bits(MusicLoud.Value * 100), Bits(SoundsLoud.Value * 100),
                        Bits(NoiseLoud.Value * 100), Bits(GameSpeed.Value * 100),
                        Bits(Brightness.Value * 100), TimerTurnOn.IsChecked.Value });
                TSql.SavePlayerStats(new string[] { "@LOGIN", "@LV", "@LC", "@HP",
                    "@AP", "@XP", "@TK", "@LN", "@TR" },
                    MainHero.GetPlayerRecord(TSql.CurrentLogin));
            }
            catch (Exception ex) {
                _ = new Reload(Numb(CONECTION_ERROR), ex.Message).ShowDialog();
                Close();
            }
        }
        private void SaveCool(string name)
        {
            try
            {
                byte[] CipherValue = new byte[] { 1, 2, 4, 8 };
                TSql.SavePlayerBag(new string[] { "@LOGIN", "@BAN", "@ETR", "@ANT",
                    "@FUS", "@HRB", "@ER2", "@SLB", "@ELX", "@MAT" },
                    new object[] { name, 255, 255, 255,
                        255, 255, 255, 255, 255, 65535});
                TSql.SavePlayerEquip(new string[] { "@LOGIN", "@WPN", "@ARR", "@PNT",
                    "@BOO", "@WPS", "@ARS", "@PTS", "@BTS" },
                    new object[] { name, 255, 115,
                        85, 55, 15, 15, 15, 15 });
                TSql.SavePlayerSettings(new string[] { "@LOGIN", "@MUS", "@SND",
                    "@NS", "@FS", "@BR", "@TMR" },
                    new object[] { name, Bits(MusicLoud.Value * 100),
                        Bits(SoundsLoud.Value * 100), Bits(NoiseLoud.Value * 100),
                        Bits(GameSpeed.Value * 100), Bits(Brightness.Value * 100),
                        TimerTurnOn.IsChecked.Value });
                TSql.SavePlayerStats(new string[] { "@LOGIN", "@LV", "@LC",
                    "@HP", "@AP", "@XP", "@TK", "@LN", "@TR" },
                    new object[] { name, 25, 1, 999, 999, 0, 0, 65535, true });
            }
            catch (Exception ex)
            {
                _ = new Reload(Numb(CONECTION_ERROR), ex.Message).ShowDialog();
                Close();
            }
        }
        //[EN] Continue button click.
        //[RU] Кнопка "Продолжить начатое".
        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            object[] Bag = TSql.CheckPlayerBag(TSql.CurrentLogin,
                new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            int len = Bag.Length - 1;
            byte[] byteArray = new byte[len];
            for (int i = 0; i < len - 1; i++)
                byteArray[i] = Bits(Bag[i]);
            GetBag.SetCount(byteArray);
            GetMaterials = Shrt(Bag[8]);

            byte[] byteEquip = TSql.CheckPlayerEquip(TSql.CurrentLogin,
                new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            GetHero.SetAllEquip(byteEquip[0], byteEquip[1], byteEquip[2], byteEquip[3]);
            byte[] Ciphers = { byteEquip[4], byteEquip[5], byteEquip[6], byteEquip[7] };

            Bag = TSql.GetPlayerRecord(TSql.CurrentLogin,
                new object[] { 0, 0, 0, 0, 0, 0, 0 });
            GetLV = Bits(Bag[0]);
            MainHero.MenuTask = Bits(Bag[1]);
            GetHP = Shrt(Bag[2]);
            GetAP = Shrt(Bag[3]);

            MainHero.Experience = Shrt(Bag[4]);
            MainHero.MiniTask = Bool(Bag[5]);
            MainHero.Learned = Shrt(Bag[6]);

            byteEquip = TSql.GetPlayerSettings(TSql.CurrentLogin,
                new byte[] { 0, 0, 0, 0, 0, 0 });
            SettingsSetAll(byteEquip);

            GetBag.Weapons = Decoder(new BitArray(new bool[4]), Ciphers[0]);
            GetBag.Hands = GetValueFromDecoder(GetBag.Weapons, MainHero.Weapon.Power);
            GetBag.Armors = Decoder(new BitArray(new bool[4]), Ciphers[1]);
            GetBag.Jacket = GetValueFromDecoder(GetBag.Armors, MainHero.Armor.Power);
            GetBag.Panties = Decoder(new BitArray(new bool[4]), Ciphers[2]);
            GetBag.Leggings = GetValueFromDecoder(GetBag.Panties, MainHero.Legs.Power);
            GetBag.ArmBoots = Decoder(new BitArray(new bool[4]), Ciphers[3]);
            GetBag.Foots = GetValueFromDecoder(GetBag.ArmBoots, MainHero.Boots.Power);
            OnPropertyChanged(nameof(GetBag));
            OnPropertyChanged(nameof(GetMaterials));
            OnPropertyChanged(nameof(GetHero));
            OnPropertyChanged(nameof(GetNlvl));
            ContinueQuest();
        }
        private void RefreshSkills()
        {
            OnPropertyChanged(nameof(ATorch));
            OnPropertyChanged(nameof(AWhip));
            OnPropertyChanged(nameof(ASling));
            OnPropertyChanged(nameof(ACombo));
            OnPropertyChanged(nameof(AWhirl));
            OnPropertyChanged(nameof(AQuake));
            OnPropertyChanged(nameof(ACure));
            OnPropertyChanged(nameof(ACure2));
            OnPropertyChanged(nameof(AHeal));
            OnPropertyChanged(nameof(AHpup));
            OnPropertyChanged(nameof(AApup));
            OnPropertyChanged(nameof(ATemper));
            OnPropertyChanged(nameof(ASecure));
            OnPropertyChanged(nameof(ALearn));
        }
        private void MapCheck(in byte Loc)
        {
            switch (Loc)
            {
                case 0: Location1_AncientPyramid(); break;
                case 1: Location2_WaterTemple(); break;
                case 2: Location3_LavaTemple(); break;
                default: Location4_BigRun(); break;
            }
        }
        private void ChangeBackground(in byte loc, in byte NoSpoilers)
        {
            string[] Bmps = new string[] { Paths.Static.Map.Location1,
                Paths.Static.Map.Location2, Paths.Static.Map.Location3,
                Paths.Static.Map.Location4 };
            Img1.Source = Bmper((NoSpoilers == 0) ?
                Paths.Static.Map.Main : Bmps[loc]);
        }
        private void ChangeBackground(in byte loc)
        {
            string[] Bmps = new string[] { Paths.Static.Map.Location1,
                Paths.Static.Map.Location2, Paths.Static.Map.Location3,
                Paths.Static.Map.Location4 };
            Img1.Source = Bmper(Bmps[loc]);
        }
        private void SettingsSetAll(params byte[] SettingValues)
        {
            Slider[] Sliders = { MusicLoud, SoundsLoud,
                NoiseLoud, GameSpeed, Brightness };
            for (byte i = 0; i < Sliders.Length; i++)
                Sliders[i].Value = Dble(SettingValues[i]) * 0.01;
            TimerTurnOn.IsChecked = SettingValues[5] >= 1;
        }
        private void PlayerSetLocation(in int row, in int column)
        {
            MainHero.Y = row;
            MainHero.X = column;
            AnyGrid(Img2, row, column);
        }

        //[EN] Creating a location instances.
        //[RU] Создание локаций.
        private void Location1_AncientPyramid()
        {
            AnyShowX(ChestImg1, ChestImg2, ChestImg3,
                ChestImg4, Table1, Table2, Table3);
            Sets.EnemyRate += MainHero.MenuTask;
            switch (MainHero.MenuTask)
            {
                case 0:
                    AnyShowX(KeyImg1, KeyImg2, KeyImg3,
                        LockImg1, LockImg2, LockImg3);
                    break;
                case 1:
                    AnyShowX(KeyImg3, LockImg3, KeyImg2, LockImg2);
                    ChangeMap(0, 101, 131);
                    break;
                case 2:
                    AnyShowX(KeyImg3, LockImg3);
                    ChangeMap(0, 101, 131, 102, 132);
                    break;
                case 3:
                    ChangeMap(0, 101, 131, 102, 132, 103, 133);
                    break;
            }
            AnyGridX(new Image [] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1,
                Table2, Table3, Threasure1, SaveProgress },
                new int[] { 27, 24, 7, 9, 33, 25, 10, 4, 17 },
                new int[] { 19, 11, 21, 20, 18, 15, 38, 36, 29 });
            PlayerSetLocation(MainHero.MenuTask <= 0 ? 34 : 17,
                MainHero.MenuTask <= 0 ? 18 : 29);
            Sets.LockIndex = Bits(3 - MainHero.MenuTask);
            if (GetBag.Armors[3])
                ChangeMapToVoid(191);
            TheEnd.Source = Ura(Paths.CutScenes.Victory);
        }
        private void Location2_WaterTemple()
        {
            byte[] EnemyRates = { 2, 3, 4, 5, 3, 5, 5 };
            Sets.EnemyRate = EnemyRates[Ray.MenuTask];
            Img1.Source = Bmper(Paths.Static.Map.Location2);
            AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4,
                Table1, Table2, Table3, Threasure1, SaveProgress },
                new int[] { 9, 21, 10, 8, 29, 22, 22, 16, 28 },
                new int[] { 8, 10, 24, 35, 49, 23, 2, 4, 20 });
            AnyShowX(Img1, ChestImg1, ChestImg2, ChestImg3, ChestImg4,Table1,
                Table2, Table3, Threasure1, SaveProgress, SecretChestImg1,
                SecretChestImg2, JailImg2, JailImg3, Boulder1);
            ChestsCheck(GetBag.Panties[3], 213, SecretChestImg1);
            ChestsCheck(MainHero.MiniTask, 232, SecretChestImg2);
            bool task1 = MainHero.MenuTask > 4;
            bool task2 = MainHero.MenuTask > 5;
            if (!task2)
                AnyShowX(JailImg1, JailImg5, JailImg6, JailImg7);
            else if (!task1)
                AnyShow(JailImg1);
            if (task1)
                ChangeMap(0, task2 ? new byte[] {
                    134, 136, 137, 138, 104, 106, 107, 108
                    } : new byte[] { 134, 104 });
            PlayerSetLocation(task1 ? 28 : 34, task1 ? 20 : 51);
            TheEnd.Source = Ura(Paths.CutScenes.WasteTime);
        }
        private void Location3_LavaTemple()
        {
            Sets.EnemyRate = 5;
            AnyShowX(ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2,
                Table3, Boulder1, JailImg1, JailImg2, JailImg5, Lever1, Lever2, Lever3);
            AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1,
                Table2, Table3, Threasure1, SaveProgress, Boulder1, JailImg1, JailImg2,
                JailImg5 },
                new int[] { 17, 22, 28, 26, 17, 1, 1, 2, 18, 20, 28, 21, 25 },
                new int[] { 4, 23, 38, 56, 27, 9, 50, 28, 28, 46, 37, 46, 48 });
            AnyHideX(JailImg3, JailImg6, JailImg7, SecretChestImg1, SecretChestImg2);
            AnyShowX(SpDmg1, SpDmg2, SpDmg3, SpDmg4, SpDmg5, SpHrb1, SpHrb2, SpHrb3,
                SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8, SpHrb9, SpHrb10, SpHrb11, SpHrb12,
                SpHrb13, SpHrb14, SpEtr1, SpEtr2, SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7,
                SpEtr8, SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14, SpEtr15,
                SpEtr16, SpEtr17, SpEtr18, SpElx1, SpElx2, SpElx3, SpElx4, SpElx5, SpElx6,
                SpSbg1, SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6, SpSbg7, SpSbg8, SpSbg9,
                SpSbg10, SpSbg11, SpSer, SpTsk);
            SurpriseCheck(GetBag.Weapons[3], 226, SpSer);
            SurpriseCheck(Ray.MiniTask, 233, SpTsk);
            if (Ray.MenuTask >= 8)
            {
                ChangeMapToVoid(138);
                ChangeMapToWall(111);
                PullTheLever(Lever1, Bridge1, Bridge2, Bridge3, Bridge4);
            }
            PlayerSetLocation(18, 28);
            TheEnd.Source = Ura(Paths.CutScenes.PowerRanger);
        }
        private void Location4_BigRun()
        {
            AnyShowX(TimerFlees, TimerFlees1);
            AnyHideX(SpDmg1, SpDmg2, SpDmg3, SpDmg4, SpDmg5, SpHrb1, SpHrb2, SpHrb3,
                SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8, SpHrb9, SpHrb10, SpHrb11, SpHrb12,
                SpHrb13, SpHrb14, SpEtr1, SpEtr2, SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7,
                SpEtr8, SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14, SpEtr15,
                SpEtr16, SpEtr17, SpEtr18, SpElx1, SpElx2, SpElx3, SpElx4, SpElx5, SpElx6,
                SpSbg1, SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6, SpSbg7, SpSbg8, SpSbg9,
                SpSbg10, SpSbg11, SpSer, SpTsk, Lever1, Lever2, Lever3, Bridge1, Bridge2,
                Bridge3, Bridge4, Bridge5, Bridge6, Bridge7, Bridge8);
            TimerOn(ref TRout);
            PlayerSetLocation(1, 30);
        }
        private void Threasures()
        {
            string[] ambushed = {
                Paths.CutScenes.Ambushed, Paths.CutScenes.BattleStations,
                Paths.CutScenes.NotAgain
            };
            string[] battlegrounds = {
                Paths.Static.Battle.Battle1, Paths.Static.Battle.Battle2,
                Paths.Static.Battle.Battle3, Paths.Static.Battle.Battle3
            };
            string[] threasures = {
                Paths.Static.Map.Models.Artifact1, Paths.Static.Map.Models.Artifact2,
                Paths.Static.Map.Models.Artifact3, Paths.Static.Map.Models.Artifact3
            };
            ChestsCheck(GetBag.Weapons[CurrentLocation], 203, ChestImg3);
            ChestsCheck(GetBag.Armors[CurrentLocation], 201, ChestImg1);
            ChestsCheck(GetBag.Panties[CurrentLocation], 204, ChestImg4);
            ChestsCheck(GetBag.ArmBoots[CurrentLocation], 202, ChestImg2);
            FastImgChange(BmpersToX(battlegrounds[CurrentLocation],
                threasures[CurrentLocation]), Img3, Threasure1 );
            AnyShowX(Threasure1, SaveProgress, ChestImg1, ChestImg2,
                ChestImg3, ChestImg4, Table1, Table2, Table3);
            Med2.Source = Ura(ambushed[CurrentLocation]);
        }

        //[EN] Continue game.
        //[RU] Продолжение игры.
        private void ContinueQuest()
        {
            RefreshSkills();
            TSql.DeselectAllPlayers();
            CurrentLocation = LocationDecode(MainHero.MenuTask);
            MapScheme = MapBuild(CurrentLocation);
            MapCheck(CurrentLocation);
            if (CurrentLocation < 3)
                Threasures();
            else
                TimerOn(ref TRout);
            string[] music = new string[] {
                Paths.OST.Music.AncientPyramid, Paths.OST.Music.WaterTemple,
                Paths.OST.Music.LavaTemple, Paths.OST.Music.GetAway
            };
            ChangeBackground(CurrentLocation);
            PlayMusic(music[CurrentLocation]);
            AnyShowX(Img1, Img2);
            ContinueCheckPoints();
        }
        private void ChestsCheck(in bool CheckValue, in byte OnMap, Image Chest)
        {
            string[] chestvercl = new string[] { Paths.Static.Map.Models.ChestClosed1,
                Paths.Static.Map.Models.ChestClosed2, Paths.Static.Map.Models.ChestClosed3 };
            string[] chestverop = new string[] { Paths.Static.Map.Models.ChestOpened1,
                Paths.Static.Map.Models.ChestOpened2, Paths.Static.Map.Models.ChestOpened3 };
            Chest.Source = Bmper(CheckValue ? chestverop[CurrentLocation]
                : chestvercl[CurrentLocation]);
            if (CheckValue)
                ChangeMapToWall(OnMap);
        }
        private void SurpriseCheck(in bool CheckValue, in byte OnMap, Image Chest)
        {
            if (CheckValue)
            {
                AnyHide(Chest);
                ChangeMapToVoid(OnMap);
            }
        }
        private void ContinueCheckPoints()
        {
            AnyHide(MainMenu);
            HeroStatus();
        }
        
        private void AbilsMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            AnyHide(AbilsCost);
        }
        private void BuffSkills_Click(object sender, RoutedEventArgs e)
        {
            Lab2.Foreground = Brushes.White;
            Button btn = sender as Button;
            SupportSkills skill = btn.Tag as SupportSkills;
            Dictionary<string, int> dict = new Dictionary<string, int> {
                { ATemper.Name, 0 }, { ASecure.Name, 1 }
            };
            FrameworkElement[][] elements = {
                new FrameworkElement[] { BuffsUpImg, BuffUpTxt },
                new FrameworkElement[] { ToughUpTxt, ToughUpImg }
            };
            int p = dict[skill.Name];
            AbilityBonuses[p] = Bits(skill.Buff());
            GetAP -= skill.Cost;
            PlayNoise(skill.Noise);
            ShowAction(skill.Animation, skill.IconAnimate);
            WaitForEnd(Shrt(500 / GameSpeed.Value));
            OnPropertyChanged(nameof(GetATK));
            OnPropertyChanged(nameof(GetDEF));
            AnyShowX(elements[p]);
            AnyHide(SkillsMenu);
            Time1.Value = 0;
        }
        private void Regen_Click(object sender, RoutedEventArgs e)
        {
            if (PRegn.IsEnabled)
                return;
            Lab2.Foreground = Brushes.White;
            GetAP -= AHpup.Cost;
            TimerOn(ref PRegn, Shrt(250 / GameSpeed.Value));
            PlayNoise(AHpup.Noise);
            ShowAction(AHpup.Animation, AHpup.IconAnimate);
            AnyHide(SkillsMenu);
            WaitForEnd(Shrt(500 / GameSpeed.Value));
        }
        private void Control_Click(object sender, RoutedEventArgs e)
        {
            if (PCtrl.IsEnabled)
                return;
            Lab2.Foreground = Brushes.White;
            GetAP -= AApup.Cost;
            TimerOn(ref PCtrl, Shrt(250 / GameSpeed.Value));
            PlayNoise(AApup.Noise);
            ShowAction(AApup.Animation, AApup.IconAnimate);
            AnyHide(SkillsMenu);
            WaitForEnd(Shrt(500 / GameSpeed.Value));
        }
        
        private void ACT4_Click(object sender, RoutedEventArgs e)
        {
            ushort cipher = MainHero.Learned;
            BitArray learned = Decoder(new BitArray(new bool[16]), cipher);
            int no = foes[Sets.SelectedTarget].No;
            if (learned[no])
                return;
            Lab2.Foreground = Brushes.White;
            MainHero.Learned += ALearn.Learn(no);
            Button btn = sender as Button;
            SupportSkills skill = btn.Tag as SupportSkills;
            GetAP -= skill.Cost;
            AnyHideX(EnemyStatus, TargetImage, SelectMenuSkills, ACT4);
            PlayNoise(skill.Noise);
            ShowAction(skill.Animation, skill.IconAnimate);
            if (Targt.IsEnabled)
                TimerOff(ref Targt);
            WaitForEnd(Shrt(500 / GameSpeed.Value));
        }
        private void ActionOnOne_Click(object sender, RoutedEventArgs e)
        {
            Lab2.Foreground = Brushes.White;
            Button btn = sender as Button;
            FightSkills skill = btn.Tag as FightSkills;
            GetAP -= skill.Cost;
            AnyHideX(TargetImage, btn, SelectMenuSkills);
            PlayNoise(skill.Noise);
            ShowAction(skill.Animation, skill.IconAnimate);
            Skills1(skill);
            if (Targt.IsEnabled)
                TimerOff(ref Targt);
        }
        private void ActionOnAll_Click(object sender, RoutedEventArgs e)
        {
            Lab2.Foreground = Brushes.White;
            Button btn = sender as Button;
            FightSkills skill = btn.Tag as FightSkills;
            Time1.Value = 0;
            GetAP = Shrt(GetAP - skill.Cost);
            AnyShow(EnemyStatus);
            ReCheck();
            PlayNoise(skill.Noise);
            ShowAction(skill.Animation, skill.IconAnimate);
            AnyHideX(TargetImage);
            FoesKickedAll(skill.Power, Shrt(500 / GameSpeed.Value));
            AbilitySupers();
        }

        private async void FoesKickedAll(ushort strength, ushort time)
        {
            AnyShow(DamageFoe);
            for (byte target = 0; target < foes.Length; target++)
                if (foes[target].HP > 0)
                    await FoesKicked(target, strength, time);
            AnyHide(DamageFoe);
            AfterAction();
        }
        private async void FoesKickedOne(byte target, ushort strength, ushort time)
        {
            AnyShow(DamageFoe);
            await FoesKicked(target, strength, time);
            AnyHide(DamageFoe);
            AfterAction();
        }
        private async Task FoesKicked(byte target, ushort strength, ushort time)
        {
            FrameworkElement[][] elements = new FrameworkElement[][] {
                new FrameworkElement[] { HPenemyBar, HPenemy, Enemy, EnemyImg },
                new FrameworkElement[] { HPenemyBar2, HPenemy2, Enemy2, EnemyImg2 },
                new FrameworkElement[] { HPenemyBar3, HPenemy3, Enemy3, EnemyImg3 }
            };
            AnyShowX(elements[target]);
            DamageConcretelyFoe(strength, target);
            if (foes[target].HP <= 0)
                SuperCheckFoes(target);
            else
                FoesRefresh();
            await Task.Delay(time);
            AnyHideX(elements[target]);
        }
        private void DamageConcretelyFoe(in ushort strength, int no)
        {
            foes[no].HP = Shrt(Math.Max(foes[no].HP - strength, 0));
            DamageFoe.Content = foes[no].HP > 0 ? $"-{strength}" : "Убит";
        }

        private void AbilitiesInFight_MouseLeave(object sender, MouseEventArgs e)
        {
            AnyHide(BattleText2);
        }
        private void AbilitiesInFight_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            BattleText2.Content = SkillInfo.GetDescription(btn);
            AnyShow(BattleText2);
        }
        private void AbilitiesOutFight_MouseEnter(object sender, MouseEventArgs e)
        {
            AbilsCost.Content = Numb((sender as Button).Tag);
            AnyShow(AbilsCost);
        }

        private void ItemsInFight_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(ItemsMenu);
            Items item = (sender as Button).Tag as Items;
            UseItem(item);
            if (item.StatusRestore == 0)
                ShowAndHide(CureHealTxt, "-Яд", Shrt(1000 / GameSpeed.Value));
            if (item.HpRestore > 0)
                ShowAndHide(CureHealTxt, "+" + item.HpRestore,
                    Shrt(1000 / GameSpeed.Value));
            if (item.ApRestore > 0)
                ShowAndHide(RecoverAPTxt, "+" + item.ApRestore,
                    Shrt(1000 / GameSpeed.Value));
            WaitForEnd(Shrt(500 / GameSpeed.Value));
        }
        private void ItemsUseInBattle_MouseEnter(object sender, RoutedEventArgs e)
        {
            Items item = (sender as Button).Tag as Items;
            BattleText2.Content = item.Description;
            ItemText.Content = Txts.Common.Total + ": " + item.Count;
            AnyShowX(BattleText2, ItemText);
        }
        private void ItemsUseInBattle_MouseLeave(object sender, MouseEventArgs e)
        {
            AnyHideX(ItemText, BattleText2);
        }
        private void ItemsOutMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            Items item = (sender as Button).Tag as Items;
            CountText.Content = "Всего: " + item.Count;
            AnyShow(CountText);
        }
        private void ItemsOutMenu_Click(object sender, RoutedEventArgs e)
        {
            UseItem((sender as Button).Tag as Items);
        }
        private void UseItem(Items item)
        {
            if (item.StatusRestore == 0)
                GetStatus = item.StatusRestore;
            else
            {
                ushort optimize = Shrt(Math.Min(GetMHP, GetHP + item.HpRestore));
                GetHP = optimize;
                optimize = Shrt(Math.Min(GetMAP, GetAP + item.ApRestore));
                GetAP = optimize;
            }
            item.Count--;
            GetBag.GetType().GetProperty(item.Name).SetValue(GetBag, item);
            OnPropertyChanged(nameof(GetBag));
            CountText.Content = "Всего: " + item.Count;
            PlayNoise(Paths.OST.Noises.UseItems);
        }
        private void CraftItems_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Items item = btn.Tag as Items;
            item.Count++;
            GetMaterials -= item.Cost;
            GetBag.GetType().GetProperty(item.Name).SetValue(GetBag, item);
            OnPropertyChanged(nameof(GetBag));
            CountText.Content = "Всего: " + item.Count;
        }
        private void CraftPerfboots_Click(object sender, RoutedEventArgs e)
        {
            GetMaterials -= 30000;
            GetBag.ArmBoots[3] = true;
            GetBag.Foots = MainHero.Boots.Power == 0;
            OnPropertyChanged(nameof(GetBag));
        }
        private void CraftPerfboots_MouseEnter(object sender, MouseEventArgs e)
        {
            CountText.Content = Txts.Common.QMark;
            AnyShow(CountText);
        }
        private void HeroSetStatus(byte code)
        {
            string[] text = { Txts.Common.Hlthy + " ♫", Txts.Common.Ill + " §" };
            GetStatus = code;
            AfterStatus.Content = StatusP.Content = text[code];
        }
        
        private void ChangeOnChapter(in byte Loc)
        {
            string[][] MapAndBattle = {
                new string[] { Paths.Static.Map.Location1, Paths.Static.Battle.Battle1 },
                new string[] { Paths.Static.Map.Location2, Paths.Static.Battle.Battle2 },
                new string[] { Paths.Static.Map.Location3, Paths.Static.Battle.Battle3 },
                new string[] { Paths.Static.Map.Location4, Paths.Static.Battle.Battle3 }
            };
            CurrentLocation = Loc;
            FastImgChange(BmpersToX(MapAndBattle[CurrentLocation]), Img1, Img3);
            AnyHide(ChapterIntroduction);
            AnyHide(TheEnd);
        }
        private void ChapterIntroduction_MediaEnded(object sender, RoutedEventArgs e)
        {
            CurrentLocation = LocationDecode(Ray.MenuTask);
            MapScheme = MapBuild(CurrentLocation);
            Ray.MiniTask = false;
            switch (Ray.MenuTask)
            {
                case 0:
                    ChangeOnChapter(0);
                    Location1_AncientPyramid();
                    AnyShowX(Threasure1, SaveProgress);
                    Threasures();
                    TablesSetInfo();
                    break;
                case 3: case 4:
                    ChangeOnChapter(1);
                    Location2_WaterTemple();
                    Threasures();
                    SavePlayer();
                    AnyShow(SaveProgress); break;
                case 6: case 7:
                    ChangeOnChapter(2);
                    Location3_LavaTemple();
                    Threasures();
                    SavePlayer();
                    AnyShow(SaveProgress); break;
                case 8: case 9:
                    ChangeOnChapter(3);
                    Location4_BigRun();
                    SavePlayer();
                    break;
                case 10:
                    AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Titres), TimeSpan.Zero);
                    PlayMusic(Paths.OST.Music.SayGoodbye);
                    break;
                default:
                    Form1.Close();
                    break;
            }
            AnyShowX(Img1, Img2);
        }
        private void SavePlayer()
        {
            if (TSql.CurrentLogin == "????")
                return;
            SaveGame();
            PlaySound(Paths.OST.Sounds.ControlSave);
        }
        private void AnyEquipments_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Equipment equip = btn.Tag as Equipment;
            Label caption = (equip.GetType().Name == "Weapon") ? AddATK1 : AddDEF1;
            AnyShowX(Describe1, caption);
            caption.Foreground = new SolidColorBrush(Color.FromRgb(255, 210, 6));
            caption.Content = "+" + equip.Power;
            Describe1.Content = equip.Description;
        }
        private void AnyEquipments_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Equipment equipment = btn.Tag as Equipment;
            Equipment bare = EquipInfo.GetEquip(btn);
            AnyHide(Describe1);
            Dictionary<string, string> pairs = new Dictionary<string, string> {
                { "Weapon", "Hands" }, { "Armor", "Jacket" },
                { "Legs", "Leggings" }, { "Boots", "Foots" }
            };
            GetHero.GetType().GetProperty(bare.Type).SetValue(GetHero, equipment);
            GetBag.GetType().GetProperty(pairs[bare.Type]).SetValue(GetBag, false);
            OnPropertyChanged(nameof(GetBag));
            OnPropertyChanged(nameof(GetHero));
            OnPropertyChanged(nameof(GetATK));
            OnPropertyChanged(nameof(GetDEF));
            AnyHideX(Equipments, Equipments2, Equipments3, Equipments4, CancelEq);
            EquipWatch();
        }
        private async void PoisonHurts()
        {
            ushort time = Shrt(2000 / GameSpeed.Value);
            while (!(FoesFighting() || Pause.IsEnabled))
            {
                GetHP--;
                await Task.Delay(time);
            }
        }
        private bool FoesFighting()
        {
            return (GetHP <= 0) || (foes[0].HP <= 0 && foes[1].HP <= 0 && foes[2].HP <= 0);
        }
        
        private bool RockRoll()
        {
            byte[] MapModel = CheckModelCoord(7);
            if ((MapModel[0] == MainHero.Y) && (MapModel[1] == MainHero.X))
                Pain(50);
            ChangeMapToVoid(7);
            if (MapScheme[MapModel[0] + 1, MapModel[1]] != 1)
            {
                MapModel[0]++;
                MapScheme[MapModel[0], MapModel[1]] = 7;
                AnyGrid(Boulder1, MapModel[0], MapModel[1]);
                Boulder1.RenderTransform = new RotateTransform(45 * Adoptation.Width
                    * MapModel[0], 16 * Adoptation.Width, 15 * Adoptation.Height);
            }
            else
            {
                AnyHide(Boulder1);
                return true;
            }
            return false;
        }
        private void PhysicalAttack(Equipment.Weapon weapon)
        {
            string[] person = weapon.Animation;
            string[] icon = weapon.IconAnimate;
            PlayNoise(weapon.Noise);
            ShowAction(person, icon);
        }
        private void Skills1(FightSkills skill)
        {
            Foe foe = foes[Sets.SelectedTarget];
            int power = foe.Weak.Equals(skill.Name) ? skill.Power * 2 : skill.Power;
            int EnemyAura = foe.Speed + foe.Agility;
            ushort total = Shrt(Math.Max(power - EnemyAura, 0));
            FoesKickedOne(Sets.SelectedTarget, total, Shrt(500 / GameSpeed.Value));
            FoesRefresh();
        }

        private async void ShowAction(string[] person, string[] icon)
        {
            for (byte actions = 0; actions < person.Length; actions++)
            {
                FastImgChange(BmpersToX(person[actions], icon[actions]), Img4, Img5);
                ushort wait = Shrt(50 / GameSpeed.Value);
                await Task.Delay(wait);
            }
            FastImgChange(BmpersToX(MainHero.Image, MainHero.Icon), Img4, Img5);
        }
        private async void ShowAction(string[] person)
        {
            for (byte actions = 0; actions < person.Length; actions++)
            {
                Img4.Source = Bmper(person[actions]);
                ushort wait = Shrt(50 / GameSpeed.Value);
                await Task.Delay(wait);
            }
            Img4.Source = Bmper(MainHero.Image);
        }

        private void PRegn_F_T37(object sender, EventArgs e)
        {
            if (GetHP >= GetMHP)
                TimerOff(ref PRegn);
            else
                GetHP++;
        }
        private void PCtrl_F_T38(object sender, EventArgs e)
        {
            if (GetAP == GetMAP)
                TimerOff(ref PCtrl);
            else
                GetAP++;
        }
        private void PTurn_I_T42(object sender, EventArgs e)
        {
            Time1.Value++;
            if (Time1.Value < Time1.Maximum)
                return;
            TimerOff(ref PTurn);
            Time();
        }
        //[EN] "Live" scene
        //[RU] "Живая" сцена
        private bool RudeBattle(Image image, double opacity)
        {
            image.Opacity += opacity;
            return image.Opacity < 1;
        }
        private void SomeRudeAppears(in byte BattleIndex, in string Noise)
        {
            Sets.SpecialBattle = BattleIndex;
            TargetImage = BossSlot1;
            Img2.IsEnabled = false;
            Sound1.Stop();
            PlayNoise(Noise);
        }
        private async Task FoePhases(Image image, string[] phases, ushort time)
        {
            for (byte i = 0; i < phases.Length; i++)
            {
                image.Source = Bmper(phases[i]);
                await Task.Delay(time);
            }
        }
        private async void SimpleCutScene(Image image, double opacity, ushort time)
        {
            while (!RudeBattle(image, opacity))
                await Task.Delay(time);
            LetsBattle();
        }
        private async void ComplexCutScene(Image image, double opacity, ushort time)
        {
            while (RudeBattle(image, opacity))
                await Task.Delay(time);
            await FoePhases(Ancient, Paths.Dynamic.Models.Ancient, time);
            await FoePhases(Warrior, Paths.Dynamic.Models.Warrior, time);
            AnyGrid(Warrior, Bits(Warrior.GetValue(Grid.RowProperty)), 4);
            await Task.Delay(time);
            LetsBattle();
        }
        private void Targt_D_T28(object sender, EventArgs e)
        {
            UnlimitedActionsTickCheck(Paths.Dynamic.Misc.Target);
        }
        private void WRecd_R_T44(object sender, EventArgs e)
        {
            if (WorldRecord())
                TimerOff(ref WRecd);
        }
        private void RRoll_L_T48(object sender, EventArgs e)
        {
            if (RockRoll()) TimerOff(ref RRoll);
        }
        private void TRout_F_T59(object sender, EventArgs e)
        {
            if (TimeChamber())
                TimerOff(ref TRout);
        }

        //[EN] Game interactive documentation
        //[RU] Игровое интерактивное руководство.
        private void InfoImgs_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = sender as Image;
            string[,] inf = Paths.Static.Menu.MInfo.MAfter.HelpAfter;
            img.Source = Bmper(inf[Bits(img.Tag), Txts.Docs.InfoChange1]);
        }
        private void InfoImgs_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = sender as Image;
            string[,] inf = Paths.Static.Menu.MInfo.MBefore.HelpBefore;
            img.Source = Bmper(inf[Bits(img.Tag), Txts.Docs.InfoChange1]);
        }
        private void GameHint()
        {
            string[,] inf = Paths.Static.Menu.MInfo.MBefore.HelpBefore;
            FastImgChange(BmpersToX(inf[0, Txts.Docs.InfoChange1],
                inf[1, Txts.Docs.InfoChange1], inf[2, Txts.Docs.InfoChange1]),
                InfoImg1, InfoImg2, InfoImg3);
        }
        private void GameStartBtns_MouseEnter(object sender, MouseEventArgs e)
        {
            ((sender as Button).Content as Image).Source =
                Bmper(sender.Equals(NewAdventure) ?
                Paths.Static.Menu.Adventures.AfterNewAdv
                : Paths.Static.Menu.Adventures.AfterConAdv);
        }
        private void GameStartBtns_MouseLeave(object sender, MouseEventArgs e)
        {
            ((sender as Button).Content as Image).Source =
                Bmper(sender.Equals(NewAdventure) ?
                Paths.Static.Menu.Adventures.BeforeNewAdv
                : Paths.Static.Menu.Adventures.BeforeConAdv);
        }
        private void MediaErrorEncountered(object sender,
            ExceptionRoutedEventArgs e)
        {
            _ = new Reload(Numb(MEDIA_ERROR), e.ErrorException.Message).ShowDialog();
            Close();
        }
        private void Skip1_MouseEnter(object sender, MouseEventArgs e) {
            SkipImg.Source = Bmper(Paths.Static.Menu.Adventures.AfterSkip);
        }
        private void Skip1_MouseLeave(object sender, MouseEventArgs e) {
            SkipImg.Source = Bmper(Paths.Static.Menu.Adventures.BeforeSkip);
        }

        //Genocide feature
        private void Genocide_Click(object sender, RoutedEventArgs e)
        {
            AnyShow(AutoTurn);
            AnyHide(FightMenu);
            BadTime();
        }
        private void AutoTurn_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = new
                SolidColorBrush(Color.FromArgb(255, 155, 15, 15));
        }

        private void AutoTurn_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = new
                SolidColorBrush(Color.FromArgb(255, 6, 79, 236));
        }

        private void AutoTurn_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(sender as Button);
        }

        private void GameSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OnPropertyChanged(nameof(TimeFormula));
        }
    }
}