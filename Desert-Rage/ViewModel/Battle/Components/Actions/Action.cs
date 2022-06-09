using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DesertRage.ViewModel.Battle.Components.Actions
{
    public abstract class Action : ICommand, INotifyPropertyChanged, IViewModelObservable<BattleViewModel>
    {
        public Action(IAction action)
        {
            Effect = action;
        }

        private IAction _effect;
        public IAction Effect
        {
            get => _effect;
            set
            {
                _effect = value;
                OnPropertyChanged();
            }
        }

        public virtual void SetViewModel(BattleViewModel viewModel)
        {
            Effect.SetViewModel(viewModel);
        }

        public abstract void Execute(object parameter);

        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
