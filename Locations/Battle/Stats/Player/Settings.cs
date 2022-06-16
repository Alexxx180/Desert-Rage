namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Settings
    {
        public Settings()
        {
            Music = new Slider(50, 100);
            Sound = new Slider(50, 100);
            Noise = new Slider(50, 100);

            BattleSpeed = new Slider(25, 100, 200);
            Brightness = new Slider(10, 50, 100);
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