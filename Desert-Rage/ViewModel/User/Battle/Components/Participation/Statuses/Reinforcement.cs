using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class Reinforcement : StatusEvent
    {
        /// <summary>
        /// Simple "booster" base for status event
        /// <param name="participant">Battle participant</param>
        /// <param name="status">Required status</param>
        public Reinforcement(Participant participant,
            StatusID status) : base(participant)
        {
            Status = status;
        }
    }
}
