namespace DesertRage.Model.Locations.Battle.Stats.Player.Armory
{
    public class Equipment : PowerUnit
    {
        public Equipment() { }

        public Equipment(byte power) : base(power) { }

        public Equipment(byte power, string name) : this(power)
        {
            Name = name;
        }

        public ArmoryKind Type { get; set; }

        public override string ToString()
        {
            return $"Name: { Name }\n" +
                $"Description: { Description }\n" +
                $"Power: { Power }\n" + 
                $"Type: { Type }";
        }
    }
}