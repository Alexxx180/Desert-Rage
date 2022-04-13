using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Логика взаимодействия для GameEquipment.xaml
    /// </summary>
    public partial class GameEquipment : UserControl
    {
        public GameEquipment()
        {
            InitializeComponent();
        }

        //private void EquipWatch()
        //{
        //    FastEnableDisableBtn(new bool[] {
        //        GetBag.Hands && (GetHero.Weapon.Power == 0),
        //        GetBag.Jacket && (GetHero.Armor.Power == 0),
        //        GetBag.Leggings && (GetHero.Legs.Power == 0),
        //        GetBag.Foots && (GetHero.Boots.Power == 0),
        //        !GetBag.Hands && (GetHero.Weapon.Power != 0),
        //        !GetBag.Jacket && (GetHero.Armor.Power != 0),
        //        !GetBag.Leggings && (GetHero.Legs.Power != 0),
        //        !GetBag.Foots && (GetHero.Boots.Power != 0) },
        //        Equip1, Equip2, Equip3, Equip4, Remove1,
        //        Remove2, Remove3, Remove4);
        //}

        //private void OnRemove_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    btn.IsEnabled = false;
        //    Equipment equipment = btn.Tag as Equipment;
        //    Equipment bare = EquipInfo.GetEquip(btn);
        //    if (equipment.Name == GetHero.Weapon.Name)
        //        GetHero.Weapon = (Equipment.Weapon)bare;
        //    else if (equipment.Name == GetHero.Armor.Name)
        //        GetHero.Armor = (Equipment.Armor)bare;
        //    else if (equipment.Name == GetHero.Legs.Name)
        //        GetHero.Legs = (Equipment.Armor)bare;
        //    else
        //        GetHero.Boots = (Equipment.Armor)bare;
        //    GetBag.ReEquip(bare.Name, true);
        //    OnPropertyChanged(nameof(GetBag));
        //    OnPropertyChanged(nameof(GetHero));
        //    OnPropertyChanged(nameof(GetATK));
        //    OnPropertyChanged(nameof(GetDEF));
        //    EquipWatch();
        //}

        //private void OnEquip_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    BitmapImage[][] bitmapImages = {
        //        BmpersToX(Paths.Static.BtnImgs.Usual.Knucleduster,
        //        Paths.Static.BtnImgs.Usual.AncientKnife,
        //        Paths.Static.BtnImgs.Usual.LegendSword,
        //        Paths.Static.BtnImgs.Usual.SeriousMinigun),
        //        BmpersToX(Paths.Static.BtnImgs.Usual.LeatherArmor,
        //        Paths.Static.BtnImgs.Usual.AncientArmor,
        //        Paths.Static.BtnImgs.Usual.LegendArmor,
        //        Paths.Static.BtnImgs.Usual.SeriousTshirt),
        //        BmpersToX(Paths.Static.BtnImgs.Usual.FeatherWears,
        //        Paths.Static.BtnImgs.Usual.AncientPants,
        //        Paths.Static.BtnImgs.Usual.LegendPants,
        //        Paths.Static.BtnImgs.Usual.SeriousPants),
        //        BmpersToX(Paths.Static.BtnImgs.Usual.BandageBoots,
        //        Paths.Static.BtnImgs.Usual.StrongBoots,
        //        Paths.Static.BtnImgs.Usual.LegendBoots,
        //        Paths.Static.BtnImgs.Usual.SeriousBoots)
        //    };
        //    Equipment[][] equipment = {
        //        new Equipment.Weapon[] { Knuckle, Knife, Sword, Minigun },
        //        new Equipment.Armor[] { BlackCoat, AncientArmor,
        //            LegendArmor, CoolTShirt },
        //        new Equipment.Armor[] { FeatherPants, WarriorPants,
        //            LegendPants, SeriousPants },
        //        new Equipment.Armor[] { BandageBoots, ManBoots,
        //            LegendBoots, SeriousBoots }
        //    };
        //    Equipment[] BareEq = { BareHands, Shirt, Pants, CleanBoots };
        //    Button[] EqButtons = { Equipments, Equipments2,
        //        Equipments3, Equipments4 };
        //    BitArray[] SomeEquipHave = { GetBag.Weapons, GetBag.Armors,
        //        GetBag.Panties, GetBag.ArmBoots };
        //    Sets.EquipmentClass = Bits(btn.Tag);
        //    for (int i = 0; i < SomeEquipHave[Sets.EquipmentClass].Length; i++)
        //        if (SomeEquipHave[Sets.EquipmentClass][i])
        //        {
        //            AnyShow(EqButtons[i]);
        //            EqButtons[i].Tag = equipment[Sets.EquipmentClass][i];
        //            EquipInfo.SetEquip(EqButtons[i], BareEq[Sets.EquipmentClass]);
        //        }
        //    FastImgChange(bitmapImages[Sets.EquipmentClass], EquipmentsImg,
        //        Equipments2Img, Equipments3Img, Equipments4Img);
        //    AnyShow(CancelEq);
        //}

        //private void RemoveButtons_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    Equipment equipment = btn.Tag as Equipment;
        //    Label current = sender.Equals(Remove1) ? AddATK1 : AddDEF1;
        //    current.Foreground = new SolidColorBrush(Color.FromRgb(199, 15, 15));
        //    current.Content = $"-{equipment.Power}";
        //    AnyShow(current);
        //}

        //private void RemoveButtons_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    AnyHide(sender.Equals(Remove1) ? AddATK1 : AddDEF1);
        //}

        //private void AnyEquipments_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    AnyHideX(AddATK1, AddDEF1);
        //}

        //private void AnyEquipments_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    Equipment equip = btn.Tag as Equipment;
        //    Label caption = (equip.GetType().Name == "Weapon") ? AddATK1 : AddDEF1;
        //    AnyShowX(Describe1, caption);
        //    caption.Foreground = new SolidColorBrush(Color.FromRgb(255, 210, 6));
        //    caption.Content = "+" + equip.Power;
        //    Describe1.Content = equip.Description;
        //}

        //private void AnyEquipments_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    Equipment equipment = btn.Tag as Equipment;
        //    Equipment bare = EquipInfo.GetEquip(btn);
        //    AnyHide(Describe1);
        //    Dictionary<string, string> pairs = new Dictionary<string, string> {
        //        { "Weapon", "Hands" }, { "Armor", "Jacket" },
        //        { "Legs", "Leggings" }, { "Boots", "Foots" }
        //    };
        //    GetHero.GetType().GetProperty(bare.Type).SetValue(GetHero, equipment);
        //    GetBag.GetType().GetProperty(pairs[bare.Type]).SetValue(GetBag, false);
        //    OnPropertyChanged(nameof(GetBag));
        //    OnPropertyChanged(nameof(GetHero));
        //    OnPropertyChanged(nameof(GetATK));
        //    OnPropertyChanged(nameof(GetDEF));
        //    AnyHideX(Equipments, Equipments2, Equipments3, Equipments4, CancelEq);
        //    EquipWatch();
        //}


        //private void CancelEq_Click(object sender, RoutedEventArgs e)
        //{
        //    AnyHideX(Equipments, Equipments2, Equipments3, Equipments4, CancelEq);
        //}
    }
}
