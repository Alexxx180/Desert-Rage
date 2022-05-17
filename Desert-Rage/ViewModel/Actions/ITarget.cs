using DesertRage.Model.Menu.Battle;
using System.Windows.Input;

namespace DesertRage.ViewModel.Actions
{
    public interface ITarget : ICommand
    {
        public Targeting UnitCursor { get; set; }

        public BattleViewModel ViewModel { get; set; }
    }
}
