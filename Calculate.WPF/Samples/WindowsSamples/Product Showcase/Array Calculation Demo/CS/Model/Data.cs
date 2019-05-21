#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using Syncfusion.Calculate;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ArrayICalcData
{
    public class Data : INotifyPropertyChanged
    {
        #region Constructor
        public Data()
        {

        }
        #endregion

        #region API Definition

        public int row = 0;
        public int col = 0;
        public int calcvalue = 123;
        public string result = string.Empty;

        public Random r = new Random();
        public ArrayCalcData data;
        public int nRows;
        public int nCols;

        #endregion

        #region Method

        /// <summary>
        /// Displays the ArrayCalcData values in a TextBox.
        /// </summary>
        public void ShowObject()
        {
            Result = "";
            for (int i = 0; i <= this.nRows + 1; ++i)
            {
                for (int j = 0; j <= this.nCols + 1; ++j)
                {
                    if (j == 0)
                    {
                        if (i == this.nRows + 1)
                            Result += "Sum" + "\t";
                        else
                            Result += "\t";
                        continue;
                    }
                    if (i == 0)
                    {
                        if (j == this.nCols + 1)
                            Result += "Sum";
                        else
                            Result += "\t";
                    }
                    else
                        Result += ArrayData[i - 1, j - 1].ToString() + "\t";
                }
                Result += "\r\n";
            }
        }

        private string GetIconFile(string bitmapName)
        {
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(bitmapName))
                    return bitmapName;

                bitmapName = @"..\" + bitmapName;
            }

            return bitmapName;
        }

        private void wait(double secs)
        {
            DateTime dt = DateTime.Now;
            while (((TimeSpan)(DateTime.Now - dt)).TotalSeconds < secs)
            {
                //Application.DoEvents();
            }
        }

        private void Set()
        {
            if (this.nRows == 0)
            {
                MessageBox.Show("Generate data first.");
                return;
            }
            try
            {
                int row = Row;
                int col = Col;
                string val = CalcValue.ToString();

                this.data[row, col] = val;

                ShowObject();
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

        private void Generate()
        {
            //create some sample data
            this.nRows = r.Next(10) + 2;
            this.nCols = r.Next(3) + 1;
            double[,] a = new double[nRows, nCols];//{{1.1,2.1},{3.1,4.1}};
            for (int row = 0; row < nRows; ++row)
                for (int col = 0; col < nCols; ++col)
                    a[row, col] = ((double)r.Next(100)) / 10;

            //create a ArrayCalcData object and pass it this array
            this.data = new ArrayCalcData(a);

            //create an CalcEngine object using this ArrayCalcData object
            CalcEngine engine = new CalcEngine(this.data);

            //Turn on dependency tracking so values set with the Set button
            //take effect immediately
            engine.UseDependencies = true;

            //call RecalculateRange so any formulas in the data can be initially computed.
            engine.RecalculateRange(RangeInfo.Cells(1, 1, nRows + 1, nCols + 1), data);

            ShowObject();
        }

        #endregion

        #region FindFile Utility
        /// <summary>
        /// Finds a file of the given name in the current directory or sibling "Data" directory.
        /// If file is not found, the parent folder is checked until the file is found. This method
        /// is used by our samples when they load data from a separate "Data" folder.
        /// </summary>
        /// <param name="dataDirName">The name of the "Data" folder.</param>
        /// <param name="fileName">The filename to be searched.</param>
        /// <returns>The full path of the file that was found; an empty string is returned if file is not found.</returns>

        public static string FindFile(string dataDirName, string fileName)
        {
            dataDirName = dataDirName.TrimEnd('\\', '/');
            // Check both in parent folder and Parent\Data folders.
            string dataFileName = dataDirName + "\\" + fileName;
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(fileName))
                {
                    return fileName;
                }
                if (System.IO.File.Exists(dataFileName))
                {
                    return dataFileName;
                }
                fileName = @"..\" + fileName;
                dataFileName = @"..\" + dataFileName;
            }

            return "";
        }
        #endregion

        #region Properties

        public int Row
        {
            get { return row; }
            set
            {
                row = value;
                OnpropertyChanged("Row");
            }

        }
        public int Col
        {
            get { return col; }
            set
            {
                col = value;
                OnpropertyChanged("Col");
            }

        }
        public int CalcValue
        {
            get { return calcvalue; }
            set
            {
                calcvalue = value;
                OnpropertyChanged("Value");
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnpropertyChanged("Result");
            }
        }

        public int NRows
        {
            get { return nRows; }
            set
            {
                nRows = value;
                OnpropertyChanged("NRows");
            }
        }

        public int NCols
        {
            get { return nCols; }
            set
            {
                nCols = value;
                OnpropertyChanged("NCols");
            }
        }

        public ArrayCalcData ArrayData
        {
            get { return data; }
            set
            {
                data = value;
                OnpropertyChanged("Data");
            }
        }
       

        private ICommand Gencmd;
        public ICommand GenCommand
        {
            get
            {
                if (Gencmd == null)
                    Gencmd = new Gencmd(this);
                return Gencmd;
            }
            set
            {
                Gencmd = value;
            }
        }

        private ICommand Setcmd;
        public ICommand SetCommand
        {
            get
            {
                if (Setcmd == null)
                    Setcmd = new Setcmd(this);
                return Setcmd;
            }
            set
            {
                Setcmd = value;
            }
        }

        #endregion

        #region INotifyPropertyChanged Contents

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnpropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion
    }

}

    

