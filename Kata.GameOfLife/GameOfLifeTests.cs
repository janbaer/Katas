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
        public void new_generation_cells_with_fewer_than_two_alive_neighbors_should_die()
        {
            // ARRANGE
            Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1)));
            Assert.IsFalse(grid.IsAlive(new Cell(2, 1)));
        }

        [Test]
        public void new_generation_cells_with_2_alive_neighbors_should_survive()
        {
            // ARRANGE
            Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(1, 1)));
            Assert.IsTrue(grid.IsAlive(new Cell(2, 1)));
            Assert.IsFalse(grid.IsAlive(new Cell(3, 1)));
        }

        [Test]
        public void new_generation_cells_with_more_than_three_alive_neighbors_should_die()
        {
            // ARRANGE
            Grid grid = new Grid(new Cell(1, 1), new Cell(1,2), new Cell(2, 1), new Cell(2,2), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsFalse(grid.IsAlive(new Cell(2, 2)));

        }


        
        [Test]
        public void new_generation_cells_with_3_alive_neighbors_should_survive()
        {
            // ARRANGE
            Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(2,2), new Cell(3, 1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsTrue(grid.IsAlive(new Cell(1, 1)));
            Assert.IsTrue(grid.IsAlive(new Cell(2, 1)));
            Assert.IsTrue(grid.IsAlive(new Cell(2, 2)));
            Assert.IsTrue(grid.IsAlive(new Cell(3, 1)));
        }

        [Test]
        public void new_generation_should_avive_dead_cells_with_three_alive_neigbors()
        {
            // ARRANGE
            Grid grid = new Grid(new Cell(1,1), new Cell(2,1), new Cell(3,1));

            // ACT
            grid = grid.NewGeneration();

            // ASSERT
            Assert.IsTrue(grid.IsAlive(new Cell(2,2)));
            //Assert.IsTrue(grid.IsAlive(new Cell(2,0)));

        }

        [Test]
        public void getneighborsof_should_return_eight_neigbors()
        {
            // ARRANGE
            Grid grid = new Grid();

            // ACT
            var neighbors = grid.GetNeighborsOf(new Cell(2, 2));

            // ASSERT
            Assert.AreEqual(8, neighbors.Count());
        }
    }
}
