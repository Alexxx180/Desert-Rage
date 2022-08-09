using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class RecoverCommand : CureCommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Refill some amount of hero
        /// HP and AP at the same time
        /// </summary>
        
        public RecoverCommand() : base() { }

        protected void Rest()
        {
            Man.Rest(Power);
        }

        public override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}
