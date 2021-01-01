﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{

    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    
    //[EN] Foe class, influence on new enemies.
    //[RU] Класс противник, определяет новых противников возникающих в бою.
    public class Foe
    {
        public Foe()
        {
            GetStats();
        }

        //[EN] Stats class, presents each enemy stats in new object.
        //[RU] Класс параметров, определяет параметры каждого вида противников.
        public class Stats : Foe
        {
            public void PreStats(in Byte at, in Byte df, in Byte ag, in Byte sp, in UInt16 mhp)
            {
                EnemyAttack = at;
                EnemyDefence = df;
                EnemySpeed = ag;
                EnemyAgility = sp;
                EnemyMHP = mhp;
            }
            public UInt16 EnemyMHP { get; set; }
            public Byte EnemyAttack { get; set; }
            public Byte EnemyDefence { get; set; }
            public Byte EnemySpeed { get; set; }
            public Byte EnemyAgility { get; set; }
        }
        public void GetStats() {
            EnemyName = new string[] { "Паук", "Мумия", "Зомби", "Страж","Фараон", "Угх-зан I" };
            EnemyAppears = new string[] { "", "", "" };
            EnemyTurn = new Byte[] { 60, 30, 0 };
            EnemyHP = new UInt16[] { 0, 0, 0 };
            EnemiesStillAlive = 0;
        }
        public UInt16[] EnemyHP { get; set; }
        public string[] EnemyName { get; set; }
        public string[] EnemyAppears { get; set; }
        public Byte[] EnemyTurn { get; set; }
        public Byte EnemiesStillAlive { get; set; }
    }

    //[EN] Class of hero parameters, like Max Health (HP), Attack and other.
    //[RU] Класс параметров героя, таких как Макс. Здоровье (ОЗ), Атака и прочее.
    public class Characteristics
    {
        public Characteristics() {

            //[EN] PLAYER STATS
            //[RU] СТАТУС ИГРОКА

            //[EN] Current player's level and exp to the next level
            //[RU] Текущий уровень игрока и количество опыта необходимое для достижения следующего.
            CurrentLevel = 1;
            NextLevel = new UInt16[] { 15, 24, 38, 61, 98, 112, 150, 177, 200, 250 };

            //[EN] Active stats (HP,AP)
            //[RU] Активные параметры (ОЗ, ОД).
            MaxHP = 100;
            MaxAP = 40;

            //[EN] Passive stats (ATK, DEF, AG, SP)
            //[RU] Пассивные параметры (АТК, ЗЩТ, СК., СП.).
            Attack = 25;
            Defence = 15;
            Speed = 15;
            Special = 25;
            
            //[EN] PLAYER LEVEL UP STATS
            //[RU] СТАТУС ИГРОКА ПРИ ПОВЫШЕНИИ УРОВНЯ
            MaxHPNxt = new UInt16[] { 100, 110, 121, 132, 145, 159, 174, 192, 221, 250 };
            MaxAPNxt = new UInt16[] { 40, 44, 48, 53, 58, 64, 70, 77, 85, 100 };
            AttackNxt = new Byte[] { 25, 28, 31, 34, 40, 45, 52, 63, 70, 85 };
            DefenseNxt = new Byte[] { 15, 17, 19, 21, 25, 30, 33, 37, 45, 50 };
            SpeedNxt = new Byte[] { 15, 17, 19, 21, 23, 25, 28, 31, 35, 39 };
            SpecialNxt = new Byte[] { 25, 30, 35, 40, 45, 50, 60, 65, 75, 100 };

            //[EN] PLAYER CURRENT EQUIP
            //[RU] ТЕКУЩАЯ ЭКИПИРОВКА
            PlayerEQ = new Byte[] { 0, 0, 0, 0 };

            //[EN] PLAYER STATUS IN AND OUT OF BATTLE
            //[RU] СТАТУС ИГРОКА В И ВНЕ БОЯ
            DefenseState = 1;
            PlayerStatus = 0;
        }

        public UInt16 MaxHP { get; set; }
        public UInt16 MaxAP { get; set; }
        public Byte Attack { get; set; }
        public Byte Defence { get; set; }
        public Byte Speed { get; set; }
        public Byte Special { get; set; }
        public Byte CurrentLevel { get; set; }
        public Byte PlayerStatus { get; set; }
        public Byte DefenseState { get; set; }
        public UInt16[] NextLevel { get; set; }
        public UInt16[] MaxHPNxt { get; set; }
        public UInt16[] MaxAPNxt { get; set; }
        public Byte[] AttackNxt { get; set; }
        public Byte[] DefenseNxt { get; set; }
        public Byte[] SpeedNxt { get; set; }
        public Byte[] SpecialNxt { get; set; }
        public Byte[] PlayerEQ { get; set; }
    }

    //[EN] Bag class, depends on items getting and used in/out battle
    //[RU] Класс мешка с вещами, зависит от вещей, получаемых и используемых в/вне боя
    public class Bag : Characteristics
    {
        public Bag()
        {
            Equip();
            Items();
        }

        //[EN] Initialize empty slots of equipment
        //[RU] Метод для обозначения слотов экипировки
        public void Equip()
        {
            Hands = false;
            Weapon = new Boolean[] { false, false, false, false };
            Jacket = false;
            Armor = new Boolean[] { false, false, false, false };
            Legs = false;
            Pants = new Boolean[] { false, false, false, false };
            Boots = false;
            ArmBoots = new Boolean[] { false, false, false, false };
        }

        //[EN] Initialize items count method
        //[RU] Метод для обозначения хранения каждого вида предметов
        public void Items()
        {
            BandageITM = 0;
            AntidoteITM = 0;
            EtherITM = 0;
            FusedITM = 0;
            Materials = 0;
        }
        public Byte BandageITM { get; set; }
        public Byte AntidoteITM { get; set; }
        public Byte EtherITM { get; set; }
        public Byte FusedITM { get; set; }
        public Boolean Hands { get; set; }
        public Boolean[] Weapon { get; set; }
        public Boolean Jacket { get; set; }
        public Boolean[] Armor { get; set; }
        public Boolean Legs { get; set; }
        public Boolean[] Pants { get; set; }
        public Boolean Boots { get; set; }
        public Boolean[] ArmBoots { get; set; }
        public UInt16 Materials { get; set; }
    }

    //[EN] Menu class, contents info 
    //[RU] Класс игрового меню, содержит справочную информацию
    public class Menu
    {
        public Menu()
        {
            InitOnNewGame();
        }

        private void InitOnNewGame()
        {
            InfoChange1 = 0;
            HelpInfo1 = new string[,]{ {"Введение","Древние - кто они?","Приключение","Управление","Сражение","Цель боя","Очки здоровья, ОЗ","Урон","Оборона","Побег","Статус","Показатели","Скорость (СКР)","Больше чем бой","Настройки","Проходы","Сундуки","Сила земли","Сцены" },
            {"Искатель сокровищ","Предыстория","Розыск","Меню/Выход","Противники","Ходы","Очки действий, ОД","Бой","Умения","Результаты","Уровень","Атака (АТК)","Спец. (СПЦ)","Реестр противников","Разработал","Стены","Опасности","Погостить пришёл","Благодарности" },
            {"Древние святыни","Артефакты","Главы","Взаимодействие","Боссы","Действия","АВШ","Выбор","Предметы","Прирост","Опыт","Защита (ЗЩТ)","Время игры","Задачи","До новых встреч","Замки","Цветные камушки","Секреты","Финансы" } };
            
            HelpInfo2 = new string[,] { {"Добро пожаловать, искатели\nприключений! Приветствуем\nвас в кратком своде правил.","Древние - люди, что когда-то\nобладали технологиями, кото-\nрые нам и не снились.","Вам доступно создание\nнового или загрузка старого\nприключения если оно было","Клавиатура обязательна\nПередвижение - WASD,\nВзаимодействие - E","Во время передвижения, на\nвас могут напасть. Не бой-\nтесь сражаться за правое!","Во время сражения нужно\nубрать всех противников и\nбоссов с поля, не погибнув.","Определяют какое количе-\nство урона персонаж может\nвзять, прежде чем умереть.","Числом определяет силу, с\nкоторой бьёт герой или враг,\nприближает к гибели.","Повышает защиту героя в\nдва раза до следующего\nхода.","Существует альтернативный\nспособ выйти из сражения -\nизбежать этим действием.","Выводит состояние героя,\nпри отравлении персонаж\nбудет терять ОЗ.","Влияют на выживаемость\nгероя, каждый отвечает за\nчто-то своё.","Влияет на скорость заполне-\nния АВШ и возможность\nсбежать из боя.","Умения доступны вне боя, а\nещё каждое из них можно\n\"пожамкать\" ^_^.","Не так-то просто справляться\nс шумом? Слишком яркое\nизображение? Не вопрос!","Место, по которому может\nходить герой, обычная\nплита.","Там хранится всевозможное\nоружие и броня древних.\nПочему бы и не одолжить?","Источники, бьющие прямо\nиз огненных песков лечат\nвсе недомогания.","Как никогда лучше показы-\nвают происходящее в\nсамом эпицентре событий." },
            {"Вы играете за одарённого\nархеолога Рэя, его целью\nявляется поиск артефактов.","После глупых войн и жажды\nвласти, люди истратили нас-\n","Здесь находятся все\nискатели! Можно разделять\nпрогресс с друзьями","Клавиатура обязательна\nОткрыть меню - Left CTRL\nВыйти из игры - ESC","Монстры и прочие чудища,\nвышедшие из под контроля\nжаждут вашей гибели","Действия героя и врагов\nраспределены: они могут\nвыполнять их спустя время","От ОД зависит доступ к осо-\nбым действиям - умениям,\nвызывающие эффекты","Опция позволяющая физи-\nчески атаковать врага\nгерою, зависит от АТК.","Каждое умение тратит ОД и\nможет оказывать эффект\nкак на врага, так и на героя.","Победив, вы получаете\nопыт, материалы и ве-\nщи в конце сражения.","Показывает потенциал\nперсонажа, от него за-\nвисят все показатели.","Урон, наносимый героем\nпри обычной атаке. Может\nбыть увеличена оружием.","Специальное влияет на силу\nэффектов от использования\nумений персонажа.","После открытия умения \"Из-\nучение\", вы сможете смот-\nреть показатели врагов","Прошу любить и жаловать:\nТатаринцев Александр,\nвыступал в роли FullStack.","Препятствия, через которые\nнельзя передвигаться. Из\nних составлены лабиринты.","Какое приключение не обо-\nйдётся без опасностей?\nВсё как положено.","-Алло, это кто?\n-Сэм.\n-Шутник, Сэм, это я.","Посвящается (Вы лучшие):\nМасленников Денис,\nМасленникова Татьяна" },
            {"Основными местами для\nпоиска сокровищ стали\nсооружения древних.","Артефакты содержат посла-\nния, лежащие в основе\nключа к мудрости веков","Приключение рассказывает\nисторию, основные события\nкоторой показаны в главах","Все нажатия на кнопки\nосуществляются с помощью\nлевой кнопки мыши (ЛКМ)","Древние стражи и могучие\nвластители, пробудившиеся\nото сна ждут боя.","Совокупность опций возни-\nкающих около персонажа.\nНужны для победы в бою.","Активная временная шкала\nпосле заполнения, даёт ход\nгерою, отображая действия.","Для выбора зоны пораже-\nния. Отмена - вернуться к\nпредыдущим опциям","Использование предметов,\nполученных после боя или\nсозданных материалами.","При повышении уровня, по-\nказатели героя вырастут,\nоблегчая новые задачи.","При сборе достаточного\nколичества - повышает\nуровень.","Снижает урон, получаемый\nот врагов. Может быть\nувеличена доспехами.","Всему своё время и приклю-\nчение - не исключение, бе-\nрегите глаза, друзья!","Для понимания основной\nцели - она разбита на\nзадачи.","Надеюсь данное руководст-\nво было вам полезно, даль-\nше для общего развития =)","Закрытые проходы, веду-\nщие через путь к выходу\nк артефактам. ","Артефакты - ключи, ведущие\nк сокровищам, эта основная\nцель приключения.","Каждое сооружение хранит\nсвои секреты. Сможете ли\nвы отыскать их все?","А в плане денег - у нас нет\nденег. Поможете ли доброй\nкопеечкой? 89212049320" } };
        }
        public Byte InfoChange1 { get; set; }
        public string[,] HelpInfo1 { get; set; }
        public string[,] HelpInfo2 { get; set; }
    }

    //[EN] Misc class, contents engine values
    //[RU] Класс прочее, содержит параметры двигателя игры
    public class Misc
    {
        public Misc()
        {
            InitOnNewGame();
        }

        //[EN] Adaptation subclass
        //[RU] Подкласс адаптации
        public class Adopt : Misc
        {
            public Adopt()
            {
                AdoptInit();
            }

            private void AdoptInit()
            {
                WidthAdBack = 1;
                HeightAdBack = 1;
                ImgLeftStep = 62;
                ImgTopStep = 30;
                ImgXbounds = 18;
                ImgYbounds = 34;
            }

            public double WidthAdBack { get; set; }
            public double HeightAdBack { get; set; }
            public double ImgLeftStep { get; set; }
            public double ImgTopStep { get; set; }
            public int ImgXbounds { get; set; }
            public int ImgYbounds { get; set; }
        }
        private void InitOnNewGame()
        {
            EquipmentClass = 0;
            MenuTask = 0;
            TableEN = true;
            LockIndex = 3;
            StepsToBattle = 20;
            SelectedTarget = 0;
            SpiderAlive = 0;
            MummyAlive = 0;
            ZombieAlive = 0;
            BonesAlive = 0;
            EnemyRate = 2;
            Rnd1 = 0;
            Rnd2 = 0;
            SpecialBattle = 0;
            ItemsDropRate = new Byte[] { 0, 0, 0, 0 };
        }
        public Byte SelectedTarget { get; set; }
        public Byte StepsToBattle { get; set; }
        public Byte EnemyRate { get; set; }
        public Int32 Rnd1 { get; set; }
        public Int32 Rnd2 { get; set; }
        public Byte EquipmentClass { get; set; }
        public Byte MenuTask { get; set; }
        public Byte SpiderAlive { get; set; }
        public Byte MummyAlive { get; set; }
        public Byte ZombieAlive { get; set; }
        public Byte BonesAlive { get; set; }
        public bool TableEN { get; set; }
        public Byte LockIndex { get; set; }
        public Byte SpecialBattle { get; set; }
        public Byte[] ItemsDropRate { get; set; }
    }

    /* [EN] Initialize locations for future
     * [RU] Инициализация локаций на будущее
    public static int[] Xcoordinate = { -1517 };
    public static int[] Ycoordinate = { 60 };*/

    /// <summary>
    /// [EN] Interaction logic for MainWindow.xaml
    /// [RU] Интерактивная логика для ГлавногоЭкрана.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //[EN] Initialize MainWindow (Main Constructor)
        //[RU] Инициализация ГлавногоЭкрана (Главный Конструктор).
        public MainWindow()
        {
            Foe1.GetStats();
            SetEnemies();
            InitializeComponent();
            Form1.ResizeMode = ResizeMode.NoResize;
            Form1.WindowStyle = WindowStyle.None;
            Form1.WindowState = WindowState.Maximized;

            WidelyUsedAnyTimer(out TimeRecord,WorldRecord, new TimeSpan(0, 0, 0, 0, 1));
            HeyPlaySomething(new Uri(@"Begin2.mp3", UriKind.RelativeOrAbsolute));
            CheckScreenProperties();

            //[EN] Working with directories (for commercial and private purposes)
            //[RU] Работа с директориями (для коммерческих и личных целей).
            //Environment.CurrentDirectory();
        }
        public static UInt16[] TimeWorldRecord = new UInt16[] { 0, 0, 0, 0 };
        private void WorldRecord(object sender, EventArgs e)
        {
            if ((TimeWorldRecord[0] <= 23) && (TimeWorldRecord[1] <= 60) && (TimeWorldRecord[2] <= 60) && (TimeWorldRecord[3] <= 100)) {
                TimeWorldRecord[3]++;
                if (TimeWorldRecord[3] >= 100)
                {
                    TimeWorldRecord[2]++;
                    TimeWorldRecord[3] = 0;
                }
                if (TimeWorldRecord[2] >= 60)
                {
                    TimeWorldRecord[1]++;
                    TimeWorldRecord[2] = 0;
                }
                if (TimeWorldRecord[1] >= 60)
                {
                    TimeWorldRecord[0]++;
                    TimeWorldRecord[1] = 0;
                }
                if (TimeWorldRecord[0] >= 2)
                {
                    TimeRecordText.Foreground = Brushes.Yellow;
                    if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[1] >= 10)
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if (TimeWorldRecord[2] >= 10)
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else
                        TimeRecordText.Content = "Эй, это уже не шутки! Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                }
                else if (TimeWorldRecord[1] >= 30)
                {
                    TimeRecordText.Foreground = Brushes.Green;
                    if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10))
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[1] >= 10)
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if (TimeWorldRecord[2] >= 10)
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[3] >= 10)
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else
                        TimeRecordText.Content = "Пора передохнуть... Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                }
                else
                {
                    if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[1] >= 10) && (TimeWorldRecord[2] >= 10))
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[1] >= 10)
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if ((TimeWorldRecord[2] >= 10) && (TimeWorldRecord[3] >= 10))
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else if (TimeWorldRecord[2] >= 10)
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                    else if (TimeWorldRecord[3] >= 10)
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + "." + TimeWorldRecord[3];
                    else
                        TimeRecordText.Content = "Время: " + TimeWorldRecord[0] + ":0" + TimeWorldRecord[1] + ":0" + TimeWorldRecord[2] + ".0" + TimeWorldRecord[3];
                }
            }
            else
            {
                TimeRecordText.Foreground = Brushes.Red;
                TimeRecordText.Content = "Срочно выключай машину! Время: 23:59:59.99";
                TimeRecord.Stop();
            }
        }
        //[EN] Initialize public objects
        //[RU] Инициализация объектов публичного доступа
        Bag BAG = new Bag();
        Characteristics Super1 = new Characteristics
        {
            MaxHP = 100,
            MaxAP = 40,
            Attack = 25,
            Defence = 15,
            Speed = 15,
            Special = 25
        };
        Foe Foe1 = new Foe();
        Misc Sets = new Misc();
        Misc.Adopt Adoptation = new Misc.Adopt();
        Menu GameMenu = new Menu();
        Foe.Stats Spider = new Foe.Stats();
        Foe.Stats Mummy = new Foe.Stats();
        Foe.Stats Zombie = new Foe.Stats();
        Foe.Stats Bones = new Foe.Stats();
        Foe.Stats BOSS1 = new Foe.Stats();
        Foe.Stats SecretBOSS1 = new Foe.Stats();

        private void ChbShow(CheckBox Chb)
        {
            Chb.Visibility = Visibility.Visible;
            Chb.IsEnabled = true;
        }
        private void ChbHide(CheckBox Chb)
        {
            Chb.Visibility = Visibility.Hidden;
            Chb.IsEnabled = false;
        }
        private void SetEnemies()
        {
            Spider.GetStats();
            Spider.PreStats(25, 0, 10, 1, 65);
            Mummy.GetStats();
            Mummy.PreStats(32, 0, 17, 1, 83);
            Zombie.GetStats();
            Zombie.PreStats(41, 0, 25, 1, 101);
            Bones.GetStats();
            Bones.PreStats(50, 0, 35, 1, 125);
            BOSS1.GetStats();
            BOSS1.PreStats(75, 0, 40, 1, 500);
            SecretBOSS1.GetStats();
            SecretBOSS1.PreStats(50, 0, 50, 1, 350);
        }


        private void SEF(Uri sound)
        {
            Sound3.Stop();
            Sound3.Source = sound;
            Sound3.Play();
        }

        private void ImgShrink(Image Img, in Double W, in Double H)
        {
            Img.Width = W;
            Img.Height = H;
        }
        private void BtnShrink(Button Btn, in Double W, in Double H)
        {
            Btn.Width = W;
            Btn.Height = H;
        }
        private void BarShrink(ProgressBar Bar, in Double W, in Double H)
        {
            Bar.Width = W;
            Bar.Height = H;
        }
        private void MedShrink(MediaElement Med, in Double W, in Double H)
        {
            Med.Width = W;
            Med.Height = H;
        }
        private void LabShrink(Label Lab, in Double fs)
        {
            Lab.FontSize = fs;
        }
        private void LabGrid(Label Lab, in Byte row, in Byte col)
        {
            //Lab.Margin = new Thickness(l, t, 0, 0);
            Grid.SetRow(Lab, row);
            Grid.SetColumn(Lab, col);
        }
        private void BtnGrid(Button Btn, in Byte row, in Byte col)
        {
            //Btn.Margin = new Thickness(l, t, 0, 0);
            Grid.SetRow(Btn, row);
            Grid.SetColumn(Btn, col);
        }
        private void BarGrid(ProgressBar Bar, in Byte row, in Byte col)
        {
            Grid.SetRow(Bar, row);
            Grid.SetColumn(Bar, col);
        }
        private void MedGrid(MediaElement Med, in Byte row, in Byte col)
        {
            //Med.Margin = new Thickness(l, t, 0, 0);
            Grid.SetRow(Med, row);
            Grid.SetColumn(Med, col);
        }
        private void ImgGrid(Image Img, in Byte row, in Byte col)
        {
            //Img.Margin = new Thickness(l, t, 0, 0);
            Grid.SetRow(Img, row);
            Grid.SetColumn(Img, col);
        }
        private void ButtonCHFT(Button Btn, in Double fs)
        {
            Btn.FontSize = fs;
        }

        private void TxtHide(TextBlock Txt)
        {
            Txt.Visibility = Visibility.Hidden;
            Txt.IsEnabled = false;
        }
        private void TxtShow(TextBlock Txt)
        {
            Txt.Visibility = Visibility.Visible;
            Txt.IsEnabled = true;
        }
        private void TxtHideX(TextBlock[] TextArray)
        {
            foreach (TextBlock Txt in TextArray)
            {
                TxtHide(Txt);
            }
        }
        private void TxtShowX(TextBlock[] TextArray)
        {
            foreach (TextBlock Txt in TextArray)
            {
                TxtShow(Txt);
            }
        }
        private void SldHide(Slider sld)
        {
            sld.Visibility = Visibility.Hidden;
            sld.IsEnabled = false;
        }
        private void SldShow(Slider sld)
        {
            sld.Visibility = Visibility.Visible;
            sld.IsEnabled = true;
        }
        private void SldShowX(Slider[] SliderArray)
        {
            foreach (Slider sld in SliderArray)
            {
                SldShow(sld);
            }
        }
        private void SldHideX(Slider[] SliderArray)
        {
            foreach (Slider sld in SliderArray)
            {
                SldHide(sld);
            }
        }
        private void Adaptate()
        {
            ///In Game with player start
            //[EN] Adaptate mechanics, sreen elements formula: CurrentScreenSize/Recomended(1920X1080)
            //[RU] Механика адаптации, формула расположения элементов: ТекущееРазрешениеЭкрана/Рекомендуемое(1920Х1080)
            Button[] BtnWFM = { Button1, Skip1, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, CancelEq, Button2, Button3, Button4, Abilities, Items, Back2, Back1, Fight, Cancel1, Cancel2, Cure, Torch, Heal, Whip, Super, ACT1, ACT2, textOk2, TextOk1, InfoIndexMinus, InfoIndexPlus };
            Button[] BtnM = { Cure1, Heal1, Bandage, Ether1, Antidote, Fused, Equipments, Status, Abils, Items0, Tasks, Info, Equip, Bandage1, Antidote1, Ether, Fused1 };
            //TimeImg
            Label[] LabMS = { Lab1, Lab2, FightSkills, MiscSkills, HealCost, AbilsCost, CostText, BandageText, EtherText, AntidoteText, FusedText, CountText, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoIndex, Describe1, Describe2, BattleText1, BattleText2, HPtext, APtext, LevelText, ExpText, ItemText, BattleText3, BattleText4, BattleText5, BattleText6, HPenemy, BandageText, EtherText, AntidoteText, FusedText, CountText, ATK, SP, FightSkills, MiscSkills, HealCost, AbilsCost, CostText, Name0, Level0, StatusP, HPtext1, APtext1, Exp1, ATK1, DEF1, AG1, SP1, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, HP1, AP1, EquipH, EquipB, EquipL, EquipD, EquipText, HP, AP };
            Image[] ImgMS = { Icon0, ATKImg, DEFImg, AGImg, SPImg, EquipHImg, EquipBImg, EquipLImg, EquipDImg, Task1Img, Task2Img, Task3Img, Task4Img, Img4, Img5, ItemsCountImg, Img6, Img7, Img8, ChestImg4, ChestImg3, ChestImg2, ChestImg1, LockImg3, LockImg2, LockImg1, KeyImg3, KeyImg2, KeyImg1, Threasure1, Table1, Table2, Table3, TableMessage1, ChestMessage1 };
            ProgressBar[] StBarMS = { HPbar1, APbar1, ExpBar1 };
            ProgressBar[] BarMS = { HPbar, APbar, NextExpBar, Time1, HPenemyBar };
            MediaElement[] MedMS = { PharaohBattle, Med3, Med4, Trgt };
            //Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, ATK1, DEF1, AG1, SP1, EquipText, EquipH, EquipB, EquipL, EquipD, Exp1,
            foreach (Button btn in BtnWFM)
            {
                //ButtonMove(btn, btn.Margin.Left * Adoptation.WidthAdBack, btn.Margin.Top * Adoptation.HeightAdBack);
                BtnShrink(btn, (btn.Width * Adoptation.WidthAdBack), (btn.Height * Adoptation.HeightAdBack));
                ButtonCHFT(btn, btn.FontSize * Adoptation.WidthAdBack);
            }
            foreach (Button btn in BtnM)
            {
                //ButtonMove(btn, btn.Margin.Left * Adoptation.WidthAdBack, btn.Margin.Top * Adoptation.HeightAdBack);
                BtnShrink(btn, (btn.Width * Adoptation.WidthAdBack), (btn.Height * Adoptation.HeightAdBack));
            }
            //System.Windows.MessageBox.Show(Convert.ToString(Params.Margin.Left));
            foreach (Label lab in LabMS)
            {
                //LabMove(lab, lab.Margin.Left * Adoptation.WidthAdBack, lab.Margin.Top * Adoptation.HeightAdBack);
                LabShrink(lab, lab.FontSize * Adoptation.WidthAdBack);
            }
            //System.Windows.MessageBox.Show(Convert.ToString(Params.Margin.Left));
            foreach (Image img in ImgMS)
            {
                //ImgMove(img, img.Margin.Left * Adoptation.WidthAdBack, img.Margin.Top * Adoptation.HeightAdBack);
                ImgShrink(img, img.Width * Adoptation.WidthAdBack, img.Height * Adoptation.HeightAdBack);
            }
            foreach (ProgressBar bar in StBarMS)
            {
                //BarMove(bar, bar.Margin.Left * Adoptation.WidthAdBack, bar.Margin.Top * Adoptation.HeightAdBack);
                BarShrink(bar, bar.Width * 2 * Adoptation.WidthAdBack, bar.Height * Adoptation.HeightAdBack);
            }
            foreach (ProgressBar bar in BarMS)
            {
                //BarMove(bar, bar.Margin.Left * Adoptation.WidthAdBack, bar.Margin.Top * Adoptation.HeightAdBack);
                BarShrink(bar, bar.Width * Adoptation.WidthAdBack, bar.Height * Adoptation.HeightAdBack);
            }
            foreach (MediaElement med in MedMS)
            {
                //MedMove(med, med.Margin.Left * Adoptation.WidthAdBack, med.Margin.Top * Adoptation.HeightAdBack);
                MedShrink(med, med.Width * Adoptation.WidthAdBack, med.Height * Adoptation.HeightAdBack);
            }
            ///[EN] When fire start, break this, this may make more fun) Or if you want to release where player and Location stands|[RU] Ничего такого, просто способ быстро понять в чём дело, если элементы уехали в сторону
            //Lab1.Content = Img1.Margin.Top;
            //ImgShrink(Img2, 9999, 9999);
        }

        //D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\

        private void FullImgMedAutoShrink(in int W, in int H)
        {
            ImgShrink(Menu1, W, H);
            MedShrink(Med1, W, H);
            MedShrink(Med2, W, H);
            MedShrink(Win, W, H);
            MedShrink(GameOver, W, H);
            MedShrink(TheEnd, W, H);
            ImgShrink(Img1, W, H);
        }
        private void CheckScreenProperties()
        {
            int[,] ScreenSize = { { 800, 1024, 1152, 1280, 1280, 1280, 1280, 1280, 1360, 1366, 1440, 1600, 1600, 1680, 3840 }, { 600, 768, 864, 720, 768, 800, 960, 1024, 768, 768, 900, 900, 1024, 1050, 2160 } };
            double[,] WHB = { { 0.416667, 0.533333, 0.6, 0.666667, 0.666667, 0.666667, 0.666667, 0.666667, 0.708333, 0.711458, 0.75, 0.833333, 0.833333, 0.875, 2 }, { 0.555556, 0.711111, 0.8, 0.666667, 0.711111, 0.740741, 0.888889, 0.948148, 0.711111, 0.711111, 0.833333, 0.833333, 0.948148, 0.972222, 2 } };
            double[,] I2S = { { 12.92, 16.53, 18.6, 20.67, 20.67, 20.67, 20.67, 20.67, 21.96, 22.06, 23.25, 25.83, 25.83, 27.125, 62 }, { 16.67, 21.33, 24, 20.1, 21.33, 22.22, 26.67, 28.44, 21.33, 21.33, 25, 25, 28.44, 29.16, 60 } };
            String Screen = SystemParameters.VirtualScreenWidth + "X" + SystemParameters.VirtualScreenHeight;
            if (Screen != "1920X1080") {
                for (int j = 0; j < ScreenSize.GetLength(1); j++)
                {
                    if (Screen == (ScreenSize[0, j] + "X" + ScreenSize[1, j]))
                    {
                        Adoptation.HeightAdBack = WHB[1, j];
                        Adoptation.WidthAdBack = WHB[0, j];
                        ImgShrink(Img2, I2S[0, j], I2S[1, j]);
                        FullImgMedAutoShrink(ScreenSize[0, j], ScreenSize[1, j]);
                        Adoptation.ImgLeftStep = I2S[0, j] * 2;
                        Adoptation.ImgTopStep = I2S[1, j];
                        Adaptate();
                        break;
                    }
                    if (j == ScreenSize.GetLength(1))
                    {
                        MessageBoxResult MR = System.Windows.MessageBox.Show("Приложение не поддерживает данный\nтип разрешения на этом устройстве\n" + "\nДоступные разрешения:\n800x600;         1024X768;\n1152x864;       1280X720;\n1280x768;       1280X800;\n1280x960;       1280X1024;\n1360x768;       1366X768;\n1440x900;       1600X900;\n1600x1024;     1680X1050;\n1920x1080;     3840X2160;\n" + "\nТекущее разрешение экрана: " + Screen, "Ошибка адаптации разрешения", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (MR == MessageBoxResult.OK)
                        {
                            Form1.Close();
                        }
                    }
                }
            }
            else
            {
                Adoptation.ImgLeftStep = 62;
                Adoptation.ImgTopStep = 30;
            }
        }

        //[EN] Initialize all variables
        //[RU] Инициализация всех переменных.

        //[EN] Initialize timers
        //[RU] Инициализация таймеров.
        System.Windows.Threading.DispatcherTimer timer = null;
        System.Windows.Threading.DispatcherTimer timer2 = null;
        System.Windows.Threading.DispatcherTimer timer3 = null;
        System.Windows.Threading.DispatcherTimer timer4 = null;
        System.Windows.Threading.DispatcherTimer timer5 = null;
        System.Windows.Threading.DispatcherTimer timer6 = null;
        System.Windows.Threading.DispatcherTimer timer7 = null;
        System.Windows.Threading.DispatcherTimer timer8 = null;
        System.Windows.Threading.DispatcherTimer timer9 = null;
        System.Windows.Threading.DispatcherTimer timer10 = null;
        System.Windows.Threading.DispatcherTimer timer11 = null;
        System.Windows.Threading.DispatcherTimer timer12 = null;
        System.Windows.Threading.DispatcherTimer timer13 = null;
        System.Windows.Threading.DispatcherTimer TimeRecord = null;
        System.Windows.Threading.DispatcherTimer BossAppear1 = null;

        //[EN] Initialize way to escape and experience
        //[RU] Инициализация состояния побега и количества опыта, получаемого после боя.
        public static Int32 speed = 0;
        public static Int32 Exp = 0;
        public static Byte[,] MapScheme;

        //[EN] Initialize random mechanic
        //[RU] Инициализация механики ведения случайных величин.
        public static Random Random1 = new Random();
        public static Int32 rnd = Random1.Next(5, 20);
        public static int poison = 0;

        private void New_game()
        {
            //[EN] Return to normal stats
            //[RU] Возврат к исходным значениям.
            SetEnemies();
            Exp = 0;
            Foe1.EnemyAppears[0] = "";
            Foe1.EnemyAppears[1] = "";
            Foe1.EnemyAppears[2] = "";
            Foe1.EnemiesStillAlive = 0;
            Sets.SpiderAlive = 0;
            Sets.MummyAlive = 0;
            Sets.ZombieAlive = 0;
            Sets.BonesAlive = 0;
            PharaohAppears.Opacity = 0.1;
            ImgGrid(PharaohAppears, 8, 36);
            Sets.SpecialBattle = 0;
            Adoptation.ImgXbounds = 18;
            Adoptation.ImgYbounds = 34;
            Super1.CurrentLevel = 1;
            HPbar.Maximum = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
            HPbar.Value = HPbar.Maximum;
            APbar.Maximum = Super1.MaxAPNxt[Super1.CurrentLevel - 1];
            APbar.Value = APbar.Maximum;
            Super1.MaxHP = 100;
            Super1.MaxAP = 40;
            Super1.CurrentLevel = 1;
            Super1.Attack = 25;
            Super1.Defence = 15;
            Super1.Speed = 15;
            Super1.Special = 25;
            BAG.Hands = false;
            BAG.Jacket = false;
            BAG.Legs = false;
            BAG.Boots = false;
            BAG.AntidoteITM = 10;
            BAG.BandageITM = 10;
            BAG.EtherITM = 10;
            BAG.FusedITM = 10;
            BAG.Materials = 200;
            Sets.MenuTask = 0;
            Uri uriSourceCH = new Uri(@"ChestClosed(ver1).png", UriKind.RelativeOrAbsolute);
            FastImgChange(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4 }, new BitmapImage[] { new BitmapImage(uriSourceCH), new BitmapImage(uriSourceCH), new BitmapImage(uriSourceCH), new BitmapImage(uriSourceCH) } );
        }
        private void HeyPlaySomething(Uri uris)
        {
            Sound1.Stop();
            Sound1.Source = uris;
            Sound1.Play();
        }
        private void Dj(Uri uris)
        {
            Sound2.Stop();
            Sound2.Source = uris;
            Sound2.Play();
        }
        private void Intro()
        {
            Med1.IsEnabled = true;
            Med1.Visibility = Visibility.Visible;
            Med1.Play();
        }

        //[EN] Working with Images
        //[RU] Работа с изображениями
        private void ImgHide(Image Img)
        {
            Img.Visibility = Visibility.Hidden;
            Img.IsEnabled = false;
        }
        private void ImgShow(Image Img)
        {
            Img.Visibility = Visibility.Visible;
            Img.IsEnabled = true;
        }

        //[EN] Working with Media
        //[RU] Работа с элементами Медиа (звук, анимация, прочее).
        private void MediaHide(MediaElement Med)
        {
            Med.Stop();
            Med.Visibility = Visibility.Hidden;
            Med.IsEnabled = false;
        }
        private void MediaShow(MediaElement Med)
        {
            Med.Visibility = Visibility.Visible;
            Med.IsEnabled = true;
            Med.Play();
        }
        //[EN] Working with Buttons
        //[RU] Работа с кнопками.
        private void ButtonHide(Button Btn)
        {
            Btn.Visibility = Visibility.Hidden;
            Btn.IsEnabled = false;
        }

        private void BtnHideX(Button[] ButtonArray)
        {
            foreach (Button Btn in ButtonArray)
            {
                ButtonHide(Btn);
            }
        }
        private void ButtonShow(Button Btn)
        {
            Btn.Visibility = Visibility.Visible;
            Btn.IsEnabled = true;
        }
        //[EN] Working with Labels
        //[RU] Работа с метками (надписями).
        private void LabHide(Label Lab)
        {
            Lab.Visibility = Visibility.Hidden;
            Lab.IsEnabled = false;
        }
        private void LabShow(Label Lab)
        {
            Lab.Visibility = Visibility.Visible;
            Lab.IsEnabled = true;
        }
        //[EN] Working with bars
        //[RU] Работа со шкалами.
        private void BarShow(ProgressBar Bar)
        {
            Bar.Visibility = Visibility.Visible;
            Bar.IsEnabled = true;
        }

        private void BarHide(ProgressBar Bar)
        {
            Bar.Visibility = Visibility.Hidden;
            Bar.IsEnabled = false;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            New_game();
            MapBuild();
            Intro();
            LabHide(Lab1);
            ButtonHide(Button1);
            ButtonShow(Skip1);
            HeyPlaySomething(new Uri(@"Intro1.mp3", UriKind.RelativeOrAbsolute));
        }

        private void MapBuild()
        {
            MapScheme = new Byte[,]
            { {  1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
              {  1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,0,0,1,0,1,0,0,1,0,1,0,0,0,1,1,1,1,1,1,0,1,1,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,1,1,0,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,1,0,0,0,0,0,1,0,0,0,0,1,0,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1 },
              {  1,1,1,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,1,0,1,0,1,0,0,0,0,1,161,1,0,0,0,1,0,0,1,1,0,1,0,0,1,1,0,0,1,1,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,1,0,0,0,0,0,0,0,0,1,1,1,0,1,0,0,1,0,1,1,0,0,0,0,0,1,1,0,1 },
              {  1,1,0,1,1,0,1,1,1,1,0,1,1,0,1,1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,0,0,1,0,1,1,0,1,0,0,1,1,1,1,0,1,0,1 },
              {  1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,203,1,0,0,1,1,0,1,0,0,0,1,1,1,1,133,1,1,1,0,0,0,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0,1 },
              {  1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,0,0,1,1,1,0,1,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,1,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1 },
              {  1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,1,1,204,0,0,0,0,1,1,0,0,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,1,0,0,1,0,1,0,1,191,1,0,1,0,1,0,1 },
              {  1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,0,0,0,1,1,0,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,173,1,1,1,1,1,1,0,1,1,0,1,0,0,1,1,0,1,0,1,0,1 },
              {  1,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,1,0,0,0,1,0,0,1,1,1,0,0,0,1,1,1,0,0,0,0,0,1,0,1,1,0,0,0,0,0,1,1,0,1 },
              {  1,0,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0,0,1 },
              {  1,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1 },
              {  1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,1,1,1,1,0,0,1,0,1,1,1,1,1,0,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1 },
              {  1,0,1,0,1,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,1 },
              {  1,0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,1,0,0,0,1,1,0,1,0,0,1,0,1,0,1,0,1,1,1,1,1,0,0,1,1,1,1,1,0,1,1,0,0,0,1,0,0,0,0,0,0,1 },
              {  1,0,1,1,131,1,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1 },
              {  1,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,1,1,1,1,1,1,132,1,1,0,1,1,1,0,0,1,0,0,1,1,1,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1 },
              {  1,0,0,0,0,0,1,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1 },
              {  1,0,1,0,0,0,0,1,1,1,1,102,0,0,0,0,1,0,1,0,0,1,1,0,0,0,0,0,0,0,0,1,1,1,0,1,0,1,0,0,0,0,1,0,1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,1 },
              {  1,0,1,0,0,0,0,0,0,0,1,1,0,0,0,0,1,0,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1 },
              {  1,0,1,0,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,1,0,1,0,0,1,0,0,0,0,0,1,1,1,1,1,1,1,0,1,0,0,1,0,0,1,1,1,1,0,0,0,0,0,1,0,0,1 },
              {  1,0,1,0,1,0,0,0,0,0,1,202,0,0,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1 },
              {  1,1,1,0,1,1,1,1,0,0,1,1,0,0,1,172,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,1,0,0,1,0,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,0,0,1,1,1,1,0,1,1,1,1,1,1,0,0,1,0,0,1,0,0,0,1,1,1,0,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,0,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,1,0,201,1,0,0,0,0,1,0,0,1,1,1,1,0,0,0,0,1,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1,0,1,0,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,1,1,1,0,0,0,0,1,0,0,1,0,1,0,0,0,1,0,0,1,0,0,1,0,0,0,1,1,1,1,1,1,1,1,1,1,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,0,1 },
              {  1,0,1,0,1,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,1,1,0,0,1,0,1,0,0,1,0,0,0,1,0,0,0,1,1,0,0,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0,1,0,0,1 },
              {  1,0,1,0,1,0,0,0,0,1,1,1,1,0,0,0,0,1,1,0,1,0,0,1,0,0,1,0,1,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,1 },
              {  1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,0,0,1,0,0,0,1,0,1,0,1,0,1,1,1,0,1,1,0,0,1,1,1,1,0,0,1,1,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,1,1,0,0,1,0,0,1,0,0,0,1,0,1,0,0,0,1,0,1,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,1,1,0,0,0,0,1,0,0,1,0,0,1,1,0,1 },
              {  1,0,101,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,171,0,1,0,1,0,1,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0,103,0,1,0,0,0,1,0,0,0,0,1,0,0,1,0,0,1 },
              {  1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
              {  1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 } };
        }
        private void Med1_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox();
        }

        private void MessageBox()
        {
            throw new NotImplementedException();
        }

        //[EN] Activate/Deactivate all .. | [RU] Активировать/Деактивировать все...
        //[EN] chests/
        //[RU] сундуки/
        private void ChestsAllTurnOn1()
        {
            ImgShow(ChestImg1);
            ImgShow(ChestImg2);
            ImgShow(ChestImg3);
            ImgShow(ChestImg4);
        }
        private void ChestsAllTurnOff1()
        {
            ImgHide(ChestImg1);
            ImgHide(ChestImg2);
            ImgHide(ChestImg3);
            ImgHide(ChestImg4);
        }
        //[EN] keys/
        //[RU] ключи/
        private void KeysAllTurnOn1()
        {
            ImgShow(KeyImg1);
            ImgShow(KeyImg2);
            ImgShow(KeyImg3);
        }
        private void KeysAllTurnOff1()
        {
            ImgHide(KeyImg1);
            ImgHide(KeyImg2);
            ImgHide(KeyImg3);
        }
        //[EN] Locks/
        //[RU] замки/
        private void LocksAllTurnOn1()
        {
            ImgShow(LockImg1);
            ImgShow(LockImg2);
            ImgShow(LockImg3);
        }
        private void LocksAllTurnOff1()
        {
            ImgHide(LockImg1);
            ImgHide(LockImg2);
            ImgHide(LockImg3);
        }
        //[EN] Tables/
        //[RU] таблички/
        private void TablesAllTurnOn1()
        {
            ImgShow(Table1);
            ImgShow(Table2);
            ImgShow(Table3);
        }
        private void TablesAllTurnOff1()
        {
            ImgHide(Table1);
            ImgHide(Table2);
            ImgHide(Table3);
        }

        //[EN] After game intro has been ended
        //[RU] После завершения пролога.
        private void Med1_MediaEnded(object sender, RoutedEventArgs e)
        {
            TablesAllTurnOn1();
            ChestsAllTurnOn1();
            KeysAllTurnOn1();
            LocksAllTurnOn1();
            MediaHide(Med1);
            ButtonHide(Skip1);
            ImgShowX(new Image[] { Img1, TableMessage1, Threasure1, Img2 });
            Img1.Source = new BitmapImage(new Uri(@"Loc1_2.jpg", UriKind.RelativeOrAbsolute));
            HeyPlaySomething(new Uri(@"Main_theme.mp3", UriKind.RelativeOrAbsolute));
        }
        private void CheckIfInteracted()
        {
            if (ChestMessage1.IsEnabled)
            {
                ImgHide(ChestMessage1);
            }
            if (TaskCompletedImg.IsEnabled)
            {
                ImgHide(TaskCompletedImg);
            }
        }
        //[EN] Complete tasks
        //[RU] Завершение задач.
        private void CollectKey(Image Key, Image Lock)
        {
            ImgHideX(new Image[] { Key, Lock });
            ImgShow(TaskCompletedImg);
            Sets.LockIndex--;
            Sets.EnemyRate++;
            Sets.MenuTask++;
        }
        //[EN] Target select mech
        //[RU] Механика выбора цели.
        private void InfoAboutEnemies()
        {
            Byte[] grRow = new Byte[] { 23, 15, 21 };
            Byte[] grColumn = new Byte[] { 2, 13, 24 };
            int[] newHP = { Spider.EnemyMHP, Mummy.EnemyMHP, Zombie.EnemyMHP, Bones.EnemyMHP, BOSS1.EnemyMHP, SecretBOSS1.EnemyMHP };
            Uri[] EnemySource = new Uri[] { new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Spider1.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Mummy1.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Zombie1.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Bones1.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Pharaoh.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\UghZan1.png", UriKind.RelativeOrAbsolute) };
            for (int en = 0; en < newHP.Length; en++)
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == Foe1.EnemyName[en])
                {
                    BattleText1.Content = Foe1.EnemyName[en];
                    HPenemyBar.Maximum = newHP[en];
                    HPenemyBar.Width = HPenemyBar.Maximum;
                    EnemyImg.Source = new BitmapImage(EnemySource[en]);
                    Grid.SetColumn(BattleText1, 17);
                    break;
                }
            }
            if ((Foe1.EnemyAppears[0] == "Фараон") || (Foe1.EnemyAppears[0] == "Угх-зан I"))
                ImgGrid(TrgtImg, (byte)((Int32)TrgtImg.GetValue(Grid.RowProperty) - 5), (byte)(Int32)TrgtImg.GetValue(Grid.ColumnProperty));
            ImgGrid(TrgtImg, grRow[Sets.SelectedTarget], grColumn[Sets.SelectedTarget]);
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            RefreshAllHP();
            LabShowX(new Label[] { HPenemy, BattleText1 });
        }
        private void SelectWithKeyBoard(bool Left)
        {
            if (Left)
            {
                if (Sets.SelectedTarget > 0)
                {
                    if (Foe1.EnemyHP[1] == 0)
                    {
                        if (!(Foe1.EnemyHP[0] == 0))
                            Sets.SelectedTarget -= 2;
                    }
                    else
                    if (Foe1.EnemyHP[0] == 0)
                    {
                        if (Sets.SelectedTarget > 1)
                            Sets.SelectedTarget--;
                    }
                    else
                    {
                        Sets.SelectedTarget--;
                    }
                    InfoAboutEnemies();
                }
            }
            else
            {
                if (Sets.SelectedTarget < Sets.Rnd1 - 1)
                {
                    if (Foe1.EnemyHP[1] == 0)
                    {
                        if (!(Foe1.EnemyHP[2] == 0))
                            Sets.SelectedTarget += 2;
                    }
                    else
                    if (Foe1.EnemyHP[0] == 0)
                    {
                        if (Sets.SelectedTarget < 2)
                            Sets.SelectedTarget++;
                    }
                    else
                    {
                        Sets.SelectedTarget++;
                    }
                    InfoAboutEnemies();
                }
            }
        }
        private void TablesSetInfo()
        {
            if ((Sets.TableEN) || (TableMessage1.IsEnabled))
            {
                Sets.TableEN = false;
                ImgHide(TableMessage1);
            }
            Byte Interaction = 0;
            if (Img2.Source.ToString().Contains("person3.png") || Img2.Source.ToString().Contains("WalkR1.png"))
            {
                Interaction = MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds + 1];
            }
            else if (Img2.Source.ToString().Contains("person1.png") || Img2.Source.ToString().Contains("WalkD1.png") || Img2.Source.ToString().Contains("WalkD2.png"))
            {
                Interaction = MapScheme[Adoptation.ImgYbounds + 1, Adoptation.ImgXbounds];
            }
            else if (Img2.Source.ToString().Contains("person4.png") || Img2.Source.ToString().Contains("WalkL1.png"))
            {
                Interaction = MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds - 1];
            }
            else if (Img2.Source.ToString().Contains("person2.png") || Img2.Source.ToString().Contains("WalkU1.png") || Img2.Source.ToString().Contains("WalkU2.png"))
            {
                Interaction = MapScheme[Adoptation.ImgYbounds - 1, Adoptation.ImgXbounds];
            }

            switch (Interaction)
            {
                case 171:
                    TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage1.png", UriKind.RelativeOrAbsolute));
                    ImgGrid(TableMessage1, 25, 13);
                    if (!Sets.TableEN)
                        Sets.TableEN = true;
                    ImgShow(TableMessage1);
                    break;
                case 172:
                    TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage2.png", UriKind.RelativeOrAbsolute));
                    ImgGrid(TableMessage1, 17, 10);
                    if (!Sets.TableEN)
                        Sets.TableEN = true;
                    ImgShow(TableMessage1);
                    break;
                case 173:
                    TableMessage1.Source = new BitmapImage(new Uri(@"TableMessage3.png", UriKind.RelativeOrAbsolute));
                    ImgGrid(TableMessage1, 2, 33);
                    if (!Sets.TableEN)
                        Sets.TableEN = true;
                    ImgShow(TableMessage1);
                    break;
                default:
                    break;
            }
        }
        private void GetPoisoned()
        {
            if (Super1.PlayerStatus == 1)
            {
                HPbar.Value -= 1;
                RefreshAllHP();
            }
            if (HPbar.Value <= 0)
            {
                Super1.PlayerStatus = 0;
                ImgHideX(new Image[] { Img2, Menu1 });
                MegaHide();
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                MediaShow(GameOver);
                timer.Stop();
                timer2.Stop();
            }
        }
        //[EN] Movement (W,A,S,D), actions on map (E), open menu (LCtrl), target select in fight (W,A,S,D)
        //[RU] Передвижение (W,A,S,D), действия при нахождении на локации (E), открыть меню (LCtrl), выбор цели (W,A,S,D)
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            CheckIfInteracted();
            if (Img2.IsEnabled)
            {
                Sets.Rnd1 = 0;
                Sets.SelectedTarget = 0;
                if (e.Key == Key.W)
                {
                    if (Img2.Source.ToString().Contains("WalkU1.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkU2.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"WalkU1.png", UriKind.RelativeOrAbsolute));

                    if ((MapScheme[Adoptation.ImgYbounds - 1, Adoptation.ImgXbounds] == 0) || (MapScheme[Adoptation.ImgYbounds - 1, Adoptation.ImgXbounds] == 191))
                    {
                        Adoptation.ImgYbounds -= 1;
                        Img2.SetValue(Grid.RowProperty, Adoptation.ImgYbounds);
                        if (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] == 191)
                        {
                            MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] = 0;
                            Sets.StepsToBattle--;
                            MediaShow(Med2);
                            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        }
                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.A)
                {
                    if (Img2.Source.ToString().Contains("person4.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkL1.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"person4.png", UriKind.RelativeOrAbsolute));
                    if ((MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds - 1] == 0) || (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds - 1] == 191))
                    {
                        Adoptation.ImgXbounds -= 1;
                        Img2.SetValue(Grid.ColumnProperty, Adoptation.ImgXbounds);
                        if (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] == 191)
                        {
                            ImgShrink(TrgtImg, 475, 475);
                            MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] = 0;
                            Sets.StepsToBattle--;
                            Sets.SpecialBattle = 200;
                            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                            MediaShow(Med2);
                        }
                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.S)
                {
                    if (Img2.Source.ToString().Contains("WalkD1.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkD2.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"WalkD1.png", UriKind.RelativeOrAbsolute));

                    if ((MapScheme[Adoptation.ImgYbounds + 1, Adoptation.ImgXbounds] == 0) || (MapScheme[Adoptation.ImgYbounds + 1, Adoptation.ImgXbounds] == 191))
                    {
                        Adoptation.ImgYbounds += 1;
                        Img2.SetValue(Grid.RowProperty, Adoptation.ImgYbounds);
                        if (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] == 191)
                        {
                            ImgShrink(TrgtImg, 475, 475);
                            MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] = 0;
                            Sets.StepsToBattle--;
                            Sets.SpecialBattle = 200;
                            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                            MediaShow(Med2);
                        }
                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.D)
                {
                    if (Img2.Source.ToString().Contains("person3.png"))
                    {
                        Img2.Source = new BitmapImage(new Uri(@"WalkR1.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                        Img2.Source = new BitmapImage(new Uri(@"person3.png", UriKind.RelativeOrAbsolute));

                    if ((MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds + 1] == 0) || (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds + 1] == 191))
                    {
                        Adoptation.ImgXbounds += 1;
                        Img2.SetValue(Grid.ColumnProperty, Adoptation.ImgXbounds);
                        if (MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] == 191)
                        {
                            ImgShrink(TrgtImg, 475, 475);
                            MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] = 0;
                            Sets.StepsToBattle--;
                            Sets.SpecialBattle = 200;
                            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                            MediaShow(Med2);
                        }
                    }
                    TablesSetInfo();
                    if (Sets.StepsToBattle >= rnd)
                    {
                        ImgHide(Img2);
                        Sound1.Stop();
                        Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
                        MediaShow(Med2);
                    }
                    Sets.StepsToBattle++;
                    GetPoisoned();
                }
                if (e.Key == Key.E)
                {

                    Uri DoorSound1 = new Uri(@"DoorOpened1.mp3", UriKind.RelativeOrAbsolute);
                    Uri ChestSound1 = new Uri(@"ChestOpened1.mp3", UriKind.RelativeOrAbsolute);
                    Uri BossSound1 = new Uri(@"Horror.mp3", UriKind.RelativeOrAbsolute);
                    Uri uriSourceCH = new Uri(@"ChestOpened(ver1).png", UriKind.RelativeOrAbsolute);
                    Uri[] EquipmentAll = new Uri[] { new Uri(@"GetItemsCustomWeapon1.png", UriKind.RelativeOrAbsolute), new Uri(@"GetItemsArmor1.png", UriKind.RelativeOrAbsolute), new Uri(@"GetItemsCustomPants1.png", UriKind.RelativeOrAbsolute), new Uri(@"GetItemsCustomBoots1.png", UriKind.RelativeOrAbsolute) };
                    Byte Interaction = 0;
                    Int32[] LocItem = new Int32[] { 0, 0 };
                    if (Img2.Source.ToString().Contains("person3.png"))
                    {
                        LocItem[0] = Adoptation.ImgYbounds;
                        LocItem[1] = Adoptation.ImgXbounds + 1;
                        Interaction = MapScheme[LocItem[0], LocItem[1]];
                    }
                    else if (Img2.Source.ToString().Contains("person1.png"))
                    {
                        LocItem[0] = Adoptation.ImgYbounds + 1;
                        LocItem[1] = Adoptation.ImgXbounds;
                        Interaction = MapScheme[LocItem[0], LocItem[1]];
                    }
                    else if (Img2.Source.ToString().Contains("person4.png"))
                    {
                        LocItem[0] = Adoptation.ImgYbounds;
                        LocItem[1] = Adoptation.ImgXbounds - 1;
                        Interaction = MapScheme[LocItem[0], LocItem[1]];
                    }
                    else if (Img2.Source.ToString().Contains("person2.png"))
                    {
                        LocItem[0] = Adoptation.ImgYbounds - 1;
                        LocItem[1] = Adoptation.ImgXbounds;
                        Interaction = MapScheme[LocItem[0], LocItem[1]];
                    }

                    switch (Interaction)
                    {
                        case 101:
                            ImgGrid(TaskCompletedImg, 28, 0);
                            CollectKey(KeyImg1, LockImg1);
                            SEF(DoorSound1);
                            MapScheme[LocItem[0], LocItem[1]] = 0;
                            for (Byte i = 0; i < MapScheme.GetLength(0); i++)
                            {
                                for (Byte j = 0; j < MapScheme.GetLength(1); j++)
                                {
                                    if (MapScheme[i, j] == 131)
                                    {
                                        MapScheme[i, j] = 0;
                                        break;
                                    }
                                }
                            }
                            break;
                        case 102:
                            ImgGrid(TaskCompletedImg, 16, 18);
                            CollectKey(KeyImg2, LockImg2);
                            SEF(DoorSound1);
                            MapScheme[LocItem[0], LocItem[1]] = 0;
                            for (Byte i = 0; i < MapScheme.GetLength(0); i++)
                            {
                                for (Byte j = 0; j < MapScheme.GetLength(1); j++)
                                {
                                    if (MapScheme[i, j] == 132)
                                    {
                                        MapScheme[i, j] = 0;
                                        break;
                                    }
                                }
                            }
                            break;
                        case 103:
                            ImgGrid(TaskCompletedImg, 28, 39);
                            CollectKey(KeyImg3, LockImg3);
                            SEF(DoorSound1);
                            MapScheme[LocItem[0], LocItem[1]] = 0;
                            for (Byte i = 0; i < MapScheme.GetLength(0); i++)
                            {
                                for (Byte j = 0; j < MapScheme.GetLength(1); j++)
                                {
                                    if (MapScheme[i, j] == 133)
                                    {
                                        MapScheme[i, j] = 0;
                                        break;
                                    }
                                }
                            }
                            break;
                        case 131:
                            break;
                        case 132:
                            break;
                        case 133:
                            break;
                        case 161:
                            ImgShrink(TrgtImg, 475, 475);
                            Sets.SpecialBattle = 1;
                            Img2.IsEnabled = false;
                            Sound1.Stop();
                            ImgShow(PharaohAppears);
                            BossAppear1 = new System.Windows.Threading.DispatcherTimer();
                            BossAppear1.Tick += new EventHandler(PharaohAppear_Time51);
                            BossAppear1.Interval = new TimeSpan(0, 0, 0, 0, 20);
                            BossAppear1.Start();
                            Dj(BossSound1);
                            break;
                        case 162:
                            break;
                        case 163:
                            break;
                        case 201:
                            ChestMessage1.Source = new BitmapImage(EquipmentAll[1]);
                            ChestImg1.Source = new BitmapImage(uriSourceCH);
                            ImgShow(ChestMessage1);
                            BAG.Jacket = true;
                            BAG.Armor[0] = true;
                            SEF(ChestSound1);
                            ImgGrid(ChestMessage1, 22, 16);
                            break;
                        case 202:
                            ImgShow(ChestMessage1);
                            ChestMessage1.Source = new BitmapImage(EquipmentAll[3]);
                            ChestImg2.Source = new BitmapImage(uriSourceCH);
                            BAG.Boots = true;
                            BAG.ArmBoots[0] = true;
                            SEF(ChestSound1);
                            ImgGrid(ChestMessage1, 19, 8);
                            break;
                        case 203:
                            ImgShow(ChestMessage1);
                            ChestMessage1.Source = new BitmapImage(EquipmentAll[0]);
                            ChestImg3.Source = new BitmapImage(uriSourceCH);
                            BAG.Hands = true;
                            BAG.Weapon[0] = true;
                            SEF(ChestSound1);
                            ImgGrid(ChestMessage1, 2, 18);
                            break;
                        case 204:
                            ImgShow(ChestMessage1);
                            ChestMessage1.Source = new BitmapImage(EquipmentAll[2]);
                            ChestImg4.Source = new BitmapImage(uriSourceCH);
                            BAG.Legs = true;
                            SEF(ChestSound1);
                            ImgGrid(ChestMessage1, 4, 17);
                            break;
                        case 205:
                            break;
                        case 206:
                            break;
                        case 207:
                            break;
                        case 208:
                            break;
                        case 209:
                            break;
                        case 210:
                            break;
                        case 211:
                            break;
                        case 212:
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if ((Fight.IsEnabled) || (ACT1.IsEnabled) || (ACT2.IsEnabled))
                {
                    if (e.Key == Key.W)
                    {
                        SelectWithKeyBoard(true);
                    }
                    if (e.Key == Key.A)
                    {
                        SelectWithKeyBoard(true);
                    }
                    if (e.Key == Key.S)
                    {
                        SelectWithKeyBoard(false);
                    }
                    if (e.Key == Key.D)
                    {
                        SelectWithKeyBoard(false);
                    }

                }
            }
            if (e.Key == Key.LeftCtrl)
            {
                if (Img2.IsEnabled)
                    if (!Menu1.IsEnabled)
                    {
                        if (Sets.TableEN)
                        {
                            Sets.TableEN = false;
                            ImgHide(TableMessage1);
                        }
                        HeroStatus();
                    }
                    else
                    {
                        ImgHide(Menu1);
                        ImgShowX(new Image[] { Img2, Img1 });
                        BtnHideX(new Button[] { Status, Abils, Items0, Equip, Tasks, Info, Settings });
                        MegaHide();
                    }
            }
            if (e.Key == Key.Escape)
                Form1.Close();
        }

        private void PharaohAppear_Time51(object sender, EventArgs e)
        {
            if (PharaohAppears.Opacity < 1)
            {
                PharaohAppears.Opacity += 0.01;
            } else
            {
                if ((byte)((Int32)PharaohAppears.GetValue(Grid.RowProperty) - 1) < 6)
                {
                    MediaShow(Med2);
                    BossAppear1.Stop();
                }
                ImgGrid(PharaohAppears, (byte)((Int32)PharaohAppears.GetValue(Grid.RowProperty) - 1), (byte)(Int32)(PharaohAppears.GetValue(Grid.ColumnProperty)));
            }
        }
        private void StatusCalculate()
        {
            StatsMeaning();
            MenuHpApExp();
        }

        private void HeroStatus()
        {
            StatusCalculate();
            ImgShowX(new Image[] { Menu1, Img2, Img1, Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg });
            RightPanelMenuTurnON();
            BarShowX(new ProgressBar[] { HPbar1, APbar1, ExpBar1 });
            LabShowX(new Label[] { Name0, Level0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD });
            if (!TimerTurnOn.IsChecked.Value)
            {
                LabShow(TimeRecordText);
            }
            BarGridX(new ProgressBar[] { HPbar1, APbar1 }, new Byte[] { 7, 9 }, new Byte[] { 11, 11 });
            LabGridX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Exp1 }, new Byte[] { 2, 7, 9, Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new Byte[] { 14, 2, 2, Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            Img2.SetValue(Grid.RowProperty, Adoptation.ImgYbounds);
            Status.IsEnabled = false;
            Describe2.Content = "Статус героя";
            Describe1.Content = "ОЗ имеет тенденцию падать до 0. Враги только этого и добиваются.\nПохоже им уже давно пора задать трёпку.";
            LabShow(Describe1);
        }

        private void ImgShowX(in Image[] ImagesArray)
        {
            foreach (Image img in ImagesArray)
            {
                ImgShow(img);
            }
        }

        private void LabShowX(in Label[] LabelArray)
        {
            foreach (Label Lab in LabelArray)
            {
                LabShow(Lab);
            }
        }

        private void BarShowX(in ProgressBar[] ProgressBarArray)
        {
            foreach (ProgressBar Bar in ProgressBarArray)
            {
                BarShow(Bar);
            }
        }
        private void BtnShowX(in Button[] ButtonArray)
        {
            foreach (Button Btn in ButtonArray)
            {
                ButtonShow(Btn);
            }
        }

        private void ImgGridX(in Image[] ImageArray, in Byte[] rows, in Byte[] cols)
        {
            for (Byte i = 0; i < ImageArray.Length; i++)
            {
                ImgGrid(ImageArray[i], rows[i], cols[i]);
            }
        }
        private void LabGridX(in Label[] LabelArray, in Byte[] rows, in Byte[] cols)
        {
            for (Byte i = 0; i < LabelArray.Length; i++)
            {
                LabGrid(LabelArray[i], rows[i], cols[i]);
            }
        }
        private void BarGridX(in ProgressBar[] ProgressBarArray, in Byte[] rows, in Byte[] cols)
        {
            for (Byte i = 0; i < ProgressBarArray.Length; i++)
            {
                BarGrid(ProgressBarArray[i], rows[i], cols[i]);
            }
        }
        private void BtnGridX(in Button[] ButtonArray, in Byte[] rows, in Byte[] cols)
        {
            for (Byte i = 0; i < ButtonArray.Length; i++)
            {
                BtnGrid(ButtonArray[i], rows[i], cols[i]);
            }
        }
        private void LabHideX(Label[] LabelArray)
        {
            foreach (Label Lab in LabelArray)
            {
                LabHide(Lab);
            }
        }
        private void ImgHideX(Image[] ImageArray)
        {
            foreach (Image Img in ImageArray)
            {
                ImgHide(Img);
            }
        }
        private void MegaHide()
        {
            TxtHideX(new TextBlock[] { InfoText1, InfoText2, InfoText3 });
            SldHideX(new Slider[] { MusicLoud, SoundsLoud, NoiseLoud, GameSpeed, Brightness });
            ChbHide(TimerTurnOn);
            LabHideX(new Label[] { MusicText, SoundsText, NoiseText, GameSpeedText, BrightnessText, MusicPercent, SoundsPercent, NoisePercent, BrightnessPercent, GameSpeedX, TimeRecordText });
            Image[] MegaHIDEImg = { Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg, Task1Img, Task2Img, Task3Img, Task4Img, MaterialsCraftImg };
            ProgressBar[] MegaHIDEBar = { HPbar1, APbar1, ExpBar1 };
            Label[] MegaHIDELab = { Name0, StatusP, Exp1, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD, AbilsCost, HealCost, CountText, CostText, FightSkills, MiscSkills, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoIndex, Level0, AntidoteText, EtherText, BandageText, FusedText, MaterialsCraft };
            Button[] MegaHIDEButton = { Ether1, Bandage, Antidote, Cure1, Heal1, Fused, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, Equipments, CancelEq, InfoIndexPlus, InfoIndexMinus, CraftSwitch, CraftAntidote, CraftBandage, CraftFused, CraftEther, Torch1, Whip1, Super0 };
            foreach (Image Img in MegaHIDEImg) {
                ImgHide(Img);
            }
            foreach (ProgressBar Bar in MegaHIDEBar)
            {
                BarHide(Bar);
            }
            foreach (Label Lab in MegaHIDELab)
            {
                LabHide(Lab);
            }
            foreach (Button Btn in MegaHIDEButton)
            {
                ButtonHide(Btn);
            }
        }

        public static Byte[] EnemyNamesFight = new Byte[] { 0, 0, 0, 0 };
        public static UInt16 Mat = 0;

        private void EnemiesTotal(in Byte num, in string EnemyKind, in Byte CountEnemy)
        {
            switch (EnemyNamesFight[num])
            {
                case 1:
                    BattleText3.Content = EnemyKind + ": " + CountEnemy;
                    LabShow(BattleText3);
                    break;
                case 2:
                    BattleText4.Content = EnemyKind + ": " + CountEnemy;
                    LabShow(BattleText4);
                    break;
                case 3:
                    BattleText5.Content = EnemyKind + ": " + CountEnemy;
                    LabShow(BattleText5);
                    break;
                default:
                    break;
            }
        }

        private void RegularBattle()
        {
            CalculateBattleStatus();

            string[] RegularEnemies = new string[] { "Паук", "Мумия", "Зомби", "Страж" };
            Uri[] RegularEnemiesImg = new Uri[] { new Uri(@"Spider.png", UriKind.RelativeOrAbsolute), new Uri(@"Mummy.png", UriKind.RelativeOrAbsolute), new Uri(@"Zombie.png", UriKind.RelativeOrAbsolute), new Uri(@"Bones.png", UriKind.RelativeOrAbsolute) };
            Uri RegularBattleTheme1 = new Uri(@"Battle_theme2.mp3", UriKind.RelativeOrAbsolute);

            HeyPlaySomething(RegularBattleTheme1);

            Sets.StepsToBattle = 0;
            rnd = Random1.Next(5, 20);

            if (Sets.SpecialBattle == 0)
            {
                Sets.Rnd1 = Random1.Next(1, 4);
                Foe1.EnemiesStillAlive = (byte)Sets.Rnd1;
                for (int ib = 1; ib <= Sets.Rnd1; ib++)
                {
                    Sets.Rnd2 = Random1.Next(1, Sets.EnemyRate);
                    if (Sets.Rnd2 == 1)
                    {
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 65;
                            Img6.Source = new BitmapImage(RegularEnemiesImg[0]);
                            Foe1.EnemyAppears[0] = RegularEnemies[0];
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 65;
                            Img7.Source = new BitmapImage(RegularEnemiesImg[0]);
                            Foe1.EnemyAppears[1] = RegularEnemies[0];
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 65;
                            Img8.Source = new BitmapImage(RegularEnemiesImg[0]);
                            Foe1.EnemyAppears[2] = RegularEnemies[0];
                        }
                        Exp += 5;
                        Mat += 5;
                        Sets.SpiderAlive += 1;
                        Sets.ItemsDropRate[0] += 1;
                        if (EnemyNamesFight[0] == 0)
                        {
                            if ((EnemyNamesFight[1] != 1) && (EnemyNamesFight[2] != 1) && (EnemyNamesFight[3] != 1))
                            {
                                EnemyNamesFight[0] = 1;
                            }
                            else if ((EnemyNamesFight[1] != 2) && (EnemyNamesFight[2] != 2) && (EnemyNamesFight[3] != 2))
                            {
                                EnemyNamesFight[0] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[0] = 3;
                            }
                        }
                    }
                    if (Sets.Rnd2 == 2)
                    {
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 83;
                            Img6.Source = new BitmapImage(RegularEnemiesImg[1]);
                            Foe1.EnemyAppears[0] = RegularEnemies[1];
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 83;
                            Img7.Source = new BitmapImage(RegularEnemiesImg[1]);
                            Foe1.EnemyAppears[1] = RegularEnemies[1];
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 83;
                            Img8.Source = new BitmapImage(RegularEnemiesImg[1]);
                            Foe1.EnemyAppears[2] = RegularEnemies[1];
                        }
                        Mat += 10;
                        Exp += 8;
                        Sets.MummyAlive += 1;
                        Sets.ItemsDropRate[1] += 1;
                        if (EnemyNamesFight[1] == 0)
                        {
                            if ((EnemyNamesFight[0] != 1) && (EnemyNamesFight[2] != 1) && (EnemyNamesFight[3] != 1))
                            {
                                EnemyNamesFight[1] = 1;
                            }
                            else if ((EnemyNamesFight[0] != 2) && (EnemyNamesFight[2] != 2) && (EnemyNamesFight[3] != 2))
                            {
                                EnemyNamesFight[1] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[1] = 3;
                            }
                        }
                    }
                    if (Sets.Rnd2 == 3)
                    {
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 101;
                            Img6.Source = new BitmapImage(RegularEnemiesImg[2]);
                            Foe1.EnemyAppears[0] = RegularEnemies[2];
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 101;
                            Img7.Source = new BitmapImage(RegularEnemiesImg[2]);
                            Foe1.EnemyAppears[1] = RegularEnemies[2];
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 101;
                            Img8.Source = new BitmapImage(RegularEnemiesImg[2]);
                            Foe1.EnemyAppears[2] = RegularEnemies[2];
                        }
                        Mat += 35;
                        Exp += 12;
                        Sets.ZombieAlive += 1;
                        Sets.ItemsDropRate[2] += 1;
                        if (EnemyNamesFight[2] == 0)
                        {
                            if ((EnemyNamesFight[0] != 1) && (EnemyNamesFight[1] != 1) && (EnemyNamesFight[3] != 1))
                            {
                                EnemyNamesFight[2] = 1;
                            }
                            else if ((EnemyNamesFight[0] != 2) && (EnemyNamesFight[1] != 2) && (EnemyNamesFight[3] != 2))
                            {
                                EnemyNamesFight[2] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[2] = 3;
                            }
                        }
                    }
                    if (Sets.Rnd2 == 4)
                    {
                        if (ib == 1)
                        {
                            Foe1.EnemyHP[0] = 125;
                            Img6.Source = new BitmapImage(RegularEnemiesImg[3]);
                            Foe1.EnemyAppears[0] = RegularEnemies[3];
                        }
                        if (ib == 2)
                        {
                            Foe1.EnemyHP[1] = 125;
                            Img7.Source = new BitmapImage(RegularEnemiesImg[3]);
                            Foe1.EnemyAppears[1] = RegularEnemies[3];
                        }
                        if (ib == 3)
                        {
                            Foe1.EnemyHP[2] = 125;
                            Img8.Source = new BitmapImage(RegularEnemiesImg[3]);
                            Foe1.EnemyAppears[2] = RegularEnemies[3];
                        }
                        Mat += 75;
                        Exp += 15;
                        Sets.BonesAlive += 1;
                        Sets.ItemsDropRate[3] += 1;
                        if (EnemyNamesFight[3] == 0)
                        {
                            if ((EnemyNamesFight[0] != 1) && (EnemyNamesFight[1] != 1) && (EnemyNamesFight[2] != 1))
                            {
                                EnemyNamesFight[3] = 1;
                            }
                            else if ((EnemyNamesFight[0] != 2) && (EnemyNamesFight[1] != 2) && (EnemyNamesFight[2] != 2))
                            {
                                EnemyNamesFight[3] = 2;
                            }
                            else
                            {
                                EnemyNamesFight[3] = 3;
                            }
                        }
                    }
                }
                //"            "
                EnemiesTotal(0, RegularEnemies[0], Sets.SpiderAlive);
                EnemiesTotal(1, RegularEnemies[1], Sets.MummyAlive);
                EnemiesTotal(2, RegularEnemies[2], Sets.ZombieAlive);
                EnemiesTotal(3, RegularEnemies[3], Sets.BonesAlive);
                switch (Sets.Rnd1)
                {
                    case 1:
                        ImgShow(Img6);
                        break;
                    case 2:
                        ImgShowX(new Image[] { Img6, Img7 });
                        break;
                    case 3:
                        ImgShowX(new Image[] { Img6, Img7, Img8 });
                        break;
                    default:
                        ImgShow(Img6);
                        break;
                }
            }
            else
            {

            }
            TimeEnemy();
        }
        private void CalculateBattleStatus()
        {
            EnemyNamesFight = new Byte[] { 0, 0, 0, 0 };
            if (Img2.Source.ToString().Contains("WalkU1.png") || Img2.Source.ToString().Contains("WalkU2.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person2.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkL1.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person4.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkD1.png") || Img2.Source.ToString().Contains("WalkD2.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person1.png", UriKind.RelativeOrAbsolute));
            }
            else if (Img2.Source.ToString().Contains("WalkR1.png"))
            {
                Img2.Source = new BitmapImage(new Uri(@"person3.png", UriKind.RelativeOrAbsolute));
            }
            if (Super1.CurrentLevel < 10)
                LevelText.Content = "Ур. " + Super1.CurrentLevel;
            else
                LevelText.Content = "Ур." + Super1.CurrentLevel;
            if (Sets.TableEN)
                ImgHide(TableMessage1);
            HPbar.Maximum = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
            APbar.Maximum = Super1.MaxAPNxt[Super1.CurrentLevel - 1];
            RefreshAllHPAP();
            speed = 0;
            Lab2.Foreground = Brushes.Yellow;

            LabShowX(new Label[] { LevelText, Lab2, HP, AP, HPtext, APtext });
            ImgHideX(new Image[] { Threasure1, Img1, Img2, PharaohAppears });
            ImgShowX(new Image[] { Img3, Img4, Img5, TimeTurnImg });
            BarShowX(new ProgressBar[] { HPbar, APbar, Time1 });
            MediaHide(Med2);

            TablesAllTurnOff1();
            ChestsAllTurnOff1();
            KeysAllTurnOff1();
            LocksAllTurnOff1();
            if (Sets.SpecialBattle!=200)
                FightMenuBack();
            ImgGrid(Img6, 23, 2);

            Time1.Value = 100;
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
        }
        private void BossBattle1()
        {
            CalculateBattleStatus();
            Uri PharaohSource = new Uri(@"Pharaoh.mp3", UriKind.RelativeOrAbsolute);
            Uri PharaohSRC = new Uri(@"Pharaoh.png", UriKind.RelativeOrAbsolute);
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Convert.ToByte(Sets.Rnd1);
            BattleText3.Content = "Фараон: " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "Фараон";
            Foe1.EnemyHP[0] = 500;
            Img6.Source = new BitmapImage(PharaohSRC);

            ImgGrid(Img6, 18, 2);
            ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            MedShrink(Trgt, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            ImgShow(Img6);

            Exp += 125;
            Mat += 250;

            HeyPlaySomething(PharaohSource);
            TimeEnemy();
        }
        public static UInt16[] RememberHPAP = {0,0,0,0};
        public static Byte[] RememberParams = { 0, 0, 0, 0 };
        private void SecretBossBattle1()
        {
            CalculateBattleStatus();
            Uri SecretSource = new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SecretBossFight1.mp3", UriKind.RelativeOrAbsolute);
            Uri SecretSRC = new Uri(@"UghZan.png", UriKind.RelativeOrAbsolute);

            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Convert.ToByte(Sets.Rnd1);
            BattleText3.Content = "Угх-зан I: " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "Угх-зан I";
            Foe1.EnemyHP[0] = 500;
            Img6.Source = new BitmapImage(SecretSRC);

            ImgGrid(Img6, 18, 2);
            ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
            ImgShow(Img6);

            Byte GameSpeed1 = Convert.ToByte(50/GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, SeriousSwitch_Time_Tick45, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            
            RememberHPAP[0] = Convert.ToUInt16(HPbar.Value);
            RememberHPAP[1] = Convert.ToUInt16(APbar.Value);
            RememberHPAP[2] = Super1.MaxHP;
            RememberHPAP[3] = Super1.MaxAP;
            RememberParams[0] = Super1.Attack;
            RememberParams[1] = Super1.Defence;
            RememberParams[2] = Super1.Speed;
            RememberParams[3] = Super1.Special;

            APtext.Content = "БР";
            APbar.Maximum = 200;
            APbar.Value = APbar.Maximum;
            APbar.Width= APbar.Maximum;
            HPbar.Maximum = 200;
            HPbar.Value = HPbar.Maximum;
            HPbar.Width = HPbar.Maximum;
            RefreshAllHPAP();
            Super1.Attack = 100;
            Super1.Defence = 35;

            Exp += 250;
            Mat += 500;

            HeyPlaySomething(SecretSource);
            TimeEnemy();
        }
        private void Med2_MediaEnded(object sender, RoutedEventArgs e)
        {
            switch (Sets.SpecialBattle)
            {
                case 0:
                    RegularBattle();
                    break;
                case 1:
                    BossBattle1();
                    break;
                case 200:
                    SecretBossBattle1();
                    break;
                default:
                    break;
            }
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            FightMenuMakesDisappear();
            BtnShowX(new Button[] { Fight, Cancel1 });
            SelectTarget();
        }

        public void SelectTarget()
        {
            Uri[] EnemySource = new Uri[] { new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Spider1.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Mummy1.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Zombie1.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Bones1.png", UriKind.RelativeOrAbsolute),new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\Pharaoh.png", UriKind.RelativeOrAbsolute), new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\EnemyImgs\UghZan1.png", UriKind.RelativeOrAbsolute) };
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук")
            {
                BattleText1.Content = "Паук";
                HPenemyBar.Maximum = 65;
                EnemyImg.Source = new BitmapImage(EnemySource[0]);
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
            {
                BattleText1.Content = "Мумия";
                HPenemyBar.Maximum = 83;
                EnemyImg.Source = new BitmapImage(EnemySource[1]);                
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
            {
                BattleText1.Content = "Зомби";
                HPenemyBar.Maximum = 101;
                EnemyImg.Source = new BitmapImage(EnemySource[2]);
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
            {
                BattleText1.Content = "Страж";
                HPenemyBar.Maximum = 125;
                EnemyImg.Source = new BitmapImage(EnemySource[3]);
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
            {
                BattleText1.Content = "Фараон";
                HPenemyBar.Maximum = 500;
                EnemyImg.Source = new BitmapImage(EnemySource[4]);
            }
            if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Угх-зан I")
            {
                BattleText1.Content = "Угх-Зан I";
                HPenemyBar.Maximum = 350;
                EnemyImg.Source = new BitmapImage(EnemySource[5]);
            }
            LabShow(HPenemy);
            BarShow(HPenemyBar);
            ImgShowX(new Image[] { EnemyImg, TrgtImg });
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            RefreshAllHP();
            InfoAboutEnemies();
            UInt16 GameSpeed1 = Convert.ToUInt16(100 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer9, Target_Time_Tick16, new TimeSpan(0, 0, 0, 0, GameSpeed1));
        }

        private void Med3_MediaEnded(object sender, RoutedEventArgs e)
        {
            AfterAction();
        }

        private void AfterAction()
        {
            BattleText3.Foreground = Brushes.White;
            BattleText4.Foreground = Brushes.White;
            BattleText5.Foreground = Brushes.White;
            if (Sets.SpecialBattle == 200)
            {
                HP.Foreground = Brushes.White;
            }
            LabHideX(new Label[] { BattleText1, BattleText2 });
            if (speed > 0)
            {
                Sets.SpiderAlive = 0;
                Sets.MummyAlive = 0;
                Sets.ZombieAlive = 0;
                Sets.BonesAlive = 0;
                Foe1.EnemyHP[0] = 0;
                Foe1.EnemyHP[1] = 0;
                Foe1.EnemyHP[2] = 0;
                Exp = 0;

                ImgShowX(new Image[] { Img1, Img2, Threasure1 });
                ImgHideX(new Image[] { Img3, Img4, Img5, Img6, Img7, Img8, TimeTurnImg });
                BarHideX(new ProgressBar[] { HPbar, APbar, NextExpBar, Time1 });
                LabHideX(new Label[] { HP, AP, Lab2, HPtext, APtext, LevelText, ExpText, BattleText3, BattleText4, BattleText5, BattleText6 });
                speed = 0;
                timer2.Stop();
                Sound1.Stop();
                
                ChestsAllTurnOn1();
                TablesAllTurnOn1();
                if (Sets.TableEN)
                    ImgShow(TableMessage1);
                
                switch (Sets.LockIndex)
                {
                    case 0:
                        break;
                    case 1:
                        ImgShowX(new Image[] { KeyImg3, LockImg3 });
                        break;
                    case 2:
                        ImgShowX(new Image[] { KeyImg2, LockImg2, KeyImg3, LockImg3 });
                        break;
                    case 3:
                        KeysAllTurnOn1();
                        LocksAllTurnOn1();
                        break;
                    default:
                        KeysAllTurnOn1();
                        LocksAllTurnOn1();
                        break;
                }
                if (Super1.CurrentLevel >= 2)
                    Abilities.IsEnabled = false;
                Abilities.Visibility = Visibility.Hidden;
                HeyPlaySomething(new Uri(@"Main_theme.mp3", UriKind.RelativeOrAbsolute));
            }
            else
            if (Foe1.EnemiesStillAlive <= 0)
            {
                Sound1.Stop();
                SEF(new Uri(@"YouWon.mp3", UriKind.RelativeOrAbsolute));
                Grid.SetColumn(BattleText1, 22);
                BattleText1.Content = "Победа!";
                BattleText2.Content = "Пора переходить к добыче";
                BattleText3.Content = "";
                ImgShow(Img4);
                LabShowX(new Label[] { BattleText1, BattleText2 });
                ButtonShow(textOk2);
            }
            else
            {
                if (HPbar.Value != 0)
                {
                    Time();
                }
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Super1.DefenseState = 2;
            FightMenuMakesDisappear();
            Time1.Value = 0;
            HP.Foreground = Brushes.White;
            if (Sets.SpecialBattle == 200)
            {
                FastImgChange(new Image[] { Img4, Img5 }, new BitmapImage[] { new BitmapImage(new Uri(@"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\PNG\SeriousSam.png", UriKind.RelativeOrAbsolute)), new BitmapImage(new Uri(@"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\PNG\IconSeriousSam.png", UriKind.RelativeOrAbsolute)) });
                if (HPbar.Value + 40 < HPbar.Maximum)
                    HPbar.Value += 40;
                else
                    HPbar.Value = HPbar.Maximum;
                
                if (APbar.Value + 20 < APbar.Maximum)
                    APbar.Value += 20;
                else
                    APbar.Value = APbar.Maximum;
                RefreshAllHPAP();
            }
            else
            {
                FastImgChange(new Image[] { Img4, Img5 }, new BitmapImage[] { new BitmapImage(new Uri(@"Defence.png", UriKind.RelativeOrAbsolute)), new BitmapImage(new Uri(@"IconDefence1.png", UriKind.RelativeOrAbsolute)) });
            }
            Lab2.Foreground = Brushes.White;
            Dj(new Uri(@"Defence.mp3", UriKind.RelativeOrAbsolute));
            Time();
        }

        private void Time()
        {
            if ((Time1.Value == 100) && (HPbar.Value != 0))
            {
                Super1.DefenseState = 1;
                Uri[] uriSources = new Uri[] { new Uri(@"pers5.png", UriKind.RelativeOrAbsolute), new Uri(@"person6.png", UriKind.RelativeOrAbsolute) };
                if (Super1.PlayerStatus == 0)
                    uriSources[1] = new Uri(@"person6.png", UriKind.RelativeOrAbsolute);
                else
                    uriSources[1] = new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute);
                if (Sets.SpecialBattle == 200)
                {
                    uriSources[0] = new Uri(@"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\PNG\SeriousSam.png", UriKind.RelativeOrAbsolute);
                    uriSources[1] = new Uri(@"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\PNG\IconSeriousSam.png", UriKind.RelativeOrAbsolute);
                }
                FastImgChange(new Image[] { Img4, Img5 }, new BitmapImage[] { new BitmapImage(uriSources[0]), new BitmapImage(uriSources[1]) });
                FightMenuBack();
                if (Sets.SpecialBattle == 200)
                {
                    BtnHideX(new Button[] { Button4, Items, Abilities });
                }
                Lab2.Foreground = Brushes.Yellow;
            }
            else
            {
                UInt16 GameSpeed1 = Convert.ToUInt16((240 / Super1.Speed) / GameSpeed.Value);
                WidelyUsedAnyTimer(out timer, Player_Time_Tick, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            }
        }
        private void TimeEnemy()
        {
            int aglfoe = 25;
            if ((Foe1.EnemyHP[0] != 0) || (Foe1.EnemyHP[1] != 0) || (Foe1.EnemyHP[2] != 0))
            {
                UInt16 GameSpeed1 = Convert.ToUInt16((50 - aglfoe) / GameSpeed.Value);
                WidelyUsedAnyTimer(out timer2, EnemyTime_Tick2, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            }
        }

        private int CheckEnemies(out UInt16 EnemyAttack, Byte pos)
        {
            EnemyAttack = 25;
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++)
            {
                if (Foe1.EnemyAppears[pos - 1] == Foe1.EnemyName[i])
                {
                    Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1, SecretBOSS1 };
                    EnemyAttack = FS[i].EnemyAttack;
                    break;
                }
            }
            return EnemyAttack;
        }
        private int GetOut(out Byte Speed)
        {
            Speed = 10;
            for (Byte i = 0; i < Foe1.EnemyAppears.Length; i++)
            {
                for (Byte j = 0; j < Foe1.EnemyName.Length; j++) {
                    if (Foe1.EnemyAppears[i] == Foe1.EnemyName[j])
                    {
                        Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1, SecretBOSS1 };
                        if (Speed < FS[j].EnemySpeed)
                            Speed = FS[j].EnemySpeed;
                    }
                }
            }
            return Speed;
        }

        private string NameEnemies(out string enemy, Byte pos)
        {
            enemy = "Паук";
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++)
            {
                if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[i])
                {
                    Foe.Stats[] FS = new Foe.Stats[] { Spider, Mummy, Zombie, Bones, BOSS1, SecretBOSS1 };
                    enemy = FS[i].EnemyName[i];
                    break;
                }
            }
            return enemy;
        }

        private string EnemySounds(in Byte pos)
        {
            string ogg = "";
            for (Byte i = 0; i < Foe1.EnemyName.Length; i++)
            {
                if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[i])
                {
                    string[] sounds = { "SpiderDied", "MummyDied", "ZombieDied", "BonesDied", "DefeatPharaoh" };
                    ogg = sounds[i];
                    break;
                }
            }
            return ogg;
        }
        private void EnemyOnAttack(in string enemy, in UInt16 dmg)
        {
            if (Sets.SpecialBattle!=200)
                HPbar.Value = HPbar.Value - dmg;
            else
            {
                if (APbar.Value - 10 >= 0)
                {
                    APbar.Value -= 10;
                    HPbar.Value = HPbar.Value - (dmg - 10);
                }
                else
                {
                    HPbar.Value = HPbar.Value - (dmg - APbar.Value);
                    APbar.Value = 0;
                }
                RefreshAllHPAP();
            }
            RefreshAllHP();
            BattleText6.Content = "-" + dmg;
            LabShow(BattleText6);
            HP.Foreground = Brushes.Red;
            UInt16 GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
            if (Sets.SpecialBattle != 200)
            {
                if (timer3 == null)
                {
                    WidelyUsedAnyTimer(out timer3, DamageTime_Tick3, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                    timer3.IsEnabled = true;
                }   
                else if (Img4.Source.ToString().Contains("pers5.png")&&(!timer3.IsEnabled)) {
                    WidelyUsedAnyTimer(out timer3, DamageTime_Tick3, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                    timer3.IsEnabled = true;
                }
            
                if (timer4 == null)
                {
                    WidelyUsedAnyTimer(out timer4, HurtTime_Tick4, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                    timer4.IsEnabled = true;
                }
                else if (!timer4.IsEnabled)
                {
                    WidelyUsedAnyTimer(out timer4, HurtTime_Tick4, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                    timer4.IsEnabled = true;
                }
            }
            GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
        }

        public static Byte PlayerHurt = 0;
        public static Byte PlayerHurtM = 0;
        public static Byte[] EnemyAtck = new Byte[] { 0, 0, 0 };
        //public static string DamageGet = "";
        private void DamageTime_Tick3(object sender, EventArgs e)
        {
            string[] HurtImg = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PersonHurts\\PersonHurts5.png" };
            Img4.Source = new BitmapImage(new Uri(HurtImg[PlayerHurt], UriKind.RelativeOrAbsolute));
            if (PlayerHurt == HurtImg.Length - 1)
            {
                HP.Foreground = Brushes.White;
                PlayerHurt = 0;
                Img4.Source = new BitmapImage(new Uri("/pers5.png", UriKind.RelativeOrAbsolute));
                timer3.Stop();
                timer3.IsEnabled = false;
            }
            else
                PlayerHurt++;
        }

        private void HurtTime_Tick4(object sender, EventArgs e)
        {
            Byte[] RowSet1 = { 17, 18, 19, 18, 19 };
            Byte[] ColumnSet1 = { 50, 51, 52, 53, 54 };
            if (PlayerHurtM == ColumnSet1.Length - 1)
            {
                PlayerHurtM = 0;
                timer4.Stop();
                timer4.IsEnabled = false;
                LabHide(BattleText6);
            }
            else
            {
                LabGrid(BattleText6, RowSet1[PlayerHurtM], ColumnSet1[PlayerHurtM]);
                PlayerHurtM++;
            }
        }

        private void FoeAttack1_Time_Tick5(object sender, EventArgs e)
        {
            string[] EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png" };
            string Enemy = "/Spider.png";
            switch (Foe1.EnemyAppears[0])
            {
                case "Мумия":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png" };
                    Enemy = "/Mummy.png";
                    break;
                case "Зомби":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png" };
                    Enemy = "/Zombie.png";
                    break;
                case "Страж":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png" };
                    Enemy = "/Bones.png";
                    break;
                case "Фараон":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png" };
                    Enemy = "/Pharaoh.png";
                    break;
                case "Угх-зан I":
                    EnemyAnimate = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks10.png" };
                    Enemy = "/UghZan.png";
                    break;
                default:
                    break;
            }
            Img6.Source = new BitmapImage(new Uri(EnemyAnimate[EnemyAtck[0]], UriKind.RelativeOrAbsolute));
            if (EnemyAtck[0] == EnemyAnimate.Length - 1)
            {
                if (Sets.SpecialBattle == 200)
                {
                    LabHide(BattleText6);
                    HP.Foreground = Brushes.White;
                }
                EnemyAtck[0] = 0;
                Img6.Source = new BitmapImage(new Uri(Enemy, UriKind.RelativeOrAbsolute));
                timer5.Stop();
            }
            else
            {
                Img6.Source = new BitmapImage(new Uri(EnemyAnimate[EnemyAtck[0]], UriKind.RelativeOrAbsolute));
                EnemyAtck[0]++;
            }
        }

        private void FoeAttack2_Time_Tick6(object sender, EventArgs e)
        {
            string[] EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png" };
            string Enemy = "/Spider.png";
            switch (Foe1.EnemyAppears[1])
            {
                case "Мумия":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png" };
                    Enemy = "/Mummy.png";
                    break;
                case "Зомби":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png" };
                    Enemy = "/Zombie.png";
                    break;
                case "Страж":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png" };
                    Enemy = "/Bones.png";
                    break;
                case "Фараон":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png" };
                    Enemy = "/Pharaoh.png";
                    break;
                case "Угх-зан I":
                    EnemyAnimate = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks10.png" };
                    Enemy = "/UghZan.png";
                    break;
                default:
                    break;
            }
            Img7.Source = new BitmapImage(new Uri(EnemyAnimate[EnemyAtck[1]], UriKind.RelativeOrAbsolute));
            if (EnemyAtck[1] == EnemyAnimate.Length - 1)
            {
                EnemyAtck[1] = 0;
                Img7.Source = new BitmapImage(new Uri(Enemy, UriKind.RelativeOrAbsolute));
                timer6.Stop();
            }
            else
            {
                Img7.Source = new BitmapImage(new Uri(EnemyAnimate[EnemyAtck[1]], UriKind.RelativeOrAbsolute));
                EnemyAtck[1]++;
            }
        }

        private void FoeAttack3_Time_Tick7(object sender, EventArgs e)
        {
            string[] EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SpiderAttacks\\SpiderAttacks1.png" };
            string Enemy = "/Spider.png";
            switch (Foe1.EnemyAppears[2])
            {
                case "Мумия":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\MummyAttacks\\MummyAttacks1.png" };
                    Enemy = "/Mummy.png";
                    break;
                case "Зомби":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ZombieAttacks\\ZombieAttacks1.png" };
                    Enemy = "/Zombie.png";
                    break;
                case "Страж":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\BonesAttacks\\BonesAttacks1.png" };
                    Enemy = "/Bones.png";
                    break;
                case "Фараон":
                    EnemyAnimate = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\PharaohAttacks\\PharaohAttacks.png" };
                    Enemy = "/Pharaoh.png";
                    break;
                case "Угх-зан I":
                    EnemyAnimate = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\UghZan1Attacks\UghZan1Attacks10.png" };
                    Enemy = "/UghZan.png";
                    break;
                default:
                    break;
            }
            Img8.Source = new BitmapImage(new Uri(EnemyAnimate[EnemyAtck[2]], UriKind.RelativeOrAbsolute));
            if (EnemyAtck[2] >= EnemyAnimate.Length - 1)
            {
             EnemyAtck[2] = 0;
             Img8.Source = new BitmapImage(new Uri(Enemy, UriKind.RelativeOrAbsolute));
             timer7.Stop();
            }
            else
            {
             Img8.Source = new BitmapImage(new Uri(EnemyAnimate[EnemyAtck[2]], UriKind.RelativeOrAbsolute));
             EnemyAtck[2]++;
            }
        }

        private void EnemyTime_Tick2(object sender, EventArgs e)
        {
            if (HPbar.Value == 0)
            {
                Super1.PlayerStatus = 0;
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                LabHide(BattleText3);
                MediaShow(GameOver);
                GameOver.Play();
                if (timer != null)
                    timer.Stop();
                timer2.Stop();
            }
            if ((Super1.PlayerStatus == 1) && (HPbar.Value != 0))
            {
                if (poison < 30)
                {
                    poison += 1;
                }
                else
                {
                    poison = 0;
                    HPbar.Value = HPbar.Value - 1;
                    RefreshAllHP();
                }
            }
            string enemy = "";
            UInt16 EnemyAttack = 25;
            UInt16 PlayerDef = Convert.ToUInt16(Super1.Defence * Super1.DefenseState + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3]);
            Uri uriSource = new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute);
            if (((Foe1.EnemyHP[0] != 0) || (Foe1.EnemyHP[1] != 0) || (Foe1.EnemyHP[2] != 0)) && (HPbar.Value != 0))
            {
                if (Foe1.EnemyHP[0] != 0)
                    if (Foe1.EnemyTurn[0] == 200)
                    {
                        Foe1.EnemyTurn[0] = 0;
                        CheckEnemies(out EnemyAttack, 1);
                        NameEnemies(out enemy, 1);
                        if (EnemyAttack > PlayerDef)
                        {
                            UInt16 GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
                            WidelyUsedAnyTimer(out timer5, FoeAttack1_Time_Tick5, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                            UInt16 dmg = Convert.ToUInt16(EnemyAttack - PlayerDef);
                            EnemyOnAttack(enemy, dmg);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[0] == "Паук"))
                            {
                                Img5.Source = new BitmapImage(uriSource);
                                LabShow(BattleText2);
                                BattleText2.Content = "Рэй отравлен!";
                                Super1.PlayerStatus = 1;
                            }
                            LabShow(BattleText1);
                        }
                    }
                    else
                        Foe1.EnemyTurn[0] += 1;
                if (Foe1.EnemyHP[1] != 0)
                    if (Foe1.EnemyTurn[1] == 200)
                    {
                        CheckEnemies(out EnemyAttack, 1);
                        NameEnemies(out enemy, 1);
                        Foe1.EnemyTurn[1] = 0;
                        if (EnemyAttack > PlayerDef)
                        {
                            UInt16 GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
                            WidelyUsedAnyTimer(out timer6, FoeAttack2_Time_Tick6, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                            UInt16 dmg = Convert.ToUInt16(EnemyAttack - PlayerDef);
                            EnemyOnAttack(enemy, dmg);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[1] == "Паук"))
                            {
                                Img5.Source = new BitmapImage(uriSource);
                                LabShow(BattleText2);
                                BattleText2.Content = "Рэй отравлен!";
                                Super1.PlayerStatus = 1;
                            }
                            LabShow(BattleText1);
                        }
                    }
                    else
                        Foe1.EnemyTurn[1] += 1;
                if (Foe1.EnemyHP[2] != 0)
                    if (Foe1.EnemyTurn[2] == 200)
                    {
                        Foe1.EnemyTurn[2] = 0;
                        CheckEnemies(out EnemyAttack, 1);
                        NameEnemies(out enemy, 1);
                        if (EnemyAttack > PlayerDef)
                        {
                            UInt16 GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
                            WidelyUsedAnyTimer(out timer7, FoeAttack3_Time_Tick7, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                            UInt16 dmg = Convert.ToUInt16(EnemyAttack - PlayerDef);
                            EnemyOnAttack(enemy, dmg);
                            if ((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && (Foe1.EnemyAppears[2] == "Паук"))
                            {
                                Img5.Source = new BitmapImage(uriSource);
                                LabShow(BattleText2);
                                BattleText2.Content = "Рэй отравлен!";
                                Super1.PlayerStatus = 1;
                            }
                            LabShow(BattleText1);
                        }
                    }
                    else
                        Foe1.EnemyTurn[2] += 1;
                if ((Foe1.EnemyTurn[0] == 15) || (Foe1.EnemyTurn[1] == 15) || (Foe1.EnemyTurn[2] == 15))
                {
                    if (Convert.ToString(BattleText2.Content) == "Рэй отравлен!")
                    {
                        LabHide(BattleText2);
                    }
                    LabHide(BattleText1);
                }
            }
        }

        private void Player_Time_Tick(object sender, EventArgs e)
        {
            if (Time1.Value < 100)
                Time1.Value += 1;
            else
            {
                timer.Stop();
                Time();
            }

        }

        private void Skip1_Click(object sender, RoutedEventArgs e)
        {
            ButtonHide(Skip1);
            Med1.Position = new TimeSpan(0, 0, 0, 7, 500);
        }

        private void Sound1_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound1.Stop();
            Sound1.Position = TimeSpan.Zero;
            Sound1.Play();
        }
        private void FightMenuMakesDisappear()
        {
            BtnHideX(new Button[] { Button2, Button3, Button4, Abilities, Items });
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Byte agl = Super1.Speed;
            Byte fagl = 10;
            FightMenuMakesDisappear();
            GetOut(out fagl);
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            if (agl > fagl)
            {
                timer2.Stop();
                speed = 1;
            }
            else
            {
                BattleText2.Content = "Не удается сбежать!";
                LabShow(BattleText2);
            }
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Escape_Time_Tick9, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            Dj(new Uri(@"Escape.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Med4_MediaEnded(object sender, RoutedEventArgs e)
        {
            Med4Stop();
        }

        private void Med4Stop()
        {
            Med4.Position = new TimeSpan(0, 0, 0, 0, 0);
            MediaHide(Med4);
            if (!Img2.IsEnabled)
            {
                if (Super1.PlayerStatus == 0)
                {
                    Img5.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
                }
                if (HPbar.Value != 0)
                    ImgShow(Img5);
            }
        }
        private void FightMenuBack()
        {
            BtnShowX(new Button[] { Button2, Button3 });
            if (Sets.SpecialBattle != 200) {
                if (Sets.SpecialBattle == 0)
                    ButtonShow(Button4);
                else
                {
                    Button4.Visibility = Visibility.Visible;
                }
                BtnShowX(new Button[] { Abilities, Items });
                if (Super1.CurrentLevel <= 1)
                    Abilities.IsEnabled = false;
            }
        }
        private void Trgt_MediaEnded(object sender, RoutedEventArgs e)
        {
            Trgt.Stop();
            Med1.Position = new TimeSpan(0, 0, 0, 0, 0);
            Trgt.Play();
        }
        public static Byte SelectedTrgt = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer9.Stop();
            ImgHideX(new Image[] { TrgtImg, EnemyImg });
            UInt16 strength = Convert.ToUInt16(Super1.Attack + Super1.PlayerEQ[0]);
            Byte PharaohAura = 0;
            LabHide(BattleText1);
            SelectedTrgt = Sets.SelectedTarget;
            UInt16 GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer10, DamageFoe_Time_Tick17, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            
            if (Sets.SpecialBattle==1)
            {
                PharaohAura = 25;
            }
            LabShow(BattleText1);
            BarHide(HPenemyBar);
            LabHide(HPenemy);
            BtnHideX(new Button[] { Fight, Cancel1 });

            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;

            if (Foe1.EnemyHP[Sets.SelectedTarget] - (strength - PharaohAura) < 0)
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = 0;
            }
            else
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = Convert.ToUInt16(Foe1.EnemyHP[Sets.SelectedTarget] - (strength - PharaohAura));
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                string res = EnemySounds(Sets.SelectedTarget);
                SEF(new Uri(@"" + res + ".mp3", UriKind.RelativeOrAbsolute));
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                switch (Sets.SelectedTarget)
                {
                    case 0:
                        ImgHide(Img6);
                        break;
                    case 1:
                        ImgHide(Img7);
                        break;
                    case 2:
                        ImgHide(Img8);
                        break;
                }
                SuperCheckFoes(Sets.SelectedTarget);

                if (Foe1.EnemyHP[0] != 0)
                    Sets.SelectedTarget = 0;
                else if (Foe1.EnemyHP[1] != 0)
                    Sets.SelectedTarget = 1;
                else if (Foe1.EnemyHP[2] != 0)
                    Sets.SelectedTarget = 2;
                
                Byte[] grRow = new Byte[] { 23, 15, 21 };
                Byte[] grColumn = new Byte[] { 2, 13, 24 };
                Grid.SetRow(TrgtImg, grRow[Sets.SelectedTarget]);
                Grid.SetColumn(TrgtImg, grColumn[Sets.SelectedTarget]);
                Foe1.EnemiesStillAlive = Convert.ToByte(Foe1.EnemiesStillAlive - 1);
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                {
                    if (Foe1.EnemiesStillAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText6);
                        BattleText6.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }

                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Угх-зан I")
                {
                    if (Foe1.EnemiesStillAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        LabHide(BattleText6);
                        BattleText6.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }

                }
            }
            GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            if (Sets.SpecialBattle==200)
            {
                WidelyUsedAnyTimer(out timer8, SeriousMinigun_Time_Tick39, new TimeSpan(0, 0, 0, 0, GameSpeed1));

            }
            else
            {
                WidelyUsedAnyTimer(out timer8, HandAttack_Time_Tick8, new TimeSpan(0, 0, 0, 0, GameSpeed1));                
            }
            Dj(new Uri(@"Punch.mp3", UriKind.RelativeOrAbsolute));
            
        }

        public static Byte Actions = 0;
   
        private void SeriousMinigun_Time_Tick39(object sender, EventArgs e)
        {
            string[] SSam = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun10.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun11.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun12.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun13.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun14.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSamMinigun\SeriousSamMinigun15.png" };
            string[] IcoSS = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconSeriousSamMinigun\IconSeriousSamMinigun1.png" };
            ActionsTickCheck(SSam, IcoSS);
        }
        private void SeriousSwitch_Time_Tick45(object sender, EventArgs e)
        {
            string[] SSam = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\SeriousSwitch\SeriousSwitch9.png", };
            string[] IcoSS = new string[] { @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked1.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked2.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked3.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked4.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked5.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked6.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked7.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked8.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked9.png", @"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\IconShocked\IconShocked10.png", };
            ActionsTickCheck(SSam, IcoSS);
        }
        private void HandAttack_Time_Tick8(object sender, EventArgs e)
        {
            string[] HndAt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HandAttack\\HandAttack10.png" };
            string[] IcoRg = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconRage\\IconRage10.png" };
            ActionsTickCheck(HndAt, IcoRg);
        }


        private void Escape_Time_Tick9(object sender, EventArgs e)
        {
            string[] Flee = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Escape\\Escape2.png" };
            string[] IcoEs = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconEscape\\IconEscape2.png" };
            ActionsTickCheck(Flee, IcoEs);
        }

        private void Items_Time_Tick10(object sender, EventArgs e)
        {
            string[] ItmUs = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\ItemsUsed\\ItemUsed1.png" };
            string[] IcoUs = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconItemUsed\\IconItemUsed10.png" };
            ActionsTickCheck(ItmUs, IcoUs);
        }

        private void Cure_Time_Tick11(object sender, EventArgs e)
        {
            string[] Cure = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Cure\\Cure10.png" };
            string[] IcoCr = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconCure\\IconCure10.png" };
            ActionsTickCheck(Cure, IcoCr);
        }

        private void Heal_Time_Tick12(object sender, EventArgs e)
        {
            string[] Heal = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Heal\\Heal10.png" };
            string[] IcoHl = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\HealIcon\\HealIcon10.png" };
            ActionsTickCheck(Heal, IcoHl);
        }

        private void Torch_Time_Tick13(object sender, EventArgs e)
        {
            string[] Torch = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Torch\\Torch10.png" };
            string[] IcoTh = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\IconTorch\\IconTorch10.png" };
            ActionsTickCheck(Torch, IcoTh);
        }
        private void Whip_Time_Tick14(object sender, EventArgs e)
        {
            string[] Whip = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Whip\\Whip10.png" };
            string[] IcoWp = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\WhipIcon\\WhipIcon10.png" };
            ActionsTickCheck(Whip, IcoWp);
        }

        private void Super_Time_Tick15(object sender, EventArgs e)
        {
            string[] Super = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Super\\Super5.png" };
            string[] IcoSr = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\SuperIcon\\SuperIcon4.png" };
            ActionsTickCheck(Super, IcoSr);
        }

        private void Target_Time_Tick16(object sender, EventArgs e)
        {
            string[] Trgt = new string[] { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\Target\\Target2.png" };
            UnlimitedActionsTickCheck(Trgt);
        }

        public static UInt16 FoeDamage = 0;

        private void DamageFoe_Time_Tick17(object sender, EventArgs e)
        {
            UInt16 strength = Convert.ToUInt16(Super1.Attack + Super1.PlayerEQ[0]);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = Convert.ToUInt16(strength);
            FoesKicked();
        }

        private void CureHP_Time_Tick18(object sender, EventArgs e)
        {
            UInt16 curepower = Convert.ToUInt16(Super1.Special * 2);
            CureHealTxt.Content = "+" + curepower;
            CureOrHeal();
        }
        private void HealPsn_Time_Tick19(object sender, EventArgs e)
        {
            CureHealTxt.Content = "-Яд";
            CureOrHeal();
        }
        private void TorchDmg_Time_Tick20(object sender, EventArgs e)
        {
            UInt16 trchsp = Convert.ToUInt16(Super1.Special);
            if ((Foe1.EnemyAppears[SelectedTrgt] == "Паук") || (Foe1.EnemyAppears[SelectedTrgt] == "Мумия"))
            {
                trchsp = Convert.ToUInt16(trchsp * 2.5);
            }
            else
            {
                if (Foe1.EnemyAppears[SelectedTrgt] == "Фараон")
                    trchsp = Convert.ToUInt16(trchsp * 0.5);
                else
                    trchsp = Convert.ToUInt16(trchsp * 1.25);
            }
            if (Foe1.EnemyAppears[0] == "Угх-Зан I")
                trchsp = 0;
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = Convert.ToUInt16(trchsp);
            FoesKicked();
        }

        private void WhipDmg_Time_Tick21(object sender, EventArgs e)
        {
            UInt16 whipsp = Convert.ToUInt16(Super1.Special);
            if ((Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби") || (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж"))
            {
                whipsp = Convert.ToUInt16(whipsp * 3);
            }
            else
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                    whipsp = Convert.ToUInt16(whipsp * 0.75);
                else
                    whipsp = Convert.ToUInt16(whipsp * 1.5);
            }
            if (Foe1.EnemyAppears[0] == "Угх-Зан I")
                whipsp = 0;
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = Convert.ToUInt16(whipsp);
            FoesKicked();
        }

        private void SuperDmg_Time_Tick22(object sender, EventArgs e)
        {
            UInt16 supersp = Convert.ToUInt16(Super1.Special);
            if (Foe1.EnemyAppears[0] != "Фараон")
                supersp *= 2;
            if (Foe1.EnemyAppears[0] == "Угх-Зан I")
                supersp = 0;
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            if (Foe1.EnemyHP[0] != 0)
                Labs[0].Content = Convert.ToUInt16(supersp);
            if (Foe1.EnemyHP[1] != 0)
                Labs[1].Content = Convert.ToUInt16(supersp);
            if (Foe1.EnemyHP[2] != 0)
                Labs[2].Content = Convert.ToUInt16(supersp);
            FoesKicked();
        }
        private void Bandage_Time_Tick23(object sender, EventArgs e)
        {
            CureHealTxt.Content = "+50";
            CureOrHeal();
        }

        private void Ether_Time_Tick24(object sender, EventArgs e)
        {
            RecoverAPTxt.Content = "+50";
            RestoreAP();
        }

        private void Fused_Time_Tick25(object sender, EventArgs e)
        {
            CureHealTxt.Content = "+80";
            RecoverAPTxt.Content = "+80";
            CureOrHeal();
            RestoreAP();
        }

        private void Antidote_Time_Tick26(object sender, EventArgs e)
        {
            CureHealTxt.Content = "-Яд";
            CureOrHeal();
        }

        public static Byte CureCurrent = 0;
        public static Byte RAPCurrent = 0;
        private void CureOrHeal()
        {
            Byte[] RowSet2 = { 22, 21, 20, 19, 18 };
            if (!CureHealTxt.IsEnabled)
                LabShow(CureHealTxt);
            if (CureCurrent == RowSet2.Length - 1)
            {
                CureCurrent = 0;
                timer11.Stop();
                LabHide(CureHealTxt);
            }
            else
            {
                Grid.SetRow(CureHealTxt, RowSet2[CureCurrent]);
                CureCurrent++;
            }
        }
        private void RestoreAP()
        {
            Byte[] RowSet2 = { 24, 23, 22, 21, 20 };
            if (!RecoverAPTxt.IsEnabled)
                LabShow(RecoverAPTxt);
            if (RAPCurrent == RowSet2.Length - 1)
            {
                RAPCurrent = 0;
                timer11.Stop();
                LabHide(RecoverAPTxt);
            }
            else
            {
                Grid.SetRow(RecoverAPTxt, RowSet2[RAPCurrent]);
                RAPCurrent++;
            }
        }

        private void FoesKicked()
        {
            Byte[,] RowSet2 = new Byte[,] { { 26, 25, 26, 25, 26 }, { 18, 17, 18, 17, 18 }, { 24, 23, 24, 23, 24 } };
            Byte[,] ColumnSet2 = new Byte[,] { { 4, 3, 2, 1, 0 }, { 15, 14, 13, 12, 11 }, { 26, 25, 24, 23, 22 } };
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            if (SelectedTrgt != 4)
            {
                if (!Labs[SelectedTrgt].IsEnabled)
                    LabShow(Labs[SelectedTrgt]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    timer10.Stop();
                    LabHide(Labs[SelectedTrgt]);
                }
                else
                {
                    LabGrid(Labs[SelectedTrgt], RowSet2[SelectedTrgt, FoeDamage], ColumnSet2[SelectedTrgt, FoeDamage]);
                    FoeDamage++;
                }
            }
            else
            {
                if ((!Labs[0].IsEnabled) && (Foe1.EnemyHP[0] != 0))
                    LabShow(Labs[0]);
                if ((!Labs[1].IsEnabled) && (Foe1.EnemyHP[1] != 0))
                    LabShow(Labs[1]);
                if ((!Labs[2].IsEnabled) && (Foe1.EnemyHP[1] != 0))
                    LabShow(Labs[2]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    timer10.Stop();
                    LabHideX(Labs);
                }
                else
                {
                    if (Foe1.EnemyHP[0] != 0)
                    {
                        LabGrid(Labs[0], RowSet2[0, FoeDamage], ColumnSet2[0, FoeDamage]);
                    }
                    if (Foe1.EnemyHP[1] != 0)
                    {
                        LabGrid(Labs[1], RowSet2[1, FoeDamage], ColumnSet2[1, FoeDamage]);
                    }
                    if (Foe1.EnemyHP[2] != 0)
                    {
                        LabGrid(Labs[2], RowSet2[2, FoeDamage], ColumnSet2[2, FoeDamage]);
                    }
                    FoeDamage++;
                }
            }
        }
        private void IconActions(Image icon, in string[] ico)
        {
            icon.Source = new BitmapImage(new Uri(ico[Actions], UriKind.RelativeOrAbsolute));
            if (Actions == ico.Length - 1)
            {
                Actions = 0;
                icon.Source = new BitmapImage(new Uri("/person6.png", UriKind.RelativeOrAbsolute));
                timer2.Stop();
            }
            else
                Actions++;
        }
        private void ActionsTickCheck(in string[] pers, in string[] ico)
        {
            FastImgChange(new Image[] { Img4, Img5 }, new BitmapImage[] { new BitmapImage(new Uri(pers[Actions], UriKind.RelativeOrAbsolute)), new BitmapImage(new Uri(ico[Actions], UriKind.RelativeOrAbsolute)) });
            if (Actions == pers.Length - 1)
            {
                Actions = 0;
                if (Sets.SpecialBattle!=200)
                    Img4.Source = new BitmapImage(new Uri("/pers5.png", UriKind.RelativeOrAbsolute));
                else
                    Img4.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\PNG\SeriousSam.png", UriKind.RelativeOrAbsolute));
                if (Sets.SpecialBattle != 200)
                {
                    if (Super1.PlayerStatus == 1)
                        Img5.Source = new BitmapImage(new Uri("/IconPoisoned.png", UriKind.RelativeOrAbsolute));
                    else
                        Img5.Source = new BitmapImage(new Uri("/person6.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    Img5.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\Учёба, ПТК НовГУ\3 курс\Курсовая\PNG\IconSeriousSam.png", UriKind.RelativeOrAbsolute));
                }
                AfterAction();
                timer8.Stop();
            }
            else
            {
                Actions++;
            }
        }
        public static Byte trgt = 0;
        private void UnlimitedActionsTickCheck(in string[] spec)
        {
            TrgtImg.Source = new BitmapImage(new Uri(spec[trgt], UriKind.RelativeOrAbsolute));
            if (trgt == spec.Length - 1)
                trgt = 0;
            else
                trgt++;
        }

        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            timer9.Stop();
            BtnHideX(new Button[] { Fight, Cancel1 });
            FightMenuBack();
            if (Sets.SpecialBattle == 200)
            {
                BtnHideX(new Button[] { Button4, Items, Abilities });
            }
            LabHideX(new Label[] { HPenemy, BattleText1 });
            ImgHideX(new Image[] { EnemyImg, TrgtImg });
            BarHide(HPenemyBar);
        }

        private void Win_MediaEnded(object sender, RoutedEventArgs e)
        {
            WinStop();
            HideAfterBattleMenu();
        }

        private void WinStop()
        {
            WonOrDied();
            switch (Sets.LockIndex)
            {
                case 0:
                    break;
                case 1:
                    ImgShowX(new Image[] { KeyImg3, LockImg3 });
                    break;
                case 2:
                    ImgShowX(new Image[] { KeyImg2, LockImg2, KeyImg3, LockImg3 });
                    break;
                case 3:
                    KeysAllTurnOn1();
                    LocksAllTurnOn1();
                    break;
                default:
                    KeysAllTurnOn1();
                    LocksAllTurnOn1();
                    break;
            }
            ImgShowX(new Image[] { Threasure1, Img2 });
            ChestsAllTurnOn1();
            TablesAllTurnOn1();
            if (Sets.TableEN)
                ImgShow(TableMessage1);
            MediaHide(Win);
            Win.Position = new TimeSpan(0, 0, 0, 0, 0);
            ImgHide(Img5);
            HeyPlaySomething(new Uri(@"Main_theme.mp3", UriKind.RelativeOrAbsolute));
        }
        private void Sound2_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound2.Stop();
        }

        private void Win_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            WonOrDied();
            Win.Stop();
            ImgShow(Img2);
        }

        private void HideAfterBattleMenu()
        {
            LabHideX(new Label[] { NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, ExpText, AfterLevel, AfterName, AfterStatus, BeforeParams, BeforeHPtxt, BeforeAPtxt, BeforeHP, BeforeAP, BeforeAttack, BeforeDefence, BeforeAgility, BeforeSpecial, BeforeATK, BeforeDEF, BeforeAG, BeforeSP, AfterBattleGet, MaterialsGet, MaterialsOnHand, MaterialsAdd, ItemsGet, ItemsGetSlot1 });
            ImgHideX(new Image[] { AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg, AfterBattleMenuImg, AfterIcon, BeforeAttackImg, BeforeDefenceImg, BeforeAgilityImg, BeforeSpecialImg, MaterialsGetImg });
            BarHideX(new ProgressBar[] { AfterHPbar, AfterAPbar, NextExpBar, BeforeHPbar, BeforeAPbar });
            ButtonHide(TextOk1);
        }

        private void TextOk1_Click(object sender, RoutedEventArgs e)
        {
            Win.Source = new Uri(@"Win.mp4", UriKind.RelativeOrAbsolute);
            if (Sets.SpecialBattle == 0)
            {
                MediaShow(Win);
                LabHideX(new Label[] { BattleText1, BattleText2, BattleText3 });
                ImgHide(Img1);
            }
            else
            {
                ImgGrid(Img6, 18, 2);
                ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
                LabHideX(new Label[] { BattleText1, BattleText2, BattleText3 });
                switch (Sets.SpecialBattle)
                {
                    case 1:
                        HideAfterBattleMenu();
                        MediaShow(TheEnd);
                        Img1.Source = new BitmapImage(new Uri(@"AbsoluteBlack.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 200:
                        MediaShow(Win);
                        LabHideX(new Label[] { BattleText1, BattleText2, BattleText3 });
                        ImgHide(Img1);
                        break;
                    default:
                        MediaShow(Win);
                        LabHideX(new Label[] { BattleText1, BattleText2, BattleText3 });
                        ImgHide(Img1);
                        break;
                }
            }
            Sound1.Stop();
            ImgShow(Img1);
        }
        private void BarHideX(ProgressBar[] ProgressBarArray)
        {
            foreach (ProgressBar Bar in ProgressBarArray)
            {
                BarHide(Bar);
            }
        }
        private void WonOrDied()
        {
            Sound1.Stop();
            LabHideX(new Label[] { BattleText1, BattleText2, BattleText3, Lab2, HPtext, APtext, LevelText, HP, AP, ATK, SP });
            BtnHideX(new Button[] { TextOk1, Button2, Button3, Button4, Items, Abilities, textOk2 });
            BarHideX(new ProgressBar[] { HPbar, APbar, Time1 });
            ImgHideX(new Image[] { Img3, Img4, Img5, Img6, Img7, Img8, TimeTurnImg });
            
        }
        public void TextCh1()
        {
            LabShow(BattleText2);
        }

        public void DisableBattleText()
        {
            LabHide(BattleText2);
        }

        private void Button4_MouseEnter(object sender, MouseEventArgs e)
        {
            EscapeFromBattleImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\EscapeAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Сбежать из боя";
            TextCh1();
        }

        private void Button4_MouseLeave(object sender, MouseEventArgs e)
        {
            EscapeFromBattleImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\EscapeBeforeImg.png", UriKind.RelativeOrAbsolute));
            DisableBattleText();
        }

        private void Button3_MouseEnter(object sender, MouseEventArgs e)
        {
            DefenceImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\DefenceAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Встать в стойку (Защита Х2)";
            TextCh1();
        }

        private void Button3_MouseLeave(object sender, MouseEventArgs e)
        {
            DefenceImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\DefenceBeforeImg.png", UriKind.RelativeOrAbsolute));
            DisableBattleText();
        }

        private void Button2_MouseEnter(object sender, MouseEventArgs e)
        {
            FightImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\FightAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Атаковать выбранного врага";
            TextCh1();
        }

        private void Button2_MouseLeave(object sender, MouseEventArgs e)
        {
            FightImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\FightBeforeImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Подтвердить выбор";
            DisableBattleText();
        }

        private void Cancel1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Отменить нападение";
            TextCh1();
        }

        private void Cancel1_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Fight_MouseEnter(object sender, MouseEventArgs e)
        {
            SelectTrgt1Img.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Подтвердить выбор";
            TextCh1();
        }

        private void Fight_MouseLeave(object sender, MouseEventArgs e)
        {
            SelectTrgt1Img.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectBeforeImg.png", UriKind.RelativeOrAbsolute));
            if (Foe1.EnemyHP[Sets.SelectedTarget] != 0)
                DisableBattleText();
        }

        private void HideFightIconPersActions()
        {
            BarHide(HPenemyBar);
            LabHideX(new Label[] { BattleText4, BattleText5, BattleText6, HPenemy, ItemText });
            ImgHideX(new Image[] { ItemsCountImg, Img4, Img5, TrgtImg });
            BtnHideX(new Button[] { Cure, Heal, Torch, Whip, Super, Back1, Button2, Button3, Button4, Items, Abilities, Fight, Cancel1, ACT1, ACT2, Cancel2 });
        }

        private void GameOver_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaHide(GameOver);
            GameOver.Stop();
            if (timer != null)
                timer.Stop();
            WonOrDied();
            ChestsAllTurnOff1();
            KeysAllTurnOff1();
            LocksAllTurnOff1();
            TablesAllTurnOff1();
            ImgHide(Threasure1);
            HideFightIconPersActions();
            ImgShow(Img1);
            ButtonShow(Button1);
            LabShow(Lab1);
            Sound1.Position = new TimeSpan(0, 0, 0, 0, 0);
            Img1.Source = new BitmapImage(new Uri(@"New_game_show.jpg", UriKind.RelativeOrAbsolute));
            HeyPlaySomething(new Uri(@"Begin2.mp3", UriKind.RelativeOrAbsolute));
            BtnHideX(new Button[] { Button2, Button3, Button4 });
        }

        private void AbilitiesMakeDisappear1()
        {
            BtnHideX(new Button[] { Cure, Torch, Heal, Back1, Whip, Super, SwitchAbils });
        }
        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            AbilitiesMakeDisappear1();
            FightMenuBack();
        }

        private void Back1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Вернуться к действиям";
            TextCh1();
        }

        private void Back1_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Cure_Click(object sender, RoutedEventArgs e)
        {
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Cure_Time_Tick11, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            GameSpeed1 = Convert.ToUInt16(75 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer11, CureHP_Time_Tick18, new TimeSpan(0, 0, 0, 0, GameSpeed1));            
            Dj(new Uri(@"Cure.mp3", UriKind.RelativeOrAbsolute));
            if (((Super1.Special * 2) + HPbar.Value) >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
            }
            else
            {
                HPbar.Value = HPbar.Value + Super1.Special * 2;
            }
            APbar.Value -= 5;
            RefreshAllHPAP();
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
        }

        private void Cure_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит ОЗ, Стоит: 2 ОД";
            TextCh1();
        }

        private void Cure_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Abilities_Click(object sender, RoutedEventArgs e)
        {
            CheckAccessAbilities(new Button[] { Cure, Heal }, new Byte[] { 2, 4 }, new Byte[] { 5, 3 });
            ButtonShow(SwitchAbils);
            ButtonShow(Back1);
            ToNextImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ToNext.png", UriKind.RelativeOrAbsolute));
            FightMenuMakesDisappear();
        }

        private void Abilities_MouseEnter(object sender, MouseEventArgs e)
        {
            AbilitiesImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\SkillsAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Особые умения";
            TextCh1();
        }

        private void Abilities_MouseLeave(object sender, MouseEventArgs e)
        {
            AbilitiesImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\SkillsBeforeImg.png", UriKind.RelativeOrAbsolute));
            DisableBattleText();
        }

        private void LevelUpShow()
        {
            LabShowX(new Label[] { NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP });
            ImgShowX(new Image[] { AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg });
            BarShowX(new ProgressBar[] { AfterHPbar, AfterAPbar });
        }
        private void AddingStats_Time_Tick41(object sender, EventArgs e)
        {
            if ((CurrentNextHPAP[0] < Super1.MaxHP) || (CurrentNextHPAP[1] < Super1.MaxAP) || (CurrentNextParams[0] < Super1.Attack) || (CurrentNextParams[1] < Super1.Defence) || (CurrentNextParams[2] < Super1.Speed) || (CurrentNextParams[3] < Super1.Special))
            {
                if (CurrentNextHPAP[0] < Super1.MaxHP)
                {
                    CurrentNextHPAP[0]++;
                    AddHP.Content = "+" + (Super1.MaxHP - CurrentNextHPAP[0]);
                    AfterHP.Content = HPbar.Value + "/" + CurrentNextHPAP[0];
                    HPbar.Width = CurrentNextHPAP[0];
                    AfterHPbar.Width = CurrentNextHPAP[0];
                    HPbar.Maximum = CurrentNextHPAP[0];
                    AfterHPbar.Maximum = CurrentNextHPAP[0];
                }
                else
                {
                    LabHide(AddHP);
                }

                if (CurrentNextHPAP[1] < Super1.MaxAP)
                {
                    CurrentNextHPAP[1]++;
                    AddAP.Content = "+" + (Super1.MaxAP - CurrentNextHPAP[1]);
                    AfterAP.Content = APbar.Value + "/" + CurrentNextHPAP[1];
                    APbar.Width = CurrentNextHPAP[1];
                    AfterAPbar.Width = CurrentNextHPAP[1];
                    APbar.Maximum = CurrentNextHPAP[1];
                    AfterAPbar.Maximum = CurrentNextHPAP[1];
                }
                else
                {
                    LabHide(AddAP);
                }

                if (CurrentNextParams[0] < Super1.Attack)
                {
                    CurrentNextParams[0]++;
                    AddATK.Content = "+" + (Super1.Attack - CurrentNextParams[0]);
                    AfterATK.Content = CurrentNextParams[0];
                }
                else
                {
                    LabHide(AddATK);
                }

                if (CurrentNextParams[1] < Super1.Defence)
                {
                    CurrentNextParams[1]++;
                    AddDEF.Content = "+" + (Super1.Defence - CurrentNextParams[1]);
                    AfterDEF.Content = CurrentNextParams[1];
                }
                else
                {
                    LabHide(AddDEF);
                }

                if (CurrentNextParams[2] < Super1.Speed)
                {
                    CurrentNextParams[2]++;
                    AddAG.Content = "+" + (Super1.Speed - CurrentNextParams[2]);
                    AfterAG.Content = CurrentNextParams[2];
                }
                else
                {
                    LabHide(AddAG);
                }

                if (CurrentNextParams[3] < Super1.Special)
                {
                    CurrentNextParams[3]++;
                    AddSP.Content = "+" + (Super1.Special - CurrentNextParams[3]);
                    AfterSP.Content = CurrentNextParams[3];
                }
                else
                {
                    LabHide(AddSP);
                }
            }
            else
            {
                timer13.Stop();
                LabHideX(new Label[] { AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP });
                ButtonShow(TextOk1);
            }
        }
        private void AddingMaterials_Time_Tick42(object sender, EventArgs e)
        {
            if ((Mat > 0) && (BAG.Materials + 1 < 65535))
            {
                BAG.Materials++;
                MaterialsOnHand.Content = BAG.Materials;
                Mat--;
                MaterialsAdd.Content = "+" + Mat;
            } else
            {
                Mat = 0;
                LabHide(MaterialsAdd);
                timer.Stop();
            }
        }
        private void Levelling_Time_Tick40(object sender, EventArgs e)
        {
            if ((Exp > 0) && (Super1.CurrentLevel < 10)) {
                if (NextExpBar.Value + 1 >= NextExpBar.Maximum)
                {
                    if (Super1.CurrentLevel < 10) {
                        Super1.CurrentLevel += 1;
                        Super1.Attack = Super1.AttackNxt[Super1.CurrentLevel - 1];
                        Super1.Defence = Super1.DefenseNxt[Super1.CurrentLevel - 1];
                        Super1.Speed = Super1.SpeedNxt[Super1.CurrentLevel - 1];
                        Super1.Special = Super1.SpecialNxt[Super1.CurrentLevel - 1];
                        Super1.MaxHP = Super1.MaxHPNxt[Super1.CurrentLevel - 1];
                        Super1.MaxAP = Super1.MaxAPNxt[Super1.CurrentLevel - 1];

                        NextExpBar.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
                        NextExpBar.Value = 0;
                        ExpText.Content = "Опыт " + NextExpBar.Value + "/" + NextExpBar.Maximum;
                        AfterLevel.Content = "Уровень " + Super1.CurrentLevel;
                        
                        /*CurrentNextParams[0] = Super1.Attack;
                        CurrentNextParams[1] = Super1.Defence;
                        CurrentNextParams[2] = Super1.Speed;
                        CurrentNextParams[3] = Super1.Special;
                        CurrentNextHPAP[0] = Super1.MaxHP;
                        CurrentNextHPAP[1] = Super1.MaxAP;*/

                        AddHP.Content = "+" + (Super1.MaxHP - CurrentNextHPAP[0]);
                        AddAP.Content = "+" + (Super1.MaxAP - CurrentNextHPAP[1]);
                        AddATK.Content = "+" + (Super1.Attack - CurrentNextParams[0]);
                        AddDEF.Content = "+" + (Super1.Defence - CurrentNextParams[1]);
                        AddAG.Content = "+" + (Super1.Speed - CurrentNextParams[2]);
                        AddSP.Content = "+" + (Super1.Special - CurrentNextParams[3]);

                        if (!NewLevelGet.IsEnabled)
                            LevelUpShow();
                        if (LevelUpCount > 1)
                        {
                            NewLevelGet.Content = "Новый уровень! " + "X" + LevelUpCount;
                        }
                        else
                        {
                            NewLevelGet.Content = "Новый уровень!";
                        }
                        LevelUpCount += 1;
                        Dj(new Uri("D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp.mp3", UriKind.RelativeOrAbsolute));
                        WidelyUsedAnyTimer(out timer2, LevelingUPImage_Time_Tick44, new TimeSpan(0, 0, 0, 0, 25));
                    } else
                    {
                        NextExpBar.Value = NextExpBar.Maximum;
                        //                "Максимальный"
                        ExpText.Content = "Профессионал";
                        Exp = 0;
                        if (!NewLevelGet.IsEnabled)
                        {
                            timer12.Stop();
                            ButtonShow(TextOk1);
                        }
                        else
                        {
                            timer12.Stop();
                            WidelyUsedAnyTimer(out timer13, AddingStats_Time_Tick41, new TimeSpan(0, 0, 0, 0, 25));                            
                        }
                    }
                }
                else
                {
                    NextExpBar.Value++;
                    ExpText.Content = "Опыт " + NextExpBar.Value + "/" + NextExpBar.Maximum;
                }
                Exp--;
            }
            else
            {
                if (!NewLevelGet.IsEnabled)
                {
                    timer12.Stop();
                    ButtonShow(TextOk1);
                }
                else
                {
                    timer12.Stop();
                    WidelyUsedAnyTimer(out timer13, AddingStats_Time_Tick41, new TimeSpan(0, 0, 0, 0, 25));
                }
            }
        }

        public static Byte LevelUpCount = 1;
        public static Byte[] CurrentNextParams = new Byte[] { 25, 15, 15, 25 };
        public static UInt16[] CurrentNextHPAP = new UInt16[] { 100, 40 };

        private void LevelingUPImage_Time_Tick44(object sender, EventArgs e) {
            string[] ico = { "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon1.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon2.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon3.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon4.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon5.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon6.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon7.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon8.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon9.png", "D:\\Александр\\Windows 7\\misc\\Надгробные плиты\\C#\\WpfApp1\\WpfApp1\\LevelUp\\LevelUpIcon9.png" };
            Image icon = AfterIcon;
            IconActions(icon, ico);
        }
        private void textOk2_Click(object sender, RoutedEventArgs e)
        {
            ItemsGetSlot1.Content = "";
            if (Sets.SpecialBattle == 200)
            {
                APtext.Content = "ОД";
                APbar.Maximum = RememberHPAP[3];
                APbar.Value = RememberHPAP[1];
                HPbar.Maximum = RememberHPAP[2];
                HPbar.Value = RememberHPAP[0];
                Super1.Attack = RememberParams[0];
                Super1.Defence = RememberParams[1];
                APbar.Width = APbar.Maximum;
                HPbar.Width = HPbar.Maximum;
                RefreshAllHPAP();
                Sets.SpecialBattle = 0;
                TrgtImg.Width = 325;
                TrgtImg.Height = 325;
                Img6.Width = 325;
                Img6.Height = 325;
                FastImgChange(new Image[] { Img4, Img5 }, new BitmapImage[] { new BitmapImage(new Uri("/pers5.png", UriKind.RelativeOrAbsolute)), new BitmapImage(new Uri("/person6.png", UriKind.RelativeOrAbsolute)) });
                BAG.Armor[3] = true;
                if (Super1.PlayerEQ[1] == 0)
                    BAG.Jacket = true;
                ItemsGetSlot1.Content += "Футболка серьёзного \n";
                LabShow(ItemsGetSlot1);
            }
            
            LevelUpCount = 1;
            CurrentNextParams[0] = Super1.Attack;
            CurrentNextParams[1] = Super1.Defence;
            CurrentNextParams[2] = Super1.Speed;
            CurrentNextParams[3] = Super1.Special;
            CurrentNextHPAP[0] = Super1.MaxHP;
            CurrentNextHPAP[1] = Super1.MaxAP;

            BeforeATK.Content=CurrentNextParams[0];
            BeforeDEF.Content = CurrentNextParams[1];
            BeforeAG.Content = CurrentNextParams[2];
            BeforeSP.Content = CurrentNextParams[3];
            BeforeHP.Content = HPbar.Value+"/"+CurrentNextHPAP[0];
            BeforeAP.Content = APbar.Value + "/" + CurrentNextHPAP[1];

            AfterATK.Content = CurrentNextParams[0];
            AfterDEF.Content = CurrentNextParams[1];
            AfterAG.Content = CurrentNextParams[2];
            AfterSP.Content = CurrentNextParams[3];
            AfterHP.Content = HPbar.Value + "/" + CurrentNextHPAP[0];
            AfterAP.Content = APbar.Value + "/" + CurrentNextHPAP[1];
            HPbar.Width = CurrentNextHPAP[0];
            BeforeHPbar.Width = CurrentNextHPAP[0];
            AfterHPbar.Width = CurrentNextHPAP[0];

            APbar.Width = CurrentNextHPAP[1];
            BeforeAPbar.Width = CurrentNextHPAP[1];
            AfterAPbar.Width = CurrentNextHPAP[1];

            HPbar.Maximum = CurrentNextHPAP[0];
            BeforeHPbar.Maximum = CurrentNextHPAP[0];
            AfterHPbar.Maximum = CurrentNextHPAP[0];

            APbar.Maximum = CurrentNextHPAP[1];
            BeforeAPbar.Maximum = CurrentNextHPAP[1];
            AfterAPbar.Maximum = CurrentNextHPAP[1];

            BeforeHPbar.Value = HPbar.Value;
            AfterHPbar.Value = HPbar.Value;

            BeforeAPbar.Value = APbar.Value;
            AfterAPbar.Value = APbar.Value;
            
            MaterialsOnHand.Content = BAG.Materials;
            MaterialsAdd.Content = "+"+Mat;
            AfterLevel.Content = "Уровень " +Super1.CurrentLevel;
            LabHideX(new Label[] { BattleText1, BattleText2, BattleText3, BattleText4, BattleText5, BattleText6 });
            ItemsGetSlot1.Content = "";
            
            LabShowX(new Label[] { ExpText, AfterLevel, AfterName, AfterStatus, BeforeParams, BeforeHPtxt, BeforeAPtxt, BeforeHP, BeforeAP, BeforeAttack, BeforeDefence, BeforeAgility, BeforeSpecial, BeforeATK, BeforeDEF, BeforeAG, BeforeSP, AfterBattleGet, MaterialsGet, MaterialsOnHand, MaterialsAdd, ItemsGet, ItemsGetSlot1 });
            ImgShowX(new Image[] { AfterBattleMenuImg, AfterIcon, BeforeAttackImg, BeforeDefenceImg, BeforeAgilityImg, BeforeSpecialImg, MaterialsGetImg });
            BarShowX(new ProgressBar[] { NextExpBar, BeforeHPbar, BeforeAPbar });
            WidelyUsedAnyTimer(out timer12, Levelling_Time_Tick40, new TimeSpan(0, 0, 0, 0, 25));
            WidelyUsedAnyTimer(out timer, AddingMaterials_Time_Tick42, new TimeSpan(0, 0, 0, 0, 25));
            RefreshAllHPAP();
            ButtonHide(textOk2);
            timer2.Stop();
            Byte item = 0;
            if (Sets.ItemsDropRate[0] != 0)
            {
                while (Sets.ItemsDropRate[0] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[0]--;
                }
            }
            if (item>0)
            {
                ItemsGetSlot1.Content += "Антидот: "+item+"\n";
                if (BAG.AntidoteITM+item<255)
                    BAG.AntidoteITM += item;
                else
                    BAG.AntidoteITM = 255;
                item = 0;
            }
            if (Sets.ItemsDropRate[1] != 0)
            {
                while (Sets.ItemsDropRate[1] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[1]--;
                }
            }
            if (item > 0)
            {
                ItemsGetSlot1.Content += "Бинт: " + item + "\n";
                if (BAG.BandageITM+item < 255)
                    BAG.BandageITM += item;
                else
                    BAG.EtherITM = 255;
                item = 0;
            }
            if (Sets.ItemsDropRate[2] != 0)
            {
                while (Sets.ItemsDropRate[2] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[2]--;
                }
            }
            if (item > 0)
            {
                ItemsGetSlot1.Content += "Эфир: " + item + "\n";
                if (BAG.EtherITM+ item < 255)
                    BAG.EtherITM += item;
                else
                    BAG.EtherITM = 255;
                item = 0;
            }
            if (Sets.ItemsDropRate[3] != 0)
            {
                while (Sets.ItemsDropRate[3] != 0)
                {
                    Byte rndItem = (Byte)Random1.Next(0, 8);
                    if (rndItem == 4)
                    {
                        item++;
                    }
                    Sets.ItemsDropRate[3]--;
                }
            }
            if (item > 0)
            {
                ItemsGetSlot1.Content += "Смесь: " + item + "\n";
                if (BAG.FusedITM + item < 255)
                    BAG.FusedITM += item;
                else
                    BAG.FusedITM = 255;
                item = 0;
            }
            WonOrDied();
        }

        private void Torch_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Подожжёт врагов, Стоит: 4 ОД";
            TextCh1();
        }

        private void Torch_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void ACT1_MouseEnter(object sender, MouseEventArgs e)
        {
            SelectTrgt2Img.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Поджечь выбранного врага";
            TextCh1();
        }

        private void ACT1_MouseLeave(object sender, MouseEventArgs e)
        {
            SelectTrgt2Img.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectBeforeImg.png", UriKind.RelativeOrAbsolute));
            DisableBattleText();
        }

        private void Cancel2_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Обратно к умениям";
            TextCh1();
        }

        private void Cancel2_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Torch_Click(object sender, RoutedEventArgs e)
        {
            SelectTarget();
            AbilitiesMakeDisappear1();
            BtnShowX(new Button[] { ACT1, Cancel2 });
        }

        private void InBattleHighSkillsMenu()
        {
            if (ToNextImg.Source.ToString().Contains("ToNext.png"))
            {
                BtnHideX(new Button[] { Cure, Heal });
                CheckAccessAbilities(new Button[] { Torch, Whip, Super }, new Byte[] { 3, 6, 7 }, new Byte[] { 4, 6, 10 });
                ButtonShow(SwitchAbils);
                ToNextImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ToPrev.png", UriKind.RelativeOrAbsolute));
            }
            else if (ToNextImg.Source.ToString().Contains("ToPrev.png"))
            {
                BtnHideX(new Button[] { Torch, Whip, Super });
                CheckAccessAbilities(new Button[] { Cure, Heal }, new Byte[] { 2, 4 }, new Byte[] { 5, 3 });
                ButtonShow(SwitchAbils);
                ToNextImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ToNext.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Cancel2_Click(object sender, RoutedEventArgs e)
        {
            timer9.Stop();
            BarHide(HPenemyBar);
            LabHideX(new Label[] { HPenemy, BattleText1 });
            ImgHideX(new Image[] { EnemyImg, TrgtImg });
            BtnHideX(new Button[] { Fight, ACT1, ACT2, Cancel2, Back1 });
            BtnShow(Back2);
            InBattleHighSkillsMenu();
        }
        private void CheckFoeCounts(in Byte selected, in string foestatus)
        {
            if (EnemyNamesFight[selected]==1)
            {
                BattleText3.Content = foestatus;
                BattleText3.Foreground = Brushes.Red;
            } else if (EnemyNamesFight[selected] == 2)
            {
                BattleText4.Content = foestatus;
                BattleText4.Foreground = Brushes.Red;
            } else if (EnemyNamesFight[selected] == 3)
            {
                BattleText5.Content = foestatus;
                BattleText5.Foreground = Brushes.Red;
            }
        }
        private void ACT(in Byte a1)
        {
            string[] EnemyNames = { "Паук", "Мумия", "Зомби", "Страж" };
            UInt16 strength = Super1.Special;
            if ((a1 == 0) && ((Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[0]) || (Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[1])))
            {
                strength = Convert.ToUInt16(strength * 2.5);
            }
            else
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                    strength = Convert.ToUInt16(strength * 0.5);
                else
                    strength = Convert.ToUInt16(strength * 1.25);
            }
            if ((a1 == 1) && ((Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[2]) || (Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[3])))
            {
                strength = Convert.ToUInt16(strength * 3);
            }
            else
            {
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон")
                    strength = Convert.ToUInt16(strength * 0.75);
                else
                    strength = Convert.ToUInt16(strength * 1.5);
            }
            LabHideX(new Label[] { HPenemy, BattleText1 });
            BarHide(HPenemyBar);
            ImgHide(EnemyImg);
            BtnHideX(new Button[] { Fight, Cancel1, Cancel2 });
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            if (Foe1.EnemyHP[Sets.SelectedTarget] - strength < 0)
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = 0;
            }
            else
            {
                Foe1.EnemyHP[Sets.SelectedTarget] = (ushort)(Foe1.EnemyHP[Sets.SelectedTarget] - strength);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                string res= "SpiderDied";
                res=EnemySounds(Sets.SelectedTarget);
                SEF(new Uri(@"" + res + ".mp3", UriKind.RelativeOrAbsolute));
                SuperCheckFoes(Sets.SelectedTarget);
                /*if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Паук")
                {
                    Sets.SpiderAlive--;
                    CheckFoeCounts(0, (spdr + ": " + Sets.SpiderAlive));
                    if (Sets.SpiderAlive == 0)
                    {
                      //  LabShow(BattleText3);
                        CheckFoeCounts(0, "");
                   //     EnemyNamesFight[0] = 0;
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Мумия")
                {
                    Sets.MummyAlive--;
                    CheckFoeCounts(1, (mum + ": " + Sets.MummyAlive));
                    if (Sets.MummyAlive == 0)
                    {
                        CheckFoeCounts(1, "");
                      //  EnemyNamesFight[1] = 0;
                      //  LabShow(BattleText4);
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Зомби")
                {
                    Sets.ZombieAlive--;
                    CheckFoeCounts(2, (zomb + ": " + Sets.ZombieAlive));
                    if (Sets.ZombieAlive == 0)
                    {
                      //  LabShow(BattleText5);
                        CheckFoeCounts(2, "");
                    //    EnemyNamesFight[2] = 0;
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == "Страж")
                {
                    Sets.BonesAlive--;
                    CheckFoeCounts(3, (defd + ": " + Sets.BonesAlive));
                    if (Sets.BonesAlive == 0)
                    {
                        CheckFoeCounts(3, "");
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
                }*/
                
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                switch (Sets.SelectedTarget)
                {
                    case 0:
                        ImgHide(Img6);
                        break;
                    case 1:
                        ImgHide(Img7);
                        break;
                    case 2:
                        ImgHide(Img8);
                        break;
                }
                if (Foe1.EnemyHP[0] != 0)
                    Sets.SelectedTarget = 0;
                else
                    if (Foe1.EnemyHP[1] != 0)
                    Sets.SelectedTarget = 1;
                else
                    if (Foe1.EnemyHP[2] != 0)
                    Sets.SelectedTarget = 2;
                
                Foe1.EnemiesStillAlive = Convert.ToByte(Foe1.EnemiesStillAlive - 1);
                if (Foe1.EnemyAppears[0] == "Фараон")
                {
                    if (Foe1.EnemiesStillAlive == 0)
                    {
                        BattleText2.Content = Foe1.EnemyAppears[Sets.SelectedTarget] + " погибает!";
                        LabShow(BattleText2);
                        BattleText3.Content = "";
                        LabHide(BattleText3);
                    }
                }
            }
        }
        private void ACT1_Click(object sender, RoutedEventArgs e)
        {
            APbar.Value -= 4;
            RefreshAllAP();
            ImgHide(TrgtImg);
            BtnHideX(new Button[] { ACT1, Cancel2 });
            SelectedTrgt = Sets.SelectedTarget;
            timer9.Stop();
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Torch_Time_Tick13, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer10, TorchDmg_Time_Tick20, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            Dj(new Uri(@"Torch.mp3", UriKind.RelativeOrAbsolute));
            Time1.Value = 0;
            ACT(0);
        }

        private void Heal_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Лечит статус, Стоит: 3 ОД";
            TextCh1();
        }

        private void Heal_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            LabShow(BattleText1);
            Img5.Source = new BitmapImage(new Uri(@"Person6.png", UriKind.RelativeOrAbsolute));
            Super1.PlayerStatus = 0;
            APbar.Value -= 3;
            RefreshAllAP();
            AbilitiesMakeDisappear1();
            Time1.Value = 0;
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Heal_Time_Tick12, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            GameSpeed1 = Convert.ToUInt16(75 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer11, HealPsn_Time_Tick19, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            Dj(new Uri(@"Heal.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Whip_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Дробит кости, Стоит: 6 ОД";
            TextCh1();
        }

        private void Whip_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }

        private void Whip_Click(object sender, RoutedEventArgs e)
        {
            SelectTarget();
            AbilitiesMakeDisappear1();
            BtnShowX(new Button[] { ACT2, Cancel2 });
        }

        private void ACT2_MouseEnter(object sender, MouseEventArgs e)
        {
            SelectTrgt3Img.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Ударить врага хлыстом";
            TextCh1();
        }

        private void ACT2_MouseLeave(object sender, MouseEventArgs e)
        {
            SelectTrgt3Img.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\TrgtSelectBeforeImg.png", UriKind.RelativeOrAbsolute));
            DisableBattleText();
        }

        private void ACT2_Click(object sender, RoutedEventArgs e)
        {
            APbar.Value = APbar.Value - 6;
            RefreshAllAP();
            BtnHideX(new Button[] { ACT2, Cancel2 });
            ImgHide(TrgtImg);
            SelectedTrgt = Sets.SelectedTarget;
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Whip_Time_Tick14, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer10, WhipDmg_Time_Tick21, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            Dj(new Uri(@"Whip.mp3", UriKind.RelativeOrAbsolute));
            Time1.Value = 0;
            ACT(1);
        }

        private void Super_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Кровавая бойня, Стоит: 10 ОД";
            TextCh1();
        }

        private void Super_MouseLeave(object sender, MouseEventArgs e)
        {
            DisableBattleText();
        }
        private void SuperCheckFoes(in Byte seltrg)
        {
            Byte FoeType=0;
            string FoesCount="";
            switch (Foe1.EnemyAppears[seltrg])
            {
                case "Паук":
                    FoeType = 0;
                    if (Sets.SpiderAlive == 0) {
                        Foe1.EnemyAppears[seltrg] = "";
                    } else {
                        FoesCount = "Паук: " + Sets.SpiderAlive;
                        Sets.SpiderAlive--;
                    }
                    break;
                case "Мумия":
                    FoeType = 1;
                    if (Sets.MummyAlive == 0) {
                        Foe1.EnemyAppears[seltrg] = "";
                    } else {
                        FoesCount = "Мумия: " + Sets.MummyAlive;
                        Sets.MummyAlive--;
                    }
                    break;
                case "Зомби":
                    FoeType = 2;
                    if (Sets.ZombieAlive == 0) {
                        Foe1.EnemyAppears[seltrg] = "";
                    } else {
                        FoesCount = "Зомби: " + Sets.ZombieAlive;
                        Sets.ZombieAlive--;
                    }
                    break;
                case "Страж":
                    FoeType = 3;
                    if (Sets.BonesAlive == 0)
                    {
                        Foe1.EnemyAppears[seltrg] = "";
                    } else {
                        FoesCount = "Страж: " + Sets.BonesAlive;
                        Sets.BonesAlive--;
                    }
                    break;
                default:
                    FoeType = 0;
                    if (Sets.SpiderAlive == 0)
                    {
                        Foe1.EnemyAppears[seltrg] = "";
                    }
                    else
                    {
                        FoesCount = "Паук: " + Sets.SpiderAlive;
                        Sets.SpiderAlive--;
                    }
                    break;
            }
            CheckFoeCounts(FoeType, FoesCount);
            
        }
        private void Super_Click(object sender, RoutedEventArgs e)
        {
            APbar.Value = APbar.Value - 10;
            RefreshAllAP();
            UInt16 strength = Super1.Special;
            if (Foe1.EnemyAppears[Sets.SelectedTarget] != "Фараон")
                strength = Convert.ToUInt16(strength * 2);
            Dj(new Uri(@"Super.mp3", UriKind.RelativeOrAbsolute));

            AbilitiesMakeDisappear1();
            ImgHide(TrgtImg);
            LabHideX(new Label[] { BattleText1, HPenemy });
            BtnHideX(new Button[] { Fight, Cancel1, Cancel2 });
            BarHide(HPenemyBar);
            LabShow(BattleText1);
            SelectedTrgt = 4;
            Time1.Value = 0;
            
            Lab2.Foreground = Brushes.White;
            if (Foe1.EnemyAppears[Sets.SelectedTarget] != "Фараон")
            {
                if ((Foe1.EnemyHP[0] - strength <= 0)&& (Foe1.EnemyAppears[0] != ""))
                {
                    Foe1.EnemyHP[0] = 0;
                    ImgHide(Img6);
                    SuperCheckFoes(0);
                    Foe1.EnemiesStillAlive--;
                }
                else if (Foe1.EnemyAppears[0] != "")
                    Foe1.EnemyHP[0] = Convert.ToUInt16(Foe1.EnemyHP[0] - strength);

                if ((Foe1.EnemyHP[1] - strength <= 0)&& (Foe1.EnemyAppears[1]!=""))
                {
                    Foe1.EnemyHP[1] = 0;
                    ImgHide(Img7);
                    SuperCheckFoes(1);
                    Foe1.EnemiesStillAlive--;
                }
                else if (Foe1.EnemyAppears[1] != "")
                    Foe1.EnemyHP[1] = Convert.ToUInt16(Foe1.EnemyHP[1] - strength);

                if ((Foe1.EnemyHP[2] - strength <= 0)&& (Foe1.EnemyAppears[2] != ""))
                {
                    Foe1.EnemyHP[2] = 0;
                    ImgHide(Img8);
                    SuperCheckFoes(2);
                    Foe1.EnemiesStillAlive--;
                }
                else if (Foe1.EnemyAppears[2] != "")
                    Foe1.EnemyHP[2] = Convert.ToUInt16(Foe1.EnemyHP[2] - strength);
                
                if (Foe1.EnemyHP[0] != 0)
                    Sets.SelectedTarget = 0;
                else if (Foe1.EnemyHP[1] != 0)
                    Sets.SelectedTarget = 1;
                else if (Foe1.EnemyHP[2] != 0)
                    Sets.SelectedTarget = 2;

                Time1.Value = 0;
                UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
                WidelyUsedAnyTimer(out timer8, Super_Time_Tick15, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
                WidelyUsedAnyTimer(out timer10, SuperDmg_Time_Tick22, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            }
            else
            {
                if (Foe1.EnemyHP[0] - strength <= 0)
                    Foe1.EnemyHP[0] = 0;
                else
                    Foe1.EnemyHP[0] = Convert.ToUInt16(Foe1.EnemyHP[0] - strength);

                if (Foe1.EnemyHP[0] == 0)
                {
                    ImgHide(Img6);
                    Time1.Value = 0;
                    Foe1.EnemiesStillAlive = 0;
                }
                UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
                Dj(new Uri(@"DefeatPharaoh.mp3", UriKind.RelativeOrAbsolute));
                WidelyUsedAnyTimer(out timer8, Super_Time_Tick15, new TimeSpan(0, 0, 0, 0, GameSpeed1));
                GameSpeed1 = Convert.ToUInt16(50 / GameSpeed.Value);
                WidelyUsedAnyTimer(out timer10, SuperDmg_Time_Tick22, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            }
        }

        private void Items_MouseEnter(object sender, MouseEventArgs e)
        {
            ItemsImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ItemsAfterImg.png", UriKind.RelativeOrAbsolute));
            BattleText2.Content = "Посмотреть инвентарь";
            TextCh1();
        }

        private void Items_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemsImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ItemsBeforeImg.png", UriKind.RelativeOrAbsolute));
            DisableBattleText();
        }

        private void Items_Click(object sender, RoutedEventArgs e)
        {
            FightMenuMakesDisappear();
            ButtonShow(Back2);
            LabShow(ItemText);
            ImgShow(ItemsCountImg);
            CheckAccessItems(new Byte[] { BAG.AntidoteITM, BAG.FusedITM, BAG.BandageITM, BAG.EtherITM }, new Button[] { Antidote1, Fused1, Bandage1, Ether });
            Dj(new Uri(@"ItemsOpen.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Back2_DragEnter(object sender, DragEventArgs e)
        {
            BattleText2.Content = "Обратно к действиям";
            TextCh1();
        }

        private void Back2_DragLeave(object sender, DragEventArgs e)
        {
            DisableBattleText();
        }

        private void MenuItemsHide1()
        {
            BtnHideX(new Button[] { Antidote1, Fused1, Bandage1 , Ether, Back2 });
        }
        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            MenuItemsHide1();
            FightMenuBack();
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Antidote1_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            Super1.PlayerStatus = 0;
            BAG.AntidoteITM -= 1;
            Time1.Value = 0;

            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);            
            WidelyUsedAnyTimer(out timer8, Items_Time_Tick10, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            GameSpeed1 = Convert.ToUInt16(75 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer11, Antidote_Time_Tick26, new TimeSpan(0, 0, 0, 0, GameSpeed1));            
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Antidote1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Избавляет от яда";
            ItemText.Content = "Всего:" + BAG.AntidoteITM;
            TextCh1();
        }

        private void Antidote1_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }

        private void Fused1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит 80 ОЗ и 40 ОД";
            ItemText.Content = "Всего:" + BAG.FusedITM;
            TextCh1();
        }

        private void Fused1_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }

        private void Fused1_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            if ((HPbar.Value + 80) > HPbar.Maximum)
                HPbar.Value = HPbar.Maximum;
            else
                HPbar.Value += 80;
           
            if ((APbar.Value + 80) > APbar.Maximum)
                APbar.Value = APbar.Maximum;
            else
                APbar.Value += 80;
            RefreshAllHPAP();
            BAG.FusedITM -= 1;
            Time1.Value = 0;
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Items_Time_Tick10, new TimeSpan(0, 0, 0, 0, GameSpeed1));            
            GameSpeed1 = Convert.ToUInt16(75 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer11, Fused_Time_Tick25, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Bandage1_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит 50 ОЗ";
            ItemText.Content = "Всего:" + BAG.BandageITM;
            TextCh1();
        }

        private void Bandage1_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }

        private void Bandage1_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            if ((HPbar.Value + 50) > HPbar.Maximum)
                HPbar.Value = HPbar.Maximum;
            else
                HPbar.Value += 50;
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            BAG.BandageITM -= 1;
            Time1.Value = 0;
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Items_Time_Tick10, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            GameSpeed1 = Convert.ToUInt16(75 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer11, Bandage_Time_Tick23, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Ether_MouseEnter(object sender, MouseEventArgs e)
        {
            BattleText2.Content = "Восстановит 50 ОД";
            ItemText.Content = "Всего:" + BAG.EtherITM;
            TextCh1();
        }

        private void Ether_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            DisableBattleText();
        }
        
        private void Ether_Click(object sender, RoutedEventArgs e)
        {
            LabHide(ItemText);
            ImgHide(ItemsCountImg);
            MenuItemsHide1();
            if ((APbar.Value + 50) > APbar.Maximum)
                APbar.Value = APbar.Maximum;
            else
                APbar.Value += 50;
            RefreshAllAP();
            BAG.EtherITM -= 1;
            Time1.Value = 0;
            UInt16 GameSpeed1 = Convert.ToUInt16(25 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer8, Items_Time_Tick10, new TimeSpan(0, 0, 0, 0, GameSpeed1));
            GameSpeed1 = Convert.ToUInt16(75 / GameSpeed.Value);
            WidelyUsedAnyTimer(out timer11, Ether_Time_Tick24, new TimeSpan(0, 0, 0, 0, GameSpeed1));            
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
        }
        private void ShowEquipAndStats()
        {
            ImgShowX(new Image[] { EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg });
            LabShowX(new Label[] { ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText });
        }

        private void MenuHpApExp()
        {
            HPbar1.Width = HPbar.Width * 2;
            HPbar1.Maximum = HPbar.Maximum;
            HPbar1.Value = HPbar.Value;
            APbar1.Width = APbar.Width * 2;
            APbar1.Maximum = APbar.Maximum;
            APbar1.Value = APbar.Value;
            ExpBar1.Width = NextExpBar.Width*0.5;
            ExpBar1.Maximum = NextExpBar.Maximum;
            ExpBar1.Value = NextExpBar.Value;
            Exp1.Content = ExpText.Content;
            RefreshAllHPAP();
            if (Super1.PlayerStatus == 0)
            {
                Icon0.Source = new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute));
                StatusP.Content = "Статус: здоров ♫";
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
                StatusP.Content = "Статус: отравлен §";
            }
        }
        private void Status_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Посмотреть статус";
        }

        private void Status_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            RightPanelMenuTurnON();
            HeroStatus();
        }

        private void Abils_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к умениям";
        }

        private void Abils_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }
        private void RightPanelMenuTurnON()
        {
            BtnShowX(new Button[] { Status, Abils, Items0, Equip, Tasks, Info, Settings });
        }
        private void CheckAccessAbilities(Button[] abils, in Byte[] lvl, in Byte[] apcost)
        {
            for (Byte i=0; i<abils.Length; i++)
            {
                if (Super1.CurrentLevel >= lvl[i])
                {
                    ButtonShow(abils[i]);
                    if (APbar1.Value < apcost[i])
                        abils[i].IsEnabled = false;
                }
            }
        }

        private void HeroAbilities()
        {
            MenuHpApExp();
            ImgShowX(new Image[] { Menu1, Icon0 });
            RightPanelMenuTurnON();
            BarShowX(new ProgressBar[] { HPbar1, APbar1 });
            LabShowX(new Label[] { Name0, StatusP, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, CostText, MiscSkills, FightSkills });
            BarGridX(new ProgressBar[] { HPbar1, APbar1 }, new Byte[] { 4, 26 }, new Byte[] { 16, 11 });
            LabGridX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Exp1 }, new Byte[] { 2, 4, 26, Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new Byte[] { 14, 7, 2, Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            CheckAccessAbilities(new Button[] { Cure1, Heal1, Torch1, Whip1, Super0 }, new Byte[] { 2, 4, 1, 1, 1 }, new Byte[] { 2, 1, 4, 6, 10 });
        }

        private void Abils_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            HeroAbilities();
            Abils.IsEnabled = false;
            LabShow(Describe2);
            //                  "                                                                       "                                                                       ""                                                                       "
            Describe1.Content = "Умения хороши везде где они применимы. Стоит только начать изучать их.\nКаждое умение становится доступным при достижении определённого уровня.\nИспользуя их правильно, можно свернуть горы!";
            LabShow(Describe1);
        }

        private void Cure1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"Cure.mp3", UriKind.RelativeOrAbsolute));
            if (((Super1.Special * 2) + HPbar.Value) >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
            }
            else
            {
                HPbar.Value = HPbar.Value + Super1.Special * 2;
                HPbar1.Value = HPbar.Value;
            }
            APbar.Value -= 2;
            APbar1.Value = APbar.Value;
            if (APbar1.Value < 2)
                Cure1.IsEnabled = false;
            RefreshAllHPAP();
        }

        private void Heal1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"Heal.mp3", UriKind.RelativeOrAbsolute));
            Super1.PlayerStatus = 0;
            StatusP.Content = "Статус: здоров";
            APbar.Value -= 1;
            APbar1.Value = APbar.Value;
            RefreshAllAP();
            if (APbar1.Value < 1)
                Heal1.IsEnabled = false;
            if (Super1.PlayerStatus == 0)
            {
                FastImgChange(new Image[] { Icon0, Img5 }, new BitmapImage[] { new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute)), new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute)) });
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Items0_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к вещам";
        }

        private void Items0_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }
        private void CheckAccessItems(in Byte[] bag, Button[] btn, Label[] lab)
        {
            for (Byte i = 0; i < lab.Length; i++)
            {
                if (bag[i] >= 1)
                {
                    ButtonShow(btn[i]);
                    LabShow(lab[i]);
                }
            }
        }
        private void CheckAccessItems(in Byte[] bag, Button[] btn)
        {
            for (Byte i = 0; i < btn.Length; i++)
            {
                if (bag[i] >= 1)
                {
                    ButtonShow(btn[i]);
                }
            }
        }
        private void HeroItems()
        {
            MenuHpApExp();
            ImgShowX(new Image[] { Menu1, Icon0, MaterialsCraftImg });
            RightPanelMenuTurnON();
            ButtonShow(CraftSwitch);
            BarShowX(new ProgressBar[] { HPbar1, APbar1 });
            LabShowX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Describe1, Describe2, MaterialsCraft });
            BarGridX(new ProgressBar[] { HPbar1, APbar1 }, new Byte[] { 2, 4 }, new Byte[] { 16, 16 });
            LabGridX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Exp1 }, new Byte[] { 7, 2, 4, Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new Byte[] { 2, 7, 7, Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            CheckAccessItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM }, new Button[] { Antidote, Bandage, Ether1, Fused }, new Label[] { AntidoteText, BandageText, EtherText, FusedText });
            CraftSwitch.Content = "Создание";
            MaterialsCraft.Content = BAG.Materials;
            Items0.IsEnabled = false;
            Describe1.Content = "";
            LabShow(Describe2);
            LabShow(Describe1);
        }
        private void Items0_Click(object sender, RoutedEventArgs e)
        {
            MegaHide();
            HeroItems();
            Dj(new Uri(@"ItemsOpen.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Bandage_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Бинт, полученный из мумии. Отлично подходит для перевязывания ран";
            CountText.Content = "Всего: " + BAG.BandageITM;
            LabShow(CountText);
        }

        private void Bandage_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
            LabHide(CountText);
        }

        private void Bandage_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.BandageITM -= 1;
            if (50 + HPbar.Value >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
            }
            else
            {
                HPbar.Value = HPbar.Value + 50;
                HPbar1.Value = HPbar.Value;
            }
            RefreshAllHP();
            if (BAG.BandageITM < 1)
            {
                LabHide(BandageText);
                ButtonHide(Bandage);
                CountText.Content = "";
            }
            else
                CountText.Content = "Всего: " + BAG.BandageITM;
        }

        private void Ether1_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Особая жидкость древних, чудесным образом восполняющая силы";
            CountText.Content = "Всего: " + BAG.EtherITM;
            LabShow(CountText);
        }

        private void Ether1_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
            LabHide(CountText);
        }

        private void Ether1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.EtherITM -= 1;
            if (50 + APbar.Value >= APbar.Maximum)
            {
                APbar.Value = APbar.Maximum;
                APbar1.Value = APbar.Value;
            }
            else
            {
                APbar.Value = APbar.Value + 50;
                APbar1.Value = APbar.Value;
            }
            RefreshAllAP();
            if (BAG.EtherITM < 1)
            {
                LabHide(EtherText);
                ButtonHide(Ether1);
            }
            else
                CountText.Content = "Всего: " + BAG.EtherITM;
        }

        private void Antidote_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Склизкая, мутная жижа, добытая из глаз паука - единственное средство от его ужасного яда";
            CountText.Content = "Всего: " + BAG.AntidoteITM;
            LabShow(CountText);
        }

        private void Antidote_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
            LabHide(CountText);
        }

        private void Antidote_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.AntidoteITM -= 1;
            Super1.PlayerStatus = 0;
            StatusP.Content = "Статус: здоров";
            Antidote.IsEnabled = false;
            if (BAG.AntidoteITM < 1)
            {
                LabHide(AntidoteText);
                ButtonHide(Antidote);
                CountText.Content = "";
            }
            else
                CountText.Content = "Всего: " + BAG.AntidoteITM;

            if (Super1.PlayerStatus == 0)
            {
                FastImgChange(new Image[] { Icon0, Img5 }, new BitmapImage[] { new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute)), new BitmapImage(new Uri(@"person6.png", UriKind.RelativeOrAbsolute)) });
            }
            else
            {
                Icon0.Source = new BitmapImage(new Uri(@"IconPoisoned.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Fused_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"ItemsUsed.mp3", UriKind.RelativeOrAbsolute));
            BAG.FusedITM -= 1;
            if (80 + HPbar.Value >= HPbar.Maximum)
            {
                HPbar.Value = HPbar.Maximum;
                HPbar1.Value = HPbar.Value;
            }
            else
            {
                HPbar.Value = HPbar.Value + 80;
                HPbar1.Value = HPbar.Value;
            }
            if (80 + APbar.Value >= APbar.Maximum)
            {
                APbar.Value = APbar.Maximum;
                APbar1.Value = APbar.Value;
            }
            else
            {
                APbar.Value = APbar.Value + 80;
                APbar1.Value = APbar.Value;
            }
            RefreshAllHPAP();
            if (BAG.FusedITM < 1)
            {
                LabHide(FusedText);
                ButtonHide(Fused);
                CountText.Content = "";
            }
            else
                CountText.Content = "Всего: " + BAG.FusedITM;
        }

        private void Fused_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe1.Content = "Смесь из костной муки одного из стражей, кальций всегда важен!";
            CountText.Content = "Всего: " + BAG.FusedITM;
            LabShow(CountText);
        }
        private void RefreshAllAP()
        {
            AP.Content = APbar.Value + "/" + APbar.Maximum;
            AP1.Content = APbar1.Value + "/" + APbar1.Maximum;
        }
        private void RefreshAllHP()
        {
            HP.Content = HPbar.Value + "/" + HPbar.Maximum;
            HP1.Content = HPbar1.Value + "/" + HPbar1.Maximum;
        }
        private void RefreshAllHPAP()
        {
            RefreshAllHP();
            RefreshAllAP();
        }
        private void Fused_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            CountText.Content = "";
            LabHide(CountText);
        }

        private void Equip_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к снаряжению";
        }

        private void Equip_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void HeroEquip()
        {
            StatusCalculate();
            ImgShowX(new Image[] { Menu1, Img2, Img1, Icon0, EquipHImg, EquipBImg, EquipLImg, EquipDImg, ATKImg, DEFImg, AGImg, SPImg });
            RightPanelMenuTurnON();
            BarShowX(new ProgressBar[] { HPbar1, APbar1 });
            LabShowX(new Label[] { HPtext1, APtext1, HP1, AP1, Describe1, Describe2 });
            BarGridX(new ProgressBar[] { HPbar1, APbar1 }, new Byte[] { 2, 4 }, new Byte[] { 16, 16 });
            LabGridX(new Label[] { StatusP, HPtext1, APtext1, HP1, AP1, Exp1 }, new Byte[] { 2, 2, 4, Convert.ToByte(HPbar1.GetValue(Grid.RowProperty)), Convert.ToByte(APbar1.GetValue(Grid.RowProperty)), Convert.ToByte(ExpBar1.GetValue(Grid.RowProperty)) }, new Byte[] { 14, 7, 7, Convert.ToByte(Convert.ToInt32(HPbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(HPbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(APbar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(APbar1.Width) / 32)), Convert.ToByte(Convert.ToInt32(ExpBar1.GetValue(Grid.ColumnProperty)) + 1 + (Convert.ToInt32(ExpBar1.Width) / 32)) });
            LabShowX(new Label[] { HPtext1, APtext1, HP1, AP1, Describe1, Describe2, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, EquipText, ATK1, DEF1, AG1, SP1, EquipH, EquipB, EquipL, EquipD });
            BtnShowX(new Button[] { Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4 });
            FastEnableDisableBtn(false, new Button[] { Equip, Remove1, Remove2, Remove3, Remove4, Equip1, Equip2, Equip3, Equip4 });
            Describe2.Content = "Снаряжение героя";
            Describe1.Content = "Отличное оснащение даёт преимущество в бою.\n";
            LabShow(Describe1);
        }
        private void FastEnableDisableBtn(Boolean enabled, Button[] buttons)
        {
            foreach(Button btn in buttons)
            {
                btn.IsEnabled = enabled;
            }
        }
        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            HeroEquip();
            Describe1.Content = "";
            ShowEquipAndStats();
            EquipWatch();
            LabHide(Describe1);
        }
        private void EquipWatch()
        {
            if (BAG.Hands && (Super1.PlayerEQ[0] == 0))
                Equip1.IsEnabled = true;
            Equip1.Visibility = Visibility.Visible;
            if (BAG.Jacket && (Super1.PlayerEQ[1] == 0))
                Equip2.IsEnabled = true;
            Equip2.Visibility = Visibility.Visible;
            if (BAG.Legs && (Super1.PlayerEQ[2] == 0))
                Equip3.IsEnabled = true;
            Equip3.Visibility = Visibility.Visible;
            if (BAG.Boots && (Super1.PlayerEQ[3] == 0))
                Equip4.IsEnabled = true;
            Equip4.Visibility = Visibility.Visible;
            if (!BAG.Hands && (Super1.PlayerEQ[0] != 0))
                Remove1.IsEnabled = true;
            Remove1.Visibility = Visibility.Visible;
            if (!BAG.Jacket && (Super1.PlayerEQ[1] != 0))
                Remove2.IsEnabled = true;
            Remove2.Visibility = Visibility.Visible;
            if (!BAG.Legs && (Super1.PlayerEQ[2] != 0))
                Remove3.IsEnabled = true;
            Remove3.Visibility = Visibility.Visible;
            if (!BAG.Boots && (Super1.PlayerEQ[3] != 0))
                Remove4.IsEnabled = true;
            Remove4.Visibility = Visibility.Visible;
        }
        private void StatsMeaning()
        {
            Level0.Content = "Уровень: " + Super1.CurrentLevel;
            ATK1.Content = Super1.Attack + Super1.PlayerEQ[0];
            DEF1.Content = Super1.Defence + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3];
            AG1.Content = Super1.Speed;
            SP1.Content = Super1.Special;
        }
        private void Remove1_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[0] = 0;
            BAG.Hands = true;
            Remove1.IsEnabled = false;
            StatsMeaning();
            EquipH.Content = "Правая рука";
            EquipWatch();
        }

        private void Remove2_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[1] = 0;
            BAG.Jacket = true;
            Remove2.IsEnabled = false;
            StatsMeaning();
            EquipB.Content = "Тело";
            EquipWatch();
        }

        private void Remove3_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[2] = 0;
            BAG.Legs = true;
            Remove3.IsEnabled = false;
            StatsMeaning();
            EquipL.Content = "Ноги";
            EquipWatch();
        }

        private void Remove4_Click(object sender, RoutedEventArgs e)
        {
            Super1.PlayerEQ[3] = 0;
            BAG.Boots = true;
            Remove4.IsEnabled = false;
            StatsMeaning();
            EquipD.Content = "Ступни";
            EquipWatch();
        }

        private void Equip1_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 0;
            if (BAG.Weapon[0])
                ButtonShow(Equipments);
            if (BAG.Weapon[3])
                ButtonShow(Equipments4);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"KnucledusterItem.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void Equipments_Click(object sender, RoutedEventArgs e)
        {
            if (Sets.EquipmentClass == 0)
            {
                OnEquiped(Equip1, EquipH, "Древний кастет", 0, 10);
            }
            if (Sets.EquipmentClass == 1)
            {
                OnEquiped(Equip2, EquipB, "Чёрный кожак", 1, 5);
            }
            if (Sets.EquipmentClass == 2)
            {
                OnEquiped(Equip3, EquipL, "Штаны стервятника", 2, 4);
            }
            if (Sets.EquipmentClass == 3)
            {
                OnEquiped(Equip4, EquipD, "Бинтовая обувь", 3, 1);
            }
            StatsMeaning();
            BtnHideX(new Button[] { Equipments, CancelEq });
            EquipWatch();
        }

        private void Equip2_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 1;
            if (BAG.Armor[0])
                ButtonShow(Equipments);
            if (BAG.Armor[3])
                ButtonShow(Equipments4);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"BlackSkinItems.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void Equip3_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 2;
            if (BAG.Pants[0])
                ButtonShow(Equipments);
            if (BAG.Pants[3])
                ButtonShow(Equipments4);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"EagleWearsItems.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void Equip4_Click(object sender, RoutedEventArgs e)
        {
            Sets.EquipmentClass = 3;
            if (BAG.ArmBoots[0])
                ButtonShow(Equipments);
            if (BAG.ArmBoots[3])
                ButtonShow(Equipments4);
            EquipmentsImg.Source = new BitmapImage(new Uri(@"BandageBootsItems.png", UriKind.RelativeOrAbsolute));
            ButtonShow(CancelEq);
        }

        private void CancelEq_Click(object sender, RoutedEventArgs e)
        {
            BtnHideX(new Button[] { Equipments, Equipments4, CancelEq });
        }

        private void HeroTasks()
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            RightPanelMenuTurnON();
            LabShow(Describe2);
            Tasks.IsEnabled = false;
            Uri[] uriSources = new Uri[] { new Uri(@"ActiveTask.png", UriKind.RelativeOrAbsolute), new Uri(@"CompletedTask.png", UriKind.RelativeOrAbsolute) };
            switch (Sets.MenuTask)
            {
                case 0:
                    LabShow(Task1);
                    ImgShow(Task1Img);
                    Task1Img.Source = new BitmapImage(uriSources[0]);
                    break;
                case 1:
                    LabShowX(new Label[] { Task1, Task2 });
                    ImgShowX(new Image[] { Task1Img, Task2Img });
                    FastImgChange(new Image[] { Task1Img, Task2Img }, new BitmapImage[] { new BitmapImage(uriSources[1]), new BitmapImage(uriSources[0]) });
                    break;
                case 2:
                    LabShowX(new Label[] { Task1, Task2, Task3 });
                    ImgShowX(new Image[] { Task1Img, Task2Img, Task3Img });
                    FastImgChange(new Image[] { Task1Img, Task2Img, Task3Img }, new BitmapImage[] { new BitmapImage(uriSources[1]), new BitmapImage(uriSources[1]), new BitmapImage(uriSources[0]) });
                    break;
                case 3:
                    LabShowX(new Label[] { Task1, Task2, Task3, Task4 });
                    ImgShowX(new Image[] { Task1Img, Task2Img, Task3Img, Task4Img });
                    FastImgChange(new Image[] { Task1Img, Task2Img, Task3Img, Task4Img }, new BitmapImage[] { new BitmapImage(uriSources[1]), new BitmapImage(uriSources[1]), new BitmapImage(uriSources[1]), new BitmapImage(uriSources[0]) });
                    break;
                default:
                    LabShow(Task1);
                    ImgShow(Task1Img);
                    break;
            }
            Describe1.Content = "Выполняя задачи нужно оставаться предельно осторожным.\nНикто не знает, что поджидает в святилищах древних.";
            LabShow(Describe1);
        }
        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            HeroTasks();
        }

        private void Tasks_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Перейти к задачам";
        }

        private void Tasks_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled)
            {
                Dj(new Uri(@"ItemsClose.mp3", UriKind.RelativeOrAbsolute));
            }
            MegaHide();
            RightPanelMenuTurnON();
            Info.IsEnabled = false;
            GameMenu.InfoChange1 = 0;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { GameMenu.HelpInfo2[0, GameMenu.InfoChange1], GameMenu.HelpInfo2[1, GameMenu.InfoChange1], GameMenu.HelpInfo2[2, GameMenu.InfoChange1] }, new string[] { GameMenu.HelpInfo1[0, GameMenu.InfoChange1], GameMenu.HelpInfo1[1, GameMenu.InfoChange1], GameMenu.HelpInfo1[2, GameMenu.InfoChange1] });
            TxtShowX(new TextBlock[] { InfoText1, InfoText2, InfoText3 });
            LabShowX(new Label[] { Describe2, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoIndex });
            ButtonShow(InfoIndexPlus);
            InfoIndex.Content = (GameMenu.InfoChange1 + 1) + "/19";
        }
        private void FastInfoChange(TextBlock[] Texts, Label[] Headers, in string[] text, in string[] content)
        {
            for(Byte i=0; i < Headers.Length; i++)
            {
                Headers[i].Content = content[i];
                Texts[i].Text = text[i];
            }
        }

        private void FastImgChange(Image[] ImageArray, BitmapImage[] bitmapImage)
        {
            for (Byte i=0;i<ImageArray.Length;i++)
            {
                ImageArray[i].Source = bitmapImage[i];
            }
        }

        private void InfoIndexPlus_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.InfoChange1 += 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { GameMenu.HelpInfo2[0, GameMenu.InfoChange1], GameMenu.HelpInfo2[1, GameMenu.InfoChange1], GameMenu.HelpInfo2[2, GameMenu.InfoChange1] }, new string[] { GameMenu.HelpInfo1[0, GameMenu.InfoChange1], GameMenu.HelpInfo1[1, GameMenu.InfoChange1], GameMenu.HelpInfo1[2, GameMenu.InfoChange1] });
            InfoIndex.Content = (GameMenu.InfoChange1 + 1) + "/19";
            ButtonShow(InfoIndexMinus);
            if (GameMenu.InfoChange1 >= 18)
                ButtonHide(InfoIndexPlus);
        }

        private void InfoIndexMinus_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.InfoChange1 -= 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { GameMenu.HelpInfo2[0, GameMenu.InfoChange1], GameMenu.HelpInfo2[1, GameMenu.InfoChange1], GameMenu.HelpInfo2[2, GameMenu.InfoChange1] }, new string[] { GameMenu.HelpInfo1[0, GameMenu.InfoChange1], GameMenu.HelpInfo1[1, GameMenu.InfoChange1], GameMenu.HelpInfo1[2, GameMenu.InfoChange1] });
            InfoIndex.Content = (GameMenu.InfoChange1 + 1) + "/19";
            ButtonShow(InfoIndexPlus);
            if (GameMenu.InfoChange1 <= 0)
                ButtonHide(InfoIndexMinus);
        }

        private void Info_MouseEnter(object sender, MouseEventArgs e)
        {
            Describe2.Content = "Посмотреть справку (Что делать?)";
        }

        private void Info_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe2.Content = "";
        }

        private void Equipments_MouseEnter(object sender, MouseEventArgs e)
        {
            LabShow(Describe1);
            if (Sets.EquipmentClass == 0)
            {
                EquipCollectInfo("Прочный костяной кастет. Одно из лучших средств показать свою мощь!", AddATK1, "+10");
            }
            if (Sets.EquipmentClass == 1)
            {
                EquipCollectInfo("Черная кожаная куртка. Никто не ценит ничего так сильно, как\nнадёжный кожак в жуткую погоду.", AddDEF1, "+5");
            }
            if (Sets.EquipmentClass == 2)
            {
                EquipCollectInfo("Штаны из перьев стервятника. Вполне сгодится и на огородное пугало...", AddDEF1, "+4");
            }
            if (Sets.EquipmentClass == 3)
            {
                EquipCollectInfo("Бинтовая обувь. Спасает от ужасной жары здешних песков как никогда.", AddDEF1, "+1");
            }
        }

        private void Equipments_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            LabHideX(new Label[] { AddATK1, AddDEF1 });
        }

        private void PharaohBattle_MediaEnded(object sender, RoutedEventArgs e)
        {
            ImgHide(Img2);
            Sound1.Stop();
            MediaHide(PharaohBattle);
            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
            MediaShow(Med2);
        }

        private void TheEnd_MediaEnded(object sender, RoutedEventArgs e)
        {
            Uri uriSource = new Uri(@"Final1.mp4", UriKind.RelativeOrAbsolute);
            Uri uriSource1 = new Uri(@"Titres3.mp4", UriKind.RelativeOrAbsolute);
            if (TheEnd.Source == uriSource1)
                Form1.Close();
            else
            {
                if (TheEnd.Source != uriSource)
                {
                    HideFightIconPersActions();
                    WonOrDied();
                    MediaShowAdvanced(TheEnd, new Uri(@"Final1.mp4", UriKind.RelativeOrAbsolute), new TimeSpan(0, 0, 0, 0, 0));
                    HeyPlaySomething(new Uri(@"Final1.mp3", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    if (TheEnd.Source != uriSource1)
                    {
                        MediaShowAdvanced(TheEnd, new Uri(@"Titres3.mp4", UriKind.RelativeOrAbsolute), new TimeSpan(0, 0, 0, 0, 0));
                        HeyPlaySomething(new Uri(@"Titres.mp3", UriKind.RelativeOrAbsolute));
                    }
                }
            }
        }

        private void Sound3_MediaEnded(object sender, RoutedEventArgs e)
        {
            Sound3.Stop();
            Sound3.Position = new TimeSpan(0, 0, 0, 0, 0);
        }

        private void Med3_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            AfterAction();
        }

        private void Med4_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Med4Stop();
        }

        private void Med4_MediaOpened(object sender, RoutedEventArgs e)
        {
            ImgHide(Img5);
        }

        private void Med3_MediaOpened(object sender, RoutedEventArgs e)
        {
            ImgHide(Img4);
        }

        private void Win_MediaOpened(object sender, RoutedEventArgs e)
        {
            WonOrDied();
        }

        private void Trgt_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Trgt.Stop();
            Trgt.Play();
        }

        private void Med1_MediaOpened(object sender, RoutedEventArgs e)
        {
            ButtonHide(Button1);
            ImgHide(Img1);
            LabHide(Lab1);
            ButtonShow(Skip1);
        }

        private void PharaohBattle_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Img2.Visibility = Visibility.Hidden;
            Sound1.Stop();
            MediaHide(PharaohBattle);
            Dj(new Uri(@"Ambushed.mp3", UriKind.RelativeOrAbsolute));
            MediaShow(Med2);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (Img2.IsEnabled)
            {
                if (e.Key == Key.W)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person2.png", UriKind.RelativeOrAbsolute));
                }
                if (e.Key == Key.A)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person4.png", UriKind.RelativeOrAbsolute));
                }
                if (e.Key == Key.S)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person1.png", UriKind.RelativeOrAbsolute));
                }
                if (e.Key == Key.D)
                {
                    Img2.Source = new BitmapImage(new Uri(@"person3.png", UriKind.RelativeOrAbsolute));
                }
            }
        }

        private void SwitchAbils_Click(object sender, RoutedEventArgs e)
        {
            if (ToNextImg.Source.ToString().Contains("ToNext.png"))
            {
                BtnHideX(new Button[] { Cure, Heal });
                CheckAccessAbilities(new Button[] { Torch, Whip, Super }, new Byte[] { 3, 6, 7 }, new Byte[] { 4, 6, 10 });
                ButtonShow(SwitchAbils);
                ToNextImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ToPrev.png", UriKind.RelativeOrAbsolute));
            }
            else if (ToNextImg.Source.ToString().Contains("ToPrev.png"))
            {
                BtnHideX(new Button[] { Torch, Whip, Super });
                CheckAccessAbilities(new Button[] { Cure, Heal }, new Byte[] { 2, 4 }, new Byte[] { 5, 3 });
                ButtonShow(SwitchAbils);
                ToNextImg.Source = new BitmapImage(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\AbilitiesImgs\ToNext.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void Remove1_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AddATK1);
        }

        private void Remove1_MouseEnter(object sender, MouseEventArgs e)
        {
            AddATK1.Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
            AddATK1.Content = "-" +Super1.PlayerEQ[0];
            LabShow(AddATK1);
        }

        private void Remove2_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AddDEF1);
        }

        private void Remove2_MouseEnter(object sender, MouseEventArgs e)
        {
            AddDEF1.Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
            AddDEF1.Content = "-" + Super1.PlayerEQ[1];
            LabShow(AddDEF1);
        }

        private void Remove3_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AddDEF1);
        }

        private void Remove3_MouseEnter(object sender, MouseEventArgs e)
        {
            AddDEF1.Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
            AddDEF1.Content = "-" + Super1.PlayerEQ[2];
            LabShow(AddDEF1);
        }

        private void Remove4_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AddDEF1);
        }

        private void Remove4_MouseEnter(object sender, MouseEventArgs e)
        {
            AddDEF1.Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
            AddDEF1.Content = "-" + Super1.PlayerEQ[3];
            LabShow(AddDEF1);
        }
        private void CheckAccessMaterials (in Byte[] bag, Button[] btn)
        {
            for (Byte i = 0; i < btn.Length; i++)
            {
                if (BAG.Materials >= bag[i])
                {
                    ButtonShow(btn[i]);
                } else
                {
                    ButtonHide(btn[i]);
                }
            }
        }
        private void TooManyItems(in Byte[] bag, Button[] btn)
        {
            for (Byte i = 0; i < btn.Length; i++)
            {
                if (bag[i] >= 255)
                {
                    btn[i].IsEnabled = false;
                }
            }
        }
        private void CraftSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (CraftSwitch.Content.ToString() == "Создание") {
                Bandage.IsEnabled = false;
                Ether1.IsEnabled = false;
                Antidote.IsEnabled = false;
                Fused.IsEnabled = false;
                LabHideX(new Label[] { BandageText, AntidoteText, EtherText, FusedText });
                CheckAccessMaterials(new Byte[] { 10, 20, 70, 150 }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
                TooManyItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
                CraftSwitch.Content = "Инвентарь";
            } else
            {
                MegaHide();
                HeroItems();
            }
        }

        private void CraftFused_Click(object sender, RoutedEventArgs e)
        {
            BAG.Materials -= 150;
            BAG.FusedITM++;
            MaterialsCraft.Content = BAG.Materials;
            CheckAccessMaterials(new Byte[] { 10, 20, 70, 150 }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
            TooManyItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
        }

        private void CraftEther_Click(object sender, RoutedEventArgs e)
        {
            BAG.Materials -= 70;
            BAG.EtherITM++;
            MaterialsCraft.Content = BAG.Materials;
            CheckAccessMaterials(new Byte[] { 10, 20, 70, 150 }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
            TooManyItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
        }

        private void CraftBandage_Click(object sender, RoutedEventArgs e)
        {
            BAG.Materials -= 20;
            BAG.BandageITM++;
            MaterialsCraft.Content = BAG.Materials;
            CheckAccessMaterials(new Byte[] { 10, 20, 70, 150 }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
            TooManyItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
        }

        private void CraftAntidote_Click(object sender, RoutedEventArgs e)
        {
            BAG.Materials -= 10;
            BAG.AntidoteITM++;
            MaterialsCraft.Content = BAG.Materials;
            CheckAccessMaterials(new Byte[] { 10, 20, 70, 150 }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
            TooManyItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused });
        }

        private void Whip1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Whip.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Super0_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Super.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Torch1_Click(object sender, RoutedEventArgs e)
        {
            Dj(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\Torch.mp3", UriKind.RelativeOrAbsolute));
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings.IsEnabled = false;
            MegaHide();
            ChbShow(TimerTurnOn);
            HeroSettings();
        }

        private void MusicLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound1.Volume = MusicLoud.Value;
            if (MusicPercent!=null)
            {
                MusicPercent.Content = Convert.ToByte(Sound1.Volume * 100) + "%";
            }
        }

        private void SoundsLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound3.Volume = SoundsLoud.Value;
            if (!Button1.IsEnabled)
            {
                SEF(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\ChestOpened1.mp3", UriKind.RelativeOrAbsolute));
            }
            if (SoundsPercent != null)
                SoundsPercent.Content = Convert.ToByte(Sound3.Volume * 100) + "%";
            
        }

        private void NoiseLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound2.Volume = NoiseLoud.Value;
            if (!Button1.IsEnabled)
            {
                Dj(new Uri(@"D:\Александр\Windows 7\misc\Надгробные плиты\C#\WpfApp1\WpfApp1\BonesDied.mp3", UriKind.RelativeOrAbsolute));
            }
            if (NoisePercent!=null)
                NoisePercent.Content = Convert.ToByte(Sound2.Volume * 100) + "%";
            
        }

        private void GameSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (GameSpeedX!=null)
            {
                GameSpeedX.Content = "x" + Math.Round(GameSpeed.Value, 2);
            }
        }

        private void Brightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BrightnessPercent != null)
            {
                BrightnessImg.Opacity = 1-Brightness.Value;
                BrightnessPercent.Content = Convert.ToByte(Brightness.Value*100) +"%";
            }
        }
        private void HeroSettings()
        {
            ImgShow(Menu1);
            RightPanelMenuTurnON();
            LabShowX(new Label[] { MusicText, SoundsText, NoiseText, GameSpeedText, BrightnessText, MusicPercent, SoundsPercent, NoisePercent, BrightnessPercent, GameSpeedX });
            SldShowX(new Slider[] { MusicLoud, SoundsLoud, NoiseLoud, GameSpeed, Brightness });
        }

        private void TimerTurnOn_Checked(object sender, RoutedEventArgs e)
        {
            TimeRecord.Stop();
        }

        private void TimerTurnOn_Unchecked(object sender, RoutedEventArgs e)
        {
            WidelyUsedAnyTimer(out TimeRecord, WorldRecord, new TimeSpan(0, 0, 0, 0, 1));
        }

        private void Cure1_MouseEnter(object sender, MouseEventArgs e)
        {
            AbilsCost.Content = "-2";
            LabShow(AbilsCost);
        }

        private void Cure1_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AbilsCost);
        }

        private void Heal1_MouseEnter(object sender, MouseEventArgs e)
        {
            AbilsCost.Content = "-1";
            LabShow(AbilsCost);
        }

        private void Heal1_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AbilsCost);
        }

        private void Torch1_MouseEnter(object sender, MouseEventArgs e)
        {
            AbilsCost.Content = "-4";
            LabShow(AbilsCost);
        }

        private void Torch1_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AbilsCost);
        }

        private void Whip1_MouseEnter(object sender, MouseEventArgs e)
        {
            AbilsCost.Content = "-6";
            LabShow(AbilsCost);
        }

        private void Whip1_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AbilsCost);
        }

        private void Super0_MouseEnter(object sender, MouseEventArgs e)
        {
            AbilsCost.Content = "-10";
            LabShow(AbilsCost);
        }

        private void Super0_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(AbilsCost);
        }
        

        private void Equipments4_Click(object sender, RoutedEventArgs e)
        {
            if (Sets.EquipmentClass == 0)
            {
                OnEquiped(Equip1, EquipH, "Миниган XM214-A", 0, 165);
            }
            if (Sets.EquipmentClass == 1)
            {
                OnEquiped(Equip2, EquipB, "Футболка крутого", 1, 85);
            }
            if (Sets.EquipmentClass == 2)
            {
                OnEquiped(Equip3, EquipL, "Штаны серьёзного", 2, 55);
            }
            if (Sets.EquipmentClass == 3)
            {
                OnEquiped(Equip4, EquipD, "Армейские ботинки", 3, 25);
            }
            StatsMeaning();
            BtnHideX(new Button[] { Equipments4, CancelEq });
            EquipWatch();
        }

        private void Equipments4_MouseEnter(object sender, MouseEventArgs e)
        {
            LabShow(Describe1);
            if (Sets.EquipmentClass == 0)
            {
                EquipCollectInfo("Футболка для настоящих ценителей", AddATK1, "+165");
            }
            if (Sets.EquipmentClass == 1)
            {
                EquipCollectInfo("Футболка для настоящих ценителей", AddDEF1, "+85");
            }
            if (Sets.EquipmentClass == 2)
            {
                EquipCollectInfo("Штаны серьёзных намерений", AddDEF1, "+55");
            }
            if (Sets.EquipmentClass == 3)
            {
                EquipCollectInfo("Прочные сапоги из натуральной дублёной кожи\n",AddDEF1,"+25");
            }
        }

        

        private void Equipments4_MouseLeave(object sender, MouseEventArgs e)
        {
            Describe1.Content = "";
            LabHideX(new Label[] { AddATK1, AddDEF1 });            
        }

        private void EquipCollectInfo(string describe, Label Stat, string statrise)
        {
            Describe1.Content = describe;
            LabShow(Stat);
            Stat.Content = statrise;
            Stat.Foreground = new SolidColorBrush(Color.FromRgb(255, 210, 6));
        }

        private void OnEquiped(Button EquipButton, Label Equips, in string equipment, in Byte ArmClass, in Byte EqPower)
        {
            EquipButton.IsEnabled = false;
            Equips.Content = equipment;
            Super1.PlayerEQ[ArmClass] = EqPower;
            switch (ArmClass)
            {
                case 0:
                    BAG.Hands = false;
                    break;
                case 1:
                    BAG.Jacket = false;
                    break;
                case 2:
                    BAG.Legs = false;
                    break;
                case 3:
                    BAG.Boots = false;
                    break;
                default:
                    BAG.Hands = false;
                    break;
            }
        }
        private void WidelyUsedAnyTimer(out System.Windows.Threading.DispatcherTimer timer, EventHandler SomeEvent, TimeSpan timeSpan)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(SomeEvent);
            timer.Interval = timeSpan;
            timer.Start();
        }
        private void MediaShowAdvanced(MediaElement Media, Uri Source, TimeSpan timeSpan)
        {
            Media.Stop();
            Media.Source = Source;
            Media.Position = timeSpan;
            Media.Play();
        }
    }
}
