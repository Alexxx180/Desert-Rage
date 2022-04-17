using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace DesertRage.ViewModel
{
    public class GameStart : INotifyPropertyChanged
    {
        public GameStart()
        {
            IsListVisible = false;
            Profiles = new ObservableCollection<string>();

            Profiles.Add("АляТополя");
            Profiles.Add("МистерПерпендыкович");
            Profiles.Add("СерьезныйСэм");
            Profiles.Add("Еще");
            Profiles.Add("И еще");
            Profiles.Add("И еще один");
        }

        private string _currentProfile;
        public string CurrentProfile
        {
            get => _currentProfile;
            set
            {
                _currentProfile = value;
                OnPropertyChanged();
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
                OnPropertyChanged(nameof(IsPlayerExists));
            }
        }

        public bool IsPlayerExists => !IsListVisible && Profiles.Contains(CurrentProfile);

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