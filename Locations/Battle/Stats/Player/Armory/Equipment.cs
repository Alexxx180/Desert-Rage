using DesertRage.Model.Locations.Battle.Things;

namespace DesertRage.Model.Locations.Battle.Stats.Player.Armory
{
    public class Equipment : PowerUnit
    {
        public Equipment() { }

        public Equipment(float power) : base(power) { }

        public Equipment(float power, string name) : this(power)
        {
            Name = name;
        }

        public ArmoryKind Type { get; set; }
    }
}