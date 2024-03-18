namespace SudokuMaker
{
    public class Row
    {
        public readonly Cell[] Values;

        public Row(Cell[] values) =>
            Values = values;
    }
}
