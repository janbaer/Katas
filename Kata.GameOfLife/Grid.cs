using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        private readonly Cell[] aliveCells;

        public Grid(params Cell[] aliveCells)
        {
            this.aliveCells = aliveCells;
        }

        public bool IsAlive(Cell cell)
        {
            return this.aliveCells.Any(c=> c.Equals(cell));
        }

        public Grid NewGeneration()
        {
            var aliveCandidates = this.aliveCells.Where(c => GetNumberOfAliveNeighborsOf(c) == 2 || GetNumberOfAliveNeighborsOf(c) == 3);

            var aviveCandidates = this.aliveCells.SelectMany(GetDeadNeighboorsOf).Where(c => GetNumberOfAliveNeighborsOf(c) == 3);

            return new Grid(aliveCandidates.Union(aviveCandidates).ToArray());
        }


        public IEnumerable<Cell> GetNeighborsOf(Cell cell)
        {
            var neighbors = new List<Cell>();

            foreach (var x in Enumerable.Range(-1, 3))
            {
                foreach (var y in Enumerable.Range(-1, 3))
                {
                    var newCell = new Cell(cell.X + x, cell.Y + y);

                    if (newCell.Equals(cell) == false)
                    {
                        neighbors.Add(newCell);
                    }


                }
            }

            return neighbors;
        }

        public int GetNumberOfAliveNeighborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Count(IsAlive);
        }

        public IEnumerable<Cell> GetDeadNeighboorsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Where(c => !IsAlive(c));
        }
    }
}