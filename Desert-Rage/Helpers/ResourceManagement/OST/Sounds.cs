namespace DesertRage.Helpers.ResourceManagement.OST
{
    public class Sounds : OST
    {
        protected string SoundPrefix = @"Sounds\";

        public override string BuildPath(string name)
        {
            return base.BuildPath(SoundPrefix + name);
        }

        #region Map
        public string Door = @"DoorOpened.mp3";
        public string Chest = @"ChestOpened.mp3";
        public string Save = @"SaveSound.mp3";
        public string BagOpen = @"ItemsOpen.mp3";
        public string BagClose = @"ItemsClose.mp3";
        #endregion

        #region InBattle
        public string LevelUp = @"LevelUp.mp3";
        #endregion

        #region Weapons
        public string HandAttack = @"Punch.mp3";
        public string Knife = @"Knife.mp3";
        public string Sword = @"Sword.mp3";
        public string Minigun = @"Minigun2.mp3";
        #endregion

        #region Other actions
        public string StrongStand = @"Defence.mp3";
        public string FleeAway = @"Escape.mp3";
        public string UseItems = @"ItemsUsed.mp3";
        #endregion

        #region Battle Skills
        public string Torch = @"Torch.mp3";
        public string Whip = @"Whip.mp3";
        public string Thrower = @"Thrower.mp3";
        public string Super = @"Super.mp3";
        public string Whirl = @"Wind.mp3";
        public string Quake = @"Quake.mp3";
        public string Learn = @"Scan.mp3";
        #endregion

        #region Healing Abilities
        public string Cure = @"Cure.mp3";
        public string Cure2 = @"Cure2.mp3";
        public string Heal = @"Heal.mp3";
        public string PowerUp = @"PowUp.mp3";
        public string Shield = @"Shield.mp3";
        public string HpUp = @"HpUp.mp3";
        public string ApUp = @"Control.mp3";
        #endregion
    }
}