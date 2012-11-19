using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using FluentAssertions;


namespace Kata.GameOfLife
{
    [TestFixture]
    public class GameOfLifeTests
    {

        /// <summary></summary>
        [Test]
        public void new_generation_should_kill_alive_cell_with_fewer_than_two_live_neighbours()
        {
            // ARRANGE
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 2);
            var grid = new Grid(cell1, cell2);

            // ACT
            grid.NewGeneration();

            // ASSERT
            Assert.False(grid.IsAlive(cell1));
            Assert.False(grid.IsAlive(cell2));
        }

        /// <summary></summary>
        [Test]
        public void new_generation_should_keep_alive_cell_with_two_live_neighbours()
        {
            // ARRANGE
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(2, 1);
            var cell3 = new Cell(3, 2);
            var grid = new Grid(cell1, cell2, cell3);            

            // ACT
            grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(cell1));
            Assert.IsTrue(grid.IsAlive(cell2));
            Assert.IsFalse(grid.IsAlive(cell3));

        }

        /// <summary></summary>
        [Test]
        public void new_generation_should_keep_alive_cell_with_three_live_neighbours()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2), new Cell(2, 1), new Cell(2, 2));

            // ACT
            grid.NewGeneration();

            // ASSERT
            Assert.IsTrue(grid.IsAlive(new Cell(1, 1)));
            Assert.IsTrue(grid.IsAlive(new Cell(2, 2)));
            Assert.IsTrue(grid.IsAlive(new Cell(1, 2)));
            Assert.IsTrue(grid.IsAlive(new Cell(2, 1)));
            Assert.IsFalse(grid.IsAlive(new Cell(3, 2)));

        }

        /// <summary></summary>
        [Test]
        public void new_generation_should_kill_alive_cell_with_more_than_three_live_neighbours()
        {
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2), new Cell(2, 1), new Cell(2, 2), new Cell(3,2));

            // ACT
            grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(2, 2)));
        }
        
        /// <summary></summary>
        [Test]
        public void new_generation_should_revive_dead_cell_with_three_live_neighbours()
        {
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2), new Cell(2, 1));

            // ACT
            grid.NewGeneration();

            // ASSERT
            Assert.IsTrue(grid.IsAlive(new Cell(2, 2)));
            Assert.IsFalse(grid.IsAlive(new Cell(3, 2)));
        }

        /// <summary></summary>
        [Test]
        public void GetNeighboorsOfTest()
        {
            // ARRANGE
            var grid = new Grid();

            // ACT
            IEnumerable<Cell> neighboors = grid.GetNeighboorsOf(new Cell(2, 2));

            // ASSERT
            Assert.IsTrue(neighboors.Any(c=> c.X == 1 && c.Y == 1));
            Assert.IsTrue(neighboors.Any(c=> c.X == 1 && c.Y == 2));
            Assert.IsTrue(neighboors.Any(c=> c.X == 1 && c.Y == 3));
            Assert.IsTrue(neighboors.Any(c=> c.X == 2 && c.Y == 1));
            Assert.IsTrue(neighboors.Any(c=> c.X == 2 && c.Y == 3));
            Assert.IsTrue(neighboors.Any(c=> c.X == 3 && c.Y == 1));
            Assert.IsTrue(neighboors.Any(c=> c.X == 3 && c.Y == 2));
            Assert.IsTrue(neighboors.Any(c=> c.X == 3 && c.Y == 3));
            Assert.IsFalse(neighboors.Any(c=> c.X == 3 && c.Y == 4));

        }

    }
}
