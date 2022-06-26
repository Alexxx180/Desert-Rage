namespace DesertRage.Model.Locations.Battle.Stats.Player.Armory
{
    public class Equipment : NoiseUnit
    {
        public Equipment() { }

        public Equipment(byte power) : base(power) { }

        public Equipment(byte power, string name) : this(power)
        {
            Name = name;
        }

        public ArmoryKind Type { get; set; }
    }
}