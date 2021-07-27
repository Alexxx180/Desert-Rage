using System;
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
using System.Resources;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace WpfApp1
{

    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    public class Txts
    {
        public void SetTxt() {
            Foe = new Foes();
            Bos = new Bosses();
            Doc = new Docs();
            Sct = new Sections();
            Hnt = new Hints();
            Goal = new Goals();
            Bag = new BItems();
            Skl = new Abililities();
            Com = new Common();
            Can = new CancelOptions();
            Fht = new FightOptions();
            Eqp = new Equipment();
            Eqp.SetEquip();
        }
        public class Common : Txts
        {
            public Common() { SetCommon(); }
            private void SetCommon()
            {
                Total = "Всего";
                Hlthy = "Статус: здоров";
                Ill = "Статус: отравлен";
                Exp = "Опыт";
                Lv = "Ур";
                NewLv = "Новый уровень!";
                Won = "Победа!";
                Thres = "Похоже что-то есть...";
                Time = "Время";
                QMark = "Что это?";
                Expert = "Профессионал";
            }
            public String Total { get; set; }
            public String Hlthy { get; set; }
            public String Ill { get; set; }
            public String Exp { get; set; }
            public String Lv { get; set; }
            public String NewLv { get; set; }
            public String Expert { get; set; }
            public String Won { get; set; }
            public String Thres { get; set; }
            public String Time { get; set; }
            public String QMark { get; set; }
        }
        public class FightOptions : Txts
        {
            public FightOptions() { SetFightOptions(); }
            private void SetFightOptions()
            {
                Atk = "Атаковать выбранного врага";
                Def = "Встать в стойку (Защита X2)";
                Esc = "Сбежать из боя";
                Inv = "Посмотреть инвентарь";
                Act = "Особые умения";
                Trg = "Подтвердить цель";
                Gen = "Атаковать всех подряд";
                S1 = "Поджечь выбранного врага";
                S2 = "Ударить врага хлыстом";
                S3 = "Подстрелить врага";
                S4 = "Изучить врага";
            }
            public String Atk { get; set; }
            public String Def { get; set; }
            public String Esc { get; set; }
            public String Inv { get; set; }
            public String Act { get; set; }
            public String Gen { get; set; }
            public String Trg { get; set; }
            public String S1 { get; set; }
            public String S2 { get; set; }
            public String S3 { get; set; }
            public String S4 { get; set; }
        }
        public class CancelOptions : Txts
        {
            public CancelOptions() { SetCancelOptions(); }
            private void SetCancelOptions()
            {
                Fgt = "Отменить нападение";
                Act = "Отменить умение";
                Back = "Обратно к действиям";
            }
            public String Fgt { get; set; }
            public String Act { get; set; }
            public String Back { get; set; }
        }
        public class Foes : Txts
        {
            public Foes() { SetAllEnemyDscr(); }
            private void SetAllEnemyDscr()
            {
                Spider = "Паук";
                Mummy = "Мумия";
                Zombie = "Зомби";
                Bones = "Страж";
                Vulture = "Стервятник";
                Ghoul = "Гуль";
                GrimReaper = "Жнец";
                Scarab = "Скарабей";
                KillerMole = "Моль-убийца";
                Imp = "Прислужник";
                Worm = "П. червь";
                Master = "Мастер";
                GetFast = new string[] { Spider, Mummy, Zombie, Bones, Vulture, Ghoul, GrimReaper, Scarab, KillerMole, Imp, Worm, Master };
                GetByIndexes = new string[,] { { Spider, Mummy, Zombie, Bones }, { Vulture, Ghoul, GrimReaper, Scarab }, { KillerMole, Imp, Worm, Master } };
            }
            public String Spider { get; set; }
            public String Mummy { get; set; }
            public String Zombie { get; set; }
            public String Bones { get; set; }
            public String Vulture { get; set; }
            public String Ghoul { get; set; }
            public String GrimReaper { get; set; }
            public String Scarab { get; set; }
            public String KillerMole { get; set; }
            public String Imp { get; set; }
            public String Worm { get; set; }
            public String Master { get; set; }
            public String[] GetFast { get; set; }
            public String[,] GetByIndexes { get; set; }
        }
        public class Bosses : Txts
        {
            public Bosses() { SetAllEnemyDscr(); }
            private void SetAllEnemyDscr()
            {
                Pharaoh = "Фараон";
                Friend = "????";
                AMaster = "Владыка";
                UghZan = "Угх-зан I";
                GetByIndexes = new string[] { Pharaoh, Friend, AMaster, UghZan };
            }
            public String Pharaoh { get; set; }
            public String Friend { get; set; }
            public String AMaster { get; set; }
            public String UghZan { get; set; }
            public String[] GetByIndexes { get; set; }
        }
        public class Docs : Txts {
            public Docs() { SetDocs(); }

            private void SetDocs()
            {
                InfoChange1 = 0;
                HelpInfo1 = new string[,]{ {"Введение","Древние - кто они?","Приключение","Управление","Сражение","Цель боя","Очки здоровья","Урон","Оборона","Побег","Статус","Показатели","Скорость (СКР)","Больше чем бой","Настройки","Проходы","Сундуки","Сила земли","Сцены" },
                {"Неизвестный...","Предыстория","Розыск","Меню/Выход","Противники","Ходы","Очки действий","Бой","Умения","Результаты","Уровень","Атака (АТК)","Спец. (СПЦ)","Бестиарий","Разработал","Стены","Опасности","Погостить пришёл","Благодарности" },
                {"Древние святыни","Артефакты","Главы","Взаимодействие","Боссы","Действия","АВШ","Выбор","Предметы","Прирост","Опыт","Защита (ЗЩТ)","Время игры","Задачи","До новых встреч","Замки","Камни","Секреты","Финансы" } };
                HelpInfo2 = new string[,] { {"Добро пожаловать, искатели\nприключений! Приветствуем\nвас в кратком своде правил.","Древние - люди, что когда-то\nобладали технологиями, кото-\nрые нам и не снились.","Вам доступно создание\nнового или загрузка старого\nприключения если оно было","Клавиатура обязательна\nПередвижение - WASD,\nВзаимодействие - E","Во время передвижения, на\nвас могут напасть. Не бой-\nтесь сражаться за правое!","Во время сражения нужно\nубрать всех противников и\nбоссов с поля, не погибнув.","Определяют какое количе-\nство урона персонаж может\nвзять, прежде чем умереть.","Числом определяет силу, с\nкоторой бьёт герой или враг,\nприближает к гибели.","Повышает защиту героя в\nдва раза до следующего\nхода.","Существует альтернативный\nспособ выйти из сражения -\nизбежать этим действием.","Выводит состояние героя,\nпри отравлении персонаж\nбудет терять ОЗ.","Влияют на выживаемость\nгероя, каждый отвечает за\nчто-то своё.","Влияет на скорость заполне-\nния АВШ и возможность\nсбежать из боя.","Умения доступны вне боя, а\nещё каждое из них можно\n\"пожамкать\" ^_^.","Не так-то просто справляться\nс шумом? Слишком яркое\nизображение? Не вопрос!","Место, по которому может\nходить герой, обычная\nплита.","Там хранится всевозможное\nоружие и броня древних.\nПочему бы и не одолжить?","Источники, бьющие прямо\nиз огненных песков лечат\nвсе недомогания.","Как никогда лучше показы-\nвают происходящее в\nсамом эпицентре событий." },
                {"Вы играете за одарённого\nархеолога Рэя, его целью\nявляется поиск артефактов.","После глупых войн и жажды\nвласти, люди истратили нас-\n","Здесь находятся все\nискатели! Можно разделять\nпрогресс с друзьями","Клавиатура обязательна\nОткрыть меню - Left CTRL\nВыйти из игры - ESC","Монстры и прочие чудища,\nвышедшие из под контроля\nжаждут вашей гибели","Действия героя и врагов\nраспределены: они могут\nвыполнять их спустя время","От ОД зависит доступ к осо-\nбым действиям - умениям,\nвызывающие эффекты","Опция позволяющая физи-\nчески атаковать врага\nгерою, зависит от АТК.","Каждое умение тратит ОД и\nможет оказывать эффект\nкак на врага, так и на героя.","Победив, вы получаете\nопыт, материалы и ве-\nщи в конце сражения.","Показывает потенциал\nперсонажа, от него за-\nвисят все показатели.","Урон, наносимый героем\nпри обычной атаке. Может\nбыть увеличена оружием.","Специальное влияет на силу\nэффектов от использования\nумений персонажа.","После открытия умения \"Из-\nучение\", вы сможете смот-\nреть показатели врагов","Прошу любить и жаловать:\nТатаринцев Александр,\nвыступал в роли FullStack.","Препятствия, через которые\nнельзя передвигаться. Из\nних составлены лабиринты.","Какое приключение не обо-\nйдётся без опасностей?\nВсё как положено.","-Алло, это кто?\n-Сэм.\n-Шутник, Сэм, это я.","Посвящается (Вы лучшие):\nМасленников Денис,\nМасленникова Татьяна" },
                {"Основными местами для\nпоиска сокровищ стали\nсооружения древних.","Артефакты содержат посла-\nния, лежащие в основе\nключа к мудрости веков","Приключение рассказывает\nисторию, основные события\nкоторой показаны в главах","Все нажатия на кнопки\nосуществляются с помощью\nлевой кнопки мыши (ЛКМ)","Древние стражи и могучие\nвластители, пробудившиеся\nото сна ждут боя.","Совокупность опций возни-\nкающих около персонажа.\nНужны для победы в бою.","Активная временная шкала\nпосле заполнения, даёт ход\nгерою, отображая действия.","Для выбора зоны пораже-\nния. Отмена - вернуться к\nпредыдущим опциям","Использование предметов,\nполученных после боя или\nсозданных материалами.","При повышении уровня, по-\nказатели героя вырастут,\nоблегчая новые задачи.","При сборе достаточного\nколичества - повышает\nуровень.","Снижает урон, получаемый\nот врагов. Может быть\nувеличена доспехами.","Всему своё время и приклю-\nчение - не исключение, бе-\nрегите глаза, друзья!","Для понимания основной\nцели - она разбита на\nзадачи.","Надеюсь данное руководст-\nво было вам полезно, даль-\nше для общего развития =)","Закрытые проходы, веду-\nщие через путь к выходу\nк артефактам. ","Артефакты - ключи, ведущие\nк сокровищам, эта основная\nцель приключения.","Каждое сооружение хранит\nсвои секреты. Сможете ли\nвы отыскать их все?","А в плане денег - у нас нет\nденег. Поможете ли доброй\nкопеечкой? 89212049320" } };
            }
            public Byte InfoChange1 { get; set; }
            public string[,] HelpInfo1 { get; set; }
            public string[,] HelpInfo2 { get; set; }
        }
        public class Hints : Txts
        {
            public Hints() { SetHints(); }
            private void SetHints()
            {
                Status = "ОЗ имеет тенденцию падать до 0. Враги только этого и добиваются.\nПохоже что ненадолго.";
                Skills = "Каждое умение становится доступным при достижении определённого\nуровня. Используя их правильно, можно свернуть горы!";
                Items = "Предметы бывают очень полезными как в бою, так и вне боя. Лучше\nвсего перевязывать раны - иначе этот напалм не выдержать.";
                Equip = "Отличное оснащение даёт преимущество в бою.";
                Tasks = "Выполняя задачи нужно оставаться предельно осторожным. Никто не\nзнает, что поджидает в святилищах древних.";
                Infos = "Герой! Контролируй прогресс\nу точек контроля со знаком \"S\"";
                Setts = "Настройки помогают определить предпочтения. Помимо стандартного\nизменения громкости и яркости, вы можете регулировать скорость боя";

                EqWpn1 = "Прочный костяной кастет. Одно из лучших средств показать свою мощь!";
                EqWpn2 = "Закалённый острый кинжал, пробивающий камни насквозь. Крайне\nсмертоносная игрушка.";
                EqWpn3 = "Меч грёз, рассекающий воздух.";
                EqWpn4 = "Размер не имеет  значения, главное как его используют";
                EqArm1 = "Черная кожаная куртка. Никто не ценит ничего так сильно, как\nнадёжный кожак в жуткую погоду.";
                EqArm2 = "Отлично сохранившиеся доспехи древних воинов. Кажется, что\nради хороших вещей древние даже золота не жалели.";
                EqArm3 = "Нагрудник, отполированный настолько, что в нём видно отражение\n приближающихся врагов.";
                EqArm4 = "Футболка для настоящих ценителей";
                EqBts1 = "Бинтовая обувь. Спасает от ужасной жары здешних песков как никогда.";
                EqBts2 = "Сапоги прирождённых солдат, покрыты слоём железа и укрепл-\nены пластинами.";
                EqBts3 = "Невесомые сапоги, из невероятно прочного материала.";
                EqBts4 = "Прочные сапоги из натуральной дублёной кожи";

                Wrn1 = "Пора передохнуть...";
                Wrn2 = "Эй, это уже не шутки!";
                Wrn3 = "Срочно выключай машину!";
            }
            public string Status { get; set; }
            public string Skills { get; set; }
            public string Items { get; set; }
            public string Equip { get; set; }
            public string Tasks { get; set; }
            public string Infos { get; set; }
            public string Setts { get; set; }
            public string EqWpn1 { get; set; }
            public string EqWpn2 { get; set; }
            public string EqWpn3 { get; set; }
            public string EqWpn4 { get; set; }
            public string EqArm1 { get; set; }
            public string EqArm2 { get; set; }
            public string EqArm3 { get; set; }
            public string EqArm4 { get; set; }
            public string EqPnt1 { get; set; }
            public string EqPnt2 { get; set; }
            public string EqPnt3 { get; set; }
            public string EqPnt4 { get; set; }
            public string EqBts1 { get; set; }
            public string EqBts2 { get; set; }
            public string EqBts3 { get; set; }
            public string EqBts4 { get; set; }
            public string Wrn1 { get; set; }
            public string Wrn2 { get; set; }
            public string Wrn3 { get; set; }
        }
        public class Sections : Txts
        {
            public Sections() { SetHints(); }
            private void SetHints()
            {
                Status = "Статус героя";
                Skills = "Умения героя";
                Items = "Предметы";
                Equip = "Снаряжение героя";
                Tasks = "Текущие цели";
                Infos = "Руководство игрока";
                Setts = "Настройки";
            }
            public string Status { get; set; }
            public string Skills { get; set; }
            public string Items { get; set; }
            public string Equip { get; set; }
            public string Tasks { get; set; }
            public string Infos { get; set; }
            public string Setts { get; set; }
        }
        public class Abililities : Txts
        {
            public Abililities() { SetAbililities(); }
            private void SetAbililities()
            {
                Cur = "Восстановление ОЗ, [-5 ОД]";
                Cr2 = "ОЗ 100% мгновенно, [-10 ОД]";
                Hl = "Лечение статуса, [-3 ОД]";
                Bf = "Повышает атаку, [-12 ОД]";
                Tg = "Повышает защиту, [-8 ОД]";
                Rg = "Постепенно ОЗ+, [-15 ОД]";
                Cn = "Постепенно ОД+, [0 ОД]";
                Tr = "Поджигает врагов, [-4 ОД]";
                Wh = "Дробит кости, [-6 ОД]";
                Th = "Подстрелить врага, [-15 ОД]";
                Sp = "Мощное комбо, [-10 ОД]";
                Sp2 = "Порезы ветром, [-20 ОД]";
                Sp3 = "Обвал камнями, [-30 ОД]";
                Ln = "Анализ врага, [-2 ОД]";
            }
            public string Cur { get; set; }
            public string Cr2 { get; set; }
            public string Hl { get; set; }
            public string Bf { get; set; }
            public string Tg { get; set; }
            public string Rg { get; set; }
            public string Cn { get; set; }
            public string Tr { get; set; }
            public string Wh { get; set; }
            public string Th { get; set; }
            public string Sp { get; set; }
            public string Sp2 { get; set; }
            public string Sp3 { get; set; }
            public string Ln { get; set; }
        }
        public class BItems : Txts
        {
            public BItems() { SetBItems(); }
            private void SetBItems()
            {
                Ant = "-Яд";
                Ban = "+50 ОЗ";
                Etr = "+50 ОД";
                Bld = "+80 ОЗ|ОД";
                Hrb = "+350 ОЗ";
                Er2 = "+300 ОД";
                Slb = "100% ОЗ|ОД";
                Elx = "100% ОЗ|ОД";
            }
            public string Ant { get; set; }
            public string Ban { get; set; }
            public string Etr { get; set; }
            public string Bld { get; set; }
            public string Hrb { get; set; }
            public string Er2 { get; set; }
            public string Slb { get; set; }
            public string Elx { get; set; }
        }
        public class Goals : Txts
        {
            public Goals() { SetTasks(); }
            private void SetTasks()
            {
                T1 = "Найдите способ открыть дверь";
                T2 = "Соберите другой ключ";
                T3 = "Соберите последний ключ";
                T4 = "Проверьте загадочный артефакт";
                T5 = "Другой способ открыть врата";
                T6 = "Откройте путь до артефакта";
                T7 = "Проверьте загадочный артефакт";
                T8 = "Переправа через пропасть";
                T9 = "Заберите последний ключ";
                T10 = "Выберетесь из лабиринта до обвала!";
                E1 = "Найдите и изучите древнее чудовище";
                E2 = "Найдите золотой анх";
                E3 = "Найдите фрагмент удачи";
            }
            public string T1 { get; set; }
            public string T2 { get; set; }
            public string T3 { get; set; }
            public string T4 { get; set; }
            public string T5 { get; set; }
            public string T6 { get; set; }
            public string T7 { get; set; }
            public string T8 { get; set; }
            public string T9 { get; set; }
            public string T10 { get; set; }
            public string E1 { get; set; }
            public string E2 { get; set; }
            public string E3 { get; set; }
        }
        public class Equipment : Txts
        {
            public void SetEquip()
            {
                Hand = new Hands();
                Tors = new Torso();
                Legs = new Anckles();
                Boot = new Boots();
            }
            public class Hands : Equipment
            {
                public Hands() { SetHands(); }
                public void SetHands()
                {
                    Bare = "Пустые руки";
                    Duster = "Костяной кастет";
                    Knife = "Древний кинжал";
                    Sword = "Меч легенды";
                    Minigun = "Миниган XM214-A";
                }
                public string Bare { get; set; }
                public string Duster { get; set; }
                public string Knife { get; set; }
                public string Sword { get; set; }
                public string Minigun { get; set; }
            }
            public class Torso : Equipment
            {
                public Torso() { SetTorso(); }
                public void SetTorso()
                {
                    Bare = "Лёгкая рубашка";
                    Bcoat = "Чёрный кожак";
                    Ancient = "Древняя броня";
                    Legend = "Броня легенды";
                    Serious = "Футболка крутого";
                }
                public string Bare { get; set; }
                public string Bcoat { get; set; }
                public string Ancient { get; set; }
                public string Legend { get; set; }
                public string Serious { get; set; }
            }
            public class Anckles : Equipment
            {
                public Anckles() { SetLegs(); }
                public void SetLegs()
                {
                    Bare = "Стильные штаны";
                    Vulture = "Штаны стервятника";
                    Ancient = "Древние поножи";
                    Legend = "Поножи легенды";
                    Serious = "Штаны серьёзного";
                }
                public string Bare { get; set; }
                public string Vulture { get; set; }
                public string Ancient { get; set; }
                public string Legend { get; set; }
                public string Serious { get; set; }
            }
            public class Boots : Equipment
            {
                public Boots() { SetBoots(); }
                public void SetBoots()
                {
                    Bare = "Начищенные ботинки";
                    Bboots = "Бинтовая обувь";
                    Ancient = "Древние сапоги";
                    Legend = "Сапоги легенды";
                    Serious = "Армейские ботинки";
                }
                public string Bare { get; set; }
                public string Bboots { get; set; }
                public string Ancient { get; set; }
                public string Legend { get; set; }
                public string Serious { get; set; }
            }
            public Hands Hand { get; set; }
            public Torso Tors { get; set; }
            public Anckles Legs { get; set; }
            public Boots Boot { get; set; }
        }
        public Foes Foe { get; set; }
        public Bosses Bos { get; set; }
        public Docs Doc { get; set; }
        public Sections Sct { get; set; }
        public Hints Hnt { get; set; }
        public Equipment Eqp { get; set; }
        public Goals Goal { get; set; }
        public Abililities Skl { get; set; }
        public BItems Bag { get; set; }
        public Common Com { get; set; }
        public CancelOptions Can { get; set; }
        public FightOptions Fht { get; set; }
    }
    public class Paths
    {
        public void SetPaths()
        {
            PersonStatePath = new Static.Person();
            IconStatePath = new Static.Icon();
            FoesStatePath = new Static.Foes();
            BossesStatePath = new Static.Bosses();
            FoesAnimatePath = new Dynamic.Foes();
            BossesAnimatePath = new Dynamic.Bosses();
            PersonAnimatePath = new Dynamic.Person();
            IconAnimatePath = new Dynamic.Icon();
            MiscAnimatePath = new Dynamic.Misc();
            GameMusic = new OST.Music();
            GameSounds = new OST.Sounds();
            GameNoises = new OST.Noises();
            CutScene = new CutScenes();
            Backgrounds = new Static.Map();
            MapModels = new Static.Map.Models();
            Ray = new Static.Map.Models.Guy();
            Msg = new Static.Map.Messages();
            BtnCustomize = new Static.BtnImgs.Usual();
            BtnBefore = new Static.BtnImgs.Before();
            BtnAfter = new Static.BtnImgs.After();
            Adv = new Static.Menu.Adventures();
            MenuImgs = new Static.Menu.MTasks();
            BefMInfoImgs = new Static.Menu.MInfo.MBefore();
            AftMInfoImgs = new Static.Menu.MInfo.MAfter();
            Fighting = new Static.Battle();
            AniModel = new Dynamic.Models();
        }
        public class CutScenes : Paths
        {
            public CutScenes() { SetAllPaths(); }
            public void SetAllPaths()
            {
                Ambushed = @"Resources\CutScenes\BattleStarts\BattleStations1.mp4";
                BattleStations = @"Resources\CutScenes\BattleStarts\BattleStations2.mp4";
                NotAgain = @"Resources\CutScenes\BattleStarts\BattleStations3.mp4";
                PreChapter1 = @"Resources\CutScenes\ChaptersIntroduction\Chapter1.mp4";
                PreChapter2 = @"Resources\CutScenes\ChaptersIntroduction\Chapter2.mp4";
                PreChapter3 = @"Resources\CutScenes\ChaptersIntroduction\Chapter3.mp4";
                PreChapter4 = @"Resources\CutScenes\ChaptersIntroduction\Epilogue.mp4";
                Victory = @"Resources\CutScenes\BattleEnds\Win1.mp4";
                WasteTime = @"Resources\CutScenes\BattleEnds\Win2.mp4";
                PowerRanger = @"Resources\CutScenes\BattleEnds\Win3.mp4";
                Fin_Chapter1 = @"Resources\CutScenes\ChaptersEnding\Final1.mp4";
                Fin_Chapter2 = @"Resources\CutScenes\ChaptersEnding\Final2.mp4";
                Fin_Chapter3 = @"Resources\CutScenes\ChaptersEnding\Final3.mp4";
                Ending = @"Resources\CutScenes\ChaptersEnding\Ending.mp4";
                Titres = @"Resources\CutScenes\ChaptersEnding\Titres.mp4";
            }
            public String Prologue { get; set; }
            public String Ambushed { get; set; }
            public String BattleStations { get; set; }
            public String NotAgain { get; set; }
            public String PreChapter1 { get; set; }
            public String PreChapter2 { get; set; }
            public String PreChapter3 { get; set; }
            public String PreChapter4 { get; set; }
            public String Victory { get; set; }
            public String WasteTime { get; set; }
            public String PowerRanger { get; set; }
            public String Fin_Chapter1 { get; set; }
            public String Fin_Chapter2 { get; set; }
            public String Fin_Chapter3 { get; set; }
            public String Ending { get; set; }
            public String Titres { get; set; }
        }
        public class OST:Paths
        {
            public class Music : OST
            {
                public Music() { SetAllPaths(); }
                public void SetAllPaths()
                {
                    MainTheme = @"Resources\OST\Music\Main_theme.mp3";
                    Prologue = @"Resources\OST\Music\Intro.mp3";

                    AncientPyramid = @"Resources\OST\Music\AncientPyramid_theme.mp3";
                    WaterTemple = @"Resources\OST\Music\WaterTemple_theme.mp3";
                    LavaTemple = @"Resources\OST\Music\FireTemple_theme.mp3";
                    GetAway = @"Resources\OST\Music\GetAway.mp3";

                    FoesChase = @"Resources\OST\Music\BattleTheme1.mp3";
                    HandleThis = @"Resources\OST\Music\BattleTheme2.mp3";
                    StampSmth = @"Resources\OST\Music\BattleTheme3.mp3";

                    LookWhoAwake = @"Resources\OST\Music\BossBattle1.mp3";
                    SayHello = @"Resources\OST\Music\BossBattle2.mp3";
                    SeriousTalk = @"Resources\OST\Music\FinalBoss_theme.mp3";
                    SeriousIsMe = @"Resources\OST\Music\SecretBossFight.mp3";

                    AncientKey = @"Resources\OST\Music\ChFin1.mp3";
                    Conversation = @"Resources\OST\Music\ChFin2.mp3";
                    Threasures = @"Resources\OST\Music\ChFin3.mp3";
                    PutTheEnd = @"Resources\OST\Music\Ending.mp3";

                    SayGoodbye = @"Resources\OST\Music\Titres.mp3";
                }
                public String MainTheme { get; set; }
                public String Prologue { get; set; }
                public String AncientPyramid { get; set; }
                public String WaterTemple { get; set; }
                public String LavaTemple { get; set; }
                public String FoesChase { get; set; }
                public String HandleThis { get; set; }
                public String StampSmth { get; set; }
                public String LookWhoAwake { get; set; }
                public String SayHello { get; set; }
                public String SeriousTalk { get; set; }
                public String SeriousIsMe { get; set; }
                public String AncientKey { get; set; }
                public String Conversation { get; set; }
                public String Threasures { get; set; }
                public String PutTheEnd { get; set; }
                public String GetAway { get; set; }
                public String SayGoodbye { get; set; }
            }
            public class Sounds : OST
            {
                public Sounds() { SetAllPaths(); }
                public void SetAllPaths()
                {
                    DoorOpened = @"Resources\OST\Sounds\DoorOpened.mp3";
                    ChestOpened = @"Resources\OST\Sounds\ChestOpened.mp3";
                    ControlSave = @"Resources\OST\Sounds\SaveSound.mp3";
                    NowTheWinnerIs = @"Resources\OST\Sounds\YouWon.mp3";

                    SpiderDied = @"Resources\OST\Sounds\SpiderDied.mp3";
                    MummyDied = @"Resources\OST\Sounds\MummyDied.mp3";
                    ZombieDied = @"Resources\OST\Sounds\ZombieDied.mp3";
                    BonesDied = @"Resources\OST\Sounds\BonesDied.mp3";
                    VultureDied = @"Resources\OST\Sounds\VultureDied.mp3";
                    GhoulDied = @"Resources\OST\Sounds\GhoulDied.mp3";
                    GrimReaperDied = @"Resources\OST\Sounds\GrimReaperDied.mp3";
                    ScarabDied = @"Resources\OST\Sounds\ScarabDied.mp3";
                    KillerMoleDied = @"Resources\OST\Sounds\KillerMoleDied.mp3";
                    ImpDied = @"Resources\OST\Sounds\ImpDied.mp3";
                    WormDied = @"Resources\OST\Sounds\WormDied.mp3";
                    MasterDied = @"Resources\OST\Sounds\MasterDied.mp3";

                    PhaGetLost = @"Resources\OST\Sounds\DefeatPharaoh.mp3";
                    ByeFriend = @"Resources\OST\Sounds\DefeatFriend.mp3";
                    ThisIsAll = @"Resources\OST\Sounds\DefeatMasterOfAll.mp3";
                    HereGetSome = @"Resources\OST\Sounds\UghZan1Died.mp3";
                }
                public String DoorOpened { get; set; }
                public String ChestOpened { get; set; }
                public String ControlSave { get; set; }
                public String NowTheWinnerIs { get; set; }
                public String SpiderDied { get; set; }
                public String MummyDied { get; set; }
                public String ZombieDied { get; set; }
                public String BonesDied { get; set; }
                public String VultureDied { get; set; }
                public String GhoulDied { get; set; }
                public String GrimReaperDied { get; set; }
                public String ScarabDied { get; set; }
                public String KillerMoleDied { get; set; }
                public String ImpDied { get; set; }
                public String WormDied { get; set; }
                public String MasterDied { get; set; }
                public String PhaGetLost { get; set; }
                public String ByeFriend { get; set; }
                public String ThisIsAll { get; set; }
                public String HereGetSome { get; set; }
            }
            public class Noises : OST
            {
                public Noises()
                {
                    SetAllPaths();
                }
                public void SetAllPaths()
                {
                    Danger = @"Resources\OST\Noises\Ambushed.mp3";
                    Danger2 = @"Resources\OST\Noises\FoesNearby.mp3";
                    Danger3 = @"Resources\OST\Noises\GetReady.mp3";
                    Horror = @"Resources\OST\Noises\Horror.mp3";
                    EgoRage = @"Resources\OST\Noises\PharaohRoar.mp3";
                    
                    StrongStand = @"Resources\OST\Noises\Defence.mp3";
                    FleeAway = @"Resources\OST\Noises\Escape.mp3";
                    HandAttack = @"Resources\OST\Noises\Punch.mp3";
                    Knife = @"Resources\OST\Noises\Knife.mp3";
                    Sword = @"Resources\OST\Noises\Sword.mp3";
                    Minigun = @"Resources\OST\Noises\Minigun2.mp3";

                    Cure = @"Resources\OST\Noises\Cure.mp3";
                    Cure2 = @"Resources\OST\Noises\Cure2.mp3";
                    Heal = @"Resources\OST\Noises\Heal.mp3";
                    PowUp = @"Resources\OST\Noises\PowUp.mp3";
                    Shield = @"Resources\OST\Noises\Shield.mp3";
                    HpUp = @"Resources\OST\Noises\HpUp.mp3";
                    ApUp = @"Resources\OST\Noises\Control.mp3";
                    Torch = @"Resources\OST\Noises\Torch.mp3";
                    Whip = @"Resources\OST\Noises\Whip.mp3";
                    Thrower = @"Resources\OST\Noises\Thrower.mp3";
                    Super = @"Resources\OST\Noises\Super.mp3";
                    Whirl = @"Resources\OST\Noises\Wind.mp3";
                    Quake = @"Resources\OST\Noises\Quake.mp3";
                    Learn = @"Resources\OST\Noises\Scan.mp3";

                    BagOpen = @"Resources\OST\Noises\ItemsOpen.mp3";
                    BagClose = @"Resources\OST\Noises\ItemsClose.mp3";
                    UseItems = @"Resources\OST\Noises\ItemsUsed.mp3";
                    LevelUp = @"Resources\OST\Noises\LevelUp.mp3";
                }
                public String Danger { get; set; }
                public String Danger2 { get; set; }
                public String Danger3 { get; set; }
                public String Horror { get; set; }
                public String EgoRage { get; set; }
                public String StrongStand { get; set; }
                public String FleeAway { get; set; }
                public String HandAttack { get; set; }
                public String Knife { get; set; }
                public String Sword { get; set; }
                public String Minigun { get; set; }
                public String Cure { get; set; }
                public String Cure2 { get; set; }
                public String Heal { get; set; }
                public String PowUp { get; set; }
                public String Shield { get; set; }
                public String HpUp { get; set; }
                public String ApUp { get; set; }
                public String Torch { get; set; }
                public String Whip { get; set; }
                public String Thrower { get; set; }
                public String Super { get; set; }
                public String Whirl { get; set; }
                public String Quake { get; set; }
                public String Learn { get; set; }
                public String BagOpen { get; set; }
                public String BagClose { get; set; }
                public String UseItems { get; set; }
                public String LevelUp { get; set; }
            }
        }
        public class Static : Paths
        {
            public class Map
            {
                public Map()
                {
                    SetAllMapPaths();
                }
                public void SetAllMapPaths()
                {
                    Main = @"/Resources\Images\Locations\Regular\New_game_show.jpg";
                    Location1 = @"/Resources\Images\Locations\Loc1\Loc1.jpg";
                    Location2 = @"/Resources\Images\Locations\Loc2\Loc2.png";
                    Location3 = @"/Resources\Images\Locations\Loc3\Loc3.jpg";
                    Location4 = @"/Resources\Images\Locations\Loc4\Loc4.jpg";
                    Normal = @"/Resources\Images\Locations\Regular\AbsoluteBlack.jpg";
                    Register = @"/Resources/Images/Autorize/Wanted.png";
                    UnRegister = @"/Resources/Images/Autorize/Wanted2.png";
                }
                public class Models : Map
                {
                    public class Guy : Map
                    {
                        public Guy() { SetAllGuyPaths(); }
                        public void SetAllGuyPaths()
                        {
                            StaticUp = @"/Resources/Images/Locations/Total/Person/Static/Up.png";
                            StaticRight = @"/Resources/Images/Locations/Total/Person/Static/Right.png";
                            StaticLeft = @"/Resources/Images/Locations/Total/Person/Static/Left.png";
                            StaticDown = @"/Resources/Images/Locations/Total/Person/Static/Down.png";
                            GoUp1 = @"/Resources/Images/Locations/Total/Person/Walk/Up1.png";
                            GoUp2 = @"/Resources/Images/Locations/Total/Person/Walk/Up2.png";
                            GoLeft = @"/Resources/Images/Locations/Total/Person/Walk/Left.png";
                            GoRight = @"/Resources/Images/Locations/Total/Person/Walk/Right.png";
                            GoDown1 = @"/Resources/Images/Locations/Total/Person/Walk/Down1.png";
                            GoDown2 = @"/Resources/Images/Locations/Total/Person/Walk/Down2.png";
                        }
                        public String StaticUp { get; set; }
                        public String StaticRight { get; set; }
                        public String StaticLeft { get; set; }
                        public String StaticDown { get; set; }
                        public String GoUp1 { get; set; }
                        public String GoUp2 { get; set; }
                        public String GoLeft { get; set; }
                        public String GoRight { get; set; }
                        public String GoDown1 { get; set; }
                        public String GoDown2 { get; set; }
                    }
                    public Models() { SetAllModPaths(); }
                    public void SetAllModPaths()
                    {
                        LeverOff = @"/Resources\Images\Locations\Loc3\Models\LeverOff.png";
                        LeverOn = @"/Resources\Images\Locations\Loc3\Models\LeverOn.png";
                        ChestClosed1 = @"/Resources\Images\Locations\Total\Chests\ChestClosed(ver1).png";
                        ChestClosed2 = @"/Resources\Images\Locations\Total\Chests\ChestClosed(ver2).png";
                        ChestClosed3 = @"/Resources\Images\Locations\Total\Chests\ChestClosed(ver3).png";
                        ChestOpened1 = @"/Resources\Images\Locations\Total\Chests\ChestOpened(ver1).png";
                        ChestOpened2 = @"/Resources\Images\Locations\Total\Chests\ChestOpened(ver2).png";
                        ChestOpened3 = @"/Resources\Images\Locations\Total\Chests\ChestOpened(ver3).png";
                        Artifact1 = @"/Resources\Images\Locations\Loc1\Models\AncientArtifact.png";
                        Artifact2 = @"/Resources\Images\Locations\Loc2\Models\AncientArtifact2.png";
                        Artifact3 = @"/Resources\Images\Locations\Loc3\Models\AncientArtifact3.png";
                    }
                    public String LeverOff { get; set; }
                    public String LeverOn { get; set; }
                    public String ChestClosed1 { get; set; }
                    public String ChestClosed2 { get; set; }
                    public String ChestClosed3 { get; set; }
                    public String ChestOpened1 { get; set; }
                    public String ChestOpened2 { get; set; }
                    public String ChestOpened3 { get; set; }
                    public String Artifact1 { get; set; }
                    public String Artifact2 { get; set; }
                    public String Artifact3 { get; set; }
                }
                public class Messages : Map
                {
                    public Messages() { SetAllMsgPaths(); }
                    public void SetAllMsgPaths()
                    {
                        Knucleduster = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomWeapon1.png";
                        AncientKnife = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomWeapon2.png";
                        LegendSword = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomWeapon3.png";
                        SeriousMinigun = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomWeapon4.png";
                        LeatherArmor = @"/Resources\Images\Locations\Messages\Chests\GetItemsArmor1.png";
                        AncientArmor = @"/Resources\Images\Locations\Messages\Chests\GetItemsArmor2.png";
                        LegendArmor = @"/Resources\Images\Locations\Messages\Chests\GetItemsArmor3.png";
                        FeatherWears = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomPants1.png";
                        AncientPants = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomPants2.png";
                        LegendPants = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomPants3.png";
                        SeriousPants = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomPants4.png";
                        BandageBoots = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomBoots1.png";
                        StrongBoots = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomBoots2.png";
                        LegendBoots = @"/Resources\Images\Locations\Messages\Chests\GetItemsCustomBoots3.png";
                        Tb1_Msg1 = @"/Resources\Images\Locations\Messages\Tables\TableMessage1.png";
                        Tb1_Msg2 = @"/Resources\Images\Locations\Messages\Tables\TableMessage4.png";
                        Tb1_Msg3 = @"/Resources\Images\Locations\Messages\Tables\TableMessage7.png";
                        Tb2_Msg1 = @"/Resources\Images\Locations\Messages\Tables\TableMessage2.png";
                        Tb2_Msg2 = @"/Resources\Images\Locations\Messages\Tables\TableMessage5.png";
                        Tb2_Msg3 = @"/Resources\Images\Locations\Messages\Tables\TableMessage8.png";
                        Tb3_Msg1 = @"/Resources\Images\Locations\Messages\Tables\TableMessage3.png";
                        Tb3_Msg2 = @"/Resources\Images\Locations\Messages\Tables\TableMessage6.png";
                        Tb3_Msg3 = @"/Resources\Images\Locations\Messages\Tables\TableMessage9.png";
                        Completed = @"/Resources\Images\Locations\Messages\TasksTaskCompleted.png";
                    }
                    public String Knucleduster { get; set; }
                    public String AncientKnife { get; set; }
                    public String LegendSword { get; set; }
                    public String SeriousMinigun { get; set; }
                    public String LeatherArmor { get; set; }
                    public String AncientArmor { get; set; }
                    public String LegendArmor { get; set; }
                    public String FeatherWears { get; set; }
                    public String AncientPants { get; set; }
                    public String SeriousPants { get; set; }
                    public String LegendPants { get; set; }
                    public String BandageBoots { get; set; }
                    public String StrongBoots { get; set; }
                    public String LegendBoots { get; set; }
                    public String Tb1_Msg1 { get; set; }
                    public String Tb1_Msg2 { get; set; }
                    public String Tb1_Msg3 { get; set; }
                    public String Tb2_Msg1 { get; set; }
                    public String Tb2_Msg2 { get; set; }
                    public String Tb2_Msg3 { get; set; }
                    public String Tb3_Msg1 { get; set; }
                    public String Tb3_Msg2 { get; set; }
                    public String Tb3_Msg3 { get; set; }
                    public String Completed { get; set; }
                }
                public String Main { get; set; }
                public String Location1 { get; set; }
                public String Location2 { get; set; }
                public String Location3 { get; set; }
                public String Location4 { get; set; }
                public String Normal { get; set; }
                public String Register { get; set; }
                public String UnRegister { get; set; }
            }
            public class Battle : Static
            {
                public Battle() { SetAllBPaths(); }
                public void SetAllBPaths()
                {
                    Battle1 = @"/Resources\Images\Fight\Background\Battle1.jpg";
                    Battle2 = @"/Resources\Images\Fight\Background\Battle2.jpg";
                    Battle3 = @"/Resources\Images\Fight\Background\Battle3.jpg";
                }
                public String Battle1 { get; set; }
                public String Battle2 { get; set; }
                public String Battle3 { get; set; }
            }
            public class Menu : Static
            {
                public class Adventures : Menu
                {
                    public Adventures() { SetAllAPaths(); }
                    public void SetAllAPaths()
                    {
                        AdventureLock = @"/Resources\Images\Autorize\Adventures5.png";
                        BeforeNewAdv = @"/Resources\Images\Autorize\Adventures3.png";
                        AfterNewAdv = @"/Resources\Images\Autorize\Adventures1.png";
                        BeforeConAdv = @"/Resources\Images\Autorize\Adventures4.png";
                        AfterConAdv = @"/Resources\Images\Autorize\Adventures2.png";
                        BeforeSkip = @"/Resources\Images\Autorize\Skips1.png";
                        AfterSkip = @"/Resources\Images\Autorize\Skips2.png";
                    }
                    public String BeforeNewAdv { get; set; }
                    public String AfterNewAdv { get; set; }
                    public String BeforeConAdv { get; set; }
                    public String AfterConAdv { get; set; }
                    public String AdventureLock { get; set; }
                    public String BeforeSkip { get; set; }
                    public String AfterSkip { get; set; }
                }
                public class MTasks : Menu
                {
                    public MTasks() { SetAllTPaths(); }
                    public void SetAllTPaths()
                    {
                        UsualTask = @"/Resources\Images\Menu\Tasks\Priority\ActiveTask.png";
                        Completed = @"/Resources\Images\Menu\Tasks\Priority\CompletedTask.png";
                        ExperTask = @"/Resources\Images\Menu\Tasks\Priority\ExperTask.png";
                    }
                    public String UsualTask { get; set; }
                    public String ExperTask { get; set; }
                    public String Completed { get; set; }
                }
                public class MInfo : Menu
                {
                    public class MAfter : MInfo
                    {
                        public MAfter() { SetAllMPaths(); }
                        public void SetAllMPaths()
                        {
                            Help1_1 = @"/Resources\Images\Menu\Help\Inform\Page1\Info1\Introduction2.png";
                            Help1_2 = @"/Resources\Images\Menu\Help\Inform\Page1\Info2\Founder2.png";
                            Help1_3 = @"/Resources\Images\Menu\Help\Inform\Page1\Info3\AncientPlaces2.png";
                            Help2_1 = @"/Resources\Images\Menu\Help\Inform\Page2\Info1\WhoIsAncients2.png";
                            Help2_2 = @"/Resources\Images\Menu\Help\Inform\Page2\Info2\PreHistory2.png";
                            Help2_3 = @"/Resources\Images\Menu\Help\Inform\Page2\Info3\Artifacts2.png";
                            Help3_1 = @"/Resources\Images\Menu\Help\Inform\Page3\Info1\NewAdventures2.png";
                            Help3_2 = @"/Resources\Images\Menu\Help\Inform\Page3\Info2\Wanted2.png";
                            Help3_3 = @"/Resources\Images\Menu\Help\Inform\Page3\Info3\Chapters2.png";
                            Help4_1 = @"/Resources\Images\Menu\Help\Inform\Page4\Info1\Movement2.png";
                            Help4_2 = @"/Resources\Images\Menu\Help\Inform\Page4\Info2\Exit2.png";
                            Help4_3 = @"/Resources\Images\Menu\Help\Inform\Page4\Info3\Click2.png";
                            Help5_1 = @"/Resources\Images\Menu\Help\Inform\Page5\Info1\Fight2.png";
                            Help5_2 = @"/Resources\Images\Menu\Help\Inform\Page5\Info2\Foes2.png";
                            Help5_3 = @"/Resources\Images\Menu\Help\Inform\Page5\Info3\Bosses2.png";
                            Help6_1 = @"/Resources\Images\Menu\Help\Inform\Page6\Info1\FoesDestroy2.png";
                            Help6_2 = @"/Resources\Images\Menu\Help\Inform\Page6\Info2\Timing2.png";
                            Help6_3 = @"/Resources\Images\Menu\Help\Inform\Page6\Info3\Actions2.png";
                            Help7_1 = @"/Resources\Images\Menu\Help\Inform\Page7\Info1\Hp2.png";
                            Help7_2 = @"/Resources\Images\Menu\Help\Inform\Page7\Info2\Ap2.png";
                            Help7_3 = @"/Resources\Images\Menu\Help\Inform\Page7\Info3\Time2.png";
                            Help8_1 = @"/Resources\Images\Menu\Help\Inform\Page8\Info1\Damage2.png";
                            Help8_2 = @"/Resources\Images\Menu\Help\Inform\Page8\Info2\Kombat2.png";
                            Help8_3 = @"/Resources\Images\Menu\Help\Inform\Page8\Info3\Select2.png";
                            Help9_1 = @"/Resources\Images\Menu\Help\Inform\Page9\Info1\Defence2.png";
                            Help9_2 = @"/Resources\Images\Menu\Help\Inform\Page9\Info2\Skills2.png";
                            Help9_3 = @"/Resources\Images\Menu\Help\Inform\Page9\Info3\Bag2.png";
                            Help10_1 = @"/Resources\Images\Menu\Help\Inform\Page10\Info1\Flee2.png";
                            Help10_2 = @"/Resources\Images\Menu\Help\Inform\Page10\Info2\Results2.png";
                            Help10_3 = @"/Resources\Images\Menu\Help\Inform\Page10\Info3\StatsUp2.png";
                            Help11_1 = @"/Resources\Images\Menu\Help\Inform\Page11\Info1\Status2.png";
                            Help11_2 = @"/Resources\Images\Menu\Help\Inform\Page11\Info2\Levels2.png";
                            Help11_3 = @"/Resources\Images\Menu\Help\Inform\Page11\Info3\Exp2.png";
                            Help12_1 = @"/Resources\Images\Menu\Help\Inform\Page12\Info1\Stats2.png";
                            Help12_2 = @"/Resources\Images\Menu\Help\Inform\Page12\Info2\ATK2.png";
                            Help12_3 = @"/Resources\Images\Menu\Help\Inform\Page12\Info3\DEF2.png";
                            Help13_1 = @"/Resources\Images\Menu\Help\Inform\Page13\Info1\SPD2.png";
                            Help13_2 = @"/Resources\Images\Menu\Help\Inform\Page13\Info2\SPC2.png";
                            Help13_3 = @"/Resources\Images\Menu\Help\Inform\Page13\Info3\TimeOut2.png";
                            Help14_1 = @"/Resources\Images\Menu\Help\Inform\Page14\Info1\MoreFight2.png";
                            Help14_2 = @"/Resources\Images\Menu\Help\Inform\Page14\Info2\Bestiary2.png";
                            Help14_3 = @"/Resources\Images\Menu\Help\Inform\Page14\Info3\Tasks2.png";
                            Help15_1 = @"/Resources\Images\Menu\Help\Inform\Page15\Info1\Settings2.png";
                            Help15_2 = @"/Resources\Images\Menu\Help\Inform\Page15\Info2\Creator2.png";
                            Help15_3 = @"/Resources\Images\Menu\Help\Inform\Page15\Info3\Goodbye2.png";
                            Help16_1 = @"/Resources\Images\Menu\Help\Inform\Page16\Info1\Ways2.png";
                            Help16_2 = @"/Resources\Images\Menu\Help\Inform\Page16\Info2\Walls2.png";
                            Help16_3 = @"/Resources\Images\Menu\Help\Inform\Page16\Info3\Locks2.png";
                            Help17_1 = @"/Resources\Images\Menu\Help\Inform\Page17\Info1\Chests2.png";
                            Help17_2 = @"/Resources\Images\Menu\Help\Inform\Page17\Info2\Dangers2.png";
                            Help17_3 = @"/Resources\Images\Menu\Help\Inform\Page17\Info3\Artifacts2.png";
                            Help18_1 = @"/Resources\Images\Menu\Help\Inform\Page18\Info1\Sources2.png";
                            Help18_2 = @"/Resources\Images\Menu\Help\Inform\Page18\Info2\SupposeSam2.png";
                            Help18_3 = @"/Resources\Images\Menu\Help\Inform\Page18\Info3\Secrets2.png";
                            Help19_1 = @"/Resources\Images\Menu\Help\Inform\Page19\Info1\Scenes2.png";
                            Help19_2 = @"/Resources\Images\Menu\Help\Inform\Page19\Info2\Thanks2.png";
                            Help19_3 = @"/Resources\Images\Menu\Help\Inform\Page19\Info3\Help2.png";
                        }
                        public String Help1_1 { get; set; }
                        public String Help1_2 { get; set; }
                        public String Help1_3 { get; set; }
                        public String Help2_1 { get; set; }
                        public String Help2_2 { get; set; }
                        public String Help2_3 { get; set; }
                        public String Help3_1 { get; set; }
                        public String Help3_2 { get; set; }
                        public String Help3_3 { get; set; }
                        public String Help4_1 { get; set; }
                        public String Help4_2 { get; set; }
                        public String Help4_3 { get; set; }
                        public String Help5_1 { get; set; }
                        public String Help5_2 { get; set; }
                        public String Help5_3 { get; set; }
                        public String Help6_1 { get; set; }
                        public String Help6_2 { get; set; }
                        public String Help6_3 { get; set; }
                        public String Help7_1 { get; set; }
                        public String Help7_2 { get; set; }
                        public String Help7_3 { get; set; }
                        public String Help8_1 { get; set; }
                        public String Help8_2 { get; set; }
                        public String Help8_3 { get; set; }
                        public String Help9_1 { get; set; }
                        public String Help9_2 { get; set; }
                        public String Help9_3 { get; set; }
                        public String Help10_1 { get; set; }
                        public String Help10_2 { get; set; }
                        public String Help10_3 { get; set; }
                        public String Help11_1 { get; set; }
                        public String Help11_2 { get; set; }
                        public String Help11_3 { get; set; }
                        public String Help12_1 { get; set; }
                        public String Help12_2 { get; set; }
                        public String Help12_3 { get; set; }
                        public String Help13_1 { get; set; }
                        public String Help13_2 { get; set; }
                        public String Help13_3 { get; set; }
                        public String Help14_1 { get; set; }
                        public String Help14_2 { get; set; }
                        public String Help14_3 { get; set; }
                        public String Help15_1 { get; set; }
                        public String Help15_2 { get; set; }
                        public String Help15_3 { get; set; }
                        public String Help16_1 { get; set; }
                        public String Help16_2 { get; set; }
                        public String Help16_3 { get; set; }
                        public String Help17_1 { get; set; }
                        public String Help17_2 { get; set; }
                        public String Help17_3 { get; set; }
                        public String Help18_1 { get; set; }
                        public String Help18_2 { get; set; }
                        public String Help18_3 { get; set; }
                        public String Help19_1 { get; set; }
                        public String Help19_2 { get; set; }
                        public String Help19_3 { get; set; }
                    }
                    public class MBefore : MInfo
                    {
                        public MBefore() { SetAllMPaths(); }
                        public void SetAllMPaths()
                        {
                            Help1_1 = @"/Resources/Images/Menu/Help/Inform/Page1/Info1/Introduction1.png";
                            Help1_2 = @"/Resources/Images/Menu/Help/Inform/Page1/Info2/Founder1.png";
                            Help1_3 = @"/Resources/Images/Menu/Help/Inform/Page1/Info3/AncientPlaces1.png";
                            Help2_1 = @"/Resources/Images/Menu/Help/Inform/Page2/Info1/WhoIsAncients1.png";
                            Help2_2 = @"/Resources/Images/Menu/Help/Inform/Page2/Info2/PreHistory1.png";
                            Help2_3 = @"/Resources/Images/Menu/Help/Inform/Page2/Info3/Artifacts1.png";
                            Help3_1 = @"/Resources/Images/Menu/Help/Inform/Page3/Info1/NewAdventures1.png";
                            Help3_2 = @"/Resources/Images/Menu/Help/Inform/Page3/Info2/Wanted1.png";
                            Help3_3 = @"/Resources/Images/Menu/Help/Inform/Page3/Info3/Chapters1.png";
                            Help4_1 = @"/Resources/Images/Menu/Help/Inform/Page4/Info1/Movement1.png";
                            Help4_2 = @"/Resources/Images/Menu/Help/Inform/Page4/Info2/Exit1.png";
                            Help4_3 = @"/Resources/Images/Menu/Help/Inform/Page4/Info3/Click1.png";
                            Help5_1 = @"/Resources/Images/Menu/Help/Inform/Page5/Info1/Fight1.png";
                            Help5_2 = @"/Resources/Images/Menu/Help/Inform/Page5/Info2/Foes1.png";
                            Help5_3 = @"/Resources/Images/Menu/Help/Inform/Page5/Info3/Bosses1.png";
                            Help6_1 = @"/Resources/Images/Menu/Help/Inform/Page6/Info1/FoesDestroy1.png";
                            Help6_2 = @"/Resources/Images/Menu/Help/Inform/Page6/Info2/Timing1.png";
                            Help6_3 = @"/Resources/Images/Menu/Help/Inform/Page6/Info3/Actions1.png";
                            Help7_1 = @"/Resources/Images/Menu/Help/Inform/Page7/Info1/Hp1.png";
                            Help7_2 = @"/Resources/Images/Menu/Help/Inform/Page7/Info2/Ap1.png";
                            Help7_3 = @"/Resources/Images/Menu/Help/Inform/Page7/Info3/Time1.png";
                            Help8_1 = @"/Resources/Images/Menu/Help/Inform/Page8/Info1/Damage1.png";
                            Help8_2 = @"/Resources/Images/Menu/Help/Inform/Page8/Info2/Kombat1.png";
                            Help8_3 = @"/Resources/Images/Menu/Help/Inform/Page8/Info3/Select1.png";
                            Help9_1 = @"/Resources/Images/Menu/Help/Inform/Page9/Info1/Defence1.png";
                            Help9_2 = @"/Resources/Images/Menu/Help/Inform/Page9/Info2/Skills1.png";
                            Help9_3 = @"/Resources/Images/Menu/Help/Inform/Page9/Info3/Bag1.png";
                            Help10_1 = @"/Resources/Images/Menu/Help/Inform/Page10/Info1/Flee1.png";
                            Help10_2 = @"/Resources/Images/Menu/Help/Inform/Page10/Info2/Results1.png";
                            Help10_3 = @"/Resources/Images/Menu/Help/Inform/Page10/Info3/StatsUp1.png";
                            Help11_1 = @"/Resources/Images/Menu/Help/Inform/Page11/Info1/Status1.png";
                            Help11_2 = @"/Resources/Images/Menu/Help/Inform/Page11/Info2/Levels1.png";
                            Help11_3 = @"/Resources/Images/Menu/Help/Inform/Page11/Info3/Exp1.png";
                            Help12_1 = @"/Resources/Images/Menu/Help/Inform/Page12/Info1/Stats1.png";
                            Help12_2 = @"/Resources/Images/Menu/Help/Inform/Page12/Info2/ATK1.png";
                            Help12_3 = @"/Resources/Images/Menu/Help/Inform/Page12/Info3/DEF1.png";
                            Help13_1 = @"/Resources/Images/Menu/Help/Inform/Page13/Info1/SPD1.png";
                            Help13_2 = @"/Resources/Images/Menu/Help/Inform/Page13/Info2/SPC1.png";
                            Help13_3 = @"/Resources/Images/Menu/Help/Inform/Page13/Info3/TimeOut1.png";
                            Help14_1 = @"/Resources/Images/Menu/Help/Inform/Page14/Info1/MoreFight1.png";
                            Help14_2 = @"/Resources/Images/Menu/Help/Inform/Page14/Info2/Bestiary1.png";
                            Help14_3 = @"/Resources/Images/Menu/Help/Inform/Page14/Info3/Tasks1.png";
                            Help15_1 = @"/Resources/Images/Menu/Help/Inform/Page15/Info1/Settings1.png";
                            Help15_2 = @"/Resources/Images/Menu/Help/Inform/Page15/Info2/Creator1.png";
                            Help15_3 = @"/Resources/Images/Menu/Help/Inform/Page15/Info3/Goodbye1.png";
                            Help16_1 = @"/Resources/Images/Menu/Help/Inform/Page16/Info1/Ways1.png";
                            Help16_2 = @"/Resources/Images/Menu/Help/Inform/Page16/Info2/Walls1.png";
                            Help16_3 = @"/Resources/Images/Menu/Help/Inform/Page16/Info3/Locks1.png";
                            Help17_1 = @"/Resources/Images/Menu/Help/Inform/Page17/Info1/Chests1.png";
                            Help17_2 = @"/Resources/Images/Menu/Help/Inform/Page17/Info2/Dangers1.png";
                            Help17_3 = @"/Resources/Images/Menu/Help/Inform/Page17/Info3/Artifacts1.png";
                            Help18_1 = @"/Resources/Images/Menu/Help/Inform/Page18/Info1/Sources1.png";
                            Help18_2 = @"/Resources/Images/Menu/Help/Inform/Page18/Info2/SupposeSam1.png";
                            Help18_3 = @"/Resources/Images/Menu/Help/Inform/Page18/Info3/Secrets1.png";
                            Help19_1 = @"/Resources/Images/Menu/Help/Inform/Page19/Info1/Scenes1.png";
                            Help19_2 = @"/Resources/Images/Menu/Help/Inform/Page19/Info2/Thanks1.png";
                            Help19_3 = @"/Resources/Images/Menu/Help/Inform/Page19/Info3/Help1.png";
                        }
                        public String Help1_1 { get; set; }
                        public String Help1_2 { get; set; }
                        public String Help1_3 { get; set; }
                        public String Help2_1 { get; set; }
                        public String Help2_2 { get; set; }
                        public String Help2_3 { get; set; }
                        public String Help3_1 { get; set; }
                        public String Help3_2 { get; set; }
                        public String Help3_3 { get; set; }
                        public String Help4_1 { get; set; }
                        public String Help4_2 { get; set; }
                        public String Help4_3 { get; set; }
                        public String Help5_1 { get; set; }
                        public String Help5_2 { get; set; }
                        public String Help5_3 { get; set; }
                        public String Help6_1 { get; set; }
                        public String Help6_2 { get; set; }
                        public String Help6_3 { get; set; }
                        public String Help7_1 { get; set; }
                        public String Help7_2 { get; set; }
                        public String Help7_3 { get; set; }
                        public String Help8_1 { get; set; }
                        public String Help8_2 { get; set; }
                        public String Help8_3 { get; set; }
                        public String Help9_1 { get; set; }
                        public String Help9_2 { get; set; }
                        public String Help9_3 { get; set; }
                        public String Help10_1 { get; set; }
                        public String Help10_2 { get; set; }
                        public String Help10_3 { get; set; }
                        public String Help11_1 { get; set; }
                        public String Help11_2 { get; set; }
                        public String Help11_3 { get; set; }
                        public String Help12_1 { get; set; }
                        public String Help12_2 { get; set; }
                        public String Help12_3 { get; set; }
                        public String Help13_1 { get; set; }
                        public String Help13_2 { get; set; }
                        public String Help13_3 { get; set; }
                        public String Help14_1 { get; set; }
                        public String Help14_2 { get; set; }
                        public String Help14_3 { get; set; }
                        public String Help15_1 { get; set; }
                        public String Help15_2 { get; set; }
                        public String Help15_3 { get; set; }
                        public String Help16_1 { get; set; }
                        public String Help16_2 { get; set; }
                        public String Help16_3 { get; set; }
                        public String Help17_1 { get; set; }
                        public String Help17_2 { get; set; }
                        public String Help17_3 { get; set; }
                        public String Help18_1 { get; set; }
                        public String Help18_2 { get; set; }
                        public String Help18_3 { get; set; }
                        public String Help19_1 { get; set; }
                        public String Help19_2 { get; set; }
                        public String Help19_3 { get; set; }
                    }
                }
            }

            public class BtnImgs : Static
            {
                public class Usual : BtnImgs
                {
                    public Usual() { SetAllPaths(); }
                    public void SetAllPaths()
                    {
                        ArrowNext = @"/Resources/Images/Fight/Options/ToNext.png";
                        ArrowPrev = @"/Resources/Images/Fight/Options/ToPrev.png";
                        Knucleduster= @"/Resources/Images/Menu/Equip/Equipment/KnucledusterItem.png";
                        AncientKnife = @"/Resources/Images/Menu/Equip/Equipment/AncientKnife.png";
                        LegendSword = @"/Resources/Images/Menu/Equip/Equipment/LegendSword.png";
                        SeriousMinigun = @"/Resources/Images/Menu/Equip/Equipment/SeriousMinigun.png";
                        LeatherArmor = @"/Resources/Images/Menu/Equip/Equipment/BlackSkinItems.png";
                        AncientArmor = @"/Resources/Images/Menu/Equip/Equipment/AncientArmorButton.png";
                        LegendArmor = @"/Resources/Images/Menu/Equip/Equipment/LegendArmor.png";
                        SeriousTshirt = @"/Resources/Images/Menu/Equip/Equipment/CoolT-shirt.png";
                        FeatherWears = @"/Resources/Images/Menu/Equip/Equipment/EagleWearsItems.png";
                        AncientPants = @"/Resources/Images/Menu/Equip/Equipment/WarPants.png";
                        LegendPants = @"/Resources/Images/Menu/Equip/Equipment/LegendPants.png";
                        SeriousPants = @"/Resources/Images/Menu/Equip/Equipment/SeriousPants.png";
                        BandageBoots = @"/Resources/Images/Menu/Equip/Equipment/BandageBootsItems.png";
                        StrongBoots = @"/Resources/Images/Menu/Equip/Equipment/ManBoots.png";
                        LegendBoots = @"/Resources/Images/Menu/Equip/Equipment/LegendBoots.png";
                        SeriousBoots = @"/Resources/Images/Menu/Equip/Equipment/SeriousBoots.png";
                    }
                    public String ArrowNext { get; set; }
                    public String ArrowPrev { get; set; }
                    public String Knucleduster { get; set; }
                    public String AncientKnife { get; set; }
                    public String LegendSword { get; set; }
                    public String SeriousMinigun { get; set; }
                    public String LeatherArmor { get; set; }
                    public String AncientArmor { get; set; }
                    public String LegendArmor { get; set; }
                    public String SeriousTshirt { get; set; }
                    public String FeatherWears { get; set; }
                    public String AncientPants { get; set; }
                    public String LegendPants { get; set; }
                    public String SeriousPants { get; set; }
                    public String BandageBoots { get; set; }
                    public String StrongBoots { get; set; }
                    public String LegendBoots { get; set; }
                    public String SeriousBoots { get; set; }
                }
                public class Before : BtnImgs
                {
                    public Before() { SetAllPaths(); }
                    public void SetAllPaths()
                    {
                        Fight = @"/Resources\Images\Fight\Options\FightBeforeImg.png";
                        Defence = @"/Resources\Images\Fight\Options\DefenceBeforeImg.png";
                        Escape = @"/Resources\Images\Fight\Options\EscapeBeforeImg.png";
                        Bag = @"/Resources\Images\Fight\Options\ItemsBeforeImg.png";
                        Skills = @"/Resources\Images\Fight\Options\SkillsBeforeImg.png";
                        Select = @"/Resources\Images\Fight\Options\TrgtSelectBeforeImg.png";
                        Genocide = @"/Resources\Images\Fight\Options\GenocideBeforeImg.png";
                    }
                    public String Fight { get; set; }
                    public String Defence { get; set; }
                    public String Escape { get; set; }
                    public String Bag { get; set; }
                    public String Skills { get; set; }
                    public String Select { get; set; }
                    public String Genocide { get; set; }
                }
                public class After : BtnImgs
                {
                    public After() { SetAllPaths(); }
                    public void SetAllPaths()
                    {
                        Fight = @"/Resources\Images\Fight\Options\FightAfterImg.png";
                        Defence = @"/Resources\Images\Fight\Options\DefenceAfterImg.png";
                        Escape = @"/Resources\Images\Fight\Options\EscapeAfterImg.png";
                        Bag = @"/Resources\Images\Fight\Options\ItemsAfterImg.png";
                        Skills = @"/Resources\Images\Fight\Options\SkillsAfterImg.png";
                        Select = @"/Resources\Images\Fight\Options\TrgtSelectAfterImg.png";
                        Genocide = @"/Resources\Images\Fight\Options\GenocideAfterImg.png";
                    }
                    public String Fight { get; set; }
                    public String Defence { get; set; }
                    public String Escape { get; set; }
                    public String Bag { get; set; }
                    public String Skills { get; set; }
                    public String Select { get; set; }
                    public String Genocide { get; set; }
                }
            }
            public class Foes : Static
            {
                public Foes() { SetAllEnemyPaths(); }

                private void SetAllEnemyPaths()
                {
                    Spider = @"/Resources\Images\Fight\Enemies\Enemies\Spider.png";
                    Mummy = @"/Resources\Images\Fight\Enemies\Enemies\Mummy.png";
                    Zombie = @"/Resources\Images\Fight\Enemies\Enemies\Zombie.png";
                    Bones = @"/Resources\Images\Fight\Enemies\Enemies\Bones.png";
                    Vulture = @"/Resources\Images\Fight\Enemies\Enemies\Vulture.png";
                    Ghoul = @"/Resources\Images\Fight\Enemies\Enemies\Ghoul.png";
                    GrimReaper = @"/Resources\Images\Fight\Enemies\Enemies\GrimReaper.png";
                    Scarab = @"/Resources\Images\Fight\Enemies\Enemies\Scarab.png";
                    KillerMole = @"/Resources\Images\Fight\Enemies\Enemies\KillerMole.png";
                    Imp = @"/Resources\Images\Fight\Enemies\Enemies\Imp.png";
                    Worm = @"/Resources\Images\Fight\Enemies\Enemies\Worm.png";
                    Master = @"/Resources\Images\Fight\Enemies\Enemies\Master.png";

                    SpiderIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Spider1.png";
                    MummyIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Mummy1.png";
                    ZombieIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Zombie1.png";
                    BonesIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Bones1.png";
                    VultureIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Vulture1.png";
                    GhoulIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Ghoul1.png";
                    GrimReaperIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\GrimReaper1.png";
                    ScarabIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Scarab.png";
                    KillerMoleIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\KillerMole1.png";
                    ImpIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Imp1.png";
                    WormIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Worm1.png";
                    MasterIcon = @"/Resources\Images\Fight\Enemies\EnemyImgs\Master1.png";
                }
                public String Spider { get; set; }
                public String Mummy { get; set; }
                public String Zombie { get; set; }
                public String Bones { get; set; }
                public String Vulture { get; set; }
                public String Ghoul { get; set; }
                public String GrimReaper { get; set; }
                public String Scarab { get; set; }
                public String KillerMole { get; set; }
                public String Imp { get; set; }
                public String Worm { get; set; }
                public String Master { get; set; }
                public String SpiderIcon { get; set; }
                public String MummyIcon { get; set; }
                public String ZombieIcon { get; set; }
                public String BonesIcon { get; set; }
                public String VultureIcon { get; set; }
                public String GhoulIcon { get; set; }
                public String GrimReaperIcon { get; set; }
                public String ScarabIcon { get; set; }
                public String KillerMoleIcon { get; set; }
                public String ImpIcon { get; set; }
                public String WormIcon { get; set; }
                public String MasterIcon { get; set; }
            }
            public class Bosses : Static
            {
                public Bosses() { SetAllEnemyPaths(); }
                private void SetAllEnemyPaths()
                {
                    Pharaoh = @"/Resources\Images\Fight\Enemies\Bosses\Static\Pharaoh.png";
                    UghZan = @"/Resources\Images\Fight\Enemies\Bosses\Static\UghZan.png";
                    Warrior = @"/Resources\Images\Fight\Enemies\Bosses\Static\Warrior.png";
                    MrOfAll = @"/Resources\Images\Fight\Enemies\Bosses\Static\MasterOfAll1.png";

                    PharaohIcon = @"/Resources\Images\Fight\Enemies\BossImgs\Pharaoh.png";
                    UghZanIcon = @"/Resources\Images\Fight\Enemies\BossImgs\UghZan1.png";
                    WarriorIcon = @"/Resources\Images\Fight\Enemies\BossImgs\Warrior1.png";
                    MrOfAllIcon = @"/Resources\Images\Fight\Enemies\BossImgs\MasterOfAll1.png";
                }
                public String Pharaoh { get; set; }
                public String UghZan { get; set; }
                public String Warrior { get; set; }
                public String MrOfAll { get; set; }
                public String PharaohIcon { get; set; }
                public String UghZanIcon { get; set; }
                public String WarriorIcon { get; set; }
                public String MrOfAllIcon { get; set; }
            }
            public class Person : Static
            {
                public Person() { SetAllPaths(); }
                private void SetAllPaths()
                {
                    Usual = @"/Resources\Images\Fight\Character\Person\Static\Usual.png";
                    Serious = @"/Resources\Images\Fight\Character\Person\Static\SeriousSam.png";
                    Defensive = @"/Resources\Images\Fight\Character\Person\Static\Defence.png";
                }
                public String Usual { get; set; }
                public String Serious { get; set; }
                public String Defensive { get; set; }
            }
            public class Icon : Static
            {
                public Icon() { SetAllPaths(); }
                private void SetAllPaths()
                {
                    Usual = @"/Resources\Images\Fight\Character\Icon\Static\Usual.png";
                    Poison = @"/Resources\Images\Fight\Character\Icon\Static\Poison.png";
                    Serious = @"/Resources\Images\Fight\Character\Icon\Static\Sam.png";
                    Defensive = @"/Resources\Images\Fight\Character\Icon\Static\Defence.png";
                    LevelUp = @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon9.png";
                }
                public String Usual { get; set; }
                public String Poison { get; set; }
                public String Serious { get; set; }
                public String Defensive { get; set; }
                public String LevelUp { get; set; }
            }
        }
        public class Dynamic : Paths
        {
            public class Foes : Dynamic
            {
                public Foes() { SetAllPaths(); }
                private void SetAllPaths()
                {
                    Spider = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\SpiderAttacks\SpiderAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\SpiderAttacks\SpiderAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\SpiderAttacks\SpiderAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\SpiderAttacks\SpiderAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\SpiderAttacks\SpiderAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\SpiderAttacks\SpiderAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\SpiderAttacks\SpiderAttacks1.png" };
                    Mummy = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MummyAttacks\MummyAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MummyAttacks\MummyAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MummyAttacks\MummyAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MummyAttacks\MummyAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MummyAttacks\MummyAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MummyAttacks\MummyAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MummyAttacks\MummyAttacks1.png" };
                    Zombie = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ZombieAttacks\ZombieAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ZombieAttacks\ZombieAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ZombieAttacks\ZombieAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ZombieAttacks\ZombieAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ZombieAttacks\ZombieAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ZombieAttacks\ZombieAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ZombieAttacks\ZombieAttacks1.png" };
                    Bones = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\BonesAttacks\BonesAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\BonesAttacks\BonesAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\BonesAttacks\BonesAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\BonesAttacks\BonesAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\BonesAttacks\BonesAttacks3.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\BonesAttacks\BonesAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\BonesAttacks\BonesAttacks1.png" };
                    Vulture = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\VultureAttacks\VultureAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\VultureAttacks\VultureAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\VultureAttacks\VultureAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\VultureAttacks\VultureAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\VultureAttacks\VultureAttacks1.png" };
                    Ghoul = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GhoulAttacks\GhoulAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GhoulAttacks\GhoulAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GhoulAttacks\GhoulAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GhoulAttacks\GhoulAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GhoulAttacks\GhoulAttacks1.png" };
                    GrimReaper = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\GrimReaperAttacks\GrimReaperAttacks1.png" };
                    Scarab = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ScarabAttacks\ScarabAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ScarabAttacks\ScarabAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ScarabAttacks\ScarabAttacks1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ScarabAttacks\ScarabAttacks2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ScarabAttacks\ScarabAttacks1.png" };
                    KillerMole = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\KillerMoleAttacks\KillerMole1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\KillerMoleAttacks\KillerMole2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\KillerMoleAttacks\KillerMole1.png" };
                    Imp = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ImpAttacks\Imp1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ImpAttacks\Imp2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\ImpAttacks\Imp1.png" };
                    Worm = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\WormAttacks\Worm1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\WormAttacks\Worm2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\WormAttacks\Worm1.png" };
                    Master = new string[] { @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MasterAttacks\Master1.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MasterAttacks\Master2.png", @"/Resources\Images\Fight\Enemies\Enemies\Dynamic\MasterAttacks\Master1.png" };
                }
                public String[] Spider { get; set; }
                public String[] Mummy { get; set; }
                public String[] Zombie { get; set; }
                public String[] Bones { get; set; }
                public String[] Vulture { get; set; }
                public String[] Ghoul { get; set; }
                public String[] GrimReaper { get; set; }
                public String[] Scarab { get; set; }
                public String[] KillerMole { get; set; }
                public String[] Imp { get; set; }
                public String[] Worm { get; set; }
                public String[] Master { get; set; }

            }
            public class Bosses : Dynamic
            {
                public Bosses() { SetAllBossesPaths(); }

                private void SetAllBossesPaths()
                {
                    Pharaoh = new string[] { @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\PharaohAttacks\PharaohAttacks.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\PharaohAttacks\PharaohAttacks2.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\PharaohAttacks\PharaohAttacks3.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\PharaohAttacks\PharaohAttacks3.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\PharaohAttacks\PharaohAttacks3.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\PharaohAttacks\PharaohAttacks2.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\PharaohAttacks\PharaohAttacks.png" };
                    UghZan = new string[] { @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks1.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks2.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks3.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks4.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks5.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks6.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks7.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks8.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks9.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\UghZan1Attacks\UghZan1Attacks10.png" };
                    Warrior = new string[] { @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\WarriorAttacks\WarriorAttacks1.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\WarriorAttacks\WarriorAttacks2.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\WarriorAttacks\WarriorAttacks3.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\WarriorAttacks\WarriorAttacks2.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\WarriorAttacks\WarriorAttacks1.png" };
                    MrOfAll = new string[] { @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\MofallAttacks\MasterOfAll1.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\MofallAttacks\MasterOfAll2.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\MofallAttacks\MasterOfAll3.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\MofallAttacks\MasterOfAll4.png", @"/Resources\Images\Fight\Enemies\Bosses\Dynamic\MofallAttacks\MasterOfAll5.png" };
                }
                public String[] Pharaoh { get; set; }
                public String[] UghZan { get; set; }
                public String[] Warrior { get; set; }
                public String[] MrOfAll { get; set; }
            }
            public class Person : Dynamic
            {
                public Person()
                {
                    SetAllPersonPaths();
                }

                public void SetAllPersonPaths()
                {
                    Cure = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure\Cure10.png"};
                    Cure2 = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_10.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_11.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_12.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_13.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Cure2\Cure2_14.png"};
                    Heal = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Heal\Heal10.png"};
                    BuffUp = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\BuffUp\BuffUp10.png"};
                    ToughenUp = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\ToughenUp\ToughenUp10.png"};
                    Regen = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Regen\Regen10.png"};
                    Control = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Control\Control10.png"};
                    Torch = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Torch\Torch10.png"};
                    Whip = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Whip\Whip10.png"};
                    Thrower = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Thrower\Thrower1.png"};
                    Super = new string[] {@"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super5.png"};
                    Tornado = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Super\Super5.png" };
                    Quake = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Quake\Quake8.png" };
                    Learn = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Skills\Learn\Learn10.png" };
                    
                    BagUse = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Items\ItemUsed1.png" };
                    Escape = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Escape\Escape2.png" };
                    HdAttack = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\HandAttack\HandAttack10.png" };
                    KnAttack = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\KnifeAttack\KnifeAttck10.png" };
                    SwAttack = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SwordAttack\Sword10.png" };
                    MgAttack = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack10.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack11.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack12.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack13.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\MinigunAttack\MinigunAttack14.png" };
                    SeriousMg = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun9.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun10.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun11.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun12.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun13.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun14.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Fight\SeriousSamMinigun\SeriousSamMinigun15.png" };
                    SSwitch = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch5.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch6.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch7.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch8.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\SeriousSwitch\SeriousSwitch9.png" };
                    Hurt = new string[] { @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\PersonHurts\PersonHurts1.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\PersonHurts\PersonHurts2.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\PersonHurts\PersonHurts3.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\PersonHurts\PersonHurts4.png", @"/Resources\Images\Fight\Character\Person\Dynamic\Misc\PersonHurts\PersonHurts5.png" };
                }
                public string[] Cure { get; set; }
                public string[] Cure2 { get; set; }
                public string[] Heal { get; set; }
                public string[] BuffUp { get; set; }
                public string[] ToughenUp { get; set; }
                public string[] Regen { get; set; }
                public string[] Control { get; set; }
                public string[] Torch { get; set; }
                public string[] Whip { get; set; }
                public string[] Thrower { get; set; }
                public string[] Super { get; set; }
                public string[] Tornado { get; set; }
                public string[] Quake { get; set; }
                public string[] Learn { get; set; }
                public string[] BagUse { get; set; }
                public string[] Escape { get; set; }
                public string[] HdAttack { get; set; }
                public string[] KnAttack { get; set; }
                public string[] SwAttack { get; set; }
                public string[] MgAttack { get; set; }
                public string[] SeriousMg { get; set; }
                public string[] SSwitch { get; set; }
                public string[] Hurt { get; set; }
                public string[][] GetByIndexes { get; set; }
                
            }

            public class Icon : Dynamic
            {
                public Icon() { SetAllIconPaths(); }

                public void SetAllIconPaths()
                {
                    Cure = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconCure\IconCure10.png" };
                    Cure2 = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\CureIcon2\IconCure2_9.png" };
                    Heal = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\HealIcon\HealIcon10.png" };
                    BuffUp = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\BuffUpIcon\BuffUpIcon10.png" };
                    ToughenUp = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ToughenUpIcon\ToughenUpIcon10.png" };
                    Regen = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\RegenIcon\RegenIcon10.png" };
                    Control = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ControlIcon\ControlIcon10.png" };
                    Torch = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\IconTorch\IconTorch10.png" };
                    Whip = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\WhipIcon\WhipIcon10.png" };
                    Thrower = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\ThrowerIcon\ThrowerIcon10.png" };
                    Super = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\SuperIcon\SuperIcon4.png" };
                    Tornado = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\TornadoIcon\TornadoIcon10.png" };
                    Quake = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\QuakeIcon\QuakeIcon9.png" };
                    Learn = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Skills\LearnIcon\LearnIcon10.png" };
                    
                    BagUse = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Items\IconItemUsed10.png" };
                    Escape = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Escape\Flee2.png" };
                    HdAttack = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Punch\IconRage10.png" };
                    KnAttack = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Knife\IconKnAtk10.png" };
                    SwAttack = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sword\Sword8.png" };
                    MgAttack = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Minigun\MinigunIcon1.png" };
                    SeriousMg = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Fight\Sam\IconSeriousSamMinigun1.png" };
                    
                    SSwitch = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\IconShocked\IconShocked10.png" };
                    LevelUp = new string[] { @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon1.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon2.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon3.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon4.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon5.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon6.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon7.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon8.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon9.png", @"/Resources\Images\Fight\Character\Icon\Dynamic\Misc\LevelUp\LevelUpIcon9.png" };
                }
                public string[] Cure { get; set; }
                public string[] Cure2 { get; set; }
                public string[] Heal { get; set; }
                public string[] BuffUp { get; set; }
                public string[] ToughenUp { get; set; }
                public string[] Regen { get; set; }
                public string[] Control { get; set; }
                public string[] Torch { get; set; }
                public string[] Whip { get; set; }
                public string[] Thrower { get; set; }
                public string[] Super { get; set; }
                public string[] Tornado { get; set; }
                public string[] Quake { get; set; }
                public string[] Learn { get; set; }
                public string[] BagUse { get; set; }
                public string[] Escape { get; set; }
                public string[] HdAttack { get; set; }
                public string[] KnAttack { get; set; }
                public string[] SwAttack { get; set; }
                public string[] MgAttack { get; set; }
                public string[] SeriousMg { get; set; }
                public string[] SSwitch { get; set; }
                public string[] LevelUp { get; set; }
                public string[][] GetByIndexes { get; set; }
            }
            public class Misc : Dynamic
            {
                public Misc() { SetAllMiscPaths(); }
                public void SetAllMiscPaths() { Target = new string[] { @"/Resources\Images\Fight\Target\Target1.png", @"/Resources\Images\Fight\Target\Target2.png", @"/Resources\Images\Fight\Target\Target3.png", @"/Resources\Images\Fight\Target\Target2.png", @"/Resources\Images\Fight\Target\Target1.png", @"/Resources\Images\Fight\Target\Target2.png", @"/Resources\Images\Fight\Target\Target3.png", @"/Resources\Images\Fight\Target\Target2.png" }; }
                public string[] Target { get; set; }
            }
            public class Models : Dynamic
            {
                public Models() { SetAllPaths(); }
                public void SetAllPaths()
                {
                    Ancient = new string[] { @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act1.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act2.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act3.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act4.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act5.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act6.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act5.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Ancient\Act6.png" };
                    Warrior = new string[] { @"/Resources\Images\Locations\Loc2\Models\Dynamic\Warrior\Act1.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Warrior\Act2.png", @"/Resources\Images\Locations\Loc2\Models\Dynamic\Warrior\Act3.png", };
                }
                public string[] Ancient { get; set; }
                public string[] Warrior { get; set; }
            }
        }
        public Static.Person PersonStatePath { get; set; }
        public Static.Icon IconStatePath { get; set; }
        public Static.Foes FoesStatePath { get; set; }
        public Static.Bosses BossesStatePath { get; set; }
        public Static.Map Backgrounds { get; set; }
        public Static.Map.Models MapModels { get; set; }
        public Static.Map.Models.Guy Ray { get; set; }
        public Static.Map.Messages Msg { get; set; }
        public Static.BtnImgs.Usual BtnCustomize { get; set; }
        public Static.BtnImgs.Before BtnBefore { get; set; }
        public Static.BtnImgs.After BtnAfter { get; set; }
        public Static.Menu.MTasks MenuImgs { get; set; }
        public Static.Menu.Adventures Adv { get; set; }
        public Static.Menu.MInfo.MBefore BefMInfoImgs { get; set; }
        public Static.Menu.MInfo.MAfter AftMInfoImgs { get; set; }
        public Static.Battle Fighting { get; set; }
        public Dynamic.Foes FoesAnimatePath { get; set; }
        public Dynamic.Bosses BossesAnimatePath { get; set; }
        public Dynamic.Person PersonAnimatePath { get; set; }
        public Dynamic.Icon IconAnimatePath { get; set; }
        public Dynamic.Misc MiscAnimatePath { get; set; }
        public Dynamic.Models AniModel { get; set; }
        public OST.Music GameMusic { get; set; }
        public OST.Sounds GameSounds { get; set; }
        public OST.Noises GameNoises { get; set; }
        public CutScenes CutScene { get; set; }
    }
    public class Sql {
        public Sql()
        {
            Con = NewConnection();
            PlayerLogins = new List<string>();
        }
        public SqlConnection NewConnection() {
            //[EN] Server connection
            //[RU] Подключение через сервер (ПК создателя)
            //return new SqlConnection("Data Source=SASHA;Initial Catalog=DesertRageGame;Integrated Security=True"); //SASHA

            //[EN] Local connection
            //[RU] Подключение локально
            //return new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "+ Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Resources\Database\DesertRageGame.mdf; Integrated Security = True");

            //[EN] Publishing local connection
            //[RU] Публикация с локальным подключением
            //return new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "+ Environment.CurrentDirectory + @"\Resources\Database\DesertRageGame.mdf; Integrated Security = True");

            //[EN] Publishing experimental
            //[RU] Публикация-эксперимент
            return new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Database\DesertRageGame.mdf; Integrated Security = True");
        }
        private void NewStoredProcedureBuild(in String ProcedureName) { Cmd = new SqlCommand(ProcedureName, Con) { CommandType = CommandType.StoredProcedure }; }
        private void NewExecuteNonQueryBuild()
        {
            Cmd.Connection.Open();
            Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }
        private List<string> NewSqlDataReaderBuild(List<string> Lgs)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows) while (DataReader.Read()) Lgs.Add(DataReader.GetValue(0).ToString());
            Cmd.Connection.Close();
            return Lgs;
        }
        private string NewSqlDataReaderBuild(string Selected, in Byte Column)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows) while (DataReader.Read()) Selected = DataReader.GetValue(Column).ToString();
            Cmd.Connection.Close();
            return Selected;
        }
        private string NewSqlDataReaderBuild(in Byte Column)
        {
            string uo = "0";
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows) while (DataReader.Read()) uo = DataReader.GetValue(Column).ToString();
            Cmd.Connection.Close();
            return uo;
        }
        private Object[] NewSqlDataReaderBuild(Object[] Values, in Byte StartValue, in Byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows) while (DataReader.Read()) for (Byte i = StartValue; i < EndValue; i++) Values[i- StartValue] = DataReader.GetValue(i);
            Cmd.Connection.Close();
            return Values;
        }
        private Byte[] NewSqlDataReaderBuild(Byte[] Values, in Byte StartValue, in Byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows) while (DataReader.Read()) for (Byte i = StartValue; i < EndValue; i++) Values[i- StartValue] = Convert.ToByte(DataReader.GetValue(i));
            Cmd.Connection.Close();
            return Values;
        }
        private void AddProcedureParameter(in String ParamName, in String NewStringParam) { Cmd.Parameters.Add(ParamName, SqlDbType.VarChar).Value = NewStringParam; }
        private void AddProcedureParameter(in String ParamName, in Boolean NewBooleanParam) { Cmd.Parameters.Add(ParamName, SqlDbType.Bit).Value = NewBooleanParam; }
        private void AddProcedureParameter(in String ParamName, in Byte NewTinyIntParam) { Cmd.Parameters.Add(ParamName, SqlDbType.TinyInt).Value = NewTinyIntParam; }
        private void AddProcedureParameter(in String ParamName, in UInt16 NewSmallIntParam) { Cmd.Parameters.Add(ParamName, SqlDbType.SmallInt).Value = NewSmallIntParam; }
        private void AddProcedureParametersX(in String[] ParamNames, in Object[] NewAnyParams)
        {
            for (Byte i = 0; i < ParamNames.Length; i++)
            {
                switch (NewAnyParams[i].GetType().ToString())
                {
                    case "System.String": AddProcedureParameter(ParamNames[i], (String)NewAnyParams[i]); continue;
                    case "System.Boolean": AddProcedureParameter(ParamNames[i], (Boolean)NewAnyParams[i]); continue;
                    case "System.UInt16": AddProcedureParameter(ParamNames[i], (UInt16)NewAnyParams[i]); continue;
                    case "System.Byte": AddProcedureParameter(ParamNames[i], (Byte)NewAnyParams[i]); continue;
                    default: continue;
                }
            }
        }
        private void CheckIfPlayersListIsNotNull() { if (PlayerLogins.Count > 0) PlayerLogins.Clear(); }
        public void DeselectAllPlayers()
        {
            NewStoredProcedureBuild("DeselectPlayers");
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void NewPlayer(in String NewPlayerLogin)
        {
            NewStoredProcedureBuild("AddNewProfile");
            AddProcedureParameter("@LOGIN", NewPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void DeletePlayer(in String ExistingPlayerLogin)
        {
            NewStoredProcedureBuild("DeleteProfile");
            AddProcedureParameter("@LOGIN", ExistingPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void CheckAllRecordedPlayers()
        {
            CheckIfPlayersListIsNotNull();
            NewStoredProcedureBuild("CheckLogin");
            PlayerLogins=NewSqlDataReaderBuild(new List<string>());
            Cmd.Parameters.Clear();
        }
        public string GetCurrentPlayer()
        {
            NewStoredProcedureBuild("CheckSelected");
            CurrentLogin = (PlayerLogins.Count > 0 ? (NewSqlDataReaderBuild("????", 0) == "????" ? PlayerLogins[0] : NewSqlDataReaderBuild("????", 0)) : "????");
            Cmd.Parameters.Clear();
            return CurrentLogin;
        }
        public Object[] CheckPlayerBag(in String PlayerLogin, in Object[] Items)
        {
            NewStoredProcedureBuild("CheckBAG");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Items, 2, 11);
        }
        public Byte[] CheckPlayerEquip(in String PlayerLogin, in Byte[] Equip)
        {
            NewStoredProcedureBuild("CheckEquip");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Equip, 2, 10);
        }
        public Object[] GetPlayerRecord(in String PlayerLogin, in Object[] RecordValues)
        {
            NewStoredProcedureBuild("CheckPlayer");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(RecordValues, 1, 8);
        }
        public Object[] GetPlayerStats(in String PlayerLogin, in Object[] Params)
        {
            NewStoredProcedureBuild("CheckParams");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Params, 1, 7);
        }
        public Byte[] GetPlayerSettings(in String PlayerLogin, in Byte[] Settings)
        {
            NewStoredProcedureBuild("CheckSettings");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Settings, 2, 8);
        }
        public void SavePlayerBag(in String[] Parameters, in Object[] Items)
        {
            NewStoredProcedureBuild("GetNewItemsBag");
            AddProcedureParametersX(Parameters, Items);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerEquip(in String[] Parameters, in Object[] Equipment)
        {
            NewStoredProcedureBuild("GetNewEquip");
            AddProcedureParametersX(Parameters, Equipment);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerStats(in String[] Parameters, in Object[] Stats)
        {
            NewStoredProcedureBuild("GetNewParams");
            AddProcedureParametersX(Parameters, Stats);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerSettings(in String[] Parameters, in Object[] Settings)
        {
            NewStoredProcedureBuild("GetNewSettings");
            AddProcedureParametersX(Parameters, Settings);
            NewExecuteNonQueryBuild();
        }
        public void NewGameStart(in String PlayerLogin)
        {
            NewStoredProcedureBuild("NewGameStart");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            NewExecuteNonQueryBuild();
        }
        public Boolean CheckIfPlayerCanContinue()
        {
            NewStoredProcedureBuild("CheckPlayer");
            AddProcedureParameter("@LOGIN", CurrentLogin);
            return Convert.ToByte(NewSqlDataReaderBuild("1", 2)) > 0;
        }
        public string CheckTask()
        {
            NewStoredProcedureBuild("CheckTask");
            AddProcedureParameter("@LOGIN", CurrentLogin);
            return NewSqlDataReaderBuild(0);
        }
        public SqlCommand Cmd { get; set; }
        public SqlDataReader DataReader { get; set; }
        public SqlConnection Con { get; set; }
        public List<string> PlayerLogins { get; set; }
        public string CurrentLogin { get; set; }
    }

    //[EN] Foe class, influence on new enemies.
    //[RU] Класс противник, определяет новых противников возникающих в бою.
    public class Foe
    {
        public Foe() { GetStats(); }

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
            public void PreStats(in Byte FoeIndex)
            {
                UInt16[] MaxHp = {    65,   83,  101,  125,  250,  306,  272,  100,  400,  600,  950,  760,  500, 2000,10000,  350 };
                Byte[] Power   = {  25, 32, 41, 50, 45, 80,100, 75,150,125,160,180, 75,170,255, 50 };
                Byte[] Vital   = {   3,  7,  5, 15, 25, 40, 20, 80,100,120, 70,150, 40,120,255, 50 };
                Byte[] Speed   = {  10, 17, 25, 35, 65, 30, 45, 80,100, 90,130,150, 40, 90,255, 50 };
                Byte[] Abils   = {   0,  2,  5,  7, 30, 20, 60, 80, 75,110, 70,150, 35,140,255, 50 };
                Byte[] Exper   = {   5,  7, 11, 15, 35, 75,100, 60,175,140,200,225,100,200,255,150 };
                Byte[] Mater   = {   5, 10, 35, 75, 60,110, 80,255,105,180,150,255,100,200,255,150 };
                Byte[] Drops =   { 0,1,2,3, 6,4,5,7, 6,5,5,7, 3, 7, 7, 5 };
                EnemyAttack = Power[FoeIndex];
                EnemyDefence = Vital[FoeIndex];
                EnemySpeed = Speed[FoeIndex];
                EnemyAgility = Abils[FoeIndex];
                EnemyMHP = MaxHp[FoeIndex];
                Materials = Mater[FoeIndex];
                Experience = Exper[FoeIndex];
                DropRate = Drops[FoeIndex];
            }
            public UInt16 EnemyMHP { get; set; }
            public Byte EnemyAttack { get; set; }
            public Byte EnemyDefence { get; set; }
            public Byte EnemySpeed { get; set; }
            public Byte EnemyAgility { get; set; }
            public Byte Experience { get; set; }
            public Byte Materials { get; set; }
            public Byte DropRate { get; set; }
        }
        /// <summary>
        /// Крайне важная информация для разработчика на будущее:
        /// Т.к. выходит слишком много "Ничьих" среди врагов и они не могут
        /// нанести урон персонажу + игрок не может противостоять физическими атаками врагов 3 локации
        /// Создаем формулу бонуса к атаке: АТК (с учётом экипировки)+АТК(без)* (СКР/100)
        /// Бонус к защите: ЗЩТ+СПЦ*(СКР/200)
        /// </summary>
        public void GetStats() {
            EnemyName = new string[][] { new string[] { "Паук", "Мумия", "Зомби", "Страж", "Фараон", "Угх-зан I" }, new string[] { "Стервятник", "Гуль", "Жнец", "Скарабей", "????" }, new string[] { "Моль-убийца", "Прислужник", "П. червь", "Мастер", "Владыка" } };
            EnemyAppears = new string[] { "", "", "" };
            EnemyTurn = new UInt16[] { 60, 30, 0 };
            EnemyHP = new UInt16[] { 0, 0, 0 };
            EnemiesStillAlive = 0;
        }
        public void SetEnemies()
        {
            Spider = new Stats();
            Mummy = new Stats();
            Zombie = new Stats();
            Bones = new Stats();
            Vulture = new Stats();
            Ghoul = new Stats();
            GrimReaper = new Stats();
            Scarab = new Stats();
            KillerMole = new Stats();
            Imp = new Stats();
            Worm = new Stats();
            Master = new Stats();
            BOSS1 = new Stats();
            BOSS2 = new Stats();
            BOSS3 = new Stats();
            SecretBOSS1 = new Stats();
        }
        public UInt16[] EnemyHP { get; set; }
        public string[][] EnemyName { get; set; }
        public string[] EnemyAppears { get; set; }
        public UInt16[] EnemyTurn { get; set; }
        public Byte EnemiesStillAlive { get; set; }
        public Stats Spider { get; set; }
        public Stats Mummy { get; set; }
        public Stats Zombie { get; set; }
        public Stats Bones { get; set; }
        public Stats Vulture { get; set; }
        public Stats Ghoul { get; set; }
        public Stats GrimReaper { get; set; }
        public Stats  Scarab { get; set; }
        public Stats KillerMole { get; set; }
        public Stats Imp { get; set; }
        public Stats Worm { get; set; }
        public Stats Master { get; set; }
        public Stats BOSS1 { get; set; }
        public Stats BOSS2 { get; set; }
        public Stats BOSS3 { get; set; }
        public Stats SecretBOSS1 { get; set; }
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
            NextLevel = new UInt16[] { 15, 24, 38, 61, 98, 112, 150, 177, 200, 250, 420, 770, 1170, 1595, 2045, 2520, 3020, 3620, 4320, 5080, 6020, 7500, 8750, 10000, 0 };

            //[EN] Active stats (HP,AP)
            //[RU] Активные параметры (ОЗ, ОД).
            MaxHP = 100;
            MaxAP = 40;
            CurrentHP = MaxHP;
            CurrentAP = MaxAP;

            //[EN] Passive stats (ATK, DEF, AG, SP)
            //[RU] Пассивные параметры (АТК, ЗЩТ, СКР, СПЦ).
            Attack = 25;
            Defence = 15;
            Speed = 15;
            Special = 25;
            Learned = 0;

            //[EN] PLAYER LEVEL UP STATS
            //[RU] СТАТУС ИГРОКА ПРИ ПОВЫШЕНИИ УРОВНЯ
            MaxHPNxt = new UInt16[] { 100, 110, 121, 132, 145, 159, 174, 192, 221, 250, 282, 312, 350, 391, 436, 485, 532, 582, 633, 686, 741, 800, 862, 930, 999 };
            MaxAPNxt = new UInt16[] { 40, 44, 48, 53, 58, 64, 70, 77, 85, 100, 121, 147, 200, 267, 342, 395, 478, 540, 570, 600, 785, 840, 890, 940, 999 };
            AttackNxt = new Byte[] { 25, 28, 31, 34, 40, 45, 52, 63, 70, 85, 102, 109, 116, 124, 132, 141, 150, 160, 171, 182, 194, 206, 219, 230, 255 };
            DefenseNxt = new Byte[] { 15, 17, 19, 21, 25, 30, 33, 37, 45, 50, 66, 81, 88, 96, 110, 119, 136, 146, 157, 175, 187, 199, 211, 225, 255 };
            SpeedNxt = new Byte[] { 15, 17, 19, 21, 23, 25, 28, 31, 35, 39, 40, 42, 45, 48, 53, 61, 74, 95, 116, 137, 158, 179, 200, 221, 255 };
            SpecialNxt = new Byte[] { 25, 30, 35, 40, 45, 50, 60, 65, 75, 100, 105, 110, 120, 125, 130, 140, 145, 160, 175, 185, 200, 210, 225, 240, 255 };

            //[EN] PLAYER CURRENT EQUIP
            //[RU] ТЕКУЩАЯ ЭКИПИРОВКА
            PlayerEQ = new Byte[] { 0, 0, 0, 0 };

            //[EN] PLAYER STATUS IN AND OUT OF BATTLE
            //[RU] СТАТУС ИГРОКА В И ВНЕ БОЯ
            DefenseState = 1;
            PlayerStatus = 0;
            MenuTask = 0;
            MiniTask = false;
            Experience = 0;
        }
        public void SetStats(in Byte Level)
        {
            CurrentLevel = Convert.ToByte(Level + 1);
            MaxHP = MaxHPNxt[Level];
            MaxAP = MaxAPNxt[Level];
            Attack = AttackNxt[Level];
            Defence = DefenseNxt[Level];
            Speed = SpeedNxt[Level];
            Special = SpecialNxt[Level];
        }
        public void SetStats(in Byte Level, in UInt16 MaxHp, in UInt16 MaxAp, in Byte Power, in Byte Defense, in Byte Agility, in Byte Ability)
        {
            CurrentLevel = Level;
            MaxHP = MaxHp;
            MaxAP = MaxAp;
            Attack = Power;
            Defence = Defense;
            Speed = Agility;
            Special = Ability;
        }
        public void SetCurrentHpAp(in UInt16 Hp, in UInt16 Ap)
        {
            CurrentHP = Hp;
            CurrentAP = Ap;
        }
        public Object[] GetPlayerRecord(in string login) { return new Object[] { login, CurrentLevel, MenuTask, CurrentHP, CurrentAP, Experience, MiniTask, Learned, true }; }
        public void SetPlayerRecord(params Object[] Values) { SetAnyValues(new Object[] { CurrentLevel, MenuTask, CurrentHP, CurrentAP, Experience, MiniTask, Learned }, Values); }
        public void SetAnyValues(Object[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++)
            {
                switch (Properties[i].GetType().ToString())
                {
                    case "System.Byte": Properties[i] = Convert.ToByte(Values[i]); break;
                    case "System.UInt16": Properties[i] = Convert.ToUInt16(Values[i]); break;
                    case "System.Boolean": Properties[i] = Convert.ToBoolean(Values[i]); break;
                    case "System.String": Properties[i] = Convert.ToString(Values[i]); break;
                    default: break;
                }
            }
        }
        public void SetAnyValues(Object[] Properties, in Object Value)
        {
            for (Byte i = 0; i < Properties.Length; i++)
            {
                switch (Properties[i].GetType().ToString())
                {
                    case "System.Byte": Properties[i] = Convert.ToByte(Value); break;
                    case "System.UInt16": Properties[i] = Convert.ToUInt16(Value); break;
                    case "System.Boolean": Properties[i] = Convert.ToBoolean(Value); break;
                    case "System.String": Properties[i] = Convert.ToString(Value); break;
                    default: break;
                }
            }
        }
        public void SetAllEquip(in Byte Weapon, in Byte Armor, in Byte Legs, in Byte Boots)
        {
            PlayerEQ[0] = Weapon;
            PlayerEQ[1] = Armor;
            PlayerEQ[2] = Legs;
            PlayerEQ[3] = Boots;
        }
        public UInt16 MaxHP { get; set; }
        public UInt16 MaxAP { get; set; }
        public UInt16 CurrentHP { get; set; }
        public UInt16 CurrentAP { get; set; }
        public Byte Attack { get; set; }
        public Byte Defence { get; set; }
        public Byte Speed { get; set; }
        public Byte Special { get; set; }
        public UInt16 Learned { get; set; }
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
        public Byte MenuTask { get; set; }
        public Boolean MiniTask { get; set; }
        public UInt16 Experience { get; set; }
    }

    //[EN] Bag class, depends on items getting and used in/out battle
    //[RU] Класс мешка с вещами, зависит от вещей, получаемых и используемых в/вне боя
    public class Bag : Characteristics
    {
        public Bag() { Equip(); Items(); }

        //[EN] Initialize empty slots of equipment
        //[RU] Метод для обозначения слотов экипировки
        public void Equip()
        {
            Hands = false;
            Jacket = false;
            Legs = false;
            Boots = false;
            Weapon = new Boolean[] { false, false, false, false };
            Armor = new Boolean[] { false, false, false, false };
            Pants = new Boolean[] { false, false, false, false };
            ArmBoots = new Boolean[] { false, false, false, false };
        }
        public void EquipPropertyChange(in Byte propertyNo, in Boolean onChange)
        {
            switch (propertyNo)
            {
                case 0: Hands = onChange; break;
                case 1: Jacket = onChange; break;
                case 2: Legs = onChange; break;
                case 3: Boots = onChange; break;
                default: break;
            }
        }

        //[EN] Initialize items count method
        //[RU] Метод для обозначения хранения каждого вида предметов
        public void Items()
        {
            BandageITM = 0;
            AntidoteITM = 0;
            EtherITM = 0;
            FusedITM = 0;
            HerbsITM = 0;
            SleepBagITM = 0;
            Ether2ITM = 0;
            ElixirITM = 0;
            Materials = 0;
        }
        public void ItemsSet(in Byte Bandages, in Byte Antidote, in Byte Ether, in Byte Fused, in Byte Herbs, in Byte SleepBags, in Byte Ethers2, in Byte Elixir, in UInt16 Materia) {
            BandageITM = Bandages;
            AntidoteITM = Antidote;
            EtherITM = Ether;
            FusedITM = Fused;
            HerbsITM = Herbs;
            SleepBagITM = SleepBags;
            Ether2ITM = Ethers2;
            ElixirITM = Elixir;
            Materials = Materia;
        }
        public void ItemsSet(in Byte Bandages, in Byte Antidote, in Byte Ether, in Byte Fused, in Byte Herbs, in Byte SleepBags, in Byte Ethers2, in Byte Elixir)
        {
            BandageITM = Bandages;
            AntidoteITM = Antidote;
            EtherITM = Ether;
            FusedITM = Fused;
            HerbsITM = Herbs;
            SleepBagITM = SleepBags;
            Ether2ITM = Ethers2;
            ElixirITM = Elixir;
        }
        public void EquipWearSet(in Boolean hands, in Boolean jacket, in Boolean legs, in Boolean boots)
        {
            Hands = hands;
            Jacket = jacket;
            Legs = legs;
            Boots = boots;
        }
        public void EquipKindsSet(in Boolean[] weapon, in Boolean[] armor, in Boolean[] pants, in Boolean[] armboots)
        {
            Weapon = weapon;
            Armor = armor;
            Pants = pants;
            ArmBoots = armboots;
        }
        public void EquipAllSet(in Boolean hands, in Boolean jacket, in Boolean legs, in Boolean boots, in Boolean[] weapon, in Boolean[] armor, in Boolean[] pants, in Boolean[] armboots)
        {
            EquipWearSet(hands, jacket, legs, boots);
            EquipKindsSet(weapon, armor, pants, armboots);
        }
        public Byte BandageITM { get; set; }
        public Byte AntidoteITM { get; set; }
        public Byte EtherITM { get; set; }
        public Byte FusedITM { get; set; }
        public Byte HerbsITM { get; set; }
        public Byte Ether2ITM { get; set; }
        public Byte SleepBagITM { get; set; }
        public Byte ElixirITM { get; set; }
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

    //[EN] Misc class, contents engine values
    //[RU] Класс прочее, содержит параметры двигателя игры
    public class Misc
    {
        public Misc() { InitOnNewGame(); }

        //[EN] Adaptation subclass
        //[RU] Подкласс адаптации
        public class Adopt : Misc
        {
            public Adopt() { AdoptInit(); }
            private void AdoptInit()
            {
                WidthAdBack = 1;
                HeightAdBack = 1;
                ImgXbounds = 18;
                ImgYbounds = 34;
            }
            public void SetBounds(in Boolean LeftRightOrUpDown, in Byte RowOrColumn) { if (LeftRightOrUpDown) ImgYbounds = RowOrColumn; else ImgXbounds = RowOrColumn; }
            public double WidthAdBack { get; set; }
            public double HeightAdBack { get; set; }
            public int ImgXbounds { get; set; }
            public int ImgYbounds { get; set; }
        }
        private void InitOnNewGame()
        {
            EquipmentClass = 0;
            TableEN = true;
            LockIndex = 3;
            StepsToBattle = 20;
            SeriousBonus = 0;
            SelectedTarget = 0;
            FoeType1Alive = 0;
            FoeType2Alive = 0;
            FoeType3Alive = 0;
            FoeType4Alive = 0;
            EnemyRate = 2;
            Rnd1 = 0;
            Rnd2 = 0;
            SpecialBattle = 0;
            ItemsDropRate = new Byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        public void EnemiesGetDown(in Byte propertyNo)
        {
            switch (propertyNo)
            {
                case 0: FoeType1Alive--; break;
                case 1: FoeType2Alive--; break;
                case 2: FoeType3Alive--; break;
                case 3: FoeType4Alive--; break;
                default: break;
            }
        }
        public void EnemiesGetLost(in Byte propertyNo)
        {
            switch (propertyNo)
            {
                case 0: FoeType1Alive = 0; break;
                case 1: FoeType2Alive = 0; break;
                case 2: FoeType3Alive = 0; break;
                case 3: FoeType4Alive = 0; break;
                default: break;
            }
        }
        public Byte SelectedTarget { get; set; }
        public Byte StepsToBattle { get; set; }
        public Byte EnemyRate { get; set; }
        public Int32 Rnd1 { get; set; }
        public Int32 Rnd2 { get; set; }
        public Byte EquipmentClass { get; set; }
        public Byte FoeType1Alive { get; set; }
        public Byte FoeType2Alive { get; set; }
        public Byte FoeType3Alive { get; set; }
        public Byte FoeType4Alive { get; set; }
        public bool TableEN { get; set; }
        public Byte LockIndex { get; set; }
        public Byte SpecialBattle { get; set; }
        public Byte SeriousBonus { get; set; }
        public Byte[] ItemsDropRate { get; set; }
    }

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
            InitializeComponent();
            Functionality();
        }
        private void Functionality()
        {
            DataContext = this;
            Txt = new Txts();
            Txt.SetTxt();
            Path.SetPaths();
            Foe1.SetEnemies();
            SetEnemies();
            SetAllTimeTriggers();
            ShowFoesStats();
            TimerOn(ref WRecd);
            HeyPlaySomething(Path.GameMusic.MainTheme);
            
            CheckScreenProperties();

            try { Autorization(); SeeMap(); } catch (Exception ex) {
                Reload rel = new Reload("Столкнулись с проблемой подключения. Свяжитесь с администратором для решения проблемы.", "You encountered a problem of connection to database. Contact with administrator to solve this.", ex.Message);
                rel.ShowDialog();
                Close();
            }
            Anonymous();
        }

        //[EN] Connection to database and show progress feature
        //[RU] Подключение к базе данных и особенность показа прогресса.
        Sql DataBaseMSsql = new Sql();
        public void Autorization() { DataBaseMSsql.CheckAllRecordedPlayers(); CurrentPlayer.Content = DataBaseMSsql.GetCurrentPlayer(); Continue.IsEnabled = DataBaseMSsql.CheckIfPlayerCanContinue(); ConAdv.Source = Bmper(Continue.IsEnabled ? Path.Adv.BeforeConAdv : Path.Adv.AdventureLock); }
        private void SeeMap() { Byte locs = Bits(DataBaseMSsql.CheckTask()); ChangeBackground(LocationDecode(locs), locs); }
        private bool TimeChamber()
        {
            if ((FleeTime[0] > 0) || (FleeTime[1] > 0))
            {
                if (FleeTime[1] > 0) { FleeTime[1]--; } else { FleeTime[0]--; FleeTime[1] = 59; }
                TimerFlees.Foreground = TimerFlees1.Foreground = new SolidColorBrush(Color.FromRgb(255, Bits(((FleeTime[0] <= 0) && (FleeTime[1] % 2 == 1)) ? 0 : 255), Bits(((FleeTime[0] <= 0) && (FleeTime[1] % 2 == 1)) ? 0 : 255)));
                TimerFlees.Content = FleeTime[0] + ((FleeTime[1] >= 10) ? ":" : ":0") + FleeTime[1];
                TimerFlees.BorderBrush = TimerFlees1.BorderBrush = new SolidColorBrush(Color.FromRgb(Bits(255 - (FleeTime[0] * 60 + FleeTime[1]) * 1.7), Bits(75 + (FleeTime[0] * 60 + FleeTime[1])), Bits(105 + (FleeTime[0] * 60 + FleeTime[1]))));
            }
            else
            {
                AnyHideX(TimerFlees, TimerFlees1);
                TimerFlees.Foreground = TimerFlees1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                TimerFlees.BorderBrush = TimerFlees1.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 220, 255));
                FleeTime = new Byte[] { 2, 30 };
                TimerFlees.Content = FleeTime[0] + ":" + FleeTime[1];
                WonOrDied(); MediaShow(GameOver);
                return true;
            }
            return false;
        }
        private bool WorldRecord()
        {
            TimeWorldRecord[3]++;
            for (SByte i = 3; i > 0; i--) { Byte[] Conds = { 23, 60, 60, 100 }; if (TimeWorldRecord[i] >= Conds[i]) { TimeWorldRecord[i - 1]++; TimeWorldRecord[i] = 0; } }
            TimeRecordText.Foreground = TimeWorldRecord[0] > 23 ? Brushes.Red : TimeWorldRecord[0] >= 2 ? Brushes.Yellow : TimeWorldRecord[1] >= 30 ? Brushes.Green : Brushes.White;
            TimeRecordText.Content = TimeWorldRecord[0] > 23 ? Txt.Hnt.Wrn3 + " " + Txt.Com.Time + ": 23:59:59.99" : ((TimeWorldRecord[0] >= 2 ? Txt.Hnt.Wrn2 + " " : TimeWorldRecord[1] >= 30 ? Txt.Hnt.Wrn1 + " " : "") + Txt.Com.Time + ": " + TimeWorldRecord[0] + (TimeWorldRecord[1] >= 10 ? ":" : ":0") + TimeWorldRecord[1] + (TimeWorldRecord[2] >= 10 ? ":" : ":0") + TimeWorldRecord[2] + (TimeWorldRecord[3] >= 10 ? "." : ".0") + TimeWorldRecord[3]);
            return TimeWorldRecord[0] > 23;
        }
        ///[EN] Initialize all variables
        ///[RU] Инициализация всех переменных.

        //[EN] Initialize public objects
        //[RU] Инициализация объектов публичного доступа
        Txts Txt { get; set; }
        public Txts _Txt { get { return Txt; } set { Txt = value; OnPropertyChanged(); } }
        Paths Path = new Paths();
        Bag BAG = new Bag();
        Characteristics Super1 = new Characteristics { MaxHP = 100, MaxAP = 40, Attack = 25, Defence = 15, Speed = 15, Special = 25 };
        Foe Foe1 = new Foe();
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
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion

        //[EN] Initialize timers for events
        //[RU] Инициализация таймеров для событий.
        System.Windows.Threading.DispatcherTimer PHurt = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer THurt = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer E1Atk = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer E2Atk = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer E3Atk = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PHAtk = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PKAtk = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PSAtk = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PMAtk = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PFlee = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PItem = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Pure1 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Pure2 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PHeal = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PBuff = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PTogh = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PHpUp = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PApUp = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PTrch = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PWhip = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PThrw = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Puper = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Pnado = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Puake = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Pearn = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer SMini = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer SSwth = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Targt = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PBndg = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PEthr = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PHerb = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PEtr2 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PAtdt = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PCur2 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PFusd = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PElxr = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PRegn = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PCtrl = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PThwr = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PWhrl = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PQuak = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PTurn = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer ETurn = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer WRecd = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Boss1 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Boss2 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer Boss3 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer RRoll = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer EHurt = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PCure = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PAtxc = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PToch = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PWhpd = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PSupr = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PPowr = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer AStat = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer AMats = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer NLevl = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer TRout = new System.Windows.Threading.DispatcherTimer();

        System.Windows.Threading.DispatcherTimer ILevl = new System.Windows.Threading.DispatcherTimer();

        //[EN] Initialize way to success the escape and get experience/materials.
        //[RU] Инициализация состояний получения опыта/материалов и успеха побега.
        public static Int32 speed = 0;
        public static Int32 Exp = 0;
        public static UInt16 Mat = 0;

        //[EN] Initialize random mechanic
        //[RU] Инициализация механики ведения случайных величин.
        public static Random Random1 = new Random();
        public static Int32 rnd = Random1.Next(5, 20);
        public static int poison = 0;

        //[EN] Injuries.
        //[RU] Ранения.
        public static Byte PlayerHurt = 0;
        public static Byte PlayerHurtM = 0;
        public static Byte trgt = 0;
        public static Byte SelectedTrgt = 0;
        public static Byte[] EnemyAtck = new Byte[] { 0, 0, 0 };

        //[EN] Values for stopwatch and timer
        //[RU] Значения времени для секундомера и таймера.
        public static UInt16[] TimeWorldRecord = new UInt16[] { 0, 0, 0, 0 };
        public static Byte[] FleeTime = new Byte[] { 2, 30 };

        //[EN] Initialize locations.
        //[RU] Инициализация локаций.
        public static Byte CurrentLocation = 0;
        public static Byte[,] MapScheme;
        public static Byte[] EnemyNamesFight = new Byte[] { 0, 0, 0, 0 };

        //[EN] Animation variables.
        //[RU] Переменные анимации.
        public static Byte Actions = 0;
        public static UInt16 FoeDamage = 0;
        public static Byte CureCurrent = 0;
        public static Byte RAPCurrent = 0;
        public static Byte Appearance = 0;

        //[EN] Enemy stats initializing and edit showing in bestiary
        //[RU] Инициализация параметров врагов и их отображение в бестиарии
        private void SetEnemies()
        {
            Foe1.Spider.PreStats(0);
            Foe1.Mummy.PreStats(1);
            Foe1.Zombie.PreStats(2);
            Foe1.Bones.PreStats(3);
            Foe1.Vulture.PreStats(4);
            Foe1.Ghoul.PreStats(5);
            Foe1.GrimReaper.PreStats(6);
            Foe1.Scarab.PreStats(7);
            Foe1.KillerMole.PreStats(8);
            Foe1.Imp.PreStats(9);
            Foe1.Worm.PreStats(10);
            Foe1.Master.PreStats(11);
            Foe1.BOSS1.PreStats(12);
            Foe1.BOSS2.PreStats(13);
            Foe1.BOSS3.PreStats(14);
            Foe1.SecretBOSS1.PreStats(15);
        }
        private void ShowFoesStats()
        {
            FastTextChange(new Label[] { FoeAtk1, FoeAtk2, FoeAtk3, FoeAtk4, FoeAtk5, FoeAtk6, FoeAtk7, FoeAtk8, FoeAtk9, FoeAtk10, FoeAtk11, FoeAtk12, FoeAtk13, FoeAtk14, FoeAtk15, FoeAtk16 },
                new string[] { ""+Foe1.Spider.EnemyAttack, "" + Foe1.Mummy.EnemyAttack, "" + Foe1.Zombie.EnemyAttack, "" + Foe1.Bones.EnemyAttack, "" + Foe1.Vulture.EnemyAttack, "" + Foe1.Ghoul.EnemyAttack,
                "" + Foe1.GrimReaper.EnemyAttack, "" + Foe1.Scarab.EnemyAttack, "" + Foe1.KillerMole.EnemyAttack, "" + Foe1.Imp.EnemyAttack, "" + Foe1.Worm.EnemyAttack, "" + Foe1.Master.EnemyAttack,
                "" + Foe1.BOSS1.EnemyAttack, "" + Foe1.BOSS2.EnemyAttack, "" + Foe1.BOSS3.EnemyAttack, "" + Foe1.SecretBOSS1.EnemyAttack });
            FastTextChange(new Label[] { FoeDef1, FoeDef2, FoeDef3, FoeDef4, FoeDef5, FoeDef6, FoeDef7, FoeDef8, FoeDef9, FoeDef10, FoeDef11, FoeDef12, FoeDef13, FoeDef14, FoeDef15, FoeDef16 },
                new string[] { ""+Foe1.Spider.EnemyDefence, "" + Foe1.Mummy.EnemyDefence, "" + Foe1.Zombie.EnemyDefence, "" + Foe1.Bones.EnemyDefence, "" + Foe1.Vulture.EnemyDefence, "" + Foe1.Ghoul.EnemyDefence,
                "" + Foe1.GrimReaper.EnemyDefence, "" + Foe1.Scarab.EnemyDefence, "" + Foe1.KillerMole.EnemyDefence, "" + Foe1.Imp.EnemyDefence, "" + Foe1.Worm.EnemyDefence, "" + Foe1.Master.EnemyDefence,
                "" + Foe1.BOSS1.EnemyDefence, "" + Foe1.BOSS2.EnemyDefence, "" + Foe1.BOSS3.EnemyDefence, "" + Foe1.SecretBOSS1.EnemyDefence });
            FastTextChange(new Label[] { FoeSpd1, FoeSpd2, FoeSpd3, FoeSpd4, FoeSpd5, FoeSpd6, FoeSpd7, FoeSpd8, FoeSpd9, FoeSpd10, FoeSpd11, FoeSpd12, FoeSpd13, FoeSpd14, FoeSpd15, FoeSpd16 },
                new string[] { ""+Foe1.Spider.EnemySpeed, "" + Foe1.Mummy.EnemySpeed, "" + Foe1.Zombie.EnemySpeed, "" + Foe1.Bones.EnemySpeed, "" + Foe1.Vulture.EnemySpeed, "" + Foe1.Ghoul.EnemySpeed,
                "" + Foe1.GrimReaper.EnemySpeed, "" + Foe1.Scarab.EnemySpeed, "" + Foe1.KillerMole.EnemySpeed, "" + Foe1.Imp.EnemySpeed, "" + Foe1.Worm.EnemySpeed, "" + Foe1.Master.EnemySpeed,
                "" + Foe1.BOSS1.EnemySpeed, "" + Foe1.BOSS2.EnemySpeed, "" + Foe1.BOSS3.EnemySpeed, "" + Foe1.SecretBOSS1.EnemySpeed });
            FastTextChange(new Label[] { FoeSpc1, FoeSpc2, FoeSpc3, FoeSpc4, FoeSpc5, FoeSpc6, FoeSpc7, FoeSpc8, FoeSpc9, FoeSpc10, FoeSpc11, FoeSpc12, FoeSpc13, FoeSpc14, FoeSpc15, FoeSpc16 },
                new string[] { ""+Foe1.Spider.EnemyAgility, "" + Foe1.Mummy.EnemyAgility, "" + Foe1.Zombie.EnemyAgility, "" + Foe1.Bones.EnemyAgility, "" + Foe1.Vulture.EnemyAgility, "" + Foe1.Ghoul.EnemyAgility,
                "" + Foe1.GrimReaper.EnemyAgility, "" + Foe1.Scarab.EnemyAgility, "" + Foe1.KillerMole.EnemyAgility, "" + Foe1.Imp.EnemyAgility, "" + Foe1.Worm.EnemyAgility, "" + Foe1.Master.EnemyAgility,
                "" + Foe1.BOSS1.EnemyAgility, "" + Foe1.BOSS2.EnemyAgility, "" + Foe1.BOSS3.EnemyAgility, "" + Foe1.SecretBOSS1.EnemyAgility });
        }
        private void ImgShrink(Image Img, in Double W, in Double H) { Img.Width = W; Img.Height = H; }
        private void BarShrink(ProgressBar Bar, in Double W, in Double H) { Bar.Width = W; Bar.Height = H; }
        private void MedShrink(MediaElement Med, in Double W, in Double H) { Med.Width = W; Med.Height = H; }
        private void LabShrink(Label Lab, in Double fs) { Lab.FontSize = fs; }
        private void TxtShrink(TextBlock Txt, in Double fs) { Txt.FontSize = fs; }
        private void LabGrid(Label Lab, in Byte row, in Byte col) { Grid.SetRow(Lab, row); Grid.SetColumn(Lab, col); }
        private void BtnGrid(Button Btn, in Byte row, in Byte col) { Grid.SetRow(Btn, row); Grid.SetColumn(Btn, col); }
        private void BarGrid(ProgressBar Bar, in Byte row, in Byte col) { Grid.SetRow(Bar, row); Grid.SetColumn(Bar, col); }
        private void MedGrid(MediaElement Med, in Byte row, in Byte col) { Grid.SetRow(Med, row); Grid.SetColumn(Med, col); }
        private void ImgGrid(Image Img, in Byte row, in Byte col) { Grid.SetRow(Img, row); Grid.SetColumn(Img, col); }
        private void ButtonCHFT(Button Btn, in Double fs) { Btn.FontSize = fs; }
        private void AnyHide(Object Element)
        {
            switch (Element.GetType().ToString())
            {
                case "System.Windows.Controls.Label": LabHide((Label)Element); break;
                case "System.Windows.Controls.Button": ButtonHide((Button)Element); break;
                case "System.Windows.Controls.Image": ImgHide((Image)Element); break;
                case "System.Windows.Controls.TextBlock": TxtHide((TextBlock)Element); break;
                case "System.Windows.Controls.Slider": SldHide((Slider)Element); break;
                case "System.Windows.Controls.CheckBox": ChbHide((CheckBox)Element); break;
                case "System.Windows.Controls.MediaElement": MediaHide((MediaElement)Element); break;
                case "System.Windows.Controls.ProgressBar": BarHide((ProgressBar)Element); break;
                case "System.Windows.Controls.TextBox": TBoxHide((TextBox)Element); break;
                case "System.Windows.Controls.Grid": GHide((Grid)Element); break;
            }
        }
        private void AnyShow(Object Element)
        {
            switch (Element.GetType().ToString())
            {
                case "System.Windows.Controls.Label": LabShow((Label)Element); break;
                case "System.Windows.Controls.Button": ButtonShow((Button)Element); break;
                case "System.Windows.Controls.Image": ImgShow((Image)Element); break;
                case "System.Windows.Controls.TextBlock": TxtShow((TextBlock)Element); break;
                case "System.Windows.Controls.Slider": SldShow((Slider)Element); break;
                case "System.Windows.Controls.CheckBox": ChbShow((CheckBox)Element); break;
                case "System.Windows.Controls.MediaElement": MediaShow((MediaElement)Element); break;
                case "System.Windows.Controls.ProgressBar": BarShow((ProgressBar)Element); break;
                case "System.Windows.Controls.TextBox": TBoxShow((TextBox)Element); break;
                case "System.Windows.Controls.Grid": GShow((Grid)Element); break;
            }
        }
        private void AnyGrid(Object Element, in Byte row, in Byte column)
        {
            switch (Element.GetType().ToString())
            {
                case "System.Windows.Controls.Label": LabGrid((Label)Element, row, column); break;
                case "System.Windows.Controls.Button": BtnGrid((Button)Element, row, column); break;
                case "System.Windows.Controls.Image": ImgGrid((Image)Element, row, column); break;
                case "System.Windows.Controls.MediaElement": MedGrid((MediaElement)Element, row, column); break;
                case "System.Windows.Controls.ProgressBar": BarGrid((ProgressBar)Element, row, column); break;
            }
        }
        private void Scales(ScaleTransform scl, in Double W, in Double H) { scl.ScaleX = W; scl.ScaleY = H; }
        private void AnyHideX(params Object[] Elements) { foreach (Object Element in Elements) AnyHide(Element); }
        private void AnyShowX(params Object[] Elements) { foreach (Object Element in Elements) AnyShow(Element); }
        private void AnyGridX(Object[] Elements, in Byte[] rows, in Byte[] columns) { for (Byte i = 0; i < Elements.Length; i++) AnyGrid(Elements[i], rows[i], columns[i]); }
        private void Adaptate()
        {
            //[EN] Adaptate mechanics, sreen elements formula: CurrentScreenSize/Recomended(1920X1080)
            //[RU] Механика адаптации, формула расположения элементов: ТекущееРазрешениеЭкрана/Рекомендуемое(1920Х1080)
            Button[] BtnWFM = { CraftSwitch, AddProfile, DeleteProfile, AutoTurn };
            FullMediaShrink(Numb(1920*Adoptation.WidthAdBack), Numb(1080 * Adoptation.HeightAdBack));
            Label[] LabMS = { CurrentPlayer, Player1, Player2, Player3, Player4, Player5, Player6, Lab1, TimerFlees, TimerFlees1, CureHealTxt, RecoverAPTxt, BuffUpTxt, DamageFoe, DamageFoe2, DamageFoe3, Lab2, BattleText1, BattleText2, BattleText3, BattleText4, BattleText5, BattleText6, HPtext, APtext, LevelText, HP, AP, HPenemy, ItemText, ATK, ExpText, AfterLevel, AfterName, AfterStatus, NewLevelGet, BeforeParams, BeforeHPtxt, BeforeAPtxt, BeforeHP, BeforeAP, BeforeAttack, BeforeDefence, BeforeAgility, BeforeSpecial, BeforeATK, BeforeDEF, BeforeAG, BeforeSP, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, AfterBattleGet, MaterialsGet, MaterialsAdd, MaterialsOnHand, ItemsGet, ItemsGetSlot1, Name0, Level0, StatusP, HPtext1, APtext1, HP1, AP1, Exp1, TimeRecordText, Params, ParamsATK, ParamsDEF, ParamsAG, ParamsSP, ATK1, AddATK1, DEF1, AddDEF1, AG1, SP1, EquipText, EquipH, EquipB, EquipL, EquipD, CostText, AbilsCost, FightSkills, MiscSkills, BandageText, HerbsText, EtherText, Ether2OutText, SleepBagText, ElixirText, AntidoteText, FusedText, CountText, MaterialsCraft, CrftAntidoteCostTxt, CrftBandageCostTxt, CrftEtherCostTxt, CrftFusedCostTxt, CrftHerbsCostTxt, CrftEther2CostTxt, CrftBedbagCostTxt, CrftElixirCostTxt, Task1, Task2, Task3, Task4, InfoHeaderText1, InfoHeaderText2, InfoHeaderText3, InfoIndex, DescribeHeader, Describe1, Describe2, MusicText, MusicPercent, SoundsText, SoundsPercent, NoiseText, NoisePercent, BrightnessText, BrightnessPercent, GameSpeedText, GameSpeedX, FoeAtk1, FoeDef1, FoeSpd1, FoeSpc1, FoeWkn1, FoeNam1, FoeDsc1, FoeAtk2, FoeDef2, FoeSpd2, FoeSpc2, FoeWkn2, FoeNam2, FoeDsc2, FoeAtk3, FoeDef3, FoeSpd3, FoeSpc3, FoeWkn3, FoeNam3, FoeDsc3, FoeAtk4, FoeDef4, FoeSpd4, FoeSpc4, FoeWkn4, FoeNam4, FoeDsc4, FoeAtk5, FoeDef5, FoeSpd5, FoeSpc5, FoeWkn5, FoeNam5, FoeDsc5, FoeAtk6, FoeDef6, FoeSpd6, FoeSpc6, FoeWkn6, FoeNam6, FoeDsc6, FoeAtk7, FoeDef7, FoeSpd7, FoeSpc7, FoeWkn7, FoeNam7, FoeDsc7, FoeAtk8, FoeDef8, FoeSpd8, FoeSpc8, FoeWkn8, FoeNam8, FoeDsc8, FoeAtk9, FoeDef9, FoeSpd9, FoeSpc9, FoeWkn9, FoeNam9, FoeDsc9, FoeAtk10, FoeDef10, FoeSpd10, FoeSpc10, FoeWkn10, FoeNam10, FoeDsc10, FoeAtk11, FoeDef11, FoeSpd11, FoeSpc11, FoeWkn11, FoeNam11, FoeDsc11, FoeAtk12, FoeDef12, FoeSpd12, FoeSpc12, FoeWkn12, FoeNam12, FoeDsc12, FoeAtk13, FoeDef13, FoeSpd13, FoeSpc13, FoeWkn13, FoeNam13, FoeDsc13, FoeAtk14, FoeDef14, FoeSpd14, FoeSpc14, FoeWkn14, FoeNam14, FoeDsc14, FoeAtk15, FoeDef15, FoeSpd15, FoeSpc15, FoeWkn15, FoeNam15, FoeDsc15, FoeAtk16, FoeDef16, FoeSpd16, FoeSpc16, FoeWkn16, FoeNam16, FoeDsc16, Task5, CrftCraftPerfbootsCostTxt };
            TextBlock[] blocks = { InfoText1, InfoText2, InfoText3 };
            ProgressBar[] BarMS = { Time1, HPbar, HPbarOver333, HPbarOver666, APbar, APbarOver333, APbarOver666, HPenemyBar, NextExpBar, BeforeHPbar, BeforeHPbarOver333, BeforeHPbarOver666, BeforeAPbar, BeforeAPbarOver333, BeforeAPbarOver666, AfterHPbar, AfterHPbarOver333, AfterHPbarOver666, AfterAPbar, AfterAPbarOver333, AfterAPbarOver666, HPbar1, APbar1, ExpBar1 };
            ScaleTransform[] scls = { MuLd, SnLd, NsLd, Gs, Brgt, TmOn };
            foreach (ScaleTransform scl in scls) { Scales(scl, scl.ScaleX * Adoptation.WidthAdBack, scl.ScaleY * Adoptation.HeightAdBack); }
            TimerTurnOn.Width *= Adoptation.WidthAdBack;
            TimerTurnOn.Height *= Adoptation.HeightAdBack;
            TimerTurnOn.FontSize *= Adoptation.WidthAdBack;
            foreach (Button btn in BtnWFM) { ButtonCHFT(btn, btn.FontSize * Adoptation.WidthAdBack); }
            foreach (Label lab in LabMS) { LabShrink(lab, Numb(lab.FontSize * Adoptation.WidthAdBack) > 0 ? Numb(lab.FontSize * Adoptation.WidthAdBack) : 1); }
            foreach (TextBlock blk in blocks) { TxtShrink(blk, Numb(blk.FontSize * Adoptation.WidthAdBack) > 0 ? Numb(blk.FontSize * Adoptation.WidthAdBack) : 1); }
            foreach (ProgressBar bar in BarMS) { BarShrink(bar, bar.Width * Adoptation.WidthAdBack, bar.Height * Adoptation.HeightAdBack); }
        }
        //[EN] Accurate transform fullscreen media
        //[RU] Аккуратное преобразование полноэкранного медиа
        private void FullMediaShrink(in int W, in int H)
        {
            MedShrink(Med1, W, H);
            MedShrink(Med2, W, H);
            MedShrink(Win, W, H);
            MedShrink(GameOver, W, H);
            MedShrink(ChapterIntroduction, W, H);
            MedShrink(TheEnd, W, H);
        }
        //[EN] Get coefficient
        //[RU] Получение коэффициентов
        private void CheckScreenProperties()
        {
            Adoptation.WidthAdBack = SystemParameters.PrimaryScreenWidth / 1920;
            Adoptation.HeightAdBack = SystemParameters.PrimaryScreenHeight / 1080;
            //Adoptation.HeightAdBack = SystemParameters.VirtualScreenHeight / 1080;
            //Adoptation.WidthAdBack = SystemParameters.VirtualScreenWidth / 1920;
            Adaptate();
        }
        //[EN] Set events on triggers
        //[RU] Установка событий на триггеры
        private void SetAllTimeTriggers()
        {
            EventHandler[] events = new EventHandler[]
            {
                 PHurt_D_T1,   //[EN] Damage: Player | [RU] Урон: Игрок
                 THurt_D_T2,   //[EN] Damage: Texts  | [RU] Урон: Текст
                 E1Atk_D_T3,   //[EN] Attack: Enemy1 | [RU] Атака: Враг1
                 E2Atk_D_T4,   //[EN] Attack: Enemy2 | [RU] Атака: Враг2
                 E3Atk_D_T5,   //[EN] Attack: Enemy3 | [RU] Атака: Враг3
                 PHAtk_D_T6,   //[EN] Attack: Punch  | [RU] Атака: Кулак
                 PKAtk_D_T7,   //[EN] Attack: Knife  | [RU] Атака: Нож
                 PSAtk_D_T8,   //[EN] Attack: Sword  | [RU] Атака: Меч
                 PMAtk_D_T9,   //[EN] Attack: XM214  | [RU] Атака: Миниган XM214-A
                 PFlee_D_T10,  //[EN] Battle: Escape | [RU] Битва: Побег
                 PItem_D_T11,  //[EN] Battle: Items  | [RU] Битва: Предметы
                 Pure1_D_T12,  //[EN] Skills: Cure   | [RU] Умения: Лечение
                 Pure2_D_T13,  //[EN] Skills: Cure2  | [RU] Умения: Лечение 2
                 PHeal_D_T14,  //[EN] Skills: Heal   | [RU] Умения: Исцеление
                 PBuff_D_T15,  //[EN] Skills: Buff   | [RU] Умения: Усиление
                 PTogh_D_T16,  //[EN] Skills: Shield | [RU] Умения: Щит
                 PHpUp_D_T17,  //[EN] Skills: Hp up  | [RU] Умения: Подъём ОЗ
                 PApUp_D_T18,  //[EN] Skills: Ap up  | [RU] Умения: Подъём ОД
                 PTrch_D_T19,  //[EN] Skills: Torch  | [RU] Умения: Факел
                 PWhip_D_T20,  //[EN] Skills: Whip   | [RU] Умения: Кнут
                 PThrw_D_T21,  //[EN] Skills: Sling  | [RU] Умения: Рогатка
                 Puper_D_T22,  //[EN] Skills: Combo  | [RU] Умения: Комбо
                 Pnado_D_T23,  //[EN] Skills: Wind   | [RU] Умения: Ветер
                 Puake_D_T24,  //[EN] Skills: Stones | [RU] Умения: Камни
                 Pearn_D_T25,  //[EN] Skills: Learn  | [RU] Умения: Изучение
                 SMini_D_T26,  //[EN] Scene: S-size  | [RU] Сцена: S-размер
                 SSwth_D_T27,  //[EN] Scene: SSwitch | [RU] Сцена: Серьёзный обмен
                 Targt_D_T28,  //[EN] Active: Target | [RU] Активное: Цель
                 PBndg_D_T29,  //[EN] Items: Bandage | [RU] Предметы: Бинт
                 PEthr_D_T30,  //[EN] Items: Ether   | [RU] Предметы: Эфир
                 PHerb_D_T31,  //[EN] Items: Herbs   | [RU] Предметы: Травы
                 PEtr2_D_T32,  //[EN] Items: Ether 2 | [RU] Предметы: Эфир 2
                 PAtdt_D_T33,  //[EN] Items: Antidote| [RU] Предметы: Противоядие
                 PCur2_D_T34,  //[EN] Texts: Cure 2  | [RU] Текст: Лечение 2
                 PFusd_D_T35,  //[EN] Items: Bone mix| [RU] Предметы: Смесь костной муки
                 PElxr_D_T36,  //[EN] Items: Elixir  | [RU] Предметы: Эликсир
                 PRegn_F_T37,  //[EN] Texts: Regen   | [RU] Текст: Регенерация
                 PCtrl_F_T38,  //[EN] Texts: Control | [RU] Текст: Контроль
                 PThwr_I_T39,  //[EN] Damage: Throw  | [RU] Урон: Бросок
                 PWhrl_I_T40,  //[EN] Damage: Whirl  | [RU] Урон: Вихрь
                 PQuak_I_T41,  //[EN] Damage: Quake  | [RU] Урон: Тряска
                 PTurn_I_T42,  //[EN] Turns: Player  | [RU] Ходы: Игрок
                 ETurn_I_T43,  //[EN] Turns: Enemy   | [RU] Ходы: Враг
                 WRecd_R_T44,  //[EN] Run: Speed     | [RU] Прохождение: Скорость
                 Boss1_C_T45,  //[EN] Cut': Boss 1   | [RU] Вырезка: Босс 1
                 Boss2_C_T46,  //[EN] Cut': Boss 2   | [RU] Вырезка: Босс 2
                 Boss3_C_T47,  //[EN] Cut': Boss 3   | [RU] Вырезка: Босс 3
                 RRoll_L_T48,  //[EN] Live: RockRoll | [RU] Живая: Рок н' ролл (перекати шар)
                 EHurt_D_T49,  //[EN] Damage: Enemy  | [RU] Урон: Противник
                 PCure_D_T50,  //[EN] Texts: Cure    | [RU] Текст: Лечение
                 PAtxc_D_T51,  //[EN] Texts: Heal    | [RU] Текст: Исцеление
                 PToch_D_T52,  //[EN] Damage: Torch  | [RU] Урон: Факел
                 PWhpd_D_T53,  //[EN] Damage: Whip   | [RU] Урон: Кнут
                 PSupr_D_T54,  //[EN] Damage: Super  | [RU] Урон: Супер
                 PPowr_D_T55,  //[EN] Texts: Buff    | [RU] Текст: Усиление
                 AStat_F_T56,  //[EN] Exp: Stat add  | [RU] Опыт: Повышение параметра
                 AMats_F_T57,  //[EN] Exp: Materials | [RU] Опыт: Материалы
                 NLevl_F_T58,  //[EN] Exp: New level | [RU] Опыт: Новый уровень
                 TRout_F_T59   //[EN] Live: Get away!| [RU] Живая: Бежим!
            };

            TimeSpan[] spans = new TimeSpan[]
            {
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(100/ GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, 20),
                new TimeSpan(0, 0, 0, 0, 20),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, 1),
                new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, 1),
                new TimeSpan(0, 0, 0, 0, 20),
                new TimeSpan(0, 0, 0, 0, 20),
                new TimeSpan(0, 0, 0, 0, 20),
                new TimeSpan(0, 0, 0, 1),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Bits(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, Shrt(75 / GameSpeed.Value)),
                new TimeSpan(0, 0, 0, 0, 1),
                new TimeSpan(0, 0, 0, 0, 1),
                new TimeSpan(0, 0, 0, 0, 1),
                new TimeSpan(0, 0, 0, 1)
            };
            for (Byte i = 0; i < events.Length; i++) {
                switch (i) {
                    case 0:  ChangeTimer(ref PHurt, events[i], spans[i]); break;
                    case 1:  ChangeTimer(ref THurt, events[i], spans[i]); break;
                    case 2:  ChangeTimer(ref E1Atk, events[i], spans[i]); break;
                    case 3:  ChangeTimer(ref E2Atk, events[i], spans[i]); break;
                    case 4:  ChangeTimer(ref E3Atk, events[i], spans[i]); break;
                    case 5:  ChangeTimer(ref PHAtk, events[i], spans[i]); break;
                    case 6:  ChangeTimer(ref PKAtk, events[i], spans[i]); break;
                    case 7:  ChangeTimer(ref PSAtk, events[i], spans[i]); break;
                    case 8:  ChangeTimer(ref PMAtk, events[i], spans[i]); break;
                    case 9:  ChangeTimer(ref PFlee, events[i], spans[i]); break;
                    case 10: ChangeTimer(ref PItem, events[i], spans[i]); break;
                    case 11: ChangeTimer(ref Pure1, events[i], spans[i]); break;
                    case 12: ChangeTimer(ref Pure2, events[i], spans[i]); break;
                    case 13: ChangeTimer(ref PHeal, events[i], spans[i]); break;
                    case 14: ChangeTimer(ref PBuff, events[i], spans[i]); break;
                    case 15: ChangeTimer(ref PTogh, events[i], spans[i]); break;
                    case 16: ChangeTimer(ref PHpUp, events[i], spans[i]); break;
                    case 17: ChangeTimer(ref PApUp, events[i], spans[i]); break;
                    case 18: ChangeTimer(ref PTrch, events[i], spans[i]); break;
                    case 19: ChangeTimer(ref PWhip, events[i], spans[i]); break;
                    case 20: ChangeTimer(ref PThrw, events[i], spans[i]); break;
                    case 21: ChangeTimer(ref Puper, events[i], spans[i]); break;
                    case 22: ChangeTimer(ref Pnado, events[i], spans[i]); break;
                    case 23: ChangeTimer(ref Puake, events[i], spans[i]); break;
                    case 24: ChangeTimer(ref Pearn, events[i], spans[i]); break;
                    case 25: ChangeTimer(ref SMini, events[i], spans[i]); break;
                    case 26: ChangeTimer(ref SSwth, events[i], spans[i]); break;
                    case 27: ChangeTimer(ref Targt, events[i], spans[i]); break;
                    case 28: ChangeTimer(ref PBndg, events[i], spans[i]); break;
                    case 29: ChangeTimer(ref PEthr, events[i], spans[i]); break;
                    case 30: ChangeTimer(ref PHerb, events[i], spans[i]); break;
                    case 31: ChangeTimer(ref PEtr2, events[i], spans[i]); break;
                    case 32: ChangeTimer(ref PAtdt, events[i], spans[i]); break;
                    case 33: ChangeTimer(ref PCur2, events[i], spans[i]); break;
                    case 34: ChangeTimer(ref PFusd, events[i], spans[i]); break;
                    case 35: ChangeTimer(ref PElxr, events[i], spans[i]); break;
                    case 36: ChangeTimer(ref PRegn, events[i], spans[i]); break;
                    case 37: ChangeTimer(ref PCtrl, events[i], spans[i]); break;
                    case 38: ChangeTimer(ref PThwr, events[i], spans[i]); break;
                    case 39: ChangeTimer(ref PWhrl, events[i], spans[i]); break;
                    case 40: ChangeTimer(ref PQuak, events[i], spans[i]); break;
                    case 41: ChangeTimer(ref PTurn, events[i], spans[i]); break;
                    case 42: ChangeTimer(ref ETurn, events[i], spans[i]); break;
                    case 43: ChangeTimer(ref WRecd, events[i], spans[i]); break;
                    case 44: ChangeTimer(ref Boss1, events[i], spans[i]); break;
                    case 45: ChangeTimer(ref Boss2, events[i], spans[i]); break;
                    case 46: ChangeTimer(ref Boss3, events[i], spans[i]); break;
                    case 47: ChangeTimer(ref RRoll, events[i], spans[i]); break;
                    case 48: ChangeTimer(ref EHurt, events[i], spans[i]); break;
                    case 49: ChangeTimer(ref PCure, events[i], spans[i]); break;
                    case 50: ChangeTimer(ref PAtxc, events[i], spans[i]); break;
                    case 51: ChangeTimer(ref PToch, events[i], spans[i]); break;
                    case 52: ChangeTimer(ref PWhpd, events[i], spans[i]); break;
                    case 53: ChangeTimer(ref PSupr, events[i], spans[i]); break;
                    case 54: ChangeTimer(ref PPowr, events[i], spans[i]); break;
                    case 55: ChangeTimer(ref AStat, events[i], spans[i]); break;
                    case 56: ChangeTimer(ref AMats, events[i], spans[i]); break;
                    case 57: ChangeTimer(ref NLevl, events[i], spans[i]); break;
                    case 58: ChangeTimer(ref TRout, events[i], spans[i]); break;
                }
            };            
        }

        //[EN] New game start and return to normal stats
        //[RU] Начало новой игры и возврат к исходным значениям.
        private void New_game()
        {
            DataBaseMSsql.DeselectAllPlayers();

            DataBaseMSsql.NewGameStart(DataBaseMSsql.CurrentLogin);

            SetEnemies();
            Exp = 0;
            Foe1.EnemyAppears = new string[] { "", "", "" };
            Foe1.EnemiesStillAlive = Sets.FoeType4Alive = Sets.FoeType3Alive = Sets.FoeType2Alive = Sets.FoeType1Alive = 0;

            PharaohAppears.Opacity = 0.1;
            Ancient.Opacity = 0.25;
            FinalAppears.Opacity = 0.1;
            Sets.SpecialBattle = 0;
            TheEnd.Source = Ura(Path.CutScene.Victory);

            MapBuild(0);
            ImgGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress, PharaohAppears }, new Byte[] { 27, 24, 7, 9, 33, 25, 10, 4, 17, 8 }, new Byte[] { 19, 11, 21, 20, 18, 13, 38, 36, 29, 36 });
            
            //[EN] DevOp
            //[RU] Разработчик
            //Super1.SetStats(25, 999, 999, 255, 255, 255, 255);
            //Super1.SetCurrentHpAp(999, 999);
            
            //[EN] Normal
            //[RU] Обычный
            Super1.SetStats(0);
            Super1.SetCurrentHpAp(100, 40);
            Time1.Maximum = TimeFormula();
            PlayerSetLocation(34, 18);
            MaxAndWidthHPcalculate();
            MaxAndWidthAPcalculate();
            HeroStatus();
            BAG.EquipWearSet(false, false, false, false);
            BAG.ItemsSet(0, 0, 0, 0, 0, 0, 0, 0, 0);
            Super1.MenuTask = 0;
            FastImgChange(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Threasure1 }, BmpersToX(Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.Artifact1)));
        }

        //[EN] Play original soundtrack (OST)
        //[RU] Проигрывание оригинального саундтрека
        private void HeyPlaySomething(in string Path) { Sound1.Stop(); Sound1.Source = Ura(Path); Sound1.Play(); }
        private void Dj(in string Path) { Sound2.Stop(); Sound2.Source = Ura(Path); Sound2.Play(); }
        private void SEF(in string Path) { Sound3.Stop(); Sound3.Source = Ura(Path); Sound3.Play(); }

        //[EN] Hide/show elements
        //[RU] Спрятать/показать элементы
        private void ImgHide(Image Img) { Img.Visibility = Visibility.Hidden; Img.IsEnabled = false; }
        private void ImgShow(Image Img) { Img.Visibility = Visibility.Visible; Img.IsEnabled = true; }
        private void MediaHide(MediaElement Med) { Med.Stop(); Med.Visibility = Visibility.Hidden; Med.IsEnabled = false; }
        private void MediaShow(MediaElement Med) { Med.Visibility = Visibility.Visible; Med.IsEnabled = true; Med.Play(); }
        private void ButtonHide(Button Btn) { Btn.Visibility = Visibility.Hidden; Btn.IsEnabled = false; }
        private void BtnHideX(Button[] ButtonArray) { foreach (Button Btn in ButtonArray) ButtonHide(Btn); }
        private void ButtonShow(Button Btn) { Btn.Visibility = Visibility.Visible; Btn.IsEnabled = true; }
        private void LabHide(Label Lab) { Lab.Visibility = Visibility.Hidden; Lab.IsEnabled = false; }
        private void LabShow(Label Lab) { Lab.Visibility = Visibility.Visible; Lab.IsEnabled = true; }
        private void BarShow(ProgressBar Bar) { Bar.Visibility = Visibility.Visible; Bar.IsEnabled = true; }
        private void BarHide(ProgressBar Bar) { Bar.Visibility = Visibility.Hidden; Bar.IsEnabled = false; }
        private void TxtHide(TextBlock Txt) { Txt.Visibility = Visibility.Hidden; Txt.IsEnabled = false; }
        private void TxtShow(TextBlock Txt) { Txt.Visibility = Visibility.Visible; Txt.IsEnabled = true; }
        private void SldHide(Slider sld) { sld.Visibility = Visibility.Hidden; sld.IsEnabled = false; }
        private void SldShow(Slider sld) { sld.Visibility = Visibility.Visible; sld.IsEnabled = true; }
        private void ChbShow(CheckBox Chb) { Chb.Visibility = Visibility.Visible; Chb.IsEnabled = true; }
        private void ChbHide(CheckBox Chb) { Chb.Visibility = Visibility.Hidden; Chb.IsEnabled = false; }
        private void TBoxShow(TextBox tbx) { tbx.Visibility = Visibility.Visible; tbx.IsEnabled = true; }
        private void TBoxHide(TextBox tbx) { tbx.Visibility = Visibility.Hidden; tbx.IsEnabled = false; }
        private void GHide(Grid grid) { grid.Visibility = Visibility.Hidden; grid.IsEnabled = false; }
        private void GShow(Grid grid) { grid.Visibility = Visibility.Visible; grid.IsEnabled = true; }
        private void ImgShowX(in Image[] ImagesArray) { foreach (Image img in ImagesArray) ImgShow(img); }
        private void LabShowX(in Label[] LabelArray) { foreach (Label Lab in LabelArray) LabShow(Lab); }
        private void BarShowX(in ProgressBar[] ProgressBarArray) { foreach (ProgressBar Bar in ProgressBarArray) BarShow(Bar); }
        private void ImgGridX(in Image[] ImageArray, in Byte[] rows, in Byte[] cols) { for (Byte i = 0; i < ImageArray.Length; i++) ImgGrid(ImageArray[i], rows[i], cols[i]); }
        private void LabHideX(Label[] LabelArray) { foreach (Label Lab in LabelArray) LabHide(Lab); }
        private void ImgHideX(Image[] ImageArray) { foreach (Image Img in ImageArray) ImgHide(Img); }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            New_game();
            MediaShow(Med1);
            AnyHide(MainMenu);
            HeyPlaySomething(Path.GameMusic.Prologue);
        }

        //[EN] Bitmapimages and URI from string converting
        //[RU] Преобразование в изображения и URI из строки
        public Uri Ura(in string Path) { return new Uri(Path, UriKind.RelativeOrAbsolute); }
        public BitmapImage Bmper(string UriToBmp) { return new BitmapImage(new Uri(UriToBmp, UriKind.RelativeOrAbsolute)); }
        public BitmapImage Bmper(object Obj) { return (BitmapImage)Obj; }
        public BitmapImage[] BmpersToX(params BitmapImage[] bitmapImages) { return bitmapImages; }
        public BitmapImage[] BmpersToX(params string[] texts) { List<BitmapImage> bmps = new List<BitmapImage>(); foreach (string txt in texts) bmps.Add(Bmper(txt)); return bmps.ToArray(); }
        
        //[EN] For future
        //[RU] На будущее
        //private void AnyShowX(in Boolean[] Conditions, Object[] Objects) { for (Byte i = 0; i < Conditions.Length; i++) if (Conditions[i]) AnyShow(Objects[i]); }
        private void AnyShowX2(in Boolean[] Conditions, params Object[][] Objects) { for (Byte i = 0; i < Conditions.Length; i++) if (Conditions[i]) AnyShowX(Objects[i]); }

        //[EN] Map builder
        //[RU] Построитель карт
        private void MapBuild(in Byte Loc)
        {
            switch (Loc)
            {
                case 0:
                    MapScheme = new Byte[,]
                    {{ 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,161,  1,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1,  0,  0,  1,  1,  0,  0,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  1 },
                    {  1,  1,  0,  1,  1,  0,  1,  1,  1,  1,  0,  1,  1,  0,  1,  1,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  1,  1,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,203,  1,  0,  0,  1,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,133,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,204,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,191,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,173,  1,  1,  1,  1,  1,  1,  0,  1,  1,  0,  1,  0,  0,  1,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  1,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  0,  0,  1,  0,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,150,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  1,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,131,  1,  0,  0,  1,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,132,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,102,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,202,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  1,  0,  0,  1,172,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  1,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,201,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1,  1,  1,  0,  1,  1,  0,  0,  1,  1,  1,  1,  0,  0,  1,  1,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  1 },
                    {  1,  0,101,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,171,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,103,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 }};
                    break;
                case 1:
                    MapScheme = new Byte[,]
                    {{ 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  7,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,135,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,105,  1,232,  1,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  1,  1,  1,  0,  1,  0,  1,  1,  1,  0,  1 },
                    {  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,106,  0,  1,  0,  6,  1,  0,  1,  0,  6,  6,  6,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  0,  0,  1,205,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  1,  1,  6,  0,  1,208,  1,  0,  0,  6,  6,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  1,206,  1,  1,  0,  0,  0,  0,  0,  6,  0,  6,  6,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  6,  1,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  6,  0,  6,  0,  0,  1,  0,  0,  0,  6,  6,  0,  6,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  6,  6,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  1,  0,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  6,  6,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  1 },
                    {  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  6,  0,  0,  6,  0,  1,  0,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1 },
                    {  1,  0,  0,  0,162,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  6,  6,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1 },
                    {  1,  1,  1,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  0,  0,107,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  6,  0,  0,  6,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,136,  1,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  1,  0,  1,  1,  1,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,135,  0,  0,  0,  6,  6,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  1,  0,  1,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  6,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,207,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  1,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  0,  0,  0,  1,  1,  0,  1,  1,  0,  0,  0,  6,  0,  6,  0,  1,  0,  0,  1,104,  1,  0,  1 },
                    {  1,  0,176,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,175,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  6,  0,  1,  0,  0,  0,  1,  1,  1,  6,  1 },
                    {  1,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  6,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,108,  0,  0,  0,  6,  0,  6,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,138,  1,  0,  6,  0,  6,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1,  6,  1,  0,  1,  0,  1,192,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,213,  1,  1,  1,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,134,  1,  1,  1,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  1,137,  1,  0,  1,  0,150,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  0,  6,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,174,  6,  6,  0,  1,  1,  0,  6,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  6,  6,  0,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,  0,  0,  0,  0,  1,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  6,  0,  0,  0,  0,  0,  0,  6,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  6,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  0,  0,  1,  1,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  6,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 } };
                    break;
                case 2:
                    MapScheme = new Byte[,]
                    {{ 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,178,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  8,  8,  1,  0,  0,  0,  1,  8,  8,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,179,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  8,  8,  1,  0,163,  0,  1,  8,  8,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  8,  8,  1,  0,  0,  0,  1,  8,  8,  0,  0,  1,  0,  1,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  8,  8,  8,  1,  0,  1,  8,  8,  8,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  6,  6,  0,  0,  0,  1,  1,  1,  0,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  0,  1,  1,  1,  0,  0,  0,  6,  6,  0,  0,  1,  1,  0,  1,  0,  0,  0,  8,  8,  8,  0,  8,  8,  8,  0,  0,  0,  1,  0,  1,  0,  0,  1,  1,  0,  0,  6,  6,  0,  0,  1,  0,  0,  0,  1,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  1,  0,  0,  0,  1,  0,  0,  6,  6,  0,  0,  1,  1,  0,  1,  1,  0,  0,  0,  8,  8,  0,  8,  8,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  6,  6,224,222,  6,  6,  1,  0,151,  0,  1,  6,  6,224,222,  6,  6,  1 },
                    {  1,  6,  6,223,225,  6,  6,  1,  0,152,  0,  1,  6,  6,223,225,  6,  6,  1,  1,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  1,  1,  6,  6,222,222,  6,  6,  1,  0,  0,  0,  1,  6,  6,222,222,  6,  6,  1 },
                    {  1,  6,  6,223,223,  6,  6,  1,  0,  0,  0,  1,  6,  6,223,223,  6,  6,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  1,  1,  0,  0,  6,  6,  0,  0,  0,  1,  0,  1,  0,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  0,  1,  0,  1,  0,  0,  0,  6,  6,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  1,  0,  1,  1,  0,  0,  6,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,  1 },
                    {  1,  0,  0,  6,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,139,139,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,222,222,224,221,223,  0,  0,  0,  0,  0,  0,  1,  1,  0,223,  8,223,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,225,  0,  0,  0,  0,  0,140,140,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,221,222,222,223,223,  0,  0,  0,  0,  0,  0,  1,  1,  0,  8,225,  8,  0,  0,  0,  0,  0,  0,  0,  0,  0,225,  8,225,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,223,225,  0,  0,  0,  1,  0,221,  0,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,225,  8,225,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,225,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,222,224,223,  0,  0,  0,  1,  0,  0,  1,  0,226,  1 },
                    {  1,  1,  1,  1,  1,  0,  0,  1,  1,  1,  1,  8,  8,  8,  8,  8,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,223,224,222,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1,  8,  8,  8,  8,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,138,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,225,223,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  1,  1,138,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,209,  0,  1,  0,  1,  9,  1,233,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  1,177,  0,  0,  1,  0,  6,  0,  6,  0,  8,  8,  8,  0,  6,  0,  6,  0,  1,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  1,  0,  0,  0,  1,  0,  1,  9,  0,  1,  1,  1,  0,223,  0,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  0,150,  0,  0,  0,  0,  6,  0,  6,  8,221,  8,  6,  0,  6,  0,  0,  0,  1,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  6,  6,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  6,  0,  6,  0,  8,  8,  8,  0,  6,  0,  6,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  8,  0,  0,  0,  8,  8,  1,  9,  1,  1,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  7,  1,  0,  6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  1,  8,  1,  0,  1,  0,  0,221,  0,  1,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  1,135,  1,  6,110,  6,  0,  0,  0,  0,  0,  0,  1,  1,  1 },
                    {  1,  0,  6,  0,  0,224,  1,  8,  1,  9,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,210,  0,  0,  1,  0,  8,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  6,  0,  0,  0,  1,  1,  1,  1,  0,  0,  1 },
                    {  1,  1,  1,  0,  1,  1,  1,  8,  1,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  6,  0,  0,  0,  0,  6,  0,  0,  6,  0,  6,  8,  0,  9,  1,  1,222,  0,  0,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  6,  0,  1,  8,  8,  8,  1,  9,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  1,  1,  1,  0,  1,  0,  8,  0,  0,  1,  1,  1,  1,  1,  1,  8,  8,  0,  0,  0,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  8,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  6,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,104,  0,  0,  0,  0,  1,  0,  1,136,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  6,  0,  1,  8,  1,  0,  0,  6,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  0,  8,  0,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  0,  8,212,  8,  0,  1 },
                    {  1,  1,  1,  0,  1,  8,  1,  6,  6,  0,  1,  0,  0,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  6,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,105,  1,  0,  1,  0,  0,  0,  1,  0,  0,  8,  0,  0,  1 },
                    {  1,  0,  0,  0,  1,  8,  1,  6,  6,  0,  1,  0,  0,  0,  0,  1,  0,  1,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  8,  0,  1,  0,  1,  1,  1,  0,  0,134,211,  1,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  0,  6,  1,  6,  1,  6,  0,  6,  1,  0,  0,  0,  0,  1,  1,  1,222,  1,  1,  1,  0,  1,  0,  0,  1,  0,  0,  6,  1,  0,  1,  0,  0,  0,  8,  1,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  0,  6,  0,  1,  0,  6,  6,  1,  0,  0,  9,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  0,  1,  0,  1,  1,  1,  1 },
                    {  1,  0,  1,  6,  0,  6,  1,  0,  6,  6,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,223,  1,  8,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1 },
                    {  1,  0,  1,  1,  1,  1,  1,  6,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  0,  0,  0,  6,  0,  1,  1,  1,  0,  0,  1 },
                    {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  6,  0,  0,  0,  0,  1,106,  0,  1 },
                    {  1,109,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,111,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,223,  1 },
                    {  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 } };
                    break;
                case 3:
                    MapScheme = new Byte[,]
                    {{1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    { 1,  0,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  0,  0,  0,  0,  1 },
                    { 1,  0,  1,  0,  0,  1,  1,  0,  1,  1,  1,  0,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  1 },
                    { 1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1 },
                    { 1,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  1 },
                    { 1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  1,  1,  1,  0,  1 },
                    { 1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  1,  1,  0,  1,  0,  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  1,  1,  1 },
                    { 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1 },
                    { 1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  1 },
                    { 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1 },
                    { 1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  1,  1,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1 },
                    { 1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  0,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1 },
                    { 1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1,  1,  0,  0,  1,  0,  0,  1,  1,  0,  1,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  1,  0,  0,  1 },
                    { 1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  0,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  1 },
                    { 1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  1,  1,  1,  0,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  1 },
                    { 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    { 1,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  1 },
                    { 1,  0,  1,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  1,  0,  1,  1,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  1,  0,  1,  0,  0,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1 },
                    { 1,  0,  0,  1,  1,  0,  1,  0,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  0,  1,  1,  1,  0,  1,  1,  1,  0,  1,  0,  1,  0,  1,  1,  1,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    { 1,  0,  1,  1,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  1,  1,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1 },
                    { 1,  0,  0,  1,  1,  0,  1,  0,  0,  1,  1,  1,  0,  1,  0,  1,  0,  0,  0,  0,  1,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  1,  1,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1 },
                    { 1,  0,  1,  1,  0,  0,  1,  0,  1,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  1,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
                    { 1,  0,  0,  1,  1,  0,  1,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  1,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  1,  0,  1,  1,  0,  0,  1,  0,  0,  0,  1,  0,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  1,  0,  1,  0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  1,  1,  1,  0,  1,  1,  1,  0,  0,  0,  1,  0,  1,  0,  1,  0,  1,  0,  0,  0,  1,  0,  0,  0,  1,  1,  0,  0,  0,  0,  1,  0,  0,  1 },
                    { 1,  0,  1,  1,  1,  1,  1,  0,  1,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  1,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  1,  1,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  1 },
                    { 1,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  1,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,170,  0,  1,  1,  0,  0,  0,  0,  0,  1,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1 },
                    { 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 }};
                    break;
                default: break;
            }
        }

        //[EN] Activate/Deactivate all .. | [RU] Активировать/Деактивировать все...
        //[EN] Chests+Tables
        //[RU] Сундуки+Таблички
        private void ChestsAndTablesAllTurnOn1() { ImgShowX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3 }); }
        private void ChestsAndTablesAllTurnOff1() { ImgHideX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3 }); }
        private void Map1ModelsAllTurnOn1() { ImgShowX(new Image[] { KeyImg1, KeyImg2, KeyImg3, LockImg1, LockImg2, LockImg3 }); }
        private void Map1ModelsAllTurnOff1() { ImgHideX(new Image[] { LockImg1, LockImg2, LockImg3, KeyImg1, KeyImg2, KeyImg3 }); }
        private void CheckIfInteracted() {
            UIElement[] elements = { ChestMessage1, TaskCompletedImg, PainImg, HPhelper };
            foreach (UIElement element in elements)
                if (element.IsEnabled)
                    AnyHide(element);
        }

        //[EN] After game intro has been ended
        //[RU] После завершения пролога.
        private void Med1_MediaEnded(object sender, RoutedEventArgs e) { Img1.Source = Bmper(Path.Backgrounds.Normal); AnyShowX(Img1, ChapterIntroduction); AnyHideX(Med1, Skip1); HeyPlaySomething(Path.GameMusic.AncientPyramid); }
        
        //[EN] Complete tasks
        //[RU] Завершение задач.
        private void CollectKey(Image Key, Image Lock)
        {
            ImgHideX(new Image[] { Key, Lock });
            ImgShow(TaskCompletedImg);
            SEF(Path.GameSounds.DoorOpened);
            Sets.LockIndex--;
            Sets.EnemyRate++;
            Super1.MenuTask++;
        }
        private void PullTheLever(Image Lever, Image[] Imgs)
        {
            AnyShowX(Imgs);
            Lever.Source = Bmper(Path.MapModels.LeverOn);
            SEF(Path.GameSounds.DoorOpened);
        }
        private Byte Bits(Object obj) { return Convert.ToByte(obj); }
        private Int32 Numb(Object obj) { return Convert.ToInt32(obj); }
        private UInt16 Shrt(Object obj) { return Convert.ToUInt16(obj); }

        //[EN] Multibar health feature
        //[RU] Особенность многошкального здоровья.
        private void MaxAndWidthHPcalculate()
        {
            if (Super1.MaxHP > 333) NewMaximumX(Super1.MaxHP > 666 ? new UInt16[] { 333, 333, Shrt(Super1.MaxHP - 666) } : new UInt16[] { 333, Shrt(Super1.MaxHP - 333) },
                Super1.MaxHP > 666 ? new ProgressBar[] { HPbar, HPbarOver333, HPbarOver666 } : new ProgressBar[] { HPbar, HPbarOver333 });
            else NewMaximum(HPbar, Super1.MaxHP);
        }
        private void MaxAndWidthAPcalculate()
        {
            if (Super1.MaxAP > 333) NewMaximumX(Super1.MaxAP > 666 ? new UInt16[] { 333, 333, Shrt(Super1.MaxAP - 666) } : new UInt16[] { 333, Shrt(Super1.MaxAP - 333) },
                Super1.MaxAP > 666 ? new ProgressBar[] { APbar, APbarOver333, APbarOver666 } : new ProgressBar[] { APbar, APbarOver333 });
            else NewMaximum(APbar, Super1.MaxAP);
        }

        //[EN] Calculate HP and AP
        //[RU] Подсчёт ОЗ и ОД.
        private void CurrentHPcalculate()
        {
            if (Super1.CurrentHP > 666)
            {
                if (!HPbarOver666.IsEnabled) BarShow(HPbarOver666);
                HPbar.Value = HPbar.Maximum;
                HPbarOver333.Value = HPbarOver333.Maximum;
                HPbarOver666.Value = Super1.CurrentHP - 666;
            }
            else if (Super1.CurrentHP > 333)
            {
                if (HPbarOver666.IsEnabled) BarHide(HPbarOver666);
                if (!HPbarOver333.IsEnabled) BarShow(HPbarOver333);
                HPbarOver666.Value = 0;
                HPbarOver333.Value = Super1.CurrentHP - 333;
                HPbar.Value = HPbar.Maximum;
            }
            else
            {
                if (HPbarOver666.IsEnabled) BarHide(HPbarOver666);
                if (HPbarOver333.IsEnabled) BarHide(HPbarOver333);
                HPbarOver666.Value = 0;
                HPbarOver333.Value = 0;
                HPbar.Value = Super1.CurrentHP;
            }
            RefreshAllHP();
        }
        private void CurrentAPcalculate()
        {
            if (Super1.CurrentAP > 666)
            {
                if (!APbarOver666.IsEnabled) BarShow(APbarOver666);
                APbar.Value = APbar.Maximum;
                APbarOver333.Value = APbarOver333.Maximum;
                APbarOver666.Value = Super1.CurrentAP - 666;
            }
            else if (Super1.CurrentAP > 333)
            {
                if (APbarOver666.IsEnabled) BarHide(APbarOver666);
                if (!APbarOver333.IsEnabled) BarShow(APbarOver333);
                APbar.Value = APbar.Maximum;
                APbarOver666.Value = 0;
                APbarOver333.Value = Super1.CurrentAP - 333;
                APbar.Value = APbar.Maximum;
            }
            else
            {
                if (APbarOver666.IsEnabled) BarHide(APbarOver666);
                if (APbarOver333.IsEnabled) BarHide(APbarOver333);
                APbarOver666.Value = 0;
                APbarOver333.Value = 0;
                APbar.Value = Super1.CurrentAP;
            }
            RefreshAllAP();
        }
        private void CurrentHpApCalculate() { CurrentHPcalculate(); CurrentAPcalculate(); }
        private void NewMaximum(ProgressBar Bar, in UInt16 Max) { Bar.Maximum = Max; Bar.Width = Bar.Maximum * Adoptation.WidthAdBack; }
        private void NewMaximumX(in UInt16[] Maxes, params ProgressBar[] Bars) { for (Byte i = 0; i < Bars.Length; i++) NewMaximum(Bars[i], Maxes[i]); }
        private void NewMaximumX(in UInt16 Max, params ProgressBar[] Bars) { foreach (ProgressBar Bar in Bars) NewMaximum(Bar, Max); }
        private void FullRecover(ProgressBar Bar) { Bar.Value = Bar.Maximum; }
        private void FullRecoverX(params ProgressBar[] Bars) { foreach (ProgressBar Bar in Bars) FullRecover(Bar); }
        private void Laugh()
        {
            Sound2.SpeedRatio = GameSpeed.Value;
            Sound3.SpeedRatio = GameSpeed.Value;
        }
        private void NotLaugh()
        {
            Sound2.SpeedRatio = 1;
            Sound3.SpeedRatio = 1;
        }

        //[EN] Movement and map interaction
        //[RU] Передвижение и взаимодействие с картой.
        private Byte CheckGuy()
        {
            String[] Direction = { Path.Ray.StaticRight, Path.Ray.GoRight, Path.Ray.StaticDown, Path.Ray.GoDown1, Path.Ray.GoDown2, Path.Ray.StaticLeft, Path.Ray.GoLeft, Path.Ray.StaticUp, Path.Ray.GoUp1, Path.Ray.GoUp2 };
            SByte[,] Dir1 = { { 0, 0, 1, 1, 1, 0, 0, -1, -1, -1 }, { 1, 1, 0, 0, 0, -1, -1, 0, 0, 0 } };
            for (Byte i = 0; i < Direction.Length; i++) if (Img2.Source.ToString().Contains(Direction[i])) return MapScheme[Adoptation.ImgYbounds + Dir1[0, i], Adoptation.ImgXbounds + Dir1[1, i]];
            return 0;
        }
        private void Movement(in Boolean LeftRightOrUpDown, in BitmapImage bmp, in Byte rowcolumn)
        {
            Img2.Source = bmp;
            Adoptation.SetBounds(LeftRightOrUpDown, rowcolumn);
            PlayerSetLocation(Bits(Adoptation.ImgYbounds), Bits(Adoptation.ImgXbounds));
            GroundCheck(MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds]);
            TablesSetInfo();
            if (CurrentLocation < 3) {
                if (Sets.StepsToBattle >= rnd)
                {
                    AnyHideX(PainImg, Img2, HPhelper);
                    Sound1.Stop();
                    Dj(Path.GameNoises.Danger);
                    LetsBattle();
                }
                Sets.StepsToBattle++;
            }
            GetPoisoned();
        }

        //[EN] "Live" scene
        //[RU] "Живая" сцена
        private void SomeRudeAppears(in Byte BattleIndex, ref System.Windows.Threading.DispatcherTimer timer, in string Noise)
        {
            Sets.SpecialBattle = BattleIndex;
            Img2.IsEnabled = false;
            Sound1.Stop();
            TimerOn(ref timer);
            Dj(Noise);
        }

        //[EN] Check if person get poisoned
        //[RU] Проверить отравлен ли герой
        private void GetPoisoned()
        {
            if (Super1.PlayerStatus == 1) Super1.CurrentHP--;
            if (Super1.CurrentHP <= 0)
            {
                Super1.PlayerStatus = 0;
                ImgHide(Img2);
                AnyHide(GameMenu);
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                MediaShow(GameOver);
                if (RRoll.IsEnabled) TimerOff(ref RRoll);
                if (TRout.IsEnabled) TimerOff(ref TRout);
            }
        }

        //[EN] Check if got wall on the way
        //[RU] Проверка на препятствия
        private Boolean IsWayNext(Byte map)
        {
            switch (map)
            {
                case 0: case 6: case 7: case 8: case 9: case 104: case 105: case 106: case 107: case 108: case 112:
                case 113: case 114: case 115: case 116: case 117: case 118: case 119: case 120: case 150: case 151:
                case 152: case 170: case 191: case 192: return true;
                default: return false;
            }
        }
        private void CheckMapIfModelExistsX(in Byte[] Models, in Image[] images) { for (Byte i = 0; i < Models.Length; i++) if (CheckMapIfModelExists(Models[i])) ImgShow(images[i]); }

        //[EN] Game messages
        //[RU] Игровые сообщения
        private Byte TColMgs(in Image img) { return Numb(img.GetValue(Grid.ColumnProperty)) - 5 > 0 ? Bits(Bits(img.GetValue(Grid.ColumnProperty)) - 5) : Bits(0); }
        private Byte TRowMgs(in Image img) { return Numb(img.GetValue(Grid.RowProperty)) - 8 > 0 ? Bits(Bits(img.GetValue(Grid.RowProperty)) - 8) : Bits(0); }
        private Byte ColMgs(in Image img) { return Numb(img.GetValue(Grid.ColumnProperty)) - 3 > 0 ? Bits(Bits(img.GetValue(Grid.ColumnProperty)) - 3) : Bits(0); }
        private Byte RowMgs(in Image img) { return Numb(img.GetValue(Grid.RowProperty)) - 5 > 0 ? Bits(Bits(img.GetValue(Grid.RowProperty)) - 5) : Bits(0); }
        private void TablesSetInfo()
        {
            if (Sets.TableEN || TableMessage1.IsEnabled) ImgHide(TableMessage1);
            Sets.TableEN = !Sets.TableEN && !TableMessage1.IsEnabled;
            Byte Interaction = CheckGuy();
            Byte[] Conditions = { 171, 172, 173, 174, 175, 176, 177, 178, 179 };
            BitmapImage[] images = BmpersToX(Bmper(Path.Msg.Tb1_Msg1), Bmper(Path.Msg.Tb2_Msg1), Bmper(Path.Msg.Tb3_Msg1), Bmper(Path.Msg.Tb1_Msg2), Bmper(Path.Msg.Tb2_Msg2), Bmper(Path.Msg.Tb3_Msg2), Bmper(Path.Msg.Tb1_Msg3), Bmper(Path.Msg.Tb2_Msg3), Bmper(Path.Msg.Tb3_Msg3));
            Image[] Mess = { Table1, Table2, Table3, Table1, Table2, Table3, Table1, Table2, Table3 };
            for (Byte i = 0; i < Conditions.Length; i++) if (Interaction == Conditions[i]) SetTablesMessage(images[i], TRowMgs(Mess[i]), TColMgs(Mess[i]));
        }
        private void SetTablesMessage(BitmapImage image, Byte X, Byte Y)
        {
            TableMessage1.Source = image;
            if (!Sets.TableEN) Sets.TableEN = true;
            ImgGrid(TableMessage1, X, Y);
            ImgShow(TableMessage1);
        }

        //[EN] Determine a battle
        //[RU] Определение битвы.
        private void LetsBattle() 
        {
            Sets.StepsToBattle--;
            string[] dng = { Path.GameNoises.Danger, Path.GameNoises.Danger2, Path.GameNoises.Danger3 };
            Dj(dng[CurrentLocation]);
            MediaShow(Med2);
        }
        private void WhatsGoingOn(in Byte SecretBattlesIndex)
        { 
            MapScheme[Adoptation.ImgYbounds,Adoptation.ImgXbounds] = 0;
            Sets.SpecialBattle = SecretBattlesIndex;
        }
        private void IhurtMyLegKit(int damage)
        {
            Super1.CurrentHP -= Shrt(damage);
            HPbar1.Value = Super1.CurrentHP;
            BarGrid(HPhelper, Bits(Shrt(Img2.GetValue(Grid.RowProperty)) - 1), Bits(Shrt(Img2.GetValue(Grid.ColumnProperty)) - 1));
            AnyShow(HPhelper);
            ImgShow(PainImg);
        }
        //[EN] Check what is under person foot.
        //[RU] Проверить на что герой наступил.
        private void GroundCheck(in Byte Interaction)
        {
            switch (Interaction)
            {
                case 0: break;
                case 6: IhurtMyLegKit(1); break;
                case 8: IhurtMyLegKit(10); break;
                case 9: IhurtMyLegKit(25); break;
                case 104: ChangeMapToVoidOrWallX(new Byte[] { 104, 134 }, 0); ImgHide(JailImg1); Sets.EnemyRate = 5; Super1.MenuTask++; break;
                case 105: ChangeMapToVoidOrWallX(new Byte[] { 105, 135 }, 0); ImgHideX((CurrentLocation == 1) ? new Image[] { JailImg2, JailImg3 } : new Image[] { JailImg2 }); TimerOn(ref RRoll); break;
                case 106: ChangeMapToVoidOrWallX(new Byte[] { 106, 136 }, 0); ImgHide(JailImg5); if (CurrentLocation == 1) Super1.MenuTask++; break;
                case 107: ChangeMapToVoidOrWallX(new Byte[] { 107, 137 }, 0); ImgHide(JailImg6); break;
                case 108: ChangeMapToVoidOrWallX(new Byte[] { 108, 138 }, 0); ImgHide(JailImg7); break;
                case 150: if (DataBaseMSsql.CurrentLogin != "????") { SaveGame(); SEF(Path.GameSounds.ControlSave); } break;
                case 151: Super1.CurrentHP = Super1.MaxHP; Dj(Path.GameNoises.Cure2); break;
                case 152: Super1.CurrentAP = Super1.MaxAP; Dj(Path.GameNoises.ApUp); break;
                case 170: if (TRout.IsEnabled) TimerOff(ref TRout); FleeTime = new Byte[] { 2, 30 }; TimerFlees.Content = "2:30"; AnyHideX(Img2, TimerFlees, Img1); Super1.MenuTask++; MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Ending), new TimeSpan(0, 0, 0, 0, 0)); AnyShow(Skip1); HeyPlaySomething(Path.GameMusic.PutTheEnd); Img1.Source = Bmper(Path.Backgrounds.Normal); break;
                case 191: WhatsGoingOn(200); LetsBattle(); break;
                case 192: ChangeMapToVoid(192); PlayerSetLocation(1, 57); break;
                default: break;
            }
        }

        //[EN] Movement (W,A,S,D)/target select (W,A,S,D); actions on map (E); open menu (LCtrl).
        //[RU] Передвижение (W,A,S,D)/выбор цели (W,A,S,D); действия при нахождении на локации (E); открыть меню (LCtrl).
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            CheckIfInteracted();
            if (e.Key == Key.Escape) Form1.Close();
            if (e.Key == Key.P)
            {
                if (Pause.IsEnabled)
                {
                    Resume();
                    AnyHide(Pause);
                }
                else
                {
                    PauseGame();
                    AnyShow(Pause);
                }
            }
            if (Pause.IsEnabled)
                return;
            if (Img2.IsEnabled)
            {
                Sets.Rnd1 = 0;
                Sets.SelectedTarget = 0;
                if (e.Key == Key.W) Movement(true, Img2.Source.ToString().Contains(Path.Ray.GoUp1) ? Bmper(Path.Ray.GoUp2) : Bmper(Path.Ray.GoUp1), IsWayNext(MapScheme[Adoptation.ImgYbounds - 1, Adoptation.ImgXbounds]) ? Bits(Adoptation.ImgYbounds - 1) : Bits(Adoptation.ImgYbounds));
                if (e.Key == Key.A) Movement(false, Img2.Source.ToString().Contains(Path.Ray.StaticLeft) ? Bmper(Path.Ray.GoLeft) : Bmper(Path.Ray.StaticLeft), IsWayNext(MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds - 1]) ? Bits(Adoptation.ImgXbounds - 1) : Bits(Adoptation.ImgXbounds));
                if (e.Key == Key.S) Movement(true, Img2.Source.ToString().Contains(Path.Ray.GoDown1) ? Bmper(Path.Ray.GoDown2) : Bmper(Path.Ray.GoDown1), IsWayNext(MapScheme[Adoptation.ImgYbounds + 1, Adoptation.ImgXbounds]) ? Bits(Adoptation.ImgYbounds + 1) : Bits(Adoptation.ImgYbounds));
                if (e.Key == Key.D) Movement(false, Img2.Source.ToString().Contains(Path.Ray.StaticRight) ? Bmper(Path.Ray.GoRight) : Bmper(Path.Ray.StaticRight), IsWayNext(MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds + 1]) ? Bits(Adoptation.ImgXbounds + 1) : Bits(Adoptation.ImgXbounds));
                if (e.Key == Key.E)
                {
                    string[] ChestOp = { Path.MapModels.ChestOpened1, Path.MapModels.ChestOpened2, Path.MapModels.ChestOpened3 };
                    string[,] EquipmentAll = new string[,] { { Path.Msg.Knucleduster, Path.Msg.LeatherArmor, Path.Msg.FeatherWears, Path.Msg.BandageBoots }, { Path.Msg.AncientKnife, Path.Msg.AncientArmor, Path.Msg.AncientPants, Path.Msg.StrongBoots }, { Path.Msg.LegendSword, Path.Msg.LegendArmor, Path.Msg.LegendPants, Path.Msg.LegendBoots } };
                    Int32[] LocItem = new Int32[] { Img2.Source.ToString().Contains(Path.Ray.StaticDown) ? Adoptation.ImgYbounds + 1 : (Img2.Source.ToString().Contains(Path.Ray.StaticUp) ? Adoptation.ImgYbounds - 1 : Adoptation.ImgYbounds), Img2.Source.ToString().Contains(Path.Ray.StaticRight) ? Adoptation.ImgXbounds + 1 : (Img2.Source.ToString().Contains(Path.Ray.StaticLeft) ? Adoptation.ImgXbounds - 1 : Adoptation.ImgXbounds) };
                    Byte Interaction = MapScheme[LocItem[0], LocItem[1]];
                    switch (Interaction)
                    {
                        case 101: ImgGrid(TaskCompletedImg, RowMgs(KeyImg1), ColMgs(KeyImg1)); CollectKey(KeyImg1, LockImg1); ChangeMapToVoidOrWallX(new Byte[] { 101, 131 }, 0); break;
                        case 102: ImgGrid(TaskCompletedImg, RowMgs(KeyImg2), ColMgs(KeyImg2)); CollectKey(KeyImg2, LockImg2); ChangeMapToVoidOrWallX(new Byte[] { 102, 132 }, 0); break;
                        case 103: ImgGrid(TaskCompletedImg, RowMgs(KeyImg3), ColMgs(KeyImg3)); CollectKey(KeyImg3, LockImg3); ChangeMapToVoidOrWallX(new Byte[] { 103, 133 }, 0); break;
                        case 111: ImgGrid(TaskCompletedImg, RowMgs(KeyImg3), 39); PullTheLever(Lever1, new Image[] { Bridge1, Bridge2, Bridge3, Bridge4 }); ChangeMapToWall(111); ChangeMapToVoid(138); Super1.MenuTask = 8; break;
                        case 109: PullTheLever(Lever2, new Image[] { Bridge5, Bridge6 }); ChangeMapToWall(109); ChangeMapToVoid(139); break;
                        case 110: PullTheLever(Lever3, new Image[] { Bridge7, Bridge8 }); ChangeMapToWall(110); ChangeMapToVoid(140); break;
                        case 161: SomeRudeAppears(1, ref Boss1, Path.GameNoises.Horror); break;
                        case 162: SomeRudeAppears(2, ref Boss2, Path.GameNoises.EgoRage); break;
                        case 163: SomeRudeAppears(3, ref Boss3, Path.GameNoises.EgoRage); break;
                        case 201: ChestOpen(ChestImg1, Bmper(EquipmentAll[CurrentLocation, 1]), Bmper(ChestOp[CurrentLocation]), 1, CurrentLocation); break;
                        case 202: ChestOpen(ChestImg2, Bmper(EquipmentAll[CurrentLocation, 3]), Bmper(ChestOp[CurrentLocation]), 3, CurrentLocation); break;
                        case 203: ChestOpen(ChestImg3, Bmper(EquipmentAll[CurrentLocation, 0]), Bmper(ChestOp[CurrentLocation]), 0, CurrentLocation); break;
                        case 204: ChestOpen(ChestImg4, Bmper(EquipmentAll[CurrentLocation, 2]), Bmper(ChestOp[CurrentLocation]), 2, CurrentLocation); break;
                        case 205: ChestOpen(ChestImg4, Bmper(EquipmentAll[CurrentLocation, 2]), Bmper(ChestOp[CurrentLocation]), 2, CurrentLocation); break;
                        case 206: ChestOpen(ChestImg3, Bmper(EquipmentAll[CurrentLocation, 0]), Bmper(ChestOp[CurrentLocation]), 0, CurrentLocation); break;
                        case 207: ChestOpen(ChestImg2, Bmper(EquipmentAll[CurrentLocation, 3]), Bmper(ChestOp[CurrentLocation]), 3, CurrentLocation); break;
                        case 208: ChestOpen(ChestImg1, Bmper(EquipmentAll[CurrentLocation, 1]), Bmper(ChestOp[CurrentLocation]), 1, CurrentLocation); break;
                        case 209: ChestOpen(ChestImg1, Bmper(EquipmentAll[CurrentLocation, 0]), Bmper(ChestOp[CurrentLocation]), 0, CurrentLocation); break;
                        case 210: ChestOpen(ChestImg2, Bmper(EquipmentAll[CurrentLocation, 1]), Bmper(ChestOp[CurrentLocation]), 1, CurrentLocation); break;
                        case 211: ChestOpen(ChestImg3, Bmper(EquipmentAll[CurrentLocation, 2]), Bmper(ChestOp[CurrentLocation]), 2, CurrentLocation); break;
                        case 212: ChestOpen(ChestImg4, Bmper(EquipmentAll[CurrentLocation, 3]), Bmper(ChestOp[CurrentLocation]), 3, CurrentLocation); break;
                        case 213: ChestOpen(SecretChestImg1, Bmper(Path.Msg.SeriousPants), Bmper(ChestOp[CurrentLocation]), 2, 3); break;
                        case 221: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpDmg1, SpDmg2, SpDmg3, SpDmg4, SpDmg5); IhurtMyLegKit(50); break;
                        case 222: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpHrb1, SpHrb2, SpHrb3, SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8, SpHrb9, SpHrb10, SpHrb11, SpHrb12, SpHrb13, SpHrb14); if (BAG.HerbsITM < 255) BAG.HerbsITM++; break;
                        case 223: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpEtr1, SpEtr2, SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7, SpEtr8, SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14, SpEtr15, SpEtr16, SpEtr17, SpEtr18); if (BAG.Ether2ITM < 255) BAG.Ether2ITM++; break;
                        case 224: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpElx1, SpElx2, SpElx3, SpElx4, SpElx5, SpElx6); if (BAG.ElixirITM < 255) BAG.ElixirITM++; break;
                        case 225: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpSbg1, SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6, SpSbg7, SpSbg8, SpSbg9, SpSbg10, SpSbg11); if (BAG.SleepBagITM < 255) BAG.SleepBagITM++; break;
                        case 226: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpSer); BAG.Weapon[3] = true; break;
                        case 232: ChangeMapToWall(232); SecretChestImg2.Source = Bmper(ChestOp[CurrentLocation]); ImgGrid(TaskCompletedImg, RowMgs(SecretChestImg2), ColMgs(SecretChestImg2)); AnyShow(TaskCompletedImg); GetSecretReward(); break;
                        case 233: ChangeMapToVoid(Bits(LocItem[0]), Bits(LocItem[1]), SpTsk); GetSecretReward(); break;
                        default: break;
                    }
                }
                if (e.Key == Key.LeftCtrl) { AnyHideX(Img2); StatusCalculate(); AnyShow(GameMenu); }
                if (e.Key == Key.I) { Bestiary(); return; }
            }
            else if (SelectMenuFight.IsEnabled || SelectMenuSkills.IsEnabled) { if (e.Key == Key.W || e.Key == Key.A || e.Key == Key.S || e.Key == Key.D) SelectWithKeyBoard(e.Key == Key.W || e.Key == Key.A); }
            else if (e.Key == Key.LeftCtrl) { if (BestiaryImg.IsEnabled || GameMenu.IsEnabled) { HideMenus(); if (Img1.IsEnabled && !Med2.IsEnabled) AnyShow(Img2); } }
            else if (e.Key == Key.I) { if (BestiaryImg.IsEnabled || GameMenu.IsEnabled) { HideMenus(); if (Img1.IsEnabled && !Med2.IsEnabled) AnyShow(Img2); } }
            
        }

        //[EN] Menu-hide methods. + Decor-methods.
        //[RU] Методы для скрытия меню. + Методы-декораторы.
        private void HideMenus() {
            AnyHideX(BestiaryImg, GameMenu);
            MegaHide2();
        }
        private void PauseGame()
        {
            Sound1.Pause();
            if (Med1.IsEnabled) Med1.Pause();
            if (Med2.IsEnabled) Med2.Pause();
            if (Win.IsEnabled) Win.Pause();
            if (TheEnd.IsEnabled) TheEnd.Pause();
            if (ChapterIntroduction.IsEnabled) ChapterIntroduction.Pause();
            if (GameOver.IsEnabled) GameOver.Pause();
            if (!FoesFighting()) { TimerOff(ref PTurn); TimerOff(ref ETurn); }
            if (CurrentLocation==3&&!TheEnd.IsEnabled) { TimerOff(ref TRout); };
        }
        private void Resume()
        {
            Sound1.Play();
            if (Med1.IsEnabled) Med1.Play();
            if (Med2.IsEnabled) Med2.Play();
            if (Win.IsEnabled) Win.Play();
            if (TheEnd.IsEnabled) TheEnd.Play();
            if (ChapterIntroduction.IsEnabled) ChapterIntroduction.Play();
            if (GameOver.IsEnabled) GameOver.Play();
            if (!FoesFighting()) { TimerOn(ref PTurn); TimerOn(ref ETurn); }
            if (CurrentLocation == 3 && !TheEnd.IsEnabled) { TimerOn(ref TRout); };
        }
        private void MegaHide()
        {
            AnyHideX(GameStatus, GameSkills, GameItems, GameEquip, GameTasks, HelpHints, GameSettings, SwitchPanel,
                TimeRecordText, TimerFlees1, CountText,
                Task1, Task2, Task3, Task4, Task5, Task1Img, Task2Img, Task3Img, Task4Img, Task5Img,
                AntidoteText, EtherText, BandageText, FusedText, HerbsText, Ether2OutText, SleepBagText, ElixirText, Ether1, Bandage, Antidote, Fused, Herbs1, Ether2Out, SleepBag1, Elixir1,
                Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4, Equipments, CancelEq
                );
        }
        private void MegaHide2()
        {
            AnyHideX(BestiaryImg, FoeImg1, FoeAImg1, FoeDImg1, FoeGImg1, FoeSImg1, FoeAtk1, FoeDef1, FoeSpc1, FoeSpd1, FoeWkn1, FoeNam1, FoeDsc1, FoeImg2, FoeAImg2, FoeDImg2, FoeGImg2, FoeSImg2, FoeAtk2, FoeDef2, FoeSpc2, FoeSpd2, FoeWkn2, FoeNam2, FoeDsc2,
            FoeImg3, FoeAImg3, FoeDImg3, FoeGImg3, FoeSImg3, FoeAtk3, FoeDef3, FoeSpc3, FoeSpd3, FoeWkn3, FoeNam3, FoeDsc3, FoeImg4, FoeAImg4, FoeDImg4, FoeGImg4, FoeSImg4, FoeAtk4, FoeDef4, FoeSpc4, FoeSpd4, FoeWkn4, FoeNam4, FoeDsc4,
            FoeImg5, FoeAImg5, FoeDImg5, FoeGImg5, FoeSImg5, FoeAtk5, FoeDef5, FoeSpc5, FoeSpd5, FoeWkn5, FoeNam5, FoeDsc5, FoeImg6, FoeAImg6, FoeDImg6, FoeGImg6, FoeSImg6, FoeAtk6, FoeDef6, FoeSpc6, FoeSpd6, FoeWkn6, FoeNam6, FoeDsc6,
            FoeImg7, FoeAImg7, FoeDImg7, FoeGImg7, FoeSImg7, FoeAtk7, FoeDef7, FoeSpc7, FoeSpd7, FoeWkn7, FoeNam7, FoeDsc7, FoeImg8, FoeAImg8, FoeDImg8, FoeGImg8, FoeSImg8, FoeAtk8, FoeDef8, FoeSpc8, FoeSpd8, FoeWkn8, FoeNam8, FoeDsc8,
            FoeImg9, FoeAImg9, FoeDImg9, FoeGImg9, FoeSImg9, FoeAtk9, FoeDef9, FoeSpc9, FoeSpd9, FoeWkn9, FoeNam9, FoeDsc9, FoeImg10, FoeAImg10, FoeDImg10, FoeGImg10, FoeSImg10, FoeAtk10, FoeDef10, FoeSpc10, FoeSpd10, FoeWkn10, FoeNam10, FoeDsc10,
            FoeImg11, FoeAImg11, FoeDImg11, FoeGImg11, FoeSImg11, FoeAtk11, FoeDef11, FoeSpc11, FoeSpd11, FoeWkn11, FoeNam11, FoeDsc11, FoeImg12, FoeAImg12, FoeDImg12, FoeGImg12, FoeSImg12, FoeAtk12, FoeDef12, FoeSpc12, FoeSpd12, FoeWkn12, FoeNam12, FoeDsc12,
            FoeImg13, FoeAImg13, FoeDImg13, FoeGImg13, FoeSImg13, FoeAtk13, FoeDef13, FoeSpc13, FoeSpd13, FoeWkn13, FoeNam13, FoeDsc13, FoeImg14, FoeAImg14, FoeDImg14, FoeGImg14, FoeSImg14, FoeAtk14, FoeDef14, FoeSpc14, FoeSpd14, FoeWkn14, FoeNam14, FoeDsc14,
            FoeImg15, FoeAImg15, FoeDImg15, FoeGImg15, FoeSImg15, FoeAtk15, FoeDef15, FoeSpc15, FoeSpd15, FoeWkn15, FoeNam15, FoeDsc15, FoeImg16, FoeAImg16, FoeDImg16, FoeGImg16, FoeSImg16, FoeAtk16, FoeDef16, FoeSpc16, FoeSpd16, FoeWkn16, FoeNam16, FoeDsc16);
        }
        private void FastTextChange(Label[] Labs, in String[] texts) { for (Byte i = 0; i < Labs.Length; i++) Labs[i].Content = texts[i]; }

        //[EN] Learn foe and bestiary mechanic.
        //[RU] Механика изучения врагов и бестиария.
        private void LearnFoe() {
            UInt16 cipher = Super1.Learned;
            Boolean[] learned = Decoder(new UInt16[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768 }, new Boolean[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }, cipher, 16);
            switch(Foe1.EnemyAppears[Sets.SelectedTarget])
            {
                case "Паук": if (!learned[0]) Super1.Learned+=1; break;
                case "Мумия" : if (!learned[1]) Super1.Learned += 2; break;
                case "Зомби" : if (!learned[2]) Super1.Learned += 4; break;
                case "Страж" : if (!learned[3]) Super1.Learned += 8; break;
                case "Стервятник" : if (!learned[4]) Super1.Learned += 16; break;
                case "Гуль" : if (!learned[5]) Super1.Learned += 32; break;
                case "Жнец" : if (!learned[6]) Super1.Learned += 64; break;
                case "Скарабей" : if (!learned[7]) Super1.Learned += 128; break;
                case "Моль-убийца" : if (!learned[8]) Super1.Learned += 256; break;
                case "Прислужник" : if (!learned[9]) Super1.Learned += 512; break;
                case "П. червь" : if (!learned[10]) Super1.Learned += 1024; break;
                case "Мастер" : if (!learned[11]) Super1.Learned += 2048; break;
                case "Фараон": if (!learned[12]) Super1.Learned += 4096; break;
                case "????": if (!learned[13]) Super1.Learned += 8192; break;
                case "Владыка": if (!learned[14]) Super1.Learned += 16384; break;
                case "Угх-зан I": if (!learned[15]) Super1.Learned += 32768; break;
                default: break;
            }
        }
        private void Bestiary()
        {
            UInt16 cipher = Super1.Learned;
            Boolean[] learned = Decoder(new UInt16[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768 }, new Boolean[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }, cipher, 16);
            AnyHide(Img2);
            AnyShow(BestiaryImg);
            AnyShowX2(learned, new object[] { FoeImg1, FoeAImg1, FoeDImg1, FoeGImg1, FoeSImg1, FoeAtk1, FoeDef1, FoeSpc1, FoeSpd1, FoeWkn1, FoeNam1, FoeDsc1 }, new object[] { FoeImg2, FoeAImg2, FoeDImg2, FoeGImg2, FoeSImg2, FoeAtk2, FoeDef2, FoeSpc2, FoeSpd2, FoeWkn2, FoeNam2, FoeDsc2 },
            new object[] { FoeImg3, FoeAImg3, FoeDImg3, FoeGImg3, FoeSImg3, FoeAtk3, FoeDef3, FoeSpc3, FoeSpd3, FoeWkn3, FoeNam3, FoeDsc3 }, new object[] { FoeImg4, FoeAImg4, FoeDImg4, FoeGImg4, FoeSImg4, FoeAtk4, FoeDef4, FoeSpc4, FoeSpd4, FoeWkn4, FoeNam4, FoeDsc4 },
            new object[] { FoeImg5, FoeAImg5, FoeDImg5, FoeGImg5, FoeSImg5, FoeAtk5, FoeDef5, FoeSpc5, FoeSpd5, FoeWkn5, FoeNam5, FoeDsc5 }, new object[] { FoeImg6, FoeAImg6, FoeDImg6, FoeGImg6, FoeSImg6, FoeAtk6, FoeDef6, FoeSpc6, FoeSpd6, FoeWkn6, FoeNam6, FoeDsc6 },
            new object[] { FoeImg7, FoeAImg7, FoeDImg7, FoeGImg7, FoeSImg7, FoeAtk7, FoeDef7, FoeSpc7, FoeSpd7, FoeWkn7, FoeNam7, FoeDsc7 }, new object[] { FoeImg8, FoeAImg8, FoeDImg8, FoeGImg8, FoeSImg8, FoeAtk8, FoeDef8, FoeSpc8, FoeSpd8, FoeWkn8, FoeNam8, FoeDsc8 },
            new object[] { FoeImg9, FoeAImg9, FoeDImg9, FoeGImg9, FoeSImg9, FoeAtk9, FoeDef9, FoeSpc9, FoeSpd9, FoeWkn9, FoeNam9, FoeDsc9 }, new object[] { FoeImg10, FoeAImg10, FoeDImg10, FoeGImg10, FoeSImg10, FoeAtk10, FoeDef10, FoeSpc10, FoeSpd10, FoeWkn10, FoeNam10, FoeDsc10 },
            new object[] { FoeImg11, FoeAImg11, FoeDImg11, FoeGImg11, FoeSImg11, FoeAtk11, FoeDef11, FoeSpc11, FoeSpd11, FoeWkn11, FoeNam11, FoeDsc11 }, new object[] { FoeImg12, FoeAImg12, FoeDImg12, FoeGImg12, FoeSImg12, FoeAtk12, FoeDef12, FoeSpc12, FoeSpd12, FoeWkn12, FoeNam12, FoeDsc12 },
            new object[] { FoeImg13, FoeAImg13, FoeDImg13, FoeGImg13, FoeSImg13, FoeAtk13, FoeDef13, FoeSpc13, FoeSpd13, FoeWkn13, FoeNam13, FoeDsc13 }, new object[] { FoeImg14, FoeAImg14, FoeDImg14, FoeGImg14, FoeSImg14, FoeAtk14, FoeDef14, FoeSpc14, FoeSpd14, FoeWkn14, FoeNam14, FoeDsc14 },
            new object[] { FoeImg15, FoeAImg15, FoeDImg15, FoeGImg15, FoeSImg15, FoeAtk15, FoeDef15, FoeSpc15, FoeSpd15, FoeWkn15, FoeNam15, FoeDsc15 }, new object[] { FoeImg16, FoeAImg16, FoeDImg16, FoeGImg16, FoeSImg16, FoeAtk16, FoeDef16, FoeSpc16, FoeSpd16, FoeWkn16, FoeNam16, FoeDsc16 });
        }
        
        //[EN] Objects interaction
        //[RU] Взаимодействие с объектами.
        private void ChestOpen(Image Chest, in BitmapImage Message, in BitmapImage ChestOpened, in Byte Class, in Byte Quality)
        {
            ImgShow(ChestMessage1);
            ChestMessage1.Source = Message;
            Chest.Source = ChestOpened;
            switch (Class)
            {
                case 0: BAG.Hands = Super1.PlayerEQ[Class] == 0; BAG.Weapon[Quality] = true; break;
                case 1: BAG.Jacket = Super1.PlayerEQ[Class] == 0; BAG.Armor[Quality] = true; break;
                case 2: BAG.Legs = Super1.PlayerEQ[Class] == 0; BAG.Pants[Quality] = true; break;
                case 3: BAG.Boots = Super1.PlayerEQ[Class] == 0; BAG.ArmBoots[Quality] = true; break;
                default: break;
            }
            SEF(Path.GameSounds.ChestOpened);
            ImgGrid(ChestMessage1, Bits(Bits(Chest.GetValue(Grid.RowProperty)) - 5), Bits(Bits(Chest.GetValue(Grid.ColumnProperty)) - 3));
        }
        private void GetSecretReward() {
            Exp += 250;
            Mat += 250;
            Super1.MiniTask = true;
            ShowAfterBattleMenu();
        }

        //[EN] Menu : Player status
        //[RU] Меню : Статус игрока
        private void StatusCalculate() { StatsMeaning(); MenuHpApExp(); }
        private void HeroStatus()
        {
            StatusCalculate();
            AnyShow(GameStatus);
            RightPanelMenuTurnON();
            if (TimerTurnOn.IsChecked.Value)
                LabHide(TimeRecordText); 
            else
                LabShow(TimeRecordText);
            if (CurrentLocation==3) AnyShow(TimerFlees1);
            PlayerSetLocation(Bits(Adoptation.ImgYbounds), Bits(Adoptation.ImgXbounds));
            Status.IsEnabled = false;
            FastTextChange(new Label[] { Describe1, Describe2 }, new String[] { Txt.Hnt.Status, Txt.Sct.Status });
            BroAreYouPro();
        }

        //[EN] Battle : Calculating methods.
        //[RU] Сражение : Методы подсчёта.
        private void EnemiesTotal(in Byte num, in string EnemyKind, in Byte CountEnemy)
        {
            switch (EnemyNamesFight[num])
            {
                case 1: BattleText3.Content = EnemyKind + ": " + CountEnemy; LabShow(BattleText3); BattleText3.Foreground = Brushes.Red; if (CountEnemy <= 0) LabHide(BattleText3); break;
                case 2: BattleText4.Content = EnemyKind + ": " + CountEnemy; LabShow(BattleText4); BattleText4.Foreground = Brushes.Red; if (CountEnemy <= 0) LabHide(BattleText4); break;
                case 3: BattleText5.Content = EnemyKind + ": " + CountEnemy; LabShow(BattleText5); BattleText5.Foreground = Brushes.Red; if (CountEnemy <= 0) LabHide(BattleText5); break;
                default: break;
            }
        }
        private void FoesCalculate(in Byte InBattle, in Byte FoeIndex, in Byte Exper, in Byte Mater, in Byte ItemDrop)
        {
            Image[] Enemies = { Img6, Img7, Img8 };
            UInt16[][] EnHP = { new UInt16[] { Foe1.Spider.EnemyMHP, Foe1.Mummy.EnemyMHP, Foe1.Zombie.EnemyMHP, Foe1.Bones.EnemyMHP, Foe1.BOSS1.EnemyMHP, Foe1.SecretBOSS1.EnemyMHP }, new UInt16[] { Foe1.Vulture.EnemyMHP, Foe1.Ghoul.EnemyMHP, Foe1.GrimReaper.EnemyMHP, Foe1.Scarab.EnemyMHP, Foe1.BOSS2.EnemyMHP }, new UInt16[] { Foe1.KillerMole.EnemyMHP, Foe1.Imp.EnemyMHP, Foe1.Worm.EnemyMHP, Foe1.Master.EnemyMHP, Foe1.BOSS3.EnemyMHP } };
            string[,] RegularEnemiesImg = new string[,] { { Path.FoesStatePath.Spider, Path.FoesStatePath.Mummy, Path.FoesStatePath.Zombie, Path.FoesStatePath.Bones }, { Path.FoesStatePath.Vulture, Path.FoesStatePath.Ghoul, Path.FoesStatePath.GrimReaper, Path.FoesStatePath.Scarab }, { Path.FoesStatePath.KillerMole, Path.FoesStatePath.Imp, Path.FoesStatePath.Worm, Path.FoesStatePath.Master } };
            for (Byte i = 0; i < Enemies.Length; i++)
                if (InBattle - 1 == i)
                {
                    Foe1.EnemyHP[i] = EnHP[CurrentLocation][FoeIndex];
                    Enemies[i].Source = Bmper(RegularEnemiesImg[CurrentLocation, FoeIndex]);
                    Foe1.EnemyAppears[i] = Txt.Foe.GetByIndexes[CurrentLocation, FoeIndex];
                    break;
                }
            Exp += Exper;
            Mat += Mater;
            switch (FoeIndex)
            {
                case 0: Sets.FoeType1Alive += 1; break;
                case 1: Sets.FoeType2Alive += 1; break;
                case 2: Sets.FoeType3Alive += 1; break;
                case 3: Sets.FoeType4Alive += 1; break;
                default: Sets.FoeType1Alive += 1; break;
            }
            Sets.ItemsDropRate[ItemDrop] += 1;
        }
        private void LabelsReturnNormal() { Label[] Enemies = { BattleText3, BattleText4, BattleText5 }; foreach (Label en in Enemies) en.Foreground = Brushes.White; }
        private void SmartEnemyLabels(in Byte Index)
        {
            List<Byte> msp = new List<byte>();
            Byte[] Mapawe = { 0, 1, 2, 3 };
            foreach (Byte i in Mapawe) if (i != Index) msp.Add(i);
            if (EnemyNamesFight[Index] == 0) EnemyNamesFight[Index] = Bits((EnemyNamesFight[msp[0]] != 1) && (EnemyNamesFight[msp[1]] != 1) && (EnemyNamesFight[msp[2]] != 1)? 1 : (EnemyNamesFight[msp[0]] != 2) && (EnemyNamesFight[msp[1]] != 2) && (EnemyNamesFight[msp[2]] != 2)? 2 : 3);
        }
        private void CalculateBattleStatus()
        {
            EnemyNamesFight = new Byte[] { 0, 0, 0, 0 };            
            if (Img2.Source.ToString().Contains(Path.Ray.GoUp1) || Img2.Source.ToString().Contains(Path.Ray.GoUp2)) Img2.Source = Bmper(Path.Ray.StaticUp);
            else if (Img2.Source.ToString().Contains(Path.Ray.GoLeft)) Img2.Source = Bmper(Path.Ray.StaticLeft);
            else if (Img2.Source.ToString().Contains(Path.Ray.GoDown1) || Img2.Source.ToString().Contains(Path.Ray.GoDown2)) Img2.Source = Bmper(Path.Ray.StaticDown);
            else if (Img2.Source.ToString().Contains(Path.Ray.GoRight)) Img2.Source = Bmper(Path.Ray.StaticRight);
            LevelText.Content = Super1.CurrentLevel < 10 ? Txt.Com.Lv + ". " + Super1.CurrentLevel : Txt.Com.Lv + "." + Super1.CurrentLevel;
            if (Sets.TableEN) ImgHide(TableMessage1);
            MaxAndWidthHPcalculate();
            MaxAndWidthAPcalculate();
            CurrentHpApCalculate();
            speed = 0;
            Lab2.Foreground = Brushes.Yellow;
            AnyShow(BattleStatus);
            AnyHideX(Threasure1, Med2, Img2, PharaohAppears, SaveProgress, JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7, Boulder1, Ancient, Warrior, FinalAppears);
            Map1ModelsAllTurnOff1();
            ChestsAndTablesAllTurnOff1();
            AnyShowX(Img3, Img4);
            Items.IsEnabled = Sets.SpecialBattle != 200;
            Button4.IsEnabled = Sets.SpecialBattle == 0;
            Abilities.IsEnabled = Super1.CurrentLevel >= 2 && Sets.SpecialBattle != 200;
            ImgGrid(Img6, 23, 2);
            AbilityBonuses[0] = 0;
            AbilityBonuses[1] = 0;
            if (AutoTurn.IsEnabled)
                BadTime();
            else
            {
                AnyShow(FightMenu);
                Time1.Value = Time1.Maximum;
            }
            HeroSetStatus(Super1.PlayerStatus);
        }
        private void SizeEnemy(Image img, in Boolean huge)
        {
            Grid.SetColumnSpan(img ?? Img6, huge ? 15 : 11);
            Grid.SetRowSpan(img ?? Img6, huge ? 15 : 11);
            ImgShrink(img ?? Img6, huge ? 480 * Adoptation.WidthAdBack : 320 * Adoptation.WidthAdBack, huge ? 390 * Adoptation.HeightAdBack : 300 * Adoptation.HeightAdBack);
        }
        private void FoesZero()
        {
            Foe1.EnemyAppears[0] = "";
            Foe1.EnemyAppears[1] = "";
            Foe1.EnemyAppears[2] = "";
            Foe1.EnemyHP[0] = 0;
            Foe1.EnemyHP[1] = 0;
            Foe1.EnemyHP[2] = 0;
        }

        //[EN] Battle : Usual.
        //[RU] Сражение : Обычное.
        private void RegularBattle()
        {
            FoesZero();
            Byte[][] Mat = { new Byte[] { Foe1.Spider.Materials, Foe1.Mummy.Materials, Foe1.Zombie.Materials, Foe1.Bones.Materials, Foe1.BOSS1.Materials, Foe1.SecretBOSS1.Materials }, new Byte[] { Foe1.Vulture.Materials, Foe1.Ghoul.Materials, Foe1.GrimReaper.Materials, Foe1.Scarab.Materials }, new Byte[] { Foe1.KillerMole.Materials, Foe1.Imp.Materials, Foe1.Worm.Materials, Foe1.Master.Materials } };
            Byte[][] XP = { new Byte[] { Foe1.Spider.Experience, Foe1.Mummy.Experience, Foe1.Zombie.Experience, Foe1.Bones.Experience, Foe1.BOSS1.Experience, Foe1.SecretBOSS1.Experience }, new Byte[] { Foe1.Vulture.Experience, Foe1.Ghoul.Experience, Foe1.GrimReaper.Experience, Foe1.Scarab.Experience }, new Byte[] { Foe1.KillerMole.Experience, Foe1.Imp.Experience, Foe1.Worm.Experience, Foe1.Master.Experience } };
            Byte[][] DrRt = { new Byte[] { Foe1.Spider.DropRate, Foe1.Mummy.DropRate, Foe1.Zombie.DropRate, Foe1.Bones.DropRate, Foe1.BOSS1.DropRate, Foe1.SecretBOSS1.DropRate }, new Byte[] { Foe1.Vulture.DropRate, Foe1.Ghoul.DropRate, Foe1.GrimReaper.DropRate, Foe1.Scarab.DropRate }, new Byte[] { Foe1.KillerMole.DropRate, Foe1.Imp.DropRate, Foe1.Worm.DropRate, Foe1.Master.DropRate } };
            string[] themes = { Path.GameMusic.FoesChase, Path.GameMusic.HandleThis, Path.GameMusic.StampSmth };
            HeyPlaySomething(themes[CurrentLocation]);
            SizeEnemy(Img6, false);
            Sets.StepsToBattle = 0;
            Byte[] LEncounter = { 5, 10, 15 }; Byte[] HEncounter = { 20, 30, 40 };
            rnd = Random1.Next((CurrentLocation < 3 ? LEncounter[CurrentLocation] : 5), (CurrentLocation < 3 ? HEncounter[CurrentLocation] : 20));

            if (Sets.SpecialBattle == 0)
            {
                Sets.Rnd1 = Random1.Next(1, 4);
                Foe1.EnemiesStillAlive = Bits(Sets.Rnd1);
                for (Byte ib = 1; ib <= Sets.Rnd1; ib++)
                {
                    Sets.Rnd2 = Random1.Next(1, Sets.EnemyRate);
                    FoesCalculate(ib, Bits(Sets.Rnd2 - 1), XP[CurrentLocation][Sets.Rnd2 - 1], Mat[CurrentLocation][Sets.Rnd2 - 1], DrRt[CurrentLocation][Sets.Rnd2 - 1]);
                    SmartEnemyLabels(Bits(Sets.Rnd2 - 1));
                }
                Byte[] FoeCount = { Sets.FoeType1Alive, Sets.FoeType2Alive, Sets.FoeType3Alive, Sets.FoeType4Alive };
                for (Byte i=0;i<FoeCount.Length;i++) EnemiesTotal(i, Foe1.EnemyName[CurrentLocation][i], FoeCount[i]);
                LabelsReturnNormal();
                switch (Sets.Rnd1)
                {
                    case 1: ImgShow(Img6); break;
                    case 2: ImgShowX(new Image[] { Img6, Img7 }); break;
                    case 3: ImgShowX(new Image[] { Img6, Img7, Img8 }); break;
                    default: ImgShow(Img6); break;
                }
            }
            CalculateBattleStatus();
            TimeEnemy();
        }

        //[EN] Battle : Boss 1 (Pharaoh).
        //[RU] Сражение : Босс 1 (Фараон).
        private void BossBattle1()
        {
            FoesZero();
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Bits(Sets.Rnd1);
            BattleText3.Content = Txt.Bos.Pharaoh +": " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "Фараон";
            Foe1.EnemyHP[0] = 500;
            Img6.Source = Bmper(Path.BossesStatePath.Pharaoh);
            ImgGrid(Img6, 18, 2);
            SizeEnemy(Img6, true);
            ImgShow(Img6);
            Exp += 125;
            Mat += 250;
            HeyPlaySomething(Path.GameMusic.LookWhoAwake);
            CalculateBattleStatus();
            TimeEnemy();
        }

        //[EN] Battle : Boss 2 (????).
        //[RU] Сражение : Босс 2 (????).
        private void BossBattle2()
        {
            FoesZero();
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Bits(Sets.Rnd1);
            BattleText3.Content = Txt.Bos.Friend + ": " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "????";
            Foe1.EnemyHP[0] = 2000;
            Img6.Source = Bmper(Path.BossesStatePath.Warrior);
            ImgGrid(Img6, 18, 2);
            SizeEnemy(Img6, true);
            ImgShow(Img6);
            Exp += 255;
            Mat += 255;
            HeyPlaySomething(Path.GameMusic.SayHello);
            CalculateBattleStatus();
            TimeEnemy();
        }

        //[EN] Battle : Boss 3 (The Lord).
        //[RU] Сражение : Босс 3 (Владыка).
        private void BossBattle3()
        {
            FoesZero();
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Bits(Sets.Rnd1);
            BattleText3.Content = Txt.Bos.AMaster+": " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "Владыка";
            Foe1.EnemyHP[0] = 10000;
            Img6.Source = Bmper(Path.BossesStatePath.MrOfAll);
            ImgGrid(Img6, 18, 2);
            SizeEnemy(Img6, true);
            ImgShow(Img6);
            Exp += 255;
            Mat += 255;
            HeyPlaySomething(Path.GameMusic.SeriousTalk);
            CalculateBattleStatus();
            TimeEnemy();
        }

        //[EN] Battle : Secret boss 1 (Ugh Zan I). + Remember true params.
        //[RU] Сражение : Секретный босс 1 (Угх Зан I). + Запоминание настоящих параметров.
        public static UInt16[] RememberHPAP = { 0, 0, 0, 0 };
        public static Byte[] RememberParams = { 0, 0, 0, 0 };
        private void SecretBossBattle1()
        {
            FoesZero();
            BtnHideX(new Button[] { Button4, Items, Abilities });
            Sets.Rnd1 = 1;
            Foe1.EnemiesStillAlive = Bits(Sets.Rnd1);
            BattleText3.Content = Txt.Bos.UghZan + ": " + Foe1.EnemiesStillAlive;
            LabShow(BattleText3);
            Foe1.EnemyAppears[0] = "Угх-зан I";
            Foe1.EnemyHP[0] = 350;
            Img6.Source = Bmper(Path.BossesStatePath.UghZan);
            ImgGrid(Img6, 18, 2);
            SizeEnemy(Img6, true);
            ImgShow(Img6);
            TimerOn(ref SSwth, new TimeSpan(0, 0, 0, 0, Bits(50 / GameSpeed.Value)));
            APtext.Content = "БР";
            NewMaximumX(200, HPbar, APbar);
            FullRecoverX(HPbar, APbar);
            Super1.CurrentHP = 200;
            Super1.CurrentAP = 200;
            Super1.MaxHP = 200;
            Super1.MaxAP = 200;
            CurrentHpApCalculate();
            Super1.Attack = 100;
            Super1.Defence = 35;
            Exp += 250;
            Mat += 500;
            HeyPlaySomething(Path.GameMusic.SeriousIsMe);
            CalculateBattleStatus();
            TimeEnemy();
        }
        private void Med2_MediaEnded(object sender, RoutedEventArgs e)
        {
            AnyHide(Img1);
            switch (Sets.SpecialBattle)
            {
                case 0: RegularBattle(); Laugh(); break;
                case 1: BossBattle1(); Laugh(); break;
                case 2: BossBattle2(); Laugh(); break;
                case 3: BossBattle3(); Laugh(); break;
                case 200: SecretBossBattle1(); Laugh(); break;
                default: Form1.Close(); break;
            }
        }

        //[EN] Battle : Person attack.
        //[RU] Сражение : Атака героя.
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Sets.SelectedTarget = Bits(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
            SelectedTrgt = Sets.SelectedTarget;
            AnyHide(FightMenu);
            AnyShow(SelectMenuFight);
            SelectTarget();
        }
        
        //[EN] Target select mech
        //[RU] Механика выбора цели.
        private void NormalTarget() { Byte[,] grRowColumn = new Byte[,] { { 23, 15, 21 }, { 2, 13, 24 } }; ImgGrid(TrgtImg, grRowColumn[0, Sets.SelectedTarget], grRowColumn[1, Sets.SelectedTarget]); SizeEnemy(TrgtImg, false); }
        private void MegaTarget() { Byte[,] grRowColumn = new Byte[,] { { 23, 15, 21 }, { 2, 13, 24 } }; ImgGrid(TrgtImg, Bits(grRowColumn[0, Sets.SelectedTarget] - 5), grRowColumn[1, Sets.SelectedTarget]); SizeEnemy(TrgtImg, true); }
        private void SelectWithKeyBoard(bool Left)
        {
            if (Left)
            {
                if (Sets.SelectedTarget > 0)
                {
                    if (Foe1.EnemyHP[1] == 0) Sets.SelectedTarget = Bits(Foe1.EnemyHP[0] != 0 ? Sets.SelectedTarget - 2 : Sets.SelectedTarget);
                    else if (Foe1.EnemyHP[0] == 0) Sets.SelectedTarget = Bits(Sets.SelectedTarget > 1 ? Sets.SelectedTarget - 1 : Sets.SelectedTarget);
                    else Sets.SelectedTarget--;
                    InfoAboutEnemies();
                }
            }
            else
                if (Sets.SelectedTarget < Sets.Rnd1 - 1)
            {
                if (Foe1.EnemyHP[1] == 0) Sets.SelectedTarget = Bits(Foe1.EnemyHP[2] != 0 ? Sets.SelectedTarget + 2 : Sets.SelectedTarget);
                else if (Foe1.EnemyHP[0] == 0) Sets.SelectedTarget = Bits(Sets.SelectedTarget < 2 ? Sets.SelectedTarget + 1 : Sets.SelectedTarget);
                else Sets.SelectedTarget++;
                InfoAboutEnemies();
            }
        }

        //[EN] Info about enemies
        //[RU] Информация по врагам.
        private void InfoAboutEnemies()
        {
            int[][] newHP = { new int[] { Foe1.Spider.EnemyMHP, Foe1.Mummy.EnemyMHP, Foe1.Zombie.EnemyMHP, Foe1.Bones.EnemyMHP, Foe1.BOSS1.EnemyMHP, Foe1.SecretBOSS1.EnemyMHP }, new int[] { Foe1.Vulture.EnemyMHP, Foe1.Ghoul.EnemyMHP, Foe1.GrimReaper.EnemyMHP, Foe1.Scarab.EnemyMHP, Foe1.BOSS2.EnemyMHP }, new int[] { Foe1.KillerMole.EnemyMHP, Foe1.Imp.EnemyMHP, Foe1.Worm.EnemyMHP, Foe1.Master.EnemyMHP, Foe1.BOSS3.EnemyMHP } };
            string[][] EnemySource = new string[][] { new string[] { Path.FoesStatePath.SpiderIcon, Path.FoesStatePath.MummyIcon, Path.FoesStatePath.ZombieIcon, Path.FoesStatePath.BonesIcon, Path.BossesStatePath.PharaohIcon, Path.BossesStatePath.UghZanIcon }, new string[] { Path.FoesStatePath.VultureIcon, Path.FoesStatePath.GhoulIcon, Path.FoesStatePath.GrimReaperIcon, Path.FoesStatePath.ScarabIcon, Path.BossesStatePath.WarriorIcon }, new string[] { Path.FoesStatePath.KillerMoleIcon, Path.FoesStatePath.ImpIcon, Path.FoesStatePath.WormIcon, Path.FoesStatePath.MasterIcon, Path.BossesStatePath.MrOfAllIcon } };
            for (int en = 0; en < Foe1.EnemyName[CurrentLocation].Length; en++)
                if (Foe1.EnemyAppears[Sets.SelectedTarget] == Foe1.EnemyName[CurrentLocation][en])
                {
                    Enemy.Content = Foe1.EnemyName[CurrentLocation][en];
                    HPenemyBar.Maximum = newHP[CurrentLocation][en];
                    HPenemyBARwidth(HPenemyBar.Maximum);
                    EnemyImg.Source = Bmper(EnemySource[CurrentLocation][en]);
                    break;
                }
            if (Sets.SpecialBattle == 0) { NormalTarget(); } else { MegaTarget(); };
            HPenemyBar.Value = Foe1.EnemyHP[Sets.SelectedTarget];
            HPenemy.Content = HPenemyBar.Value + "/" + HPenemyBar.Maximum;
            RefreshAllHP();
            AnyShow(EnemyStatus);
        }
        private void HPenemyBARwidth(in double maxHp)
        {
            if (maxHp > 3500) { HPenemyBar.Width = HPenemyBar.Maximum / 16 * Adoptation.WidthAdBack; HPenemyBar.Foreground = new SolidColorBrush(Color.FromRgb(0, 243, 255)); HPenemyBar.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 243, 255)); }
            else if (maxHp > 500) { HPenemyBar.Width = HPenemyBar.Maximum / 4 * Adoptation.WidthAdBack; HPenemyBar.Foreground = new SolidColorBrush(Color.FromRgb(14, 222, 175)); HPenemyBar.BorderBrush = new SolidColorBrush(Color.FromRgb(14, 222, 175)); }
            else { HPenemyBar.Width = HPenemyBar.Maximum * Adoptation.WidthAdBack; HPenemyBar.Foreground = new SolidColorBrush(Color.FromRgb(50, 172, 40)); HPenemyBar.BorderBrush = new SolidColorBrush(Color.FromRgb(50, 172, 40)); }
        }
        public void SelectTarget()
        {
            AnyShow(EnemyStatus);
            AnyShowX(TrgtImg);
            RefreshAllHP();
            InfoAboutEnemies();
            TimerOn(ref Targt);
        }

        //[EN] Battle : After action.
        //[RU] Сражение : Последействие.
        private void AfterAction()
        {
            BattleText3.Foreground = Brushes.White;
            BattleText4.Foreground = Brushes.White;
            BattleText5.Foreground = Brushes.White;
            if (Sets.SpecialBattle == 200) HP.Foreground = Brushes.White;
            LabHideX(new Label[] { BattleText1, BattleText2 });
            if (speed > 0)
            {
                NotLaugh();
                if (PRegn.IsEnabled) { TimerOff(ref PRegn); }
                if (PCtrl.IsEnabled) { TimerOff(ref PCtrl); }
                Sets.FoeType1Alive = 0;
                Sets.FoeType2Alive = 0;
                Sets.FoeType3Alive = 0;
                Sets.FoeType4Alive = 0;
                Foe1.EnemiesStillAlive = 0;
                Foe1.EnemyHP[0] = 0;
                Foe1.EnemyHP[1] = 0;
                Foe1.EnemyHP[2] = 0;
                Exp = 0;
                Mat = 0;
                AnyHide(BattleStatus);
                AnyHideX(BattleText2, Img3, Img4, Img6, Img7, Img8, BattleText3, BattleText4, BattleText5, BattleText6);
                ImgShowX(new Image[] { Img1, Img2, Threasure1, SaveProgress });
                CheckMapIfModelExistsX(new Byte[] { 104, 105, 105, 106, 107, 108 }, new Image[] { JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });
                speed = 0;
                if (ETurn.IsEnabled) TimerOff(ref ETurn);
                Sound1.Stop();
                ChestsAndTablesAllTurnOn1();
                if (CurrentLocation == 0) Map1EnableModels(); else if (CurrentLocation == 1) ImgShowX(new Image[] { SecretChestImg1, SecretChestImg2 });
                if (CheckMapIfModelExists(7)) ImgShow(Boulder1);
                Abilities.IsEnabled = Super1.CurrentLevel >= 2;
                string[] music = new string[] { Path.GameMusic.AncientPyramid, Path.GameMusic.WaterTemple, Path.GameMusic.LavaTemple };
                HeyPlaySomething(music[CurrentLocation]);
            }
            else
            if (Foe1.EnemiesStillAlive <= 0)
            {
                if (PRegn.IsEnabled) { TimerOff(ref PRegn); }
                if (PCtrl.IsEnabled) { TimerOff(ref PCtrl); }
                Sound1.Stop();
                SEF(Path.GameSounds.NowTheWinnerIs);
                AnyHideX(BattleText3, BattleText4, BattleText5);
                FastTextChange(new Label[] { BattleText2 }, new string[] { Txt.Com.Thres });
                AnyShowX(Img4, BattleText1, BattleText2, textOk2);
            }
            else if (Super1.CurrentHP > 0) { Time(); AnyHideX(BattleText1, BattleText2); }
        }

        //[EN] Battle : Person defence.
        //[RU] Сражение : Защита героя.
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Super1.DefenseState = 2;
            AnyHide(FightMenu);
            Time1.Value = 0;
            HP.Foreground = Brushes.White;
            if (Sets.SpecialBattle == 200)
            {
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Path.PersonStatePath.Serious), Bmper(Path.IconStatePath.Serious)));
                Super1.SetCurrentHpAp(Shrt(Super1.CurrentHP + 40 < Super1.MaxHP ? Super1.CurrentHP + 40 : Super1.MaxHP), Shrt(Super1.CurrentAP + 20 < Super1.MaxAP ? Super1.CurrentAP + 20 : Super1.MaxAP));
                CurrentHpApCalculate();
            }
            else FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Path.PersonStatePath.Defensive), Bmper(Path.IconStatePath.Defensive)));
            Lab2.Foreground = Brushes.White;
            Dj(Path.GameNoises.StrongStand);
            Time();
        }

        //[EN] Player and foes timing.
        //[RU] Соблюдение времени игроком и врагами.
        private UInt16 TimeFormula() { return Shrt(305 - Super1.Speed); }
        private void Time()
        {
            if ((Time1.Value >= Time1.Maximum) && (Super1.CurrentHP > 0))
            {
                Super1.DefenseState = 1;
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Sets.SpecialBattle == 200 ? Path.PersonStatePath.Serious : Path.PersonStatePath.Usual), Bmper(Sets.SpecialBattle == 200 ? Path.IconStatePath.Serious : Super1.PlayerStatus == 1 ? Path.IconStatePath.Poison : Path.IconStatePath.Usual)));
                if (AutoTurn.IsEnabled && !FoesFighting())
                    BadTime();
                else
                    AnyShow(FightMenu);
                Items.IsEnabled = Sets.SpecialBattle != 200;
                Button4.IsEnabled = Sets.SpecialBattle == 0;
                Abilities.IsEnabled = Super1.CurrentLevel >= 2 && Sets.SpecialBattle != 200;
                if (Sets.SpecialBattle == 200) BtnHideX(new Button[] { Button4, Items, Abilities });
                Lab2.Foreground = Brushes.Yellow;
            }
            else TimerOn(ref PTurn);
        }
        private void TimeEnemy() { if ((Foe1.EnemyHP[0] > 0) || (Foe1.EnemyHP[1] > 0) || (Foe1.EnemyHP[2] > 0)) TimerOn(ref ETurn); }
        
        //[EN] Get necessary information from foes fast.
        //[RU] Быстрое получение нужной информации от врагов.
        private int CheckEnemies(out UInt16 EnemyAttack, Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 }, new Foe.Stats[] { Foe1.KillerMole, Foe1.Imp, Foe1.Worm, Foe1.Master, Foe1.BOSS3 } };
            EnemyAttack = 25;
            for (Byte i = 0; i < Foe1.EnemyName[CurrentLocation].Length; i++) if (Foe1.EnemyAppears[pos - 1] == Foe1.EnemyName[CurrentLocation][i]) { EnemyAttack = Shrt(FS[CurrentLocation][i].EnemyAttack + FS[CurrentLocation][i].EnemyAttack*(FS[CurrentLocation][i].EnemySpeed*0.01)); break; }
            return 25;
        }
        private int GetOut(out Byte Speed)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 }, new Foe.Stats[] { Foe1.KillerMole, Foe1.Imp, Foe1.Worm, Foe1.Master, Foe1.BOSS3 } };
            Speed = 10;
            for (Byte i = 0; i < Foe1.EnemyAppears.Length; i++) for (Byte j = 0; j < Foe1.EnemyName.Length; j++) if (Foe1.EnemyAppears[i] == Foe1.EnemyName[CurrentLocation][j]) Speed = Speed < FS[CurrentLocation][j].EnemySpeed ? FS[CurrentLocation][j].EnemySpeed : Speed;
            return Speed;
        }
        private Byte GetSpeed(in Byte trgt)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 }, new Foe.Stats[] { Foe1.KillerMole, Foe1.Imp, Foe1.Worm, Foe1.Master, Foe1.BOSS3 } };
            for (Byte i = 0; i < FS[CurrentLocation].Length; i++) if (Foe1.EnemyAppears[trgt] == Foe1.EnemyName[CurrentLocation][i]) return FS[CurrentLocation][i].EnemySpeed;
            return 10;
        }
        private UInt16 EnemyTough(Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 }, new Foe.Stats[] { Foe1.KillerMole, Foe1.Imp, Foe1.Worm, Foe1.Master, Foe1.BOSS3 } };
            for (Byte i = 0; i < Foe1.EnemyName[CurrentLocation].Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { return Shrt(FS[CurrentLocation][i].EnemyDefence + FS[CurrentLocation][i].EnemyAgility * (FS[CurrentLocation][i].EnemySpeed * 0.01)); }
            return 25;
        }
        private UInt16 EnemyAntiSkill(Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 }, new Foe.Stats[] { Foe1.KillerMole, Foe1.Imp, Foe1.Worm, Foe1.Master, Foe1.BOSS3 } };
            for (Byte i = 0; i < Foe1.EnemyName[CurrentLocation].Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { return Shrt(FS[CurrentLocation][i].EnemyAgility + FS[CurrentLocation][i].EnemySpeed); }
            return 25;
        }
        private string NameEnemies(out string enemy, Byte pos)
        {
            Foe.Stats[][] FS = new Foe.Stats[][] { new Foe.Stats[] { Foe1.Spider, Foe1.Mummy, Foe1.Zombie, Foe1.Bones, Foe1.BOSS1, Foe1.SecretBOSS1 }, new Foe.Stats[] { Foe1.Vulture, Foe1.Ghoul, Foe1.GrimReaper, Foe1.Scarab, Foe1.BOSS2 }, new Foe.Stats[] { Foe1.KillerMole, Foe1.Imp, Foe1.Worm, Foe1.Master, Foe1.BOSS3 } };
            enemy = "Паук";
            for (Byte i = 0; i < Foe1.EnemyName[CurrentLocation].Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { enemy = FS[CurrentLocation][i].EnemyName[CurrentLocation][i]; break; }
            return enemy;
        }
        private string EnemySounds(in Byte pos)
        {
            string[][] sounds = { new string[] { Path.GameSounds.SpiderDied, Path.GameSounds.MummyDied, Path.GameSounds.ZombieDied, Path.GameSounds.BonesDied, Path.GameSounds.PhaGetLost, Path.GameSounds.HereGetSome }, new string[] { Path.GameSounds.VultureDied, Path.GameSounds.GhoulDied, Path.GameSounds.GrimReaperDied, Path.GameSounds.ScarabDied, Path.GameSounds.ByeFriend }, new string[] { Path.GameSounds.KillerMoleDied, Path.GameSounds.ImpDied, Path.GameSounds.WormDied, Path.GameSounds.MasterDied, Path.GameSounds.ThisIsAll } };
            for (Byte i = 0; i < Foe1.EnemyName[CurrentLocation].Length; i++) if (Foe1.EnemyAppears[pos] == Foe1.EnemyName[CurrentLocation][i]) { return sounds[CurrentLocation][i]; }
            return Path.GameSounds.SpiderDied;
        }
        private void EnemyOnAttack(in string enemy, in UInt16 dmg)
        {
            if (Sets.SpecialBattle != 200) Super1.CurrentHP = Shrt(Super1.CurrentHP - dmg > 0? Super1.CurrentHP - dmg:0);
            else
            {
                if (Super1.CurrentAP - 10 >= 0) Super1.SetCurrentHpAp(Shrt(dmg - 10 > 0 ? (Super1.CurrentHP - dmg + 10 > 0 ? Super1.CurrentHP - (dmg - 10) : 0) : Super1.CurrentHP), Shrt(Super1.CurrentAP - 10));                
                else Super1.SetCurrentHpAp(Shrt(dmg > 0 ? (Super1.CurrentHP - dmg + Super1.CurrentAP > 0 ? Super1.CurrentHP - (dmg - Super1.CurrentAP) : 0) : 0), 0);                
                CurrentAPcalculate();
            }
            CurrentHPcalculate();
            BattleText6.Content = "-" + dmg;
            LabShow(BattleText6);
            HP.Foreground = Brushes.Red;
            if (Sets.SpecialBattle != 200)
            {
                if ((!PHurt.IsEnabled) && Img4.Source.ToString().Contains(Path.PersonStatePath.Usual)) { TimerOn(ref PHurt, new TimeSpan(0,0,0,0, Shrt(50 / GameSpeed.Value))); }
                if (!THurt.IsEnabled) { TimerOn(ref THurt, new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value))); }
                else HP.Foreground = Brushes.White;
            }
        }

        //[EN] Fast setting values
        //[RU] Быстрая установка значений.
        public void SetAnyValues(Object[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++)
            {
                if (Values[i].GetType() == typeof(String)) Properties[i] = (String)Values[i];
                if (Values[i].GetType() == typeof(Boolean)) Properties[i] = (Boolean)Values[i];
                if (Values[i].GetType() == typeof(Byte)) Properties[i] = (Byte)Values[i];
                if (Values[i].GetType() == typeof(UInt16)) Properties[i] = (UInt16)Values[i];
                if (Values[i].GetType() == typeof(Double)) Properties[i] = (Double)Values[i];
            }
        }
        public Byte[] SetAnyValues(Byte[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++) Properties[i] = (Byte)Values[i];
            return Properties;
        }
        public UInt16[] SetAnyValues(UInt16[] Properties, params Object[] Values)
        {
            for (Byte i = 0; i < Values.Length; i++) Properties[i] = (UInt16)Values[i];
            return Properties;
        }
        private UInt16 TimeFoeFormula(in Byte speed) { return Shrt(355 - speed); }
        private void BattleFoeCharges(in Byte FoeNo , ref System.Windows.Threading.DispatcherTimer SomeTimer)
        {
            string enemy;
            UInt16 EnemyAttack;
            UInt16 PlayerDef = Shrt(Super1.Defence * Super1.DefenseState + Super1.Special * Super1.Speed * 0.005 + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3] + AbilityBonuses[1]+ Sets.SeriousBonus);
            if (Foe1.EnemyHP[FoeNo] > 0)
            {
                UInt16 turn = TimeFoeFormula(GetSpeed(FoeNo));
                if (Foe1.EnemyTurn[FoeNo] >= Shrt(turn / GameSpeed.Value))
                {
                    Foe1.EnemyTurn[FoeNo] = 0;
                    CheckEnemies(out EnemyAttack, 1);
                    NameEnemies(out enemy, 1);
                    if (EnemyAttack > PlayerDef)
                    {
                        UInt16 dmg = Shrt(EnemyAttack - PlayerDef);
                        TimerOn(ref SomeTimer, new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)));
                        EnemyOnAttack(enemy, dmg);
                        Super1.PlayerStatus = Bits((Random1.Next(1, 13) == 7) && (Super1.PlayerStatus != 1) && ((Foe1.EnemyAppears[FoeNo] == "Паук") && (Foe1.EnemyAppears[FoeNo] == "Моль-убийца")) ? 1 : 0);
                        if (Sets.SpecialBattle != 200)
                            HeroSetStatus(Super1.PlayerStatus);
                    }
                }
                else Foe1.EnemyTurn[FoeNo] += 1;
                    
            }
        }
        private void Skip1_Click(object sender, RoutedEventArgs e) {
            AnyHide(Skip1);
            MediaElement[] media = { Med1, TheEnd };
            foreach(MediaElement med in media)            
                if (med.IsEnabled)
                {
                    med.Stop();
                    med.RaiseEvent(new RoutedEventArgs(MediaElement.MediaEndedEvent));
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
            Byte agl = Super1.Speed;
            AnyHide(FightMenu);
            GetOut(out byte fagl);
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            if (agl > fagl) { if (ETurn.IsEnabled) TimerOff(ref ETurn); speed = 1; }
            TimerOn(ref PFlee, new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value)));
            Dj(Path.GameNoises.FleeAway);
            LabHide(BattleText2);
        }
        
        private void BadTime()
        {
            SelectedTrgt = Sets.SelectedTarget;
            UInt16 strength = Shrt(Super1.Attack + Super1.PlayerEQ[0] + AbilityBonuses[0] + Sets.SeriousBonus + Super1.Attack * Super1.Speed / 100);
            UInt16 EnemyDefence = EnemyTough(SelectedTrgt);
            AnyHideX(EnemyStatus, SelectMenuFight, TrgtImg);
            TimerOn(ref EHurt, new TimeSpan(0, 0, 0, 0, Shrt(50 / GameSpeed.Value)));

            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;

            Foe1.EnemyHP[Sets.SelectedTarget] = Shrt(Foe1.EnemyHP[Sets.SelectedTarget] - (strength - EnemyDefence) <= 0 ? 0 : Foe1.EnemyHP[Sets.SelectedTarget] - (strength - EnemyDefence));
            if (Foe1.EnemyHP[Sets.SelectedTarget] <= 0)
            {
                string res;
                try { res = EnemySounds(Sets.SelectedTarget); }
                catch (Exception ex)
                {
                    res = Path.GameSounds.SpiderDied;
                    Reload rel = new Reload("Путь к звуку не найден. При повторном появлении cообщения cвяжитесь с администратором.", "Can't find path to sound. If problem repeat to occur contact with administrator.", ex.Message);
                    rel.ShowDialog();
                }
                SEF(res);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] <= 0)
            {
                switch (Sets.SelectedTarget)
                {
                    case 0: ImgHide(Img6); break;
                    case 1: ImgHide(Img7); break;
                    case 2: ImgHide(Img8); break;
                }
                SuperCheckFoes(Bits(Sets.SelectedTarget));
                Sets.SelectedTarget = Bits(Foe1.EnemyHP[0] > 0 ? 0 : Foe1.EnemyHP[1] > 0 ? 1 : Foe1.EnemyHP[2] > 0 ? 2 : 0);

                Byte[,] grRowColumn = new Byte[,] { { 23, 15, 21 }, { 2, 13, 24 } };
                ImgGrid(TrgtImg, grRowColumn[0, Sets.SelectedTarget], grRowColumn[1, Sets.SelectedTarget]);
                Foe1.EnemiesStillAlive = Bits(Foe1.EnemiesStillAlive - 1);
                if ((Foe1.EnemyAppears[Sets.SelectedTarget] == "Фараон") || (Foe1.EnemyAppears[Sets.SelectedTarget] == "Угх-зан I"))
                    if (Foe1.EnemiesStillAlive == 0)
                    {
                        LabHide(BattleText6);
                        BattleText6.Content = "";
                        Foe1.EnemyAppears[Sets.SelectedTarget] = "";
                    }
            }
            string[] atk = { Path.GameNoises.HandAttack, Path.GameNoises.Knife, Path.GameNoises.Sword, Path.GameNoises.Minigun };
            if (Sets.SpecialBattle != 200)
                switch (Super1.PlayerEQ[0])
                {
                    case 50: TimerOn(ref PKAtk, new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value))); Dj(atk[1]); break;
                    case 165: TimerOn(ref PMAtk, new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value))); Dj(atk[3]); break;
                    case 200: TimerOn(ref PSAtk, new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value))); Dj(atk[2]); break;
                    default: TimerOn(ref PHAtk, new TimeSpan(0, 0, 0, 0, Shrt(25 / GameSpeed.Value))); Dj(atk[0]); break;
                }
            else { TimerOn(ref SMini); Dj(atk[3]); }
        }
        //[EN] Battle : Person attack, calculate.
        //[RU] Сражение : Атака героя, подсчёт.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TimerOff(ref Targt);
            BadTime();
        }
        private bool CureOrHeal(string Power)
        {
            if (CureHealTxt.Content.ToString() != Power) CureHealTxt.Content = Power;
            Byte[] RowSet2 = { 22, 21, 20, 19, 18 };
            if (!CureHealTxt.IsEnabled) LabShow(CureHealTxt);
            if (CureCurrent == RowSet2.Length - 1)
            {
                ReturnLabs();
                return true;
            }
            else
            {
                Grid.SetRow(CureHealTxt, RowSet2[CureCurrent]);
                CureCurrent++;
            }
            return false;
        }
        private void ReturnLabs()
        {
            CureCurrent = 0;
            RAPCurrent = 0;
            AnyHideX(RecoverAPTxt, CureHealTxt);
        }
        private bool RestoreAP(string Power)
        {
            Byte[] RowSet2 = { 24, 23, 22, 21, 20 };
            if (RecoverAPTxt.Content.ToString() != Power) RecoverAPTxt.Content = Power;
            if (!RecoverAPTxt.IsEnabled) LabShow(RecoverAPTxt);
            if (RAPCurrent == RowSet2.Length - 1) { ReturnLabs(); return true; }
            else { Grid.SetRow(RecoverAPTxt, RowSet2[RAPCurrent]); RAPCurrent++; }
            return false;
        }
        private bool FoesKicked()
        {
            Byte[,] RowSet2 = new Byte[,] { { 26, 25, 26, 25, 26 }, { 18, 17, 18, 17, 18 }, { 24, 23, 24, 23, 24 } };
            Byte[,] ColumnSet2 = new Byte[,] { { 4, 3, 2, 1, 0 }, { 15, 14, 13, 12, 11 }, { 26, 25, 24, 23, 22 } };
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            if (SelectedTrgt < 3)
            {
                if (!Labs[SelectedTrgt].IsEnabled) LabShow(Labs[SelectedTrgt]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    LabHide(Labs[SelectedTrgt]);
                    return true;
                }
                else
                {
                    LabGrid(Labs[SelectedTrgt], RowSet2[SelectedTrgt, FoeDamage], ColumnSet2[SelectedTrgt, FoeDamage]);
                    FoeDamage++;
                }
            }
            else
            {
                for (Byte i = 0; i < 3; i++) if ((!Labs[i].IsEnabled) && (Foe1.EnemyHP[i] != 0)) LabShow(Labs[i]);
                if (FoeDamage == ColumnSet2.GetLength(1) - 1)
                {
                    FoeDamage = 0;
                    LabHideX(Labs);
                    return true;
                }
                else
                {
                    for (Byte i = 0; i < 3; i++) if (Foe1.EnemyHP[i] != 0) LabGrid(Labs[i], RowSet2[i, FoeDamage], ColumnSet2[i, FoeDamage]);
                    FoeDamage++;
                }
            }
            return false;
        }
        private bool ActionsTickCheck(in string[] pers, in string[] ico)
        {
            FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(pers[Actions]), Bmper(ico[Actions])));
            if (Actions == pers.Length - 1)
            {
                Actions = 0;
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Sets.SpecialBattle != 200 ? @Path.PersonStatePath.Usual : @Path.PersonStatePath.Serious),
                Bmper(Sets.SpecialBattle == 200 ? @Path.IconStatePath.Serious : Super1.PlayerStatus == 1 ? @Path.IconStatePath.Poison : @Path.IconStatePath.Usual)));
                AfterAction();
                return true;
            }
            else Actions++;
            return false;
        }
        private void UnlimitedActionsTickCheck(in string[] spec)
        {
            TrgtImg.Source = new BitmapImage(new Uri(spec[trgt], UriKind.RelativeOrAbsolute));
            trgt = Bits(trgt == spec.Length - 1 ? 0 : trgt+1);
        }
        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            if (Targt.IsEnabled) TimerOff(ref Targt);
            AnyHideX(EnemyStatus, SelectMenuFight, TrgtImg);
            AnyShow(FightMenu);
            Items.IsEnabled = Sets.SpecialBattle != 200;
            Button4.IsEnabled = Sets.SpecialBattle == 0;
            Abilities.IsEnabled = Super1.CurrentLevel >= 2 && Sets.SpecialBattle != 200;
            if (Sets.SpecialBattle == 200) BtnHideX(new Button[] { Button4, Items, Abilities });
        }
        private void Win_MediaEnded(object sender, RoutedEventArgs e) { WinStop(); AnyHideX(NewLevelGet, AfterHPbar, AfterHPbarOver333, AfterHPbarOver666, AfterAPbar, AfterAPbarOver333, AfterAPbarOver666, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, AfterAttackImg, AfterDefenceImg, AfterSpecialImg, AfterAgilityImg, FightResults); }
        private void WinStop()
        {
            WonOrDied();
            string[] music = new string[] { Path.GameMusic.AncientPyramid, Path.GameMusic.WaterTemple, Path.GameMusic.LavaTemple };
            CheckMapIfModelExistsX(new Byte[] { 104, 105, 105, 106, 107, 108 }, new Image[] { JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });
            if (CurrentLocation < 3) AnyShowX(ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3);
            if (CurrentLocation == 0) Map1EnableModels();
            if (CheckMapIfModelExists(7)) AnyShow(Boulder1);
            ImgShowX(new Image[] { Threasure1, Img2, SaveProgress });
            AnyShow(Img1);
            AnyHideX(Win);
            Win.Position = new TimeSpan(0, 0, 0, 0, 0);
            HeyPlaySomething(music[CurrentLocation]);
        }
        private void Map1EnableModels()
        {
            switch (Sets.LockIndex)
            {
                case 0: break;
                case 1: ImgShowX(new Image[] { KeyImg3, LockImg3 }); break;
                case 2: ImgShowX(new Image[] { KeyImg2, LockImg2, KeyImg3, LockImg3 }); break;
                case 3: Map1ModelsAllTurnOn1(); break;
                default: Map1ModelsAllTurnOn1(); break;
            }
            ChestsAndTablesAllTurnOn1();
        }
        private void Sound2_MediaEnded(object sender, RoutedEventArgs e) { Sound2.Stop(); }
        private void Win_MediaFailed(object sender, ExceptionRoutedEventArgs e) { WonOrDied(); Win.Stop(); ImgShow(Img2); }
        private void TextOk1_Click(object sender, RoutedEventArgs e)
        {
            HeroSetStatus(Super1.PlayerStatus);
            Win.Source = CurrentLocation == 2 ? Ura(Path.CutScene.PowerRanger) : CurrentLocation ==1 ? Ura(Path.CutScene.WasteTime) : Ura(Path.CutScene.Victory);
            MaterialsAdd.Content = "";
            Mat = 0;
            if (Sets.SpecialBattle == 0)
            {
                MediaShow(Win);
                AnyHideX(BattleText1, BattleText2, BattleText3, Img1);
            }
            else
            {
                ImgGrid(Img6, 18, 2);
                ImgShrink(Img6, 450 * Adoptation.WidthAdBack, 450 * Adoptation.HeightAdBack);
                LabHideX(new Label[] { BattleText1, BattleText2, BattleText3 });
                switch (Sets.SpecialBattle)
                {
                    case 1: case 2: case 3: MediaShow(TheEnd); AnyShow(Skip1); Img1.Source = Bmper(Path.Backgrounds.Normal); break;
                    case 200: MediaShow(Win); break;
                    default: MediaShow(Win); break;
                }
                Sets.SpecialBattle = 0;
            }
            AnyHideX(NewLevelGet, AfterHPbar, AfterHPbarOver333, AfterHPbarOver666, AfterAPbar, AfterAPbarOver333, AfterAPbarOver666, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, AfterAttackImg, AfterDefenceImg, AfterSpecialImg, AfterAgilityImg, FightResults);
            Sound1.Stop();
            ImgShow(Img1);
        }
        private void WonOrDied() {
            Sound1.Stop();
            AnyHideX(BattleText1, BattleText2, BattleText3, ATK, TextOk1, FightMenu, textOk2, Img3, Img4, Img6, Img7, Img8, BattleStatus);
        }
        private void FightStaticButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            BattleText2.Content = b.Tag.ToString();
            LabShow(BattleText2);
        }
        private void FightStaticButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            LabHide(BattleText2);
        }
        private void FightDynamicButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            int p = Numb(b.Tag);
            Image img = b.Content as Image;
            BitmapImage[] Btim = { Bmper(Path.BtnBefore.Fight), Bmper(Path.BtnBefore.Defence), Bmper(Path.BtnBefore.Escape), Bmper(Path.BtnBefore.Skills), Bmper(Path.BtnBefore.Bag), Bmper(Path.BtnBefore.Genocide) };
            img.Source = Btim[p];
            LabHide(BattleText2);
        }
        private void FightDynamicButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            int p = Numb(b.Tag);
            Image img = b.Content as Image;
            BitmapImage[] Btim = { Bmper(Path.BtnAfter.Fight), Bmper(Path.BtnAfter.Defence), Bmper(Path.BtnAfter.Escape), Bmper(Path.BtnAfter.Skills),Bmper(Path.BtnAfter.Bag), Bmper(Path.BtnAfter.Genocide) };
            String[] text = { Txt.Fht.Atk, Txt.Fht.Def, Txt.Fht.Esc, Txt.Fht.Inv, Txt.Fht.Act, Txt.Fht.Gen };
            img.Source = Btim[p];
            BattleText2.Content = text[p];
            LabShow(BattleText2);
        }
        private void SelectDynamicButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = ((Button)sender).Content as Image;
            img.Source = Bmper(Path.BtnAfter.Select);
            BattleText2.Content = ((Button)sender).Tag.ToString();
            LabShow(BattleText2);
        }
        private void SelectDynamicButtons_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = ((Button)sender).Content as Image;
            img.Source = Bmper(Path.BtnBefore.Select);
            LabHide(BattleText2);
        }
        private void HideFightIconPersActions() {
            AnyHideX(EnemyStatus, BattleText4, BattleText5, BattleText6, ItemsMenu, Img4, TrgtImg, SkillsMenu, FightMenu, SelectMenuFight, SelectMenuSkills);
        }
        private void GameOver_MediaEnded(object sender, RoutedEventArgs e)
        {
            Reload.Reloading();
            Form1.Close();
        }
        public static Byte[] AbilityBonuses = new Byte[] { 0, 0, 0, 0 };
        private void Back1_Click(object sender, RoutedEventArgs e) {
            AnyHide(SkillsMenu);
            AnyShow(FightMenu);
            Items.IsEnabled = Sets.SpecialBattle != 200;
            Button4.IsEnabled = Sets.SpecialBattle == 0;
            Abilities.IsEnabled = Super1.CurrentLevel >= 2 && Sets.SpecialBattle != 200;
        }
        private void Cure_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 5)
            {
                TimerOn(ref Pure1, Shrt(25 / GameSpeed.Value));
                TimerOn(ref PCure, Shrt(75 / GameSpeed.Value));
                Dj(Path.GameNoises.Cure);
                Super1.SetCurrentHpAp(Shrt(Super1.Special * 2 + Super1.CurrentHP >= Super1.MaxHP ? Super1.MaxHP : Super1.CurrentHP + Super1.Special * 2), Shrt(Super1.CurrentAP - 5));
                CurrentHpApCalculate();
                AnyHide(SkillsMenu);
                Time1.Value = 0;
            }
        }
        private void Abilities_Click(object sender, RoutedEventArgs e)
        {
            Button[][] pages = { new Button[] { Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control }, new Button[] { Torch, Whip, Thrower, Super, Tornado, Quake, Learn } };
            Byte[][] levels = { new Byte[] { 2, 21, 4, 16, 14, 20, 25 }, new Byte[] { 3, 6, 11, 7, 13, 18, 5 } };
            Byte[][] apcost = { new Byte[] { 5, 10, 3, 12, 8, 15, 0 }, new Byte[] { 4, 6, 15, 10, 20, 30, 2 } };
            int i = Bits(SwitchAbils.Tag);
            CheckAccessAbilities(pages[i], levels[i], apcost[i]);
            AnyShow(SkillsMenu);
            Control.IsEnabled = !PCtrl.IsEnabled;
            Regen.IsEnabled = !PRegn.IsEnabled;
            FastEnableDisableBtn(new Boolean[] { AbilityBonuses[0] <= 0, AbilityBonuses[1] <= 0 }, BuffUp, ToughenUp);
            AnyHide(FightMenu);
        }
        private void LevelUpShow()
        {
            AnyShowX(NewLevelGet, AfterParams, AfterHPtxt, AfterAPtxt, AfterHP, AfterAP, AfterAttack, AfterDefence, AfterAgility, AfterSpecial, AfterATK, AfterDEF, AfterAG, AfterSP, AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, AfterAttackImg, AfterDefenceImg, AfterAgilityImg, AfterSpecialImg);
            if (AfterAPbar.Width < 333) BarShow(AfterAPbar); else BarShowX(AfterAPbarOver333.Width < 333 ? new ProgressBar[] { AfterAPbar, AfterAPbarOver333 } : new ProgressBar[] { AfterAPbar, AfterAPbarOver333, AfterAPbarOver666 });
            if (AfterHPbar.Width < 333) BarShow(AfterHPbar); else BarShowX(AfterHPbarOver333.Width < 333? new ProgressBar[] { AfterHPbar, AfterHPbarOver333 } : new ProgressBar[] { AfterHPbar, AfterHPbarOver333, AfterHPbarOver666 });
        }
        private void CustomAddStat(in Byte StatNo, in Byte Stat, Label AddPlus, Label Added)
        {
            if (CurrentNextParams[StatNo] < Stat) { CurrentNextParams[StatNo]++; FastTextChange(new Label[] { AddPlus, Added }, new string[] { "+" + (Stat - CurrentNextParams[StatNo]), CurrentNextParams[StatNo].ToString() }); }
            else LabHide(AddPlus);
        }
        private void RecursiveLevelUp(UInt16 cnt)
        {
            Super1.CurrentLevel = Super1.CurrentLevel < 25 ? Bits(Super1.CurrentLevel + 1) : Bits(25);
            Super1.SetStats(Bits(Super1.CurrentLevel - 1));
            Time1.Maximum = TimeFormula();

            cnt = Shrt(cnt - (NextExpBar.Maximum - Super1.Experience));
            Super1.Experience = 0;
            NextExpBar.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
            NextExpBar.Value = 0;
            FastTextChange(new Label[] { AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP, ExpText, AfterLevel }, new string[] { "+" + (Super1.MaxHP - CurrentNextHPAP[0]), "+" + (Super1.MaxAP - CurrentNextHPAP[1]), "+" + (Super1.Attack - CurrentNextParams[0]), "+" + (Super1.Defence - CurrentNextParams[1]), "+" + (Super1.Speed - CurrentNextParams[2]), "+" + (Super1.Special - CurrentNextParams[3]), Txt.Com.Exp + " " + NextExpBar.Value + "/" + NextExpBar.Maximum, Txt.Com.Lv + " " + Super1.CurrentLevel });

            NewLevelGet.Content = LevelUpCount > 1 ? Txt.Com.NewLv + " X" + LevelUpCount : Txt.Com.NewLv;
            LevelUpCount += 1;
            if ((cnt >= NextExpBar.Maximum)&&Super1.CurrentLevel<25) RecursiveLevelUp(cnt);
            AfterIcon.Source = Bmper(Path.IconStatePath.LevelUp);
        }
        
        public static Byte LevelUpCount = 1;
        public static Byte[] CurrentNextParams = new Byte[] { 25, 15, 15, 25 };
        public static UInt16[] CurrentNextHPAP = new UInt16[] { 100, 40 };
        private void textOk2_Click(object sender, RoutedEventArgs e)
        {
            NotLaugh();
            ItemsGetSlot1.Content = "";
            if (Sets.SpecialBattle == 200)
            {
                APtext.Content = "ОД";
                Super1.SetStats(Bits(Super1.CurrentLevel-1));
                Super1.SetCurrentHpAp(Super1.MaxHPNxt[Super1.CurrentLevel - 1], Super1.MaxAPNxt[Super1.CurrentLevel - 1]);
                RefreshAllHPAP();
                Sets.SpecialBattle = 0;
                FastImgChange(new Image[] { Img4, Img5 }, BmpersToX(Bmper(Path.PersonStatePath.Usual), Bmper(Super1.PlayerStatus == 1 ? Path.IconStatePath.Poison : Path.IconStatePath.Usual)));
                BAG.Armor[3] = true;
                BAG.Jacket = Super1.PlayerEQ[1] == 0;
                ItemsGetSlot1.Content += Txt.Eqp.Tors.Serious+" \n";
                Super1.MiniTask = true;
                AnyShowX(Button4, Items, Abilities);
                LabShow(ItemsGetSlot1);
            }
            AnyHideX(BattleStatus, BattleText1, BattleText2, BattleText3, BattleText4, BattleText5, BattleText6, textOk2);
            ShowAfterBattleMenu();
            WonOrDied();
        }
        private void GoldBar(ProgressBar bar, in UInt16 val) { bar.Value = val; }
        private void GoldBarX(in UInt16[] val, params ProgressBar[] bar) { for (Byte i=0;i<val.Length;i++) GoldBar(bar[i], val[i]); }
        private void ShowAfterBattleMenu()
        {
            NewMaximumX(new UInt16[] { Super1.MaxHP, Shrt(Super1.MaxHP - 333 >= 1 ? Super1.MaxHP - 333 : 1), Shrt(Super1.MaxHP - 666 >= 1 ? Super1.MaxHP - 666 : 1) }, BeforeHPbar, BeforeHPbarOver333, BeforeHPbarOver666);
            NewMaximumX(new UInt16[] { Super1.MaxHP, Shrt(Super1.MaxHP - 333 >= 1 ? Super1.MaxHP - 333 : 1), Shrt(Super1.MaxHP - 666 >= 1 ? Super1.MaxHP - 666 : 1) }, AfterHPbar, AfterHPbarOver333, AfterHPbarOver666);
            NewMaximumX(new UInt16[] { Super1.MaxAP, Shrt(Super1.MaxAP - 333 >= 1 ? Super1.MaxAP - 333 : 1), Shrt(Super1.MaxAP - 666 >= 1 ? Super1.MaxAP - 666 : 1) }, BeforeAPbar, BeforeAPbarOver333, BeforeAPbarOver666);
            NewMaximumX(new UInt16[] { Super1.MaxAP, Shrt(Super1.MaxAP - 333 >= 1 ? Super1.MaxAP - 333 : 1), Shrt(Super1.MaxAP - 666 >= 1 ? Super1.MaxAP - 666 : 1) }, AfterAPbar, AfterAPbarOver333, AfterAPbarOver666);
            GoldBarX(new UInt16[] { Super1.CurrentHP, Shrt(Super1.CurrentHP - 333 >= 1 ? Super1.CurrentHP - 333 : 1), Shrt(Super1.CurrentHP - 666 >= 1 ? Super1.CurrentHP - 666 : 1) }, BeforeHPbar, BeforeHPbarOver333, BeforeHPbarOver666);
            GoldBarX(new UInt16[] { Super1.CurrentHP, Shrt(Super1.CurrentHP - 333 >= 1 ? Super1.CurrentHP - 333 : 1), Shrt(Super1.CurrentHP - 666 >= 1 ? Super1.CurrentHP - 666 : 1) }, AfterHPbar, AfterHPbarOver333, AfterHPbarOver666);
            GoldBarX(new UInt16[] { Super1.CurrentAP, Shrt(Super1.CurrentAP - 333 >= 1 ? Super1.CurrentAP - 333 : 1), Shrt(Super1.CurrentAP - 666 >= 1 ? Super1.CurrentAP - 666 : 1) }, BeforeAPbar, BeforeAPbarOver333, BeforeAPbarOver666);
            GoldBarX(new UInt16[] { Super1.CurrentAP, Shrt(Super1.CurrentAP - 333 >= 1 ? Super1.CurrentAP - 333 : 1), Shrt(Super1.CurrentAP - 666 >= 1 ? Super1.CurrentAP - 666 : 1) }, AfterAPbar, AfterAPbarOver333, AfterAPbarOver666);
            LevelUpCount = 1;
            CurrentNextParams = SetAnyValues(CurrentNextParams, Super1.Attack, Super1.Defence, Super1.Speed, Super1.Special);
            CurrentNextHPAP = SetAnyValues(CurrentNextHPAP, Super1.MaxHP, Super1.MaxAP);
            FastTextChange(new Label[] { BeforeATK, BeforeDEF, BeforeAG, BeforeSP, BeforeHP, BeforeAP, AfterATK, AfterDEF, AfterAG, AfterSP, AfterHP, AfterAP }, new string[] { Convert.ToString(CurrentNextParams[0]), Convert.ToString(CurrentNextParams[1]), Convert.ToString(CurrentNextParams[2]), Convert.ToString(CurrentNextParams[3]), Super1.CurrentHP + "/" + CurrentNextHPAP[0], Super1.CurrentAP + "/" + CurrentNextHPAP[1], Convert.ToString(CurrentNextParams[0]), Convert.ToString(CurrentNextParams[1]), Convert.ToString(CurrentNextParams[2]), Convert.ToString(CurrentNextParams[3]), Super1.CurrentHP + "/" + CurrentNextHPAP[0], Super1.CurrentAP + "/" + CurrentNextHPAP[1] });
            if (Super1.MaxHP < 333)
            {
                NewMaximumX(CurrentNextHPAP[0], BeforeHPbar, AfterHPbar);
                SetAnyValues(new object[] { HPbarOver333.Value, HPbarOver666.Value }, 0, 0);
            }
            else
            {
                NewMaximumX(Super1.MaxHP - 333 < 333 ? new UInt16[] { 333, 333, Shrt(CurrentNextHPAP[0] - 333), Shrt(CurrentNextHPAP[0] - 333) } : new UInt16[] { 333, 333, 333, 333, Shrt(CurrentNextHPAP[0] - 666), Shrt(CurrentNextHPAP[0] - 666) }, Super1.MaxHP - 333 < 333 ? new ProgressBar[] { BeforeHPbar, AfterHPbar, BeforeHPbarOver333, AfterHPbarOver333 } : new ProgressBar[] { BeforeHPbar, AfterHPbar, BeforeHPbarOver333, AfterHPbarOver333, BeforeHPbarOver666, AfterHPbarOver666 });
                BarShowX(Super1.MaxHP - 333 < 333 ? new ProgressBar[] { BeforeHPbarOver333 } : new ProgressBar[] { BeforeHPbarOver333, BeforeHPbarOver666 });
                HPbarOver666.Value = (Super1.MaxHP - 333 < 333 ? 0 : HPbarOver666.Value);
            }
            if (APbar.Maximum < 333)
            {
                NewMaximumX(CurrentNextHPAP[1], BeforeAPbar, AfterAPbar);
                SetAnyValues(new object[] { APbarOver333.Value, APbarOver666.Value }, 0, 0);
            }
            else
            {
                NewMaximumX(Super1.MaxAP - 333 < 333 ? new UInt16[] { 333, 333, Shrt(CurrentNextHPAP[1] - 333), Shrt(CurrentNextHPAP[1] - 333) } : new UInt16[] { 333, 333, 333, 333, Shrt(CurrentNextHPAP[1] - 666), Shrt(CurrentNextHPAP[1] - 666) }, Super1.MaxAP - 333 < 333 ? new ProgressBar[] { BeforeAPbar, AfterAPbar, BeforeAPbarOver333, AfterAPbarOver333 } : new ProgressBar[] { BeforeAPbar, AfterAPbar, BeforeAPbarOver333, AfterAPbarOver333, BeforeAPbarOver666, AfterAPbarOver666 });
                BarShowX(Super1.MaxAP - 333 < 333 ? new ProgressBar[] { BeforeAPbarOver333 } : new ProgressBar[] { BeforeAPbarOver333, BeforeAPbarOver666 });
                APbarOver666.Value = Super1.MaxAP - 333 < 333 ? 0 : APbarOver666.Value;
            }
            SetAnyValues(new object[] { BeforeHPbar.Value, AfterHPbar.Value, BeforeHPbarOver333.Value, AfterHPbarOver333.Value, BeforeHPbarOver666.Value, AfterHPbarOver666.Value, BeforeAPbar.Value, AfterAPbar.Value, BeforeAPbarOver333.Value, AfterAPbarOver333.Value, BeforeAPbarOver666.Value, AfterAPbarOver666.Value }, new object[] { HPbar.Value, HPbar.Value, HPbarOver333.Value, HPbarOver333.Value, HPbarOver666.Value, HPbarOver666.Value, APbar.Value, APbar.Value, APbarOver333.Value, APbarOver333.Value, APbarOver666.Value, APbarOver666.Value });
            FastTextChange(new Label[] { MaterialsOnHand, MaterialsAdd, AfterLevel }, new string[] { "" + BAG.Materials, "+" + Mat, Txt.Com.Lv + " " + Super1.CurrentLevel });

            AnyShow(FightResults);
            ItemsGetSlot1.Content = "";
            TimerOn(ref NLevl);
            TimerOn(ref AMats);
            RefreshAllHPAP();
            if (ETurn.IsEnabled) TimerOff(ref ETurn);
            BAG.AntidoteITM = ItemsGetAfterFight(0, BAG.AntidoteITM);
            BAG.BandageITM = ItemsGetAfterFight(1, BAG.BandageITM);
            BAG.EtherITM = ItemsGetAfterFight(2, BAG.EtherITM);
            BAG.FusedITM = ItemsGetAfterFight(3, BAG.FusedITM);
            BAG.HerbsITM = ItemsGetAfterFight(4, BAG.HerbsITM);
            BAG.Ether2ITM = ItemsGetAfterFight(5, BAG.Ether2ITM);
            BAG.SleepBagITM = ItemsGetAfterFight(6, BAG.SleepBagITM);
            BAG.ElixirITM = ItemsGetAfterFight(7, BAG.ElixirITM);
            BroAreYouPro();
        }
        private void BroAreYouPro() { if (Super1.CurrentLevel >= 25) { ExpBar1.Value = ExpBar1.Maximum = NextExpBar.Value = NextExpBar.Maximum; Exp1.Content = ExpText.Content = Txt.Com.Expert; } }
        private Byte ItemsGetAfterFight(in Byte ItemNo, Byte Value)
        {
            Byte item = 0;
            String[] ItemNames = { "Антидот", "Бинт", "Эфир", "Смесь", "Целебные травы", "Бутыль эфира", "Спальный мешок", "Эликсир" };
            if (Sets.ItemsDropRate[ItemNo] != 0)
                while (Sets.ItemsDropRate[ItemNo] != 0)
                {
                    item = Bits(Random1.Next(0, 8) == 4 ? item + 1 : item);
                    Sets.ItemsDropRate[ItemNo]--;
                }
            if (item > 0)
            {
                ItemsGetSlot1.Content += ItemNames[ItemNo] +": " + item + "\n";
                Value = Bits(Value + item < 255 ? Value + item : 255);
            }
            return Value;
        }
        private void Torch_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 4)
            {
                Sets.SelectedTarget = Bits(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
                SelectedTrgt = Sets.SelectedTarget;
                SelectTarget();
                AnyHide(SkillsMenu);
                AnyShowX(ACT1, SelectMenuSkills);
            }
        }

        private void Cancel2_Click(object sender, RoutedEventArgs e)
        {
            if (Targt.IsEnabled) TimerOff(ref Targt);
            AnyHideX(EnemyStatus, TrgtImg, SelectMenuSkills, ACT1, ACT2, ACT3, ACT4);
            AnyShow(SkillsMenu);
        }
        private void ACT(in Byte a1)
        {
            string[] EnemyNames = { "Паук", "Мумия", "Зомби", "Страж", "Стервятник", "Гуль", "Жнец", "Скарабей", "Моль-убийца", "Прислужник", "П. червь", "Мастер"  };
            UInt16 strength = a1 switch
            {
                0 => Shrt(Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[0] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[1] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[5] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[6] ? Super1.Special * 2.5 : Super1.Special * 1.25),
                1 => Shrt(Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[2] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[3] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[7] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[9] ? Super1.Special * 3 : Super1.Special * 1.5),
                2 => Shrt(Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[4] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[8] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[9] || Foe1.EnemyAppears[Sets.SelectedTarget] == EnemyNames[11] ? Super1.Special * 5 : Super1.Special * 2.5),
                _ => Super1.Special,
            };
            strength += Shrt(Super1.Special * Super1.Speed * 0.01);
            AnyHideX(EnemyStatus, SelectMenuSkills);
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Foe1.EnemyHP[Sets.SelectedTarget] = Shrt(strength > EnemyAura ? Foe1.EnemyHP[Sets.SelectedTarget] - (strength - EnemyAura) < 0 ? 0 : Foe1.EnemyHP[Sets.SelectedTarget] - (strength-EnemyAura): Foe1.EnemyHP[Sets.SelectedTarget]);
            if (Foe1.EnemyHP[Sets.SelectedTarget] <= 0)
            {
                string res;
                try { res = EnemySounds(Sets.SelectedTarget); } catch (Exception ex) {
                    res = Path.GameSounds.SpiderDied;
                    Reload rel = new Reload("Путь к звуку не найден. При повторном появлении cообщения cвяжитесь с администратором.", "Can't find path to sound. If problem repeat to occur contact with administrator.", ex.Message);
                    rel.ShowDialog();
                }
                SEF(res);
                SuperCheckFoes(Sets.SelectedTarget);
            }
            if (Foe1.EnemyHP[Sets.SelectedTarget] == 0)
            {
                Image[] Imgs = { Img6, Img7, Img8 };
                ImgHide(Imgs[Sets.SelectedTarget]);
                Sets.SelectedTarget = Bits(Foe1.EnemyHP[0] != 0? 0 : Foe1.EnemyHP[1] != 0 ? 1 : Foe1.EnemyHP[2] != 0 ? 2 : Sets.SelectedTarget);                
                Foe1.EnemiesStillAlive--;
                if (Foe1.EnemyAppears[0] == "Фараон") if (Foe1.EnemiesStillAlive == 0) LabHide(BattleText3);
            }
        }
        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 3)
            {
                HeroSetStatus(0);
                Time1.Value = 0;
                AfterStatus.Content = StatusP.Content = Txt.Com.Hlthy + " ♫";
                Super1.CurrentAP -= 3;
                CurrentAPcalculate();
                AnyHide(SkillsMenu);
                TimerOn(ref PHeal, Shrt(25 / GameSpeed.Value));
                TimerOn(ref PAtxc, Shrt(75 / GameSpeed.Value));
                Dj(Path.GameNoises.Heal);
            }
        }
        private void Whip_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 6)
            {
                Sets.SelectedTarget = Bits(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
                SelectedTrgt = Sets.SelectedTarget;
                SelectTarget();
                AnyHide(SkillsMenu);
                AnyShowX(SelectMenuSkills, ACT2);
            }
        }
        private void SuperCheckFoes(in Byte seltrg)
        {
            Byte[] FoesAlive = { Sets.FoeType1Alive, Sets.FoeType2Alive, Sets.FoeType3Alive, Sets.FoeType4Alive };
            for (Byte i = 0; i < FoesAlive.Length; i++)
                if (Foe1.EnemyAppears[seltrg] == Foe1.EnemyName[CurrentLocation][i])
                {
                    if (FoesAlive[i] - 1 <= 0) { Sets.EnemiesGetLost(i); FoesAlive[i] = 0; }
                    else
                    {
                        Sets.EnemiesGetDown(i);
                        FoesAlive[i]--;
                    }
                    EnemiesTotal(Bits(i), Foe1.EnemyName[CurrentLocation][i], FoesAlive[i]);
                    break;
                }
            Foe1.EnemyAppears[seltrg] = "";
        }
        private void AbilitySupers(in UInt16 strength)
        {
            AnyHide(SkillsMenu);
            AnyHideX(TrgtImg, SelectMenuSkills, EnemyStatus);
            SelectedTrgt = 4;
            Time1.Value = 0;
            Lab2.Foreground = Brushes.White;
            for (Byte i=0;i< Foe1.EnemyAppears.Length; i++) SupersFastCheck(strength,i);
            Sets.SelectedTarget = Bits(Foe1.EnemyHP[0] > 0 ? 0 : Foe1.EnemyHP[1] > 0? 1 : 2);
            Time1.Value = 0;
        }
        private void SupersFastCheck(in UInt16 strength, in Byte CheckIndex)
        {
            Image[] FoeImgs = { Img6, Img7, Img8 };
            UInt16 EnemyAura = EnemyAntiSkill(CheckIndex);
            if ((Foe1.EnemyHP[CheckIndex] - strength + EnemyAura <= 0) && (Foe1.EnemyAppears[CheckIndex] != ""))
            {
                Foe1.EnemyHP[CheckIndex] = 0;
                ImgHide(FoeImgs[CheckIndex]);
                if ((Sets.SpecialBattle != 1) && (Sets.SpecialBattle != 2)) SuperCheckFoes(CheckIndex);
                else { LabHide(BattleText3); Foe1.EnemyAppears[0] = ""; };
                Foe1.EnemiesStillAlive = Bits(Foe1.EnemiesStillAlive - 1 <= 0 ? 0 : Foe1.EnemiesStillAlive - 1);
                Foe1.EnemyAppears[CheckIndex] = "";
            }
            else if (Foe1.EnemyAppears[CheckIndex] != "") Foe1.EnemyHP[CheckIndex] = Shrt(strength > EnemyAura ? (Foe1.EnemyHP[CheckIndex] - strength + EnemyAura) : Foe1.EnemyHP[CheckIndex]);
        }
        private void Items_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(FightMenu);
            AnyShowX(ItemsMenu);
            CheckAccessItems(new Byte[] { BAG.AntidoteITM, BAG.FusedITM, BAG.BandageITM, BAG.EtherITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM }, new Button[] { Antidote1, Fused1, Bandage1, Ether, Herbs, Ether2, Elixir });
            Dj(Path.GameNoises.BagOpen);
        }
        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            AnyHide(ItemsMenu);
            AnyShow(FightMenu);
            Items.IsEnabled = Sets.SpecialBattle != 200;
            Button4.IsEnabled = Sets.SpecialBattle == 0;
            Abilities.IsEnabled = Super1.CurrentLevel >= 2 && Sets.SpecialBattle != 200;
            Dj(Path.GameNoises.BagClose);
        }
        private void MenuHpApExp()
        {
            HPbar1.Width = (HPbar.Width + HPbarOver333.Width + HPbarOver666.Width) * 0.65;
            HPbar1.Maximum = Super1.MaxHP;
            HPbar1.Value = Super1.CurrentHP;
            APbar1.Width = (APbar.Width + APbarOver333.Width + APbarOver666.Width) * 0.65;
            APbar1.Maximum = Super1.MaxAP;
            APbar1.Value = Super1.CurrentAP;
            NextExpBar.Value = Super1.Experience;
            ExpBar1.Width = NextExpBar.Width * 0.5;
            ExpBar1.Maximum = NextExpBar.Maximum;
            ExpBar1.Value = NextExpBar.Value;
            Exp1.Content = ExpText.Content;
            RefreshAllHPAP();
            BarColoring(HPbar1, 0);
            BarColoring(APbar1, 1);
            HeroSetStatus(Super1.PlayerStatus);
        }
        private void BarColoring(ProgressBar Bar, in Byte color)
        {
            string[,] colors = new string[,] { { "#FF3AAC28", "#FF0EDEAF", "#FF00F3FF" }, { "#FF1D25BB", "#FF5E1DBB", "#FFBB1D4F" } };
            if (Bar.Value < 333)
            {
                Bar.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 0]));
                Bar.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 0]));
            } else if (Bar.Value < 666)
            {
                Bar.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 1]));
                Bar.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 1]));
            } else
            {
                Bar.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 2]));
                Bar.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(colors[color, 2]));
            }
        }
        private void Status_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            RightPanelMenuTurnON();
            HeroStatus();
        }
        private void RightPanelMenuTurnON() { AnyShowX(Status, Abils, Items0, Equip, Tasks, Info, Settings); }
        private void CheckAccessAbilities(Button[] abils, in Byte[] lvl, in Byte[] apcost) { for (Byte i = 0; i < abils.Length; i++) if (Super1.CurrentLevel >= lvl[i]) { ButtonShow(abils[i]); abils[i].IsEnabled = Super1.CurrentAP >= apcost[i]; } }
        private void HeroAbilities()
        {
            MenuHpApExp();
            RightPanelMenuTurnON();
            AnyShowX(GameSkills);
            CheckAccessAbilities(new Button[] { Cure1, Heal1, Cure2Out, Torch1, Whip1, Thrower1, Super0, Tornado1, Quake1, Learn1, BuffUp1, ToughenUp1, Regen1, Control1 }, new Byte[] { 2, 4, 21, 3, 6, 11, 7, 13, 18, 5, 16, 14, 20, 25 }, new Byte[] { 5, 3, 10, 4, 6, 15, 10, 20, 30, 2, 12, 8, 15, 0 });
        }
        private void Abils_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            HeroAbilities();
            Abils.IsEnabled = false;
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { Txt.Hnt.Skills, Txt.Sct.Skills });
            AnyShowX(Describe2, DescribeHeader, Describe1);
        }
        private void CheckAccessItems(in Byte[] bag, Button[] btn, Label[] lab) { for (Byte i = 0; i < lab.Length; i++) if (bag[i] >= 1) { ButtonShow(btn[i]); LabShow(lab[i]); } }
        private void CheckAccessItems(in Byte[] bag, Button[] btn) { for (Byte i = 0; i < btn.Length; i++) if (bag[i] >= 1) ButtonShow(btn[i]); else ButtonHide(btn[i]); }
        private void HeroItems()
        {
            MenuHpApExp();
            RightPanelMenuTurnON();
            CheckAccessItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM }, new Button[] { Antidote, Bandage, Ether1, Fused, Herbs1, Ether2Out, SleepBag1, Elixir1 }, new Label[] { AntidoteText, BandageText, EtherText, FusedText, HerbsText, Ether2OutText, SleepBagText, ElixirText });
            FastEnableDisableBtn(new Boolean[] { MapScheme[Adoptation.ImgYbounds, Adoptation.ImgXbounds] == 150, false }, new Button[] { SleepBag1, Items0 });
            CraftSwitch.Content = "Создание";
            MaterialsCraft.Content = BAG.Materials;
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { Txt.Hnt.Items, Txt.Sct.Items });
            AnyShow(GameItems);
        }
        private void Items0_Click(object sender, RoutedEventArgs e)
        {
            MegaHide();
            HeroItems();
            Dj(Path.GameNoises.BagOpen);
        }
        private void Bandage_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void Ether1_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void Antidote_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void RefreshAllAP() { FastTextChange(new Label[] { AP, AP1 }, new string[] { Super1.CurrentAP + "/" + (Sets.SpecialBattle==200 ? 200 :Super1.MaxAP), Super1.CurrentAP + "/" + Super1.MaxAP }); }
        private void RefreshAllHP() { FastTextChange(new Label[] { HP, HP1 }, new string[] { Super1.CurrentHP + "/" + (Sets.SpecialBattle == 200 ? 200 : Super1.MaxHP), Super1.CurrentHP + "/" + Super1.MaxHP }); }
        private void RefreshAllHPAP() { RefreshAllHP(); RefreshAllAP(); }
        private void Fused_MouseLeave(object sender, MouseEventArgs e) { LabHide(CountText); }
        private void HeroEquip()
        {
            StatusCalculate();
            RightPanelMenuTurnON();
            AnyShowX(GameEquip);
            FastEnableDisableBtn(false, new Button[] { Equip, Remove1, Remove2, Remove3, Remove4, Equip1, Equip2, Equip3, Equip4 });
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { Txt.Hnt.Equip, Txt.Sct.Equip });
        }
        private void FastEnableDisableBtn(Boolean enabled, params Button[] buttons) { foreach (Button btn in buttons) btn.IsEnabled = enabled; }
        private void FastEnableDisableBtn(Boolean[] enabled, params Button[] buttons) { for (Byte i=0;i<enabled.Length;i++) buttons[i].IsEnabled = enabled[i]; }
        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            HeroEquip();
            EquipWatch();
        }
        private void CheckSeriousBonus() { Sets.SeriousBonus = Bits(((Super1.PlayerEQ[0] == 165) && (Super1.PlayerEQ[1] == 85) && (Super1.PlayerEQ[2] == 55) && (Super1.PlayerEQ[3] == 25)) ? 90 : 0); }
        private void EquipWatch()
        {
            AnyShowX(Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4);
            FastEnableDisableBtn(new Boolean[] { BAG.Hands && (Super1.PlayerEQ[0] == 0), BAG.Jacket && (Super1.PlayerEQ[1] == 0), BAG.Legs && (Super1.PlayerEQ[2] == 0), BAG.Boots && (Super1.PlayerEQ[3] == 0), !BAG.Hands && (Super1.PlayerEQ[0] != 0),!BAG.Jacket && (Super1.PlayerEQ[1] != 0),!BAG.Legs && (Super1.PlayerEQ[2] != 0),!BAG.Boots && (Super1.PlayerEQ[3] != 0) }, Equip1, Equip2, Equip3, Equip4, Remove1, Remove2, Remove3, Remove4);
        }
        private void StatsMeaning() { FastTextChange(new Label[] { Level0, ATK1, DEF1, AG1, SP1 }, new string[] { Txt.Com.Lv + ": " + Super1.CurrentLevel, Convert.ToString(Super1.Attack + Super1.PlayerEQ[0] + Sets.SeriousBonus), Convert.ToString(Super1.Defence + Super1.PlayerEQ[1] + Super1.PlayerEQ[2] + Super1.PlayerEQ[3]+Sets.SeriousBonus), Convert.ToString(Super1.Speed), Convert.ToString(Super1.Special) }); }
        private void OnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button[] buttons = { Remove1, Remove2, Remove3, Remove4 };
            Label[] labels = { EquipH, EquipB, EquipL, EquipD };
            string[] descr = { Txt.Eqp.Hand.Bare, Txt.Eqp.Tors.Bare, Txt.Eqp.Legs.Bare, Txt.Eqp.Boot.Bare };
            for (Byte i=0;i < buttons.Length; i++)
                if (sender.Equals(buttons[i]))
                {
                    Super1.PlayerEQ[i] = 0;
                    buttons[i].IsEnabled = false;
                    labels[i].Content = descr[i];
                    BAG.EquipPropertyChange(i, true);
                    break;
                }
            CheckSeriousBonus();
            StatsMeaning();
            EquipWatch();
        }
        private void OnEquip_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage[][] bitmapImages = {
                BmpersToX(Bmper(Path.BtnCustomize.Knucleduster), Bmper(Path.BtnCustomize.AncientKnife), Bmper(Path.BtnCustomize.LegendSword), Bmper(Path.BtnCustomize.SeriousMinigun)),
                BmpersToX(Bmper(Path.BtnCustomize.LeatherArmor), Bmper(Path.BtnCustomize.AncientArmor), Bmper(Path.BtnCustomize.LegendArmor), Bmper(Path.BtnCustomize.SeriousTshirt)),
                BmpersToX(Bmper(Path.BtnCustomize.FeatherWears), Bmper(Path.BtnCustomize.AncientPants), Bmper(Path.BtnCustomize.LegendPants), Bmper(Path.BtnCustomize.SeriousPants)),
                BmpersToX(Bmper(Path.BtnCustomize.BandageBoots), Bmper(Path.BtnCustomize.StrongBoots), Bmper(Path.BtnCustomize.LegendBoots), Bmper(Path.BtnCustomize.SeriousBoots))
            };
            Byte i = 0;
            Button[] EqButtons = { Equip1, Equip2, Equip3, Equip4 };
            Boolean[][] SomeEquipHave = { BAG.Weapon, BAG.Armor, BAG.Pants, BAG.ArmBoots };
            for (;i < EqButtons.Length; i++) if (sender.Equals(EqButtons[i])) break;
            Sets.EquipmentClass = i;
            if (SomeEquipHave[i][0]) ButtonShow(Equipments);
            if (SomeEquipHave[i][1]) ButtonShow(Equipments2);
            if (SomeEquipHave[i][2]) ButtonShow(Equipments3);
            if (SomeEquipHave[i][3]) ButtonShow(Equipments4);
            FastImgChange(new Image[] { EquipmentsImg, Equipments2Img, Equipments3Img, Equipments4Img }, bitmapImages[i]);
            ButtonShow(CancelEq);
        }
        private void CancelEq_Click(object sender, RoutedEventArgs e) { BtnHideX(new Button[] { Equipments, Equipments2, Equipments3, Equipments4, CancelEq }); }
        private void ShowSomeTasks(Label[] labs, Image[] imgs, in string[] texts, in string[] bmps)
        {
            AnyShowX(labs);
            AnyShowX(imgs);
            FastTextChange(labs, texts);
            FastImgChange(imgs, BmpersToX(bmps));
        }
        private void ShowSomeTasks(Label labs, Image imgs, in string texts, in string bmps)
        {
            AnyShowX(labs, imgs);
            labs.Content = texts;
            imgs.Source = Bmper(bmps);
        }
        private void RealTasks()
        {
            string[] TasksText = { Txt.Goal.T1, Txt.Goal.T2, Txt.Goal.T3, Txt.Goal.T4, Txt.Goal.T5, Txt.Goal.T6, Txt.Goal.T7, Txt.Goal.T8, Txt.Goal.T9, Txt.Goal.T10 };
            string[] uriSources = new string[] { Path.MenuImgs.UsualTask, Path.MenuImgs.Completed };
            switch (Super1.MenuTask)
            {
                case 0: ShowSomeTasks(Task1, Task1Img, TasksText[0], uriSources[0]); break;
                case 1: ShowSomeTasks(new Label[] { Task1, Task2 }, new Image[] { Task1Img, Task2Img }, new string[] { TasksText[0], TasksText[1] }, new string[] { uriSources[1], uriSources[0] }); break;
                case 2: ShowSomeTasks(new Label[] { Task1, Task2, Task3 }, new Image[] { Task1Img, Task2Img, Task3Img }, new string[] { TasksText[0], TasksText[1], TasksText[2] }, new string[] { uriSources[1], uriSources[1], uriSources[0] }); break;
                case 3: ShowSomeTasks(new Label[] { Task1, Task2, Task3, Task4 }, new Image[] { Task1Img, Task2Img, Task3Img, Task4Img }, new string[] { TasksText[0], TasksText[1], TasksText[2], TasksText[3] }, new string[] { uriSources[1], uriSources[1], uriSources[1], uriSources[0] }); break;
                case 4: ShowSomeTasks(Task1, Task1Img, TasksText[4], uriSources[0]); break;
                case 5: ShowSomeTasks(new Label[] { Task1, Task2 }, new Image[] { Task1Img, Task2Img }, new string[] { TasksText[4], TasksText[5] }, new string[] { uriSources[1], uriSources[0] }); break;
                case 6: ShowSomeTasks(new Label[] { Task1, Task2, Task3 }, new Image[] { Task1Img, Task2Img, Task3Img }, new string[] { TasksText[4], TasksText[5], TasksText[6] }, new string[] { uriSources[1], uriSources[1], uriSources[0] }); break;
                case 7: ShowSomeTasks(Task1, Task1Img, TasksText[7], uriSources[0]); break;
                case 8: ShowSomeTasks(new Label[] { Task1, Task2 }, new Image[] { Task1Img, Task2Img }, new string[] { TasksText[7], TasksText[8] }, new string[] { uriSources[1], uriSources[0] }); break;
                default: ShowSomeTasks(Task1, Task1Img, TasksText[9], uriSources[0]); break;
            }
        }
        private void MiniTasks()
        {
            string[] TasksText = { Txt.Goal.E1, Txt.Goal.E2, Txt.Goal.E3 };
            string[] uriSources = new string[] { Path.MenuImgs.ExperTask, Path.MenuImgs.Completed };
            if (CurrentLocation<3) ShowSomeTasks(Task5, Task5Img, TasksText[CurrentLocation], uriSources[Super1.MiniTask ? 1 : 0]);
        }
        private void HeroTasks()
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            AnyShow(GameTasks);
            RightPanelMenuTurnON();
            Tasks.IsEnabled = false;
            RealTasks();
            MiniTasks();
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { Txt.Hnt.Tasks, Txt.Sct.Tasks });            
        }
        private void Tasks_Click(object sender, RoutedEventArgs e) { HeroTasks(); }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (!Items0.IsEnabled) Dj(Path.GameNoises.BagClose);
            MegaHide();
            AnyShow(HelpHints);
            RightPanelMenuTurnON();
            Info.IsEnabled = false;
            Txt.Doc.InfoChange1 = 0;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { Txt.Doc.HelpInfo2[0, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo2[1, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo2[2, Txt.Doc.InfoChange1] }, new string[] { Txt.Doc.HelpInfo1[0, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo1[1, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo1[2, Txt.Doc.InfoChange1] });
            FastTextChange(new Label[] { InfoIndex, Describe1, Describe2 }, new string[] { Txt.Doc.InfoChange1 + 1 + "/19", Txt.Hnt.Infos, Txt.Sct.Infos });
            AnyShowX(SwitchPanel);
            GameHint();
        }
        private void FastInfoChange(TextBlock[] Texts, Label[] Headers, in string[] text, in string[] content) { for (Byte i = 0; i < Headers.Length; i++) { Headers[i].Content = content[i]; Texts[i].Text = text[i]; } }
        private void FastImgChange(Image[] ImageArray, BitmapImage[] bitmapImage) { for (Byte i = 0; i < ImageArray.Length; i++) ImageArray[i].Source = bitmapImage[i]; }
        private void InfoIndexPlus_Click(object sender, RoutedEventArgs e)
        {
            Txt.Doc.InfoChange1 += 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { Txt.Doc.HelpInfo2[0, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo2[1, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo2[2, Txt.Doc.InfoChange1] }, new string[] { Txt.Doc.HelpInfo1[0, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo1[1, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo1[2, Txt.Doc.InfoChange1] });
            InfoIndex.Content = (Txt.Doc.InfoChange1 + 1) + "/19";
            ButtonShow(InfoIndexMinus);
            if (Txt.Doc.InfoChange1 >= 18) ButtonHide(InfoIndexPlus);
            GameHint();
        }
        private void InfoIndexMinus_Click(object sender, RoutedEventArgs e)
        {
            Txt.Doc.InfoChange1 -= 1;
            FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 }, new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 }, new string[] { Txt.Doc.HelpInfo2[0, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo2[1, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo2[2, Txt.Doc.InfoChange1] }, new string[] { Txt.Doc.HelpInfo1[0, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo1[1, Txt.Doc.InfoChange1], Txt.Doc.HelpInfo1[2, Txt.Doc.InfoChange1] });
            InfoIndex.Content = Txt.Doc.InfoChange1 + 1 + "/19";
            ButtonShow(InfoIndexPlus);
            if (Txt.Doc.InfoChange1 <= 0) ButtonHide(InfoIndexMinus);
            GameHint();
        }
        private void TheEnd_MediaEnded(object sender, RoutedEventArgs e)
        {
            HideFightIconPersActions();
            WonOrDied();
            AnyHide(Skip1);
            switch (Super1.MenuTask)
            {
                case 3: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Fin_Chapter1), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.AncientKey); Super1.MenuTask++; Img1.Source = Bmper(Path.Backgrounds.Normal); AnyShow(Skip1); break;
                case 4: MediaShowAdvanced(ChapterIntroduction, Ura(Path.CutScene.PreChapter2), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.WaterTemple); break;
                case 6: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Fin_Chapter2), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.Conversation); Super1.MenuTask++; Img1.Source = Bmper(Path.Backgrounds.Normal); AnyShow(Skip1); break;
                case 7: MediaShowAdvanced(ChapterIntroduction, Ura(Path.CutScene.PreChapter3), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.LavaTemple); break;
                case 8: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Fin_Chapter3), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.Threasures); Super1.MenuTask++; Img1.Source = Bmper(Path.Backgrounds.Normal); AnyShow(Skip1); break;
                case 9: MediaShowAdvanced(ChapterIntroduction, Ura(Path.CutScene.PreChapter4), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.GetAway); break;
                case 10: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Titres), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.SayGoodbye); Super1.MenuTask++; break;
                default: Form1.Close(); break;
            }
        }
        private void Sound3_MediaEnded(object sender, RoutedEventArgs e) { Sound3.Stop(); Sound3.Position = new TimeSpan(0, 0, 0, 0, 0); }
        private void Win_MediaOpened(object sender, RoutedEventArgs e) { WonOrDied(); }
        private void Med1_MediaOpened(object sender, RoutedEventArgs e) { AnyHideX(Button1, Img1, Lab1, Skip1); AnyShow(Skip1); }
        private void Form1_KeyUp(object sender, KeyEventArgs e) { if (Img2.IsEnabled) Img2.Source = Bmper(e.Key == Key.W ? Path.Ray.StaticUp : e.Key == Key.A ? Path.Ray.StaticLeft : e.Key == Key.D ? Path.Ray.StaticRight : Path.Ray.StaticDown); }
        private void SwitchAbils_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int i = Bits(b.Tag);
            Button[][] pages = { new Button[] { Cure, Cure2, Heal, BuffUp, ToughenUp, Regen, Control }, new Button[] { Torch, Whip, Thrower, Super, Tornado, Quake, Learn } };
            Byte[][] levels = { new Byte[] { 2, 21, 4, 16, 14, 20, 25 }, new Byte[] { 3, 6, 11, 7, 13, 18, 5 } };
            Byte[][] apcost = { new Byte[] { 5, 10, 3, 12, 8, 15, 0 }, new Byte[] { 4, 6, 15, 10, 20, 30, 2 } };
            BtnHideX(pages[i]);
            i = (i + 1 >= pages.Length) ? 0 : i + 1;
            b.Tag = i;
            ToNextImg.Source = Bmper((i == pages.Length-1) ? Path.BtnCustomize.ArrowPrev : Path.BtnCustomize.ArrowNext);
            CheckAccessAbilities(pages[i], levels[i], apcost[i]);
            BuffUp.IsEnabled = AbilityBonuses[0] == 0;
            ToughenUp.IsEnabled = AbilityBonuses[1] == 0;
            Control.IsEnabled = !PCtrl.IsEnabled;
            Regen.IsEnabled = !PRegn.IsEnabled;
        }
        private void RemoveButtons_MouseEnter(object sender, MouseEventArgs e)
        {
            Byte[] EquipQuality = { Super1.PlayerEQ[0], Super1.PlayerEQ[1], Super1.PlayerEQ[2], Super1.PlayerEQ[3] };
            Label[] EquipLabels = { AddATK1, AddDEF1, AddDEF1, AddDEF1 };
            Button[] Buttons = { Remove1, Remove2, Remove3, Remove4 };
            for (Byte i = 0; i < EquipQuality.Length; i++)
                if (sender.Equals(Buttons[i]))
                {
                    EquipLabels[i].Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
                    EquipLabels[i].Content = "-" + EquipQuality[i];
                    LabShow(EquipLabels[i]);
                    break;
                }
        }
        private void RemoveButtons_MouseLeave(object sender, MouseEventArgs e) { LabHide(sender.Equals(Remove1) ? AddATK1 : AddDEF1); }
        private void CheckAccessMaterials(in UInt16[] bag, Button[] btn) { for (Byte i = 0; i < btn.Length; i++) if (BAG.Materials >= bag[i]) ButtonShow(btn[i]); else ButtonHide(btn[i]); }
        private void TooManyItems(in Byte[] bag, Button[] btn) { for (Byte i = 0; i < btn.Length; i++) btn[i].IsEnabled = bag[i] < 255; }
        private void FastBtnsDisable(in Boolean Logic, params Button[] buttons) { foreach (Button btn in buttons) btn.IsEnabled = Logic; }
        private void CraftSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (CraftSwitch.Content.ToString() == "Создание") {
                FastBtnsDisable(false, Bandage, Ether1, Antidote, Fused, Herbs1, Ether2Out, SleepBag1, Elixir1);
                LabHideX(new Label[] { AntidoteText, BandageText, EtherText, FusedText, HerbsText, Ether2OutText, SleepBagText, ElixirText });
                CheckAccessMaterials(new UInt16[] { 10, 20, 70, 150, 500, 1500, 100, 10000 }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused, CraftHerbs, CraftEther2, CraftBedbag, CraftElixir });
                if (!BAG.ArmBoots[3]) CheckAccessMaterials(new UInt16[] { 30000 }, new Button[] { CraftPerfboots });
                TooManyItems(new Byte[] { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM }, new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused, CraftHerbs, CraftEther2, CraftBedbag, CraftElixir });
                CraftSwitch.Content = "Сумка";
            } else
            {
                AnyHideX(CraftAntidote,CraftBandage,CraftBedbag,CraftElixir,CraftEther,CraftEther2,CraftFused,CraftHerbs,CraftPerfboots);
                HeroItems();
            }
        }
        private void AbilsMenu_Click(object sender, RoutedEventArgs e)
        {
            Button[] abils = new Button[] { Cure1, Cure2Out, Heal1, Torch1, Whip1, Thrower1, Super0, Tornado1, Quake1, Learn1, BuffUp1, ToughenUp1, Regen1, Control1 };
            string[] uris = new string[] { Path.GameNoises.Cure, Path.GameNoises.Cure2, Path.GameNoises.Heal, Path.GameNoises.Torch, Path.GameNoises.Whip, Path.GameNoises.Thrower, Path.GameNoises.Super, Path.GameNoises.Whirl, Path.GameNoises.Quake, Path.GameNoises.Learn, Path.GameNoises.PowUp, Path.GameNoises.Shield, Path.GameNoises.HpUp, Path.GameNoises.ApUp };
            for (Byte i=0;i< abils.Length; i++)
                if (sender.Equals(abils[i]))
                    Dj(uris[i]);
            if (sender.Equals(Cure1)) if (Super1.CurrentAP >= 5) { Super1.SetCurrentHpAp(Shrt(Super1.CurrentHP + Shrt(Super1.Special * 2) >= Super1.MaxHP ? Super1.MaxHP : Super1.CurrentHP + Shrt(Super1.Special * 2)), Shrt(Super1.CurrentAP - 5)); if (Super1.CurrentAP < 5) Heal1.IsEnabled = false; }
            if (sender.Equals(Cure2Out)) if (Super1.CurrentAP >= 10) { Super1.SetCurrentHpAp(Super1.MaxHP, Shrt(Super1.CurrentAP - 10)); if (Super1.CurrentAP < 10) Heal1.IsEnabled = false; }
            if (sender.Equals(Heal1)) if (Super1.CurrentAP >= 3) { HeroSetStatus(0); Super1.CurrentAP -= 3; if (Super1.CurrentAP < 3) Heal1.IsEnabled = false; }
            RefreshAllHPAP();
            MenuHpApExp();
        }

        //[EN] Game settings
        //[RU] Настройки игры.
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MegaHide();
            ChbShow(TimerTurnOn);
            HeroSettings();
        }
        private void MusicLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { Sound1.Volume = MusicLoud.Value; if (MusicPercent != null) MusicPercent.Content = Bits(Sound1.Volume * 100) + "%"; }
        private void SoundsLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound3.Volume = SoundsLoud.Value;
            if (!Button1.IsEnabled) SEF(Path.GameSounds.ChestOpened);
            if (SoundsPercent != null) SoundsPercent.Content = Bits(Sound3.Volume * 100) + "%";
        }
        private void NoiseLoud_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound2.Volume = NoiseLoud.Value;
            if (!Button1.IsEnabled) Dj(Path.GameNoises.Torch);
            if (NoisePercent != null) NoisePercent.Content = Bits(Sound2.Volume * 100) + "%";
        }
        private void GameSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { if (GameSpeedX != null) GameSpeedX.Content = "x" + Math.Round(GameSpeed.Value, 2); }
        private void Brightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { if (BrightnessPercent != null) { BrightnessImg.Opacity = 1 - Brightness.Value; BrightnessPercent.Content = Bits(Brightness.Value * 100) + "%"; } }
        private void HeroSettings()
        {
            RightPanelMenuTurnON();
            Settings.IsEnabled = false;
            AnyShow(GameSettings);
            FastTextChange(new Label[] { Describe1, Describe2 }, new string[] { Txt.Hnt.Setts, Txt.Sct.Setts });
        }
        private void TimerTurnOn_Checked(object sender, RoutedEventArgs e) { if (WRecd.IsEnabled) TimerOff(ref WRecd); }
        private void TimerTurnOn_Unchecked(object sender, RoutedEventArgs e) { if (!WRecd.IsEnabled) TimerOn(ref WRecd); }
        private void AnyEquipments_MouseLeave(object sender, MouseEventArgs e) { LabHideX(new Label[] { AddATK1, AddDEF1 }); }
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
                case 0: BAG.Hands = false; break;
                case 1: BAG.Jacket = false; break;
                case 2: BAG.Legs = false; break;
                case 3: BAG.Boots = false; break;
                default: BAG.Hands = false; break;
            }
        }
        private void ChangeTimer(ref System.Windows.Threading.DispatcherTimer timer, EventHandler SomeEvent, TimeSpan timeSpan)
        {
            timer.Tick += new EventHandler(SomeEvent);
            timer.Interval = timeSpan;
        }
        private void MediaShowAdvanced(MediaElement Media, Uri Source, TimeSpan timeSpan)
        {
            Media.Visibility = Visibility.Visible;
            Media.IsEnabled = true;
            Media.Source = Source;
            Media.Position = timeSpan;
            Media.Play();
        }
        private void CurrentPlayer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AutorizeImg.Source.ToString().Contains(Path.Backgrounds.UnRegister)) AnyHideX(AddProfile, DeleteProfile, Player1, Player2, Player3, Player4, Player5, Player6, AddPlayer); else CheckRecords();
            AutorizeImg.Source = Bmper(AutorizeImg.Source.ToString().Contains(Path.Backgrounds.UnRegister) ? Path.Backgrounds.Register : Path.Backgrounds.UnRegister);
        }
        private void AddProfile_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer.Text = (AddPlayer.Text == "Никем быть нельзя!") || (AddPlayer.Text == "Один уже есть") ? "" : AddPlayer.Text;
            if (AddPlayer.Text != "")
            {
                foreach (string str in DataBaseMSsql.PlayerLogins) if (AddPlayer.Text == str) { AddPlayer.Text = "Один уже есть"; return; }
                try
                {
                    DataBaseMSsql.NewPlayer(AddPlayer.Text);
                    DataBaseMSsql.CheckAllRecordedPlayers();
                    DataBaseMSsql.GetCurrentPlayer();
                    AnyHideX(AddPlayer, AddProfile);
                    AddPlayer.Text = "";
                    CheckRecords();
                }
                catch (Exception ex) {
                    Reload rel = new Reload("Столкнулись с проблемой подключения. Свяжитесь с администратором для решения проблемы.", "You encountered a problem of connection to database. Contact with administrator to solve this.", ex.Message);
                    rel.ShowDialog();
                    Close();
                }
            }
            else AddPlayer.Text = "Никем быть нельзя!";
        }
        private void AddPlayer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AddPlayer.Text = (AddPlayer.Text == "Никем быть нельзя!") || (AddPlayer.Text == "Один уже есть") ? "" : AddPlayer.Text;
            Regex regex = new Regex("[^0-9a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public static Byte ProfileSelected = 0;
        private void CheckRecords()
        {
            Label[] Profiles = new Label[] { Player1, Player2, Player3, Player4, Player5, Player6 };
            Byte rem = 0;
            if (DataBaseMSsql.PlayerLogins.Count < 6)
            {
                for (Byte i = 0; i <DataBaseMSsql.PlayerLogins.Count; i++)
                {
                    Profiles[i].Content = DataBaseMSsql.PlayerLogins[i];
                    LabShow(Profiles[i]);
                    BtnGrid(AddProfile, Bits(i+1), 0);
                    rem++;
                }
                Grid.SetRow(AddPlayer, rem+1);
                Grid.SetRow(AddProfile, rem+1);
                AnyShowX(AddProfile, AddPlayer);
            }
            else for (Byte i = 0; i <DataBaseMSsql.PlayerLogins.Count; i++) { Profiles[i].Content =DataBaseMSsql.PlayerLogins[i]; LabShow(Profiles[i]); }
        }
        private void OnPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Label btn = sender as Label;
            Byte select = Bits(btn.GetValue(Grid.RowProperty));
            DataBaseMSsql.CurrentLogin = DataBaseMSsql.PlayerLogins[select-1];
            CurrentPlayer.Content = DataBaseMSsql.CurrentLogin;
            BtnGrid(DeleteProfile, select, 0);
            ButtonShow(DeleteProfile);
            Continue.IsEnabled = DataBaseMSsql.CheckIfPlayerCanContinue();
            ConAdv.Source = Bmper(Continue.IsEnabled ? Path.Adv.BeforeConAdv : Path.Adv.AdventureLock);
            SeeMap();
        }
        private void Anonymous()
        {
            if (CurrentPlayer.Content.ToString() == "????") Continue.IsEnabled = false;
            ConAdv.Source = Bmper(Continue.IsEnabled ? Path.Adv.BeforeConAdv : Path.Adv.AdventureLock);
        }
        private void DeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            DataBaseMSsql.DeletePlayer(DataBaseMSsql.CurrentLogin);
            DataBaseMSsql.CheckAllRecordedPlayers();
            CurrentPlayer.Content = DataBaseMSsql.GetCurrentPlayer();
            Anonymous();
            SeeMap();
            AnyHideX(Player1, Player2, Player3, Player4, Player5, Player6, DeleteProfile);
            CheckRecords();
        }
        private void AddPlayer_MouseEnter(object sender, RoutedEventArgs e) { AddPlayer.Text = ((AddPlayer.Text == "Никем быть нельзя!") || (AddPlayer.Text == "Один уже есть")) ? "": AddPlayer.Text; }
        private void SaveGame()
        {
            try
            {
                Byte[] CipherValue = new Byte[] { 1, 2, 4, 8 };
                DataBaseMSsql.SavePlayerBag(new string[] { "@LOGIN", "@BAN", "@ETR", "@ANT", "@FUS", "@HRB", "@ER2", "@SLB", "@ELX", "@MAT" }, new Object[] { DataBaseMSsql.CurrentLogin, BAG.BandageITM, BAG.EtherITM, BAG.AntidoteITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM, BAG.Materials});
                DataBaseMSsql.SavePlayerEquip(new string[] { "@LOGIN", "@WPN", "@ARR", "@PNT", "@BOO", "@WPS", "@ARS", "@PTS", "@BTS" }, new Object[] { DataBaseMSsql.CurrentLogin, Bits(Super1.PlayerEQ[0]), Bits(Super1.PlayerEQ[1]), Bits(Super1.PlayerEQ[2]), Bits(Super1.PlayerEQ[3]), Bits(Encoder(CipherValue, BAG.Weapon, Bits(BAG.Weapon.Length))), Bits(Encoder(CipherValue, BAG.Armor, Bits(BAG.Armor.Length))), Bits(Encoder(CipherValue, BAG.Pants, Bits(BAG.Pants.Length))), Bits(Encoder(CipherValue, BAG.ArmBoots, Bits(BAG.ArmBoots.Length))) });
                DataBaseMSsql.SavePlayerSettings(new string[] { "@LOGIN", "@MUS", "@SND", "@NS", "@FS", "@BR", "@TMR" }, new Object[] { DataBaseMSsql.CurrentLogin, Bits(MusicLoud.Value * 100), Bits(SoundsLoud.Value * 100), Bits(NoiseLoud.Value * 100), Bits(GameSpeed.Value * 100), Bits(Brightness.Value * 100), TimerTurnOn.IsChecked.Value });
                DataBaseMSsql.SavePlayerStats(new string[] { "@LOGIN", "@LV", "@LC", "@HP", "@AP", "@XP", "@TK", "@LN", "@TR" }, Super1.GetPlayerRecord(DataBaseMSsql.CurrentLogin));
            }
            catch (Exception ex) {
                Reload rel = new Reload("Столкнулись с проблемой подключения. Свяжитесь с администратором для решения проблемы.", "You encountered a problem of connection to database. Contact with administrator to solve this.", ex.Message);
                rel.ShowDialog();
                Close();
            }
        }

        //[EN] Decoder-encoder methods.
        //[RU] Методы шифраторы/дешифраторы.
        private Byte Encoder(in Byte[] CipherValues, in Boolean[] ToEncode, in Byte length) { Byte Cipher = 0; for (Byte i = 0; i < length; i++) if (ToEncode[i]) Cipher += CipherValues[i]; return Cipher; }
        private Boolean[] Decoder(in Byte[] CipherValues, in Boolean[] CipherPattern, Byte Cipher, in Byte length)
        {
            for (Byte i = length; i > 0; i--)
                if (Cipher - CipherValues[i - 1] >= 0)
                {
                    Cipher -= CipherValues[i - 1];
                    CipherPattern[i - 1] = true;
                }
            return CipherPattern;
        }
        private Boolean[] Decoder(in UInt16[] CipherValues, in Boolean[] CipherPattern, UInt16 Cipher, in Byte length)
        {
            for (Byte i = length; i > 0; i--)
                if (Cipher - CipherValues[i - 1] >= 0)
                {
                    Cipher -= CipherValues[i - 1];
                    CipherPattern[i - 1] = true;
                }
            return CipherPattern;
        }
        private Boolean GetValueFromDecoder(in Boolean[] Things, in Byte If) { foreach (Boolean bl in Things) if (bl && (If == 0)) return true; return false; }

        //[EN] Continue button click.
        //[RU] Кнопка "Продолжить начатое".
        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Object[] Bag=DataBaseMSsql.CheckPlayerBag(DataBaseMSsql.CurrentLogin, new Object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            BAG.ItemsSet(Bits(Bag[0]), Bits(Bag[1]), Bits(Bag[2]), Bits(Bag[3]), Bits(Bag[4]), Bits(Bag[5]), Bits(Bag[6]), Bits(Bag[7]), Shrt(Bag[8]));

            Byte[] ByteEquip = DataBaseMSsql.CheckPlayerEquip(DataBaseMSsql.CurrentLogin, new Byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            Super1.SetAllEquip(ByteEquip[0], ByteEquip[1], ByteEquip[2], ByteEquip[3]);
            Byte[] Ciphers = { ByteEquip[4], ByteEquip[5], ByteEquip[6], ByteEquip[7] };

            Bag = DataBaseMSsql.GetPlayerRecord(DataBaseMSsql.CurrentLogin, new Object[] { 0, 0, 0, 0, 0, 0, 0 });
            Super1.CurrentLevel = Bits(Bag[0]);
            Super1.MenuTask= Bits(Bag[1]);
            Super1.SetCurrentHpAp(Shrt(Bag[2]), Shrt(Bag[3]));
            Super1.Experience = Shrt(Bag[4]);
            Super1.MiniTask = Convert.ToBoolean(Bag[5]);
            Super1.Learned = Shrt(Bag[6]);

            NextExpBar.Value = Super1.Experience;
            NextExpBar.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
            ExpBar1.Value = NextExpBar.Value;
            RefreshAllHPAP();

            Bag = DataBaseMSsql.GetPlayerStats(DataBaseMSsql.CurrentLogin, new Object[] { 0, 0, 0, 0, 0, 0 });
            Super1.SetStats(Super1.CurrentLevel, Shrt(Bag[0]), Shrt(Bag[1]), Bits(Bag[2]), Bits(Bag[3]), Bits(Bag[4]), Bits(Bag[5]));

            ByteEquip = DataBaseMSsql.GetPlayerSettings(DataBaseMSsql.CurrentLogin, new Byte[] { 0, 0, 0, 0, 0, 0 });
            SettingsSetAll(ByteEquip);

            Byte[] CipherValue = new Byte[] { 1, 2, 4, 8 };
            BAG.Weapon = Decoder(CipherValue, new Boolean[] { false, false, false, false }, Ciphers[0], Bits(BAG.Weapon.Length));
            BAG.Hands = GetValueFromDecoder(BAG.Weapon, Super1.PlayerEQ[0]);
            BAG.Armor = Decoder(CipherValue, new Boolean[] { false, false, false, false }, Ciphers[1], Bits(BAG.Armor.Length));
            BAG.Jacket = GetValueFromDecoder(BAG.Armor, Super1.PlayerEQ[1]);
            BAG.Pants = Decoder(CipherValue, new Boolean[] { false, false, false, false }, Ciphers[2], Bits(BAG.Pants.Length));
            BAG.Legs = GetValueFromDecoder(BAG.Pants, Super1.PlayerEQ[2]);
            BAG.ArmBoots = Decoder(CipherValue, new Boolean[] { false, false, false, false }, Ciphers[3], Bits(BAG.ArmBoots.Length));
            BAG.Boots = GetValueFromDecoder(BAG.ArmBoots, Super1.PlayerEQ[3]);
            ContinueQuest();
        }
        private void MapCheck(in Byte Loc)
        {
            switch (Loc)
            {
                case 0: Location1_AncientPyramid(); break;
                case 1: Location2_WaterTemple(); break;
                case 2: Location3_LavaTemple(); break;
                case 3: Location4_BigRun(); break;
            }
        }
        private void ChangeBackground(in Byte loc, in Byte NoSpoilers) { BitmapImage[] Bmps = BmpersToX(Bmper(Path.Backgrounds.Location1), Bmper(Path.Backgrounds.Location2), Bmper(Path.Backgrounds.Location3), Bmper(Path.Backgrounds.Location4)); if (NoSpoilers == 0) Img1.Source = Bmper(Path.Backgrounds.Main); else Img1.Source = Bmps[loc]; }
        private void ChangeBackground(in Byte loc) { BitmapImage[] Bmps = BmpersToX(Bmper(Path.Backgrounds.Location1), Bmper(Path.Backgrounds.Location2), Bmper(Path.Backgrounds.Location3), Bmper(Path.Backgrounds.Location4)); Img1.Source = Bmps[loc]; }
        private void SettingsSetAll(params Byte[] SettingValues)
        {
            Slider[] Sliders = { MusicLoud, SoundsLoud, NoiseLoud, GameSpeed, Brightness };
            for (Byte i = 0; i < Sliders.Length; i++)
                Sliders[i].Value = Convert.ToDouble(SettingValues[i]) * 0.01;
            TimerTurnOn.IsChecked = SettingValues[5] >= 1;
        }
        private void PlayerSetLocation(in Byte row, in Byte column)
        {
            Adoptation.ImgYbounds = row;
            Adoptation.ImgXbounds = column;
            AnyGrid(Img2, row, column);
        }

        //[EN] Creating a location instances.
        //[RU] Создание локаций.
        private void Location1_AncientPyramid()
        {
            ChestsAndTablesAllTurnOn1();
            switch (Super1.MenuTask)
            {
                case 0: Map1ModelsAllTurnOn1(); break;
                case 1: ImgShowX(new Image[] { KeyImg3, LockImg3, KeyImg2, LockImg2 }); ChangeMapToVoidOrWallX(new Byte[] { 101, 131 }, 0); Sets.EnemyRate++; break;
                case 2: ImgShowX(new Image[] { KeyImg3, LockImg3 }); ChangeMapToVoidOrWallX(new Byte[] { 101, 131, 102, 132 }, 0); Sets.EnemyRate += 2; break;
                case 3: ChangeMapToVoidOrWallX(new Byte[] { 101, 131, 102, 132, 103, 133 }, 0); Sets.EnemyRate += 3; break;
            }
            ImgGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress }, new Byte[] { 27, 24, 7, 9, 33, 25, 10, 4, 17 }, new Byte[] { 19, 11, 21, 20, 18, 15, 38, 36, 29 });
            PlayerSetLocation(Bits(Super1.MenuTask <= 0 ? 34 : 17), Bits(Super1.MenuTask <= 0 ? 18 : 29));
            Sets.LockIndex = Bits(3 - Super1.MenuTask);
            if (BAG.Armor[3]) ChangeMapToVoid(191);
            TheEnd.Source = Ura(Path.CutScene.Victory);
        }
        private void Location2_WaterTemple()
        {
            Byte[] EnemyRates = { 2, 3, 4, 5, 3, 5, 5 };
            Sets.EnemyRate = EnemyRates[Super1.MenuTask];
            Img1.Source = Bmper(Path.Backgrounds.Location2);
            AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress }, new Byte[] { 9, 21, 10, 8, 29, 22, 22, 16, 28 }, new Byte[] { 8, 10, 24, 35, 49, 23, 2, 4, 20 });
            AnyShowX(Img1, ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress, SecretChestImg1, SecretChestImg2, JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7, Boulder1);
            ChestsCheck(BAG.Pants[3], 213, SecretChestImg1);
            ChestsCheck(Super1.MiniTask, 232, SecretChestImg2);
            if (Super1.MenuTask > 4) AnyHideX(Super1.MenuTask > 5 ? new Image[] { JailImg1, JailImg5, JailImg6, JailImg7 } : new Image[] { JailImg1 });
            if (Super1.MenuTask > 4) ChangeMapToVoidOrWallX(Super1.MenuTask > 5 ? new byte[] { 134,136,137,138,104,106,107,108 }: new byte[] { 134,104 }, 0);
            PlayerSetLocation(Bits(Super1.MenuTask>4 ? 28 : 34), Bits(Super1.MenuTask > 4 ? 20: 51));
            TheEnd.Source = Ura(Path.CutScene.WasteTime);
        }
        private void Location3_LavaTemple()
        {
            Sets.EnemyRate = 5;
            AnyShowX(ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Boulder1, JailImg1, JailImg2, JailImg5, Lever1, Lever2, Lever3);
            AnyGridX(new Image[] { ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2, Table3, Threasure1, SaveProgress, Boulder1, JailImg1, JailImg2, JailImg5 }, new Byte[] { 17, 22, 28, 26, 17, 1, 1, 2, 18, 20, 28, 21, 25 }, new Byte[] { 4, 23, 38, 56, 27, 9, 50, 28, 28, 46, 37, 46, 48 });
            AnyHideX(new Image[] { JailImg3, JailImg6, JailImg7, SecretChestImg1, SecretChestImg2 });
            AnyShowX(SpDmg1, SpDmg2, SpDmg3, SpDmg4, SpDmg5, SpHrb1, SpHrb2, SpHrb3, SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8, SpHrb9, SpHrb10, SpHrb11, SpHrb12, SpHrb13, SpHrb14,
                SpEtr1, SpEtr2, SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7, SpEtr8, SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14, SpEtr15, SpEtr16, SpEtr17, SpEtr18, SpElx1, SpElx2, SpElx3, SpElx4, SpElx5, SpElx6,
                SpSbg1, SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6, SpSbg7, SpSbg8, SpSbg9, SpSbg10, SpSbg11, SpSer, SpTsk);
            SurpriseCheck(BAG.Weapon[3], 226, SpSer);
            SurpriseCheck(Super1.MiniTask, 233, SpTsk);
            if (Super1.MenuTask >= 8) { ChangeMapToVoid(138); ChangeMapToWall(111); PullTheLever(Lever1, new Image[] { Bridge1, Bridge2, Bridge3, Bridge4 }); }
            PlayerSetLocation(Bits(18), Bits(28));
            TheEnd.Source = Ura(Path.CutScene.PowerRanger);
        }
        private void Location4_BigRun()
        {
            AnyShow(TimerFlees);
            AnyHideX(SpDmg1, SpDmg2, SpDmg3, SpDmg4, SpDmg5, SpHrb1, SpHrb2, SpHrb3, SpHrb4, SpHrb5, SpHrb6, SpHrb7, SpHrb8, SpHrb9, SpHrb10, SpHrb11, SpHrb12, SpHrb13, SpHrb14,
                SpEtr1, SpEtr2, SpEtr3, SpEtr4, SpEtr5, SpEtr6, SpEtr7, SpEtr8, SpEtr9, SpEtr10, SpEtr11, SpEtr12, SpEtr13, SpEtr14, SpEtr15, SpEtr16, SpEtr17, SpEtr18, SpElx1, SpElx2, SpElx3, SpElx4, SpElx5, SpElx6,
                SpSbg1, SpSbg2, SpSbg3, SpSbg4, SpSbg5, SpSbg6, SpSbg7, SpSbg8, SpSbg9, SpSbg10, SpSbg11, SpSer, SpTsk, Lever1, Lever2, Lever3, Bridge1, Bridge2, Bridge3, Bridge4, Bridge5, Bridge6, Bridge7, Bridge8);
            TimerOn(ref TRout);
            PlayerSetLocation(Bits(1), Bits(30));
        }
        private void Threasures()
        {
            string[] ambushed = { Path.CutScene.Ambushed, Path.CutScene.BattleStations, Path.CutScene.NotAgain };
            BitmapImage[] battlegrounds = BmpersToX(Bmper(Path.Fighting.Battle1), Bmper(Path.Fighting.Battle2), Bmper(Path.Fighting.Battle3), Bmper(Path.Fighting.Battle3));
            BitmapImage[] threasures = BmpersToX(Bmper(Path.MapModels.Artifact1), Bmper(Path.MapModels.Artifact2), Bmper(Path.MapModels.Artifact3), Bmper(Path.MapModels.Artifact3));
            ChestsCheck(BAG.Weapon[CurrentLocation], 203, ChestImg3);
            ChestsCheck(BAG.Armor[CurrentLocation], 201, ChestImg1);
            ChestsCheck(BAG.Pants[CurrentLocation], 204, ChestImg4);
            ChestsCheck(BAG.ArmBoots[CurrentLocation], 202, ChestImg2);
            FastImgChange(new Image[] { Img3, Threasure1 }, BmpersToX(battlegrounds[CurrentLocation], threasures[CurrentLocation]));
            AnyShowX(new Image[] { Threasure1, SaveProgress });
            ChestsAndTablesAllTurnOn1();
            Med2.Source = Ura(ambushed[CurrentLocation]);
        }
        private Byte LocationDecode(in Byte Task)
        {
            switch (Task)
            {
                case 0: case 1: case 2: case 3: return 0;
                case 4: case 5: case 6: return 1;
                case 7: case 8: return 2;
                default: return 3;
            }
        }

        //[EN] Continue game.
        //[RU] Продолжение игры.
        private void ContinueQuest()
        {
            DataBaseMSsql.DeselectAllPlayers();
            CurrentLocation = LocationDecode(Super1.MenuTask);
            Time1.Maximum = TimeFormula();
            MapBuild(CurrentLocation);
            MapCheck(CurrentLocation);
            if (CurrentLocation < 3) Threasures();
            string[] music = new string[] { Path.GameMusic.AncientPyramid, Path.GameMusic.WaterTemple, Path.GameMusic.LavaTemple, Path.GameMusic.GetAway };
            ChangeBackground(CurrentLocation);
            HeyPlaySomething(music[CurrentLocation]);
            ImgShowX(new Image[] { Img1, Img2 });
            ContinueCheckPoints();
        }
        private void ChestsCheck(in Boolean CheckValue, in Byte OnMap, Image Chest)
        {
            BitmapImage[] chestvercl = BmpersToX(Bmper(Path.MapModels.ChestClosed1), Bmper(Path.MapModels.ChestClosed2), Bmper(Path.MapModels.ChestClosed3));
            BitmapImage[] chestverop = BmpersToX(Bmper(Path.MapModels.ChestOpened1), Bmper(Path.MapModels.ChestOpened2), Bmper(Path.MapModels.ChestOpened3));
            Chest.Source = CheckValue ? chestverop[CurrentLocation] : chestvercl[CurrentLocation];
            if (CheckValue) ChangeMapToWall(OnMap);
        }
        private void SurpriseCheck(in Boolean CheckValue, in Byte OnMap, Image Chest) { if (CheckValue) { AnyHide(Chest); ChangeMapToVoid(OnMap); } }
        private void ContinueCheckPoints()
        {
            AnyHide(MainMenu);
            MaxAndWidthHPcalculate();
            MaxAndWidthAPcalculate();
            RefreshAllHPAP();
            if (Super1.CurrentLevel >= 25)
            {
                Super1.Experience = Shrt(NextExpBar.Maximum);
                NextExpBar.Value = NextExpBar.Maximum;
                ExpBar1.Value = ExpBar1.Maximum;
                FastTextChange(new Label[] { ExpText, Exp1 }, new string[] { Txt.Com.Expert, Txt.Com.Expert });
            }
            else
            {
                NextExpBar.Value = Super1.Experience;
                ExpBar1.Maximum = Super1.NextLevel[Super1.CurrentLevel - 1];
                ExpBar1.Value = NextExpBar.Value;
                FastTextChange(new Label[] { ExpText, Exp1 }, new string[] { Txt.Com.Exp + " " + NextExpBar.Value + "/" + NextExpBar.Maximum, Txt.Com.Exp + " " + ExpBar1.Value + "/" + ExpBar1.Maximum });

            }
            WeaponCheckPoint();
            ArmorCheckPoint();
            PantsCheckPoint();
            BootsCheckPoint();
            CheckSeriousBonus();
            HeroStatus();
        }
        private void WeaponCheckPoint()
        {
            EquipH.Content = (Super1.PlayerEQ[0]) switch
            {
                10 => Txt.Eqp.Hand.Duster,
                50 => Txt.Eqp.Hand.Knife,
                200 => Txt.Eqp.Hand.Sword,
                165 => Txt.Eqp.Hand.Minigun,
                _ => Txt.Eqp.Hand.Bare,
            };
        }
        private void ArmorCheckPoint()
        {
            EquipB.Content = (Super1.PlayerEQ[1]) switch
            {
                5 => Txt.Eqp.Tors.Bcoat,
                25 => Txt.Eqp.Tors.Ancient,
                90 => Txt.Eqp.Tors.Legend,
                85 => Txt.Eqp.Tors.Serious,
                _ => Txt.Eqp.Tors.Bare,
            };
        }
        private void PantsCheckPoint()
        {
            EquipL.Content = (Super1.PlayerEQ[2]) switch
            {
                4 => Txt.Eqp.Legs.Vulture,
                15 => Txt.Eqp.Legs.Ancient,
                65 => Txt.Eqp.Legs.Legend,
                55 => Txt.Eqp.Legs.Serious,
                _ => Txt.Eqp.Legs.Bare,
            };
        }
        private void BootsCheckPoint()
        {
            EquipD.Content = (Super1.PlayerEQ[3]) switch
            {
                1 => Txt.Eqp.Boot.Bboots,
                10 => Txt.Eqp.Boot.Ancient,
                45 => Txt.Eqp.Boot.Legend,
                25 => Txt.Eqp.Boot.Serious,
                _ => Txt.Eqp.Boot.Bare,
            };
        }
        private void ReplaceModel(in Byte y, in Byte x, in Byte Model) { MapScheme[y, x]=Model; }
        private Byte[] CheckModelCoord(in Byte Condition)
        {
            for (Byte i = 0; i < MapScheme.GetLength(0); i++) for (Byte j = 0; j < MapScheme.GetLength(1); j++) if (MapScheme[i, j] == Condition) return new Byte[] { i, j };
            return new Byte[] { 0, 0 };
        }
        private Boolean CheckMapIfModelExists(in Byte Condition)
        {
            for (Byte i = 0; i < MapScheme.GetLength(0); i++)
                for (Byte j = 0; j < MapScheme.GetLength(1); j++)
                    if (MapScheme[i, j] == Condition)
                        return true;            
            return false;
        }
        private void ChangeMapToVoid(in Byte Condition) { for (Byte i = 0; i < MapScheme.GetLength(0); i++) for (Byte j = 0; j < MapScheme.GetLength(1); j++) if (MapScheme[i, j] == Condition) MapScheme[i, j] = 0; }
        private void ChangeMapToVoid(in Byte Row, in Byte Col,  params Image[] Imgs)
        {
            foreach (Image img in Imgs)
                if ((Bits(img.GetValue(Grid.RowProperty))==Row)&&(Bits(img.GetValue(Grid.ColumnProperty)) == Col))
                {
                    AnyHide(img);
                    MapScheme[Row, Col] = 0;
                }
        }
        private void ChangeMapToVoidOrWallX(in Byte[] Conditions, in Byte Model) {
            foreach (Byte Condition in Conditions)
                if (Model==0)
                    ChangeMapToVoid(Condition);
                else
                    ChangeMapToWall(Condition);
        }
        private void ChangeMapToWall(in Byte Condition) {
            for (Byte i = 0; i < MapScheme.GetLength(0); i++)
                for (Byte j = 0; j < MapScheme.GetLength(1); j++)
                    if (MapScheme[i, j] == Condition)
                        MapScheme[i, j] = 1;
        }
        private void AbilsMenu_MouseLeave(object sender, MouseEventArgs e) { LabHide(AbilsCost); }
        private void Cure2_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 10)
            {
                Super1.SetCurrentHpAp(Super1.MaxHP, Shrt(Super1.CurrentAP - 10));
                TimerOn(ref Pure2, Shrt(25 / GameSpeed.Value));
                TimerOn(ref PCur2, Shrt(75 / GameSpeed.Value));
                Dj(Path.GameNoises.Cure2);
                CurrentHpApCalculate();
                AnyHide(SkillsMenu);
                Time1.Value = 0;
            }
        }
        private void BuffUp_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 12)
            {
                AbilityBonuses[0] = Super1.Special;
                Super1.CurrentAP -= 12;
                Dj(Path.GameNoises.PowUp);
                TimerOn(ref PBuff, Shrt(25 / GameSpeed.Value));
                TimerOn(ref PPowr, Shrt(75 / GameSpeed.Value));
                CurrentAPcalculate();
                AnyHide(SkillsMenu);
                Time1.Value = 0;
            }
        }
        private bool BuffUpShow(in string Power)
        {
            if (BuffUpTxt.Content.ToString() != Power) BuffUpTxt.Content = "+" + Power;
            Byte[] RowSet2 = { 22, 21, 20, 19, 18 };
            if (!BuffUpTxt.IsEnabled) LabShow(BuffUpTxt);
            if (CureCurrent == RowSet2.Length - 1)
            {
                CureCurrent = 0;
                LabHide(BuffUpTxt);
                return true;
            }
            else { Grid.SetRow(BuffUpTxt, RowSet2[CureCurrent]); CureCurrent++; }
            return false;
        }
        private void ToughenUp_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 8)
            {
                AbilityBonuses[1] = Super1.Special;
                Super1.CurrentAP -= 8;
                Dj(Path.GameNoises.Shield);
                TimerOn(ref PTogh, Shrt(25 / GameSpeed.Value));
                TimerOn(ref PPowr, Shrt(75 / GameSpeed.Value));
                CurrentAPcalculate();
                AnyHide(SkillsMenu);
                Time1.Value = 0;
            }
        }
        private void Regen_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 15)
            {
                Super1.CurrentAP -= 15;
                Dj(Path.GameNoises.HpUp);
                TimerOn(ref PRegn, Shrt((511 - Super1.Special) / GameSpeed.Value));
                TimerOn(ref PHpUp, Shrt(25 / GameSpeed.Value));
                CurrentAPcalculate();
                AnyHide(SkillsMenu);
                Time1.Value = 0;
            }
        }
        private void TimerOn(ref System.Windows.Threading.DispatcherTimer timer)
        {
            timer.IsEnabled = true;
            timer.Start();
        }
        private void TimerOn(ref System.Windows.Threading.DispatcherTimer timer, in TimeSpan time)
        {
            timer.IsEnabled = true;
            timer.Interval = time;
            timer.Start();
        }
        private void TimerOn(ref System.Windows.Threading.DispatcherTimer timer, in UInt16 time)
        {
            timer.IsEnabled = true;
            timer.Interval = new TimeSpan(0,0,0,0,time);
            timer.Start();
        }
        private void TimerOff(ref System.Windows.Threading.DispatcherTimer timer)
        {
            timer.IsEnabled = false;
            timer.Stop();
        }
        private void Control_Click(object sender, RoutedEventArgs e)
        {
            Dj(Path.GameNoises.ApUp);
            TimerOn(ref PCtrl, Shrt((511 - Super1.Special) / GameSpeed.Value));
            TimerOn(ref PApUp, Shrt(25 / GameSpeed.Value));
            AnyHide(SkillsMenu);
            Time1.Value = 0;
        }
        private void Thrower_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 4)
            {
                Sets.SelectedTarget = Bits(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
                SelectedTrgt = Sets.SelectedTarget;
                SelectTarget();
                AnyHide(SkillsMenu);
                AnyShowX(ACT3, SelectMenuSkills);
            }
        }
        private void ActionOnOne_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Byte i = btn.Name switch
            {
                "ACT1" => 0,
                "ACT2" => 1,
                "ACT3" => 2,
                _ => 0
            };
            string[] ActSounds = { Path.GameNoises.Torch, Path.GameNoises.Whip, Path.GameNoises.Thrower };
            Byte[] Cost = { 4, 6, 15 };
            SelectedTrgt = Sets.SelectedTarget;
            Time1.Value = 0;
            Super1.CurrentAP -= Cost[i];
            ACT(i);
            Dj(ActSounds[i]);
            AnyHideX(TrgtImg, btn, SelectMenuSkills);
            switch (i)
            {
                case 0: TimerOn(ref PTrch, Shrt(25 / GameSpeed.Value)); TimerOn(ref PToch, Shrt(50 / GameSpeed.Value)); break;
                case 1: TimerOn(ref PWhip, Shrt(25 / GameSpeed.Value)); TimerOn(ref PWhpd, Shrt(50 / GameSpeed.Value)); break;
                case 2: TimerOn(ref PThrw, Shrt(25 / GameSpeed.Value)); TimerOn(ref PThwr, Shrt(50 / GameSpeed.Value)); break;
                default: TimerOn(ref PTrch, Shrt(25 / GameSpeed.Value)); TimerOn(ref PToch, Shrt(50 / GameSpeed.Value)); break;
            }
            CurrentAPcalculate();
            if (Targt.IsEnabled) TimerOff(ref Targt);
        }
        private void ActionOnAll_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Byte i = btn.Name switch
            {
                "Super" => 0,
                "Tornado" => 1,
                "Quake" => 2,
                _ => 0
            };
            string[] ActSounds = { Path.GameNoises.Super, Path.GameNoises.Whirl, Path.GameNoises.Quake };
            Byte[] Cost = { 10, 20, 30 };
            UInt16[] AbilityPowers = { Shrt(Super1.Special * 2), Shrt(Super1.Special * 3), Shrt(Super1.Special * 4) };
            SelectedTrgt = Sets.SelectedTarget;
            Time1.Value = 0;
            if (Super1.CurrentAP - Cost[i] >= 0)
            {
                Super1.CurrentAP -= Cost[i];
                AbilitySupers(AbilityPowers[i]);
                Dj(ActSounds[i]);
                AnyHideX(TrgtImg, btn);
                switch (i)
                {
                    case 0: TimerOn(ref Puper, Shrt(25 / GameSpeed.Value)); TimerOn(ref PSupr, Shrt(50 / GameSpeed.Value)); break;
                    case 1: TimerOn(ref Pnado, Shrt(25 / GameSpeed.Value)); TimerOn(ref PWhrl, Shrt(50 / GameSpeed.Value)); break;
                    case 2: TimerOn(ref Puake, Shrt(25 / GameSpeed.Value)); TimerOn(ref PQuak, Shrt(50 / GameSpeed.Value)); break;
                    default: TimerOn(ref Puper, Shrt(25 / GameSpeed.Value)); TimerOn(ref PSupr, Shrt(50 / GameSpeed.Value)); break;
                }
            }
            CurrentAPcalculate();
        }
        private void AbilitiesInFight_MouseLeave(object sender, MouseEventArgs e) { LabHide(BattleText2); }
        private void AbilitiesInFight_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            BattleText2.Content = b.Tag.ToString();
            LabShow(BattleText2);
        }
        private void AbilitiesOutFight_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            AbilsCost.Content = Numb(b.Tag);
            LabShow(AbilsCost);
        }
        private void ItemsOutMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            Byte p = Bits(b.Tag);
            Byte[] counts = { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM, BAG.SleepBagITM };
            CountText.Content = "Всего: " + counts[p];
            LabShow(CountText);
        }
        private void ItemsOutMenu_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Byte p = Bits(b.Tag);
            Button[] Items = { Bandage, Ether1, Fused, Herbs1, Ether2Out, SleepBag1, Elixir1 };
            Label[] Describes = { BandageText, EtherText, FusedText, HerbsText, Ether2OutText, SleepBagText, ElixirText };
            Byte[] Counts = { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM };
            UInt16[] HpFill = { Shrt((Super1.CurrentHP + 50) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 50)), Super1.CurrentHP, Shrt((Super1.CurrentHP + 80) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 80)), Shrt((Super1.CurrentHP + 350) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 350)), Super1.CurrentHP, Super1.MaxHP, Super1.MaxHP };
            UInt16[] ApFill = { Super1.CurrentAP, Shrt((Super1.CurrentAP + 50) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 50)), Shrt((Super1.CurrentAP + 80) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 80)), Super1.CurrentAP, Shrt((Super1.CurrentAP + 300) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 300)), Super1.MaxAP, Super1.MaxAP };
            Counts[p]--;
            if (Counts[p] <= 0)
                AnyHideX(b, Describes[p]);
            if (p == 0)
                HeroSetStatus(0);
            else
            {
                Super1.SetCurrentHpAp(HpFill[p - 1], ApFill[p - 1]);
                RefreshAllHPAP();
                MenuHpApExp();
                CheckAccessItems(Counts, Items);
            }
            CountText.Content = Txt.Com.Total + ": " + Counts[p];
            BAG.ItemsSet(Counts[1], BAG.AntidoteITM, Counts[2], Counts[3], Counts[4], Counts[6], Counts[5], Counts[7]);
            Dj(Path.GameNoises.UseItems);
        }
        private void CraftItems_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Byte p = Bits(b.Tag);
            Button[] cbuttons = new Button[] { CraftAntidote, CraftBandage, CraftEther, CraftFused, CraftHerbs, CraftEther2, CraftBedbag, CraftElixir };
            Byte[] ItemsCount = { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.SleepBagITM, BAG.ElixirITM };
            UInt16[] MatCosts = new UInt16[] { 10, 20, 70, 150, 500, 1500, 100, 10000 };
            BAG.Materials -= MatCosts[p];
            ItemsCount[p]++;
            CountText.Content = Txt.Com.Total + ": " + ItemsCount[p];
            MaterialsCraft.Content = BAG.Materials;
            BAG.ItemsSet(ItemsCount[1], ItemsCount[0], ItemsCount[2], ItemsCount[3], ItemsCount[4], ItemsCount[6], ItemsCount[5], ItemsCount[7]);
            CheckAccessMaterials(MatCosts, cbuttons);
            TooManyItems(ItemsCount, cbuttons);
        }
        private void CraftPerfboots_Click(object sender, RoutedEventArgs e)
        {
            BAG.Materials -= 30000;
            BAG.ArmBoots[3] = true;
            MaterialsCraft.Content = BAG.Materials;
            ButtonHide(CraftPerfboots);
            BAG.Boots = Super1.PlayerEQ[3] == 0;
        }
        private void CraftPerfboots_MouseEnter(object sender, MouseEventArgs e) { CountText.Content = Txt.Com.QMark; LabShow(CountText); }
        private void HeroSetStatus(byte code)
        {
            String[] text = { Txt.Com.Hlthy + " ♫", Txt.Com.Ill + " §" };
            String[] icon = { @Path.IconStatePath.Usual, @Path.IconStatePath.Poison };
            Super1.PlayerStatus = code;
            AfterStatus.Content = StatusP.Content = text[code];
            AfterIcon.Source = Img5.Source = Bmper(icon[code]);
        }
        private void ItemsInFight_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Byte p = Bits(b.Tag);
            Byte[] Counts = { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM };
            UInt16[] HpFill = { Shrt((Super1.CurrentHP + 50) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 50)), Super1.CurrentHP, Shrt((Super1.CurrentHP + 80) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 80)), Shrt((Super1.CurrentHP + 350) > Super1.MaxHP ? Super1.MaxHP : (Super1.CurrentHP + 350)), Super1.CurrentHP, Super1.MaxHP };
            UInt16[] ApFill = {  Super1.CurrentAP, Shrt((Super1.CurrentAP + 50) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 50)), Shrt((Super1.CurrentAP + 80) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 80)), Super1.CurrentAP, Shrt((Super1.CurrentAP + 300) > Super1.MaxAP ? Super1.MaxAP : (Super1.CurrentAP + 300)), Super1.MaxAP };
            AnyHide(ItemsMenu);
            TimerOn(ref PItem, Shrt(25 / GameSpeed.Value));
            Counts[p]--;
            if (Counts[p] <= 0)
                AnyHide(b);
            if (p==0)
                HeroSetStatus(0);
            else
            {
                Super1.SetCurrentHpAp(HpFill[p-1], ApFill[p-1]);
                CurrentHpApCalculate();
            }
            Time1.Value = 0;
            switch (p)
            {
                case 0: TimerOn(ref PAtdt, Shrt(75 / GameSpeed.Value)); break;
                case 1: TimerOn(ref PBndg, Shrt(75 / GameSpeed.Value)); break;
                case 2: TimerOn(ref PEthr, Shrt(75 / GameSpeed.Value)); break;
                case 3: TimerOn(ref PFusd, Shrt(75 / GameSpeed.Value)); break;
                case 4: TimerOn(ref PHerb, Shrt(75 / GameSpeed.Value)); break;
                case 5: TimerOn(ref PEtr2, Shrt(75 / GameSpeed.Value)); break;
                case 6: TimerOn(ref PElxr, Shrt(75 / GameSpeed.Value)); break;
            }
            BAG.ItemsSet(Counts[1], Counts[0], Counts[2], Counts[3], Counts[4], BAG.SleepBagITM, Counts[5], Counts[6]);
            Dj(Path.GameNoises.UseItems);
        }
        private void ItemsUseInBattle_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Byte p = Bits(btn.Tag);
            Byte[] ItemsCount = { BAG.AntidoteITM, BAG.BandageITM, BAG.EtherITM, BAG.FusedITM, BAG.HerbsITM, BAG.Ether2ITM, BAG.ElixirITM };
            String[] descrypt = { Txt.Bag.Ant, Txt.Bag.Ban, Txt.Bag.Etr, Txt.Bag.Bld, Txt.Bag.Hrb, Txt.Bag.Er2, Txt.Bag.Elx };
            ItemText.Content = Txt.Com.Total + ": " + ItemsCount[p];
            BattleText2.Content = descrypt[p];
            LabShowX(new Label[] { BattleText2, ItemText });
        }
        private void ItemsUseInBattle_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemText.Content = "";
            LabHideX(new Label[] { ItemText, BattleText2 });
        }
        private void ChangeOnChapter(in Byte Loc)
        {
            BitmapImage[][] MapAndBattle = { BmpersToX(Bmper(Path.Backgrounds.Location1), Bmper(Path.Fighting.Battle1)), BmpersToX(Bmper(Path.Backgrounds.Location2), Bmper(Path.Fighting.Battle2)), BmpersToX(Bmper(Path.Backgrounds.Location3), Bmper(Path.Fighting.Battle2)), BmpersToX(Bmper(Path.Backgrounds.Location4), Bmper(Path.Fighting.Battle2)) };
            CurrentLocation = Loc;
            FastImgChange(new Image[] { Img1, Img3 }, MapAndBattle[CurrentLocation]);
            MediaHide(ChapterIntroduction);
            MediaHide(TheEnd);
        }
        private void ChapterIntroduction_MediaEnded(object sender, RoutedEventArgs e)
        {
            CurrentLocation = LocationDecode(Super1.MenuTask);
            MapBuild(CurrentLocation);
            switch (Super1.MenuTask)
            {
                case 0: Super1.MiniTask = false; ChangeOnChapter(0); Location1_AncientPyramid(); ImgShowX(new Image[] { Threasure1, SaveProgress }); Threasures(); TablesSetInfo(); break;
                case 3:
                case 4: Super1.MiniTask = false; ChangeOnChapter(1); Location2_WaterTemple(); Threasures(); if (DataBaseMSsql.CurrentLogin != "????") SaveGame(); AnyShow(SaveProgress); break;
                case 6:
                case 7: Super1.MiniTask = false; ChangeOnChapter(2); Location3_LavaTemple(); Threasures(); if (DataBaseMSsql.CurrentLogin != "????") SaveGame(); AnyShow(SaveProgress); break;
                case 8: case 9: ChangeOnChapter(3); Location4_BigRun(); if (DataBaseMSsql.CurrentLogin != "????") SaveGame(); break;
                case 10: MediaShowAdvanced(TheEnd, Ura(Path.CutScene.Titres), new TimeSpan(0, 0, 0, 0, 0)); HeyPlaySomething(Path.GameMusic.SayGoodbye); break;
                default: Form1.Close(); break;
            }
            ImgShowX(new Image[] { Img1, Img2 });
        }        
        private void AnyEquipments_MouseEnter(object sender, MouseEventArgs e)
        {
            LabShow(Describe1);
            Button[] EquipmentsBt = new Button[] { Equipments, Equipments2, Equipments3, Equipments4 };
            String[,] Descryption = new String[,] { { Txt.Hnt.EqWpn1, Txt.Hnt.EqArm1, Txt.Hnt.EqPnt1, Txt.Hnt.EqBts1 }, { Txt.Hnt.EqWpn2, Txt.Hnt.EqArm2, Txt.Hnt.EqPnt2, Txt.Hnt.EqBts2 }, { Txt.Hnt.EqWpn3, Txt.Hnt.EqArm3, Txt.Hnt.EqPnt3, Txt.Hnt.EqBts3 }, { Txt.Hnt.EqWpn4, Txt.Hnt.EqArm4, Txt.Hnt.EqPnt4, Txt.Hnt.EqBts4 } };
            Byte[,] ParamsUp = new Byte[,] { { 10, 5, 4, 1 }, { 50, 25, 15, 10 }, { 200, 90, 65, 45 }, { 165, 85, 55, 25 } };
            for (Byte i=0;i<EquipmentsBt.Length;i++)
            {
                if (sender.Equals(EquipmentsBt[i]))
                {
                    switch (Sets.EquipmentClass)
                    {
                        case 0: EquipCollectInfo(Descryption[i, 0], AddATK1, "+" + ParamsUp[i, 0]); break;
                        case 1: EquipCollectInfo(Descryption[i, 1], AddDEF1, "+" + ParamsUp[i, 1]); break;
                        case 2: EquipCollectInfo(Descryption[i, 2], AddDEF1, "+" + ParamsUp[i, 2]); break;
                        case 3: EquipCollectInfo(Descryption[i, 3], AddDEF1, "+" + ParamsUp[i, 3]); break;
                        default: EquipCollectInfo(Descryption[i, 0], AddATK1, "+" + ParamsUp[i, 0]); break;
                    }
                    break;
                }
            }
        }
        private void AnyEquipments_Click(object sender, RoutedEventArgs e)
        {
            LabShow(Describe1);
            Button[] EquipmentsBt = new Button[] { Equipments, Equipments2, Equipments3, Equipments4 };
            String[,] Descryption = new String[,] { { Txt.Eqp.Hand.Duster, Txt.Eqp.Tors.Bcoat, Txt.Eqp.Legs.Vulture, Txt.Eqp.Boot.Bboots }, { Txt.Eqp.Hand.Knife, Txt.Eqp.Tors.Ancient, Txt.Eqp.Legs.Ancient, Txt.Eqp.Boot.Ancient }, { Txt.Eqp.Hand.Sword, Txt.Eqp.Tors.Legend, Txt.Eqp.Legs.Legend, Txt.Eqp.Boot.Legend }, { Txt.Eqp.Hand.Minigun, Txt.Eqp.Tors.Serious, Txt.Eqp.Legs.Serious, Txt.Eqp.Boot.Serious } };
            Byte[,] ParamsUp = new Byte[,] { { 10, 5, 4, 1 }, { 50, 25, 15, 10 }, { 200, 90, 65, 45 }, { 165, 85, 55, 25 } };
            for (Byte i = 0; i < EquipmentsBt.Length; i++)
            {
                if (sender.Equals(EquipmentsBt[i]))
                {
                    switch (Sets.EquipmentClass)
                    {
                        case 0: OnEquiped(Equip1, EquipH, Descryption[i, 0], 0, ParamsUp[i, 0]); break;
                        case 1: OnEquiped(Equip2, EquipB, Descryption[i, 1], 1, ParamsUp[i, 1]); break;
                        case 2: OnEquiped(Equip3, EquipL, Descryption[i, 2], 2, ParamsUp[i, 2]); break;
                        case 3: OnEquiped(Equip4, EquipD, Descryption[i, 3], 3, ParamsUp[i, 3]); break;
                        default: OnEquiped(Equip1, EquipH, Descryption[i, 0], 0, ParamsUp[i, 0]); break;
                    }
                    break;
                }
            }
            CheckSeriousBonus();
            StatsMeaning();
            BtnHideX(new Button[] { Equipments, Equipments2, Equipments3, Equipments4, CancelEq });
            EquipWatch();
        }
        private string FoesStaticCheck(in string EnemyName)
        {
            return EnemyName switch
            {
                "Мумия" => Path.FoesStatePath.Mummy,
                "Зомби" => Path.FoesStatePath.Zombie,
                "Страж" => Path.FoesStatePath.Bones,
                "Стервятник" => Path.FoesStatePath.Vulture,
                "Гуль" => Path.FoesStatePath.Ghoul,
                "Жнец" => Path.FoesStatePath.GrimReaper,
                "Скарабей" => Path.FoesStatePath.Scarab,
                "Фараон" => Path.BossesStatePath.Pharaoh,
                "Угх-зан I" => Path.BossesStatePath.UghZan,
                "Моль-убийца" => Path.FoesStatePath.KillerMole,
                "Прислужник" => Path.FoesStatePath.Imp,
                "П. червь" => Path.FoesStatePath.Worm,
                "Мастер" => Path.FoesStatePath.Master,
                "????" => Path.BossesStatePath.Warrior,
                "Владыка" => Path.BossesStatePath.MrOfAll,
                _ => Path.FoesStatePath.Spider,
            };
        }
        private string[] FoesDynamicCheck(in string EnemyName)
        {
            return EnemyName switch
            {
                "Мумия" => Path.FoesAnimatePath.Mummy,
                "Зомби" => Path.FoesAnimatePath.Zombie,
                "Страж" => Path.FoesAnimatePath.Bones,
                "Стервятник" => Path.FoesAnimatePath.Vulture,
                "Гуль" => Path.FoesAnimatePath.Ghoul,
                "Жнец" => Path.FoesAnimatePath.GrimReaper,
                "Скарабей" => Path.FoesAnimatePath.Scarab,
                "Фараон" => Path.BossesAnimatePath.Pharaoh,
                "Угх-зан I" => Path.BossesAnimatePath.UghZan,
                "Моль-убийца" => Path.FoesAnimatePath.KillerMole,
                "Прислужник" => Path.FoesAnimatePath.Imp,
                "П. червь" => Path.FoesAnimatePath.Worm,
                "Мастер" => Path.FoesAnimatePath.Master,
                "????" => Path.BossesAnimatePath.Warrior,
                "Владыка" => Path.BossesAnimatePath.MrOfAll,
                _ => Path.FoesAnimatePath.Spider,
            };
        }
        private bool FoeAttacks_Time_Ticks(in Byte t1)
        {
            Image[] EnemiesImg = { Img6, Img7, Img8 };
            string[] EnemyAnimate = FoesDynamicCheck(Foe1.EnemyAppears[t1]);
            string Enemy = FoesStaticCheck(Foe1.EnemyAppears[t1]);
            EnemiesImg[t1].Source = Bmper(EnemyAnimate[EnemyAtck[t1]]);
            if (EnemyAtck[t1] >= EnemyAnimate.Length - 1)
            {
                if (Sets.SpecialBattle == 200) LabHide(BattleText6);
                HP.Foreground = Brushes.White;
                EnemyAtck[t1] = 0;
                EnemiesImg[t1].Source = Bmper(Enemy);
                return true;
            }
            else
            {
                EnemiesImg[t1].Source = Bmper(EnemyAnimate[EnemyAtck[t1]]);
                EnemyAtck[t1]++;
                return false;
            }
        }
        private bool AllDamaged(in UInt16 strength)
        {
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            AllDmgTimeTextChangeConstruction(Shrt(strength > EnemyAura ? strength - EnemyAura : 0));
            return FoesKicked();
        }
        private bool FoesFighting()
        {
            if (Super1.CurrentHP <= 0)
            {
                Super1.PlayerStatus = 0;
                Sound1.Stop();
                Sound2.Stop();
                Sound3.Stop();
                LabHide(BattleText3);
                MediaShow(GameOver);
                if (PTurn.IsEnabled) TimerOff(ref PTurn);
                return true;
            }
            if ((Super1.PlayerStatus == 1) && (Super1.CurrentHP > 0)) if (poison < 30) poison += 1; else { poison = 0; Super1.CurrentHP = Shrt(Super1.CurrentHP - 1); CurrentHPcalculate(); }
            if (((Foe1.EnemyHP[0] > 0) || (Foe1.EnemyHP[1] > 0) || (Foe1.EnemyHP[2] > 0)) && (Super1.CurrentHP > 0))
            {
                BattleFoeCharges(0, ref E1Atk);
                BattleFoeCharges(1, ref E2Atk);
                BattleFoeCharges(2, ref E3Atk);
            }
            else return true;
            return false;
        }
        private bool AcquireDamage()
        {
            Img4.Source = Bmper(Path.PersonAnimatePath.Hurt[PlayerHurt]);
            if (PlayerHurt == Path.PersonAnimatePath.Hurt.Length - 1)
            {
                HP.Foreground = Brushes.White;
                PlayerHurt = 0;
                Img4.Source = Bmper(Path.PersonStatePath.Usual);
                return true;
            }
            else PlayerHurt++;
            return false;
        }
        private bool AOuch()
        {
            Byte[] RowSet1 = { 17, 18, 19, 18, 19 };
            Byte[] ColumnSet1 = { 50, 51, 52, 53, 54 };
            if (PlayerHurtM == ColumnSet1.Length - 1)
            {
                PlayerHurtM = 0;
                LabHide(BattleText6);
                return true;
            }
            else
            {
                LabGrid(BattleText6, RowSet1[PlayerHurtM], ColumnSet1[PlayerHurtM]);
                PlayerHurtM++;
            }
            return false;
        }
        private bool ThrowAtFoes()
        {
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            string[] EnemyNames = { "Паук", "Мумия", "Зомби", "Страж", "Стервятник", "Гуль", "Жнец", "Скарабей", "Моль-убийца", "Прислужник", "П. червь", "Мастер" };
            UInt16 strength = Shrt((Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[4] || Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[8] || Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[9] || Foe1.EnemyAppears[SelectedTrgt] == EnemyNames[11] ? Super1.Special * 5 : Super1.Special * 2.5) + Super1.Special * Super1.Speed * 0.01);
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Labs[SelectedTrgt].Content = Shrt(strength > EnemyAura ? strength - EnemyAura : 0);
            return FoesKicked();
        }
        //[EN] Mini cutscenes
        //[RU] Мини сцены.
        private bool Pharaoh1()
        {
            if (!PharaohAppears.IsEnabled) ImgShow(PharaohAppears);
            if (PharaohAppears.Opacity < 1) PharaohAppears.Opacity += 0.01;
            else
            {
                if (Bits(Numb(PharaohAppears.GetValue(Grid.RowProperty)) - 1) < 6) { LetsBattle(); return true; }
                ImgGrid(PharaohAppears, Bits(Numb(PharaohAppears.GetValue(Grid.RowProperty)) - 1), Bits(Numb(PharaohAppears.GetValue(Grid.ColumnProperty))));
            }
            return false;
        }
        private bool Ancient2()
        {
            if (!Ancient.IsEnabled) AnyShow(Ancient);
            if (Ancient.Opacity < 1) Ancient.Opacity += 0.25;
            else
            {
                if (!Warrior.IsEnabled) AnyShow(Warrior);
                if (Appearance < Path.AniModel.Ancient.Length) AncientAppear_Phase1(Appearance);
                if (Appearance < 2) AncientAppear_Phase2(Appearance);
                else if (Numb(Warrior.GetValue(Grid.ColumnProperty)) < 5) AncientAppear_Phase3();
                else { ImgGrid(Warrior, Bits(Numb(Warrior.GetValue(Grid.RowProperty))), Bits(Numb(Warrior.GetValue(Grid.ColumnProperty)) - 1)); LetsBattle(); return true; }
                Appearance++;
            }
            return false;
        }
        private bool TheLord3()
        {
            if (!FinalAppears.IsEnabled) AnyShow(FinalAppears);
            if (FinalAppears.Opacity < 1) FinalAppears.Opacity += 0.05; else { LetsBattle(); return true; }
            return false;
        }
        private bool RockRoll()
        {
            Byte[] MapModel = CheckModelCoord(7);
            if ((MapModel[0] == Adoptation.ImgYbounds) && (MapModel[1] == Adoptation.ImgXbounds)) {
                ImgShow(PainImg);
                if (Super1.CurrentHP - 50 >= 0)
                {
                    Super1.CurrentHP -= 50;
                    if (Img2.IsEnabled) HPbar1.Value = Super1.CurrentHP; HPhelper.SetValue(Grid.ColumnProperty, Bits(Img2.GetValue(Grid.ColumnProperty)) - 1); HPhelper.SetValue(Grid.RowProperty, Bits(Img2.GetValue(Grid.RowProperty)) - 1); AnyShow(HPhelper);
                }
                else 
                { 
                    WonOrDied(); 
                    MediaShow(GameOver); 
                } 
            }
            ChangeMapToVoid(7);
            if (MapScheme[MapModel[0] + 1, MapModel[1]] != 1)
            {
                MapModel[0]++;
                ReplaceModel(MapModel[0], MapModel[1], 7);
                ImgGrid(Boulder1, MapModel[0], MapModel[1]);
                Boulder1.RenderTransform = new RotateTransform(45 * Adoptation.WidthAdBack * MapModel[0], 16*Adoptation.WidthAdBack, 15 * Adoptation.HeightAdBack);
            }
            else { ImgHide(Boulder1); return true; }
            return false;
        }
        private bool FoeHurts()
        {
            UInt16 pow = Shrt(Super1.Attack + Super1.PlayerEQ[0] + AbilityBonuses[0] + Sets.SeriousBonus + Super1.Attack * Super1.Speed / 100);
            UInt16 strength = Shrt(pow - EnemyTough(Sets.SelectedTarget) <= 0 ? 0 : pow - EnemyTough(Sets.SelectedTarget));
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            Labs[SelectedTrgt].Content = strength;
            return FoesKicked();
        }
        private bool Torchs()
        {
            UInt16 trchsp = Shrt((Foe1.EnemyAppears[SelectedTrgt] == "Паук") || (Foe1.EnemyAppears[SelectedTrgt] == "Мумия") || (Foe1.EnemyAppears[SelectedTrgt] == "Гуль") || (Foe1.EnemyAppears[SelectedTrgt] == "Жнец") ? Super1.Special * 2.5 : Super1.Special * 1.25);
            trchsp += Shrt(Super1.Special * Super1.Speed * 0.01);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Labs[SelectedTrgt].Content = Shrt(trchsp > EnemyAura ? trchsp - EnemyAura : 0);
            return FoesKicked();
        }
        private bool Whips()
        {
            UInt16 whipsp = Shrt((Foe1.EnemyAppears[SelectedTrgt] == "Зомби") || (Foe1.EnemyAppears[SelectedTrgt] == "Страж") || (Foe1.EnemyAppears[SelectedTrgt] == "Скарабей") || (Foe1.EnemyAppears[SelectedTrgt] == "П. червь") ? Super1.Special * 3 : Super1.Special * 1.5);
            whipsp += Shrt(Super1.Special * Super1.Speed * 0.01);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Labs[SelectedTrgt].Content = Shrt(whipsp > EnemyAura ? whipsp - EnemyAura : 0);
            return FoesKicked();
        }
        private bool Combos()
        {
            UInt16 supersp = Shrt(Super1.Special * 2);
            supersp += Shrt(Super1.Special * Super1.Speed * 0.01);
            UInt16 EnemyAura = EnemyAntiSkill(Sets.SelectedTarget);
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            for (Byte i = 0; i < Labs.Length; i++) if (Foe1.EnemyHP[i] != 0) Labs[i].Content = supersp > EnemyAura ? supersp - EnemyAura : 0;
            return FoesKicked();
        }
        private void AncientAppear_Phase1(in Byte App) { Ancient.Source = Bmper(Path.AniModel.Ancient[App]); }
        private void AncientAppear_Phase2(in Byte App) { Warrior.Source = Bmper(Path.AniModel.Warrior[App]); }
        private void AncientAppear_Phase3() { ImgGrid(Warrior, Bits(Warrior.GetValue(Grid.RowProperty)), Bits((Int32)Warrior.GetValue(Grid.ColumnProperty) + 1)); }

        //[EN] Time events.
        //[RU] Временные события.
        private void PHurt_D_T1(object sender, EventArgs e) { if (AcquireDamage()) TimerOff(ref PHurt); }
        private void THurt_D_T2(object sender, EventArgs e) { if (AOuch()) TimerOff(ref THurt); }
        private void E1Atk_D_T3(object sender, EventArgs e) { if (FoeAttacks_Time_Ticks(0)) TimerOff(ref E1Atk); }
        private void E2Atk_D_T4(object sender, EventArgs e) { if (FoeAttacks_Time_Ticks(1)) TimerOff(ref E2Atk); }
        private void E3Atk_D_T5(object sender, EventArgs e) { if (FoeAttacks_Time_Ticks(2)) TimerOff(ref E3Atk); }
        private void PHAtk_D_T6(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.HdAttack, Path.IconAnimatePath.HdAttack)) TimerOff(ref PHAtk); }
        private void PKAtk_D_T7(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.KnAttack, Path.IconAnimatePath.KnAttack)) TimerOff(ref PKAtk); }
        private void PSAtk_D_T8(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.SwAttack, Path.IconAnimatePath.SwAttack)) TimerOff(ref PSAtk); }
        private void PMAtk_D_T9(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.MgAttack, Path.IconAnimatePath.MgAttack)) TimerOff(ref PMAtk); }
        private void PFlee_D_T10(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Escape, Path.IconAnimatePath.Escape)) TimerOff(ref PFlee); }
        private void PItem_D_T11(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.BagUse, Path.IconAnimatePath.BagUse)) TimerOff(ref PItem); }
        private void Pure1_D_T12(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Cure, Path.IconAnimatePath.Cure)) TimerOff(ref Pure1); }
        private void Pure2_D_T13(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Cure2, Path.IconAnimatePath.Cure2)) TimerOff(ref Pure2); }
        private void PHeal_D_T14(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Heal, Path.IconAnimatePath.Heal)) TimerOff(ref PHeal); }
        private void PBuff_D_T15(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.BuffUp, Path.IconAnimatePath.BuffUp)) TimerOff(ref PBuff); }
        private void PTogh_D_T16(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.ToughenUp, Path.IconAnimatePath.ToughenUp)) TimerOff(ref PTogh); }
        private void PHpUp_D_T17(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Regen, Path.IconAnimatePath.Regen)) TimerOff(ref PHpUp); }
        private void PApUp_D_T18(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Control, Path.IconAnimatePath.Control)) TimerOff(ref PApUp); }
        private void PTrch_D_T19(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Torch, Path.IconAnimatePath.Torch)) TimerOff(ref PTrch); }
        private void PWhip_D_T20(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Whip, Path.IconAnimatePath.Whip)) TimerOff(ref PWhip); }
        private void PThrw_D_T21(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Thrower, Path.IconAnimatePath.Thrower)) TimerOff(ref PThrw); }
        private void Puper_D_T22(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Super, Path.IconAnimatePath.Super)) TimerOff(ref Puper); }
        private void Pnado_D_T23(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Tornado, Path.IconAnimatePath.Tornado)) TimerOff(ref Pnado); }
        private void Puake_D_T24(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Quake, Path.IconAnimatePath.Quake)) TimerOff(ref Puake); }
        private void Pearn_D_T25(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.Learn, Path.IconAnimatePath.Learn)) TimerOff(ref Pearn); }
        private void SMini_D_T26(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.SeriousMg, Path.IconAnimatePath.SeriousMg)) TimerOff(ref SMini); }
        private void SSwth_D_T27(object sender, EventArgs e) { if (ActionsTickCheck(Path.PersonAnimatePath.SSwitch, Path.IconAnimatePath.SSwitch)) TimerOff(ref SSwth); }
        private void Targt_D_T28(object sender, EventArgs e) { UnlimitedActionsTickCheck(Path.MiscAnimatePath.Target); }
        private void PBndg_D_T29(object sender, EventArgs e) { if (CureOrHeal("+50")) TimerOff(ref PBndg); }
        private void PEthr_D_T30(object sender, EventArgs e) { if (RestoreAP("+50")) TimerOff(ref PEthr); }
        private void PHerb_D_T31(object sender, EventArgs e) { if (CureOrHeal("+350")) TimerOff(ref PHerb); }
        private void PEtr2_D_T32(object sender, EventArgs e) { if (RestoreAP("+300")) TimerOff(ref PEtr2); }
        private void PAtdt_D_T33(object sender, EventArgs e) { if (CureOrHeal("-Яд")) TimerOff(ref PAtdt); }
        private void PCur2_D_T34(object sender, EventArgs e) { if (CureOrHeal("100%")) TimerOff(ref PCur2); }
        private void PFusd_D_T35(object sender, EventArgs e) { if (CureOrHeal("+80") || RestoreAP("+80")) TimerOff(ref PFusd); }
        private void PElxr_D_T36(object sender, EventArgs e) { if (CureOrHeal("100%") || RestoreAP("100%")) TimerOff(ref PElxr); }
        private void PRegn_F_T37(object sender, EventArgs e) { if (Super1.CurrentHP == Super1.MaxHP) { TimerOff(ref PRegn); } else { Super1.CurrentHP++; CurrentHPcalculate(); } }//throw new Exception("End? "+APRegenerate.IsEnabled);
        private void PCtrl_F_T38(object sender, EventArgs e) { if (Super1.CurrentAP == Super1.MaxAP) { TimerOff(ref PCtrl); } else { Super1.CurrentAP++; CurrentAPcalculate(); } }
        private void PThwr_I_T39(object sender, EventArgs e) { if (ThrowAtFoes()) TimerOff(ref PThwr); }
        private void PWhrl_I_T40(object sender, EventArgs e) { if (AllDamaged(Shrt(Super1.Special * 3 + Super1.Special * Super1.Speed * 0.01))) TimerOff(ref PWhrl); }
        private void PQuak_I_T41(object sender, EventArgs e) { if (AllDamaged(Shrt(Super1.Special * 4 + Super1.Special * Super1.Speed * 0.01))) TimerOff(ref PQuak); }
        private void PTurn_I_T42(object sender, EventArgs e) { if ((Time1.Value + 1 * GameSpeed.Value) < Time1.Maximum) Time1.Value += 1 * GameSpeed.Value; else { Time1.Value = Time1.Maximum; TimerOff(ref PTurn); Time(); } }
        private void ETurn_I_T43(object sender, EventArgs e) { if (FoesFighting()) TimerOff(ref ETurn); }
        private void WRecd_R_T44(object sender, EventArgs e) { if (WorldRecord()) TimerOff(ref WRecd); }
        private void Boss1_C_T45(object sender, EventArgs e) { if (Pharaoh1()) TimerOff(ref Boss1); }
        private void Boss2_C_T46(object sender, EventArgs e) { if (Ancient2()) TimerOff(ref Boss2); }
        private void Boss3_C_T47(object sender, EventArgs e) { if (TheLord3()) TimerOff(ref Boss3); }
        private void RRoll_L_T48(object sender, EventArgs e) { if (RockRoll()) TimerOff(ref RRoll); }
        private void EHurt_D_T49(object sender, EventArgs e) { if (FoeHurts()) TimerOff(ref EHurt); }
        private void PCure_D_T50(object sender, EventArgs e) { if (CureOrHeal("+" + Super1.Special * 2)) TimerOff(ref PCure); }
        private void PAtxc_D_T51(object sender, EventArgs e) { if (CureOrHeal("-Яд")) TimerOff(ref PAtxc); }
        private void PToch_D_T52(object sender, EventArgs e) { if (Torchs()) TimerOff(ref PToch); }
        private void PWhpd_D_T53(object sender, EventArgs e) { if (Whips()) TimerOff(ref PWhpd); }
        private void PSupr_D_T54(object sender, EventArgs e) { if (Combos()) TimerOff(ref PSupr); }
        private void PPowr_D_T55(object sender, EventArgs e) { if (BuffUpShow("" + Super1.Special)) TimerOff(ref PPowr); }
        private void AStat_F_T56(object sender, EventArgs e) { if (AddStats()) TimerOff(ref AStat); }
        private void AMats_F_T57(object sender, EventArgs e) { if (AddToBag()) TimerOff(ref AMats); }
        private void NLevl_F_T58(object sender, EventArgs e) { if (LevelUps()) TimerOff(ref NLevl); }
        private void TRout_F_T59(object sender, EventArgs e) { if (TimeChamber()) TimerOff(ref TRout); }
        private bool AddToBag()
        {
            if ((Mat > 0) && (BAG.Materials + 1 < 65535))
            {
                BAG.Materials += Shrt(Mat - 10000 >= 0 ? 10000 : Mat - 1000 >= 0 ? 1000 : Mat - 100 >= 0 ? 100 : Mat - 10 >= 0 ? 10 : 1);
                MaterialsOnHand.Content = BAG.Materials;
                Mat -= Shrt(Mat - 10000 >= 0 ? 10000 : Mat - 1000 >= 0 ? 1000 : Mat - 100 >= 0 ? 100 : Mat - 10 >= 0 ? 10 : 1);
                MaterialsAdd.Content = "+" + Mat;
            }
            else
            {
                Mat = 0;
                LabHide(MaterialsAdd);
                return true;
            }
            return false;
        }
        private bool LevelUps()
        {
            if ((Exp > 0) && (Super1.CurrentLevel < 25))
            {
                if (Super1.Experience + Shrt(Exp - 10000 >= 0 ? 10000 : Exp - 1000 >= 0 ? 1000 : Exp - 100 >= 0 ? 100 : Exp - 10 >= 0 ? 10 : 1) >= NextExpBar.Maximum)
                {
                    if (Super1.CurrentLevel < 25)
                    {
                        Dj(Path.GameNoises.LevelUp);
                        RecursiveLevelUp(Shrt(Exp - 10000 >= 0 ? 10000 : Exp - 1000 >= 0 ? 1000 : Exp - 100 >= 0 ? 100 : Exp - 10 >= 0 ? 10 : 1));
                        if (!NewLevelGet.IsEnabled) LevelUpShow();
                    }
                    else
                    {
                        Super1.Experience = Shrt(NextExpBar.Maximum);
                        NextExpBar.Value = NextExpBar.Maximum;
                        ExpText.Content = Txt.Com.Expert;
                        Exp = 0;
                        if (!NewLevelGet.IsEnabled) ButtonShow(TextOk1); else TimerOn(ref AStat, new TimeSpan(0, 0, 0, 0, 25));
                        return true;
                    }
                }
                else
                {
                    Super1.Experience += Shrt(Exp - 10000 >= 0 ? 10000 : Exp - 1000 >= 0 ? 1000 : Exp - 100 >= 0 ? 100 : Exp - 10 >= 0 ? 10 : 1); ;
                    NextExpBar.Value = Super1.Experience;
                    ExpText.Content = Txt.Com.Exp + " " + NextExpBar.Value + "/" + NextExpBar.Maximum;
                }
                Exp -= Shrt(Exp - 10000 >= 0 ? 10000 : Exp - 1000 >= 0 ? 1000 : Exp - 100 >= 0 ? 100 : Exp - 10 >= 0 ? 10 : 1);
            }
            else if (!NewLevelGet.IsEnabled)
            {
                ButtonShow(TextOk1);
                return true;
            }
            else
            {
                TimerOn(ref AStat, new TimeSpan(0, 0, 0, 0, 25));
                return true;
            }
            return false;
        }
        private bool AddStats()
        {
            if ((CurrentNextHPAP[0] < Super1.MaxHP) || (CurrentNextHPAP[1] < Super1.MaxAP) || (CurrentNextParams[0] < Super1.Attack) || (CurrentNextParams[1] < Super1.Defence) || (CurrentNextParams[2] < Super1.Speed) || (CurrentNextParams[3] < Super1.Special))
            {
                if (CurrentNextHPAP[0] < Super1.MaxHP)
                {
                    CurrentNextHPAP[0]++;
                    if (Super1.MaxHP < 333) NewMaximum(AfterHPbar, CurrentNextHPAP[0]);
                    else
                    {
                        if (CurrentNextHPAP[0] - 666 < 0 && Super1.MaxHP >= 666) CurrentNextHPAP[0] = 666; else if (CurrentNextHPAP[0] - 333 < 0) CurrentNextHPAP[0] = 333;
                        NewMaximumX(Super1.MaxHP < 666 ? new UInt16[] { 333, Shrt(CurrentNextHPAP[0] - 333) } : new UInt16[] { 333, 333, Shrt(CurrentNextHPAP[0] - 666) }, Super1.MaxHP < 666 ? new ProgressBar[] { AfterHPbar, AfterHPbarOver333 } : new ProgressBar[] { AfterHPbar, AfterHPbarOver333, AfterHPbarOver666 });
                        AnyShowX(Super1.MaxHP < 666 ? new ProgressBar[] { AfterHPbarOver333 } : new ProgressBar[] { AfterHPbarOver333, AfterHPbarOver666 });
                    }
                    FastTextChange(new Label[] { AddHP, AfterHP }, new string[] { "+" + (Super1.MaxHP - CurrentNextHPAP[0]), Super1.CurrentHP + "/" + CurrentNextHPAP[0] });
                }
                else LabHide(AddHP);

                if (CurrentNextHPAP[1] < Super1.MaxAP)
                {
                    CurrentNextHPAP[1]++;
                    if (Super1.MaxAP < 333) NewMaximum(AfterAPbar, CurrentNextHPAP[1]);
                    else
                    {
                        if (CurrentNextHPAP[1] - 666 < 0 && Super1.MaxAP >= 666) CurrentNextHPAP[1] = 666; else if (CurrentNextHPAP[1] - 333 < 0) CurrentNextHPAP[1] = 333;
                        NewMaximumX(Super1.MaxAP < 666 ? new UInt16[] { 333, Shrt(CurrentNextHPAP[1] - 333) } : new UInt16[] { 333, 333, Shrt(CurrentNextHPAP[1] - 666) }, Super1.MaxAP < 666 ? new ProgressBar[] { AfterAPbar, AfterAPbarOver333 } : new ProgressBar[] { AfterAPbar, AfterAPbarOver333, AfterAPbarOver666 });
                        AnyShowX(Super1.MaxAP < 666 ? new ProgressBar[] { AfterAPbarOver333 } : new ProgressBar[] { AfterAPbarOver333, AfterAPbarOver666 });
                    }
                    FastTextChange(new Label[] { AddAP, AfterAP }, new string[] { "+" + (Super1.MaxAP - CurrentNextHPAP[1]), Super1.CurrentAP + "/" + CurrentNextHPAP[1] });
                }
                else LabHide(AddAP);
                CustomAddStat(0, Super1.Attack, AddATK, AfterATK);
                CustomAddStat(1, Super1.Defence, AddDEF, AfterDEF);
                CustomAddStat(2, Super1.Speed, AddAG, AfterAG);
                CustomAddStat(3, Super1.Special, AddSP, AfterSP);
            }
            else
            {
                MaxAndWidthHPcalculate();
                MaxAndWidthAPcalculate();
                LabHideX(new Label[] { AddHP, AddAP, AddATK, AddDEF, AddAG, AddSP });
                ButtonShow(TextOk1);
                return true;
            }
            return false;
        }
        private void AllDmgTimeTextChangeConstruction(in UInt16 ActionPower)
        {
            Label[] Labs = new Label[] { DamageFoe, DamageFoe2, DamageFoe3 };
            for (Byte i = 0; i < 3; i++) Labs[i].Content = Foe1.EnemyHP[i] > 0 ? ActionPower : Labs[i].Content;
        }

        //[EN] Game interactive documentation
        //[RU] Игровое интерактивное руководство.
        private void InfoImgs_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = sender as Image;
            string[,] inf = { { Path.AftMInfoImgs.Help1_1, Path.AftMInfoImgs.Help2_1, Path.AftMInfoImgs.Help3_1, Path.AftMInfoImgs.Help4_1, Path.AftMInfoImgs.Help5_1, Path.AftMInfoImgs.Help6_1, Path.AftMInfoImgs.Help7_1, Path.AftMInfoImgs.Help8_1, Path.AftMInfoImgs.Help9_1, Path.AftMInfoImgs.Help10_1, Path.AftMInfoImgs.Help11_1, Path.AftMInfoImgs.Help12_1, Path.AftMInfoImgs.Help13_1, Path.AftMInfoImgs.Help14_1, Path.AftMInfoImgs.Help15_1, Path.AftMInfoImgs.Help16_1, Path.AftMInfoImgs.Help17_1, Path.AftMInfoImgs.Help18_1, Path.AftMInfoImgs.Help19_1 },
            { Path.AftMInfoImgs.Help1_2, Path.AftMInfoImgs.Help2_2, Path.AftMInfoImgs.Help3_2, Path.AftMInfoImgs.Help4_2, Path.AftMInfoImgs.Help5_2, Path.AftMInfoImgs.Help6_2, Path.AftMInfoImgs.Help7_2, Path.AftMInfoImgs.Help8_2, Path.AftMInfoImgs.Help9_2, Path.AftMInfoImgs.Help10_2, Path.AftMInfoImgs.Help11_2, Path.AftMInfoImgs.Help12_2, Path.AftMInfoImgs.Help13_2, Path.AftMInfoImgs.Help14_2, Path.AftMInfoImgs.Help15_2, Path.AftMInfoImgs.Help16_2, Path.AftMInfoImgs.Help17_2, Path.AftMInfoImgs.Help18_2, Path.AftMInfoImgs.Help19_2 },
            { Path.AftMInfoImgs.Help1_3, Path.AftMInfoImgs.Help2_3, Path.AftMInfoImgs.Help3_3, Path.AftMInfoImgs.Help4_3, Path.AftMInfoImgs.Help5_3, Path.AftMInfoImgs.Help6_3, Path.AftMInfoImgs.Help7_3, Path.AftMInfoImgs.Help8_3, Path.AftMInfoImgs.Help9_3, Path.AftMInfoImgs.Help10_3, Path.AftMInfoImgs.Help11_3, Path.AftMInfoImgs.Help12_3, Path.AftMInfoImgs.Help13_3, Path.AftMInfoImgs.Help14_3, Path.AftMInfoImgs.Help15_3, Path.AftMInfoImgs.Help16_3, Path.AftMInfoImgs.Help17_3, Path.AftMInfoImgs.Help18_3, Path.AftMInfoImgs.Help19_3 } };
            img.Source = Bmper(inf[Bits(img.Tag), Txt.Doc.InfoChange1]);
        }
        private void InfoImgs_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = sender as Image;
            string[,] inf = { { Path.BefMInfoImgs.Help1_1, Path.BefMInfoImgs.Help2_1, Path.BefMInfoImgs.Help3_1, Path.BefMInfoImgs.Help4_1, Path.BefMInfoImgs.Help5_1, Path.BefMInfoImgs.Help6_1, Path.BefMInfoImgs.Help7_1, Path.BefMInfoImgs.Help8_1, Path.BefMInfoImgs.Help9_1, Path.BefMInfoImgs.Help10_1, Path.BefMInfoImgs.Help11_1, Path.BefMInfoImgs.Help12_1, Path.BefMInfoImgs.Help13_1, Path.BefMInfoImgs.Help14_1, Path.BefMInfoImgs.Help15_1, Path.BefMInfoImgs.Help16_1, Path.BefMInfoImgs.Help17_1, Path.BefMInfoImgs.Help18_1, Path.BefMInfoImgs.Help19_1 },
            { Path.BefMInfoImgs.Help1_2, Path.BefMInfoImgs.Help2_2, Path.BefMInfoImgs.Help3_2, Path.BefMInfoImgs.Help4_2, Path.BefMInfoImgs.Help5_2, Path.BefMInfoImgs.Help6_2, Path.BefMInfoImgs.Help7_2, Path.BefMInfoImgs.Help8_2, Path.BefMInfoImgs.Help9_2, Path.BefMInfoImgs.Help10_2, Path.BefMInfoImgs.Help11_2, Path.BefMInfoImgs.Help12_2, Path.BefMInfoImgs.Help13_2, Path.BefMInfoImgs.Help14_2, Path.BefMInfoImgs.Help15_2, Path.BefMInfoImgs.Help16_2, Path.BefMInfoImgs.Help17_2, Path.BefMInfoImgs.Help18_2, Path.BefMInfoImgs.Help19_2 },
            { Path.BefMInfoImgs.Help1_3, Path.BefMInfoImgs.Help2_3, Path.BefMInfoImgs.Help3_3, Path.BefMInfoImgs.Help4_3, Path.BefMInfoImgs.Help5_3, Path.BefMInfoImgs.Help6_3, Path.BefMInfoImgs.Help7_3, Path.BefMInfoImgs.Help8_3, Path.BefMInfoImgs.Help9_3, Path.BefMInfoImgs.Help10_3, Path.BefMInfoImgs.Help11_3, Path.BefMInfoImgs.Help12_3, Path.BefMInfoImgs.Help13_3, Path.BefMInfoImgs.Help14_3, Path.BefMInfoImgs.Help15_3, Path.BefMInfoImgs.Help16_3, Path.BefMInfoImgs.Help17_3, Path.BefMInfoImgs.Help18_3, Path.BefMInfoImgs.Help19_3 } };
            img.Source = Bmper(inf[Bits(img.Tag), Txt.Doc.InfoChange1]);
        }
        private void GameHint()
        {
            string[,] inf = { { Path.BefMInfoImgs.Help1_1, Path.BefMInfoImgs.Help2_1, Path.BefMInfoImgs.Help3_1, Path.BefMInfoImgs.Help4_1, Path.BefMInfoImgs.Help5_1, Path.BefMInfoImgs.Help6_1, Path.BefMInfoImgs.Help7_1, Path.BefMInfoImgs.Help8_1, Path.BefMInfoImgs.Help9_1, Path.BefMInfoImgs.Help10_1, Path.BefMInfoImgs.Help11_1, Path.BefMInfoImgs.Help12_1, Path.BefMInfoImgs.Help13_1, Path.BefMInfoImgs.Help14_1, Path.BefMInfoImgs.Help15_1, Path.BefMInfoImgs.Help16_1, Path.BefMInfoImgs.Help17_1, Path.BefMInfoImgs.Help18_1, Path.BefMInfoImgs.Help19_1 },
            { Path.BefMInfoImgs.Help1_2, Path.BefMInfoImgs.Help2_2, Path.BefMInfoImgs.Help3_2, Path.BefMInfoImgs.Help4_2, Path.BefMInfoImgs.Help5_2, Path.BefMInfoImgs.Help6_2, Path.BefMInfoImgs.Help7_2, Path.BefMInfoImgs.Help8_2, Path.BefMInfoImgs.Help9_2, Path.BefMInfoImgs.Help10_2, Path.BefMInfoImgs.Help11_2, Path.BefMInfoImgs.Help12_2, Path.BefMInfoImgs.Help13_2, Path.BefMInfoImgs.Help14_2, Path.BefMInfoImgs.Help15_2, Path.BefMInfoImgs.Help16_2, Path.BefMInfoImgs.Help17_2, Path.BefMInfoImgs.Help18_2, Path.BefMInfoImgs.Help19_2 },
            { Path.BefMInfoImgs.Help1_3, Path.BefMInfoImgs.Help2_3, Path.BefMInfoImgs.Help3_3, Path.BefMInfoImgs.Help4_3, Path.BefMInfoImgs.Help5_3, Path.BefMInfoImgs.Help6_3, Path.BefMInfoImgs.Help7_3, Path.BefMInfoImgs.Help8_3, Path.BefMInfoImgs.Help9_3, Path.BefMInfoImgs.Help10_3, Path.BefMInfoImgs.Help11_3, Path.BefMInfoImgs.Help12_3, Path.BefMInfoImgs.Help13_3, Path.BefMInfoImgs.Help14_3, Path.BefMInfoImgs.Help15_3, Path.BefMInfoImgs.Help16_3, Path.BefMInfoImgs.Help17_3, Path.BefMInfoImgs.Help18_3, Path.BefMInfoImgs.Help19_3 } };
            FastImgChange(new Image[] { InfoImg1, InfoImg2, InfoImg3 }, BmpersToX(Bmper(inf[0, Txt.Doc.InfoChange1]), Bmper(inf[1, Txt.Doc.InfoChange1]), Bmper(inf[2, Txt.Doc.InfoChange1])));
        }
        private void GameStartBtns_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = ((Button)sender).Content as Image;
            img.Source = Bmper(sender.Equals(Button1) ? Path.Adv.AfterNewAdv : Path.Adv.AfterConAdv);
        }
        private void GameStartBtns_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = ((Button)sender).Content as Image;
            img.Source = Bmper(sender.Equals(Button1) ? Path.Adv.BeforeNewAdv : Path.Adv.BeforeConAdv);
        }
        private void MediaErrorEncountered(object sender, ExceptionRoutedEventArgs e)
        {
            throw new Exception("The video got some Exception! Read the message: \n" + e);
        }
        private void Learn_Click(object sender, RoutedEventArgs e)
        {
            if (Super1.CurrentAP >= 2)
            {
                Sets.SelectedTarget = Bits(Sets.SelectedTarget > 2 ? 0 : Sets.SelectedTarget);
                SelectedTrgt = Sets.SelectedTarget;
                SelectTarget();
                AnyHide(SkillsMenu);
                AnyShowX(SelectMenuSkills, ACT4);
            }
        }
        private void ACT4_Click(object sender, RoutedEventArgs e)
        {
            LearnFoe();
            Super1.CurrentAP -= 2;
            CurrentAPcalculate();
            AnyHideX(EnemyStatus, TrgtImg, SelectMenuSkills, ACT4);
            Dj(Path.GameNoises.Learn);
            TimerOn(ref Pearn, new TimeSpan(0,0,0,0,Shrt(25/GameSpeed.Value)));
            TimerOff(ref Targt);
        }
        private void Skip1_MouseEnter(object sender, MouseEventArgs e) { SkipImg.Source = Bmper(Path.Adv.AfterSkip); }
        private void Skip1_MouseLeave(object sender, MouseEventArgs e) { SkipImg.Source = Bmper(Path.Adv.BeforeSkip); }

        private void Genocide_Click(object sender, RoutedEventArgs e)
        {
            AnyShow(AutoTurn);
            AnyHide(FightMenu);
            BadTime();
        }

        private void AutoTurn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = new SolidColorBrush(Color.FromArgb(255, 155, 15, 15));
        }

        private void AutoTurn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Background = new SolidColorBrush(Color.FromArgb(255, 6, 79, 236));
        }

        private void AutoTurn_Click(object sender, RoutedEventArgs e)
        {
            AnyHide((Button)sender);
        }
    }
}