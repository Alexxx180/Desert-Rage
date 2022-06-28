using DesertRage.Model.Menu.Things.Logic;
using System.Collections.Generic;

namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class NextStats
    {
        public Bar[] Hp { get; set; }
        public Bar[] Ap { get; set; }

        public BattleStats[] Stats { get; set; }
        public Dictionary<string, SkillsID> Skills { get; set; }
    }
}