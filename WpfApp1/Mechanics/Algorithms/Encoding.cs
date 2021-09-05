using System;
using System.Collections;
using static WpfApp1.Customing.Converters.Converters;

namespace WpfApp1.Mechanics.Algorithms
{
    public static class Encoding
    {
        public static byte Encoder(in BitArray ToEncode)
        {
            byte Cipher = 0;
            for (byte i = 0; i < ToEncode.Length; i++)
                if (ToEncode[i])
                    Cipher += Bits(Math.Pow(2, i));
            return Cipher;
        }
        public static BitArray Decoder(in BitArray CipherPattern, byte Cipher)
        {
            int len = CipherPattern.Length - 1;
            for (int i = len; i >= 0; i--)
            {
                byte pin = Bits(Math.Pow(2, i));
                if (Cipher - pin >= 0)
                {
                    Cipher -= pin;
                    CipherPattern[i] = true;
                }
            }
            return CipherPattern;
        }
        public static BitArray Decoder(in BitArray CipherPattern, ushort Cipher)
        {
            int len = CipherPattern.Length - 1;
            for (int i = len; i >= 0; i--)
            {
                ushort pin = Shrt(Math.Pow(2, i));
                if (Cipher - pin >= 0)
                {
                    Cipher -= pin;
                    CipherPattern[i] = true;
                }
            }
            return CipherPattern;
        }
        public static bool GetValueFromDecoder(in BitArray Things, in byte If)
        {
            for (int i = 0; i < Things.Length; i++)
                if (Things[i] && (If == 0))
                    return true;
            return false;
        }
    }
}
