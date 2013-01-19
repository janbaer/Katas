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
            return _aliveCells.Any(c=> c.X == x && c.Y == y);
        }

        public bool IsAlive(Cell cell)
        {
            return IsAlive(cell.X, cell.Y);
        }

        public Grid NewGeneration()
        {
            IEnumerable<Cell> keepAliveCandidates = _aliveCells.Where(c =>
                                                                          {
                                                                              var count = GetCountOfAliveNeighbors(c);

                                                                              return count == 2 || count == 3;
                                                                          });
            IEnumerable<Cell> reviveCandidates = _aliveCells.SelectMany(GetDeadNeighborsOf).Where(c => GetCountOfAliveNeighbors(c) == 3);

            return new Grid(keepAliveCandidates.Union(reviveCandidates).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Where(c => IsAlive(c) == false);
        }

        private int GetCountOfAliveNeighbors(Cell cell)
        {
            return GetNeighborsOf(cell).Count(IsAlive);
        }

        private IEnumerable<Cell> GetNeighborsOf(Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();

            foreach (int x in Enumerable.Range(-1, 3))
            {
                foreach (int y in Enumerable.Range(-1, 3))
                {
                    var neighbor = new Cell(cell.X + x, cell.Y + y);

                    if ((cell.X == neighbor.X && cell.Y == neighbor.Y) == false)
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }
            return neighbors;
        }
    }
}