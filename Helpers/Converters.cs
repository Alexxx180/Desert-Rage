using System;
using System.Text;
using DesertRage.Model.Locations;

namespace DesertRage.Model.Helpers
{
    public static class Converters
    {
        public static bool ToBool(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static byte ToByte(this object obj)
        {
            return Convert.ToByte(obj);
        }

        public static sbyte ToSByte(this object obj)
        {
            return Convert.ToSByte(obj);
        }

        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static ushort ToUShort(this object obj)
        {
            return Convert.ToUInt16(obj);
        }

        public static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static Array ToValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum));
        }

        public static Position ToPosition(this string position)
        {
            string[] units = position.Split(':');
            return new Position
            {
                X = units[0].ToInt(),
                Y = units[1].ToInt()
            };
        }
    }
}