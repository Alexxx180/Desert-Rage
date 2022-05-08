using DesertRage.Model.Locations.Map;

namespace DesertRage.Model.Stats.Enemy
{
    // Enemy logic
    public class Foe : DescriptionUnit
    {
        public Foe()
        {

        }

        public Foe(Foe foe) : base(foe)
        {
            No = foe.No;

            Hp = foe.Hp;

            Stats = foe.Stats;
            Agility = foe.Agility;

            Turn = foe.Turn;

            Action = foe.Action;
            Death = foe.Death;

            Experience = foe.Experience;
            DropRate = foe.DropRate;

            Turn = 0;
        }

        public EnemyBestiary No { get; set; }
        public Position Size { get; set; }

        public Bar Hp { get; set; }

        public BattleStats Stats { get; set; }
        public byte Agility { get; set; }
        public byte Turn { get; set; }

        public string Action { get; set; }
        public string Death { get; set; }

        public byte Experience { get; set; }
        public byte DropRate { get; set; }
    }
}