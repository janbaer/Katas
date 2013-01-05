using System.Linq;

namespace Kata.TicTacToe
{
    public class Grid
    {
        private const char EMPTY_CELL = '\0';
        private readonly char[,] cells = new char[3,3];

        public Grid()
        {
            this.NewGame();
        }

        public void NewGame()
        {
            foreach (int x in Enumerable.Range(0,3))
            {
                foreach (int y in Enumerable.Range(0, 3))
                {
                    cells[x, y] = EMPTY_CELL;
                }
            }
        }


        public bool SetMarked(int x, int y, char player)
        {
            if (cells[x, y] == EMPTY_CELL)
            {
                cells[x, y] = player;
                return true;
            }

            return false;
        }

        public char GetWinner()
        {
            var players = new[] {'o', 'x'};

            return players.FirstOrDefault(player => TestRows(player) || TestColumns(player) || TestDiagonal(player));
        }

        private bool TestDiagonal(char player)
        {
            return cells[0, 0] == player && cells[1, 1] == player && cells[2, 2] == player;
        }

        private bool TestRows(char player)
        {
            return Enumerable.Range(0, 3).Any(y => Enumerable.Range(0, 3).All(x => cells[x, y] == player));
        }
        
        private bool TestColumns(char player)
        {
            return Enumerable.Range(0, 3).Any(x => Enumerable.Range(0, 3).All(y => cells[x, y] == player));
        }

        public bool IsDraw()
        {
            if (Enumerable.Range(0, 3).All(x => Enumerable.Range(0, 3).All(y => cells[x, y] != EMPTY_CELL)))
            {
                return GetWinner() == EMPTY_CELL;
            }

            return false;
        }
    }
}