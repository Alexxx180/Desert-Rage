using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats.Enemy;
using DesertRage.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Random = System.Random;

namespace DesertRage.Controls.Scenes.Battle.Strategy.Appear
{
    public class DockStrategy : EnemyAppearing
    {
        private readonly BattleViewModel _battleZone;
        private readonly List<Range> _area;

        private Dictionary<Position, List<Foe>> _stageFoes;
        private List<Position> _keySizes;

        public DockStrategy
            (in BattleViewModel battleZone,
            Range totalArea, params Foe[] foes)
        {
            _battleZone = battleZone;

            _area = new List<Range>
            {
                totalArea
            };

            SortEnemies(foes);
        }

        private void SortEnemies(Foe[] foes)
        {
            _stageFoes = new Dictionary<Position, List<Foe>>();
            _keySizes = new List<Position>();

            for (byte i = 0; i < foes.Length; i++)
            {
                Foe current = foes[i];
                Position size = current.Size;

                if (!_stageFoes.ContainsKey(size))
                {
                    _stageFoes.Add(size, new List<Foe>());
                    _keySizes.Add(size);
                }

                _stageFoes[size].Add(current);
            }
        }

        public ObservableCollection<Foe> Build()
        {
            return SelectEnemies();
        }

        #region FoeSelection Members
        private ObservableCollection<Foe>
            SelectEnemies()
        {
            ObservableCollection<Foe> enemies = new
                ObservableCollection<Foe>();

            Random random = new Random();
            int count = random.Next(1, 6);

            for (byte i = 0; i < count && _area.Count > 0; i++)
            {
                int zone = random.Next(0, _area.Count);

                Range totalArea = _area[zone];

                Position totalSize = totalArea.Size();
                Position selection = SelectSizeGroup(_keySizes, totalSize);
                
                Foe foe = SelectFoe(_stageFoes[selection], totalArea.Point1);
                
                enemies.Add(foe);

                Range foeArea = new Range(totalArea.Point1, selection);

                if (!selection.Equals(totalSize))
                {
                    RecalculateArea(totalArea, foeArea);
                }

                _ = _area.Remove(totalArea);
            }

            return enemies;
        }

        private Position SelectSizeGroup
            (List<Position> keys, Position total)
        {
            Position selection = new Position(0);

            for (byte i = 0; i < keys.Count; i++)
            {
                Position next = keys[i];

                if (next.IsOutTop(selection) ||
                    next.IsOutBottom(total))
                {
                    continue;
                }

                selection = next;
            }

            return selection;
        }

        private Foe SelectFoe(
            List<Foe> foes,
            Position zoneLeftTop
            )
        {
            Random randomFoe = new Random();

            int selection = randomFoe.Next(0, foes.Count);
            Foe current = foes[selection];
            current.Tile = zoneLeftTop - 1;

            return current;
        }
        #endregion

        #region CalculateAvailableSpace Members
        private void RecalculateArea(Range total, Range foe)
        {
            if (total.Point1.X != foe.Point1.X)
            {
                _area.Add(LeftArea(total, foe));
            }

            if (total.Point2.X != foe.Point2.X)
            {
                _area.Add(RightArea(total, foe));
            }

            if (total.Point1.Y != foe.Point1.Y)
            {
                _area.Add(TopArea(total, foe));
            }

            if (total.Point2.Y != foe.Point2.Y)
            {
                _area.Add(BottomArea(total, foe));
            }
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
            return new Range
            {
                Point1 = leftTop,
                Point2 = rightBottom
            };
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
            return new Range
            {
                Point1 = leftTop,
                Point2 = rightBottom
            };
        }

        private Range LeftArea(Range total, Range foe)
        {
            Position leftTop = total.Point1;
            Position rightBottom = new Position
            {
                X = foe.Point1.X - total.Point1.X,
                Y = total.Point2.Y
            };

            return new Range
            {
                Point1 = leftTop,
                Point2 = rightBottom
            };
        }

        private Range RightArea(Range total, Range foe)
        {
            Position leftTop = new Position
            {
                X = foe.Point2.X + 1,
                Y = total.Point1.Y
            };
            Position rightBottom = total.Point2;

            return new Range
            {
                Point1 = leftTop,
                Point2 = rightBottom
            };
        }
        #endregion
    }
}