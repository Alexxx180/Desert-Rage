using System.Collections.Generic;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency
{
    public class SpeedFormula : Battle, IFormula, INotifyPropertyChanged
    {
        /// <summary>
        /// Power dependency, based on hero speed stat
        /// </summary>
        
        public void SetAttributes(Dictionary<string, float> attributes) { }
        
        public int Power => ViewModel.Human.Unit.Stats.Speed;
    }
}
