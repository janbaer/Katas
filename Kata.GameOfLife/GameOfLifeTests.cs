using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

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
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2));

            // ACT
            grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(1, 2)).Should().BeFalse();

        }

        /// <summary></summary>
        [Test]
        public void new_generation_should_letalive_cell_with_two_living_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2), new Cell(1, 3));

            // ACT
            grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(1, 2)).Should().BeTrue();

        }
        
        /// <summary></summary>
        [Test]
        public void new_generation_should_letalive_cell_with_three_living_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2), new Cell(1, 3), new Cell(2, 2));

            // ACT
            grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(1,2)).Should().BeTrue();

        }

        /// <summary></summary>
        [Test]
        public void new_generation_should_kill_cell_with_more_than_three_live_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2), new Cell(1, 3), new Cell(2, 1), new Cell(2, 2));

            // ACT
            grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(2, 2)).Should().BeFalse();
        }

        /// <summary></summary>
        [Test]
        public void new_generation_should_revive_dead_cell_with_three_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(1, 2), new Cell(1, 3));

            // ACT
            grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(2, 2)).Should().BeTrue();
            grid.IsAlive(new Cell(2, 1)).Should().BeFalse();
            grid.IsAlive(new Cell(2, 3)).Should().BeFalse();

        }
    }
}
