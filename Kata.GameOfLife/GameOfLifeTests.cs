using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.GameOfLife
{
    [TestFixture]
    public class GameOfLifeTests
    {
        #region NewGeneration

        [TestFixture]
        public class NewGeneration
        {
            [Test]
            public void should_kill_alive_cells_with_fewer_than_two_alive_neighbors()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1));

                // ACT
                grid = grid.NewGeneration();

                // ASSERT
                grid.IsAlive(new Cell(1, 1)).Should().BeFalse();
            }

            [Test]
            public void should_keep_alive_cells_with_two_alive_neighbors()
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
            public void should_keep_alive_cells_with_three_alive_neighbors()
            {
                // ARRANGE
                var grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(2, 2), new Cell(3, 1));

                // ACT
                grid = grid.NewGeneration();

                // ASSERT
                grid.IsAlive(new Cell(1, 1)).Should().BeTrue();
                grid.IsAlive(new Cell(2, 1)).Should().BeTrue();
                grid.IsAlive(new Cell(2, 2)).Should().BeTrue();
                grid.IsAlive(new Cell(3, 1)).Should().BeTrue();
            }

            [Test]
            public void should_avive_cells_with_three_alive_neighbors()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));

                // ACT
                grid = grid.NewGeneration();

                // ASSERT
                grid.IsAlive(new Cell(2, 2)).Should().BeTrue();
            }

            [Test]
            public void should_kill_alive_cells_with_four_alive_neigbors()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1), new Cell(2, 2), new Cell(3, 2));

                // ACT
                grid = grid.NewGeneration();

                // ASSERT
                grid.IsAlive(new Cell(2, 2)).Should().BeFalse();
            }

        }

        #endregion

        #region GetDeadNeighborsOf

        [TestFixture]
        public class GetDeadNeighborsOf
        {
            [Test]
            public void should_return_all_dead_neighbors_for_the_given_cell()
            {
                // ARRANGE
                var grid = new Grid(new Cell(1, 2), new Cell(2, 2));

                // ACT
                IEnumerable<Cell> deadNeighbors = grid.GetDeadNeighborsOf(new Cell(2, 2));

                // ASSERT
                deadNeighbors.Should().NotBeNull();
                deadNeighbors.Count().ShouldBeEquivalentTo(7);

            }
        }

        #endregion


        #region GetNumberOfAliveNeighbors

        [TestFixture]
        public class GetNumberOfAliveNeighbors
        {
            [Test]
            public void should_return_zero_when_cell_doesnt_have_alive_neigbor()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1));

                // ACT
                int numberOfAliveNeighbors = grid.GetNumberOfAliveNeigborsOf(new Cell(1, 1));

                // ASSERT
                numberOfAliveNeighbors.ShouldBeEquivalentTo(0);
            }

            [Test]
            public void should_return_one_when_cell_have_one_alive_neigbors()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1));

                // ACT
                var numberOfAliveNeighbors = grid.GetNumberOfAliveNeigborsOf(new Cell(1, 1));

                // ASSERT
                numberOfAliveNeighbors.ShouldBeEquivalentTo(1);
            }

            [Test]
            public void should_return_one_when_cell_have_two_alive_neigbors()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));

                // ACT
                var numberOfAliveNeighbors = grid.GetNumberOfAliveNeigborsOf(new Cell(2, 1));

                // ASSERT
                numberOfAliveNeighbors.ShouldBeEquivalentTo(2);
            }

        }

        #endregion


        #region GetNeighborsOf

        [TestFixture]
        public class GetNeighborsOf
        {
            [Test]
            public void should_return_eight_cells_for_the_given_cell()
            {
                // ARRANGE
                Grid grid = new Grid();

                // ACT
                IEnumerable<Cell> neighbors = grid.GetNeighborsOf(new Cell(2, 2));

                // ASSERT
                neighbors.Should().NotBeNull();
                neighbors.Count().ShouldBeEquivalentTo(8);
            }
        }

        #endregion


        #region IsAlive

        [TestFixture]
        public class IsAlive
        {
            [Test]
            public void should_return_true_when_cell_isalive()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1));

                // ACT
                bool isAlive = grid.IsAlive(new Cell(1, 1));

                // ASSERT
                isAlive.Should().BeTrue();
            }

            [Test]
            public void should_return_false_when_cell_is_not_alive()
            {
                // ARRANGE
                Grid grid = new Grid(new Cell(1, 1));

                // ACT
                bool isAlive = grid.IsAlive(new Cell(2, 1));

                // ASSERT
                isAlive.Should().BeFalse();
            }
        }

        #endregion

    }
}