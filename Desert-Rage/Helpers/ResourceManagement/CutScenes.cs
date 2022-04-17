namespace DesertRage.Helpers.ResourceManagement
{
    public class CutScenes : Paths
    {
        protected string CutScenePrefix = @"CutScenes\";

        public override string BuildPath(string name)
        {
            return PathsPrefix + CutScenePrefix + name;
        }

        #region EnemyDrawsNear
        public string Ambushed = @"BattleStarts\BattleStations1.mp4";
        public string BattleStations = @"BattleStarts\BattleStations2.mp4";
        public string NotAgain = @"BattleStarts\BattleStations3.mp4";
        #endregion

        #region AnotherChapter
        public string PreChapter1 = @"ChaptersIntroduction\Chapter1.mp4";
        public string PreChapter2 = @"ChaptersIntroduction\Chapter2.mp4";
        public string PreChapter3 = @"ChaptersIntroduction\Chapter3.mp4";
        public string PreChapter4 = @"ChaptersIntroduction\Epilogue.mp4";
        #endregion

        #region Victory
        public string Victory = @"BattleEnds\Win1.mp4";
        public string WasteTime = @"BattleEnds\Win2.mp4";
        public string PowerRanger = @"BattleEnds\Win3.mp4";
        #endregion

        #region ChapterResults
        public string Fin_Chapter1 = @"ChaptersEnding\Final1.mp4";
        public string Fin_Chapter2 = @"ChaptersEnding\Final2.mp4";
        public string Fin_Chapter3 = @"ChaptersEnding\Final3.mp4";
        #endregion

        #region Ending
        public string Ending = @"ChaptersEnding\Ending.mp4";
        public string Titres = @"ChaptersEnding\Titres.mp4";
        #endregion
    }
}