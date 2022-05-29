namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class NextStats
    {
        public Bar[] Experience { get; set; }

        public Bar[] Hp { get; set; }
        public Bar[] Ap { get; set; }

        public BattleStats[] Stats { get; set; }
    }
}