using DesertRage.ViewModel.Actions;
using DesertRage.ViewModel.Actions.Independent;

namespace DesertRage.ViewModel.Battle.Actions.Independent
{
    public class RecoverMaxCommand : CureMaxCommand
    {
        public RecoverMaxCommand(IThing thing) : base(thing) { }

        protected void Rest()
        {
            Hero.Rest();
        }

        private protected override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}