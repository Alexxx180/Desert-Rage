using System;
using System.Windows;
using System.Windows.Controls;
using static DesertRage.Decorators.UI.Media;
using Slider = DesertRage.Model.Locations.Battle.Stats.Slider;

namespace DesertRage.Controls
{
    /// <summary>
    /// Sound track
    /// </summary>
    public partial class SoundGroup : UserControl
    {
        #region Music Members
        public static readonly DependencyProperty
            MusicProperty = DependencyProperty.Register
                (nameof(Music), typeof(Slider), typeof(SoundGroup));

        public Slider Music
        {
            get => GetValue(MusicProperty) as Slider;
            set => SetValue(MusicProperty, value);
        }
        #endregion

        #region Sound Members
        public static readonly DependencyProperty
            SoundProperty = DependencyProperty.Register
                (nameof(Sound), typeof(Slider), typeof(SoundGroup));

        public Slider Sound
        {
            get => GetValue(SoundProperty) as Slider;
            set => SetValue(SoundProperty, value);
        }
        #endregion

        #region Noise Members
        public static readonly DependencyProperty
            NoiseProperty = DependencyProperty.Register
                (nameof(Noise), typeof(Slider), typeof(SoundGroup));

        public Slider Noise
        {
            get => GetValue(NoiseProperty) as Slider;
            set => SetValue(NoiseProperty, value);
        }
        #endregion

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

        public void PlayMusic(in string path) => PlayOST(Sound1, path);
        public void PlayNoise(in string path) => PlayOST(Sound2, path);
        public void PlaySound(in string path) => PlayOST(Sound3, path);
    }
}