using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.TicTacToe
{
    [TestFixture]
    public class TicTacTests
    {
        public const char NO_WINNER = '\0';
//        [Test]
//        public void An_NewGame_Should_Has_Only_EmptyFields()
//        {
//            // ARRANGE
//            var grid = new Grid();
//
//            // ACT
//            int countOfEmptyCells = grid.Cells.Count(c => c.IsEmpty);
//
//            // ASSERT  
//            Assert.AreEqual(9, countOfEmptyCells);
//        }

        [Test]
        public void setmarked_when_cell_is_empty_it_should_return_true()
        {
            var grid = new Grid();

            grid.SetMarked(0, 0, 'o').Should().BeTrue();
        }

        [Test]
        public void setmarked_when_cell_is_not_empty_it_should_return_false()
        {
            var grid = new Grid();

            grid.SetMarked(0, 0, 'o').Should();

            grid.SetMarked(0, 0, 'x').Should().BeFalse();
        }

        [Test]
        public void getwinner_when_all_cells_in_a_row_are_marked_it_should_return_the_winner()
        {
            var grid = new Grid();

            grid.SetMarked(0, 0, 'o');
            grid.SetMarked(1, 0, 'o');
            grid.SetMarked(2, 0, 'o');

            Assert.AreEqual('o', grid.GetWinner());
        }
        
        [Test]
        public void getwinner_when_all_cells_in_a_column_are_marked_it_should_return_the_winner()
        {
            var grid = new Grid();

            grid.SetMarked(0, 0, 'o');
            grid.SetMarked(0, 1, 'o');
            grid.SetMarked(0, 2, 'o');

            grid.GetWinner().ShouldBeEquivalentTo('o');
        }
        
        [Test]
        public void getwinner_when_all_cells_in_thediagonal_are_marked_it_should_return_the_winner()
        {
            var grid = new Grid();

            grid.SetMarked(0, 0, 'o');
            grid.SetMarked(1, 1, 'o');
            grid.SetMarked(2, 2, 'o');

            grid.GetWinner().ShouldBeEquivalentTo('o');
        }

        [Test]
        public void getwinner_when_no_cells_are_marked_it_should_return_empty()
        {
            var grid = new Grid();

            grid.GetWinner().ShouldBeEquivalentTo(NO_WINNER);


        }

        [Test]
        public void getwinner_when_just_two_cells_are_marked_it_should_return_empty()
        {
            var grid = new Grid();

            grid.SetMarked(0, 0, 'o');
            grid.SetMarked(1, 0, 'o');

            grid.GetWinner().ShouldBeEquivalentTo(NO_WINNER);            
        }

        [Test]
        public void IsDraw_when_all_cells_are_marked_and_there_is_now_winner_it_should_return_true()
        {
            var grid = new Grid();

            grid.SetMarked(0, 0, 'o');
            grid.SetMarked(0, 1, 'x');
            grid.SetMarked(0, 2, 'x');
            grid.SetMarked(1, 0, 'x');
            grid.SetMarked(1, 1, 'o');
            grid.SetMarked(1, 2, 'o');
            grid.SetMarked(2, 0, 'o');
            grid.SetMarked(2, 1, 'x');
            grid.SetMarked(2, 2, 'x');

            grid.IsDraw().Should().BeTrue();
        }



    }
}
