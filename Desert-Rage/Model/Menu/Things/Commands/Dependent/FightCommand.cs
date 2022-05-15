using DesertRage.Model.Stats;

namespace DesertRage.Model.Menu.Things.Commands.Dependent
{
    public class FightCommand : DependentCommand
    {
        public BattleUnit Unit { get; set; }

        private protected override void Use(int value)
        {
            Unit.Hit(value);
        }
    }
}