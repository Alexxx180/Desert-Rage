using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Menu.Things.Logic;

namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Character : BattleUnit, INotifyPropertyChanged
    {
        public Character() : base()
        {
            StandImage = new string[4];
            GoingImage = new string[4][];

            int enumLength = Converters.ToValues<EnemyBestiary>().Length;
            Learned = new BitArray(enumLength);
        }

        public string Image { get; set; }

        public List<SkillsID> Skills { get; set; }

        #region Ap Management Members
        public void Act(int value)
        {
            Ap.Drain(value.ToUShort());
        }

        public bool CanAct(in int value)
        {
            return Ap.Current >= value;
        }

        public void Rest()
        {
            Ap.Fill();
        }

        public void Rest(int value)
        {
            Ap.Fill(value.ToUShort());
        }
        #endregion

        #region Status Members
        public void Learn(EnemyBestiary enemy)
        {
            Learned[enemy.Int()] = true;
        }

        public byte Level { get; set; }
        public Slider Experience { get; set; }

        public Slider Ap { get; set; }

        public BitArray Learned { get; set; }
        public HashSet<ArmoryElement> Equipment { get; set; }

        public BattleStats SelectedArmor { get; set; }
        #endregion

        #region Map Members
        public void SetPlace(Position place)
        {
            Place = place;
        }

        public bool Go(in char[][] map, int move)
        {
            Pose = move;

            Walk = (Walk + 1) % GoingImage[Pose].Length;
            MapImage = GoingImage[Pose][Walk];

            Position next = Front;
            char tile = map.Tile(next);

            if (WalkThrough.Contains(tile))
            {
                SetPlace(next);
            }

            ToBattle--;
            return ToBattle <= 0;
        }

        public void Stand()
        {
            MapImage = StandImage[Pose];
        }

        public Position Front => Place + Step[Pose];

        public Position _place;
        public Position Place
        {
            get => _place;
            set
            {
                _place = value;
                OnPropertyChanged();
            }
        }

        public Position[] Step { get; set; }
        public int ToBattle { get; set; }

        public int Pose { get; set; }
        public int Walk { get; set; }

        private string _mapImage;
        public string MapImage
        {
            get => _mapImage;
            set
            {
                _mapImage = value;
                OnPropertyChanged();
            }
        }

        public string[] StandImage { get; set; }
        public string[][] GoingImage { get; set; }

        public HashSet<char> WalkThrough { get; set; }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}