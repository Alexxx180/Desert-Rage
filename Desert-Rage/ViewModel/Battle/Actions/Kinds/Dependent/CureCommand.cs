using System.ComponentModel;
using DesertRage.Customing.Converters;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class CureCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        public CureCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public virtual void Use(object parameter)
        {
            Act();
            Hero.Cure(Power);
            User.UpdateHero();
            CheckStatus("CURE! " + Power);
        }

        protected int Power => StatUnit.Power.ToInt();

        public virtual bool CanUse => true;
    }
}