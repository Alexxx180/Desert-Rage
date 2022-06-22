using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.ViewModel.User;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds
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
        protected MapWorker User => Man.Player;
        protected Character Hero => User.Hero;

        public NoiseUnit Unit { get; }
    }
}