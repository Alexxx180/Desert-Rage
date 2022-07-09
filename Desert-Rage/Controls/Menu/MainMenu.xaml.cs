using DesertRage.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Controls.Scenes;
using System.Windows.Input;

namespace DesertRage.Controls.Menu
{
    /// <summary>
    /// Menu with adventure options
    /// </summary>
    public partial class MainMenu : UserControl, IControllable, INotifyPropertyChanged
    {
        #region MainWindow Members
        public static readonly DependencyProperty
            MainProperty = DependencyProperty.Register(nameof(Main),
                typeof(MainWindow), typeof(MainMenu));

        public MainWindow Main
        {
            get => GetValue(MainProperty) as MainWindow;
            set => SetValue(MainProperty, value);
        }
        #endregion

        private GameStart _startViewModel;
        public GameStart StartViewModel
        {
            get => _startViewModel;
            set
            {
                _startViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainMenu()
        {
            InitializeComponent();
            StartViewModel = new GameStart();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            string profile = StartViewModel.CurrentProfile;
            string hero;

            if (StartViewModel.IsPlayerExists)
            {
                hero = Bank.LoadProfilePreferences(profile).Description;
            }
            else
            {
                hero = StartViewModel.CurrentHero.Description;
            }
             
            Main.NewAdventure(profile, hero);
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            Main.Continue(StartViewModel.CurrentProfile);
        }

        public void KeyRelease(object sender, KeyEventArgs e) { }

        public void KeyHandle(object sender, KeyEventArgs e) { }

        public void Pause() { }

        public void Resume() { }

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