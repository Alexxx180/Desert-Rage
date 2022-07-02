using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.Model.Locations.Battle.Stats
{
    public class BattleUnit : DescriptionUnit, ICloneable<BattleUnit>, INotifyPropertyChanged
    {
        public BattleUnit()
        {
            Hp = new Slider();

            int enumLength = Converters.ToValues<StatusID>().Length;

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

        public bool NoStatus(int id)
        {
            return StatusInfo[id].Time.IsEmpty;
        }

        public void HealStatus(int id)
        {
            StatusInfo[id].Time.Drain();
        }

        public void MakeStatus(int id)
        {
            StatusInfo[id].Time.Fill();
        }

        public int Boost(StatusID id)
        {
            bool isActive = !NoStatus(id.Int());
            return isActive.Boost(2);
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

        private BattleStats _stats;
        public BattleStats Stats
        {
            get => _stats;
            set
            {
                _stats = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BattleSpeed));
            }
        }
        public float BattleSpeed => Stats.Speed / 255.0f;
        
        public string Action { get; set; }

        public Status[] StatusInfo { get; set; }

        public override BattleUnit Clone()
        {
            return new BattleUnit(this);
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}