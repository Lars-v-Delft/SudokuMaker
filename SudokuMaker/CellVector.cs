using System.Collections.Generic;

namespace SudokuMaker
{
    public class CellVector
    {
        public readonly Cell[] Cells;

        public CellVector(Cell[] cells) =>
            Cells = cells;

        public List<Cell> InvalidCells
        {
            get
            {
                List<Cell> invalidCells = new List<Cell>();
                foreach (Cell cell in Cells)
                    foreach (Cell cell1 in Cells)
                        if (cell.Value != default && cell != cell1 && cell.Value == cell1.Value)
                        {
                            invalidCells.Add(cell);
                            break;
                        }
                return invalidCells;
            }
        }
    }
}