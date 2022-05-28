namespace DesertRage.Model.Helpers
{
    public static class Translators
    {
        public static int Boost(this
            bool status, int min, int max)
        {
            return status ? max : min;
        }

        public static int Boost(this
            bool status, int multiply)
        {
            return status.Boost(1, multiply);
        }
    }
}