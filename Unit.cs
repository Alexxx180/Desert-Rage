namespace DesertRage.Model
{
    public class Unit : ICloneable<Unit>
    {
        public Unit() { }

        public Unit(Unit unit)
        {
            Set(unit);
        }

        public void Set(Unit unit)
        {
            Name = unit.Name;
        }

        public string Name { get; set; }

        public virtual Unit Clone()
        {
            return new Unit(this);
        }
    }
}