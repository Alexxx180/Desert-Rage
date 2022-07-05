using System.ComponentModel;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Helpers;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class CureCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Refill some amount of hero HP
        /// </summary>
        /// <param name="dependency">Cure power formula</param>
        /// <param name="thing">Thing info</param>
        public CureCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
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
