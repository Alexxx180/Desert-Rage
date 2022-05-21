using DesertRage.Model;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class RestCommand : RecoverCommand, INotifyPropertyChanged
    {
        public RestCommand(IFormula dependency,
            DescriptionUnit thing) : base(dependency, thing) { }

        public override void Use(object parameter)
        {
            Rest();
            User.UpdateHero();
        }
    }
}