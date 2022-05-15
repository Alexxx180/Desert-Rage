using DesertRage.Model.Locations.Map;

namespace DesertRage.Model.Stats.Enemy
{
    // Enemy logic
    public class Foe : BattleUnit
    {
        public Foe()
        {
            Size = new Position(1);
        }

        public Foe(Foe foe) : base(foe)
        {
            No = foe.No;
            
            Death = foe.Death;

            Tile = foe.Tile;
            Size = foe.Size;

            Experience = foe.Experience;
            DropRate = foe.DropRate;
        }

        public EnemyBestiary No { get; set; }
        public Position Tile { get; set; }
        public Position Size { get; set; }

        public string Death { get; set; }

        public byte Experience { get; set; }
        public byte DropRate { get; set; }
    }
}