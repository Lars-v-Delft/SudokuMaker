using System.Collections.Generic;
using System.Linq;

namespace SudokuMaker
{
    public class Sudoku
    {
        private Board board;

        public Sudoku()
        {
            board = new Board();
            FillBoard();
        }

        private void FillBoard()
        {
            Cell emptyCell = getNextEmptyCell();
            int iteration = 0;
            List<Cell> lastSet = new List<Cell>(); // avoid loop where the same cells keep getting reset to the same values
            while (emptyCell != null && iteration < 1000)
            {
                // find the value which results in the least amount of invalid cells
                KeyValuePair<int, List<Cell>> bestOption = new KeyValuePair<int, List<Cell>>();
                for (int i = 1; i <= Board.Size; i++)
                {
                    emptyCell.Value = i;
                    List<Cell> invalidCells = board.InvalidCells; // todo: optimize to check only cells relevant to changed cell
                    if (invalidCells.Any(ic => lastSet.Contains(ic))) // avoids loop of resetting same cells
                        continue;
                    if (bestOption.Key == default || invalidCells.Count < bestOption.Value.Count)
                        bestOption = new KeyValuePair<int, List<Cell>>(i, invalidCells);
                    if (bestOption.Value.Count == 0) // optimization
                        break;
                }
                // implement the best option
                foreach (Cell invalidCell in bestOption.Value) // reason why lastSet is needed
                    invalidCell.Value = default;
                emptyCell.Value = bestOption.Key;

                if (lastSet.Count == 2) // number of iterations where lastSet cells are safe from change
                    lastSet.RemoveAt(0);
                lastSet.Add(emptyCell);

                emptyCell = getNextEmptyCell();
                iteration++;
            }
        }

        private Cell getNextEmptyCell()
        {
            for (int r = 0; r < Board.Size; r++)
                for (int c = 0; c < Board.Size; c++)
                    if (board.Cells[r, c].Value == default)
                        return board.Cells[r, c];
            return null;
        }

        public List<List<int>> BoardList
        {
            get
            {
                List<List<int>> list = new List<List<int>>();
                for (int r = 0; r < Board.Size; r++)
                {
                    list.Add(new List<int>());
                    for (int c = 0; c < Board.Size; c++)
                        list[r].Add(board.Cells[r, c].Value);
                }
                return list;
            }
        }
    }
}
