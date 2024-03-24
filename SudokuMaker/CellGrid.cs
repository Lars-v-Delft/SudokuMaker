using System.Collections.Generic;

namespace SudokuMaker
{
    public class CellGrid
    {
        public Cell[,] Cells;

        public CellGrid(Cell[,] cells) =>
            Cells = cells;

        public List<Cell> InvalidCells
        {
            get
            {
                List<Cell> invalidCells = new List<Cell>();
                // who knew foreach worked with 2d-arrays, i guess you can abstract this method out then
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