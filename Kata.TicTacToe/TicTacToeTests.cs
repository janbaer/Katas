using System;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.TicTacToe
{
    [TestFixture]
    class TicTacToeTests
    {
        [Test]
        public void MarkCell_when_cell_is_empty_it_should_return_true()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER1).Should().BeTrue();

        }

        [Test]
        public void MarkCell_when_cell_is_not_empty_it_should_return_false()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(0, 0, Game.PLAYER2).Should().BeFalse();
        }

        [Test]
        public void GetWinner_when_no_rule_is_succeeded_it_should_return_nowinner()
        {
            Game game = new Game();
            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(1, 0, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.NOWINNER);
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_marked_from_player1_it_should_return_player1()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(1, 0, Game.PLAYER1);
            game.MarkCell(2, 0, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER1);
        }
        
        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_marked_from_player2_it_should_return_player2()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER2);
            game.MarkCell(1, 0, Game.PLAYER2);
            game.MarkCell(2, 0, Game.PLAYER2);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER2);
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_column_are_marked_from_player1_it_should_return_player1()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(0, 1, Game.PLAYER1);
            game.MarkCell(0, 2, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER1);
        }

        [Test]
        public void GetWinner_when_all_cells_in_the_diagonal_are_marked_from_player1_it_should_return_player1()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(1, 1, Game.PLAYER1);
            game.MarkCell(2, 2, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER1);
        }

        [Test]
        public void IsDraw_When_all_cells_are_marked_and_no_rule_is_succeeded_then_it_should_return_true()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(0, 1, Game.PLAYER2);
            game.MarkCell(0, 2, Game.PLAYER2);
            game.MarkCell(1, 0, Game.PLAYER2);
            game.MarkCell(1, 1, Game.PLAYER1);
            game.MarkCell(1, 2, Game.PLAYER1);
            game.MarkCell(2, 0, Game.PLAYER1);
            game.MarkCell(2, 1, Game.PLAYER2);
            game.MarkCell(2, 2, Game.PLAYER2);

            game.IsDraw().Should().BeTrue();
        }
    }
}
