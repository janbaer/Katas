using System;
using System.Collections.Generic;
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

            game.GetWinner().ShouldBeEquivalentTo(Game.NO_WINNER);
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_marked_from_one_player1_it_should_return_player1()
        {
            Game game = new Game();

            FillRow(game, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER1);            
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_marked_from_one_player2_it_should_return_player2()
        {
            Game game = new Game();

            FillRow(game, Game.PLAYER2);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER2);            
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_column_are_marked_from_one_player1_it_should_return_player1()
        {
            Game game = new Game();

            FillColumn(game, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER1);
        }

        [Test]
        public void GetWinner_when_all_cells_in_the_diagonal1_are_marked_from_one_player1_it_should_return_player1()
        {
            Game game = new Game();

            BuildDiagonal1(game, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER1);
        }

        [Test]
        public void GetWinner_when_all_cells_in_the_diagonal2_are_marked_from_one_player1_it_should_return_player1()
        {
            Game game = new Game();

            BuildDiagonal2(game, Game.PLAYER1);

            game.GetWinner().ShouldBeEquivalentTo(Game.PLAYER1);
        }

        [Test]
        public void IsDraw_when_all_cells_are_marked_and_no_rule_is_succeeded_it_should_return_true()
        {
            Game game = new Game();

            BuildADraw(game);

            game.IsDraw().Should().BeTrue();

        }

        [Test]
        public void IsGameOver_when_we_have_a_winner_then_it_should_return_true() 
        {
            Game game = new Game();
    
            FillRow(game, Game.PLAYER1);

            Assert.IsTrue(game.IsGameOver());
        }

        [Test]
        public void IsGameOver_when_IsDraw_it_should_return_true()
        {
            Game game = new Game();

            BuildADraw(game);

            Assert.IsTrue(game.IsGameOver());
        }
        
        [Test]
        public void IsGameOver_when_norule_is_succeeded_and_is_not_a_draw_it_should_return_false()
        {
            Game game = new Game();

            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(0, 1, Game.PLAYER1);

            Assert.IsFalse(game.IsGameOver());
        }

        private void BuildADraw(Game game)
        {
            game.MarkCell(0, 0, Game.PLAYER1);
            game.MarkCell(1, 0, Game.PLAYER2);
            game.MarkCell(2, 0, Game.PLAYER2);
            game.MarkCell(0, 1, Game.PLAYER2);
            game.MarkCell(1, 1, Game.PLAYER1);
            game.MarkCell(2, 1, Game.PLAYER1);
            game.MarkCell(0, 2, Game.PLAYER1);
            game.MarkCell(1, 2, Game.PLAYER2);
            game.MarkCell(2, 2, Game.PLAYER2);
        }

        private void FillColumn(Game game, char player)
        {
            game.MarkCell(0, 0, player);
            game.MarkCell(0, 1, player);
            game.MarkCell(0, 2, player);
        }

        private void FillRow(Game game, char player)
        {
            game.MarkCell(0, 0, player);
            game.MarkCell(1, 0, player);
            game.MarkCell(2, 0, player);
        }

        private static void BuildDiagonal2(Game game, char player)
        {
            game.MarkCell(0, 2, player);
            game.MarkCell(1, 1, player);
            game.MarkCell(2, 0, player);
        }

        private void BuildDiagonal1(Game game, char player)
        {
            game.MarkCell(0, 0, player);
            game.MarkCell(1, 1, player);
            game.MarkCell(2, 2, player);
        }
    }
}
