using DesertRage.Model.Locations;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using System.ComponentModel;

namespace DesertRage.ViewModel.Battle.Actions.Kinds.Dependent
{
    public class RestCommand : RecoverCommand, INotifyPropertyChanged
    {
        public RestCommand(IFormula dependency,
            NoiseUnit thing) : base(dependency, thing) { }

        public override void Use(object parameter)
        {
            User.SoundPlayer.PlayNoise(Unit.Noise);
            Rest();
            User.UpdateHero();
        }
    }
}