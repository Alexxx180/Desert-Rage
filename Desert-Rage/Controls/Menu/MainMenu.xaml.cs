﻿using DesertRage.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Controls.Scenes;
using static DesertRage.Writers.Processors;
using System.Diagnostics;

namespace DesertRage.Controls.Menu
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty
            TracksProperty = DependencyProperty.Register(nameof(Tracks),
                typeof(SoundGroup), typeof(MainMenu));

        public SoundGroup Tracks
        {
            get => GetValue(TracksProperty) as SoundGroup;
            set => SetValue(TracksProperty, value);
        }

        private GameStart _startViewModel;
        public GameStart StartViewModel
        {
            get => _startViewModel;
            set
            {
                _startViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainMenu()
        {
            InitializeComponent();

            StartViewModel = new GameStart();
        }

        //private void ListPlayers(object sender, RoutedEventArgs e)
        //{
        //    bool listed = AutorizeImg.Source.ToString().
        //        Contains(Paths.Static.Map.UnRegister);
        //    Grid addPlayer = AddPlayer.Parent as Grid;
        //    if (listed)
        //        AnyHideX(AddProfile, DeleteProfile, Player1, Player2,
        //            Player3, Player4, Player5, Player6, addPlayer);
        //    else
        //        CheckRecords();
        //    AutorizeImg.Source = Bmper(listed ? Paths.Static.Map.Register
        //        : Paths.Static.Map.UnRegister);
        //}

        //private void AddProfile_Click(object sender, RoutedEventArgs e)
        //{
        //    AnyHideX(NobodyNotAllowed, AlreadyHaveOne);
        //    if (AddPlayer.Text == "")
        //    {
        //        AnyShow(NobodyNotAllowed);
        //        return;
        //    }
        //    if (TSql.PlayerLogins.Contains(AddPlayer.Text))
        //    {
        //        AnyShow(AlreadyHaveOne);
        //        return;
        //    }
        //    AddNewPlayer(AddPlayer.Text);
        //    Grid addPlayer = AddPlayer.Parent as Grid;
        //    AnyHideX(addPlayer, AddProfile);
        //    AddPlayer.Text = "";
        //    CheckRecords();
        //}

        //private void AddNewPlayer(string name)
        //{
        //    try
        //    {
        //        TSql.NewPlayer(name);
        //        TSql.CheckAllRecordedPlayers();
        //        _ = TSql.GetCurrentPlayer();
        //    }
        //    catch (Exception ex)
        //    {
        //        _ = new Reload(Numb(CONECTION_ERROR), ex.Message).ShowDialog();
        //        Close();
        //    }
        //}
        //private void AddPlayer_PreviewTextInput(object sender,
        //    TextCompositionEventArgs e)
        //{
        //    AnyHideX(NobodyNotAllowed, AlreadyHaveOne);
        //    Regex regex = new Regex("[^0-9a-zA-Z]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
        //private void CheckRecords()
        //{
        //    Button[] Profiles = new Button[] { Player1, Player2,
        //        Player3, Player4, Player5, Player6 };
        //    if (TSql.PlayerLogins.Count < 6)
        //    {
        //        for (byte i = 0; i < TSql.PlayerLogins.Count; i++)
        //        {
        //            Profiles[i].Content = TSql.PlayerLogins[i];
        //            AnyShow(Profiles[i]);
        //            AnyGrid(AddProfile, Bits(i + 1), 0);
        //        }
        //        int optimization = TSql.PlayerLogins.Count + 1;
        //        Grid addPlayer = AddPlayer.Parent as Grid;
        //        Grid.SetRow(AddProfile, optimization);
        //        Grid.SetRow(addPlayer, optimization);
        //        Grid.SetRow(NobodyNotAllowed, optimization);
        //        Grid.SetRow(AlreadyHaveOne, optimization);
        //        AnyShowX(AddProfile, addPlayer);
        //    }
        //    else
        //    {
        //        for (byte i = 0; i < TSql.PlayerLogins.Count; i++)
        //        {
        //            Profiles[i].Content = TSql.PlayerLogins[i];
        //            AnyShow(Profiles[i]);
        //        }
        //    }
        //}

        //private void PlayersSelecting(object sender, RoutedEventArgs e)
        //{
        //    Button btn = sender as Button;
        //    byte select = Bits(btn.GetValue(Grid.RowProperty));
        //    int optimization = select - 1;
        //    TSql.CurrentLogin = TSql.PlayerLogins[optimization];
        //    CurrentPlayer.Content = TSql.CurrentLogin;
        //    AnyGrid(DeleteProfile, select, 0);
        //    AnyShow(DeleteProfile);
        //    Continue.IsEnabled = TSql.CheckIfPlayerCanContinue();
        //    ConAdv.Source = Bmper(Continue.IsEnabled ?
        //        Paths.Static.Menu.Adventures.BeforeConAdv :
        //        Paths.Static.Menu.Adventures.AdventureLock);
        //    SeeMap();
        //}

        //private void Anonymous()
        //{
        //    if (CurrentPlayer.Content.ToString() == "????")
        //        Continue.IsEnabled = false;
        //    ConAdv.Source = Bmper(Continue.IsEnabled ?
        //        Paths.Static.Menu.Adventures.BeforeConAdv :
        //        Paths.Static.Menu.Adventures.AdventureLock);
        //}

        //private void DeleteProfile_Click(object sender, RoutedEventArgs e)
        //{
        //    TSql.DeletePlayer(TSql.CurrentLogin);
        //    TSql.CheckAllRecordedPlayers();
        //    CurrentPlayer.Content = TSql.GetCurrentPlayer();
        //    Anonymous();
        //    SeeMap();
        //    AnyHideX(Player1, Player2, Player3, Player4,
        //        Player5, Player6, DeleteProfile);
        //    CheckRecords();
        //}

        ////[EN] Continue button click.
        ////[RU] Кнопка "Продолжить начатое".
        //private void Continue_Click(object sender, RoutedEventArgs e)
        //{
        //    Player = LoadProfile("Ray.json");

        //    OnPropertyChanged(nameof(GetBag));
        //    OnPropertyChanged(nameof(GetMaterials));
        //    OnPropertyChanged(nameof(GetHero));
        //    OnPropertyChanged(nameof(GetNlvl));
        //    ContinueQuest();
        //}

        ////[EN] Continue game.
        ////[RU] Продолжение игры.
        //private void ContinueQuest()
        //{
        //    RefreshSkills();
        //    TSql.DeselectAllPlayers();
        //    CurrentLocation = LocationDecode(MainHero.MenuTask);
        //    MapScheme = MapBuild(CurrentLocation);
        //    MapCheck(CurrentLocation);
        //    if (CurrentLocation < 3)
        //        Threasures();
        //    else
        //        TimerOn(ref TRout);
        //    string[] music = new string[] {
        //        Paths.OST.Music.AncientPyramid, Paths.OST.Music.WaterTemple,
        //        Paths.OST.Music.LavaTemple, Paths.OST.Music.GetAway
        //    };
        //    ChangeBackground(CurrentLocation);
        //    PlayMusic(music[CurrentLocation]);
        //    AnyShowX(Img1, Img2);
        //    ContinueCheckPoints();
        //}

        //private void GameStartBtns_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    ((sender as Button).Content as Image).Source =
        //        Bmper(sender.Equals(NewAdventure) ?
        //        Paths.Static.Menu.Adventures.AfterNewAdv
        //        : Paths.Static.Menu.Adventures.AfterConAdv);
        //}

        //private void GameStartBtns_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    ((sender as Button).Content as Image).Source =
        //        Bmper(sender.Equals(NewAdventure) ?
        //        Paths.Static.Menu.Adventures.BeforeNewAdv
        //        : Paths.Static.Menu.Adventures.BeforeConAdv);
        //}

        //private void ChangeOnChapter(in byte Loc)
        //{
        //    string[][] MapAndBattle = {
        //        new string[] { Paths.Static.Map.Location1, Paths.Static.Battle.Battle1 },
        //        new string[] { Paths.Static.Map.Location2, Paths.Static.Battle.Battle2 },
        //        new string[] { Paths.Static.Map.Location3, Paths.Static.Battle.Battle3 },
        //        new string[] { Paths.Static.Map.Location4, Paths.Static.Battle.Battle3 }
        //    };
        //    CurrentLocation = Loc;
        //    FastImgChange(BmpersToX(MapAndBattle[CurrentLocation]), Img1, Img3);
        //    AnyHide(ChapterIntroduction);
        //    AnyHide(TheEnd);
        //}

        //public void Autorization()
        //{
        //    ConAdv.Source = Bmper(Continue.IsEnabled ?
        //        Paths.Static.Menu.Adventures.BeforeConAdv :
        //        Paths.Static.Menu.Adventures.AdventureLock);
        //}

        //private void NewAdventure_Click(object sender, RoutedEventArgs e)
        //{
        //    New_game();
        //    AnyShow(Med1);
        //    AnyHide(MainMenu);
        //    PlayMusic(Paths.OST.Music.Prologue);
        //}

        public void MapFromScratch()
        {
            Trace.WriteLine("IT IS WORKING");
            //UserProfile user = new UserProfile();
            //user.CurrentLocation = LoadLocation("SecretTemple.json");
            //user.Hero = LoadCharacter("Ray.json");
            
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            Label display = Parent as Label;
            display.Content = new CutScene(MapFromScratch,
                "Resources/CutScenes/ChaptersIntroduction/Prologue.mp4");
        }

        private void Continue(object sender, RoutedEventArgs e)
        {

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
