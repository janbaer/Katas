namespace Kata.GameOfLife
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", X, Y);
        }


    }
}