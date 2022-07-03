using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class RestCommand : RecoverCommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Refill some amount of hero AP
        /// </summary>
        /// <param name="dependency">Rest power formula</param>
        /// <param name="thing">Skill info</param>
        public RestCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing) { }

        public override void Use(object parameter)
        {
            Act();
            Rest();
        }
    }
}