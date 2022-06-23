using DesertRage.Model;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public interface IParticipation : IModel<Participant>
    {
        public Participant Participant { get; set; }
    }
}