using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.ViewModel.User.Battle.Components.Participation;

namespace DesertRage.ViewModel.Battle.Components.Participation.Statuses
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