using DesertRage.Model.Locations;
using DesertRage.Model.Stats.Player;

namespace DesertRage.ViewModel
{
    public class UserProfile
    {
        public Location CurrentLocation { get; set; }
        internal Character Hero { get; set; }
    }
}