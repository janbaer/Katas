using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.GameOfLife
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void IsAlive_when_cell_is_in_list_of_alive_cells_it_should_return_true()
        {
            Grid grid = new Grid(new Cell(1,1));

            grid.IsAlive(1, 1).Should().BeTrue();
        }        
        
        [Test]
        public void IsAlive_when_cell_is_not_in_list_of_alive_cells_it_should_return_false()
        {
            Grid grid = new Grid(new Cell(1,1));

            grid.IsAlive(1, 2).Should().BeFalse();
        }

        [Test]
        public void NewGeneration_a_cell_with_two_alive_neighbors_should_be_alive()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1, 3));
            grid = grid.NewGeneration();

            grid.IsAlive(1, 2).Should().BeTrue();
        }

        [Test]
        public void NewGeneration_a_cell_with_three_alive_neighbors_should_be_alive()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1, 3), new Cell(2,2));
            grid = grid.NewGeneration();

            grid.IsAlive(1, 2).Should().BeTrue();
        }

        [Test]
        public void NewGeneration_a_cell_with_fewer_than_two_alive_neighbors_should_die()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1,2));
            grid = grid.NewGeneration();

            grid.IsAlive(1, 2).Should().BeFalse();
        }
        
        [Test]
        public void NewGeneration_a_cell_with_more_than_three_alive_neighbors_should_die()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,1), new Cell(2,2));
            grid = grid.NewGeneration();

            grid.IsAlive(2, 2).Should().BeFalse();
        }

        [Test]
        public void NewGeneration_a_dead_cell_with_three_alive_neighbors_should_be_alive()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1, 2), new Cell(1,3));
            grid = grid.NewGeneration();
            grid.IsAlive(2, 2).Should().BeTrue();
        }
    }
}
