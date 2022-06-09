using System.ComponentModel;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Components.Actions;

namespace DesertRage.ViewModel.Battle.Components.Actions
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