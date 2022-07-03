using DesertRage.Model.Locations.Battle;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class CureMaxCommand : ActCommand, IAction, INotifyPropertyChanged
    {
        /// <summary>
        /// Fully refill hero HP
        /// </summary>
        /// <param name="thing">Skill info</param>
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