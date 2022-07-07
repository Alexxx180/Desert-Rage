using DesertRage.Controls.Scenes;
using DesertRage.ViewModel;
using DesertRage.ViewModel.User;
using System;
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
        private GameMenu()
        {
            _randomizer = new Random();
            _tips = Bank.LoadTips();
        }

        public GameMenu(MapWorker player) : this()
        {
            InitializeComponent();
            Player = player;
            MenuTip();
        }

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

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private void MenuTip()
        {
            int no = _randomizer.Next(0, _tips.Length);
            Message = _tips[no];
        }

        public void KeyHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    Player.ViewModel.Entry.SetView(Player.Location);
                    MenuTip();
                    break;
                default:
                    break;
            }
        }

        public void KeyRelease(object sender, KeyEventArgs e) { }

        #region IPausable Members
        public void Pause()
        {
            Player.Pause();
        }

        public void Resume()
        {
            Player.Resume();
        }
        #endregion

        private readonly string[] _tips;
        private readonly Random _randomizer;

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
