using System;
using static DesertRage.Helpers.Paths;

namespace DesertRage.Helpers
{
    //[EN] Class of hero parameters, like Max Health (HP), Attack and other.
    //[RU] Класс параметров героя, таких как Макс. Здоровье (ОЗ), Атака и прочее.
    public class Characteristics
    {
        public ushort MaxHP { get; set; }
        public ushort MaxAP { get; set; }
        public ushort CurrentHP { get; set; }
        public ushort CurrentAP { get; set; }
        public byte Attack { get; set; }
        public byte Defence { get; set; }
        public byte Speed { get; set; }
        public byte Special { get; set; }
        public ushort Learned { get; set; }
        public byte CurrentLevel { get; set; }
        public byte PlayerStatus { get; set; }
        public byte DefenseState { get; set; }
        public ushort[] NextLevel { get; set; }
        public ushort[] MaxHPNxt { get; set; }
        public ushort[] MaxAPNxt { get; set; }
        public byte[] AttackNxt { get; set; }
        public byte[] DefenseNxt { get; set; }
        public byte[] SpeedNxt { get; set; }
        public byte[] SpecialNxt { get; set; }
        public byte MenuTask { get; set; }
        public byte SeriousBonus { get; set; }
        public bool MiniTask { get; set; }
        public ushort Experience { get; set; }
        //public Weapon Weapon { get; set; }
        //public Armor Armor { get; set; }
        //public Armor Legs { get; set; }
        //public Armor Boots { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Characteristics()
        {

            //[EN] PLAYER STATS
            //[RU] СТАТУС ИГРОКА

            //[EN] Current player's level and exp to the next level
            //[RU] Текущий уровень игрока и количество опыта необходимое для достижения следующего.
            CurrentLevel = 1;
            NextLevel = new ushort[] { 15, 24, 38, 61, 98, 112, 150, 177, 200, 250, 420, 770, 1170, 1595, 2045, 2520, 3020, 3620, 4320, 5080, 6020, 7500, 8750, 10000, 0 };

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
            MaxHPNxt = new ushort[] { 100, 110, 121, 132, 145, 159, 174, 192, 221, 250, 282, 312, 350, 391, 436, 485, 532, 582, 633, 686, 741, 800, 862, 930, 999 };
            MaxAPNxt = new ushort[] { 40, 44, 48, 53, 58, 64, 70, 77, 85, 100, 121, 147, 200, 267, 342, 395, 478, 540, 570, 600, 785, 840, 890, 940, 999 };
            AttackNxt = new byte[] { 25, 28, 31, 34, 40, 45, 52, 63, 70, 85, 102, 109, 116, 124, 132, 141, 150, 160, 171, 182, 194, 206, 219, 230, 255 };
            DefenseNxt = new byte[] { 15, 17, 19, 21, 25, 30, 33, 37, 45, 50, 66, 81, 88, 96, 110, 119, 136, 146, 157, 175, 187, 199, 211, 225, 255 };
            SpeedNxt = new byte[] { 15, 17, 19, 21, 23, 25, 28, 31, 35, 39, 40, 42, 45, 48, 53, 61, 74, 95, 116, 137, 158, 179, 200, 221, 255 };
            SpecialNxt = new byte[] { 25, 30, 35, 40, 45, 50, 60, 65, 75, 100, 105, 110, 120, 125, 130, 140, 145, 160, 175, 185, 200, 210, 225, 240, 255 };

            //[EN] PLAYER CURRENT EQUIP
            //[RU] ТЕКУЩАЯ ЭКИПИРОВКА
            //PlayerEQ = new byte[] { 0, 0, 0, 0 };
            SeriousBonus = 0;
            //Weapon = BareHands;
            //Armor = Shirt;
            //Legs = Pants;
            //Boots = CleanBoots;

            //[EN] PLAYER STATUS IN AND OUT OF BATTLE
            //[RU] СТАТУС ИГРОКА В И ВНЕ БОЯ
            DefenseState = 1;
            PlayerStatus = 0;
            MenuTask = 0;
            MiniTask = false;
            Experience = 0;
            X = 0;
            Y = 0;
        }
        public void SetStats(in byte Level)
        {
            CurrentLevel = Convert.ToByte(Level + 1);
            MaxHP = MaxHPNxt[Level];
            MaxAP = MaxAPNxt[Level];
            Attack = AttackNxt[Level];
            Defence = DefenseNxt[Level];
            Speed = SpeedNxt[Level];
            Special = SpecialNxt[Level];
        }
        public object[] GetPlayerRecord(in string login)
        {
            return new object[] { login, CurrentLevel, MenuTask, CurrentHP, CurrentAP, Experience, MiniTask, Learned, true };
        }

