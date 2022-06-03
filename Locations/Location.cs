using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using System.Collections.Generic;
using System.Text;

namespace DesertRage.Model.Locations
{
    public class Location
    {
        public string Name { get; set; }

        public StringBuilder[] Map { get; set; }
        public string BackCover { get; set; }

        public Position Start { get; set; }

        public Position Danger { get; set; }
        public EnemyBestiary[] StageFoes { get; set; }
        public EnemyBestiary StageBoss { get; set; }

        public Dictionary<string, string> TileCodes { get; set; }

        public Dictionary<string, string> Messages { get; set; }
        public Dictionary<string, Position> Gates { get; set; }
        public Dictionary<string, Equipment> Equipment { get; set; }
    }
}