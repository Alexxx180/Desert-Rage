using System.Collections;

namespace DesertRage.Model.Stats.Enemy
{
    public class Boss : Foe
    {
        public Boss(Foe foe) : base(foe)
        {

        }

        public string Theme { get; set; }
        public BitArray ActionsLock { get; set; }
    }
}