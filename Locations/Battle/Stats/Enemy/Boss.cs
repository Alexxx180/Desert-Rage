﻿namespace DesertRage.Model.Locations.Battle.Stats.Enemy
{
    public class Boss : Foe, ICloneable<Boss>
    {
        public Boss() { }

        public Boss(Boss unit)
        {
            Set(unit);
        }

        public void Set(Boss unit)
        {
            base.Set(unit);
            Theme = unit.Theme;
        }

        public string Theme { get; set; }

        public override Boss Clone()
        {
            return new Boss(this);
        }
    }
}