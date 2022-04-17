﻿namespace DesertRage.Model.Stats
{
    public class NextStats
    {
        public ushort[] Hp { get; set; }
        public ushort[] Ap { get; set; }

        public byte[] Attack { get; set; }
        public byte[] Defense { get; set; }
        public byte[] Speed { get; set; }
        public byte[] Special { get; set; }
    }
}