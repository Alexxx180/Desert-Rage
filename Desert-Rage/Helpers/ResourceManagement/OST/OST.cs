namespace DesertRage.Helpers.ResourceManagement.OST
{
    public class OST : Paths
    {
        protected string OSTPrefix = @"OST\";

        public override string BuildPath(string name)
        {
            return PathsPrefix + OSTPrefix + name;
        }
    }
}