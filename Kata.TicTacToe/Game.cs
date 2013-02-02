using System.Collections.Generic;
using System.Linq;

namespace Kata.TicTacToe
{
    public class Game
    {
        private const char EMPTY_CELL = '\0';
        public const char PLAYER1 = 'x';
        public const char PLAYER2 = 'o';

        private readonly int[,] _cells = new int[3, 3];

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
            IEnumerable<char> players = new List<char>() {PLAYER1, PLAYER2};

            return players.FirstOrDefault(player => CheckRows(player) || CheckColumns(player) || CheckDiagonals(player));
        }

        private bool CheckDiagonals(char player)
        {
            return CheckDiagonal1(player) || CheckDiagonal2(player);
        }

        private bool CheckDiagonal2(char player)
        {
            if (_cells[0, 2] == player && _cells[1, 1] == player && _cells[2, 0] == player)
            {
                return true;
            }
            return false;
        }

        private bool CheckDiagonal1(char player)
        {
            if (_cells[0, 0] == player && _cells[1, 1] == player && _cells[2, 2] == player)
            {
                return true;
            }
            return false;
        }

        private bool CheckColumns(char player)
        {
            if (Enumerable.Range(0, 3).Any(x => Enumerable.Range(0, 3).All(y => _cells[x, y] == player)))
            {
                return true;
            }
            return false;
        }

        private bool CheckRows(char player)
        {
            if (Enumerable.Range(0, 3).Any(y => Enumerable.Range(0, 3).All(x => _cells[x, y] == player)))
            {
                return true;
            }
            return false;
        }


        public bool IsDraw()
        {
            foreach (var cell in _cells)
            {
                if (cell == EMPTY_CELL)
                {
                    return false;
                }
            }

            return GetWinner() == '\0';
        }
    }
}