        //public void SetAllEquip(in byte weapon, in byte armor, in byte legs, in byte boots)
        //{
        //    Weapon[] weapons = { BareHands, Knuckle, Knife, Sword, Minigun };
        //    for (byte i = 0; i < weapons.Length; i++)
        //        if (weapons[i].Power == weapon)
        //        {
        //            Weapon = weapons[i];
        //            break;
        //        }
        //    Armor[] armors = { Shirt, BlackCoat, AncientArmor, LegendArmor, CoolTShirt };
        //    for (byte i = 0; i < armors.Length; i++)
        //        if (armors[i].Power == armor)
        //        {
        //            Armor = armors[i];
        //            break;
        //        }
        //    Armor[] pants = { Pants, FeatherPants, WarriorPants, LegendPants, SeriousPants };
        //    for (byte i = 0; i < pants.Length; i++)
        //        if (pants[i].Power == legs)
        //        {
        //            Legs = pants[i];
        //            break;
        //        }
        //    Armor[] boot = { CleanBoots, BandageBoots, ManBoots, LegendBoots, SeriousBoots };
        //    for (byte i = 0; i < boot.Length; i++)
        //        if (boot[i].Power == boots)
        //        {
        //            Boots = boot[i];
        //            break;
        //        }
        //}

        //public static Weapon BareHands = new Weapon(Txts.Equipment.Hands.Bare, "Weapon", "", OST.Noises.HandAttack, 0, 0, Dynamic.Person.HdAttack, Dynamic.Icon.HdAttack);
        //public static Weapon Knuckle = new Weapon(Txts.Equipment.Hands.Duster, "Weapon", Txts.Hints.EqWpn1, OST.Noises.HandAttack, 10, 203, Dynamic.Person.HdAttack, Dynamic.Icon.HdAttack);
        //public static Weapon Knife = new Weapon(Txts.Equipment.Hands.Knife, "Weapon", Txts.Hints.EqWpn2, OST.Noises.Knife, 50, 206, Dynamic.Person.KnAttack, Dynamic.Icon.KnAttack);
        //public static Weapon Sword = new Weapon(Txts.Equipment.Hands.Sword, "Weapon", Txts.Hints.EqWpn3, OST.Noises.Sword, 200, 212, Dynamic.Person.SwAttack, Dynamic.Icon.SwAttack);
        //public static Weapon Minigun = new Weapon(Txts.Equipment.Hands.Minigun, "Weapon", Txts.Hints.EqWpn4, OST.Noises.Minigun, 255, 226, Dynamic.Person.MgAttack, Dynamic.Icon.MgAttack);

        //public static Armor Shirt = new Armor(Txts.Equipment.Torso.Bare, "Armor", "", 0, 0);
        //public static Armor BlackCoat = new Armor(Txts.Equipment.Torso.Bcoat, "Armor", Txts.Hints.EqArm1, 5, 201);
        //public static Armor AncientArmor = new Armor(Txts.Equipment.Torso.Ancient, "Armor", Txts.Hints.EqArm2, 25, 208);
        //public static Armor LegendArmor = new Armor(Txts.Equipment.Torso.Legend, "Armor", Txts.Hints.EqArm3, 90, 210);
        //public static Armor CoolTShirt = new Armor(Txts.Equipment.Torso.Serious, "Armor", Txts.Hints.EqArm4, 115, 191);

        //public static Armor Pants = new Armor(Txts.Equipment.Anckles.Bare, "Legs", "", 0, 0);
        //public static Armor FeatherPants = new Armor(Txts.Equipment.Anckles.Vulture, "Legs", Txts.Hints.EqPnt1, 4, 204);
        //public static Armor WarriorPants = new Armor(Txts.Equipment.Anckles.Ancient, "Legs", Txts.Hints.EqPnt2, 15, 205);
        //public static Armor LegendPants = new Armor(Txts.Equipment.Anckles.Legend, "Legs", Txts.Hints.EqPnt3, 65, 211);
        //public static Armor SeriousPants = new Armor(Txts.Equipment.Anckles.Serious, "Legs", Txts.Hints.EqPnt4, 85, 213);

        //public static Armor CleanBoots = new Armor(Txts.Equipment.Boots.Bare, "Boots", "", 0, 0);
        //public static Armor BandageBoots = new Armor(Txts.Equipment.Boots.Bboots, "Boots", Txts.Hints.EqBts1, 1, 202);
        //public static Armor ManBoots = new Armor(Txts.Equipment.Boots.Ancient, "Boots", Txts.Hints.EqBts2, 10, 207);
        //public static Armor LegendBoots = new Armor(Txts.Equipment.Boots.Legend, "Boots", Txts.Hints.EqBts3, 40, 209);
        //public static Armor SeriousBoots = new Armor(Txts.Equipment.Boots.Serious, "Boots", Txts.Hints.EqBts4, 55, 255);
    }
}