namespace DesertRage.Model
{
    public class DescriptionUnit
    {
        public DescriptionUnit()
        {
        }

        public DescriptionUnit(DescriptionUnit copy)
        {
            Icon = copy.Icon;
            Name = copy.Name;
            Description = copy.Description;
        }

        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}