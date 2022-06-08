using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Slider = DesertRage.Model.Locations.Battle.Stats.Slider;

namespace DesertRage.Controls.Status
{
    /// <summary>
    /// Hero status: HP, AP, Poison
    /// </summary>
    public partial class StatusPanel : UserControl, INotifyPropertyChanged
    {
        #region Icon Members
        public static readonly DependencyProperty
            IconProperty = DependencyProperty.Register(
                nameof(Icon), typeof(string), typeof(StatusPanel));

        public string Icon
        {
            get => GetValue(IconProperty) as string;
            set => SetValue(IconProperty, value);
        }
        #endregion

        #region Health Members
        public static readonly DependencyProperty
            HealthPointsProperty = DependencyProperty.Register(
                nameof(HealthPoints), typeof(Slider), typeof(StatusPanel));

        public Slider HealthPoints
        {
            get => (Slider)GetValue(HealthPointsProperty);
            set => SetValue(HealthPointsProperty, value);
        }
        #endregion

        #region Action Members
        public static readonly DependencyProperty
            ActionPointsProperty = DependencyProperty.Register(
                nameof(ActionPoints), typeof(Slider), typeof(StatusPanel));

        public Slider ActionPoints
        {
            get => (Slider)GetValue(ActionPointsProperty);
            set => SetValue(ActionPointsProperty, value);
        }
        #endregion

        public StatusPanel()
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