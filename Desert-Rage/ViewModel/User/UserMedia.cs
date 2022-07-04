using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Controls;
using DesertRage.Controls.Menu.Game;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.ViewModel.User.Battle;
using DesertRage.ViewModel.User.Battle.Components;
using Serilog;

namespace DesertRage.ViewModel.User
{
    public class UserMedia : IBattle, INotifyPropertyChanged
    {
        public UserMedia()
        {
            Preferences = Bank.LoadPreferences();
        }

        #region UI Members
        private SoundGroup _soundPlayer;
        public SoundGroup SoundPlayer
        {
            get => _soundPlayer;
            set
            {
                _soundPlayer = value;
                OnPropertyChanged();
            }
        }

        private LevelMap _location;
        public LevelMap Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public GameMenu Menu { get; set; }
        #endregion

        #region OST Members
        internal void Stop()
        {
            SoundPlayer.Stop();
        }

        internal void SetSoundPlayer(SoundGroup sounds)
        {
            SoundPlayer = sounds;
        }

        public void Music(string name)
        {
            SoundPlayer.PlayMusic(name.ToFull());
        }

        public void Sound(string name)
        {
            SoundPlayer.PlaySound
                ($"/Resources/Media/OST/Sounds/{name}".ToFull());
        }

        public void Noise(string name)
        {
            SoundPlayer.PlayNoise
                ($"/Resources/Media/OST/Noises/{name}".ToFull());
        }
        #endregion

        private protected virtual void SaveGame(string profile)
        {
            Bank.SaveProfilePreferences(profile, Preferences);
            Sound("Info/Map/Save.mp3");

            Log.Information("Progress has been saved.");
        }

        public virtual void SetModel(BattleViewModel model)
        {
            ViewModel = model;
        }

        private BattleViewModel _viewModel;
        public BattleViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        private void SaveProfileName()
        {
            Bank.SavePreferences(Preferences);
        }

        public void SetName(string name, string hero)
        {
            Preferences.Name = name;
            Preferences.Description = hero;
            SaveProfileName();
        }

        public void SetPreferences(Settings preferences)
        {
            Preferences.Set(preferences);
            SaveProfileName();
        }

        public Settings Preferences { get; set; }

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