using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Components.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent
{
    public class LearnCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public LearnCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.ONE;
        }

        public virtual void Use(object parameter)
        {
            Act();
            Enemy enemy = parameter as Enemy;
            Hero.Learn(enemy.ID);

            System.Diagnostics.Trace.Write("Learned:\n[");
            for (byte i = 0; i < Hero.Learned.Length; i++)
            {
                System.Diagnostics.Trace.Write(Hero.Learned[i] + ", ");
            }
            System.Diagnostics.Trace.WriteLine("]");
        }

        public virtual bool CanUse => ViewModel.IsBattle;
    }
}