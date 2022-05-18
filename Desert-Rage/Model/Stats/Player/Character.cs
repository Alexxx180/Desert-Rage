using System.Collections;
using System.Collections.Generic;
using DesertRage.Customing.Converters;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats.Player.Armory;
using DesertRage.Model.Menu.Things.Logic;

namespace DesertRage.Model.Stats.Player
{
    public class Character : BattleUnit
    {
        public Character() : base()
        {
            StandImage = new string[4];
            GoingImage = new string[4][];
        }

        internal void Go(in string[] map, int move)
        {
            Position next = Place;
            next.Increment(Step[move]);
            
            Pose = move;
            Walk = (Walk + 1) % GoingImage[Pose].Length;
            MapImage = GoingImage[Pose][Walk];

            if (WalkThrough.Contains(map.Tile(next)))
            {
                Place = next;
            }
        }

        internal void Stand()
        {
            MapImage = StandImage[Pose];
        }

        public string Image { get; set; }

        public List<SkillsID> Skills { get; set; }

        #region Ap Management Members
        public void Act(int value)
        {
            Ap = Ap.Drain(value);
        }

        public bool CanAct(in int value)
        {
            return Ap.Current >= value;
        }

        public void Rest()
        {
            Ap = Ap.Restore();
        }

        public void Rest(int value)
        {
            Ap = Ap.Restore(value);
        }
        #endregion

        #region Status Members
        public byte Level { get; set; }
        public ushort Experience { get; set; }

        public Bar Ap { get; set; }

        public BitArray Learned { get; set; }

        public Outfit Gear { get; set; }
        #endregion

        #region Map Members
        public Position Place { get; set; }
        public Position[] Step { get; set; }

        public int Pose { get; set; }
        public int Walk { get; set; }
        public string MapImage { get; set; }
        public string[] StandImage { get; set; }
        public string[][] GoingImage { get; set; }

        public HashSet<string> WalkThrough { get; set; }
        #endregion
    }
}