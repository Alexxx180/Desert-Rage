namespace DesertRage.Model.Locations.Battle.Stats
{
    public struct BattleStats
    {
        public BattleStats(
            byte attack, byte defence,
            byte speed, byte special
            )
        {
            Attack = attack;
            Defence = defence;
            Speed = speed;
            Special = special;
        }

        public BattleStats(byte stats) :
            this(stats, stats, stats, stats)
        { }

        public byte Attack { get; set; }
        public byte Defence { get; set; }
        public byte Speed { get; set; }
        public byte Special { get; set; }
    }
}