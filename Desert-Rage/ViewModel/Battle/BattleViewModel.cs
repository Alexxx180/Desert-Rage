using System.ComponentModel;
using DesertRage.Controls.Scenes;
using DesertRage.ViewModel.Battle.Components.Participation;

namespace DesertRage.ViewModel.Battle
{
    public class BattleViewModel : Arrangement, INotifyPropertyChanged
    {
        #region UI Members
        public BattleScene Scene { get; set; }
        public MainWindow Entry { get; set; }
        #endregion
        
        private BattleViewModel() : base()
        {
            Scene = new BattleScene(this);
            Setup(this);
        }

        public BattleViewModel(UserProfile profile) : this()
        {
            Human = new Person(this, profile);
            StartTurns(Human);
        }

        #region Hero Members
        private Person _human;
        public Person Human
        {
            get => _human;
            set
            {
                _human = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Options
        public override void Start()
        {
            Entry.Display.Content = Scene;
            base.Start();
            Scene.RaiseEnter();
        }

        private protected override void End()
        {
            Scene.RaiseEscape();
            Human.Player.Peace();
        }

        private protected override void Freeze()
        {
            Human.Player.Stop();
            base.Freeze();
            EndTurns(Human);
        }

        public override void Won()
        {
            Human.Player.AddExperience(Experience);
            Human.Player.Stop();
            Human.Player.SoundPlayer.PlaySound("/Resources/Media/OST/Sounds/Info/Won.mp3".ToFull());
            End();
        }

        public void Lose()
        {
            Freeze();
            Entry.RaiseEscape();
        }
        #endregion
    }
}