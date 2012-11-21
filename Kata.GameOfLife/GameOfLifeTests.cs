using System;
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
        [Test]
        public void NewGeneration_should_kill_alive_cells_with_fewer_than_two_live_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(1,1)));
            Assert.IsFalse(grid.IsAlive(new Cell(1,2)));

        }

        [Test]
        public void NewGeneration_should_keep_alive_cells_with_two_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(1,1)));
            Assert.IsTrue(grid.IsAlive(new Cell(2,1)));
            Assert.IsFalse(grid.IsAlive(new Cell(3, 1)));
        }
        
        [Test]
        public void NewGeneration_should_keep_alive_cells_with_three_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 2), new Cell(2, 1), new Cell(2, 2), new Cell(3, 2));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsTrue(grid.IsAlive(new Cell(2, 2)));
        }

        [Test]
        public void NewGeneration_should_revive_dead_cells_with_three_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 2), new Cell(2, 1), new Cell(3, 2));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsTrue(grid.IsAlive(new Cell(2, 2)));

        }

        [Test]
        public void GetNeighboorsOfTest()
        {
            // ARRANGE
            var grid = new Grid(new Cell(2, 2));

            // ACT
            var neighboors = grid.GetNeighboorsOf(new Cell(2, 2));

            // ASSERT
            Assert.IsTrue(neighboors.Any(c=> c.X == 1 && c.Y == 1));
            Assert.IsTrue(neighboors.Any(c=> c.X == 1 && c.Y == 2));
            Assert.IsTrue(neighboors.Any(c=> c.X == 1 && c.Y == 3));
            Assert.IsTrue(neighboors.Any(c=> c.X == 2 && c.Y == 1));
            Assert.IsTrue(neighboors.Any(c=> c.X == 2 && c.Y == 3));
            Assert.IsTrue(neighboors.Any(c=> c.X == 3 && c.Y == 1));
            Assert.IsTrue(neighboors.Any(c=> c.X == 3 && c.Y == 2));
            Assert.IsTrue(neighboors.Any(c=> c.X == 3 && c.Y == 3));

        }

    }
}
