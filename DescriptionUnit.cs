namespace DesertRage.Model
{
    public class DescriptionUnit : Unit, ICloneable<DescriptionUnit>
    {
        public DescriptionUnit() { }

        public DescriptionUnit(string meaning)
        {
            Description = meaning;
        }

        public DescriptionUnit(int value, string meaning) :
            this($"+{value} {meaning}") { }

        public DescriptionUnit(DescriptionUnit unit)
        {
            Set(unit);
        }

        public void Set(DescriptionUnit unit)
        {
            base.Set(unit);
            Icon = unit.Icon;
            Description = unit.Description;
        }

        public string Icon { get; set; }
        public string Description { get; set; }

        public override DescriptionUnit Clone()
        {
            return new DescriptionUnit(this);
        }
    }
}