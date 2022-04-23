using DesertRage.Model.Stats.Player;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// In game settings component
    /// </summary>
    public partial class GameSettings : UserControl
    {
        public static readonly DependencyProperty
            GameOptionsProperty = DependencyProperty.Register
                (nameof(GameOptions), typeof(Settings),
                typeof(GameSettings));

        #region Settings Members
        public Settings GameOptions
        {
            get => GetValue(GameOptionsProperty) as Settings;
            set => SetValue(GameOptionsProperty, value);
        }
        #endregion

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
    }
}