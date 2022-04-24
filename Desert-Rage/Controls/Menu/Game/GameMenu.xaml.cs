using DesertRage.Controls.Scenes;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Customing;
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

        public void SetLocation(in LevelMap map)
        {
            Location = map;
            //this.SetActive(!IsEnabled);
        }

        public void KeyHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    Label container = Parent as Label;
                    container.Content = Location;
                    break;
                default:
                    break;
            }
        }

        public void KeyRelease(object sender, KeyEventArgs e)
        {
            
        }

        public GameMenu()
        {
            InitializeComponent();
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