namespace DesertRage.Model.Stats
{
    public struct BattleStats
    {
        public BattleStats
            (byte attack, byte defence, byte speed)
        {
            Attack = attack;
            Defence = defence;
            Speed = speed;
        }

        public BattleStats(byte stats) :
            this(stats, stats, stats) { }

        public byte Attack { get; set; }
        public byte Defence { get; set; }
        public byte Speed { get; set; }
    }
}