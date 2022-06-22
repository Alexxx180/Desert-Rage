using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public class InstantCommand : Action, INotifyPropertyChanged
    {
        public InstantCommand(IAction action) : base(action) { }

        public override void Execute(object parameter)
        {
            Effect.Use(parameter);
        }

        public override bool CanExecute(object parameter) => Effect.CanUse;
    }
}
