using DesertRage.Model.Menu.Things;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Character bag component
    /// </summary>
    public partial class GameItems : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            BagProperty = DependencyProperty.Register
                (nameof(Bag),
                typeof(ObservableCollection<Item>),
                typeof(GameItems));

        public ObservableCollection<Item> Bag
        {
            get => GetValue(BagProperty) as ObservableCollection<Item>;
            set => SetValue(BagProperty, value);
        }

        public GameItems()
        {
            InitializeComponent();
            Bag = new ObservableCollection<Item>()
            {
                new Item
                {
                    Name = "Бинт",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/AntidoteItem.png"
                }
            };
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

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}