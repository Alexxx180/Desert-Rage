using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent
{
    public class RestMaxCommand : RecoverMaxCommand
    {
        /// <summary>
        /// Fully refills hero AP
        /// </summary>
        /// <param name="thing">Thing info</param>
        public RestMaxCommand(NoiseUnit thing) : base(thing)
        {
            UnitCursor = Targeting.HERO;
        }

        public override void Use(object parameter)
        {
            Act();
            Rest();
        }
    }
}
