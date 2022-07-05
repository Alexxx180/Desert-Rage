using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class LearnCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Reveal selected enemy in the bestiary
        /// </summary>
        /// <param name="thing">Thing info</param>
        public LearnCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.ONE;
        }

        public virtual void Use(object parameter)
        {
            Act();
            Enemy enemy = parameter as Enemy;
            User.AnalyzeFoe(enemy.ID);
        }

        public virtual bool CanUse => ViewModel.IsBattle;
    }
}
