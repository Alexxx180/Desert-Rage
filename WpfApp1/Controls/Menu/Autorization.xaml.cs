using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace DesertRage.Controls.Menu
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : UserControl, INotifyPropertyChanged
    {
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

        private HashSet<string> _toDrop;

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
            }
        }

        public Autorization()
        {
            InitializeComponent();

            _isListVisible = false;
            _toDrop = new HashSet<string>();
            Profiles = new ObservableCollection<string>();

            Profiles.Add("АляТополя");
            Profiles.Add("МистерПерпендыкович");
            Profiles.Add("СерьезныйСэм");
            Profiles.Add("Еще");
            Profiles.Add("И еще");
            Profiles.Add("И еще один");
        }

        #region ProfilesManagement Members
        private void ProfilesMove(object sender, MouseEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
               Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
               Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    ListBox profileList = sender as ListBox;
                    string selectedItem = profileList.SelectedItem as string;

                    _ = Profiles.Remove(selectedItem);
                    _ = _toDrop.Add(selectedItem);

                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Move);
                }
                catch { }
            }
        }

        private void ProfilesDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string item)
            {
                Profiles.Add(item);
                _ = _toDrop.Remove(item);
            }
        }
        #endregion

        private void SelectProfile(object sender, SelectionChangedEventArgs e)
        {
            ListBox profileList = sender as ListBox;
            CurrentProfile = profileList.SelectedItem as string;
        }

        private void UseProfile(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            IsListVisible = !IsListVisible;
            button.Content = IsListVisible ? "▼" : "▲";
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