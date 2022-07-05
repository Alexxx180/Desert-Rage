namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public interface IFormula : IBattle
    {
        /// <summary>
        /// Power dependency abstraction
        /// </summary>
        
        public int Power { get; }
    }
}
