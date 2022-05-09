using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats.Enemy;
using DesertRage.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public ObservableCollection<Avatar.Foe> Build()
        {
            return SelectEnemies();
        }

        #region Status Members
        private void AreaStatus()
        {
            for (byte ii = 0; ii < _area.Count; ii++)
            {
                System.Diagnostics.Trace.WriteLine(_area[ii].ToString());
            }
        }

        private void ZoneStatus
            (Position start, Position size)
        {
            System.Diagnostics.Trace.WriteLine("");
            System.Diagnostics.Trace.WriteLine(start.ToString());
            System.Diagnostics.Trace.WriteLine(size.ToString());
            System.Diagnostics.Trace.WriteLine("");
        }

        private void FoeStatus(Model.Stats.Enemy.Foe someFoe)
        {
            System.Diagnostics.Trace.WriteLine("");
            System.Diagnostics.Trace.WriteLine(someFoe.Icon.ToString());
            System.Diagnostics.Trace.WriteLine(someFoe.Name.ToString());
            System.Diagnostics.Trace.WriteLine(someFoe.Description.ToString());
            System.Diagnostics.Trace.WriteLine(someFoe.Hp.Current.ToString());
            System.Diagnostics.Trace.WriteLine(someFoe.Hp.Max.ToString());
            System.Diagnostics.Trace.WriteLine("");
        }
        #endregion

        #region FoeSelection Members
        private ObservableCollection<Avatar.Foe>
            SelectEnemies()
        {
            ObservableCollection<Avatar.Foe> enemies = new
                ObservableCollection<Avatar.Foe>();

            System.Random random = new System.Random();
            int count = random.Next(1, 6);

            for (byte i = 0; i < count && _area.Count > 0; i++)
            {
                int zone = random.Next(0, _area.Count);

                Range totalArea = _area[zone];

                Position totalSize = totalArea.Size();
                Position selection = SelectSizeGroup(_keySizes, totalSize);

                ZoneStatus(selection, totalArea.Point1);

                Avatar.Foe foe = SelectFoe(_stageFoes[selection],
                    selection, totalArea.Point1);

                enemies.Add(foe);

                Range foeArea = new Range(totalArea.Point1, selection);

                if (!selection.Equals(totalSize))
                {
                    RecalculateArea(totalArea, foeArea);
                }

                _ = _area.Remove(totalArea);

                AreaStatus();
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

        private Avatar.Foe SelectFoe(
            List<Foe> foes,
            Position size,
            Position zoneLeftTop
            )
        {
            System.Random randomFoe = new System.Random();

            int selection = randomFoe.Next(0, foes.Count);
            Foe current = foes[selection];

            FoeStatus(current);

            return new Avatar.Foe
            {
                Battle = _battleZone,
                Size = size,
                Tile = zoneLeftTop - 1,
                Attributes = current
            };
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