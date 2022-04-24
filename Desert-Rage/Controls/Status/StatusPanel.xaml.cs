using DesertRage.Model.Stats;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace DesertRage.Controls.Status
{
    /// <summary>
    /// Hero status: HP, AP, Poison
    /// </summary>
    public partial class StatusPanel : UserControl, INotifyPropertyChanged
    {
        private string _icon;
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        private Bar _healthPoints;
        public Bar HealthPoints
        {
            get => _healthPoints;
            set
            {
                _healthPoints = value;
                OnPropertyChanged();
            }
        }

        private Bar _actionPoints;
        public Bar ActionPoints
        {
            get => _actionPoints;
            set
            {
                _actionPoints = value;
                OnPropertyChanged();
            }
        }

        public StatusPanel()
        {
            InitializeComponent();

            Icon = "/Resources/Images/Menu/Topics/Status.svg";
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
