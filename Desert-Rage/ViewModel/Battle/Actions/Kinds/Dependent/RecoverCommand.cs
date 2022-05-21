using DesertRage.Model;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class RecoverCommand : CureCommand, INotifyPropertyChanged
    {
        public RecoverCommand(IFormula dependency, 
            DescriptionUnit thing) : base(dependency, thing) { }

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