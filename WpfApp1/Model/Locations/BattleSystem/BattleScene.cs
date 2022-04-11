using WpfApp1.Model.Stats.Enemy;

namespace WpfApp1.Model.Locations.BattleSystem
{
    public class BattleScene
    {
        public BattleScene()
        {
            Field = new string[]
            {
                "...",
                "..."
            };
        }

        public string[] Field { get; set; }
        
        public Foe[] Foes { get; set; }
        public Boss[] Bosses { get; set; }
    }
}