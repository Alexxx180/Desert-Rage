namespace DesertRage.Model
{
    public class DescriptionUnit : ICloneable<DescriptionUnit>
    {
        public DescriptionUnit() { }

        public DescriptionUnit Clone()
        {
            return new DescriptionUnit
            {
                Icon = Icon,
                Name = Name,
                Description = Description
            };
        }

        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}