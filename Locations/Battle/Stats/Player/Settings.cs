namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Settings : Unit
    {
        public Settings()
        {
            Music = new Slider(50, 100);
            Sound = new Slider(50, 100);
            Noise = new Slider(50, 100);

            BattleSpeed = new Slider(25, 100, 200);
            Brightness = new Slider(10, 50, 100);
        }

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