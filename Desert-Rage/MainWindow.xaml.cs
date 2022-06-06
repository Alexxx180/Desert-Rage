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

            SetGame(NewGame());
        }

        private void SetGame(UserProfile user)
        {
            user.SetSoundPlayer(SoundTrack);
            user.LoadHeroCommands();

            Adventure = user.Battle;
            Adventure.Entry = this;
            Display.Content = user.Location;
        }

        #region Model Members
        private UserProfile NewGame()
        {
            string path = "/Resources/Media/Data/Characters/Ray/Beginner.json".ToFull();
            Character hero = App.Processor.Read<Character>(path);
            
            path = "/Resources/Media/Data/Map/SecretTemple.json".ToFull();
            Location level = App.Processor.Read<Location>(path);
            hero.Place = level.Start;

            UserProfile user = new UserProfile
            {
                Hero = hero,
                Level = level
            };

            return user;
        }

        private void SaveGame()
        {
            //PlaySound(Paths.OST.Sounds.ControlSave);
            UserProfile user = Adventure.Human.Player;
            App.Processor.Write($"/Resources/Media/Data/Profiles/{user.Name}/Level.json", user.Level);
            App.Processor.Write($"/Resources/Media/Data/Profiles/{user.Name}/Character.json", user.Hero);
        }
        #endregion

        #region RoutedEvent Members
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    //Adventure.SafeFreeze();
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