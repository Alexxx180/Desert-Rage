using System.Collections.Generic;

namespace DesertRage.Model.Locations.Battle.Things
{
    public class AttributeUnit : NoiseUnit
    {
        public CommandID Command { get; set; }
        public Dictionary<string, Attribute> Attributes { get; set; }
    }
}
