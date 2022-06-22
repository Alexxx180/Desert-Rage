using System.ComponentModel;
using DesertRage.Controls.Scenes;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Helpers;
using DesertRage.ViewModel.User.Battle.Components.Participation;

namespace DesertRage.ViewModel.User.Battle
{
    public class BattleViewModel : Arrangement, INotifyPropertyChanged
    {
        #region UI Members
        public BattleScene Scene { get; set; }
        public MainWindow Entry { get; set; }
        #endregion

        public void SetEntryPoint(MainWindow entry)
        {
            Entry = entry;
        }

        private BattleViewModel() : base()
        {
            _grind = new Bar(1, 3, 6);

            Scene = new BattleScene(this);
            Setup(this);
        }

        public BattleViewModel(MapWorker profile) : this()
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
        private protected override void Prepare()
        {
            Entry.Display.Content = Scene;
            base.Prepare();
        }

        private protected override void AllowEnemyTurns()
        {
            base.AllowEnemyTurns();
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