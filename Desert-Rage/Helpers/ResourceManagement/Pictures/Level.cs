using System.Collections.Generic;

namespace DesertRage.Helpers.ResourceManagement.Pictures
{
    public class Level : Images
    {
        protected string LevelPrefix = @"Locations\";

        public override string BuildPath(string name)
        {
            return base.BuildPath(LevelPrefix + name);
        }

        public Dictionary<string, string> Tiles { get; set; }
    }
}