using System.Collections.Generic;
using System.Linq;

namespace SudokuMaker
{
    public class Board
    {
        public const int Size = 9;
        public Cell[,] Cells { get; set; }
        private readonly CellVector[] Rows;
        private readonly CellVector[] Columns;
        private readonly CellGrid[,] Grids;

        public Board()
        {
            Cells = new Cell[Size, Size];

            // init Board with cell instances
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    Cells[r, c] = new Cell();
            // set rows with same cell instances as board
            Rows = new CellVector[Size];
            for (int r = 0; r < Size; r++)
            {
                Cell[] rowValues = new Cell[Size];
                for (int c = 0; c < Size; c++)
                    rowValues[c] = Cells[r, c];
                Rows[r] = new CellVector(rowValues);
            }
            // set columns with same cell instances as board
            Columns = new CellVector[Size];
            for (int c = 0; c < Size; c++)
            {
                Cell[] columnValues = new Cell[Size];
                for (int r = 0; r < Size; r++)
                    columnValues[r] = Cells[r, c];
                Columns[c] = new CellVector(columnValues);
            }
            // set grids with same cell instances as board
            Grids = new CellGrid[3, 3];
            for (int gr = 0; gr < 3; gr++)
                for (int gc = 0; gc < 3; gc++)
                {
                    Cell[,] gridValues = new Cell[3, 3];
                    for (int r = 0; r < 3; r++)
                        for (int c = 0; c < 3; c++)
                            gridValues[r, c] = Cells[gr * 3 + r, gc * 3 + c];
                    Grids[gr, gc] = new CellGrid(gridValues);
                }
        }

        public List<Cell> InvalidCells
        {
            get
            {
                List<Cell> invalidCells = new List<Cell>();

                foreach (CellVector row in Rows)
                    invalidCells.AddRange(row.InvalidCells);
                foreach (CellVector column in Columns)
                    invalidCells.AddRange(column.InvalidCells);
                foreach (CellGrid grid in Grids)
                    invalidCells.AddRange(grid.InvalidCells);

                return invalidCells.Distinct().ToList();
            }
        }

    }
}

