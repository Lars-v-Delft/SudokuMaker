namespace SudokuMaker
{
    public class Column
    {
        public readonly Cell[] Values;

        public Column(Cell[] values) =>
            Values = values;
    }
}
