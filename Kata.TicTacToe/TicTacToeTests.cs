using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.TicTacToe
{
    [TestFixture]
    public class TicTacToeTests
    {
        private const string PLAYER2 = "o";
        private const string PLAYER1 = "x";
        private string[,] _cells;

        [Test]
        public void MarkCell_when_a_cell_is_empty_it_should_return_true()
        {
            _cells = GenerateWorld();
            SetCell(1, 1, PLAYER1).Should().BeTrue();
        }

        [Test]
        public void MarkCell_when_a_cell_is_occupied_it_should_return_false()
        {
            _cells = GenerateWorld();

            SetCell(1, 1, PLAYER1);
            SetCell(1, 1, PLAYER2).Should().BeFalse();
        }

        [Test]
        public void GetWinner_when_a_cells_in_a_row_are_occupied_by_player1_he_should_be_the_winner()
        {
            _cells = GenerateWorld();

            SetCell(0, 0, PLAYER1);
            SetCell(1, 0, PLAYER1);
            SetCell(2, 0, PLAYER1);

            GetWinner().Should().Be(PLAYER1);
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_row_are_occupied_by_player2_he_should_be_the_winner()
        {
            _cells = GenerateWorld();

            SetCell(0, 0, PLAYER2);
            SetCell(1, 0, PLAYER2);
            SetCell(2, 0, PLAYER2);

            GetWinner().Should().Be(PLAYER2);
        }

        [Test]
        public void GetWinner_when_all_cells_in_a_column_are_occupied_by_player2_he_should_be_the_winner()
        {
            _cells = GenerateWorld();

            SetCell(1, 0, PLAYER2);
            SetCell(1, 1, PLAYER2);
            SetCell(1, 2, PLAYER2);

            GetWinner().Should().Be(PLAYER2);
        }
        
        [Test]
        public void GetWinner_when_all_cells_in_diagonal1_are_occupied_by_player2_he_should_be_the_winner()
        {
            _cells = GenerateWorld();

            SetCell(0, 0, PLAYER2);
            SetCell(1, 1, PLAYER2);
            SetCell(2, 2, PLAYER2);

            GetWinner().Should().Be(PLAYER2);
        }

        [Test]
        public void GetWinner_when_all_cells_in_diagonal2_are_occupied_by_player2_he_should_be_the_winner()
        {
            _cells = GenerateWorld();

            SetCell(0, 2, PLAYER2);
            SetCell(1, 1, PLAYER2);
            SetCell(2, 0, PLAYER2);

            GetWinner().Should().Be(PLAYER2);
        }

        [Test]
        public void GetWinner_when_no_rule_is_succeeded_it_should_be_return_no_winner()
        {
            _cells = GenerateWorld();

            SetCell(0, 2, PLAYER2);
            SetCell(1, 1, PLAYER2);

            GetWinner().Should().BeNull();
        }

        [Test]
        public void IsDraw_When_all_cells_are_occupied_and_no_rule_is_succeeded_it_should_return_true()
        {
            _cells = GenerateWorld();

            SetCell(0, 0, PLAYER1);
            SetCell(1, 0, PLAYER2);
            SetCell(2, 0, PLAYER2);
            SetCell(0, 1, PLAYER2);
            SetCell(1, 1, PLAYER1);
            SetCell(2, 1, PLAYER1);
            SetCell(0, 2, PLAYER1);
            SetCell(1, 2, PLAYER2);
            SetCell(2, 2, PLAYER2);
            
            IsDraw().Should().BeTrue();
        }
        
        [Test]
        public void IsDraw_When_all_cells_are_occupied_and_no_rule_is_succeeded_it_should_return_false()
        {
            _cells = GenerateWorld();

            //SetCell(0, 0, PLAYER1);
            SetCell(1, 0, PLAYER2);
            SetCell(2, 0, PLAYER2);
            SetCell(0, 1, PLAYER2);
            SetCell(1, 1, PLAYER1);
            SetCell(2, 1, PLAYER1);
            SetCell(0, 2, PLAYER1);
            SetCell(1, 2, PLAYER2);
            SetCell(2, 2, PLAYER2);
            
            IsDraw().Should().BeFalse();
        }

        [Test]
        public void IsDraw_when_not_all_cells_are_fills_and_a_rule_is_succeed_it_should_return_false()
        {
            _cells = GenerateWorld();

            SetCell(0, 2, PLAYER2);
            SetCell(1, 1, PLAYER2);
            SetCell(2, 0, PLAYER2);

            IsDraw().Should().BeFalse();
        }

        private bool IsDraw()
        {
            foreach (string cell in _cells)
            {
                if (cell == null)
                    return false;
            }
            return true;
        }

        private string GetWinner()
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (string cell in _cells)
            {
                if (cell == null)
                    continue;

               
                if (count.ContainsKey(cell))
                {
                    int value = count[cell];
                    count[cell] = value + 1;
                }
                else
                {
                    count.Add(cell,  1);
                    
                }
            }

            if (count.Select(x=>x.Value).Sum() < 3)
            {
                return null;
            }

            return count.OrderBy(x => x.Value).First().Key;
        }

        private bool SetCell(int x, int y, string player)
        {
            if (_cells[x, y] != null)
            {
                return false;
            }
            _cells[x, y] = player;
            return true;
        }

        private static string[,] GenerateWorld()
        {
            return new string[3, 3];
        }

        private bool CheckRows(string player)
        {
            return Enumerable.Range(0, 3).Any(y => Enumerable.Range(0, 3).All(x => _cells[x, y] == player));
        }
    }
}