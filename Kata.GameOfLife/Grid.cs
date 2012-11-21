using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        private IList<Cell> aliveCells; 

        public Grid(params Cell[] aliveCells)
        {
            this.aliveCells = new List<Cell>(aliveCells);
        }

        public bool IsAlive(Cell cell)
        {
            return this.aliveCells.Any(c => c.X == cell.X && c.Y == cell.Y);
        }

        public Grid NewGeneration()
        {
            var aliveCandidates = this.aliveCells.Where(c =>
                                                            {
                                                                int count = GetNumberOfAlifeNeighboorsOf(c);
                                                                return count == 2 || count == 3;
                                                            });

            var aviveCandidates = this.aliveCells.SelectMany(GetDeadNeighboorsOf).Where(c => GetNumberOfAlifeNeighboorsOf(c) == 3);

            return new Grid(aliveCandidates.Union(aviveCandidates).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighboorsOf(Cell cell)
        {
            return GetNeighboorsOf(cell).Where(c=> !IsAlive(c));
        }

        private int GetNumberOfAlifeNeighboorsOf(Cell cell)
        {
            return GetNeighboorsOf(cell).Count(IsAlive);
        }

        public IEnumerable<Cell> GetNeighboorsOf(Cell cell)
        {
            IList<Cell> neighboors = new List<Cell>();
            foreach (var x in Enumerable.Range(-1, 3))
            {
                foreach (var y in Enumerable.Range(-1, 3))
                {
                    if ((cell.X + x == cell.X && cell.Y + y == cell.Y) == false)
                    {
                        neighboors.Add(new Cell(cell.X + x, cell.Y + y));
                    }
                }
            }
            return neighboors;
        }
    }
}