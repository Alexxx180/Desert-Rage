using System.ComponentModel;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Helpers;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class CureCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Refill some amount of hero HP
        /// </summary>
        public CureCommand()
        {
            UnitCursor = Targeting.HERO;
        }

        public virtual void Use(object parameter)
        {
            Act();
            Hero.Cure(Power);
        }

        protected int Power => StatUnit.Power.ToInt();

        public virtual bool CanUse => true;
    }
}