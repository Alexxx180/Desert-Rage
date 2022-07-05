using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using System;
using System.Collections.Generic;
using Random = System.Random;
using Range = DesertRage.Model.Locations.Battle.Range;

namespace DesertRage.ViewModel.User.Battle.Components.Strategy.Appear
{
    public class DockStrategy : IEnemyAppearing
    {
        private Range _startArea;

        private readonly List<Range> _area;

        private Dictionary<Position, List<Foe>> _stageFoes;
        private List<Position> _keySizes;

        private DockStrategy()
        {
            _randomFoe = new Random();
            _area = new List<Range>();
            _stageFoes = new Dictionary<Position, List<Foe>>();
            _keySizes = new List<Position>();
        }

        /// <summary>
        /// Divide the battle field on four parts and fill
        /// it with the random enemies from largest to 
        /// smallest size recursively in such order:
        /// left -> top -> bottom -> right
        /// </summary>
        /// <param name="totalArea">Total area of battlefield</param>
        public DockStrategy(Range totalArea) : this()
        {
            _startArea = totalArea;
        }

        internal void ResetArea()
        {
            _area.Clear();
            _area.Add(_startArea);
        }

        internal void ResetArea(Range area)
        {
            _startArea = area;
            ResetArea();
        }

        public void ResetEnemies(params Foe[] foes)
        {
            _stageFoes.Clear();
            _keySizes.Clear();
            SortEnemies(foes);
        }

        private void SortEnemies(Foe[] foes)
        {
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

        public List<Tuple<Position, Foe>> Build()
        {
            ResetArea();
            return SelectEnemies();
        }

        #region FoeSelection Members
        private List<Tuple<Position, Foe>> SelectEnemies()
        {
            List<Tuple<Position, Foe>> enemies = new
                List<Tuple<Position, Foe>>();

            Random random = new Random();
            int count = random.Next
                (1, Opponents.Max + 1);

            for (byte i = 0; i < count && _area.Count > 0; i++)
            {
                int zone = random.Next(0, _area.Count);

                Range totalArea = _area[zone];

                Position totalSize = totalArea.Size();
                Position selection = SelectSizeGroup(_keySizes, totalSize);

                Tuple<Position, Foe> enemy = SelectEnemy
                    (_stageFoes[selection], totalArea.Point1);

                enemies.Add(enemy);

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

        private Tuple<Position, Foe> SelectEnemy
            (List<Foe> foes, Position zoneLeftTop)
        {
            int selection = _randomFoe.Next(0, foes.Count);
            Foe current = foes[selection];

            return new Tuple<Position, Foe>
                (zoneLeftTop - 1, current);
        }

        private readonly Random _randomFoe;
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
