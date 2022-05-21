using DesertRage.Model;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds
{
    public class ActCommand : Target, INotifyPropertyChanged
    {
        public ActCommand(DescriptionUnit unit)
        {
            Unit = unit;
        }

        public DescriptionUnit Unit { get; }
    }
}