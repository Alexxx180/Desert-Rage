using DesertRage.Customing.Converters;
using DesertRage.Model.Menu.Battle;
using System.Collections.ObjectModel;
using DesertRage.Model.Stats.Enemy;

namespace DesertRage.ViewModel.Actions.Dependent
{
    public class FightAllCommand : ActCommand
    {
        public FightAllCommand(IThing thing) : base(thing)
        {
            UnitCursor = Targeting.ALL;
        }

        private protected override void Use(object parameter)
        {
            int power = Subject.Power.ToInt();
            System.Diagnostics.Trace.WriteLine(power);

            ObservableCollection<Foe> foes = ViewModel.Enemies;
            for (byte i = 0; i < foes.Count; i++)
            {
                foes[i].Hit(power);

                System.Diagnostics.Trace.WriteLine(foes[i].Name);
                System.Diagnostics.Trace.WriteLine(foes[i].Hp.ToString());
            }
        }
    }
}