using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status
{
    public class ApplyStatus : StatusCommand
    {
        public ApplyStatus
            (StatusID status, NoiseUnit thing) : base(status, thing) { }

        public override void Use(object parameter)
        {
            int statusId = Status.Int();

            if (Hero.NoStatus(statusId))
            {
                ViewModel.AddStateEvent(Man.StatusEvents[Status]);
            }

            Hero.MakeStatus(statusId);

            base.Use(parameter);
        }
    }
}