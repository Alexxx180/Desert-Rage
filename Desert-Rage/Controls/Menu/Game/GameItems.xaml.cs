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
    /// Логика взаимодействия для GameItems.xaml
    /// </summary>
    public partial class GameItems : UserControl
    {
        public GameItems()
        {
            InitializeComponent();
        }

        //private void CraftSwitch_Click(object sender, RoutedEventArgs e)
        //{
        //    if (CraftSwitchLab.Content.ToString() == "Создание")
        //    {
        //        AnyShow(CraftItemsMenu);
        //        CraftSwitchLab.Content = "Сумка";
        //    }
        //    else
        //    {
        //        AnyHide(CraftItemsMenu);
        //        HeroItems();
        //    }
        //}

        //private void ItemsOutMenu_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Items item = (sender as Button).Tag as Items;
        //    CountText.Content = "Всего: " + item.Count;
        //    AnyShow(CountText);
        //}

        //private void ItemsOutMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    UseItem((sender as Button).Tag as Items);
        //}

        //private void CraftItems_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    Items item = btn.Tag as Items;
        //    item.Count++;
        //    GetMaterials -= item.Cost;
        //    GetBag.GetType().GetProperty(item.Name).SetValue(GetBag, item);
        //    OnPropertyChanged(nameof(GetBag));
        //    CountText.Content = "Всего: " + item.Count;
        //}

        //private void CraftPerfboots_Click(object sender, RoutedEventArgs e)
        //{
        //    GetMaterials -= 30000;
        //    GetBag.ArmBoots[3] = true;
        //    GetBag.Foots = MainHero.Boots.Power == 0;
        //    OnPropertyChanged(nameof(GetBag));
        //}

        //private void CraftPerfboots_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    CountText.Content = Txts.Common.QMark;
        //    AnyShow(CountText);
        //}
    }
}