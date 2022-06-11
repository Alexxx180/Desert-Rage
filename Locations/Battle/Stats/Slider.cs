using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.Model.Locations.Battle.Stats
{
    public class Slider : INotifyPropertyChanged
    {
        public Slider() { }

        #region Bar Constructor Members
        public Slider(
            ushort minimum,
            ushort current,
            ushort maximum)
        {
            Set(minimum, current, maximum);
        }

        public Slider(
            ushort current,
            ushort maximum) :
            this(0, current, maximum)
        { }

        public Slider(ushort value) :
            this(value, value) { }
        #endregion

        #region Overriden Members
        public override string ToString()
        {
            return $"{ Current } / { Max } ({ Minimum } - { Max })";
        }
        #endregion

        public void Drain()
        {
            Current = Minimum;
        }

        public void Drain(ushort value)
        {
            if (Current - value < Minimum)
                Drain();
            else
                Current -= value;
        }

        public void Fill()
        {
            Current = Max;
        }

        public void Fill(ushort value)
        {
            if (Current + value > Max)
                Fill();
            else
                Current += value;
        }

        public void Set(
            ushort minimum,
            ushort current,
            ushort maximum)
        {
            Minimum = minimum;
            Current = current;
            Max = maximum;
        }

        public void Set(Bar values)
        {
            Set(values.Minimum,
                values.Current,
                values.Max);
        }

        public void Set(Slider values)
        {
            Set(values.Minimum,
                values.Current,
                values.Max);
        }

        #region Bar Members
        public bool IsMax => Current >= Max;
        public bool IsEmpty => Current <= Minimum;
        public bool IsSealed => Minimum == Max;

        private ushort _minimum;
        public ushort Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                OnPropertyChanged();
            }
        }

        private ushort _current;
        public ushort Current
        {
            get => _current;
            set
            {
                _current = value;
                OnPropertyChanged();
            }
        }

        private ushort _maximum;
        public ushort Max
        {
            get => _maximum;
            set
            {
                _maximum = value;
                OnPropertyChanged();
            }
        }
        #endregion

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