using System.Collections;
using System.Collections.Generic;
using DesertRage.Customing.Converters;
using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats.Player.Armory;

namespace DesertRage.Model.Stats.Player
{
    public class Character
    {
        public Character()
        {
            Status = new BitArray(1);
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
            //Walk = 0;
            MapImage = StandImage[Pose];
        }

        //DispatcherTimer PRegn = new DispatcherTimer();
        //DispatcherTimer PCtrl = new DispatcherTimer();

        //private void HeroSetStatus(byte code)
        //{
        //    string[] text = { Txts.Common.Hlthy + " ♫", Txts.Common.Ill + " §" };
        //    GetStatus = code;
        //    AfterStatus.Content = StatusP.Content = text[code];
        //}

        //private void PRegn_F_T37(object sender, EventArgs e)
        //{
        //    if (GetHP >= GetMHP)
        //        TimerOff(ref PRegn);
        //    else
        //        GetHP++;
        //}

        //private void PCtrl_F_T38(object sender, EventArgs e)
        //{
        //    if (GetAP == GetMAP)
        //        TimerOff(ref PCtrl);
        //    else
        //        GetAP++;
        //}

        #region Hp Management Members
        public void Hit(int value)
        {
            Hp.Drain(value);
        }

        public void Cure()
        {
            Hp.Restore();
        }

        public void Cure(int value)
        {
            Hp.Restore(value);
        }
        #endregion

        #region Ap Management Members
        public void Act(int value)
        {
            Ap.Drain(value);
        }

        public void Rest()
        {
            Ap.Restore();
        }

        public void Rest(int value)
        {
            Ap.Restore(value);
        }
        #endregion


        #region HeroPresentation Members
        public string Name { get; set; }
        public string Description { get; set; }

        public Profile HeroProfile { get; set; }
        #endregion

        #region Status Members
        public byte Level { get; set; }
        public ushort Experience { get; set; }

        public Bar Hp { get; set; }
        public Bar Ap { get; set; }

        public BattleStats Stats { get; set; }
        public byte Special { get; set; }

        public BitArray Status { get; set; }
        public BitArray Learned { get; set; }

        public Weapon Weapon { get; set; }
        public Equipment Armor { get; set; }
        public Equipment Legs { get; set; }
        public Equipment Boots { get; set; }
        #endregion

        #region Skills Members
        public List<Skill> BattleSkills { get; set; }
        public List<Skill> ExtraSkills { get; set; }
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