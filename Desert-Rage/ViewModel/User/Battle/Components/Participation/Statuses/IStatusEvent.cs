namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public interface IStatusEvent : IParticipation
    {
        public void StateEvent(object sender, object o);
    }
}