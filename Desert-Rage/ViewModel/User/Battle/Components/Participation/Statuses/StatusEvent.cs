using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class StatusEvent : Participation, IStatusEvent
    {
        public StatusEvent(Participant participant) : base(participant) { }

        public virtual void StateEvent(object sender, object o)
        {
            if (Participant.IsDead ||
                Participant.NoStatus(Status))
            {
                Participant.Unit.SetStatus(Status, false);
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