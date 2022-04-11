using System.Collections;

namespace WpfApp1.Model.Locations
{
    public class Quests
    {
        public Quests(int length)
        {
            Descriptions = new string[length];
            Completion = new BitArray(new bool[length]);
        }

        public void Complete(int no)
        {
            Completion[no] = true;
        }

        public string[] Descriptions { get; set; }
        public BitArray Completion { get; set; }
    }
}