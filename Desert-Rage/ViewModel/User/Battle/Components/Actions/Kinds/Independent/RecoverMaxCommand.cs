using DesertRage.Model.Locations.Battle;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class RecoverMaxCommand : CureMaxCommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Fully refills hero HP
        /// and AP at the same time
        /// </summary>
        /// <param name="thing">Skill info</param>
        public RecoverMaxCommand(NoiseUnit thing) : base(thing) { }

        protected void Rest()
        {
            Hero.Rest();
        }

        public override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}