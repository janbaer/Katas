using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.GameOfLife
{
    [TestFixture]
    public class GameOfLifeTests
    {
        /*
		[SetUp]
		public void Init()
		{}

		[TearDown]
		public void Cleanup()
		{}*/

        [Test]
        public void IsAlive_when_cell_is_in_the_list_of_alive_cells_it_should_return_true()
        {
            Grid grid = new Grid(new Cell(1,1));
            grid.IsAlive(new Cell(1,1)).Should().Be(true);
        } 
        [Test]
        public void IsAlive_when_cell_is_not_in_the_list_of_alive_cells_it_should_return_false()
        {
            Grid grid = new Grid(new Cell(1,1));
            grid.IsAlive(new Cell(2,1)).Should().Be(false);
        }

        [Test]
        public void NewGeneration_when_cell_has_two_alive_neighbors_it_should_stay_alive()
        {
            Grid grid = new Grid(new Cell(1, 1), new Cell(2,1), new Cell(3,1));
            grid = grid.NewGeneration();
            grid.IsAlive(new Cell(2,1)).Should().Be(true);
        }

        [Test]
        public void NewGeneration_when_cell_has_three_alive_neighbors_it_should_stay_alive()
        {
            Grid grid = new Grid(new Cell(1, 1), new Cell(2,1), new Cell(3,1), new Cell(2,2));
            grid = grid.NewGeneration();
            grid.IsAlive(new Cell(2,2)).Should().Be(true);
        }

        [Test]
        public void NewGeneration_when_cell_has_fewer_than_two_alive_neighbors_it_should_die()
        {
            Grid grid = new Grid(new Cell(1, 1), new Cell(2,1));
            grid = grid.NewGeneration();
            grid.IsAlive(new Cell(2,1)).Should().Be(false);
        }
        
        [Test]
        public void NewGeneration_when_cell_has_more_than_three_alive_neighbors_it_should_die()
        {
            Grid grid = new Grid(new Cell(1, 1), new Cell(2,1), new Cell(2,2), new Cell(1,2));
            grid = grid.NewGeneration();
            grid.IsAlive(new Cell(2,2)).Should().Be(false);
        }

        [Test]
        public void NewGeneration_when_a_dead_cell_has_three_alive_neighbors_it_should_revive()
        {
            Grid grid = new Grid(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1));
            grid = grid.NewGeneration();
            grid.IsAlive(new Cell(2, 2)).Should().Be(true);
        }


    }
}