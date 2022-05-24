using DesertRage.Customing.Converters;
using DesertRage.Model;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class FightAllCommand : DependentCommand, IAction, INotifyPropertyChanged
    {
        public FightAllCommand(
            IFormula dependency,
            NoiseUnit thing
            ) : base(dependency, thing)
        {
            UnitCursor = Targeting.ALL;
        }

        protected int Power => StatUnit.Power.ToInt();
        protected ObservableCollection<Enemy> Enemies => ViewModel.Enemies;

        public void Use(object parameter)
        {
            ViewModel.Human.Player.SoundPlayer.PlayNoise(Unit.Noise);

            System.Diagnostics.Trace.WriteLine(Power);
            System.Diagnostics.Trace.WriteLine(Enemies.Count);
            for (int i = Enemies.Count - 1; i > -1; i--)
            {
                System.Diagnostics.Trace.WriteLine("INDEX IS: " + i);
                System.Diagnostics.Trace.WriteLine(Enemies[i].Foe.Name);
                System.Diagnostics.Trace.WriteLine(Enemies[i].Foe.Hp.ToString());
                Enemies[i].Hit(Power);

            }
        }

        public bool CanUse => ViewModel.IsBattle;
    }
}