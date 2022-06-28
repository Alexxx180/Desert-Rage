using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.ViewModel.User.Battle.Components.Actions;

namespace DesertRage.ViewModel.User
{
    public class UserMenu : HeroManagement, INotifyPropertyChanged
    {
        public UserMenu()
        {
            Equip = new ObservableCollection
                <ObservableCollection<Equipment>>
            {
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>(),
                new ObservableCollection<Equipment>()
            };
        }

        private ObservableCollection<Foe> _bestiary;
        public ObservableCollection<Foe> Bestiary
        {
            get => _bestiary;
            set
            {
                _bestiary = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ConsumeCommand> _skills;
        public ObservableCollection<ConsumeCommand> Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ConsumeCommand> _items;
        public ObservableCollection<ConsumeCommand> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection
            <ObservableCollection<Equipment>> _equip;
        public ObservableCollection
            <ObservableCollection<Equipment>> Equip
        {
            get => _equip;
            set
            {
                _equip = value;
                OnPropertyChanged();
            }
        }

        #region Equipment Members
        public void AddEquipment(ArmoryElement armor,
            Equipment[][] equipment)
        {
            int kind = armor.Kind.Byte();
            Equipment piece = equipment
                [kind][armor.Set.Int()];

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

        private protected override void AddSkills
            (HashSet<SkillsID> ramSkills)
        {
            Dictionary<SkillsID, ConsumeCommand>
                skills = Bank.AllSkills();

            foreach (SkillsID id in ramSkills)
            {
                AddSkill(skills[id]);
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
            List<ConsumeCommand> items = Bank.AllItems();

            for (byte i = 0; i < items.Count; i++)
            {
                ConsumeCommand item = items[i];
                item.Subject.SetValue(Hero.Items[i]);
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
                Items[id].Subject.SetValue(++Hero.Items[id]);
        }

        public void DecreaseItemCount(ItemsID item)
        {
            int id = item.Int();
            DecreaseItemCount(id);
        }

        private protected void DecreaseItemCount(int id)
        {
            if (Hero.Items[id] > 0)
                Items[id].Subject.SetValue(--Hero.Items[id]);
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
            Bestiary = new ObservableCollection<Foe>();
            foreach (EnemyBestiary id in Hero.Learned)
            {
                AddFoe(id);
            }
        }

        public virtual void LoadHeroCommands()
        {
            Skills = new ObservableCollection<ConsumeCommand>();
            AddSkills(Hero.Skills);

            Items = new ObservableCollection<ConsumeCommand>();
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
    }
}