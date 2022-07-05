using System.ComponentModel;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Participation;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class FightCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        public FightCommand(IFormula dependency) : base(dependency)
        {
            UnitCursor = Targeting.ONE;
        }

        /// <summary>
        /// Hit selected enemy
        /// </summary>
        /// <param name="dependency">Damage power formula</param>
        /// <param name="thing">Thing info</param>
        public FightCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.ONE;
        }

        protected int Power => StatUnit.Power.ToInt();

        protected void Damage(in Enemy unit)
        {
            unit.Hit(Power);
        }

        public virtual void Use(object parameter)
        {
            Act();
            Damage(parameter as Enemy);
        }

        public bool CanUse => ViewModel.IsBattle;
    }
}
