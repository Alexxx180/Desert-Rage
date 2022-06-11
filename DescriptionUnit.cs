namespace DesertRage.Model
{
    public class DescriptionUnit : Unit, ICloneable<DescriptionUnit>
    {
        public DescriptionUnit() { }

        public DescriptionUnit(string meaning) : base(meaning) { }

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
        }

        public string Icon { get; set; }

        public override DescriptionUnit Clone()
        {
            return new DescriptionUnit(this);
        }
    }
}