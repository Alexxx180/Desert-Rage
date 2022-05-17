using DesertRage.Customing;
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

        public Person()
        {
            InitializeComponent();
            Time = new Bar(0, 1000);
            SetTurns();
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
            ushort speed = 10;

            speed += Battle.Player.Hero.Stats.Speed;

            if (Time.Fill(out Bar newBar, speed))
            {
                _turn.Stop();
                MOptions.SetActive(true);

                System.Diagnostics.Trace.WriteLine("FOR REAL:");
                System.Diagnostics.Trace.WriteLine(Battle.Player.Hero.Hp.ToString());
                OnPropertyChanged(nameof(Battle.Player));
            }

            Time = newBar;
        }

        public static byte[] AbilityBonuses = new byte[] { 0, 0, 0, 0 };

        //#region BattleOptions
        ////[EN] Battle : Person attack.
        ////[RU] Сражение : Атака героя.
        //private void Attack(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(FightMenu);
        //    AnyShow(SelectMenuFight);
        //    SelectTarget();
        //}

        ////[EN] Battle : Person defence.
        ////[RU] Сражение : Защита героя.
        //private void Defend(object sender, RoutedEventArgs e)
        //{
        //    Ray.DefenseState = 2;
        //    AnyHide(FightMenu);
        //    HP.Foreground = Brushes.White;
        //    Lab2.Foreground = Brushes.White;
        //    if (Sets.SpecialBattle == 200)
        //    {
        //        GetHP = Shrt(Math.Min(GetHP + 40, GetMHP));
        //        GetAP = Shrt(Math.Min(GetAP + 40, GetMAP));
        //        ushort cipher = MainHero.Learned;
        //        BitArray learned = Decoder(new BitArray(new bool[16]), cipher);
        //        if (!learned[15])
        //        {
        //            MainHero.Learned += ALearn.Learn(15);
        //            PlayNoise(ALearn.Noise);
        //        }
        //        else
        //            PlayNoise(Paths.OST.Noises.StrongStand);
        //    }
        //    else
        //    {
        //        FastImgChange(BmpersToX(Paths.Static.Person.Defensive, Paths.Static.Icon.Defensive), Img4, Img5);
        //        PlayNoise(Paths.OST.Noises.StrongStand);
        //    }

        //    AfterAction();
        //}

        //private void Skills(object sender, RoutedEventArgs e)
        //{
        //    AnyShow(SkillsMenu);
        //    FastEnableDisableBtn(new bool[] { AbilityBonuses[0] <= 0,
        //        AbilityBonuses[1] <= 0 }, BuffUp, ToughenUp);
        //    AnyHide(FightMenu);
        //}

        //private void Items_Click(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(FightMenu);
        //    AnyShow(ItemsMenu);
        //    PlayNoise(Paths.OST.Noises.BagOpen);
        //}

        //private void Escape(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(FightMenu);
        //    byte fagl = Math.Max(GetFoe3.Speed, Math.Max(GetFoe1.Speed, GetFoe2.Speed));
        //    Lab2.Foreground = Brushes.White;
        //    if (GetAGL > fagl)
        //        speed = 1;
        //    ShowAction(Paths.Dynamic.Person.Escape, Paths.Dynamic.Icon.Escape);
        //    PlayNoise(Paths.OST.Noises.FleeAway);
        //    AnyHide(BattleText2);
        //    WaitForEnd(Shrt(500 / GameSpeed.Value));
        //}

        //private void Genocide(object sender, RoutedEventArgs e)
        //{
        //    AnyShow(AutoTurn);
        //    AnyHide(FightMenu);
        //    BadTime();
        //}

        //private void AutoTurn_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    (sender as Button).Background = new
        //        SolidColorBrush(Color.FromArgb(255, 155, 15, 15));
        //}

        //private void AutoTurn_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    (sender as Button).Background = new
        //        SolidColorBrush(Color.FromArgb(255, 6, 79, 236));
        //}

        //private void AutoTurn_Click(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(sender as Button);
        //}
        //#endregion

        //#region MenuOptions
        ////[EN] Battle : Person attack, calculate.
        ////[RU] Сражение : Атака героя, подсчёт.
        //private void Fight(object sender, RoutedEventArgs e)
        //{
        //    TimerOff(ref Targt);
        //    BadTime();
        //}

        //private void SelectSkill(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (sender as Button).Tag as Button;
        //    SelectTarget();
        //    AnyHide(SkillsMenu);
        //    AnyShowX(SelectMenuSkills, btn);
        //}

        //private void Cancel(object sender, RoutedEventArgs e)
        //{
        //    if (Targt.IsEnabled)
        //        TimerOff(ref Targt);
        //    AnyHideX(EnemyStatus, SelectMenuFight, TargetImage);
        //    AnyShow(FightMenu);
        //}

        //private void Cancel2_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Targt.IsEnabled)
        //        TimerOff(ref Targt);
        //    AnyHideX(EnemyStatus, TargetImage, SelectMenuSkills, ACT1, ACT2, ACT3, ACT4);
        //    AnyShow(SkillsMenu);
        //}

        //private void Back1_Click(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(SkillsMenu);
        //    AnyShow(FightMenu);
        //    Button4.IsEnabled = Sets.SpecialBattle == 0;
        //}

        //private void Back2_Click(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(ItemsMenu);
        //    AnyShow(FightMenu);
        //    PlayNoise(Paths.OST.Noises.BagClose);
        //}
        //#endregion

        //#region ImageAnimation Members
        //private async void ShowAction(string[] person, string[] icon)
        //{
        //    for (byte actions = 0; actions < person.Length; actions++)
        //    {
        //        FastImgChange(BmpersToX(person[actions], icon[actions]), Img4, Img5);
        //        ushort wait = Shrt(50 / GameSpeed.Value);
        //        await Task.Delay(wait);
        //    }
        //    FastImgChange(BmpersToX(MainHero.Image, MainHero.Icon), Img4, Img5);
        //}

        //private async void ShowAction(string[] person)
        //{
        //    for (byte actions = 0; actions < person.Length; actions++)
        //    {
        //        Img4.Source = Bmper(person[actions]);
        //        ushort wait = Shrt(50 / GameSpeed.Value);
        //        await Task.Delay(wait);
        //    }
        //    Img4.Source = Bmper(MainHero.Image);
        //}
        //#endregion

        //#region SkillsUsing Logic
        //private void MedicineCure(MedicineSkills skill)
        //{
        //    GetHP = Shrt(Math.Min(GetMHP, GetHP + skill.Cure()));
        //    GetAP -= skill.Cost;
        //}

        //private void AbilitySupers()
        //{
        //    AnyHideX(TargetImage, SelectMenuSkills, SkillsMenu);
        //    Lab2.Foreground = Brushes.White;
        //    Sets.SelectedTarget = ReSelect();
        //    Time1.Value = 0;
        //}
        //#endregion

        //#region SkillsUsing Members
        //private void ACT4_Click(object sender, RoutedEventArgs e)
        //{
        //    ushort cipher = MainHero.Learned;
        //    BitArray learned = Decoder(new BitArray(new bool[16]), cipher);
        //    int no = foes[Sets.SelectedTarget].No;
        //    if (learned[no])
        //        return;
        //    Lab2.Foreground = Brushes.White;
        //    MainHero.Learned += ALearn.Learn(no);
        //    Button btn = sender as Button;
        //    SupportSkills skill = btn.Tag as SupportSkills;
        //    GetAP -= skill.Cost;
        //    AnyHideX(EnemyStatus, TargetImage, SelectMenuSkills, ACT4);
        //    PlayNoise(skill.Noise);
        //    ShowAction(skill.Animation, skill.IconAnimate);
        //    if (Targt.IsEnabled)
        //        TimerOff(ref Targt);
        //    WaitForEnd(Shrt(500 / GameSpeed.Value));
        //}

        //private void ActionOnOne_Click(object sender, RoutedEventArgs e)
        //{
        //    Lab2.Foreground = Brushes.White;
        //    Button btn = sender as Button;
        //    FightSkills skill = btn.Tag as FightSkills;
        //    GetAP -= skill.Cost;
        //    AnyHideX(TargetImage, btn, SelectMenuSkills);
        //    PlayNoise(skill.Noise);
        //    ShowAction(skill.Animation, skill.IconAnimate);
        //    Skills1(skill);
        //    if (Targt.IsEnabled)
        //        TimerOff(ref Targt);
        //}

        //private void ActionOnAll_Click(object sender, RoutedEventArgs e)
        //{
        //    Lab2.Foreground = Brushes.White;
        //    Button btn = sender as Button;
        //    FightSkills skill = btn.Tag as FightSkills;
        //    Time1.Value = 0;
        //    GetAP = Shrt(GetAP - skill.Cost);
        //    AnyShow(EnemyStatus);
        //    ReCheck();
        //    PlayNoise(skill.Noise);
        //    ShowAction(skill.Animation, skill.IconAnimate);
        //    AnyHideX(TargetImage);
        //    FoesKickedAll(skill.Power, Shrt(500 / GameSpeed.Value));
        //    AbilitySupers();
        //}

        //private void BuffSkills_Click(object sender, RoutedEventArgs e)
        //{
        //    Lab2.Foreground = Brushes.White;
        //    Button btn = sender as Button;
        //    SupportSkills skill = btn.Tag as SupportSkills;
        //    Dictionary<string, int> dict = new Dictionary<string, int> {
        //        { ATemper.Name, 0 }, { ASecure.Name, 1 }
        //    };
        //    FrameworkElement[][] elements = {
        //        new FrameworkElement[] { BuffsUpImg, BuffUpTxt },
        //        new FrameworkElement[] { ToughUpTxt, ToughUpImg }
        //    };
        //    int p = dict[skill.Name];
        //    AbilityBonuses[p] = Bits(skill.Buff());
        //    GetAP -= skill.Cost;
        //    PlayNoise(skill.Noise);
        //    ShowAction(skill.Animation, skill.IconAnimate);
        //    WaitForEnd(Shrt(500 / GameSpeed.Value));
        //    OnPropertyChanged(nameof(GetATK));
        //    OnPropertyChanged(nameof(GetDEF));
        //    AnyShowX(elements[p]);
        //    AnyHide(SkillsMenu);
        //    Time1.Value = 0;
        //}

        //private void Regen_Click(object sender, RoutedEventArgs e)
        //{
        //    if (PRegn.IsEnabled)
        //        return;
        //    Lab2.Foreground = Brushes.White;
        //    GetAP -= AHpup.Cost;
        //    TimerOn(ref PRegn, Shrt(250 / GameSpeed.Value));
        //    PlayNoise(AHpup.Noise);
        //    ShowAction(AHpup.Animation, AHpup.IconAnimate);
        //    AnyHide(SkillsMenu);
        //    WaitForEnd(Shrt(500 / GameSpeed.Value));
        //}

        //private void Control_Click(object sender, RoutedEventArgs e)
        //{
        //    if (PCtrl.IsEnabled)
        //        return;
        //    Lab2.Foreground = Brushes.White;
        //    GetAP -= AApup.Cost;
        //    TimerOn(ref PCtrl, Shrt(250 / GameSpeed.Value));
        //    PlayNoise(AApup.Noise);
        //    ShowAction(AApup.Animation, AApup.IconAnimate);
        //    AnyHide(SkillsMenu);
        //    WaitForEnd(Shrt(500 / GameSpeed.Value));
        //}

        //private void AbilsMenu_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    AnyHide(AbilsCost);
        //}

        //private void MedicineSkill_Click(object sender, RoutedEventArgs e)
        //{
        //    Lab2.Foreground = Brushes.White;
        //    ushort time = Shrt(1000 / GameSpeed.Value);
        //    MedicineSkills skill = (sender as Button).Tag as MedicineSkills;
        //    MedicineCure(skill);
        //    ShowAction(skill.Animation, skill.IconAnimate);
        //    PlayNoise(skill.Noise);
        //    ShowAndHide(CureHealTxt, "+" + skill.Cure(), time);
        //    AnyHide(SkillsMenu);
        //    WaitForEnd(time);
        //}

        //private void Heal_Click(object sender, RoutedEventArgs e)
        //{
        //    Lab2.Foreground = Brushes.White;
        //    HeroSetStatus(AHeal.HealStatus());
        //    AfterStatus.Content = StatusP.Content = Txts.Common.Hlthy + " ♫";
        //    GetAP -= AHeal.Cost;
        //    AnyHide(SkillsMenu);
        //    ShowAction(Paths.Dynamic.Person.Heal, Paths.Dynamic.Icon.Heal);
        //    ShowAndHide(CureHealTxt, "-Яд", Shrt(1000 / GameSpeed.Value));
        //    PlayNoise(Paths.OST.Noises.Heal);
        //    WaitForEnd(Shrt(500 / GameSpeed.Value));
        //}
        //#endregion

        //#region ItemsUsing Members
        //private void ItemsInFight_Click(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(ItemsMenu);
        //    Items item = (sender as Button).Tag as Items;
        //    UseItem(item);
        //    if (item.StatusRestore == 0)
        //        ShowAndHide(CureHealTxt, "-Яд", Shrt(1000 / GameSpeed.Value));
        //    if (item.HpRestore > 0)
        //        ShowAndHide(CureHealTxt, "+" + item.HpRestore,
        //            Shrt(1000 / GameSpeed.Value));
        //    if (item.ApRestore > 0)
        //        ShowAndHide(RecoverAPTxt, "+" + item.ApRestore,
        //            Shrt(1000 / GameSpeed.Value));
        //    WaitForEnd(Shrt(500 / GameSpeed.Value));
        //}

        //private void ItemsUseInBattle_MouseEnter(object sender, RoutedEventArgs e)
        //{
        //    Items item = (sender as Button).Tag as Items;
        //    BattleText2.Content = item.Description;
        //    ItemText.Content = Txts.Common.Total + ": " + item.Count;
        //    AnyShowX(BattleText2, ItemText);
        //}

        //private void ItemsUseInBattle_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    AnyHideX(ItemText, BattleText2);
        //}
        //#endregion

        //// Deprecated: use style triggers instead
        //#region ImageSourceChange Members
        //private void AbilitiesInFight_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    AnyHide(BattleText2);
        //}

        //private void AbilitiesInFight_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    BattleText2.Content = SkillInfo.GetDescription(btn);
        //    AnyShow(BattleText2);
        //}

        //private void FightStaticButtons_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button b = sender as Button;
        //    BattleText2.Content = b.Tag.ToString();
        //    AnyShow(BattleText2);
        //}

        //private void FightStaticButtons_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    AnyHide(BattleText2);
        //}

        //private void FightDynamicButtons_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    Button fightButton = sender as Button;
        //    Image img = fightButton.Content as Image;
        //    img.Source = Bmper(MiscText.GetPath(img));
        //    AnyHide(BattleText2);
        //}

        //private void FightDynamicButtons_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button fightButton = sender as Button;
        //    Image img = fightButton.Content as Image;
        //    img.Source = Bmper(img.Tag.ToString());
        //    BattleText2.Content = fightButton.Tag.ToString();
        //    AnyShow(BattleText2);
        //}

        //private void SelectDynamicButtons_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    Image img = btn.Content as Image;
        //    img.Source = Bmper(Paths.Static.BtnImgs.After.Select);
        //    BattleText2.Content = SkillInfo.GetDescription(btn);
        //    AnyShow(BattleText2);
        //}

        //private void SelectDynamicButtons_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    Image img = btn.Content as Image;
        //    img.Source = Bmper(Paths.Static.BtnImgs.Before.Select);
        //    AnyHide(BattleText2);
        //}
        //#endregion

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