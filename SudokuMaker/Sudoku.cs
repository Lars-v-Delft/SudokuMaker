using System;
using System.Collections.Generic;

namespace SudokuMaker
{
    public class Sudoku
    {
        private readonly int size;
        public Cell[,] Board { get; set; }
        private readonly Row[] Rows;
        private readonly Column[] Columns;

        public Sudoku(int size = 9)
        {
            this.size = size;
            Board = new Cell[size, size];

            // init Board with cell instances
            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    Board[r, c] = new Cell();
            // set rows with same cell instances as board
            Rows = new Row[size];
            for (int r = 0; r < size; r++)
            {
                Cell[] rowValues = new Cell[size];
                for (int c = 0; c < size; c++)
                    rowValues[c] = Board[r, c];
                Rows[r] = new Row(rowValues);
            }
            // set columns with same cell instances as board
            Columns = new Column[size];
            for (int c = 0; c < size; c++)
            {
                Cell[] columnValues = new Cell[size];
                for (int r = 0; r < size; r++)
                    columnValues[r] = Board[r, c];
                Columns[c] = new Column(columnValues);
            }
            InitializeTestData();
        }

        private void FillBoard()
        {

        }
        private void InitializeTestData()
        {
            Random rnd = new Random();
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Board[r, c].Value = rnd.Next(1, size);
                }
            }
        }

        public List<List<int>> BoardList
        {
            get
            {
                List<List<int>> list = new List<List<int>>();
                for (int r = 0; r < size; r++)
                {
                    list.Add(new List<int>());
                    for (int c = 0; c < size; c++)
                        list[r].Add(Board[r, c].Value);
                }
                return list;
            }
        }
    }
}
