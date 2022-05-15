using DesertRage.Model.Stats;
using System.Collections.Generic;

namespace DesertRage.Model.Menu.Things.Commands.Dependent
{
    public class FightAllCommand : DependentCommand
    {
        public IEnumerable<BattleUnit> Units { get; set; }

        private protected override void Use(int value)
        {
            foreach (BattleUnit unit in Units)
                unit.Hit(value);
        }
    }
}