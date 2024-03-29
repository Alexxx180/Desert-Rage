﻿using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Participation.Statuses
{
    public class Poison : Reinforcement
    {
        /// <summary>
        /// Drain battle participant HP each turn 
        /// <param name="participant">Battle participant</param>
        public Poison(Participant participant) :
            base(participant, StatusID.POISON)
        { }

        public override void StateEvent(object sender, object o)
        {
            base.StateEvent(sender, o);
            Participant.ToughHit(1);
        }
    }
}
