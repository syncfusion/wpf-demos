using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace ArrayICalcData
{
    public class Setcmd : ICommand
    {
        private Data viewModel;

        #region Constructor
        public Setcmd(Data _viewModel)
        {
            viewModel = _viewModel;
        }
        #endregion

        #region Method

        public bool CanExecute(object parameter)
        {
            return true;
        }
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
        public void Execute(object parameter)
        {
            if (viewModel.NRows == 0)
            {
                MessageBox.Show("Generate data first.");
                return;
            }

            try
            {
                int row = viewModel.Row;
                int col = viewModel.Col;
                string val = viewModel.CalcValue.ToString();
                if (this.viewModel.nRows != row && this.viewModel.nCols != col)
                {
                    viewModel.data[row, col] = val;
                }
                else
                {
                    MessageBox.Show("Please enter a valid row and column index.\nThis field is belongs to Sum of the rows and columns");
                }

                viewModel.ShowObject();
            }
            catch (IndexOutOfRangeException ex1)
            {
                MessageBox.Show("Please enter a valid row and column index.\r\nException: " + ex1.Message);
            }
            catch (FormatException ex2)
            {
                MessageBox.Show("Please enter a valid row and column index.\r\nException: " + ex2.Message);
            }

        }

        #endregion
    }
}
