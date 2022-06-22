using DesertRage.Model;
using DesertRage.ViewModel.User.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public class ConsumeCommand : InstantCommand, INotifyPropertyChanged, IModel<BattleViewModel>
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

        public override void SetModel(BattleViewModel model)
        {
            base.SetModel(model);
            Subject.SetModel(model);
        }

        public override void Execute(object parameter)
        {
            Subject.Use();
            base.Execute(parameter);
        }

        public override bool CanExecute(object parameter) => Subject.CanUse && base.CanExecute(parameter);
    }
}