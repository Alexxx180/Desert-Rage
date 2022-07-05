using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class Berserk : Reinforcement
    {
        /// <summary>
        /// Make participant take decesions each turn indepently
        /// <param name="participant">Battle participant</param>
        public Berserk(Participant participant)
            : base(participant, StatusID.BERSERK)
        { }

        public override void StateEvent(object sender, object o)
        {
            if (Participant.Time.IsMax)
            {
                Participant.Time.Drain();
                Participant.Berserk();
            }

            base.StateEvent(sender, o);
        }
    }
}
