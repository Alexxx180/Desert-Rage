namespace DesertRage.Model
{
    public class DescriptionUnit : Unit, ICloneable<DescriptionUnit>
    {
        public DescriptionUnit() { }

        public DescriptionUnit(string meaning) : base(meaning) { }

        public DescriptionUnit(int value, 
            string meaning) : this($"+{value} {meaning}") { }

        public DescriptionUnit(Unit unit)
        {
            Name = unit.Name;
            Description = unit.Description;
        }

        public new DescriptionUnit Clone()
        {
            return new DescriptionUnit(base.Clone())
            {
                Icon = Icon
            };
        }

        public string Icon { get; set; }
    }
}