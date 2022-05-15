using System.Collections;

namespace DesertRage.Model.Stats
{
    public class BattleUnit : DescriptionUnit
    {
        public BattleUnit()
        {
            Status = new BitArray(1);
            Turn = new Bar(0, 1000);
        }

        public BattleUnit(BattleUnit unit) : base(unit)
        {
            Hp = unit.Hp;
            Turn = unit.Turn;
            Stats = unit.Stats;
            Special = unit.Special;
            Action = unit.Action;
            Status = unit.Status;
        }

        #region Hp Management Members
        public void Hit(int value)
        {
            Hp.Drain(value);
        }

        public void Cure()
        {
            Hp.Restore();
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

        public Bar Hp { get; set; }
        public Bar Turn { get; set; }

        public BattleStats Stats { get; set; }
        public byte Special { get; set; }
        public string Action { get; set; }

        public BitArray Status { get; set; }
    }
}