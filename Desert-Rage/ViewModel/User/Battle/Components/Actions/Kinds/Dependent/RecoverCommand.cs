using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class RecoverCommand : CureCommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Refill some amount of hero
        /// HP and AP at the same time
        /// </summary>
        /// <param name="dependency">Recover power formula</param>
        /// <param name="thing">Skill info</param>
        public RecoverCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing) { }

        protected void Rest()
        {
            Hero.Rest(Power);
        }

        public override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}