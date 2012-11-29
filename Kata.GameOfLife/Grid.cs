using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        private readonly List<Cell> cells;

        public Grid(params Cell[] aliveCells)
        {
            cells = new List<Cell>(aliveCells);
        }

        public bool IsAlive(Cell cellToCheck)
        {
            return cells.Any(c => c.Equals(cellToCheck));
        }

        public Grid NewGeneration()
        {
            var deadNeighboursWith3Alive = GetDeadNeighboursWithAlive(3);
            
            var aliveCandidates = this.cells.Where(
                c => {
                         int numberOfAliveNeighbors = GetNumbersOfAliveNeighborsOf(c);
                         return numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3;

                });

            return new Grid(aliveCandidates.Union(deadNeighboursWith3Alive).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighboursWithAlive(int numberOfAliveNeighbours)
        {
            var neighborsOfCells = new List<Cell>();
            foreach (var cell in this.cells)
            {
                neighborsOfCells.AddRange(this.GetNeighborsOf(cell));
            }

            var deadNeighboursWithSomeAlive =
                neighborsOfCells.Where(c => !IsAlive(c)).Where(c => GetNumbersOfAliveNeighborsOf(c) == numberOfAliveNeighbours);
            return deadNeighboursWithSomeAlive;
        }

        private int GetNumbersOfAliveNeighborsOf(Cell cell)
        {
            return GetNeighborsOf(cell).Count(IsAlive);
        }

        public IEnumerable<Cell> GetNeighborsOf(Cell cell)
        {
            var neighbours = new List<Cell>();

            foreach (var x in Enumerable.Range(-1, 3))
            {
                foreach (var y in Enumerable.Range(-1, 3))
                {
                    var newCell = new Cell(cell.X + x, cell.Y + y);

                    if (!newCell.Equals(cell))
                    {
                        neighbours.Add(newCell);
                    }
                }
            }

            return neighbours;
        }
    }
}