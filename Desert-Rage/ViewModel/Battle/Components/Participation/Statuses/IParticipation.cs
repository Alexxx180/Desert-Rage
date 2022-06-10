namespace DesertRage.ViewModel.Battle.Components.Participation.Statuses
{
    public interface IParticipation : IViewModelObservable<Participant>
    {
        public Participant Participant { get; set; }
    }
}