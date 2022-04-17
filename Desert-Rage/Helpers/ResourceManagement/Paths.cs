namespace DesertRage.Helpers.ResourceManagement
{
    public abstract class Paths
    {
        protected string PathsPrefix = @"Resources\";

        public abstract string BuildPath(string name);
    }
}