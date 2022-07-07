using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;

namespace DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent
{
    public class WeaponCommand : FightCommand
    {
        private static readonly byte _hands;

        static WeaponCommand()
        {
            _hands = ArmoryKind.Hands.Byte();
        }

        /// <summary>
        /// Hit selected enemy with a weapon
        /// </summary>
        public WeaponCommand() : base() { }

        public override NoiseUnit Unit
        {
            get
            {
                byte selection = Hero.Equipped.Weapon;
                return User.Equip[_hands][selection];
            }
        }
    }
}
