using System.Collections.Generic;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Menu.Things.Logic;
using System;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Stats.Player;
using System.IO;
using DesertRage.ViewModel.User.Battle.Components.Strategy.Fight;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent;
using DesertRage.Model.Locations.Battle;
using DesertRage.Resources.Localization;
using DesertRage.Model;
using DesertRage.Model.Locations.Battle.Things;

namespace DesertRage.ViewModel
{
    internal static class Bank
    {
        /// <summary>
        /// Game data total storage
        /// </summary>
        
        internal const string DataDirectory = "/Resources/Media/Data";

        internal static void MakeProfile(string name)
        {
            string full = $"{DataDirectory}/Profiles/{name}".ToFull();
            Directory.CreateDirectory(full);
        }

        internal static void DropProfile(string name)
        {
            string full = $"{DataDirectory}/Profiles/{name}".ToFull();
            Directory.Delete(full, true);
        }

        #region Get Data Members
        private static T GetData<T>(string path)
        {
            string full = path.ToFull();
            System.Diagnostics.Trace.WriteLine(full);

            return File.Exists(full) ?
                App.Processor.Read<T>(full) :
                default;
        }

        private static T GetItems<T>(string path)
        {
            return GetData<T>($"{DataDirectory}/{path}");
        }
        
        private static T GetCharacterData<T>(string name)
        {
            return GetItems<T>($"Characters/{name}.json");
        }

        #region Prefab Members
        internal static string[] LoadTips()
        {
            return GetItems<string[]>($"Items/{Paths.Help}.json");
        }      

        internal static Settings LoadPreferences()
        {
            return GetItems<Settings>($"Items/Preferences.json");
        }

        internal static HashSet<string> LoadHeroKeys()
        {
            return GetCharacterData<HashSet<string>>("Unlock");
        }
        
        internal static DescriptionUnit LoadHeroInitials(string name)
        {
            System.Diagnostics.Trace.WriteLine(Paths.Beginner);
            return GetCharacterData<DescriptionUnit>($"{name}/{Paths.Beginner}");
        }
        
        internal static Character LoadHero(string name)
        {
            return GetCharacterData<Character>($"{name}/{Paths.Beginner}");
        }

        internal static Location LoadLevel(string name)
        {
            return GetItems<Location>($"Map/{name}.json");
        }

        internal static NextStats GetNextStats(string name)
        {
            return GetItems<NextStats>($"Characters/{name}/Next.json");
        }

        internal static Equipment[][] GetEqupment()
        {
            return GetItems<Equipment[][]>($"Items/{Paths.Equipment}.json");
        }
        
        internal static List<AttributeUnit> GetInventory()
        {
            return GetItems<List<AttributeUnit>>($"Items/{Paths.Inventory}.json");
        }
        
        internal static Dictionary<string, AttributeUnit> GetSkills()
        {
            return GetItems<Dictionary<string, AttributeUnit>>($"Items/{Paths.Skills}.json");
        }

        internal static Foe[] Foes()
        {
            return GetItems<Foe[]>($"Opponents/{Paths.Foes}.json");
        }

        internal static Boss[] Bosses()
        {
            return GetItems<Boss[]>($"Opponents/{Paths.Bosses}.json");
        }
        #endregion

        #region Profile Members
        private static T GetProfileItems<T>(string name)
        {
            return GetItems<T>($"Profiles/{name}.json");
        }

        internal static Character LoadProfileHero(string name)
        {
            return GetProfileItems<Character>($"{name}/Hero");
        }

        internal static Location LoadProfileLevel(string name)
        {
            return GetProfileItems<Location>($"{name}/Level");
        }

        internal static Settings LoadProfilePreferences(string name)
        {
            return GetProfileItems<Settings>($"{name}/Preferences");
        }
        #endregion
        
        #endregion

        #region Set Data Members
        private static void SetData<T>(string path, T data)
        {
            string full = path.ToFull();
            System.Diagnostics.Trace.WriteLine(full);
            App.Processor.Write(full, data);
        }

        private static void SetItems<T>(string path, T items)
        {
            SetData($"{DataDirectory}/{path}.json", items);
        }

        #region Prefab Members
        internal static void SavePreferences(Settings preferences)
        {
            SetItems($"Items/Preferences", preferences);
        }
        #endregion

        #region Profile Members
        private static void
            SetProfileItems<T>(string name, T profileItems)
        {
            SetItems($"Profiles/{name}", profileItems);
        }

        internal static void
            SaveProfileHero(string name, Character hero)
        {
            SetProfileItems($"{name}/Hero", hero);
        }

        internal static void
            SaveProfileLevel(string name, Location level)
        {
            SetProfileItems($"{name}/Level", level);
        }

        internal static void
            SaveProfilePreferences(string name, Settings preferences)
        {
            SetProfileItems($"{name}/Preferences", preferences);
        }
        
        internal static void SaveCharacter(string name)
        {
            HashSet<string> heroes = LoadHeroKeys();
            heroes.Add(name);
            SetItems($"Characters/Unlock", heroes);
        }
        #endregion

        #endregion

        internal static IParticipantFight[] Fights()
        {
            return new IParticipantFight[]
            {
                new Attack(),
                new Poison(new Position(8, 1))
            };
        }

        public static string ToFull(this string path)
        {
            return Environment.CurrentDirectory + path;
        }

        public static void ForEach<T, TParam>
            (this IEnumerable<T> collection, in
            Action<T, TParam> method, TParam parameter)
        {
            foreach (T @object in collection)
            {
                method(@object, parameter);
            }
        }
    }
}
