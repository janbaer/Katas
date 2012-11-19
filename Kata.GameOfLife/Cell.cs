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

        public int Y { get; set; }
        public int X { get; set; }


        public bool Equals(Cell other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Cell);
        }

        public override int GetHashCode()
        {
            return (this.X * 397) ^ this.Y;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", this.X, this.Y);
        }
    }
}