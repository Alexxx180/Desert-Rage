using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Components.Actions
{
    public class ConsumeCommand : InstantCommand, INotifyPropertyChanged, IViewModelObservable<BattleViewModel>
    {
        public ConsumeCommand(IAction action, IThing subject) : base(action)
        {
            Subject = subject;
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

        public override void SetViewModel(BattleViewModel viewModel)
        {
            base.SetViewModel(viewModel);
            Subject.SetViewModel(viewModel);
        }

        public override void Execute(object parameter)
        {
            Subject.Use();
            base.Execute(parameter);
        }

        public override bool CanExecute(object parameter) => Subject.CanUse && base.CanExecute(parameter);
    }
}