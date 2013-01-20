using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        private readonly Cell[] _aliveCells;

        public Grid(params Cell[] aliveCells)
        {
            _aliveCells = aliveCells;
        }

        public bool IsAlive(int x, int y)
        {
            return IsAlive(new Cell(x, y));
        }

        public bool IsAlive(Cell cell)
        {
            return _aliveCells.Any(c => c.Equals(cell));
        }

        public bool IsNotAlive(Cell cell)
        {
            return IsAlive(cell) == false;
        }

        public Grid NewGeneration()
        {
            IEnumerable<Cell> keepAliveCandidates = _aliveCells.Where(cell => GetCountOfAliveNeighbors(cell) == 2 || GetCountOfAliveNeighbors(cell) == 3);

            var reviveCandidates = _aliveCells.SelectMany(GetDeadNeighborsOf).Where(c => GetCountOfAliveNeighbors(c) == 3);
            
            return new Grid(keepAliveCandidates.Union(reviveCandidates).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Where(IsNotAlive);
        }

        private int GetCountOfAliveNeighbors(Cell cell)
        {
            return GetNeighborsOf(cell).Count(IsAlive);
        }

        private IEnumerable<Cell> GetNeighborsOf(Cell cell)
        {
            IList<Cell> neighbors = new List<Cell>();

            foreach (int x in Enumerable.Range(-1, 3))
            {
                foreach (int y in Enumerable.Range(-1, 3))
                {
                    Cell neighbor = new Cell(cell.X + x, cell.Y + y);
                    if (neighbor.Equals(cell) == false)
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }
                                                               
            return neighbors;
        }
    }
}