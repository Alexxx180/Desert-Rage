using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Slider = DesertRage.Model.Locations.Battle.Stats.Slider;

namespace DesertRage.Controls.Status
{
    /// <summary>
    /// Bar component
    /// </summary>
    public partial class StatBar : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            BarProperty = DependencyProperty.Register(
                nameof(Bar), typeof(Slider), typeof(StatBar));

        #region StatBar Members
        private string _сaption;
        public string Caption
        {
            get => _сaption;
            set
            {
                _сaption = value;
                OnPropertyChanged();
            }
        }

        private Brush _foreBrush;
        public Brush ForeBrush
        {
            get => _foreBrush;
            set
            {
                _foreBrush = value;
                OnPropertyChanged();
            }
        }

        public Slider Bar
        {
            get => (Slider)GetValue(BarProperty);
            set => SetValue(BarProperty, value);
        }
        #endregion

        public StatBar()
        {
            InitializeComponent();
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