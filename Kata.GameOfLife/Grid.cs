using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        private readonly List<Cell> _aliveCells;

        public Grid(params Cell[] aliveCells)
        {
            _aliveCells = new List<Cell>(aliveCells);        
        }

        public bool IsAlive(Cell cell)
        {
            return _aliveCells.Any(c=> c.Equals(cell));
        }

        public Grid NewGeneration()
        {
            IEnumerable<Cell> aliveCandidates = _aliveCells.Where(cell => GetCountOfAliveNeighborsOf(cell) == 2 || GetCountOfAliveNeighborsOf(cell) == 3);

            IEnumerable<Cell> reviveCandidates = _aliveCells.SelectMany(GetDeadNeighborsOf).Where(cell => GetCountOfAliveNeighborsOf(cell) == 3);		

            return new Grid(aliveCandidates.Union(reviveCandidates).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Where(c => !IsAlive(c));
        }

        private int GetCountOfAliveNeighborsOf(Cell cell)
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
                    Cell newCell = new Cell(cell.X + x, cell.Y + y);

                    if (!newCell.Equals(cell))
                    {
                        neighbors.Add(newCell);
                    }
                }
            }
            return neighbors;
        }
    }
}