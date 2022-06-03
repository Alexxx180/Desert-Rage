using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Map;
using System.Collections.Generic;

namespace DesertRage.Model.Locations
{
    public class Location
    {
        public string Name { get; set; }

        public string[] Map { get; set; }
        public string BackCover { get; set; }

        public Position Start { get; set; }

        public Position Danger { get; set; }
        public EnemyBestiary[] StageFoes { get; set; }
        public EnemyBestiary StageBoss { get; set; }

        public Dictionary<string, string> TileCodes { get; set; }
        public Dictionary<string, MapObject> MapItems { get; set; }
    }
}