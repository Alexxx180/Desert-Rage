using System.Collections;

namespace DesertRage.Model.Locations
{
    public class Quests
    {
        public Quests(params string[] descriptions)
        {
            Descriptions = descriptions;
            Completion = new BitArray(descriptions.Length);
        }

        public void Complete(int no)
        {
            Completion[no] = true;
        }

        public readonly string[] Descriptions;

        public BitArray Completion { get; set; }
    }
}