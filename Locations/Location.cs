using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Map;
using System.Collections.Generic;

namespace DesertRage.Model.Locations
{
    public class Location : Unit
    {
        public void Set(Location next)
        {
            base.Set(next);
            Messages = next.Messages;
        }

        public Floor Area { get; set; }
        public Dictionary<string, string> Messages { get; set; }
    }
}
