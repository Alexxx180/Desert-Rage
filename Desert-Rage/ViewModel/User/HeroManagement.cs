﻿using System.Collections.Generic;
using System.ComponentModel;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Menu.Things.Logic;
using Serilog;

namespace DesertRage.ViewModel.User
{
    public abstract class HeroManagement : UserMedia, INotifyPropertyChanged
    {
        /// <summary>
        /// Hero interaction logic
        /// </summary>
    
        private protected override void SaveGame(string profile)
        {
            Hero.Cure();
            Hero.Rest();
            Bank.SaveProfileHero(Preferences.Name, Hero);
            base.SaveGame(profile);
        }

        private Character _hero;
        public Character Hero
        {
            get => _hero;
            set
            {
                _hero = value;
                OnPropertyChanged();
                HeroSetup();
            }
        }

        public void SetHero(Character hero)
        {
            Hero = hero;
        }

        public void UpdateHero()
        {
            OnPropertyChanged(nameof(Hero));
        }

        public abstract void HeroSetup();

        #region Status Members
        public virtual void Hit(int value)
        {
            Hero.Hit(value);
        }

        public bool Wound(ushort damage)
        {
            Sound("Info/Map/Wound.mp3");
            Hero.Hp.Drain(damage);
            bool isCritical = Hero.Hp.IsEmpty;

            if (isCritical)
                ViewModel.Entry.RaiseEscape();

            return isCritical;
        }

        public void AddExperience(int experience)
        {
            if (Hero.Experience.IsSealed)
                return;

            byte nextLevel = Hero.ChargeExperience(experience);
            if (nextLevel != Hero.Level)
                LevelUp(nextLevel);
        }

        private void LevelUp(byte count)
        {
            Log.Debug("Level Up to: " + count);
            Noise("Info/LevelUp.mp3");
            NextStats bank = Bank.GetNextStats(Preferences.Description);
            HashSet<SkillsID> newSkills = Hero.LevelUp(bank, count);

            if (newSkills.Count > 0)
                AddSkills(newSkills);
        }

        private protected abstract void AddSkills(HashSet<SkillsID> ramSkills);
        #endregion

        #region Map Members
        public void Stand()
        {
            Hero.Stand();
        }

        public void Warp(Position place)
        {
            Sound("Info/Map/Teleport.mp3");
            Hero.SetPlace(place);
        }
        #endregion

        public void FoesBattle()
        {
            ViewModel.Start();
        }

        protected void BossBattle(EnemyBestiary id)
        {
            Log.Debug($"Boss battle! Vs: {id}");
            Boss boss = ViewModel.BossesEnumeration[id];
            Music(boss.Theme);

            ViewModel.Start(boss);
        }
    }
}
