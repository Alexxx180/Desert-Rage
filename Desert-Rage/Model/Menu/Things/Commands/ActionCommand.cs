using DesertRage.ViewModel.Actions;
using System;
using System.Windows.Input;

namespace DesertRage.Model.Menu.Things.Commands
{
    public abstract class ActionCommand : ICommand
    {
        public IAttributeThing Thing { get; set; } //virtual

        public abstract void Execute(object parameter);

        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}