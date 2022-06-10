﻿using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent.Status
{
    public class ApplyStatus : StatusCommand
    {
        public ApplyStatus(StatusID status, NoiseUnit thing)
            : base(status, true, thing) { }

        public override void Use(object parameter)
        {
            int statusId = Status.Int();

            if (Hero.Status[statusId])
            {
                Hero.StatusTiming[statusId].Fill();
            }
            else
            {
                ViewModel.AddStateEvent(Man.StatusEvents[Status]);
            }

            base.Use(parameter);
        }
    }
}