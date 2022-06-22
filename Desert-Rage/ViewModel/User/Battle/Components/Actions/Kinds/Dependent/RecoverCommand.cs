using DesertRage.Model.Locations;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class RecoverCommand : CureCommand, INotifyPropertyChanged
    {
        public RecoverCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing) { }

        protected void Rest()
        {
            Hero.Rest(Power);
        }

        public override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}