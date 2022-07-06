using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.ViewModel.User.Battle.Components.Participation;
using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds
{
    public class ActCommand : Target, INotifyPropertyChanged
    {
        /// <summary>
        /// Create action command,
        /// associated with thing
        /// </summary>
        public ActCommand() { }      

        private protected void SetUnit(NoiseUnit unit)
        {
            Unit = unit;
        }

        public void Act()
        {
            Man.Act();
            User.Noise(Unit.Noise);
        }

        protected Person Man => ViewModel.Human;
        protected MapWorker User => Man.Player;
        protected Character Hero => User.Hero;

        public virtual NoiseUnit Unit { get; }
    }
}
