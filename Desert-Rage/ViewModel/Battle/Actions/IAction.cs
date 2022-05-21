using DesertRage.Model;
using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel.Battle.Actions
{
    public interface IAction : IBattle
    {
        public void Use(object parameter);

        public Targeting UnitCursor { get; }
        public DescriptionUnit Unit { get; }
    }
}