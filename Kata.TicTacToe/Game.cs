using System.Collections.Generic;
using System.Linq;

namespace Kata.TicTacToe
{
    internal class Game
    {
        public const char PLAYER1 = 'o';
        public const char PLAYER2 = 'x';
        public const char NO_WINNER = '\0';
        private const char EMPTY_CELL = '\0';

        private readonly int[,] _cells = new int[3,3];
 
        public bool MarkCell(int x, int y, char player)
        {
            if (_cells[x, y] == EMPTY_CELL)
            {
                _cells[x, y] = player;
                return true;
            }
            return false;
        }

        public char GetWinner()
        {
            var players = new List<char>() {Game.PLAYER1, Game.PLAYER2};

            return players.FirstOrDefault(candidate => CheckRows(candidate) || CheckColumns(candidate) || CheckDiagonals(candidate));
        }

        public bool IsDraw()
        {
            if (Enumerable.Range(0, 3).All(x=> Enumerable.Range(0, 3).All(y=> _cells[x, y] != EMPTY_CELL)))
            {
                return GetWinner() == NO_WINNER;
            }
            return false;
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
            return Enumerable.Range(0, 3).Any(y => Enumerable.Range(0, 3).All(x => _cells[x, y] == player));
        }

        public bool IsGameOver()
        {
            return IsDraw() || (GetWinner() != Game.NO_WINNER);
        }
    }
}