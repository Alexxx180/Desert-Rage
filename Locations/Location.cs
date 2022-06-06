using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using System.Collections.Generic;

namespace DesertRage.Model.Locations
{
    public class Location
    {
        public string Name { get; set; }

        public char[][] Map { get; set; }
        public string BackCover { get; set; }

        public Position Start { get; set; }

        public Position Danger { get; set; }
        public EnemyBestiary[] StageFoes { get; set; }
        public Dictionary<string, EnemyBestiary> Bosses { get; set; }

        public Dictionary<string, string> Messages { get; set; }
        public Dictionary<string, Position> Gates { get; set; }
        public Dictionary<string, ArmoryElement> Equipment { get; set; }

        public Dictionary<string, string> TileCodes { get; set; }
    }
}