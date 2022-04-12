using System.Windows;
using DesertRage.Model.Stats.Player.Armory;

namespace DesertRage.Helpers.Attach
{
    public static class EquipInfo
    {
        public static readonly DependencyProperty
            EquipProperty = DependencyProperty.RegisterAttached(
                "Equip", typeof(Equipment), typeof(EquipInfo),
                new PropertyMetadata(BareHands));

        public static void SetEquip(DependencyObject element, Equipment value)
        {
            element.SetValue(EquipProperty, value);
        }

        public static Equipment GetEquip(DependencyObject element)
        {
            return (Equipment)element.GetValue(EquipProperty);
        }
    }
}
