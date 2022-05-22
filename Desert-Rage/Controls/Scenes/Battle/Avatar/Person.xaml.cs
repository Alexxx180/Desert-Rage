using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.ViewModel.Battle;
using DesertRage.ViewModel.Battle.Actions;
using DesertRage.ViewModel.Battle.Actions.Kinds;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Customing.Converters;
using System.Windows.Threading;
using System;

namespace DesertRage.Controls.Scenes.Battle.Avatar
{
    /// <summary>
    /// Battle character component
    /// </summary>
    public partial class Person : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            BattleProperty = DependencyProperty.Register(
                nameof(Battle), typeof(BattleViewModel),
                typeof(Person));

        public BattleViewModel Battle
        {
            get => GetValue(BattleProperty) as BattleViewModel;
            set => SetValue(BattleProperty, value);
        }

        #region Timing Members
        private DispatcherTimer _timing;

        public void SetTurns()
        {
            _timing = new DispatcherTimer();
            _timing.Tick += WaitForTurn;
            _timing.Interval = new TimeSpan(0, 0, 0, 0, 50);
            _timing.Start();
        }
        #endregion

        private Bar _time;
        public Bar Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public Person()
        {
            InitializeComponent();
            Time = new Bar(0, 1000);
            SetTurns();


        }

        public void WaitForTurn(object sender, object o)
        {
            if (Time.IsMax)
                return;

            ushort speed = 10;
            speed += Battle.Player.Hero.Stats.Speed;

            Time = Time.Restore(speed);

            if (Time.IsMax)
                Strategy();
        }

        private void Strategy()
        {
            if (Battle.Player.Hero.Status[StatusID.BERSERK.Int()])
            {
                AutoFight();
                return;
            }
            //ActPanel();
        }

        public void AutoFight()
        {
            if (Battle.IsBattle)
            {
                Battle.Fight.Execute(Battle.Enemies[0]);
                Time = Time.Drain();
                //Battle.Enemies[0].Hit(Battle.Player.Hero.);
            }
                
        }

        public void ActPanel()
        {

        }

        public static byte[] AbilityBonuses = new byte[] { 0, 0, 0, 0 };

        

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