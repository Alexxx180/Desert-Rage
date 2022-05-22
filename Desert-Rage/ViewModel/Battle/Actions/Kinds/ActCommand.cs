using DesertRage.Model.Locations;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds
{
    public class ActCommand : Target, INotifyPropertyChanged
    {
        public ActCommand(NoiseUnit unit)
        {
            Unit = unit;
        }

        public NoiseUnit Unit { get; }
    }
}