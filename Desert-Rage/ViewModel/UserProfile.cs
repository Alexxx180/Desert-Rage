using DesertRage.Controls;
using DesertRage.Controls.Menu.Game;
using DesertRage.Customing.Converters;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Menu.Things;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel
{
    public class UserProfile : INotifyPropertyChanged
    {
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

        internal void SetSoundPlayer(SoundGroup _soundPlayer)
        {
            SoundPlayer = _soundPlayer;
        }

        public UserProfile()
        {
            Preferences = new Settings();
        }

        public string Name { get; set; }

        public Location Level { get; set; }
        public Character Hero { get; set; }
        public GameMenu Menu { get; set; }

        public Settings Preferences { get; set; }

        #region Equipment Members
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Equipment> Armor { get; set; }
        public ObservableCollection<Equipment> Pants { get; set; }
        public ObservableCollection<Equipment> Boots { get; set; }
        #endregion

        public void Go(Direction move)
        {
            Hero.Go(Level.Map, move.ToInt());
            UpdateHero();
        }

        public void Stand()
        {
            Hero.Stand();
            UpdateHero();
        }

        public void UpdateHero()
        {
            OnPropertyChanged(nameof(Hero));
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