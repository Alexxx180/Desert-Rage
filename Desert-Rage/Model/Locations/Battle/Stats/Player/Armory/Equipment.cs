using DesertRage.Model.Locations.Battle.Things;
using DesertRage.Model.Menu.Things;

namespace DesertRage.Model.Locations.Battle.Stats.Player.Armory
{
    public class Equipment : PowerUnit
    {
        public Equipment(string meaning, float power) : base(power)
        {
            Description = $"{meaning} +{power}";
        }

        public string Type { get; set; }

        public byte Chest { get; set; }
    }
}