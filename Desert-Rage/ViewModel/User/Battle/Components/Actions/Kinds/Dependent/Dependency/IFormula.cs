using System.Collections.Generic;
using DesertRage.Model.Locations.Battle.Things;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public interface IFormula : IBattle
    {
        /// <summary>
        /// Power dependency abstraction
        /// </summary>
        
        public int Power { get; }
        public void SetAttributes(Dictionary<string, Attribute> attributes);
    }
}
