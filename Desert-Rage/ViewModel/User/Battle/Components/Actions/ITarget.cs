using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.User.Battle.Components.Actions
{
    public interface ITarget : IBattle
    {
        public Targeting UnitCursor { get; set; }
    }
}