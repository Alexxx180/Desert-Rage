using System.ComponentModel;
using DesertRage.Controls.Scenes;
using DesertRage.ViewModel.Battle.Participation;

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
        }

        private protected override void Freeze()
        {
            base.Freeze();
            EndTurns(Human);
        }

        public override void Won()
        {
            Human.Player.AddExperience(Experience);
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