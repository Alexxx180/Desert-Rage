using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class Reinforcement : StatusEvent
    {
        public Reinforcement(Participant participant,
            StatusID status) : base(participant)
        {
            Status = status;
        }
    }
}