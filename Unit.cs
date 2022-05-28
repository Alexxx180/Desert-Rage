namespace DesertRage.Model
{
    public class Unit
    {
        public Unit() { }

        public Unit(string meaning)
        {
            Description = meaning;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public Unit Clone()
        {
            return new Unit
            {
                Name = Name,
                Description = Description
            };
        }
    }
}