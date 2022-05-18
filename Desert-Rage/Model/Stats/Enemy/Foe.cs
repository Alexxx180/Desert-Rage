using DesertRage.Model.Locations.Map;

namespace DesertRage.Model.Stats.Enemy
{
    // Enemy logic
    public class Foe : BattleUnit, ICloneable<Foe>
    {
        public Foe()
        {
            Size = new Position(1);
        }

        public Foe(BattleUnit unit) : base(unit)
        {
            Hp = unit.Hp;
            Turn = unit.Turn;
            Stats = unit.Stats;
            Special = unit.Special;
            Action = unit.Action;
            Status = unit.Status;
        }

        public new Foe Clone()
        {
            return new Foe(base.Clone())
            {
                Death = Death,
                Size = Size,
                Experience = Experience,
                DropRate = DropRate
            };
        }

        public Position Size { get; set; }
        public string Death { get; set; }

        public byte Experience { get; set; }
        public byte DropRate { get; set; }
    }
}