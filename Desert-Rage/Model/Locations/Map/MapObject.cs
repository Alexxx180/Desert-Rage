namespace DesertRage.Model.Locations.Map
{
    public class MapObject
    {
        public void PlayerInteract()
        {
            Interaction();
        }

        public delegate void Interact();
        public Interact Interaction { get; private set; }
    }
}
