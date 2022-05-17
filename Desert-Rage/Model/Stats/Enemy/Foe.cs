using DesertRage.Model.Locations.Map;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.Model.Stats.Enemy
{
    #warning NEED TO DEFINE FOE VIEW MODEL TO MAKE IT WORK BETTER!!
    // Enemy logic
    public class Foe : BattleUnit, INotifyPropertyChanged
    {
        public Foe()
        {
            Size = new Position(1);
        }

        public Foe(Foe foe) : base(foe)
        {
            No = foe.No;
            
            Death = foe.Death;

            Tile = foe.Tile;
            Size = foe.Size;

            Experience = foe.Experience;
            DropRate = foe.DropRate;
        }

        public EnemyBestiary No { get; set; }
        public Position Tile { get; set; }
        public Position Size { get; set; }

        public string Death { get; set; }

        public byte Experience { get; set; }
        public byte DropRate { get; set; }

        public void Update()
        {
            OnPropertyChanged(nameof(Hp));
            //OnPropertyChanged();
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}