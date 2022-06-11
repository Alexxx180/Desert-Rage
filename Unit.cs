namespace DesertRage.Model
{
    public class Unit : ICloneable<Unit>
    {
        public Unit() { }

        public Unit(string meaning)
        {
            Description = meaning;
        }

        public Unit(Unit unit)
        {
            Set(unit);
        }

        public void Set(Unit unit)
        {
            Name = unit.Name;
            Description = unit.Description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Unit Clone()
        {
            return new Unit(this);
        }
    }
}