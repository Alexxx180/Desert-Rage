using System;
using System.ComponentModel;
using System.Diagnostics;
using DesertRage.Customing.Converters;
using DesertRage.Model;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class EscapeCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        public EscapeCommand(
            IFormula dependency,
            DescriptionUnit thing
            ) : base(dependency, thing)
        {
            UnitCursor = Targeting.HERO;
        }

        protected int Power => StatUnit.Power.ToInt();

        public virtual void Use(object parameter)
        {
            ushort overallSpeed = ViewModel.EnemySpeed();
            
            Trace.WriteLine("TOTAL ENEMY SPEED: " + overallSpeed);

            int barrier = Math.Max(1, overallSpeed / Power);

            Trace.WriteLine("Barrier: " + barrier); //barrier
            CheckStatus();

            ViewModel.Escape(barrier);
        }

        protected void CheckStatus()
        {
            System.Diagnostics.Trace.WriteLine("ESCAPE....");
            System.Diagnostics.Trace.WriteLine(Power);
        }

        public virtual bool CanUse => true;
    }
}
