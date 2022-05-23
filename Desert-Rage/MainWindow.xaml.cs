using System.Collections;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Helpers;
using static DesertRage.Writers.Processors;
using DesertRage.ViewModel;
using DesertRage.Model.Locations;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Controls.Scenes.Map;
using DesertRage.ViewModel.Battle;
using DesertRage.Resources.OST.Noises.Actions;
using DesertRage.Helpers.Attach;
using DesertRage.Controls;

namespace DesertRage
{
    /// <summary>
    /// [EN] Interaction logic for game triggers.
    /// [RU] Интерактивная логика для внутренних механизмов.
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            UserProfile user = LevelMap.GetUserData();
            user.SetSoundPlayer(SoundTrack);

            Display.Content = new BattleScene(new BattleViewModel(user));
        }

        internal UserProfile Player { get; set; }

        internal Character Ray = new Character
        {
            Level = 1,
            Place = new Position(18, 34),

            Icon = Paths.Static.Person.Usual,
            Image = Paths.Static.Person.Usual,

            Hp = new Bar(100),
            Ap = new Bar(40),

            Stats = new BattleStats(25, 15, 15, 25),

            Learned = new BitArray(16),

            Gear = new Outfit(0)
        };

        internal Character Sam = new Character
        {
            Level = 1,

            Icon = Paths.Static.Person.Usual,
            Image = Paths.Static.Person.Usual,

            Hp = new Bar(100),
            Ap = new Bar(100),

            Stats = new BattleStats(50),

            Learned = new BitArray(16),

            Gear = new Outfit(0)
        };

        internal Character MainHero { get; set; }

        private void New_game()
        {
            Player.Hero = ReadJson<Character>("Ray/Beginner.json");
            Player.Level = ReadJson<Location>("SecretTemple.json");
        }

        private void SaveGame()
        {
            //PlaySound(Paths.OST.Sounds.ControlSave);
            SaveProfile("Ray.json", Player);
        }

        #region RoutedEvent Members
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Close();
                    break;
                default:
                    TransferKeyDown(sender, e);
                    break;
            };
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            TransferKeyUp(sender, e);
        }

        private void TransferKeyDown(object sender, KeyEventArgs e)
        {
            if (Display.Content is IControllable keyPad)
            {
                keyPad.KeyHandle(sender, e);
            }
        }

        private void TransferKeyUp(object sender, KeyEventArgs e)
        {
            if (Display.Content is IControllable keyPad)
            {
                keyPad.KeyRelease(sender, e);
            }
        }
        #endregion

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