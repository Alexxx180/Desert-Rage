using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DesertRage.ViewModel;
using System.Windows.Data;
using DesertRage.ViewModel.Menu;
using DesertRage.Decorators.UI.Bindings;
using DesertRage.Controls.Menu.Bestiary;

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

            BestiaryLayout bestiary = new BestiaryLayout();
            bestiary.Bind(BestiaryLayout.PlayerProperty, this, nameof(Player));

            GameSettings sets = new GameSettings();
            sets.Bind(GameSettings.PlayerProperty, this, nameof(Player),
                BindingMode.TwoWay, UpdateSourceTrigger.LostFocus);

            Topics = new ObservableCollection<Topic>
            {
                new Topic
                {
                    Name = "Статус",
                    Icon = "/Resources/Media/Images/Battle/Character/Ray/Icon.svg",
                    TopicElement = status
                },
                new Topic
                {
                    Name = "Умения",
                    Icon = "/Resources/Media/Images/Menu/Topics/Actions.svg",
                    TopicElement = skills
                },
                new Topic
                {
                    Name = "Предметы",
                    Icon = "/Resources/Media/Images/Menu/Topics/Items.svg",
                    TopicElement = items
                },
                new Topic
                {
                    Name = "Бестиарий",
                    Icon = "/Resources/Media/Images/Menu/Skills/Analyze.svg",
                    TopicElement = bestiary
                },
                new Topic
                {
                    Name = "Настройки",
                    Icon = "/Resources/Media/Images/Menu/Topics/Settings.svg",
                    TopicElement = sets
                }
            };
        }

        private void OnTopicSelection(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            MenuTopic.Content = (list.SelectedItem as Topic).TopicElement;
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