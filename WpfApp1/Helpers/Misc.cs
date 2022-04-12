namespace DesertRage.Helpers
{
    //[EN] Misc class, contents engine values
    //[RU] Класс прочее, содержит параметры двигателя игры
    public class Misc
    {
        public Misc() { InitOnNewGame(); }

        //[EN] Adaptation subclass
        //[RU] Подкласс адаптации
        public class Adopt : Misc
        {
            public Adopt() { AdoptInit(); }
            private void AdoptInit()
            {
                Width = 1;
                Height = 1;
            }
            public double Width { get; set; }
            public double Height { get; set; }
        }
        private void InitOnNewGame()
        {
            EquipmentClass = 0;
            TableEN = true;
            LockIndex = 3;
            StepsToBattle = 20;
            SelectedTarget = 0;
            EnemyRate = 2;
            Rnd1 = 0;
            Rnd2 = 0;
            SpecialBattle = 0;
            ItemsDropRate = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public byte SelectedTarget { get; set; }
        public byte StepsToBattle { get; set; }
        public byte EnemyRate { get; set; }
        public int Rnd1 { get; set; }
        public int Rnd2 { get; set; }
        public byte EquipmentClass { get; set; }
        public bool TableEN { get; set; }
        public byte LockIndex { get; set; }
        public byte SpecialBattle { get; set; }
        public byte[] ItemsDropRate { get; set; }
    }
}
