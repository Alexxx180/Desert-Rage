using DesertRage.Model.Locations.Battle.Things;
using System;
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
            Type command = typeof(Kinds.ActCommand);
            _commandSpace = command.Namespace;
        }
        
        private protected virtual void SetUnit(Type command, AttributeUnit unit)
        {
            IAction action = (IAction)Activator.CreateInstance(command);
            action.SetUnit(unit);
            Effect = action;
        }

        public void SetUnit(AttributeUnit unit)
        {
            Type type = Type.GetType($"{_commandSpace}.{unit.Command}");
            SetUnit(type, unit);
        }

        public override void Execute(object parameter)
        {
            Effect.Use(parameter);
        }

        public static InstantCommand FromUnit(AttributeUnit unit)
        {
            InstantCommand command = new InstantCommand();
            command.SetUnit(unit);
            return command;
        }

        public override bool CanExecute(object parameter) => Effect.CanUse;
    }
}
