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
using DesertRage.Helpers;
using DesertRage.Helpers.Attach;
using static DesertRage.Customing.Decorators;
using static DesertRage.Mechanics.MapBuilder;
using static DesertRage.Customing.Converters.Converters;
using static DesertRage.Mechanics.Algorithms.Coloring;
using static DesertRage.Helpers.Abilities;
using static DesertRage.Helpers.Characteristics;
using System.Diagnostics;
using DesertRage.Model.Stats;
using DesertRage.Model.Stats.Player.Armory;
using static DesertRage.Writers.Processors;
using DesertRage.Model;
using DesertRage.Model.Stats.Player;
using DesertRage.ViewModel;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Locations;
using DesertRage.Controls;

namespace DesertRage
{

    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            SoundTrack.PlayMusic(Paths.OST.Music.MainTheme);

            
            //Functionality();
            //MainHero = Ray;
        }

        

        //private void Functionality()
        //{
        //    DispatcherTimer[] timers = new DispatcherTimer[] {
        //        Targt, PRegn, PCtrl, PTurn, RRoll, TRout
        //    };

        //    SetAllTimeTriggers(ref timers);

        //    ShowFoesStats();

        //    PlayMusic(Paths.OST.Music.MainTheme);

        //    Adaptate();

        //    Autorization();
        //    SeeMap();

        //    Anonymous();

        //}

        //private Image TargetImage;

        internal UserProfile Player { get; set; }

        internal Character Ray = new Character
        {
            Level = 1,
            Place = new Position(18, 34),

            HeroProfile = new Profile
            {
                Icon = Paths.Static.Person.Usual,
                Image = Paths.Static.Person.Usual,
            },

            Hp = new Bar(100),
            Ap = new Bar(40),

            Stats = new BattleStats
            {
                Attack = 25,
                Defence = 15,
                Speed = 15
            },
            Special = 25,

            Learned = new BitArray(16),

            Weapon = new Weapon
            {
                Name = Txts.Equipment.Hands.Bare,
                Type = "Weapon",
                Description = "",
                Noise = Paths.OST.Noises.HandAttack,
                Power = 0,
                Chest = 0,
                Animation = Paths.Dynamic.Person.HdAttack,
                IconAnimation = Paths.Dynamic.Icon.HdAttack
            },

            Armor = new Equipment{
                Name = Txts.Equipment.Torso.Bare,
                Type = "Armor",
                Description = "",
                Power = 0,
                Chest = 0
            },

            Legs = new Equipment
            {
                Name = Txts.Equipment.Anckles.Bare,
                Type = "Legs",
                Description = "",
                Power = 0,
                Chest = 0
            },

            Boots = new Equipment
            {
                Name = Txts.Equipment.Boots.Bare,
                Type = "Boots",
                Description = "",
                Power = 0,
                Chest = 0
            }
        };

        internal Character Sam = new Character
        {
            Level = 1,

            HeroProfile = new Profile
            {
                Icon = Paths.Static.Person.Usual,
                Image = Paths.Static.Person.Usual,
            },

            Hp = new Bar(200),
            Ap = new Bar(200),

            Stats = new BattleStats
            {
                Attack = 50,
                Defence = 50,
                Speed = 50
            },
            Special = 50,

            Learned = new BitArray(16),

            Weapon = new Weapon
            {
                Name = Txts.Equipment.Hands.Minigun,
                Type = "Weapon",
                Description = Txts.Hints.EqWpn4,
                Noise = Paths.OST.Noises.Minigun,
                Power = 100,
                Chest = 0,
                Animation = Paths.Dynamic.Person.SeriousMg,
                IconAnimation = Paths.Dynamic.Icon.SeriousMg
            },

            Armor = new Equipment
            {
                Name = Txts.Equipment.Torso.Bare,
                Type = "Armor",
                Description = "",
                Power = 0,
                Chest = 0
            },

            Legs = new Equipment
            {
                Name = Txts.Equipment.Anckles.Bare,
                Type = "Legs",
                Description = "",
                Power = 0,
                Chest = 0
            },

            Boots = new Equipment
            {
                Name = Txts.Equipment.Boots.Bare,
                Type = "Boots",
                Description = "",
                Power = 0,
                Chest = 0
            }
        };

        internal Character MainHero { get; set; }

        //#region Skills Members
        //public FightSkills ATorch => new FightSkills("Факел",
        //    Txts.Abililities.Torch, Paths.Dynamic.Person.Torch,
        //    Paths.Dynamic.Icon.Torch, 3, 4, Shrt(GetSPL * 1.25),
        //    Paths.OST.Noises.Torch);

        //public Skill SSTorch = new Skill
        //{
        //    Name = "Факел",
        //    Description = Txts.Abililities.Torch,
        //    Noise = Paths.OST.Noises.Torch,

        //    Power = 1.25f,

        //    Level = 3,
        //    Cost = 4,

        //    Animation = Paths.Dynamic.Person.Torch,
        //    IconAnimation = Paths.Dynamic.Icon.Torch,
        //};

        //public FightSkills AWhip => new FightSkills("Кнут",
        //    Txts.Abililities.Whip, Paths.Dynamic.Person.Whip,
        //    Paths.Dynamic.Icon.Whip, 6, 6, Shrt(GetSPL * 1.5),
        //    Paths.OST.Noises.Whip);

        //public FightSkills ASling => new FightSkills("Рогатка",
        //    Txts.Abililities.Throw, Paths.Dynamic.Person.Thrower,
        //    Paths.Dynamic.Icon.Thrower, 11, 15, Shrt(GetSPL * 2.5),
        //    Paths.OST.Noises.Thrower);

        //public FightSkills ACombo => new FightSkills("Супер",
        //    Txts.Abililities.Spec1, Paths.Dynamic.Person.Super,
        //    Paths.Dynamic.Icon.Super, 7, 10, Shrt(GetSPL * 2),
        //    Paths.OST.Noises.Super);

        //public FightSkills AWhirl => new FightSkills("Буря",
        //    Txts.Abililities.Spec2, Paths.Dynamic.Person.Tornado,
        //    Paths.Dynamic.Icon.Tornado, 13, 20, Shrt(GetSPL * 3),
        //    Paths.OST.Noises.Whirl);

        //public FightSkills AQuake => new FightSkills("Обвал",
        //    Txts.Abililities.Spec3, Paths.Dynamic.Person.Quake,
        //    Paths.Dynamic.Icon.Quake, 18, 30, Shrt(GetSPL * 4),
        //    Paths.OST.Noises.Quake);

        //public MedicineSkills ACure => new MedicineSkills("Лечение",
        //    Txts.Abililities.Cure, Paths.Dynamic.Person.Cure,
        //    Paths.Dynamic.Icon.Cure, 2, 5, Shrt(GetSPL * 2),
        //    Paths.OST.Noises.Cure);

        //public MedicineSkills ACure2 => new MedicineSkills("Лечение 2",
        //    Txts.Abililities.Cure2, Paths.Dynamic.Person.Cure2,
        //    Paths.Dynamic.Icon.Cure2, 21, 10, GetMHP,
        //    Paths.OST.Noises.Cure2);

        //public MedicineSkills AHeal => new MedicineSkills("Исцеление",
        //    Txts.Abililities.Heal, Paths.Dynamic.Person.Heal,
        //    Paths.Dynamic.Icon.Heal, 4, 3, Paths.OST.Noises.Heal);

        //public MedicineSkills AHpup => new MedicineSkills("Время лечит",
        //    Txts.Abililities.Regen, Paths.Dynamic.Person.Regen,
        //    Paths.Dynamic.Icon.Regen, 20, 15, 1, Paths.OST.Noises.HpUp);

        //public MedicineSkills AApup => new MedicineSkills("Контроль",
        //    Txts.Abililities.Control, Paths.Dynamic.Person.Control,
        //    Paths.Dynamic.Icon.Control, 25, 0, 1, Paths.OST.Noises.ApUp);

        //public SupportSkills ATemper => new SupportSkills("Усиление",
        //    Txts.Abililities.Buffs, Paths.Dynamic.Person.BuffUp,
        //    Paths.Dynamic.Icon.BuffUp, 16, 12,
        //    Paths.OST.Noises.StrongStand);

        //public SupportSkills ASecure => new SupportSkills("Охрана",
        //    Txts.Abililities.Tough, Paths.Dynamic.Person.ToughenUp,
        //    Paths.Dynamic.Icon.ToughenUp, 14, 8,
        //    Paths.OST.Noises.Shield);

        //public SupportSkills ALearn => new SupportSkills("Изучение",
        //    Txts.Abililities.Learn, Paths.Dynamic.Person.Learn,
        //    Paths.Dynamic.Icon.Learn, 5, 2, Paths.OST.Noises.Learn);
        //#endregion



        //[EN] Initialize timers for events
        //[RU] Инициализация таймеров для событий.
        DispatcherTimer PTurn = new DispatcherTimer();

        DispatcherTimer RRoll = new DispatcherTimer();
        DispatcherTimer TRout = new DispatcherTimer();

        

        //[EN] Injuries.
        //[RU] Ранения.
        public static byte PlayerHurt = 0;
        public static byte PlayerHurtM = 0;
        public static byte trgt = 0;
        public static byte[] EnemyAtck = new byte[] { 0, 0, 0 };

        //[EN] Values for timer
        //[RU] Значения времени таймера.
        public static byte[] FleeTime = new byte[] { 2, 30 };

        //[EN] Animation variables.
        //[RU] Переменные анимации.
        public static byte Appearance = 0;

        //[EN] Set events on triggers
        //[RU] Установка событий на триггеры
        //private void SetAllTimeTriggers(ref DispatcherTimer[] timers)
        //{
        //    EventHandler[] events = new EventHandler[]
        //    {
        //         Targt_D_T28,  //[EN] Active target  | [RU] Активная цель
        //         PRegn_F_T37,  //[EN] Regeneration   | [RU] Регенерация
        //         PCtrl_F_T38,  //[EN] Control        | [RU] Контроль
        //         PTurn_I_T42,  //[EN] Player turns   | [RU] Ходы игрока

        //         RRoll_L_T48,  //[EN] Rock roll trap | [RU] Ловушка перекати шар
        //         TRout_F_T59   //[EN] Get away time  | [RU] Время до обвала
        //    };

        //    int timeBit = Numb(250_000 / GameSpeed.Value);   //25 миллисекунд
        //    int timeShort = Numb(500_000 / GameSpeed.Value); //50 миллисекунд

        //    TimeSpan[] spans = new TimeSpan[]
        //    {
        //        new TimeSpan(timeShort), new TimeSpan(timeBit),
        //        new TimeSpan(timeBit), TimeSpan.FromMilliseconds(1),
        //        new TimeSpan(timeBit), TimeSpan.FromMilliseconds(500),
        //        TimeSpan.FromSeconds(1)
        //    };
        //    for (byte i = 0; i < timers.Length; i++)
        //        ChangeTimer(ref timers[i], events[i], spans[i]);
        //}

        //[EN] New game start and return to normal stats
        //[RU] Начало новой игры и возврат к исходным значениям.
        private void New_game()
        {
            //RefreshSkills();

            Player.Hero = Ray;
            Player.CurrentLocation = ReadJson<Location>("SecretTemple.json");
        }
        
        //private void PauseGame()
        //{
        //    AnyShow(Pause);
        //    Sound1.Pause();
        //    if (GameOver.IsEnabled)
        //        GameOver.Pause();
        //    if (!FoesFighting())
        //        TimerOff(ref PTurn);
        //    if (CurrentLocation == 3 && !TheEnd.IsEnabled) 
        //        TimerOff(ref TRout);
        //}

        //private void Resume()
        //{
        //    AnyHide(Pause);
        //    Sound1.Play();
        //    if (GameOver.IsEnabled)
        //        GameOver.Play();
        //    if (!FoesFighting())
        //    {
        //        TimerOn(ref PTurn);
        //        if (GetStatus == 1)
        //            PoisonHurts();
        //    }
        //    if (CurrentLocation == 3 && !TheEnd.IsEnabled)
        //        TimerOn(ref TRout);
        //    for (byte i = 0; i < 3; i++)
        //        if (foes[i].HP > 0)
        //            CheckFoesTurns(i);
        //}

        private void SaveGame()
        {
            //PlaySound(Paths.OST.Sounds.ControlSave);
            SaveProfile("Ray.json", Player);
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