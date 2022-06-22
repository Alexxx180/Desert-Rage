using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Map;
using DesertRage.ViewModel.User;

namespace DesertRage.Controls.Scenes.Map
{
    /// <summary>
    /// Location map
    /// </summary>
    public partial class LevelMap : UserControl, INotifyPropertyChanged, IControllable
    {
        #region Fighting Event Members
        public static readonly RoutedEvent
            FightingEvent = EventManager.RegisterRoutedEvent(
                nameof(Fighting), RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(LevelMap));

        public event RoutedEventHandler Fighting
        {
            add { AddHandler(FightingEvent, value); }
            remove { RemoveHandler(FightingEvent, value); }
        }

        public void RaiseBattle()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FightingEvent);
            Curtain.RaiseEvent(newEventArgs);
        }
        #endregion

        #region Entering Event Members
        public static readonly RoutedEvent
            EnteringEvent = EventManager.RegisterRoutedEvent(
                nameof(Entering), RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(LevelMap));

        public event RoutedEventHandler Entering
        {
            add { AddHandler(EnteringEvent, value); }
            remove { RemoveHandler(EnteringEvent, value); }
        }

        public void RaiseEnter()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(EnteringEvent);
            Curtain.RaiseEvent(newEventArgs);
        }
        #endregion

        private MapWorker _userData;
        public MapWorker UserData
        {
            get => _userData;
            set
            {
                _userData = value;
                OnPropertyChanged();
            }
        }

        public LevelMap()
        {
            InitializeComponent();
        }

        public LevelMap(MapWorker user) : this()
        {
            UserData = user;
        }

        public void Pause()
        {
            UserData.Pause();
        }

        public void Resume()
        {
            UserData.Resume();
        }

        public void KeyRelease(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.A:
                case Key.S:
                case Key.D:
                case Key.Up:
                case Key.Left:
                case Key.Down:
                case Key.Right:
                case Key.NumPad2:
                case Key.NumPad4:
                case Key.NumPad6:
                case Key.NumPad8:
                    UserData.Stand();
                    break;
                default:
                    break;
            }
        }

        public void KeyHandle(object sender, KeyEventArgs e)
        {
            bool peace = UserData.IsFighting == Encounter.PEACE;
            if (!peace)
                return;

            switch (e.Key)
            {
                case Key.P:
                    break;
                case Key.W:
                case Key.Up:
                case Key.NumPad8:
                    Move(Direction.UP);
                    break;
                case Key.A:
                case Key.Left:
                case Key.NumPad4:
                    Move(Direction.LEFT);
                    break;
                case Key.S:
                case Key.Down:
                case Key.NumPad2:
                    Move(Direction.DOWN);
                    break;
                case Key.D:
                case Key.Right:
                case Key.NumPad6:
                    Move(Direction.RIGHT);
                    break;
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    UserData.ViewModel.Entry.Display.Content = UserData.Menu;
                    break;
                case Key.E:
                case Key.Space:
                case Key.Enter:
                    UserData.Interact();
                    break;
                default:
                    break;
            }
        }

        private void Move(Direction direction)
        {
            UserData.Go(direction);
            if (UserData.IsFighting == Encounter.PEACE)
                return;

            RaiseBattle();
        }

        private void ContinueAdventure(object sender, EventArgs e)
        {
            UserData.ResetDanger();
        }

        private void EnemyApproaches(object sender, EventArgs e)
        {
            switch (UserData.IsFighting)
            {
                case Encounter.BOSS:
                    UserData.BossBattle();
                    break;
                default:
                    UserData.FoesBattle();
                    break;
            }
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