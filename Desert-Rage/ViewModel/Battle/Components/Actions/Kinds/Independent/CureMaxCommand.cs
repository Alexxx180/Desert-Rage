using DesertRage.Model.Locations.Battle;
using System.ComponentModel;
using DesertRage.Model.Locations;

namespace DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent
{
    public class CureMaxCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        public CureMaxCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public virtual void Use(object parameter)
        {
            Act();
            Hero.Cure();
        }

        public virtual bool CanUse => true;
    }
}