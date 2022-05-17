namespace DesertRage.Model.Menu.Things
{
    public class Item : ValuableUnit
    {

        //private void UseItem(Items item)
        //{
        //    if (item.StatusRestore == 0)
        //        GetStatus = item.StatusRestore;
        //    else
        //    {
        //        ushort optimize = Shrt(Math.Min(GetMHP, GetHP + item.HpRestore));
        //        GetHP = optimize;
        //        optimize = Shrt(Math.Min(GetMAP, GetAP + item.ApRestore));
        //        GetAP = optimize;
        //    }
        //    item.Count--;
        //    GetBag.GetType().GetProperty(item.Name).SetValue(GetBag, item);
        //    OnPropertyChanged(nameof(GetBag));
        //    CountText.Content = "Всего: " + item.Count;
        //    PlayNoise(Paths.OST.Noises.UseItems);
        //}

        public ushort Cost { get; set; }
    }
}