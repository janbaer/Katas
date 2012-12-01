using System;

namespace Kata.GameOfLife
{
    public class Cell : IEquatable<Cell>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Cell other)
        {
            if (ReferenceEquals(this, other)) return true;

            return this.X == other.X && this.Y == other.Y;
        }
    }
}