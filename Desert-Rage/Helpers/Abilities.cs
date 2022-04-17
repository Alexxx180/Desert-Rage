using System;
using static DesertRage.Customing.Converters.Converters;

namespace DesertRage.Helpers
{
    public abstract class Abilities
    {
        protected Abilities(string name, string description, string[] animation, string[] iconAnimate, byte lvl, byte cost, string noise)
        {
            Name = name;
            Noise = noise;
            Description = description;
            Level = lvl;
            Cost = cost;
            Animation = animation;
            IconAnimate = iconAnimate;
        }

        public class FightSkills : Abilities
        {
            public FightSkills(string name, string description, string[] animation, string[] iconAnimate, byte lvl, byte cost, in ushort power, string noise) : base(name, description, animation, iconAnimate, lvl, cost, noise)
            {
                Power = power;
            }
            public ushort Power;
        }

        public class MedicineSkills : Abilities
        {
            public MedicineSkills(string name, string description, string[] animation, string[] iconAnimate, byte lvl, byte cost, string noise) : base(name, description, animation, iconAnimate, lvl, cost, noise) { }
            public MedicineSkills(string name, string description, string[] animation, string[] iconAnimate, byte lvl, byte cost, ushort power, string noise) : base(name, description, animation, iconAnimate, lvl, cost, noise)
            {
                Power = power;
            }
            public ushort Cure()
            {
                return Power;
            }
            public byte HealStatus()
            {
                return 0;
            }
            public ushort Power;
        }

        public class SupportSkills : Abilities
        {
            public SupportSkills(string name, string description, string[] animation, string[] iconAnimate, byte lvl, byte cost, string noise) : base(name, description, animation, iconAnimate, lvl, cost, noise) { }
            public SupportSkills(string name, string description, string[] animation, string[] iconAnimate, byte lvl, byte cost, byte power, string noise) : base(name, description, animation, iconAnimate, lvl, cost, noise)
            {
                Power = power;
            }
            public ushort Buff()
            {
                return Power;
            }
            public ushort Learn(int no) => Math.Pow(2, no).ToUShort();

            public byte Power;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Noise { get; set; }
        public string[] Animation { get; set; }
        public string[] IconAnimate { get; set; }
        public byte Level { get; set; }
        public byte Cost { get; set; }
    }
}
