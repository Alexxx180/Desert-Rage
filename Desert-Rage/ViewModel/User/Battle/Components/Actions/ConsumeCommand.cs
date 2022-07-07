using DesertRage.Model;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Things;
using System;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public class ConsumeCommand : InstantCommand, INotifyPropertyChanged, IModel<BattleViewModel>
    {
        /// <summary>
        /// Call consuming behaviour then action used
        /// </summary>
        /// <param name="subject">What and how it will be consumed</param>
        public ConsumeCommand(IThing subject)
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
        
        private protected override void SetUnit(Type command, AttributeUnit unit)
        {
            base.SetUnit(command, unit);
            Subject.SetValue(unit.Attributes["Value"].ToInt());
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
        
        public static ConsumeCommand FromUnit(IThing subject, AttributeUnit unit)
        {
            ConsumeCommand command = new ConsumeCommand(subject);
            command.SetUnit(unit);
            return command;
        }

        public override bool CanExecute(object parameter) => Subject.CanUse && base.CanExecute(parameter);
    }
}
