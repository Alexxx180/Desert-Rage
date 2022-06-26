using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things.Storage;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status
{
    public class RemoveStatus : StatusCommand
    {
        public RemoveStatus(StatusID status, NoiseUnit thing)
            : base(status, false, thing) { }

        public override void Use(object parameter)
        {
            int id = Status.Int();
            if (!Hero.Status[id])
                return;

            ViewModel.RemoveStateEvent(Man.StatusEvents[Status]);
            Hero.HealStatus(id);

            System.Diagnostics.Trace.WriteLine("ANTIDOTE! " + Hero.Ap);
            base.Use(parameter);
        }
    }
}