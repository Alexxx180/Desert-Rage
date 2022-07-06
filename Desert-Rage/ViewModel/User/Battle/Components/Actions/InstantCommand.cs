using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public class InstantCommand : Action, INotifyPropertyChanged
    {
        /// <summary>
        /// Can be used basing on effect, e.g. forever
        /// </summary>
        
        private static readonly string _commandSpace;
    
        static InstantCommand()
        {
            Type command = typeof(DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.ActCommand);
            _commandSpace = command.NameSpace;
        }
        
        private protected virtual SetUnit(string commandName, AttributeUnit unit)
        {
            IAction action = (IAction)Activator.CreateInstance(commandName);
            action.SetUnit(unit);
            Effect = action;
        }

        public void SetUnit(AttributeUnit unit)
        {
            SetUnit($"{_commandSpace}.{unit.Command}", unit);
        }

        public override void Execute(object parameter)
        {
            Effect.Use(parameter);
        }

        public override bool CanExecute(object parameter) => Effect.CanUse;
    }
}
