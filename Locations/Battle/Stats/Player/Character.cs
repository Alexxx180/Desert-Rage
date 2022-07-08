using System;
using System.Collections.Generic;
using System.ComponentModel;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Menu.Things.Logic;

namespace DesertRage.Model.Locations.Battle.Stats.Player
{
    public class Character : BattleUnit, INotifyPropertyChanged
    {
        public Character() : base()
        {
            StandImage = new string[4];
            GoingImage = new string[4][];
            Items = new byte[Enum.GetValues(typeof(ItemsID)).Length];
        }

        public string Image { get; set; }

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
            Learned.Add(enemy);
        }

        public byte ChargeExperience(int value)
        {
            byte level = (Level - 1).ToByte();
            int toNext;

            do
            {
                toNext = Experience.Max - value;

                Experience.Fill(value.ToUShort());

                if (Experience.IsMax)
                {
                    level++;
                    Experience.Set(ToNextLevel[level]);
                    value = -toNext;
                }
            }
            while (!Experience.IsSealed && toNext < 0);

            return ++level;
        }

        public HashSet<SkillsID> LevelUp(NextStats bank, byte nextLevel)
        {
            HashSet<SkillsID> skills = new HashSet<SkillsID>();
            for (int i = Level + 1; i <= nextLevel; i++)
            {
                string id = i.ToString();
                if (!bank.Skills.TryGetValue(id, out SkillsID skill))
                    return;
                
                if (Skills.Add(skill))
                    skills.Add(skill);
            }

            Level = nextLevel;
            int level = Level - 1;

            Hp.Set(bank.Hp[level]);
            Ap.Set(bank.Ap[level]);
            Stats = bank.Stats[level];

            SetStatusTiming();

            return skills;
        }

        public byte Level { get; set; }
        public Slider Experience { get; set; }
        public Bar[] ToNextLevel { get; set; }

        public Slider Ap { get; set; }

        public HashSet<SkillsID> Skills { get; set; }
        public byte[] Items { get; set; }

        private HashSet<EnemyBestiary> _learned;
        public HashSet<EnemyBestiary> Learned
        {
            get => _learned;
            set
            {
                _learned = value;
                OnPropertyChanged();
            }
        }
        public HashSet<ArmoryElement> Equipment { get; set; }

        public Armor Equipped { get; set; }
        #endregion

        #region Map Members
        public void SetPlace(Position place)
        {
            Place = place;
        }

        public bool IsBattle()
        {
            return --ToBattle <= 0;
        }

        public void Go(in char[][] map, int move)
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
    }
}
