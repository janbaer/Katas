using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.GameOfLife
{
    public class Grid
    {
        private HashSet<Cell> _aliveCells = new HashSet<Cell>();

        public Grid(params Cell[] aliveCells )
        {
            Array.ForEach(aliveCells, c => _aliveCells.Add(c));
        }

        public bool IsAlive(Cell cell)
        {
            return _aliveCells.Contains(cell);
        }

        public void NewGeneration()
        {


            var keepAliveNeighboors = _aliveCells.Where(c => GetNumberOfAliveNeighboors(c) == 2 || 
                                                             GetNumberOfAliveNeighboors(c) == 3).ToList();

            var reviveCandidates = _aliveCells.SelectMany(GetDeadNeighboors)
                                             .Where(c => GetNumberOfAliveNeighboors(c) == 3).ToList();
  
            _aliveCells.Clear();
            _aliveCells = new HashSet<Cell>(keepAliveNeighboors.Union(reviveCandidates));
        }

        private int GetNumberOfAliveNeighboors(Cell cell)
        {
            return GetNeighboorsOf(cell).Count(IsAlive);

        }

        private IEnumerable<Cell> GetDeadNeighboors(Cell livingCell)
        {
            return GetNeighboorsOf(livingCell).Except(_aliveCells);
        }

        private IEnumerable<Cell> GetNeighboorsOf(Cell cell)
        {
            var neighboors = new List<Cell>
                                 {
                                     new Cell(cell.X - 1, cell.Y - 1),
                                     new Cell(cell.X, cell.Y - 1),
                                     new Cell(cell.X + 1, cell.Y - 1),
                                     new Cell(cell.X - 1, cell.Y),
                                     new Cell(cell.X + 1, cell.Y),
                                     new Cell(cell.X - 1, cell.Y + 1),
                                     new Cell(cell.X, cell.Y + 1),
                                     new Cell(cell.X + 1, cell.Y + 1)
                                 };

            return neighboors;
        }
    }
}