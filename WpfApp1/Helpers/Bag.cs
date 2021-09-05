using System;
using System.Collections;

namespace WpfApp1.Helpers
{
    //[EN] Bag class, depends on items getting and used in/out battle
    //[RU] Класс мешка с вещами, зависит от вещей, получаемых и используемых в/вне боя
    public class Bag : Characteristics
    {
        public Items Bandage { get; set; }
        public Items Antidote { get; set; }
        public Items Ether { get; set; }
        public Items Fused { get; set; }
        public Items Herbs { get; set; }
        public Items Ether2 { get; set; }
        public Items SleepBag { get; set; }
        public Items Elixir { get; set; }
        public bool Hands { get; set; }
        public BitArray Weapons { get; set; }
        public bool Jacket { get; set; }
        public BitArray Armors { get; set; }
        public bool Leggings { get; set; }
        public BitArray Panties { get; set; }
        public bool Foots { get; set; }
        public BitArray ArmBoots { get; set; }
        public ushort Materials { get; set; }
        public Bag()
        {
            SetEquip();
            SetItems();
        }

        //[EN] Initialize empty slots of equipment
        //[RU] Метод для обозначения слотов экипировки
        public void SetEquip()
        {
            Hands = false;
            Jacket = false;
            Leggings = false;
            Foots = false;
            Weapons = new BitArray(new bool[4]);
            Armors = new BitArray(new bool[4]);
            Panties = new BitArray(new bool[4]);
            ArmBoots = new BitArray(new bool[4]);
        }
        public void ReEquip(in string name, bool value)
        {
            switch (name)
            {
                case Txts.Equipment.Hands.Bare: Hands = value; break;
                case Txts.Equipment.Torso.Bare: Jacket = value; break;
                case Txts.Equipment.Anckles.Bare: Leggings = value; break;
                case Txts.Equipment.Boots.Bare: Foots = value; break;
                default: break;
            }
        }

        //[EN] Initialize items count method
        //[RU] Метод для обозначения хранения каждого вида предметов
        public void SetItems()
        {
            Bandage = new Items("Bandage", Txts.BItems.Ban, 20, 50, 0, 1);
            Antidote = new Items("Antidote", Txts.BItems.Ant, 10, 0, 0, 0);
            Ether = new Items("Ether", Txts.BItems.Etr, 70, 0, 50, 1);
            Fused = new Items("Fused", Txts.BItems.Bld, 150, 80, 80, 1);
            Herbs = new Items("Herbs", Txts.BItems.Hrb, 500, 350, 0, 1);
            Ether2 = new Items("Ether2", Txts.BItems.Er2, 1500, 0, 300, 1);
            Elixir = new Items("Elixir", Txts.BItems.Elx, 10000, 999, 999, 1);
            SleepBag = new Items("SleepBag", Txts.BItems.Slb, 100, 999, 999, 1);
        }
        public void SetCount(params byte[] bag)
        {
            Bandage.Count = bag[0];
            Antidote.Count = bag[1];
            Ether.Count = bag[2];
            Fused.Count = bag[3];
            Herbs.Count = bag[4];
            Ether2.Count = bag[5];
            SleepBag.Count = bag[6];
            Elixir.Count = bag[7];
        }
        public void EquipWearSet(in bool equip)
        {
            Hands = equip;
            Jacket = equip;
            Leggings = equip;
            Foots = equip;
        }
        public class Items
        {
            public Items(string name, string description, ushort cost, ushort hpRestore, ushort apRestore, byte statusRestore)
            {
                Name = name;
                Description = description;
                Cost = cost;
                Count = 0;
                HpRestore = hpRestore;
                ApRestore = apRestore;
                StatusRestore = statusRestore;
            }

            public string Name { get; set; }
            public string Description { get; set; }
            public ushort Cost { get; set; }
            public byte Count { get; set; }
            public ushort HpRestore { get; set; }
            public ushort ApRestore { get; set; }
            public byte StatusRestore { get; set; }
        }
    }
}
