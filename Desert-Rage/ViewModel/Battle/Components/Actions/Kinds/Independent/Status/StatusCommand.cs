using DesertRage.Model.Helpers;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent.Status
{
    public class StatusCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public StatusCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public StatusCommand(StatusID status, bool state,
            NoiseUnit thing) : this(thing)
        {
            Status = status;
            State = state;
        }

        public virtual void Use(object parameter)
        {
            Act();

            if (Hero.Status[Status.Int()])
            {

                if (!State)
                    ViewModel.RemoveStateEvent(Man.StatusEvents[Status]);
                else
                    Hero.StatusTiming[Status.Int()].Fill();
            }
            else
            {

                if (State)
                    ViewModel.AddStateEvent(Man.StatusEvents[Status]);
            }

            Hero.SetStatus(Status, State);
        }

        public StatusID Status { get; set; }
        public bool State { get; set; }

        public bool CanUse => true;
    }
}