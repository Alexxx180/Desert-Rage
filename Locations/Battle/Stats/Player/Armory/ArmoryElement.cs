namespace DesertRage.Model.Locations.Battle.Stats.Player.Armory
{
    public struct ArmoryElement
    {
        public ArmoryElement(ArmoryKind kind, Sets set)
        {
            Kind = kind;
            Set = set;
        }

        public ArmoryKind Kind { get; set; }
        public Sets Set { get; set; }
    }
}