namespace DesertRage.Helpers.ResourceManagement.Pictures
{
    public class Background : Images
    {
        protected string BackgroundPrefix = @"Background\";

        public override string BuildPath(string name)
        {
            return base.BuildPath(BackgroundPrefix + name);
        }

        public string Black = @"Black.jpg";
        public string Cover = @"Cover.jpg";
    }
}