namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class OsmoseCommand : DrainCommand
    {
        /// <summary>
        /// Hit selected enemy and
        /// fill with its lost HPs
        /// hero APs
        /// </summary>
        public OsmoseCommand() : base() { }

        protected override void Restore(ushort points)
        {
            Hero.Rest(points);
        }
    }
}
