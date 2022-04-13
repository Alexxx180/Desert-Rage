using System;
using System.Collections.Generic;
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

namespace DesertRage.Controls.Menu.Battle
{
    /// <summary>
    /// Логика взаимодействия для BattleResults.xaml
    /// </summary>
    public partial class BattleResults : UserControl
    {
        public BattleResults()
        {
            InitializeComponent();
        }

        //private void CalculateBattleStatus()
        //{
        //    StateGuy();
        //    if (Sets.TableEN)
        //        AnyHide(TableMessage1);
        //    speed = 0;
        //    Lab2.Foreground = Brushes.Yellow;
        //    AnyShow(BattleScene);
        //    AnyHideX(Threasure1, Med2, Img2, PharaohAppears, SaveProgress, JailImg1,
        //        JailImg2, JailImg3, JailImg5, JailImg6, JailImg7, Boulder1, Ancient,
        //        Warrior, FinalAppears, LockImg1, LockImg2, LockImg3, KeyImg1, KeyImg2,
        //        KeyImg3, ChestImg1, ChestImg2, ChestImg3, ChestImg4, Table1, Table2,
        //        Table3);
        //    AbilityBonuses[0] = 0;
        //    AbilityBonuses[1] = 0;
        //    if (AutoTurn.IsEnabled)
        //        BadTime();
        //    else
        //    {
        //        AnyShow(FightMenu);
        //        Time1.Value = Time1.Maximum;
        //    }
        //    if (GetStatus == 1)
        //        PoisonHurts();
        //}

        //#region OkButton Members
        //private void TextOk1_Click(object sender, RoutedEventArgs e)
        //{
        //    HeroSetStatus(MainHero.PlayerStatus);
        //    TargetImage = TrgtImg;
        //    string[] win = new string[] { Paths.CutScenes.Victory,
        //        Paths.CutScenes.WasteTime, Paths.CutScenes.PowerRanger };
        //    Win.Source = Ura(win[CurrentLocation]);
        //    MaterialsAdd.Content = "";
        //    Mat = 0;
        //    if (Sets.SpecialBattle == 0)
        //    {
        //        AnyShow(Win);
        //        AnyHideX(BattleText1, BattleText2, Img1);
        //    }
        //    else
        //    {
        //        AnyHideX(BattleText1, BattleText2);
        //        switch (Sets.SpecialBattle)
        //        {
        //            case 1:
        //            case 2:
        //            case 3:
        //                Sound1.Stop();
        //                AnyShow(TheEnd);
        //                AnyShow(Skip1);
        //                Img1.Source = Bmper(Paths.Static.Map.Normal);
        //                break;
        //            default:
        //                AnyShow(Win);
        //                string[] music = new string[] { Paths.OST.Music.AncientPyramid,
        //                    Paths.OST.Music.WaterTemple, Paths.OST.Music.LavaTemple };
        //                PlayMusic(music[CurrentLocation]);
        //                break;
        //        }
        //        Sets.SpecialBattle = 0;
        //    }
        //    AnyHideX(NewLevelGet, FightResults);
        //    AnyShow(Img1);
        //}

        //public static byte LevelUpCount = 1;
        //private void textOk2_Click(object sender, RoutedEventArgs e)
        //{
        //    SpeedDown();
        //    ItemsGetSlot1.Content = "";
        //    if (Sets.SpecialBattle == 200)
        //    {
        //        APtext.Content = "ОД";
        //        GetHero = Ray;
        //        RefreshHeroFully();
        //        Sets.SpecialBattle = 0;
        //        FastImgChange(BmpersToX(MainHero.Image, MainHero.Icon), Img4, Img5);
        //        GetBag.Armors[3] = true;
        //        GetBag.Jacket = MainHero.Armor.Power == 0;
        //        ItemsGetSlot1.Content += $"{Txts.Equipment.Torso.Serious}\n";
        //        Ray.MiniTask = true;
        //        Button4.IsEnabled = true;
        //        AnyShowX(Button4, Items, Abilities);
        //        AnyShow(ItemsGetSlot1);
        //    }
        //    AnyHideX(BattleScene, BattleText1, BattleText2,
        //        BattleText6, textOk2, WonTxt);
        //    ShowAfterBattleMenu();
        //    WonOrDied();
        //}
        //#endregion

