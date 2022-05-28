namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Settings
    {
        public Settings()
        {
            Music = new Bar(50, 100);
            Sound = new Bar(50, 100);
            Noise = new Bar(50, 100);

            BattleSpeed = new Bar(25, 100, 200);
            Brightness = new Bar(50, 100);
        }

        #region OST Members
        public Bar Music { get; set; }
        public Bar Sound { get; set; }
        public Bar Noise { get; set; }
        #endregion

        public Bar BattleSpeed { get; set; }
        public Bar Brightness { get; set; }
    }
}