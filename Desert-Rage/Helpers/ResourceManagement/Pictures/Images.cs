namespace DesertRage.Helpers.ResourceManagement.Pictures
{
    public class Images : Paths
    {
        protected string ImagePrefix = @"Images\";

        public override string BuildPath(string name)
        {
            return PathsPrefix + ImagePrefix + name;
        }
    }
}