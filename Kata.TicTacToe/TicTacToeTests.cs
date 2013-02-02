using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.TicTacToe
{
    [TestFixture]
    public class TicTacToeTests
    {
        /*
		[SetUp]
		public void Init()
		{}

		[TearDown]
		public void Cleanup()
		{}*/

        [Test]
        public void MarkCell_when_the_cell_is_empty_it_should_return_true()
        {
            Game game = new Game();
            game.MarkCell(1, 1, 'x').Should().BeTrue();
        }

        [Test]
        public void MarkCell_when_cell_is_occupied_it_should_return_false()
        {
            Game game = new Game();
            game.MarkCell(1, 1, 'x');
            game.MarkCell(1, 1, 'o').Should().BeFalse("Cell is occupied by the other player");
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_occupied_by_player1_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(1, 0, Game.PLAYER1);
            game.MarkCell(2, 0, Game.PLAYER1);

            game.GetWinner().Should().Be(Game.PLAYER1);
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_occupied_by_player2_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, Game.PLAYER2);
            game.MarkCell(1, 0, Game.PLAYER2);
            game.MarkCell(2, 0, Game.PLAYER2);

            game.GetWinner().Should().Be(Game.PLAYER2);
        }
        
        [Test]
        public void GetWinner_when_all_cells_in_a_column_are_occupied_by_player2_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, Game.PLAYER2);
            game.MarkCell(0, 1, Game.PLAYER2);
            game.MarkCell(0, 2, Game.PLAYER2);

            game.GetWinner().Should().Be(Game.PLAYER2);
        }

        [Test]
        public void GetWinner_when_all_cells_in_diagonal1_are_occupied_by_player1_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(1, 1, Game.PLAYER1);
            game.MarkCell(2, 2, Game.PLAYER1);

            game.GetWinner().Should().Be(Game.PLAYER1);                
        }
        
        [Test]
        public void GetWinner_when_all_cells_in_diagonal2_are_occupied_by_player1_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 2, Game.PLAYER1);
            game.MarkCell(1, 1, Game.PLAYER1);
            game.MarkCell(2, 0, Game.PLAYER1);

            game.GetWinner().Should().Be(Game.PLAYER1);                
        }

        [Test]
        public void IsDraw_when_all_cells_are_occupied_and_no_rule_is_succeeded_it_should_should_return_true()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER2);
            game.MarkCell(1, 0, Game.PLAYER1);
            game.MarkCell(2, 0, Game.PLAYER1);
            game.MarkCell(0, 1, Game.PLAYER1);
            game.MarkCell(1, 1, Game.PLAYER2);
            game.MarkCell(2, 1, Game.PLAYER2);
            game.MarkCell(0, 2, Game.PLAYER2);
            game.MarkCell(1, 2, Game.PLAYER1);
            game.MarkCell(2, 2, Game.PLAYER1);

            game.IsDraw().Should().BeTrue();

        }





    }
}