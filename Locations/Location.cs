using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using System.Collections.Generic;

namespace DesertRage.Model.Locations
{
    public class Location
    {
        public void SetChapter(Location next)
        {
            Name = next.Name;
            NextChapter = next.NextChapter;
            Map = next.Map;
            BackCover = next.BackCover;
            BattleBack = next.BattleBack;
            MusicPeace = next.MusicPeace;
            MusicFight = next.MusicFight;
            Start = next.Start;
            Danger = next.Danger;
            StageFoes = next.StageFoes;
            Bosses = next.Bosses;
            Messages = next.Messages;
            Gates = next.Gates;
            Warps = next.Warps;
            Equipment = next.Equipment;
            TileCodes = next.TileCodes;
        }

        public string Name { get; set; }
        public string NextChapter { get; set; }

        public char[][] Map { get; set; }
        public string BackCover { get; set; }
        public string BattleBack { get; set; }

        public string MusicPeace { get; set; }
        public string MusicFight { get; set; }

        public Position Start { get; set; }

        public Position Danger { get; set; }
        public EnemyBestiary[] StageFoes { get; set; }
        public Dictionary<string, EnemyBestiary> Bosses { get; set; }

        public Dictionary<string, string> Messages { get; set; }
        public Dictionary<string, Position> Gates { get; set; }
        public Dictionary<string, Position> Warps { get; set; }
        public Dictionary<string, ArmoryElement> Equipment { get; set; }

        public Dictionary<string, string> TileCodes { get; set; }
    }
}