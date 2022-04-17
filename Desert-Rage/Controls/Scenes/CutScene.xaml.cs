using DesertRage.Customing.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DesertRage.Controls.Scenes
{
    /// <summary>
    /// Cut scenes
    /// </summary>
    public partial class CutScene : UserControl, INotifyPropertyChanged
    {
        #region Film Members
        private Uri _playingFilm;
        public Uri PlayingFilm
        {
            get => _playingFilm;
            set
            {
                _playingFilm = value;
                OnPropertyChanged();
                Player.Play();
            }
        }

        private readonly Queue<string> _films;

        public delegate void AfterAction();
        private AfterAction _action;
        #endregion

        public CutScene()
        {
            InitializeComponent();
            _films = new Queue<string>();
        }

        public CutScene
            (in AfterAction action,
            params string[] films) : this()
        {
            _action = action;

            for (byte i = 0; i < films.Length; i++)
            {
                _films.Enqueue(films[i]);
            }

            if (_films.Count > 0)
            {
                PlayingFilm = _films.Dequeue().ToUri();
            }
        }

        private void OnMediaEnded(object sender, RoutedEventArgs e)
        {
            if (_films.Count > 0)
            {
                PlayingFilm = _films.Dequeue().ToUri();
            }
            else
            {
                Player.Close();
                _action();
            }
        }

        //private void Skip(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(Skip1);
        //    MediaElement[] media = { Med1, TheEnd };
        //    for (byte i = 0; i < media.Length; i++)
        //        if (media[i].IsEnabled)
        //        {
        //            media[i].Stop();
        //            media[i].RaiseEvent(new RoutedEventArgs(MediaElement.MediaEndedEvent));
        //            break;
        //        }
        //}

        //private void Skip1_MouseEnter(object sender, MouseEventArgs e        {
        //    SkipImg.Source = Bmper(Paths.Static.Menu.Adventures.AfterSkip);
        //}

        //private void Skip1_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    SkipImg.Source = Bmper(Paths.Static.Menu.Adventures.BeforeSkip);
        //}

        //#region OldMedia Methods
        ////[EN] "Live" scene
        ////[RU] "Живая" сцена
        //private bool RudeBattle(Image image, double opacity)
        //{
        //    image.Opacity += opacity;
        //    return image.Opacity < 1;
        //}

        //private void SomeRudeAppears(in byte BattleIndex, in string Noise)
        //{
        //    Sets.SpecialBattle = BattleIndex;
        //    TargetImage = BossSlot1;
        //    Img2.IsEnabled = false;
        //    Sound1.Stop();
        //    PlayNoise(Noise);
        //}

        //private async Task FoePhases(Image image, string[] phases, ushort time)
        //{
        //    for (byte i = 0; i < phases.Length; i++)
        //    {
        //        image.Source = Bmper(phases[i]);
        //        await Task.Delay(time);
        //    }
        //}

        //private async void SimpleCutScene(Image image, double opacity, ushort time)
        //{
        //    while (!RudeBattle(image, opacity))
        //        await Task.Delay(time);
        //    LetsBattle();
        //}

        //private async void ComplexCutScene(Image image, double opacity, ushort time)
        //{
        //    while (RudeBattle(image, opacity))
        //        await Task.Delay(time);
        //    await FoePhases(Ancient, Paths.Dynamic.Models.Ancient, time);
        //    await FoePhases(Warrior, Paths.Dynamic.Models.Warrior, time);
        //    AnyGrid(Warrior, Bits(Warrior.GetValue(Grid.RowProperty)), 4);
        //    await Task.Delay(time);
        //    LetsBattle();
        //}
        //#endregion

        //#region OldMedia End
        ////[EN] After game intro has been ended
        ////[RU] После завершения пролога.
        //private void Med1_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    Img1.Source = Bmper(Paths.Static.Map.Normal);
        //    AnyShow(Img1);
        //    AnyShow(ChapterIntroduction);
        //    AnyHide(Med1);
        //    AnyHide(Skip1);
        //    PlayMusic(Paths.OST.Music.AncientPyramid);
        //}

        //private void ChapterIntroduction_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    CurrentLocation = LocationDecode(Ray.MenuTask);
        //    MapScheme = MapBuild(CurrentLocation);
        //    Ray.MiniTask = false;
        //    switch (Ray.MenuTask)
        //    {
        //        case 0:
        //            ChangeOnChapter(0);
        //            Location1_AncientPyramid();
        //            AnyShowX(Threasure1, SaveProgress);
        //            Threasures();
        //            TablesSetInfo();
        //            break;
        //        case 3:
        //        case 4:
        //            ChangeOnChapter(1);
        //            Location2_WaterTemple();
        //            Threasures();
        //            SavePlayer();
        //            AnyShow(SaveProgress); break;
        //        case 6:
        //        case 7:
        //            ChangeOnChapter(2);
        //            Location3_LavaTemple();
        //            Threasures();
        //            SavePlayer();
        //            AnyShow(SaveProgress); break;
        //        case 8:
        //        case 9:
        //            ChangeOnChapter(3);
        //            Location4_BigRun();
        //            SavePlayer();
        //            break;
        //        case 10:
        //            AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Titres), TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.SayGoodbye);
        //            break;
        //        default:
        //            Form1.Close();
        //            break;
        //    }
        //    AnyShowX(Img1, Img2);
        //}

        //private void Win_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //    WonOrDied();
        //}

        //private void Med1_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //    AnyHideX(NewAdventure, Img1, Lab1, Skip1);
        //    AnyShow(Skip1);
        //}

        //private void Med2_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    AnyHide(Med2);
        //    switch (Sets.SpecialBattle)
        //    {
        //        case 0: RegularBattle(); SpeedUp(); break;
        //        case 1: BossBattle1(); SpeedUp(); break;
        //        case 2: BossBattle2(); SpeedUp(); break;
        //        case 3: BossBattle3(); SpeedUp(); break;
        //        case 200: SecretBossBattle1(); SpeedUp(); break;
        //        default: Close(); break;
        //    }
        //}

        //private void Win_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    WinStop();
        //    AnyHide(NewLevelGet);
        //}

        //private void WinStop()
        //{
        //    WonOrDied();
        //    CheckMapX(new byte[] { 104, 105, 105, 106, 107, 108 }, new Image[] {
        //        JailImg1, JailImg2, JailImg3, JailImg5, JailImg6, JailImg7 });
        //    if (CurrentLocation < 3)
        //        AnyShowX(ChestImg1, ChestImg2, ChestImg3,
        //            ChestImg4, Table1, Table2, Table3);
        //    if (CurrentLocation == 0)
        //        Map1EnableModels();
        //    if (CheckMap(7))
        //        AnyShow(Boulder1);
        //    AnyShowX(Threasure1, Img2, Img1, SaveProgress);
        //    AnyHide(Win);
        //    Win.Position = TimeSpan.Zero;
        //    string[] music = new string[] { Paths.OST.Music.AncientPyramid,
        //        Paths.OST.Music.WaterTemple, Paths.OST.Music.LavaTemple };
        //    PlayMusic(music[CurrentLocation]);
        //}

        //private void Win_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        //{
        //    WonOrDied();
        //    Win.Stop();
        //    AnyShow(Img2);
        //}

        //private void GameOver_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    Reload.Reloading();
        //    Form1.Close();
        //}

        //private async void WaitForEnd(ushort time)
        //{
        //    await Task.Delay(time);
        //    AfterAction();
        //}

        //private void TheEnd_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    TargetImage = TrgtImg;
        //    AnyHideX(EnemyStatus, BattleText6, ItemsMenu, TargetImage,
        //        SkillsMenu, FightMenu, SelectMenuFight, SelectMenuSkills);
        //    WonOrDied();
        //    AnyHide(Skip1);
        //    switch (Ray.MenuTask)
        //    {
        //        case 3:
        //            Button4.IsEnabled = true;
        //            AnyHide(BossSlot1);
        //            AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Fin_Chapter1),
        //                TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.AncientKey);
        //            Ray.MenuTask++;
        //            Img1.Source = Bmper(Paths.Static.Map.Normal);
        //            AnyShow(Skip1);
        //            break;
        //        case 4:
        //            ShowAutoSave();
        //            AnyShowAdvanced(ChapterIntroduction, Ura(Paths.CutScenes.PreChapter2),
        //                TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.WaterTemple);
        //            break;
        //        case 6:
        //            Button4.IsEnabled = true;
        //            AnyHide(BossSlot1);
        //            AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Fin_Chapter2),
        //                TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.Conversation);
        //            Ray.MenuTask++;
        //            Img1.Source = Bmper(Paths.Static.Map.Normal);
        //            AnyShow(Skip1);
        //            break;
        //        case 7:
        //            ShowAutoSave();
        //            AnyShowAdvanced(ChapterIntroduction, Ura(Paths.CutScenes.PreChapter3),
        //                TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.LavaTemple);
        //            break;
        //        case 8:
        //            AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Fin_Chapter3), TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.Threasures);
        //            Ray.MenuTask++;
        //            Img1.Source = Bmper(Paths.Static.Map.Normal);
        //            AnyShow(Skip1);
        //            break;
        //        case 9:
        //            ShowAutoSave();
        //            AnyShowAdvanced(ChapterIntroduction, Ura(Paths.CutScenes.PreChapter4),
        //                TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.GetAway);
        //            break;
        //        case 10:
        //            if (CurrentPlayer.Content.ToString() == "????")
        //            {
        //                AddNewPlayer("SeriousMan");
        //                SaveCool("SeriousMan");
        //                PlaySound(Paths.OST.Sounds.ControlSave);
        //            }
        //            AnyShowAdvanced(TheEnd, Ura(Paths.CutScenes.Titres),
        //                TimeSpan.Zero);
        //            PlayMusic(Paths.OST.Music.SayGoodbye);
        //            Ray.MenuTask++;
        //            break;
        //        default: Close(); break;
        //    }
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