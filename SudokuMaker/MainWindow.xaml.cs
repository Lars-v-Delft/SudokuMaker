using System.Windows;

namespace SudokuMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            Sudoku sudoku = new Sudoku();

            DataContext = sudoku;
        }
    }
}
