using System.ComponentModel;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.ViewModel.Battle.Components.Participation;
using DesertRage.Model.Helpers;

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
            _grind = new Bar(1, 3, 6);

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

        private void Grind(in Enemy enemy)
        {
            if (_chance.From(_grind))
            {
                Human.Player.IncreaseItemCount(enemy.Drop);
            }
        }

        private readonly Bar _grind;
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

        internal override void EnemyDefeat(in Enemy enemy)
        {
            Grind(enemy);
            base.EnemyDefeat(enemy);
        }

        public override void Won()
        {
            Human.Player.AddExperience(Experience);
            Human.Player.Stop();
            Human.Player.Sound("Info/Won.mp3");
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