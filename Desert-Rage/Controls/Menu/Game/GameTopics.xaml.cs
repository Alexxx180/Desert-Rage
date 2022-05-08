using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DesertRage.Customing;
using DesertRage.Model.Menu;
using DesertRage.ViewModel;
using System.Windows.Data;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Game menu topics selection
    /// </summary>
    public partial class GameTopics : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            PlayerProperty = DependencyProperty.Register(nameof(Player),
                typeof(UserProfile), typeof(GameTopics));

        public static readonly DependencyProperty
            MenuTopicProperty = DependencyProperty.Register(
                nameof(MenuTopic), typeof(Label), typeof(GameTopics));

        public UserProfile Player
        {
            get => GetValue(PlayerProperty) as UserProfile;
            set => SetValue(PlayerProperty, value);
        }

        public Label MenuTopic
        {
            get => GetValue(MenuTopicProperty) as Label;
            set => SetValue(MenuTopicProperty, value);
        }

        private ObservableCollection<Topic> _topics;
        public ObservableCollection<Topic> Topics
        {
            get => _topics;
            set
            {
                _topics = value;
                OnPropertyChanged();
            }
        }

        public GameTopics()
        {
            InitializeComponent();
            SetTopics();
        }

        public void SetTopics()
        {
            GameStatus status = new GameStatus();
            status.Bind(GameStatus.PlayerProperty, this, nameof(Player));

            GameSkills skills = new GameSkills();
            skills.Bind(GameSkills.PlayerProperty, this, nameof(Player));

            GameItems items = new GameItems();
            items.Bind(GameItems.PlayerProperty, this, nameof(Player));

            GameSettings sets = new GameSettings();
            sets.Bind(GameSettings.PlayerProperty, this, nameof(Player),
                BindingMode.TwoWay, UpdateSourceTrigger.LostFocus);

            Topics = new ObservableCollection<Topic>
            {
                new Topic
                {
                    Name = "Статус",
                    Icon = "/Resources/Images/Menu/Topics/Status.svg",
                    TopicElement = status
                },
                new Topic
                {
                    Name = "Умения",
                    Icon = "/Resources/Images/Menu/Topics/Actions.svg",
                    TopicElement = skills
                },
                new Topic
                {
                    Name = "Предметы",
                    Icon = "/Resources/Images/Menu/Topics/Items.svg",
                    TopicElement = items
                },
                new Topic
                {
                    Name = "Настройки",
                    Icon = "/Resources/Images/Menu/Topics/Settings.svg",
                    TopicElement = sets
                }
            };
        }

        private void OnTopicSelection(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            MenuTopic.Content = (list.SelectedItem as Topic).TopicElement;
        }

        //private void Status_Click(object sender, RoutedEventArgs e)
        //{
        //    HideMenuSections();
        //    AnyShow(GameMenuSelect);
        //    HeroStatus();
        //}

        //private void HeroAbilities()
        //{
        //    AnyShow(GameMenuSelect);
        //    AnyShowX(GameSkills);
        //}

        //private void Abils_Click(object sender, RoutedEventArgs e)
        //{
        //    HideMenuSections();
        //    HeroAbilities();
        //    FastTextChange(new Label[] { Describe1, Describe2 },
        //        new string[] { Txts.Hints.Skills, Txts.Sections.Skills });
        //    AnyShowX(Describe2, DescribeHeader, Describe1);
        //}

        //private void HeroItems()
        //{
        //    AnyShow(GameMenuSelect);
        //    CraftSwitchLab.Content = "Создание";
        //    FastTextChange(new Label[] { Describe1, Describe2 },
        //        new string[] { Txts.Hints.Items, Txts.Sections.Items });
        //    AnyShow(GameItems);
        //}

        //private void Items0_Click(object sender, RoutedEventArgs e)
        //{
        //    HideMenuSections();
        //    HeroItems();
        //}

        //private void CountHide(object sender, MouseEventArgs e)
        //{
        //    AnyHide(CountText);
        //}

        //private void HeroEquip()
        //{
        //    AnyShow(GameMenuSelect);
        //    AnyShowX(GameEquip);
        //    FastEnableDisableBtn(false, Remove1, Remove2, Remove3,
        //        Remove4, Equip1, Equip2, Equip3, Equip4);
        //    FastTextChange(new Label[] { Describe1, Describe2 },
        //        new string[] { Txts.Hints.Equip, Txts.Sections.Equip });
        //}

        //private void Equip_Click(object sender, RoutedEventArgs e)
        //{
        //    HideMenuSections();
        //    HeroEquip();
        //    EquipWatch();
        //}

        //private void Tasks_Click(object sender, RoutedEventArgs e)
        //{
        //    HideMenuSections();
        //    AnyShow(GameTasks);
        //    AnyShow(GameMenuSelect);
        //    RealTasks();
        //    MiniTasks();
        //    FastTextChange(new Label[] { Describe1, Describe2 },
        //        new string[] { Txts.Hints.Tasks, Txts.Sections.Tasks });
        //}

        ////[EN] Game settings
        ////[RU] Настройки игры.
        //private void Settings_Click(object sender, RoutedEventArgs e)
        //{
        //    HideMenuSections();
        //    AnyShow(TimerTurnOn);
        //    HeroSettings();
        //}

        //private void HeroSettings()
        //{
        //    AnyShow(GameMenuSelect);
        //    AnyShow(GameSettings);
        //    FastTextChange(new Label[] { Describe1, Describe2 },
        //        new string[] { Txts.Hints.Setts, Txts.Sections.Setts });
        //}

        //private void Info_Click(object sender, RoutedEventArgs e)
        //{
        //    HideMenuSections();
        //    AnyShowX(HelpHints);
        //    Txts.Docs.InfoChange1 = 0;
        //    FastInfoChange(new TextBlock[] { InfoText1, InfoText2, InfoText3 },
        //        new Label[] { InfoHeaderText1, InfoHeaderText2, InfoHeaderText3 },
        //        new string[] { Txts.Docs.HelpInfo2[0, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo2[1, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo2[2, Txts.Docs.InfoChange1] },
        //        new string[] { Txts.Docs.HelpInfo1[0, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo1[1, Txts.Docs.InfoChange1],
        //            Txts.Docs.HelpInfo1[2, Txts.Docs.InfoChange1] });
        //    FastTextChange(new Label[] { InfoIndex, Describe1, Describe2 },
        //        new string[] { Txts.Docs.InfoChange1 + 1 + "/19",
        //            Txts.Hints.Infos, Txts.Sections.Infos });
        //    AnyShow(SwitchPanel);
        //    GameHint();
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