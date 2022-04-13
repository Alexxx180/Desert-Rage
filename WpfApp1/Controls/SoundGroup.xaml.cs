using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DesertRage.Customing.Converters.Converters;

namespace DesertRage.Controls
{
    /// <summary>
    /// Логика взаимодействия для SoundGroup.xaml
    /// </summary>
    public partial class SoundGroup : UserControl
    {
        public SoundGroup()
        {
            InitializeComponent();
        }

        private void OnMusicEnd(object sender, RoutedEventArgs e)
        {
            Sound1.Position = TimeSpan.Zero;
            Sound1.Play();
        }

        private void OnSoundsEnd(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Stop();
        }

        private static void PlayOST(MediaElement element, in string Path)
        {
            element.Stop();
            element.Source = Path.ToUri();
            element.Play();
        }

        public void PlayMusic(in string path) => PlayOST(Sound1, path);
        public void PlayNoise(in string path) => PlayOST(Sound2, path);
        public void PlaySound(in string path) => PlayOST(Sound3, path);
    }
}
