using DesertRage.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// In game settings component
    /// </summary>
    public partial class GameSettings : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            PlayerProperty = DependencyProperty.Register(nameof(Player),
                typeof(UserProfile), typeof(GameSettings));

        public UserProfile Player
        {
            get => GetValue(PlayerProperty) as UserProfile;
            set => SetValue(PlayerProperty, value);
        }

        public GameSettings()
        {
            InitializeComponent();
        }

        //private void SoundsLoud_ValueChanged(object sender,
        //    RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if (!NewAdventure.IsEnabled)
        //        PlaySound(Paths.OST.Sounds.ChestOpened);
        //}

        //private void NoiseLoud_ValueChanged(object sender,
        //    RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if (!NewAdventure.IsEnabled)
        //        PlayNoise(Paths.OST.Noises.Torch);
        //}

        //private void GameSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    OnPropertyChanged(nameof(TimeFormula));
        //}

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