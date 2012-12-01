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

        public Grid NewGeneration()
        {
            var aliveCandidates = this.aliveCells.Where(c =>
                                                            {
                                                                int numberOfAliveNeigbors = GetNumberOfAliveNeigborsOf(c);

                                                                return numberOfAliveNeigbors == 2 ||
                                                                       numberOfAliveNeigbors == 3;
                                                            });

            var aviveCandidates = this.aliveCells.SelectMany(GetDeadNeighborsOf).Where(c => GetNumberOfAliveNeigborsOf(c) == 3);

            return new Grid(aliveCandidates.Union(aviveCandidates).ToArray());
        }


        public bool IsAlive(Cell cell)
        {
            return this.aliveCells.Any(c=>c.Equals(cell));
        }

        public IEnumerable<Cell> GetNeighborsOf(Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();

            foreach (var x in Enumerable.Range(-1, 3))
            {
                foreach (var y in Enumerable.Range(-1, 3))
                {
                    Cell newCell = new Cell(cell.X +x , cell.Y + y);
                    if (!newCell.Equals(cell))
                    {
                        neighbors.Add(newCell);
                    }
                }
            }


            return neighbors;
        }

        

        public int GetNumberOfAliveNeigborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Count(IsAlive);
        }

        public IEnumerable<Cell> GetDeadNeighborsOf(Cell cell)
        {
            return this.GetNeighborsOf(cell).Where(c => IsAlive(c) == false);
        }
    }
}