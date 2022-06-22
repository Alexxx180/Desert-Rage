using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status
{
    public class RemoveStatus : StatusCommand
    {
        public RemoveStatus(StatusID status, NoiseUnit thing)
            : base(status, false, thing) { }

        public override void Use(object parameter)
        {
            if (!Hero.Status[Status.Int()])
                return;

            ViewModel.RemoveStateEvent(Man.StatusEvents[Status]);
            base.Use(parameter);
        }
    }
}