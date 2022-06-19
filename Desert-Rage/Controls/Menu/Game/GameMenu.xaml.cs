using DesertRage.Controls.Scenes;
using DesertRage.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// In game menu component
    /// </summary>
    public partial class GameMenu : UserControl, INotifyPropertyChanged, IControllable
    {
        private UserProfile _user;
        public UserProfile User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public void Pause()
        {
            User.Pause();
        }

        public void Resume()
        {
            User.Resume();
        }

        public void KeyHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    User.Battle.Entry.Display.Content = User.Location;
                    break;
                default:
                    break;
            }
        }

        public void KeyRelease(object sender, KeyEventArgs e)
        {
            
        }

        public GameMenu(UserProfile user)
        {
            InitializeComponent();
            User = user;
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