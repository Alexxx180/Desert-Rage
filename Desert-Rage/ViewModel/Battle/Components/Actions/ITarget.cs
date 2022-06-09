using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.Battle.Components.Actions
{
    public interface ITarget : IBattle
    {
        public Targeting UnitCursor { get; set; }
    }
}