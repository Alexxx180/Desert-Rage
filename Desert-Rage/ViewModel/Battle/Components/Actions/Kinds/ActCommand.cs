using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.ViewModel.Battle.Components.Actions;
using DesertRage.ViewModel.Battle.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds
{
    public class ActCommand : Target, INotifyPropertyChanged
    {
        public ActCommand(NoiseUnit unit)
        {
            Unit = unit;
        }

        public void Act()
        {
            Man.Act();
            User.SoundPlayer.PlayNoise(Unit.Noise);
        }

        protected Person Man => ViewModel.Human;
        protected UserProfile User => Man.Player;
        protected Character Hero => User.Hero;

        public NoiseUnit Unit { get; }
    }
}