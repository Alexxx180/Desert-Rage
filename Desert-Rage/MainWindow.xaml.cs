using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.ViewModel;
using DesertRage.Model.Locations;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.ViewModel.Battle;
using System;
using System.Text;
using DesertRage.Controls.Menu;

namespace DesertRage
{
    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Custom Events Members
        public static readonly RoutedEvent
            EscapingEvent = EventManager.RegisterRoutedEvent(
                nameof(Escaping), RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(MainWindow));

        public event RoutedEventHandler Escaping
        {
            add { AddHandler(EscapingEvent, value); }
            remove { RemoveHandler(EscapingEvent, value); }
        }

        public void RaiseEscape()
        {
            KeyDown -= OnKeyDown;
            RoutedEventArgs newEventArgs = new RoutedEventArgs(EscapingEvent);
            Curtain.RaiseEvent(newEventArgs);
        }
        #endregion

        private BattleViewModel _adventure;
        public BattleViewModel Adventure
        {
            get => _adventure;
            set
            {
                _adventure = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            UserProfile profile = new UserProfile();
            profile.SetSoundPlayer(SoundTrack);

            Adventure = profile.Battle;
            Adventure.Entry = this;

            profile.Music("/Resources/Media/OST/Music/MainTitle.mp3");
        }

        #region Model Members
        internal void NewAdventure(string profile)
        {
            Bank.MakeProfile(profile);

            UserProfile user = Adventure.Human.Player;

            user.SetHero(Bank.LoadHero("Ray"));
            user.SetLevel(Bank.LoadLevel("SecretTemple"));
            //user.SetPreferences(Bank.LoadProfilePreferences(profile));
            user.SetHeroStart();

            user.Preferences.Name = profile;
            
            user.SaveGame();

            Explore(user);
        }

        internal void Continue(string profile)
        {
            UserProfile user = Adventure.Human.Player;

            user.SetHero(Bank.LoadProfileHero(profile));
            user.SetLevel(Bank.LoadProfileLevel(profile));
            user.SetPreferences(Bank.LoadProfilePreferences(profile));

            user.Sound("Info/Map/Teleport.mp3");

            Explore(user);
        }

        private void Explore(UserProfile user)
        {
            Display.Content = user.Location;
            user.Peace();
        }
        #endregion

        #region RoutedEvent Members
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    RaiseEscape();
                    break;
                default:
                    TransferKeyDown(sender, e);
                    break;
            };
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            TransferKeyUp(sender, e);
        }

        private void TransferKeyDown(object sender, KeyEventArgs e)
        {
            if (Display.Content is IControllable keyPad)
            {
                keyPad.KeyHandle(sender, e);
            }
        }

        private void TransferKeyUp(object sender, KeyEventArgs e)
        {
            if (Display.Content is IControllable keyPad)
            {
                keyPad.KeyRelease(sender, e);
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

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