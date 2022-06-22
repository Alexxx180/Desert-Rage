using DesertRage.Model.Locations;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class RestCommand : RecoverCommand, INotifyPropertyChanged
    {
        public RestCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing) { }

        public override void Use(object parameter)
        {
            Act();
            Rest();
        }
    }
}