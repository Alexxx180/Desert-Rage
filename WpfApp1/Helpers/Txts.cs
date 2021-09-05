namespace WpfApp1.Helpers
{
    public static class Txts
    {
        public static class Common
        {
            public static string Total = "Всего";
            public static string Hlthy = "Статус: здоров";
            public static string Ill = "Статус: отравлен";
            public static string Exp = "Опыт";
            public static string Lv = "Ур";
            public static string NewLv = "Новый уровень!";
            public static string Won = "Победа!";
            public static string Thres = "Похоже что-то есть...";
            public static string Time = "Время";
            public static string QMark = "Что это?";
            public static string Expert = "Профессионал";
        }
        public static class FightOptions
        {
            public static string Atk = "Атаковать выбранного врага";
            public static string Def = "Встать в стойку (Защита X2)";
            public static string Esc = "Сбежать из боя";
            public static string Inv = "Посмотреть инвентарь";
            public static string Act = "Особые умения";
            public static string Trg = "Подтвердить цель";
            public static string Gen = "Атаковать всех подряд";
            public static string S1 = "Поджечь выбранного врага";
            public static string S2 = "Ударить врага хлыстом";
            public static string S3 = "Подстрелить врага";
            public static string S4 = "Изучить врага";
        }
        public static class CancelOptions
        {
            public static string Fgt = "Отменить нападение";
            public static string Act = "Отменить умение";
            public static string Back = "Обратно к действиям";
        }
        public static class Foes
        {
            public static string Spider = "Паук";
            public static string Mummy = "Мумия";
            public static string Zombie = "Зомби";
            public static string Bones = "Страж";
            public static string Vulture = "Стервятник";
            public static string Ghoul = "Гуль";
            public static string GrimReaper = "Жнец";
            public static string Scarab = "Скарабей";
            public static string KillerMole = "Моль-убийца";
            public static string Imp = "Прислужник";
            public static string Worm = "П. червь";
            public static string Master = "Мастер";
            public static string[] GetFast = new string[] { Spider, Mummy, Zombie, Bones, Vulture, Ghoul, GrimReaper, Scarab, KillerMole, Imp, Worm, Master };
            public static string[,] GetByIndexes = new string[,] { { Spider, Mummy, Zombie, Bones }, { Vulture, Ghoul, GrimReaper, Scarab }, { KillerMole, Imp, Worm, Master } };
        }
        public static class Bosses
        {
            public static string Pharaoh = "Фараон";
            public static string Friend = "????";
            public static string AMaster = "Владыка";
            public static string UghZan = "Угх-зан I";
            public static string[] GetByIndexes = new string[] { Pharaoh, Friend, AMaster, UghZan };
        }
        public static class Docs
        {
            public static byte InfoChange1 = 0;
            public static string[,] HelpInfo1 = new string[,]{ {"Введение","Древние - кто они?","Приключение","Управление","Сражение","Цель боя","Очки здоровья","Урон","Оборона","Побег","Статус","Показатели","Скорость (СКР)","Больше чем бой","Настройки","Проходы","Сундуки","Сила земли","Сцены" },
                {"Неизвестный...","Предыстория","Розыск","Меню/Выход","Противники","Ходы","Очки действий","Бой","Умения","Результаты","Уровень","Атака (АТК)","Спец. (СПЦ)","Бестиарий","Разработал","Стены","Опасности","Погостить пришёл","Благодарности" },
                {"Древние святыни","Артефакты","Главы","Взаимодействие","Боссы","Действия","АВШ","Выбор","Предметы","Прирост","Опыт","Защита (ЗЩТ)","Время игры","Задачи","До новых встреч","Замки","Камни","Секреты","Финансы" } };
            public static string[,] HelpInfo2 = new string[,] { {
                    "Добро пожаловать, искатели\nприключений! Приветствуем\nвас в кратком своде правил.",
                    "Древние - люди, что когда-то\nобладали технологиями, кото-\nрые нам и не снились.",
                    "Вам доступно создание\nнового или загрузка старого\nприключения если оно было",
                    "Клавиатура обязательна\nПередвижение - WASD,\nВзаимодействие - E",
                    "Во время передвижения, на\nвас могут напасть. Не бой-\nтесь сражаться за правое!",
                    "Во время сражения нужно\nубрать всех противников и\nбоссов с поля, не погибнув.",
                    "Определяют какое количе-\nство урона персонаж может\nвзять, прежде чем умереть.",
                    "Числом определяет силу, с\nкоторой бьёт герой или враг,\nприближает к гибели.",
                    "Повышает защиту героя в\nдва раза до следующего\nхода.",
                    "Существует альтернативный\nспособ выйти из сражения -\nизбежать этим действием.",
                    "Выводит состояние героя,\nпри отравлении персонаж\nбудет терять ОЗ.",
                    "Влияют на выживаемость\nгероя, каждый отвечает за\nчто-то своё.",
                    "Влияет на скорость заполне-\nния АВШ и возможность\nсбежать из боя.",
                    "Умения доступны вне боя, а\nещё каждое из них можно\n\"пожамкать\" ^_^.",
                    "Не так-то просто справляться\nс шумом? Слишком яркое\nизображение? Не вопрос!",
                    "Место, по которому может\nходить герой, обычная\nплита.",
                    "Там хранится всевозможное\nоружие и броня древних.\nПочему бы и не одолжить?",
                    "Источники, бьющие прямо\nиз огненных песков лечат\nвсе недомогания.",
                    "Как никогда лучше показы-\nвают происходящее в\nсамом эпицентре событий." },
                {"Вы играете за одарённого\nархеолога Рэя, его целью\nявляется поиск артефактов.",
                    "После глупых войн и жажды\nвласти, люди истратили нас-\n",
                    "Здесь находятся все\nискатели! Можно разделять\nпрогресс с друзьями",
                    "Клавиатура обязательна\nОткрыть меню - Left CTRL\nВыйти из игры - ESC",
                    "Монстры и прочие чудища,\nвышедшие из под контроля\nжаждут вашей гибели",
                    "Действия героя и врагов\nраспределены: они могут\nвыполнять их спустя время",
                    "От ОД зависит доступ к осо-\nбым действиям - умениям,\nвызывающие эффекты",
                    "Опция позволяющая физи-\nчески атаковать врага\nгерою, зависит от АТК.",
                    "Каждое умение тратит ОД и\nможет оказывать эффект\nкак на врага, так и на героя.",
                    "Победив, вы получаете\nопыт, материалы и ве-\nщи в конце сражения.",
                    "Показывает потенциал\nперсонажа, от него за-\nвисят все показатели.",
                    "Урон, наносимый героем\nпри обычной атаке. Может\nбыть увеличена оружием.",
                    "Специальное влияет на силу\nэффектов от использования\nумений персонажа.",
                    "После открытия умения \"Из-\nучение\", вы сможете смот-\nреть показатели врагов",
                    "Прошу любить и жаловать:\nТатаринцев Александр,\nвыступал в роли FullStack.",
                    "Препятствия, через которые\nнельзя передвигаться. Из\nних составлены лабиринты.",
                    "Какое приключение не обо-\nйдётся без опасностей?\nВсё как положено.",
                    "-Алло, это кто?\n-Сэм.\n-Шутник, Сэм, это я.",
                    "Посвящается (Вы лучшие):\nМасленников Денис,\nМасленникова Татьяна" },
                {"Основными местами для\nпоиска сокровищ стали\nсооружения древних.",
                    "Артефакты содержат посла-\nния, лежащие в основе\nключа к мудрости веков",
                    "Приключение рассказывает\nисторию, основные события\nкоторой показаны в главах",
                    "Все нажатия на кнопки\nосуществляются с помощью\nлевой кнопки мыши (ЛКМ)",
                    "Древние стражи и могучие\nвластители, пробудившиеся\nото сна ждут боя.",
                    "Совокупность опций возни-\nкающих около персонажа.\nНужны для победы в бою.",
                    "Активная временная шкала\nпосле заполнения, даёт ход\nгерою, отображая действия.",
                    "Для выбора зоны пораже-\nния. Отмена - вернуться к\nпредыдущим опциям",
                    "Использование предметов,\nполученных после боя или\nсозданных материалами.",
                    "При повышении уровня, по-\nказатели героя вырастут,\nоблегчая новые задачи.",
                    "При сборе достаточного\nколичества - повышает\nуровень.",
                    "Снижает урон, получаемый\nот врагов. Может быть\nувеличена доспехами.",
                    "Всему своё время и приклю-\nчение - не исключение, бе-\nрегите глаза, друзья!",
                    "Для понимания основной\nцели - она разбита на\nзадачи.",
                    "Надеюсь данное руководст-\nво было вам полезно, даль-\nше для общего развития =)",
                    "Закрытые проходы, веду-\nщие через путь к выходу\nк артефактам. ",
                    "Артефакты - ключи, ведущие\nк сокровищам, эта основная\nцель приключения.",
                    "Каждое сооружение хранит\nсвои секреты. Сможете ли\nвы отыскать их все?",
                    "А в плане денег - у нас нет\nденег. Поможете ли\nразвитию творчества?" } };
        }
        public static class Hints
        {
            public static string Status = "ОЗ имеет тенденцию падать до 0. Враги только этого и добиваются.\nПохоже что ненадолго.";
            public static string Skills = "Каждое умение становится доступным при достижении определённого\nуровня. Используя их правильно, можно свернуть горы!";
            public static string Items = "Предметы бывают очень полезными как в бою, так и вне боя. Лучше\nвсего перевязывать раны - иначе этот напалм не выдержать.";
            public static string Equip = "Отличное оснащение даёт преимущество в бою.";
            public static string Tasks = "Выполняя задачи нужно оставаться предельно осторожным. Никто не\nзнает, что поджидает в святилищах древних.";
            public static string Infos = "Герой! Контролируй прогресс\nу точек контроля со знаком \"S\"";
            public static string Setts = "Настройки помогают определить предпочтения. Помимо стандартного\nизменения громкости и яркости, вы можете регулировать скорость боя";

            public static string EqWpn1 = "Прочный костяной кастет. Одно из лучших средств показать свою мощь!";
            public static string EqWpn2 = "Закалённый острый кинжал, пробивающий камни насквозь. Крайне\nсмертоносная игрушка.";
            public static string EqWpn3 = "Меч грёз, рассекающий воздух.";
            public static string EqWpn4 = "Размер не имеет  значения, главное как его используют";
            public static string EqArm1 = "Черная кожаная куртка. Никто не ценит ничего так сильно, как\nнадёжный кожак в жуткую погоду.";
            public static string EqArm2 = "Отлично сохранившиеся доспехи древних воинов. Кажется, что\nради хороших вещей древние даже золота не жалели.";
            public static string EqArm3 = "Нагрудник, отполированный настолько, что в нём видно отражение\n приближающихся врагов.";
            public static string EqArm4 = "Футболка для настоящих ценителей";
            public static string EqPnt1 = "Такие штаны сгодятся разве что на огородное пугало.";
            public static string EqPnt2 = "Четко отделанные поножи древних воинов со стершейся позолотой.";
            public static string EqPnt3 = "Легендарные штаны, способные защитить даже от прямого\nпадения на кактус.";
            public static string EqPnt4 = "Выбор истинных легенд.";
            public static string EqBts1 = "Бинтовая обувь. Спасает от ужасной жары здешних песков как никогда.";
            public static string EqBts2 = "Сапоги прирождённых солдат, покрыты слоём железа и укрепл-\nены пластинами.";
            public static string EqBts3 = "Невесомые сапоги, из невероятно прочного материала.";
            public static string EqBts4 = "Прочные сапоги из натуральной дублёной кожи";

            public static string Wrn1 = "Пора передохнуть...";
            public static string Wrn2 = "Эй, это уже не шутки!";
            public static string Wrn3 = "Срочно выключай машину!";
        }
        public static class Sections
        {
            public static string Status = "Статус героя";
            public static string Skills = "Умения героя";
            public static string Items = "Предметы";
            public static string Equip = "Снаряжение героя";
            public static string Tasks = "Текущие цели";
            public static string Infos = "Руководство игрока";
            public static string Setts = "Настройки";
        }
        public static class Abililities
        {
            public static string Cure = "Восстановление ОЗ, [-5 ОД]";
            public static string Cure2 = "ОЗ 100% мгновенно, [-10 ОД]";
            public static string Heal = "Лечение статуса, [-3 ОД]";
            public static string Buffs = "Повышает атаку, [-12 ОД]";
            public static string Tough = "Повышает защиту, [-8 ОД]";
            public static string Regen = "Постепенно ОЗ+, [-15 ОД]";
            public static string Control = "Постепенно ОД+, [0 ОД]";
            public static string Torch = "Поджигает врагов, [-4 ОД]";
            public static string Whip = "Дробит кости, [-6 ОД]";
            public static string Throw = "Подстрелить врага, [-15 ОД]";
            public static string Spec1 = "Мощное комбо, [-10 ОД]";
            public static string Spec2 = "Порезы ветром, [-20 ОД]";
            public static string Spec3 = "Обвал камнями, [-30 ОД]";
            public static string Learn = "Анализ врага, [-2 ОД]";
        }
        public static class BItems
        {
            public static string Ant = "-Яд";
            public static string Ban = "+50 ОЗ";
            public static string Etr = "+50 ОД";
            public static string Bld = "+80 ОЗ|ОД";
            public static string Hrb = "+350 ОЗ";
            public static string Er2 = "+300 ОД";
            public static string Slb = "100% ОЗ|ОД";
            public static string Elx = "100% ОЗ|ОД";
        }
        public static class Goals
        {
            public static string T1 = "Найдите способ открыть дверь";
            public static string T2 = "Соберите другой ключ";
            public static string T3 = "Соберите последний ключ";
            public static string T4 = "Проверьте загадочный артефакт";
            public static string T5 = "Другой способ открыть врата";
            public static string T6 = "Откройте путь до артефакта";
            public static string T7 = "Проверьте загадочный артефакт";
            public static string T8 = "Переправа через пропасть";
            public static string T9 = "Заберите последний ключ";
            public static string T10 = "Выберетесь из лабиринта до обвала!";
            public static string E1 = "Найдите и изучите древнее чудовище";
            public static string E2 = "Найдите золотой анх";
            public static string E3 = "Найдите фрагмент удачи";
        }
        public static class Equipment
        {
            public static class Hands
            {
                public const string Bare = "Пустые руки";
                public const string Duster = "Костяной кастет";
                public const string Knife = "Древний кинжал";
                public const string Sword = "Меч легенды";
                public const string Minigun = "Миниган XM214-A";
            }
            public static class Torso
            {
                public const string Bare = "Лёгкая рубашка";
                public const string Bcoat = "Чёрный кожак";
                public const string Ancient = "Древняя броня";
                public const string Legend = "Броня легенды";
                public const string Serious = "Футболка крутого";
            }
            public static class Anckles
            {
                public const string Bare = "Стильные штаны";
                public const string Vulture = "Штаны стервятника";
                public const string Ancient = "Древние поножи";
                public const string Legend = "Поножи легенды";
                public const string Serious = "Штаны серьёзного";
            }
            public static class Boots
            {
                public const string Bare = "Начищенные ботинки";
                public const string Bboots = "Бинтовая обувь";
                public const string Ancient = "Древние сапоги";
                public const string Legend = "Сапоги легенды";
                public const string Serious = "Армейские ботинки";
            }
        }
    }
}
