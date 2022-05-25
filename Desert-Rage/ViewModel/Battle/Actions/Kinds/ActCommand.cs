using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Player;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds
{
    public class ActCommand : Target, INotifyPropertyChanged
    {
        public ActCommand(NoiseUnit unit)
        {
            Unit = unit;
        }

        public void Act()
        {
            User.SoundPlayer.PlayNoise(Unit.Noise);
            Man.Act();
        }

        protected void CheckStatus(string comment)
        {
            System.Diagnostics.Trace.WriteLine(comment);
            System.Diagnostics.Trace.WriteLine(Hero.Hp.ToString());
            System.Diagnostics.Trace.WriteLine(Hero.Ap.ToString());
        }

        protected Person Man => ViewModel.Human;
        protected UserProfile User => Man.Player;
        protected Character Hero => User.Hero;

        public NoiseUnit Unit { get; }
    }
}