using System.ComponentModel;
using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public class Target : Battle, ITarget, INotifyPropertyChanged
    {
        private Targeting _cursor;
        public Targeting UnitCursor
        {
            get => _cursor;
            set
            {
                _cursor = value;
                OnPropertyChanged();
            }
        }
    }
}