using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Helpers;
using DesertRage.Helpers.Attach;
using static DesertRage.Customing.Decorators;
using static DesertRage.Mechanics.MapBuilder;
using static DesertRage.Customing.Converters.Converters;
using static DesertRage.Mechanics.Algorithms.Coloring;
using static DesertRage.Helpers.Abilities;
using static DesertRage.Helpers.Characteristics;
using System.Diagnostics;
using DesertRage.Model.Stats;
using DesertRage.Model.Stats.Player.Armory;
using static DesertRage.Writers.Processors;
using DesertRage.Model;
using DesertRage.Model.Stats.Player;
using DesertRage.ViewModel;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Locations;
using DesertRage.Controls;
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
