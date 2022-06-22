namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Settings : Unit
    {
        public void Set(Settings settings)
        {
            base.Set(settings);
            Music.Set(settings.Music);
            Sound.Set(settings.Sound);
            Noise.Set(settings.Noise);
            BattleSpeed.Set(settings.BattleSpeed);
            Brightness.Set(settings.Brightness);
        }

        #region OST Members
        public Slider Music { get; set; }
        public Slider Sound { get; set; }
        public Slider Noise { get; set; }
        #endregion

        public Slider BattleSpeed { get; set; }
        public Slider Brightness { get; set; }
    }
}