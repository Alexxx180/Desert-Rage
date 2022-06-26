﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesertRage.Model.Locations
{
    public class Chip : IPlaceAble, INotifyPropertyChanged
    {
        public Chip() { }

        public Chip(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Set(IPlaceAble place)
        {
            X = place.X;
            Y = place.Y;
        }

        public void Increment(IPlaceAble place)
        {
            X += place.X;
            Y += place.Y;
        }

        public bool IsZero => X == 0 && Y == 0;

        public void Countdown()
        {
            if (--Y <= -1)
            {
                X--;
                Y = 59;
            }
        }

        #region Position Members
        public Position ToPosition()
        {
            return new Position(X, Y);
        }

        public bool IsOverflow(int min, in char[][] map)
        {
            bool overFlow = Y < min || Y >= map.Length;

            if (!overFlow)
            {
                overFlow = X < min || X >= map[Y].Length;
            }

            return overFlow;
        }

        public bool IsOutTop(IPlaceAble mask)
        {
            return X < mask.X || Y < mask.Y;
        }

        public bool IsOutBottom(IPlaceAble mask)
        {
            return X > mask.X || Y > mask.Y;
        }

        #region Overriden Members
        public override string ToString()
        {
            return $"{X}:{Y}";
        }
        #endregion

        private int _x;
        public int X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }

        private int _y;
        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged();
            }
        }
        #endregion

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