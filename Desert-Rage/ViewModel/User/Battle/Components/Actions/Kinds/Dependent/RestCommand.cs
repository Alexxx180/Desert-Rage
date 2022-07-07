using System.ComponentModel;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class RestCommand : RecoverCommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Refill some amount of hero AP
        /// </summary>
        public RestCommand() : base() { }

        public override void Use(object parameter)
        {
            Act();
            Rest();
        }
    }
}
