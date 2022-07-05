using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.ViewModel.User;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Foes bestiary
    /// </summary>
    public partial class BestiaryLayout : UserControl
    {
        public static readonly DependencyProperty
            PlayerProperty = DependencyProperty.Register(nameof(Player),
                typeof(MapWorker), typeof(BestiaryLayout));

        public MapWorker Player
        {
            get => GetValue(PlayerProperty) as MapWorker;
            set => SetValue(PlayerProperty, value);
        }

        public static readonly DependencyProperty
            SelectedFoeProperty = DependencyProperty.Register(
                nameof(SelectedFoe), typeof(Foe), typeof(BestiaryLayout));

        public Foe SelectedFoe
        {
            get => GetValue(SelectedFoeProperty) as Foe;
            set => SetValue(SelectedFoeProperty, value);
        }
        
        public BestiaryLayout()
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
