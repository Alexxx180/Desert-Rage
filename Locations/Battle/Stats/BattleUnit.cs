using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Helpers;
using System.Collections;

namespace DesertRage.Model.Locations.Battle.Stats
{
    public class BattleUnit : DescriptionUnit, ICloneable<BattleUnit>
    {
        public BattleUnit()
        {
            Hp = new Slider();

            int enumLength = Converters.ToValues<StatusID>().Length;

            Status = new BitArray(enumLength);
            StatusInfo = new Status[enumLength];
            for (byte i = 0; i < StatusInfo.Length; i++)
            {
                StatusInfo[i] = new Status
                {
                    Time = new Slider(0, Stats.Special)
                };
            }
        }

        public BattleUnit(BattleUnit unit)
        {
            Hp = new Slider();
            Set(unit);
        }

        public void SetStatusTiming()
        {
            ushort duration = Stats.Special;
            duration *= 2;

            SetStatusTiming(duration);
        }

        public void SetStatusTiming(ushort max)
        {
            for (byte i = 0; i < StatusInfo.Length; i++)
            {
                Slider time = StatusInfo[i].Time;
                time.Set(0, time.Current, max);
            }
        }

        public void Set(BattleUnit unit)
        {
            base.Set(unit);
            Hp.Set(unit.Hp);
            Stats = unit.Stats;
            Action = unit.Action;
            Status = unit.Status;
            StatusInfo = unit.StatusInfo;
            SetStatusTiming();
        }

        #region Hp Management Members
        public void Annihilate()
        {
            Hp.Drain();
        }

        public virtual void Hit(int value)
        {
            int damage = value - Stats.Defence;
            if (damage <= 0)
                return;

            damage /= Boost(StatusID.DEFENCE, StatusID.SHIELD);

            Hp.Drain(damage.ToUShort());
        }

        public void Cure()
        {
            Hp.Fill();
        }

        public void Cure(int value)
        {
            Hp.Fill(value.ToUShort());
        }
        #endregion

        public void HealStatus(int id)
        {
            StatusInfo[id].Time.Drain();
        }

        public void SetStatus(bool code)
        {
            for (byte i = 0; i < Status.Length; i++)
            {
                Status[i] = code;
            }
        }

        public void SetStatus(int id, bool code)
        {
            Status[id] = code;
        }

        public virtual void SetStatus(StatusID id, bool code)
        {
            Status[id.Int()] = code;
        }

        public int Boost(StatusID id)
        {
            return Status[id.Int()].Boost(2);
        }

        public int Boost(params StatusID[] ids)
        {
            int boost = 1;
            for (byte i = 0; i < ids.Length; i++)
            {
                boost *= Boost(ids[i]);
            }
            return boost;
        }

        public Slider Hp { get; set; }

        public BattleStats Stats { get; set; }
        public string Action { get; set; }

        public BitArray Status { get; set; }
        public Status[] StatusInfo { get; set; }

        public override BattleUnit Clone()
        {
            return new BattleUnit(this);
        }
    }
}