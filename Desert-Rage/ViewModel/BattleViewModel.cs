using DesertRage.Controls.Scenes;
using DesertRage.Controls.Scenes.Battle.Avatar;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Map;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesertRage.ViewModel
{
    public class BattleViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Foe> _enemies;
        public ObservableCollection<Foe> Enemies
        {
            get => _enemies;
            set
            {
                _enemies = value;
                OnPropertyChanged();
            }
        }

        public BattleViewModel()
        {
            Player = LevelMap.GetUserData();
            RegularBattleStrategy();
        }

        private UserProfile _player;
        public UserProfile Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged();
            }
        }

        private Model.Stats.Enemy.Foe[] FoesList()
        {
            Model.Stats.Enemy.Foe[] foes = Location.GetFoes();

            return new Model.Stats.Enemy.Foe[]
            {
                foes[0], foes[1],
                foes[2], foes[3],
            };
        }

        private void RegularBattleStrategy()
        {
            Model.Stats.Enemy.Foe[] stageFoes = FoesList();

            System.Random random = new System.Random();
            int count = random.Next(1, 5);

            List<Range> area = new List<Range>
            {
                new Range
                {
                    Point1 = new Position(1, 1),
                    Point2 = BattleScene.SceneSizes
                }
            };

            byte i;

            for (i = 0; i < count && area.Count > 0; i++)
            {
                int zone = random.Next(0, area.Count);

                Range totalArea = area[zone];

                Dictionary
                    <Position, List<Model.Stats.Enemy.Foe>>
                    sizeFoes = new
                    Dictionary
                        <Position, List<Model.Stats.Enemy.Foe>>();

                List<Position> keySizes = new List<Position>();

                byte ii;

                for (ii = 0; ii < stageFoes.Length; ii++)
                {
                    Model.Stats.Enemy.Foe current = stageFoes[ii];
                    Position size = current.Size;

                    if (!sizeFoes.ContainsKey(size))
                    {
                        sizeFoes.Add(size, new List<Model.Stats.Enemy.Foe>());
                        keySizes.Add(size);
                    }

                    sizeFoes[size].Add(current);
                }

                Position selection = new Position(0);
                Position totalSize = totalArea.Size();

                for (ii = 0; ii < keySizes.Count; ii++)
                {
                    Position next = keySizes[ii];

                    if (next.IsOutTop(selection) ||
                        next.IsOutBottom(totalSize))
                    {
                        continue;
                    }

                    selection = next;
                }

                List<Model.Stats.Enemy.Foe> suitable = sizeFoes[selection];
                int foeBySize = random.Next(0, suitable.Count);

                Foe foe = new Foe
                {
                    Battle = this,
                    Size = selection,
                    Tile = totalArea.Point1,
                    Attributes = suitable[foeBySize]
                };

                Enemies.Add(foe);

                Range foeArea = new Range(totalArea.Point1, selection);

                if (selection.Equals(totalSize))
                {
                    _ = area.Remove(totalArea);
                    continue;
                }

                area.AddRange(RecalculateArea(totalArea, foeArea));
                _ = area.Remove(totalArea);
            }
        }

        private List<Range> RecalculateArea(Range total, Range foe)
        {
            List<Range> areas = new List<Range>();

            if (total.Point1.X != foe.Point1.X)
            {
                areas.Add(LeftArea(total, foe));
            }
                
            if (total.Point2.X != foe.Point2.X)
            {
                areas.Add(RightArea(total, foe));
            }
                
            if (total.Point1.Y != foe.Point1.Y)
            {
                areas.Add(TopArea(total, foe));
            }
                
            if (total.Point2.Y != foe.Point2.Y)
            {
                areas.Add(BottomArea(total, foe));
            }

            return areas;
        }

        private Range TopArea(Range total, Range foe)
        {
            Position leftTop = new Position
            {
                X = foe.Point1.X,
                Y = total.Point1.Y
            };
            Position rightBottom = new Position
            {
                X = foe.Point2.X,
                Y = foe.Point1.Y - 1
            };
            return new Range(leftTop, rightBottom);
        }

        private Range BottomArea(Range total, Range foe)
        {
            Position leftTop = new Position
            {
                X = foe.Point1.X,
                Y = foe.Point2.Y + 1
            };
            Position rightBottom = new Position
            {
                X = foe.Point2.X,
                Y = total.Point2.Y
            };
            return new Range(leftTop, rightBottom);
        }

        private Range LeftArea(Range total, Range foe)
        {
            Position leftTop = total.Point1;
            Position rightBottom = new Position
            {
                X = foe.Point1.X - total.Point1.X,
                Y = total.Point2.Y
            };
            return new Range(leftTop, rightBottom);
        }

        private Range RightArea(Range total, Range foe)
        {
            Position leftTop = new Position
            {
                X = foe.Point2.X + 1,
                Y = total.Point1.Y
            };
            Position rightBottom = total.Point2;
            return new Range(leftTop, rightBottom);
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