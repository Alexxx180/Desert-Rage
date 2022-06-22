namespace DesertRage.ViewModel.Battle.Components.Participation.Statuses
{
    public interface IStatusEvent : IParticipation
    {
        public void StateEvent(object sender, object o);
    }
}