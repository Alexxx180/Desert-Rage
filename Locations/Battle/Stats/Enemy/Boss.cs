using System.Collections;

namespace DesertRage.Model.Locations.Battle.Stats.Enemy
{
    public class Boss : Foe
    {
        public Boss() { }

        public Boss(Foe foe) : base(foe)
        {
            Death = foe.Death;
            Size = foe.Size;
            Experience = foe.Experience;
            DropRate = foe.DropRate;
        }

        public new Boss Clone()
        {
            return new Boss(base.Clone())
            {
                Theme = Theme,
                ActionsLock = ActionsLock
            };
        }

        public string Theme { get; set; }
        public BitArray ActionsLock { get; set; }
    }
}