        //private void ShowAfterBattleMenu()
        //{
        //    LevelUpCount = 1;
        //    MaterialsAdd.Content = "+" + Mat;
        //    ItemsGetSlot1.Content = "";
        //    AnyShow(FightResults);
        //    LevelUps();
        //    MaterialsAnimation();
        //    for (byte no = 0; no < 8; no++)
        //        NewItems(no);
        //}

        //private void WonOrDied()
        //{
        //    Sound1.Stop();
        //    AnyHideX(BattleText1, BattleText2, Img6, Img7, Img8,
        //        TextOk1, FightMenu, textOk2, WonTxt, BattleScene,
        //        BuffsUpImg, BuffUpTxt, ToughUpImg, ToughUpTxt);
        //}

        //#region Results Members
        //private void NewItems(in byte no)
        //{
        //    byte item = 0;
        //    while (Sets.ItemsDropRate[no] > 0)
        //    {
        //        item = Bits(Random1.Next(0, 8) == 4 ? item + 1 : item);
        //        Sets.ItemsDropRate[no]--;
        //    }
        //    if (item <= 0)
        //        return;
        //    string[] ItemNamesEn = { "Antidote", "Bandage", "Ether",
        //        "Fused", "Herbs", "SleepBag", "Ether2", "Elixir" };
        //    string[] ItemNamesRu = { "Антидот", "Бинт", "Эфир", "Смесь",
        //        "Целебные травы", "Спальный мешок", "Бутыль эфира", "Эликсир" };
        //    byte value = Bits(GetBag.GetType().
        //        GetProperty(ItemNamesEn[no]).GetType().GetProperty("Count"));
        //    ItemsGetSlot1.Content += ItemNamesRu[no] + ": " + item + "\n";
        //    GetBag.GetType().GetProperty(ItemNamesEn[no]).
        //        SetValue("Count", Bits(Math.Min(value + item, 255)));
        //}

        //private async void MaterialsAnimation()
        //{
        //    for (int digit = 1; (Mat > 0) && (GetMaterials +
        //        Math.Min(Mat, digit) < 65535); digit *= 2)
        //    {
        //        await Task.Delay(50);
        //        ushort materials = Shrt(Math.Min(Mat, digit));
        //        GetMaterials += materials;
        //        Mat -= materials;
        //        MaterialsAdd.Content = $"+{Mat}";
        //    }
        //}

        //private async Task LevelUp(ushort exp)
        //{
        //    while (GetExp + exp >= GetNlvl && GetLV < 25)
        //    {
        //        exp = Shrt(GetExp + exp - GetNlvl);
        //        GetLV = Bits(Math.Min(GetLV + 1, 25));
        //        GetExp = 0;
        //        NewLevelGet.Content = Txts.Common.NewLv;
        //        if (LevelUpCount > 1)
        //            NewLevelGet.Content += " X" + LevelUpCount;
        //        LevelUpCount += 1;
        //        AnyShow(NewLevelGet);
        //        AfterIcon.Source = Bmper(Paths.Static.Icon.LevelUp);
        //        PlayNoise(Paths.OST.Noises.LevelUp);
        //        OnPropertyChanged(nameof(GetNlvl));
        //        await Task.Delay(500);
        //        AfterIcon.Source = Bmper(Paths.Static.Icon.Usual);
        //        await Task.Delay(125);
        //    }
        //    GetExp += exp;
        //    Exp -= exp;
        //    await Task.Delay(50);
        //}

        //private async void LevelUps()
        //{
        //    for (int digit = 1; (Exp > 0) && (GetLV < 25) &&
        //        (GetExp + Math.Min(Exp, digit) < 65535); digit *= 2)
        //    {
        //        ushort exp = Shrt(Math.Min(Exp, digit));
        //        await LevelUp(exp);
        //    }
        //    LevelUpCount = 1;
        //    AnyShow(TextOk1);
        //}
        //#endregion
    }
}