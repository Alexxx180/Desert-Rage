using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;

namespace DesertRage.ViewModel
{
    public class GameStart : INotifyPropertyChanged
    {
        public GameStart()
        {
            _unlock = Bank.LoadHeroKeys();
            IsListVisible = false;
            
            Profiles = new ObservableCollection<string>();
            LoadProfiles();
        }

        public void SetProfile(string profile)
        {
            CurrentProfile = profile;
        }

        private void LoadProfiles()
        {
            try
            {
                string folder = $"{Bank.DataDirectory}/Profiles".ToFull();
                foreach (string profile in Directory.GetDirectories(folder))
                {
                    Profiles.Add(new DirectoryInfo(profile).Name);
                }
            }
            catch // (IOException exception)
            {

            }
        }

        private string _currentProfile;
        public string CurrentProfile
        {
            get => _currentProfile;
            set
            {
                _currentProfile = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPlayerExists));
            }
        }

        private ObservableCollection<string> _profiles;
        public ObservableCollection<string> Profiles
        {
            get => _profiles;
            set
            {
                _profiles = value;
                OnPropertyChanged();
            }
        }

        private bool _isListVisible;
        public bool IsListVisible
        {
            get => _isListVisible;
            set
            {
                _isListVisible = value;
                OnPropertyChanged();
                UpdatePlayers();
            }
        }

        public bool ResetVisibility()
        {
            return IsListVisible = !IsListVisible;
        }

        public void UpdatePlayers()
        {
            OnPropertyChanged(nameof(IsPlayerExists));
        }

        public bool IsPlayerExists => !IsListVisible && Profiles.Contains(CurrentProfile);
        public bool CanCharacterSelect => _unlock.Count > 1 && !IsPlayerExists;

        private HashSet<string> _unlock;

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
