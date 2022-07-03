using DesertRage.Model;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public class ConsumeCommand : InstantCommand, INotifyPropertyChanged, IModel<BattleViewModel>
    {
        /// <summary>
        /// Call consuming behaviour then action used
        /// </summary>
        /// <param name="action">What need to be done</param>
        /// <param name="subject">What and how it will be consumed</param>
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