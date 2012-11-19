using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        private HashSet<Cell> aliveCells;

        public Grid(params Cell[] aliveCells)
        {
            this.aliveCells = new HashSet<Cell>(aliveCells);
        }

        public void NewGeneration()
        {
            var aliveCandidates = this.aliveCells.Where(c =>
                                                            {
                                                                int count = GetCountOfAliveNeighboors(c);

                                                                return count == 2 || count == 3;

                                                            }).ToList();

            var aviveCandidates = this.aliveCells.SelectMany(GetDeadNeighboorsOf).Where(c => (GetCountOfAliveNeighboors(c) == 3)).ToList();

            
            this.aliveCells = new HashSet<Cell>(aliveCandidates.Union(aviveCandidates));
        }

        private IEnumerable<Cell> GetDeadNeighboorsOf(Cell cell)
        {
            return GetNeighboorsOf(cell).Where(c => IsAlive(c) == false);
        }

        private int GetCountOfAliveNeighboors(Cell cell)
        {
            return GetNeighboorsOf(cell).Count(IsAlive);
        }


        public bool IsAlive(Cell cell)
        {
            return aliveCells.Contains(cell);
        }

        public IEnumerable<Cell> GetNeighboorsOf(Cell cell)
        {
            var neighboors = new List<Cell>
                                 {
                                     new Cell(cell.X, cell.Y - 1),
                                     new Cell(cell.X, cell.Y + 1),
                                     new Cell(cell.X - 1, cell.Y - 1),
                                     new Cell(cell.X + 1, cell.Y + 1),
                                     new Cell(cell.X - 1, cell.Y),
                                     new Cell(cell.X + 1, cell.Y),
                                     new Cell(cell.X + 1, cell.Y - 1),
                                     new Cell(cell.X - 1, cell.Y + 1)
                                 };


            return neighboors;
        }
    }
}