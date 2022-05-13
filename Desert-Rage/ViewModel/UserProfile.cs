using DesertRage.Controls.Menu.Game;
using DesertRage.Customing.Converters;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Menu.Things;
using DesertRage.Model.Stats.Player;
using DesertRage.Model.Stats.Player.Armory;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.ViewModel
{
    public class UserProfile : INotifyPropertyChanged
    {
        public UserProfile()
        {
            Preferences = new Settings();

            Weapons = new ObservableCollection<Weapon>
            {
                new Weapon
                {
                    Name = "",
                    Type = "Weapon",
                    Description = "",
                    Noise = "",
                    Power = 0,
                    Chest = 0,
                }
            };

            Armor = new ObservableCollection<Equipment>
            {
                new Equipment
                {
                    Name = "",
                    Type = "Armor",
                    Description = "",
                    Power = 0,
                    Chest = 0
                }
            };

            Pants = new ObservableCollection<Equipment>
            {
                new Equipment
                {
                    Name = "",
                    Type = "Legs",
                    Description = "",
                    Power = 0,
                    Chest = 0
                }
            };

            Boots = new ObservableCollection<Equipment>
            {
                new Equipment
                {
                    Name = "",
                    Type = "Boots",
                    Description = "",
                    Power = 0,
                    Chest = 0
                }
            };

            Items = new ObservableCollection<Item>()
            {
                new Item
                {
                    Name = "Бинт",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/Bandage.svg",
                    Description = "+50 ОЗ"
                },
                new Item
                {
                    Name = "Антидот",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/Antidote.svg",
                    Description = "- Яд"
                },
                new Item
                {
                    Name = "Эфир",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/Ether.svg",
                    Description = "+50 ОД"
                },
                new Item
                {
                    Name = "Смесь",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/Mixture.svg",
                    Description = "+80 ОЗ-ОД"
                },
                new Item
                {
                    Name = "Травы",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/Herbs.svg",
                    Description = "+350 ОЗ"
                },
                new Item
                {
                    Name = "Бутыль эфира",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/EtherBottle.svg",
                    Description = "+300 ОД"
                },
                new Item
                {
                    Name = "Спальный мешок",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/Antidote.svg",
                    Description = "100% ОЗ-ОД"
                },
                new Item
                {
                    Name = "Эликсир",
                    Count = 1,
                    Icon = "/Resources/Images/Menu/Bag/Elixir.svg",
                    Description = "100% ОЗ-ОД"
                }
            };
        }

        public string Name { get; set; }

        public Location Level { get; set; }
        public Character Hero { get; set; }
        public GameMenu Menu { get; set; }

        public Settings Preferences { get; set; }

        #region Equipment Members
        public ObservableCollection<Weapon> Weapons { get; set; }
        public ObservableCollection<Equipment> Armor { get; set; }
        public ObservableCollection<Equipment> Pants { get; set; }
        public ObservableCollection<Equipment> Boots { get; set; }
        #endregion

        public ObservableCollection<Item> Items { get; set; }

        public void Go(Direction move)
        {
            Hero.Go(Level.Map, move.ToInt());
            UpdateHero();
        }

        public void Stand()
        {
            Hero.Stand();
            UpdateHero();
        }

        public void UpdateHero()
        {
            OnPropertyChanged(nameof(Hero));
        }

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