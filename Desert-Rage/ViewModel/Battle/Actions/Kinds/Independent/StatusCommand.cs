using DesertRage.Model;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Independent
{
    public class StatusCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public StatusCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public StatusCommand(StatusID status, bool state,
            NoiseUnit thing) : this(thing)
        {
            Status = status;
            State = state;
        }

        protected UserProfile User => ViewModel.Player;
        protected Character Hero => User.Hero;

        public void Use(object parameter)
        {
            User.SoundPlayer.PlayNoise(Unit.Noise);
            Hero.SetStatus(Status, State);
            User.UpdateHero();
        }

        public StatusID Status { get; set; }
        public bool State { get; set; }

        public bool CanUse => true;
    }
}