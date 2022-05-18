using System.Collections;

namespace DesertRage.Model.Stats
{
    public class BattleUnit : DescriptionUnit, ICloneable<BattleUnit>
    {
        public BattleUnit()
        {
            Status = new BitArray(1);
            Turn = new Bar(0, 1000);
        }

        public BattleUnit(DescriptionUnit unit)
        {
            Icon = unit.Icon;
            Name = unit.Name;
            Description = unit.Description;
        }

        #region Hp Management Members
        public void Annihilate()
        {
            Hp = Hp.Drain();
        }

        public void Hit(int value)
        {
            Hp = Hp.Drain(value);
        }

        public void Cure()
        {
            Hp = Hp.Restore();
        }

        public void Cure(int value)
        {
            Hp = Hp.Restore(value);
        }
        #endregion

        public void SetStatus(bool code)
        {
            for (byte i = 0; i < Status.Length; i++)
            {
                Status[i] = code;
            }
        }

        public void SetStatus(int no, bool code)
        {
            Status[no] = code;
        }

        public new BattleUnit Clone()
        {
            return new BattleUnit(base.Clone())
            {
                Hp = Hp,
                Turn = Turn,
                Stats = Stats,
                Special = Special,
                Action = Action,
                Status = Status
            };
        }

        public Bar Hp { get; set; }
        public Bar Turn { get; set; }

        public BattleStats Stats { get; set; }
        public byte Special { get; set; }
        public string Action { get; set; }

        public BitArray Status { get; set; }
    }
}