using DesertRage.Model.Menu.Battle;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel.Actions
{
    public abstract class ActCommand : ITarget, INotifyPropertyChanged
    {
        public ActCommand(IThing thing)
        {
            Subject = thing;
        }

        private BattleViewModel _viewModel;
        public BattleViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        private Targeting _cursor;
        public Targeting UnitCursor
        {
            get => _cursor;
            set
            {
                _cursor = value;
                OnPropertyChanged();
            }
        }

        private IThing _subject;
        public IThing Subject
        {
            get => _subject;
            set
            {
                _subject = value;
                OnPropertyChanged();
            }
        }

        public void SetViewModel(BattleViewModel viewModel)
        {
            ViewModel = viewModel;
            Subject.ViewModel = viewModel;
        }

        private protected abstract void Use(object parameter);

        public void Execute(object parameter)
        {
            Use(parameter);
            Subject.Use();
        }

        public bool CanExecute(object parameter) => Subject.CanUse;

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