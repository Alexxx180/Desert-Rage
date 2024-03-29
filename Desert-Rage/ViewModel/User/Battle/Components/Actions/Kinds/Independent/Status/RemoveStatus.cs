﻿using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status
{
    public class RemoveStatus : StatusCommand
    {
        /// <summary>
        /// Remove specified status
        /// </summary>

        public override void Use(object parameter)
        {
            int id = Status.Int();
            if (Hero.NoStatus(id))
                return;

            ViewModel.RemoveStateEvent(Man.StatusEvents[Status]);
            Hero.HealStatus(id);

            base.Use(parameter);
        }
    }
}
