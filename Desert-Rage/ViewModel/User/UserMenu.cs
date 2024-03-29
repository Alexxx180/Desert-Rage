﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Things;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds;
using Serilog;

namespace DesertRage.ViewModel.User
{
    public class UserMenu : HeroManagement, INotifyPropertyChanged
    {
        /// <summary>
        /// User profile menu commands container
        /// </summary>
        public UserMenu()
        {
            Bestiary = new ObservableCollection<Foe>();
            Items = new ObservableCollection<ConsumeCommand>();
            Skills = new ObservableCollection<ConsumeCommand>();
            Equip = new ObservableCollection
                <ObservableCollection<Equipment>>
            {
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>()
            };
        }

        #region Equipment Members
        public void AddEquipment(ArmoryElement armor, Equipment[][] equipment)
        {
            byte kind = armor.Kind.Byte();
            byte set = armor.Set.Byte();
            Equipment piece = equipment[kind][set];
            Equip[kind].Add(piece);
        }

        private protected void AddEquipment(ArmoryElement armor)
        {
            if (Hero.Equipment.Add(armor))
                AddEquipment(armor, Bank.GetEqupment());
        }

        private void PlayerEquipment()
        {
            Hero.Equipment.ForEach(AddEquipment, Bank.GetEqupment());
        }

        private byte Resist(int kind, byte set)
        {
            return Equip[kind][set].Power;
        }

        internal byte Resist(ArmoryKind kind, byte set)
        {
            return Resist(kind.Byte(), set);
        }

        public override void Hit(int value)
        {
            value -= Resist(ArmoryKind.Torso, Hero.Equipped.Torso);
            value -= Resist(ArmoryKind.Legs, Hero.Equipped.Legs);
            value -= Resist(ArmoryKind.Feet, Hero.Equipped.Feet);
            base.Hit(value);
        }
        #endregion

        #region Skill Members
        private void AddSkill(ConsumeCommand skill)
        {
            skill.SetModel(ViewModel);
            Skills.Add(skill);
        }

        private protected override void AddSkills(HashSet<SkillsID> ramSkills)
        {
            Log.Debug($"Loading hero skills...");
            Dictionary<string, AttributeUnit>
                skills = Bank.GetSkills();

            foreach (SkillsID id in ramSkills)
            {
                AttributeUnit skill = skills[id.ToString()];

                ConsumeCommand command = ConsumeCommand.FromUnit
                    (new SkillCommand(), skill);

                AddSkill(command);
            }
        }
        #endregion

        #region Item Members
        private void AddItem(ConsumeCommand item)
        {
            item.SetModel(ViewModel);
            Items.Add(item);
        }

        private void AddItems()
        {
            Log.Debug($"Loading hero items...");
            List<AttributeUnit> items = Bank.GetInventory();

            for (byte i = 0; i < items.Count; i++)
            {
                ConsumeCommand item = ConsumeCommand.FromUnit
                    (new ItemCommand(), items[i]);
                AddItem(item);
            }
        }

        #region In/De-crement
        public void IncreaseItemCount(ItemsID item)
        {
            int id = item.Int();
            IncreaseItemCount(id);
        }

        private protected void IncreaseItemCount(int id)
        {
            if (Hero.Items[id] < byte.MaxValue)
                Items[id].Subject.Value++;
        }
        #endregion

        #endregion

        #region Bestiary Members
        public void AnalyzeFoe(EnemyBestiary id)
        {
            if (Hero.Learned.Contains(id))
                return;

            Hero.Learn(id);
            AddFoe(id);
        }

        private void AddFoe(EnemyBestiary id)
        {
            if (ViewModel.FoeEnumeration.ContainsKey(id))
            {
                AddFoe(ViewModel.FoeEnumeration[id]);
            }
            else if (ViewModel.BossesEnumeration.ContainsKey(id))
            {
                AddFoe(ViewModel.BossesEnumeration[id]);
            }
        }

        private void AddFoe(Foe foe)
        {
            foe.Analyze(true);
            Bestiary.Add(foe);
        }
        #endregion

        #region HeroSetup Members
        private void LoadHeroBestiary()
        {
            Log.Debug($"Loading bestiary...");
            
            foreach (EnemyBestiary id in Hero.Learned)
            {
                AddFoe(id);
            }
        }

        public virtual void LoadHeroCommands()
        {
            
            AddSkills(Hero.Skills);

            
            AddItems();
        }

        public override void HeroSetup()
        {
            PlayerEquipment();
            LoadHeroBestiary();
            LoadHeroCommands();
            ViewModel.Human.SavedEvents();
        }
        #endregion

        public ObservableCollection<Foe> Bestiary { get; }
        public ObservableCollection<ConsumeCommand> Skills { get; }
        public ObservableCollection<ConsumeCommand> Items { get; }
        public ObservableCollection<ObservableCollection<Equipment>> Equip { get; }
    }
}