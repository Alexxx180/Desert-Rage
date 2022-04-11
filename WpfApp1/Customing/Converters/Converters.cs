using System;
using System.Collections.Generic;

namespace WpfApp1.Customing.Converters
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

        public static string[] ToStrings(this object[] objs)
        {
            return StrX(objs).ToArray();
        }

        public static List<string> StrX(params object[] objs)
        {
            List<string> list = new List<string>();
            for (byte i = 0; i < objs.Length; i++)
                list.Add(objs[i].ToString());
            return list;
        }

        public static byte BitHex(string hex)
        {
            return (16 * RecognizeHex(hex.ToCharArray()[0]) +
                RecognizeHex(hex.ToCharArray()[1])).ToByte();
        }
        public static byte[] UnHex(string hexColor)
        {
            if (hexColor.Length > 7)
                return new byte[] { BitHex(hexColor.Substring(1, 2)), BitHex(hexColor.Substring(3, 2)), BitHex(hexColor.Substring(5, 2)), BitHex(hexColor.Substring(7, 2)) };
            else
                return new byte[] { BitHex(hexColor.Substring(1, 2)), BitHex(hexColor.Substring(3, 2)), BitHex(hexColor.Substring(5, 2)) };
        }
        private static byte RecognizeHex(char hex)
        {
            return hex switch
            {
                'A' => 10, 'B' => 11,
                'C' => 12, 'D' => 13,
                'E' => 14, 'F' => 15,
                _ => byte.Parse(hex.ToString())
            };
        }
    }
}
