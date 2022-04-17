namespace DesertRage.Model.Stats.Enemy
{
    // Enemy logic
    public class Foe
    {
        public Foe(Foe foe)
        {
            No = foe.No;

            Name = foe.Name;
            FoeProfile = foe.FoeProfile;

            Hp = foe.Hp;

            Stats = foe.Stats;
            Agility = foe.Agility;

            Weak = foe.Weak;

            Turn = foe.Turn;

            Animate = foe.Animate;
            Death = foe.Death;

            Materials = foe.Materials;
            Experience = foe.Experience;
            DropRate = foe.DropRate;

            Turn = 0;
        }

        public byte No { get; set; }
        public string Name { get; set; }

        public Profile FoeProfile { get; set; }

        public Bar Hp { get; set; }

        public BattleStats Stats { get; set; }
        public byte Agility { get; set; }

        public string Weak { get; set; }

        public byte Turn { get; set; }

        public string[] Animate { get; set; }
        public string Death { get; set; }

        public byte Experience { get; set; }
        public byte Materials { get; set; }
        public byte DropRate { get; set; }
    }
}