using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class RestMaxCommand : RecoverMaxCommand
    {
        /// <summary>
        /// Fully refills hero AP
        /// </summary>
        public RestMaxCommand() : base() { }

        public override void Use(object parameter)
        {
            Act();
            Rest();
        }
    }
}
