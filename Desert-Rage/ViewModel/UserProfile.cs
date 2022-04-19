using DesertRage.Customing.Converters;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats.Player;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel
{
    public class UserProfile : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public Location Level { get; set; }
        public Character Hero { get; set; }

        public void Go(Direction move)
        {
            Hero.Go(Level.Map, move.ToInt());
            OnPropertyChanged(nameof(Hero));
        }

        public void Stand()
        {
            Hero.Stand();
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