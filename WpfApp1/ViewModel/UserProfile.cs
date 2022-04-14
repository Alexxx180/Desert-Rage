using DesertRage.Model.Locations;
using DesertRage.Model.Stats.Player;

namespace DesertRage.ViewModel
{
    public class UserProfile
    {
        public string ProfileName { get; set; }

        public Location CurrentLocation { get; set; }
        internal Character Hero { get; set; }
    }
}