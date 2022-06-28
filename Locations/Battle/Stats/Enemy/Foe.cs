using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.Model.Locations.Battle.Stats.Enemy
{
    // Enemy logic
    public class Foe : BattleUnit, ICloneable<Foe>
    {
        public Foe()
        {
            Size = new Position(1);
        }

        public Foe(Foe unit)
        {
            Set(unit);
        }

        public void Set(Foe unit)
        {
            base.Set(unit);
            ID = unit.ID;
            IsLearned = unit.IsLearned;
            Death = unit.Death;
            Size = unit.Size;
            Experience = unit.Experience;
            Drop = unit.Drop;
            Strategy = unit.Strategy;
        }

        public override void Hit(int value)
        {
            int damage = value - Stats.Defence;
            damage -= Stats.Special / 2;

            if (damage <= 0)
                return;

            Hp.Drain(damage.ToUShort());
        }

        public void Analyze(bool setTo)
        {
            IsLearned = setTo;
        }

        public EnemyBestiary ID { get; set; }
        public ItemsID Drop { get; set; }

        public Position Size { get; set; }
        public string Death { get; set; }

        public byte Experience { get; set; }
        public bool IsLearned { get; set; }

        public FightingMode Strategy { get; set; }

        public override Foe Clone()
        {
            return new Foe(this);
        }
    }
}