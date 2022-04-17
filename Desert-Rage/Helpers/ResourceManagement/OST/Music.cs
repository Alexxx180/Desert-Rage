namespace DesertRage.Helpers.ResourceManagement.OST
{
    public class Music : OST
    {
        protected string MusicPrefix = @"Music\";

        public override string BuildPath(string name)
        {
            return base.BuildPath(MusicPrefix + name);
        }

        #region Main Titles
        public string MainTheme = @"MainTitle.mp3";
        public string Prologue = @"ThePrologue.mp3";
        public string SayGoodbye = @"TheTitles.mp3";
        #endregion

        #region Map Themes
        public string AncientPyramid = @"AncientPyramid_Calm.mp3";
        public string WaterTemple = @"WaterTemple_Calm.mp3";
        public string LavaTemple = @"FireTemple_Calm.mp3";
        public string GetAway = @"TheGreatEscape.mp3";
        #endregion

        #region Battle Themes
        public string FoesChase = @"AncientPyramid_Battle.mp3";
        public string HandleThis = @"WaterTemple_Danger.mp3";
        public string StampSmth = @"FireTemple_Battle.mp3";
        #endregion

        #region Boss Themes
        public string LookWhoAwake = @"AncientPyramid_Boss.mp3";
        public string SayHello = @"WaterTemple_Boss.mp3";
        public string SeriousTalk = @"FireTemple_Boss.mp3";
        public string SeriousIsMe = @"AncientPyramid_Secret.mp3";
        #endregion

        #region TheEnd Themes
        public string AncientKey = @"AncientPyramid_End.mp3";
        public string Conversation = @"WaterTemple_End.mp3";
        public string Threasures = @"FireTemple_End.mp3";
        public string PutTheEnd = @"TheEnd.mp3";
        #endregion
    }
}