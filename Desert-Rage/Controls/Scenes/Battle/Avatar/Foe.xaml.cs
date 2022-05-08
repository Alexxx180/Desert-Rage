using DesertRage.Customing;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats;
using DesertRage.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DesertRage.Controls.Scenes.Battle.Avatar
{
    /// <summary>
    /// Логика взаимодействия для Foe.xaml
    /// </summary>
    public partial class Foe : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            BattleProperty = DependencyProperty.Register(
                nameof(Battle), typeof(BattleViewModel),
                typeof(Foe));

        public static readonly DependencyProperty
            TileProperty = DependencyProperty.Register(
                nameof(Tile), typeof(Position), typeof(Foe));

        public static readonly DependencyProperty
            SizeProperty = DependencyProperty.Register(
                nameof(Size), typeof(Position), typeof(Foe));

        public BattleViewModel Battle
        {
            get => GetValue(BattleProperty) as BattleViewModel;
            set => SetValue(BattleProperty, value);
        }

        public Position Tile
        {
            get => (Position)GetValue(TileProperty);
            set => SetValue(TileProperty, value);
        }

        public Position Size
        {
            get => (Position)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        #region Enemy Attributes
        private DispatcherTimer _turn;

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

        private Model.Stats.Enemy.Foe _attributes;
        public Model.Stats.Enemy.Foe Attributes
        {
            get => _attributes;
            set
            {
                _attributes = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public Foe()
        {
            InitializeComponent();
            Time = new Bar(0, 1000);
        }

        public void SetTurns()
        {
            _turn = new DispatcherTimer();
            _turn.Tick += WaitForTurn;
            _turn.Interval = new TimeSpan(0, 0, 0, 0, 50);
            _turn.Start();
        }

        private void WaitForTurn(object sender, object o)
        {
            //10 + Attributes.Stats.Speed
            if (Time.Fill(out Bar newBar, 15))
            {
                _turn.Stop();
                Attack(10); //Attributes.Stats.Attack
            }

            Time = newBar;
        }

        private void Attack(ushort damage)
        {
            if (Battle.Player.Hero.Hp.Drop(out Bar newBar, damage))
            {
                _turn.Stop();
                // Application.Current.Shutdown();
            }
            Battle.Player.Hero.Hp = newBar;
        }

        public void Hit(ushort damage)
        {
            if (Attributes.Hp.Drop
                (out Bar newBar, damage))
            {
                Defeat();
            }

            Attributes.Hp = newBar;
        }

        public void Defeat()
        {
            _turn.Stop();
        }

        //private void BadTime()
        //{
        //    int strength = GetATK + (GetATK * GetAGL / 100);
        //    ushort EnemyDefence = foes[Sets.SelectedTarget].Defence;
        //    ushort total = Shrt(Math.Max(strength - EnemyDefence, 0));
        //    AnyHideX(SelectMenuFight, TargetImage);
        //    Lab2.Foreground = Brushes.White;
        //    FoesKickedOne(Sets.SelectedTarget, total, Shrt(500 / GameSpeed.Value));
        //    PhysicalAttack(MainHero.Weapon);
        //    FoesRefresh();
        //}

        //private void SuperCheckFoes(in byte seltrg)
        //{
        //    PlaySound(foes[seltrg].Death);
        //    Image[] images = { Img6, Img7, Img8 };
        //    string name = foes[seltrg].Name;
        //    RecordFoes[name]--;
        //    int count = RecordFoes[name];
        //    if (count <= 0)
        //    {
        //        _ = RecordFoes.Remove(name);
        //        AnyHide(HideCheck(name));
        //    }
        //    if (Sets.SpecialBattle == 0)
        //        AnyHide(images[seltrg]);
        //    else
        //        AnyHide(BossSlot1);
        //    foes[seltrg] = DeadFoe;
        //    FoesRefresh();
        //    Sets.SelectedTarget = ReSelect();
        //    EnemiesTotal(RecordFoes);
        //}

        //private Label HideCheck(string name)
        //{
        //    Label[] labels = { FoesCount1, FoesCount2, FoesCount3 };
        //    for (byte i = 0; i < labels.Length; i++)
        //    {
        //        if (labels[i].Content.ToString().Contains(name))
        //            return labels[i];
        //    }
        //    return labels[2];
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