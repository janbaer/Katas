using System.Collections.Generic;
using System.Linq;

namespace Kata.TicTacToe
{
    public class Game
    {
        private const char EMPTY_CELL = '\0';
        public const char NO_WINNER = EMPTY_CELL;
        public const char PLAYER1 = 'x';
        public const char PLAYER2 = 'o';

        private readonly int[, ] _cells = new int[3,3];

        public bool MarkCell(int x, int y, char player)
        {
            if (_cells[x, y] != EMPTY_CELL)
            {
                return false;
            }

            _cells[x, y] = player;

            return true;
        }

        public char GetWinner()
        {
            IEnumerable<char> players = new[] {PLAYER1, PLAYER2};

            return players.FirstOrDefault(player => CheckRows(player) || CheckColumns(player) || CheckDiagonals(player));
        }

        private bool CheckDiagonals(char player)
        {
            return CheckDiagonal1(player) || CheckDiagonal2(player);
        }

        private bool CheckDiagonal1(char player)
        {
            return _cells[0, 0] == player && _cells[1, 1] == player && _cells[2, 2] == player;
        }

        private bool CheckDiagonal2(char player)
        {
            return _cells[0, 2] == player && _cells[1, 1] == player && _cells[2, 0] == player;
        }

        private bool CheckColumns(char player)
        {
            return Enumerable.Range(0, 3).Any(x => Enumerable.Range(0, 3).All(y => _cells[x, y] == player));
        }

        private bool CheckRows(char player)
        {
            return Enumerable.Range(0, 3).Any(y=> Enumerable.Range(0, 3).All(x=> _cells[x, y] == player));
        }

        public bool IsDraw()
        {
            return AllCellsAreMarked() && GetWinner() == NO_WINNER;
        }

        private bool AllCellsAreMarked()
        {
            return Enumerable.Range(0, 3).All(x=> Enumerable.Range(0, 3).All(y=> _cells[x, y] != EMPTY_CELL));
        }
    }
}