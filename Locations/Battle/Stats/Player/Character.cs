using System.Collections;
using System.Collections.Generic;
using DesertRage.Model.Helpers;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using System.Text;

namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Character : BattleUnit
    {
        public Character() : base()
        {
            StandImage = new string[4];
            GoingImage = new string[4][];
        }

        public bool Go(in StringBuilder[] map, int move)
        {
            Pose = move;
            
            Walk = (Walk + 1) % GoingImage[Pose].Length;
            MapImage = GoingImage[Pose][Walk];

            Position next = Front;
            if (WalkThrough.Contains
                (map.Tile(next).ToString()))
            {
                Place = next;
            }

            ToBattle--;
            return ToBattle <= 0;
        }

        public void Stand()
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
        public Bar Experience { get; set; }

        public Bar Ap { get; set; }

        public BitArray Learned { get; set; }

        public Outfit Gear { get; set; }
        #endregion

        #region Map Members
        public Position Front => Place + Step[Pose];

        public Position Place { get; set; }
        public Position[] Step { get; set; }
        public int ToBattle { get; set; }

        public int Pose { get; set; }
        public int Walk { get; set; }
        public string MapImage { get; set; }
        public string[] StandImage { get; set; }
        public string[][] GoingImage { get; set; }

        public HashSet<string> WalkThrough { get; set; }
        #endregion
    }
}