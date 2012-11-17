using System;

namespace Kata.GameOfLife
{
    public class Cell : IEquatable<Cell>
    {
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public bool Equals(Cell other)
        {
            return other.X == this.X && other.Y == this.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Cell)) return false;

            return Equals((Cell)obj);
        }

        public override int GetHashCode()
        {
            return (this.X*397) ^ this.Y;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", this.X, this.Y);
        }
    }
}