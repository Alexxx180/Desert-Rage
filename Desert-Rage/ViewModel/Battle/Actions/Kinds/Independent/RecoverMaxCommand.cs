using DesertRage.Model;
using DesertRage.Model.Locations;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Independent
{
    public class RecoverMaxCommand : CureMaxCommand, INotifyPropertyChanged
    {
        public RecoverMaxCommand(NoiseUnit thing) : base(thing) { }

        protected void Rest()
        {
            Hero.Rest();
        }

        public override void Use(object parameter)
        {
            Rest();
            base.Use(parameter);
        }
    }
}