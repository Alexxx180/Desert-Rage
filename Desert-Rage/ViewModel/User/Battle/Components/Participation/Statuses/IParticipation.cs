using DesertRage.Model;
using DesertRage.ViewModel.User.Battle.Components.Participation;

namespace DesertRage.ViewModel.Battle.Components.Participation.Statuses
{
    public interface IParticipation : IModel<Participant>
    {
        public Participant Participant { get; set; }
    }
}