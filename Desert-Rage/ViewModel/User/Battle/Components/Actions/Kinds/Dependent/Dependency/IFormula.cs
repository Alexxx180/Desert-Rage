namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public interface IFormula : IBattle
    {
        /// <summary>
        /// Used for creating game
        /// environment dependent
        /// battle commands
        /// </summary>
        
        public int Power { get; }
    }
}
