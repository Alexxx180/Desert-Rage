using DesertRage.Customing.Converters;
using DesertRage.Model.Menu.Battle;
using System.Collections.ObjectModel;
using DesertRage.Model.Stats.Enemy;
using DesertRage.ViewModel.Battle;
using System.ComponentModel;

namespace DesertRage.ViewModel.Actions.Dependent
{
    public class FightAllCommand : ActCommand, INotifyPropertyChanged
    {
        public FightAllCommand(IThing thing) : base(thing)
        {
            UnitCursor = Targeting.ALL;
        }

        protected int Power => Subject.Power.ToInt();
        protected ObservableCollection<Enemy> Enemies => ViewModel.Enemies;

        private protected override void Use(object parameter)
        {
            System.Diagnostics.Trace.WriteLine(Power);
            System.Diagnostics.Trace.WriteLine(Enemies.Count);

            for (int i = Enemies.Count - 1; i > -1; i--)
            {
                System.Diagnostics.Trace.WriteLine("INDEX IS: "+i);
                System.Diagnostics.Trace.WriteLine(Enemies[i].Foe.Name);
                System.Diagnostics.Trace.WriteLine(Enemies[i].Foe.Hp.ToString());
                Enemies[i].Hit(Power);
                
            }
        }
    }
}