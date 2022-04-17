namespace DesertRage.Helpers.ResourceManagement.OST
{
    public class Noises : OST
    {
        protected string NoisePrefix = @"Noises\";

        public override string BuildPath(string name)
        {
            return base.BuildPath(NoisePrefix + name);
        }

        #region InBattle
        public string Danger = @"Ambushed.mp3";
        public string Danger2 = @"FoesNearby.mp3";
        public string Danger3 = @"GetReady.mp3";
        public string NowTheWinnerIs = @"YouWon.mp3";
        #endregion

        #region Mobs Death
        public string SpiderDied = @"SpiderDied.mp3";
        public string MummyDied = @"MummyDied.mp3";
        public string ZombieDied = @"ZombieDied.mp3";
        public string BonesDied = @"BonesDied.mp3";
        public string VultureDied = @"VultureDied.mp3";
        public string GhoulDied = @"GhoulDied.mp3";
        public string GrimReaperDied = @"GrimReaperDied.mp3";
        public string ScarabDied = @"ScarabDied.mp3";
        public string KillerMoleDied = @"KillerMoleDied.mp3";
        public string ImpDied = @"ImpDied.mp3";
        public string WormDied = @"WormDied.mp3";
        public string MasterDied = @"MasterDied.mp3";
        #endregion

        #region Bosses Death
        public string PhaGetLost = @"DefeatPharaoh.mp3";
        public string ByeFriend = @"DefeatFriend.mp3";
        public string ThisIsAll = @"DefeatMasterOfAll.mp3";
        public string HereGetSome = @"UghZan1Died.mp3";
        #endregion
    }
}