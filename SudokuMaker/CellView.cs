namespace SudokuMaker
{
    public class CellView
    {
        public int value;
        public int x;
        public int y;

        public CellView(int value, int y, int x)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }

        public int Value { get { return value; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }
    }
}
