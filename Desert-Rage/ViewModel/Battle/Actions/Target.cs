using System.ComponentModel;
using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.Battle.Actions
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