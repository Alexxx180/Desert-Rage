using DesertRage.ViewModel.Actions;

namespace DesertRage.ViewModel.Battle.Actions.Dependent
{
    public class RestCommand : RecoverCommand
    {
        public RestCommand(IThing thing) : base(thing) { }

        private protected override void Use(object parameter)
        {
            Rest();
        }
    }
}