﻿using DesertRage.Model.Stats.Enemy;

namespace DesertRage.Model.Locations.BattleSystem
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