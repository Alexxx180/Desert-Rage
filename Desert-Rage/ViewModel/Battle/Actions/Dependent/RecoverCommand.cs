using DesertRage.ViewModel.Actions;
using DesertRage.ViewModel.Actions.Dependent;

namespace DesertRage.ViewModel.Battle.Actions.Dependent
{
    public class RecoverCommand : CureCommand
    {
        public RecoverCommand(IThing thing) : base(thing) { }

        protected void Rest()
        {
            Hero.Rest(Power);
        }

        private protected override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}