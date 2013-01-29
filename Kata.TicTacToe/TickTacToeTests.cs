using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.TicTacToe
{
    [TestFixture]
    public class TickTacToeTests
    {
        [Test]
        public void MarkCell_when_cell_is_empty_it_should_return_true()
        {
            Game game = new Game();
            game.MarkCell(1, 1, 'x').Should().BeTrue();
        }

        [Test]
        public void MarkCell_when_cell_is_not_empty_it_should_return_false()
        {
            Game game = new Game();
            game.MarkCell(0, 1, 'x');
            game.MarkCell(0, 1, 'o').Should().BeFalse();
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_marked_from_player_x_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, 'x');
            game.MarkCell(1, 0, 'x');
            game.MarkCell(2, 0, 'x');

            game.GetWinner().Should().Be('x');
        }
        
        [Test]
        public void GetWinner_when_all_cells_in_a_column_are_marked_from_player_x_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, 'x');
            game.MarkCell(0, 1, 'x');
            game.MarkCell(0, 2, 'x');

            game.GetWinner().Should().Be('x');
        }
        
        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_marked_from_player_o_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, 'o');
            game.MarkCell(1, 0, 'o');
            game.MarkCell(2, 0, 'o');

            game.GetWinner().Should().Be('o');
        }
        
        [Test]
        public void GetWinner_when_all_cells_in_diagonal1_are_marked_from_player_o_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, 'o');
            game.MarkCell(1, 1, 'o');
            game.MarkCell(2, 2, 'o');

            game.GetWinner().Should().Be('o');
        }

        [Test]
        public void GetWinner_when_all_cells_in_diagonal2_are_marked_from_player_o_it_should_be_the_winner()
        {
            Game game = new Game();
            game.MarkCell(0, 2, 'o');
            game.MarkCell(1, 1, 'o');
            game.MarkCell(0, 2, 'o');

            game.GetWinner().Should().Be('o');
        }
        
        [Test]
        public void IsDraw_when_all_cells_are_marked_and_we_have_no_rule_succeeded  ()
        {
            Game game = new Game();
            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(1, 0, Game.PLAYER2);
            game.MarkCell(2, 0, Game.PLAYER2);
            game.MarkCell(0, 1, Game.PLAYER2);
            game.MarkCell(1, 1, Game.PLAYER1);
            game.MarkCell(2, 1, Game.PLAYER1);
            game.MarkCell(0, 2, Game.PLAYER1);
            game.MarkCell(1, 2, Game.PLAYER2);
            game.MarkCell(2, 2, Game.PLAYER2);

            game.IsDraw().Should().BeTrue();
        }


    }
}