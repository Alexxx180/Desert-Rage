using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Логика взаимодействия для GameSettings.xaml
    /// </summary>
    public partial class GameSettings : UserControl
    {
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
