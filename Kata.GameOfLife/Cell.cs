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
            if (ReferenceEquals(this, other)) return true;

            return this.X == other.X && this.Y == other.Y;
        }
    }
}