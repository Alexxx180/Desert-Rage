using DesertRage.Model.Locations.Map;
using System.Collections.Generic;

namespace DesertRage.Model.Locations
{
    public class Location
    {
        public string[] Map { get; set; }

        public Dictionary
            <Position, MapObject>
            MapItems { get; set; }

        public void CompeteTask(int taskNo)
        {
            Tasks.Complete(taskNo);
        }

        public void CompleteOther(int taskNo)
        {
            Other.Complete(taskNo);
        }

        internal Quests Tasks { get; set; }
        internal Quests Other { get; set; }
    }
}