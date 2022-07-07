using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;
using DesertRage.Model;
using DesertRage.Model.Locations.Battle.Stats.Player;
using System.Windows;
using Serilog;

namespace DesertRage.ViewModel
{
    public class GameStart : INotifyPropertyChanged
    {
        /// <summary>
        /// Game start screen 
        /// profiles selection
        /// </summary>
        public GameStart()
        {
            _heroIndex = 0;
            IsListVisible = false;
            Profiles = new ObservableCollection<string>();
            CharactersList = new ObservableCollection<DescriptionUnit>();
            LoadProfiles();
            LoadCharacters();
        }

        public void SetProfile(string profile)
        {
            CurrentProfile = profile;
        }

        private void LoadCharacters()
        {
            Log.Debug("Loading characters...");
            HashSet<string> unlock = Bank.LoadHeroKeys();
            foreach (string hero in unlock)
            {
                DescriptionUnit unit = Bank.LoadHeroInitials(hero);
                unit.Description = hero;
                CharactersList.Add(unit);
            }
            CurrentHero = CharactersList[_heroIndex];
        }

        private void LoadProfiles()
        {
            Log.Debug("Loading player profiles...");
            string folder;
            try
            {
                folder = $"{Bank.DataDirectory}/Profiles".ToFull();
                foreach (string profile in Directory.GetDirectories(folder))
                {
                    Profiles.Add(new DirectoryInfo(profile).Name);
                }
            }
            catch (IOException exception)
            {
                Log.Error($"Can't find profiles in: {folder}\n{exception.Message}");
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
                OnPropertyChanged(nameof(CanCharacterSelect));
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

        private DescriptionUnit _currentHero;
        public DescriptionUnit CurrentHero
        {
            get => _currentHero;
            set
            {
                _currentHero = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DescriptionUnit> _charactersList;
        public ObservableCollection<DescriptionUnit> CharactersList
        {
            get => _charactersList;
            set
            {
                _charactersList = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanCharacterSelect));
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
                OnPropertyChanged(nameof(CanCharacterSelect));
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

        public void Next()
        {
            CurrentHero = CharactersList[_heroIndex];
            _heroIndex++;
            _heroIndex %= CharactersList.Count;
        }

        private int _heroIndex;

        public bool IsPlayerExists => !IsListVisible && Profiles.Contains(CurrentProfile);
        
        public bool CanCharacterSelect
        {
            get
            {
                bool isAble = CharactersList.Count > 1;
                isAble &= !IsListVisible;
                isAble &= !Profiles.Contains(CurrentProfile);
                return isAble;
            }
        }

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
