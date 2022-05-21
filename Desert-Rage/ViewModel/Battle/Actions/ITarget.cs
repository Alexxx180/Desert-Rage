using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.Battle.Actions
{
    public interface ITarget : IBattle
    {
        public Targeting UnitCursor { get; set; }
    }
}