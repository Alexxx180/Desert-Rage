using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class StatusEvent : Participation, IStatusEvent
    {
        /// <summary>
        /// Status event to be attached to battle partiticipant
        /// <param name="participant">Battle participant</param>
        public StatusEvent(Participant participant) : base(participant) { }

        public virtual void StateEvent(object sender, object o)
        {
            if (Participant.IsDead ||
                Participant.NoStatus(Status))
            {
                Unit.HealStatus(Status.Int());
                RemoveEvent();
            }
        }

        protected void RemoveEvent()
        {
            Participant.ViewModel.RemoveStateEvent(this);
        }

        private protected StatusID Status;
    }
}
