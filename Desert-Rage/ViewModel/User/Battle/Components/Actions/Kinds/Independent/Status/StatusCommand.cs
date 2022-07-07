using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Things;
using DesertRage.Model.Locations.Battle.Things.Storage;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status
{
    public class StatusCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Status container
        /// </summary>
        public StatusCommand()
        {
            UnitCursor = Targeting.HERO;
        }

        public override void SetUnit(AttributeUnit unit)
        {
            base.SetUnit(unit);
            Status = (StatusID)unit.Attributes["Status"].ToInt();
        }

        public virtual void Use(object parameter)
        {
            Act();
        }

        public StatusID Status { get; set; }

        public virtual bool CanUse => true;
    }
}
