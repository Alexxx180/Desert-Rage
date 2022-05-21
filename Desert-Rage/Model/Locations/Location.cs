using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Locations.Map;
using System.Collections.Generic;

namespace DesertRage.Model.Locations
{
    public class Location
    {
        public string Name { get; set; }
        public string[] Map { get; set; }

        public string BackCover { get; set; }

        public Dictionary<string, string> TileCodes { get; set; }
        public Dictionary<string, MapObject> MapItems { get; set; }

        public void CompeteTask(int taskNo)
        {
            Tasks.Complete(taskNo);
        }

        public void CompleteOther(int taskNo)
        {
            Other.Complete(taskNo);
        }

        public static EnemyBestiary[] GetFoes()
        {
            return new EnemyBestiary[]
            {
                EnemyBestiary.Spider,
                EnemyBestiary.Mummy,
                EnemyBestiary.Zombie,
                EnemyBestiary.Bones,
            };
        }

        internal Quests Tasks { get; set; }
        internal Quests Other { get; set; }

        public EnemyBestiary[] StageFoes { get; set; }
        public EnemyBestiary StageBoss { get; set; }
    }
}