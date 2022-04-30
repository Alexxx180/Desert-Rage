using DesertRage.Model.Stats;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Status
{
    /// <summary>
    /// Hero status: HP, AP, Poison
    /// </summary>
    public partial class StatusPanel : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            HealthPointsProperty = DependencyProperty.Register(
                nameof(HealthPoints), typeof(Bar), typeof(StatusPanel));

        public static readonly DependencyProperty
            ActionPointsProperty = DependencyProperty.Register(
                nameof(ActionPoints), typeof(Bar), typeof(StatusPanel));

        public static readonly DependencyProperty
            IconProperty = DependencyProperty.Register(
                nameof(Icon), typeof(string), typeof(StatusPanel));

        public Bar HealthPoints
        {
            get => (Bar)GetValue(HealthPointsProperty);
            set => SetValue(HealthPointsProperty, value);
        }

        public Bar ActionPoints
        {
            get => (Bar)GetValue(ActionPointsProperty);
            set => SetValue(ActionPointsProperty, value);
        }

        public string Icon
        {
            get => GetValue(IconProperty) as string;
            set => SetValue(IconProperty, value);
        }

        public StatusPanel()
        {
            InitializeComponent();

            //Icon = "/Resources/Images/Menu/Topics/Status.svg";
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
