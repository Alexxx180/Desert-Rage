using System;
using System.ComponentModel;
using System.Diagnostics;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
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
            ushort overallSpeed = ViewModel.EnemySpeed();
            
            Trace.WriteLine("TOTAL ENEMY SPEED: " + overallSpeed);

            int barrier = Math.Max(1, overallSpeed / Power);

            Trace.WriteLine("Barrier: " + barrier); //barrier
            CheckStatus("Escape: " + Power);

            ViewModel.Escape(barrier);
        }

        public virtual bool CanUse => true;
    }
}