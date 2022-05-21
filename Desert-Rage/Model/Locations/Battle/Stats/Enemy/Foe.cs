namespace DesertRage.Model.Locations.Battle.Stats.Enemy
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

        public override void Hit(int value)
        {
            int damage = value - (Stats.Defence + Stats.Special / 2);
            if (damage <= 0)
                return;

            Hp = Hp.Drain(damage);
        }

        public Position Size { get; set; }
        public string Death { get; set; }

        public byte Experience { get; set; }
        public byte DropRate { get; set; }
    }
}