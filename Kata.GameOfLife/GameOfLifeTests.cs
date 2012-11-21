using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.GameOfLife
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void new_generation_should_kill_cells_with_fewer_than_two_alive_neighbors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1)));
            Assert.IsFalse(grid.IsAlive(new Cell(2, 1)));
        }

        [Test]
        public void new_generation_should_keep_cells_with_two_alive_neighbors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(1, 1)).Should().BeFalse();
            grid.IsAlive(new Cell(2, 1)).Should().BeTrue();
            grid.IsAlive(new Cell(3, 1)).Should().BeFalse();
        }

        [Test]
        public void new_generation_should_keep_cells_with_three_alive_neighbors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1), new Cell(2, 2));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(1, 1)).Should().BeTrue();
            grid.IsAlive(new Cell(2, 1)).Should().BeTrue();
            grid.IsAlive(new Cell(2, 2)).Should().BeTrue();
            grid.IsAlive(new Cell(3, 1)).Should().BeTrue();
        }

        [Test]
        public void new_generation_should_avive_dead_cells_with_three_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(2, 2)).Should().BeTrue();
        }

        [Test]
        public void GetNeighbors_should_return_eight_neighbors()
        {
            // ARRANGE
            var grid = new Grid();

            // ACT
            IEnumerable<Cell> neighbors = grid.GetNeigborsOf(new Cell(2, 2));

            // ASSERT
            Assert.IsNotNull(neighbors);
            Assert.AreEqual(8, neighbors.Count());
        }
    }
}