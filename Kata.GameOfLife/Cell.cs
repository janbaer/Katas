using System;

namespace Kata.GameOfLife
{
    public class Cell   : IEquatable<Cell>
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
        public bool Equals(Cell other)
        {
            if (ReferenceEquals(this, other)) return true;

            if (this.X == other.X && this.Y == other.Y)
            {
                return true;
            }

            return false;
        }
    }
}