using DesertRage.Model;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Independent
{
    public class StatusCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public StatusCommand(DescriptionUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public StatusCommand(StatusID status, bool state,
            DescriptionUnit thing) : this(thing)
        {
            Status = status;
            State = state;
        }

        public void Use(object parameter)
        {
            UserProfile user = ViewModel.Player;
            Character character = user.Hero;

            character.SetStatus(Status, State);
            user.UpdateHero();

            System.Diagnostics.Trace.WriteLine(user);
            System.Diagnostics.Trace.WriteLine(character.Hp.ToString());
        }

        public StatusID Status { get; set; }
        public bool State { get; set; }
    }
}