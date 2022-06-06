﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Locations;
using DesertRage.ViewModel.Battle;
using Range = DesertRage.Model.Locations.Battle.Range;

namespace DesertRage.Controls.Scenes
{
    /// <summary>
    /// Логика взаимодействия для BattleScene.xaml
    /// </summary>
    public partial class BattleScene : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            BattleModelProperty = DependencyProperty.Register(
                nameof(BattleModel), typeof(BattleViewModel),
                typeof(BattleScene));

        public BattleViewModel BattleModel
        {
            get => GetValue(BattleModelProperty) as BattleViewModel;
            set => SetValue(BattleModelProperty, value);
        }

        #region Escaping Event Members
        public static readonly RoutedEvent
            EscapingEvent = EventManager.RegisterRoutedEvent(
                nameof(Escaping), RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(BattleScene));

        public event RoutedEventHandler Escaping
        {
            add { AddHandler(EscapingEvent, value); }
            remove { RemoveHandler(EscapingEvent, value); }
        }

        public void RaiseEscape()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(EscapingEvent);
            Curtain.RaiseEvent(newEventArgs);
        }
        #endregion

        #region Entering Event Members
        public static readonly RoutedEvent
            EnteringEvent = EventManager.RegisterRoutedEvent(
                nameof(Entering), RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(BattleScene));

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

        public static readonly Range SceneArea;

        static BattleScene()
        {
            SceneArea = new Range
            {
                Point1 = new Position(1, 1),
                Point2 = new Position(5, 3)
            };
        }

        public BattleScene
            (BattleViewModel battle)
        {
            InitializeComponent();
            BattleModel = battle;
        }

        private Uri _battleBackground;
        public Uri BattleBackground
        {
            get => _battleBackground;
            set
            {
                _battleBackground = value;
                OnPropertyChanged();
            }
        }

        public void ReturnToMap()
        {
            Label display = Parent as Label;
            LevelMap map = BattleModel.Human.Player.Location;
            display.Content = map;
            map.RaiseEnter();
        }

        private void Exit(object sender, EventArgs e)
        {
            ReturnToMap();
        }

        private void BattleStart(object sender, EventArgs e)
        {
            BattleModel.Resume();
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