using System.Collections.Generic;

namespace DesertRage.Model.Locations.Battle.Things
{
    public class AttributeUnit : NoiseUnit
    {
        public string Command { get; set; }
        public Dictionary<string, float> Attributes { get; set; }
    }
}
