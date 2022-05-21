namespace DesertRage.Model.Locations.Battle.Stats.Player.Armory
{
    public class Weapon : Equipment
    {
        public Weapon(float power, string meaning) :
            base(meaning, power) { }

        public string Noise { get; set; }

        public string[] Animation { get; set; }
        public string[] IconAnimation { get; set; }
    }
}