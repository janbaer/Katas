using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        public Cell[] AliveCells { get; set; }

        public Grid(params Cell[] aliveCells)
        {
            AliveCells = aliveCells;
        }

        public Grid NewGeneration()
        {
            var aliveCandidates = this.AliveCells.Where(c =>
                                                            {
                                                                var count = GetNumberOfAliveNeighborsOf(c);

                                                                return new[] {2,3}.Contains(count);
                                                            });

            var aviveCandidates = this.AliveCells.SelectMany(GetDeadNeighborsOf)
                                      .Where(c => GetNumberOfAliveNeighborsOf(c) == 3);


            return new Grid(aliveCandidates.Union(aviveCandidates).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighborsOf(Cell cell)
        {
            return GetNeigborsOf(cell).Where(c => !IsAlive(c));
        }


        private int GetNumberOfAliveNeighborsOf(Cell cell)
        {
            return GetNeigborsOf(cell).Count(IsAlive);
        }

        public bool IsAlive(Cell cell)
        {
            return this.AliveCells.Any(c=> c.Equals(cell));
        }

        public IEnumerable<Cell> GetNeigborsOf(Cell cell)
        {
            var neighbors = new List<Cell>();

            foreach (var x in Enumerable.Range(-1, 3))
            {
                foreach (var y in Enumerable.Range(-1, 3))
                {
                    var newCell = new Cell(cell.X + x, cell.Y + y);

                    if (!cell.Equals(newCell))
                    {
                        neighbors.Add(newCell);
                    }
                }
            }

            return neighbors;
        }


    }
}