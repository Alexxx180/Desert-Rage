namespace WpfApp1.Model.Locations
{
    public class Location
    {
        public string[] Map { get; set; }

        public void CompeteTask(int taskNo)
        {
            Tasks.Complete(taskNo);
        }

        public void CompleteOther(int taskNo)
        {
            Other.Complete(taskNo);
        }

        internal Quests Tasks { get; set; }
        internal Quests Other { get; set; }
    }
}