namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Settings : DescriptionUnit
    {
        public void Set(Settings settings)
        {
            base.Set(settings);
            Music.Set(settings.Music);
            Sound.Set(settings.Sound);
            Noise.Set(settings.Noise);
            Brightness.Set(settings.Brightness);
            BattleSpeed.Set(settings.BattleSpeed);
        }

        #region OST Members
        public Slider Music { get; set; }
        public Slider Sound { get; set; }
        public Slider Noise { get; set; }
        #endregion

        public Slider Brightness { get; set; }
        public Slider BattleSpeed { get; set; }
    }
}
