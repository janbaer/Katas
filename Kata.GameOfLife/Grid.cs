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
            return this.aliveCells.Any(c => c.X == cell.X && c.Y == cell.Y);
        }

        public Grid NewGeneration()
        {
            var aliveCandidates = this.aliveCells.Where(c =>
                                                            {
                                                                int count = GetNumberOfAliveNeighborsOf(c);

                                                                return count == 2 || count == 3;
                                                            });

            var reviveCandidates = this.aliveCells.SelectMany(GetDeadNeighborsOf)
                                       .Where(c => GetNumberOfAliveNeighborsOf(c) == 3);

            return new Grid(aliveCandidates.Union(reviveCandidates).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Where(c=>!IsAlive(c));
        }

        private int GetNumberOfAliveNeighborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Count(IsAlive);
        }

        public IEnumerable<Cell> GetNeighborsOf(Cell cell)
        {
            var neighbors = new List<Cell>();
            foreach (var x in Enumerable.Range(-1, 3))
            {
                foreach (var y in Enumerable.Range(-1, 3))
                {
                    var newCell = new Cell(cell.X + x, cell.Y + y);
                    if ((newCell.X == cell.X && newCell.Y == cell.Y) == false)
                    {
                        neighbors.Add(newCell);
                    }
                }
            }
            return neighbors;
        }
    }
}