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
        [Test]
        public void new_generation_should_kill_alive_cells_with_fewer_than_two_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(1,1)));
        }

        [Test]
        public void new_generation_should_keep_alive_cells_with_two_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(2, 1)).Should().BeTrue();
        }
        
        [Test]
        public void new_generation_should_keep_alive_cells_with_three_alive_neighboors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(2,2), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            grid.IsAlive(new Cell(2, 2)).Should().BeTrue();
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
            grid.IsAlive(new Cell(1, 2)).Should().BeFalse();
        }

        [Test]
        public void get_neighbors_should_return_eight_neighboors()
        {
            // ARRANGE
            var grid = new Grid();

            IEnumerable<Cell> expectedCells = new List<Cell>()
                                                {
                                                    new Cell(1, 1), new Cell(2,1), new Cell(3,1), new Cell(1,2), new Cell(3,2), new Cell(1,3), new Cell(2,3), new Cell(3,3)
                                                };

            // ACT
            IEnumerable<Cell> neighbors = grid.GetNeighborsOf(new Cell(2, 2));

            // ASSERT
            neighbors.Should().NotBeNull();
            neighbors.Count().ShouldBeEquivalentTo(8);

            foreach (var cell in expectedCells)
            {
                neighbors.Any(n => n.X == cell.X && n.Y == cell.Y).Should().BeTrue();
            }
        }

        [Test]
        public void get_number_of_alive_neighboors_should_return_two()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1), new Cell(3, 1));

            // ACT
            int numberOfAliveNeighbors = grid.GetNumberOfAliveNeighborsOf(new Cell(2, 1));

            // ASSERT
            numberOfAliveNeighbors.ShouldBeEquivalentTo(2);
        }

        [Test]
        public void get_dead_neighbors_should_return_all_not_alive_neighbors()
        {
            // ARRANGE
            var grid = new Grid(new Cell(2, 2), new Cell(1, 2), new Cell(3, 2));
            IEnumerable<Cell> expectedCells = new List<Cell>()
                                                          {
                                                              new Cell(1,1), new Cell(2,1), new Cell(3,1), new Cell(1,3), new Cell(2,3), new Cell(3,3)
                                                          };

            // ACT
            IEnumerable<Cell> deadNeighboors = grid.GetDeadNeighboorsOf(new Cell(2, 2));

            // ASSERT
            deadNeighboors.Should().NotBeNull();
            deadNeighboors.Count().ShouldBeEquivalentTo(6);
            
            foreach (var cell in expectedCells)
            {
                deadNeighboors.Any(c => c.X == cell.X && c.Y == cell.Y).Should().BeTrue();
            }

        }

        [Test]
        public void when_a_cell_IsAlive_than_IsAlive_should_return_true()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1));

            // ACT
            var isAlive = grid.IsAlive(new Cell(1, 1));

            // ASSERT
            isAlive.Should().BeTrue();
        }
        
        [Test]
        public void when_a_cell_IsNotAlive_than_IsAlive_should_return_true()
        {
            // ARRANGE
            var grid = new Grid(new Cell(1, 1));

            // ACT
            var isAlive = grid.IsAlive(new Cell(1, 2));

            // ASSERT
            isAlive.Should().BeFalse();
        }

        #region Cell.Equals Tests

        [Test]
        public void when_cell_is_same_reference_equals_should_return_true()
        {
            // ARRANGE
            var cell = new Cell(1, 1);

            // ACT
            bool equals = cell.Equals(cell);

            // ASSERT
            equals.Should().BeTrue();
        }

        [Test]
        public void when_X_and_y_are_equal_than_equals_should_return_true()
        {
            // ARRANGE
            var cell1 = new Cell(1, 2);
            var cell2 = new Cell(1, 2);

            // ACT
            var equals = cell1.Equals(cell2);

            // ASSERT
            equals.Should().BeTrue();
        }

        [Test]
        public void when_X_and_y_are_not_equal_than_equals_should_return_false()
        {
            // ARRANGE
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 2);

            // ACT
            var equals = cell1.Equals(cell2);

            // ASSERT
            equals.Should().BeFalse();
        }

        #endregion


    }
}
