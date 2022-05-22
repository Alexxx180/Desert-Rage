using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.Battle.Actions
{
    public interface IAction : IBattle
    {
        public void Use(object parameter);
        public bool CanUse { get; }

        public Targeting UnitCursor { get; }
        public NoiseUnit Unit { get; }
    }
}