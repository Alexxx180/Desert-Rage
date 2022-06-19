using System;
using System.ComponentModel;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds.Dependent
{
    public class EscapeCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        public EscapeCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing)
        {
            UnitCursor = Targeting.HERO;
        }

        protected int Power => StatUnit.Power.ToInt();

        public virtual void Use(object parameter)
        {
            Act();

            ushort overallSpeed = ViewModel.TrapLevel;
            int barrier = Math.Max(1, overallSpeed / Power);
            ViewModel.Escape(barrier);
        }

        public virtual bool CanUse => User.IsFighting != Encounter.BOSS;
    }
}