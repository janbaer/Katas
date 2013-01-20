using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.GameOfLife
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void IsAlive_when_cell_is_in_the_list_of_alive_cells_it_should_return_true()
        {
            Grid grid = new Grid(new Cell(1, 1));
            bool isAlive = grid.IsAlive(1, 1);

            isAlive.Should().BeTrue();
        }

        [Test]
        public void IsAlive_when_cell_is_not_in_the_list_of_alive_cells_it_should_return_false()
        {
            Grid grid = new Grid(new Cell(1, 1));
            bool isAlive = grid.IsAlive(1, 2);

            isAlive.Should().BeFalse();            
        }

        [Test]
        public void NewGeneration_when_cell_has_fewer_than_two_alive_neighbors_it_should_kill_the_cell()
        {
            Grid grid = new Grid(new Cell(1, 1), new Cell(1, 2));

            grid = grid.NewGeneration();

            grid.IsAlive(1, 2).Should().BeFalse();
        }

        [Test]
        public void NewGeneration_when_cell_has_two_alive_neighbors_it_should_keep_alive()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3));
            grid = grid.NewGeneration();

            grid.IsAlive(1, 2).Should().BeTrue();
        }
        
        [Test]
        public void NewGeneration_when_cell_has_three_alive_neighbors_it_should_keep_alive()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2, 2));
            grid = grid.NewGeneration();

            grid.IsAlive(1, 2).Should().BeTrue();
        }

        [Test]
        public void NewGeneration_when_a_dead_cell_has_three_alive_neighbors_it_should_revive()
        {
            Grid grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3));
            grid = grid.NewGeneration();
            grid.IsAlive(2, 2).Should().BeTrue();
        }
    }
}