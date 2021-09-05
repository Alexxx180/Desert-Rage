namespace WpfApp1.Helpers
{
    //[EN] Foe class, influence on new enemies.
    //[RU] Класс противник, определяет новых противников возникающих в бою.
    public class Foe
    {
        public Foe(Foe foe) : this(foe.No, foe.Name, foe.Attack, foe.Defence, foe.Agility, foe.Speed, foe.MaxHP, foe.Materials, foe.Experience, foe.DropRate,
            foe.Icon, foe.Image, foe.Animate, foe.Death, foe.Weak) { }

        public Foe(byte no, string name, in byte attack, in byte defence, in byte agility, in byte special, in ushort maxHp, in byte materials,
            in byte experience, in byte dropRate, string icon, string image, string[] animate, string death, string weak)
        {
            No = no;
            Name = name;
            Icon = icon;
            Image = image;
            Animate = animate;
            Death = death;
            Weak = weak;
            PreStats(attack, defence, agility, special, maxHp, experience, materials, dropRate);
        }
        public Foe(ushort maxHp, string icon, string name)
        {
            MaxHP = maxHp;
            HP = 0;
            Icon = icon;
            Name = name;
        }
        public void PreStats(in byte at, in byte df, in byte ag, in byte sp, in ushort mhp, in byte mat, in byte exp, in byte rate)
        {
            Attack = at;
            Defence = df;
            Speed = ag;
            Agility = sp;
            HP = MaxHP = mhp;
            Materials = mat;
            Experience = exp;
            DropRate = rate;
            Turn = 0;
        }

        public ushort HP { get; set; }
        public ushort MaxHP { get; set; }
        public byte Attack { get; set; }
        public byte Defence { get; set; }
        public byte Speed { get; set; }
        public byte Agility { get; set; }
        public byte Experience { get; set; }
        public byte Materials { get; set; }
        public byte DropRate { get; set; }
        public byte No { get; set; }
        public byte Turn { get; set; }
        public string Weak { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string[] Animate { get; set; }
        public string Death { get; set; }
    }
}
