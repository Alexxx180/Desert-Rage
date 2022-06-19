namespace DesertRage.Model.Helpers
{
    public static class Casters
    {
        public static byte Byte(this object obj)
        {
            return (byte)obj;
        }

        public static int Int(this object obj)
        {
            return (int)obj;
        }
    }
}