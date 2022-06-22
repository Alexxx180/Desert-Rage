using DesertRage.Controls.Scenes;
using DesertRage.ViewModel.User;
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
        private MapWorker _player;
        public MapWorker Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged();
            }
        }

        public void Pause()
        {
            Player.Pause();
        }

        public void Resume()
        {
            Player.Resume();
        }

        public void KeyHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    Player.ViewModel.Entry.Display.Content = Player.Location;
                    break;
                default:
                    break;
            }
        }

        public void KeyRelease(object sender, KeyEventArgs e)
        {
            
        }

        public GameMenu(MapWorker player)
        {
            InitializeComponent();
            Player = player;
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