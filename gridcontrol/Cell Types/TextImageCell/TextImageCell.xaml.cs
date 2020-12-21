#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Cells;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for TextImageCell.xaml
    /// </summary>
    public partial class TextImageCell : DemoControl
    {
        public TextImageCell()
        {
            InitializeComponent();
            this.InitGrid();
        }
        public TextImageCell(string themename) : base(themename)
        {
            InitializeComponent();
            this.InitGrid();
        }
        private void InitGrid()
        {
            this.grid.Model.RowCount = 30;
            this.grid.Model.ColumnCount = 25;

            string vectorImgSrcUri = @"pack://application:,,,/syncfusion.gridcontroldemos.wpf;component/Data/GridControl/Finance.xaml";
            // Using Vector Images.
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri(vectorImgSrcUri);

            ObservableCollection<Image> imgList = new ObservableCollection<Image>();
            string[] investments = new string[] { "Investment", "PersonalFinance", "Tax", "Insurance", "Stock", "Assets","Earnings", 
                "MutualFunds", "Budget", "Deposit", "CashBundle","Creditcards", "FinanceCheque" };

            // Loading ImageList.
            foreach (string key in investments)
            {
                Image img = new Image();
                img.Margin = new Thickness(2);
                img.Source = (DrawingImage)dictionary[key];
                imgList.Add(img);
            }

            grid.Model.TableStyle.ImageList = imgList;

            int row = 0, col = 1;
            grid.Model[row, col].Text = "Employee Name";
            grid.Model[row, col + 1].Text = "Investments";
            grid.Model[row, col + 2].Text = "Company Name";
            grid.Model[row, col + 1].Image = imgList.ElementAt(0);
            row++;
            grid.Model[row, col].Text = "Nancy";
            grid.Model[row, col + 1].Text = "Personal Finance";
            grid.Model[row, col + 2].Text = "Alfreds Futterkiste";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Bill";
            grid.Model[row, col + 1].Text = "Tax";
            grid.Model[row, col + 2].Text = "Ana Trujillo Emparedados y helados";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "John";
            grid.Model[row, col + 1].Text = "Insurance";
            grid.Model[row, col + 2].Text = "Antonio Moreno Taquería";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Franklin";
            grid.Model[row, col + 1].Text = "Stock";
            grid.Model[row, col + 2].Text = "Around the Horn";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Joseph";
            grid.Model[row, col + 1].Text = "Assets";
            grid.Model[row, col + 2].Text = "Berglunds snabbköp";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Bill";
            grid.Model[row, col + 1].Text = "Earnings";
            grid.Model[row, col + 2].Text = "Ana Trujillo Emparedados y helados";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Franklin";
            grid.Model[row, col + 1].Text = "MutualFunds";
            grid.Model[row, col + 2].Text = "Around the Horn";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Nancy";
            grid.Model[row, col + 1].Text = "Budget";
            grid.Model[row, col + 2].Text = "Alfreds Futterkiste";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "John";
            grid.Model[row, col + 1].Text = "Deposit";
            grid.Model[row, col + 2].Text = "Antonio Moreno Taquería";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Franklin";
            grid.Model[row, col + 1].Text = "CashBundle";
            grid.Model[row, col + 2].Text = "Around the Horn";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "John";
            grid.Model[row, col + 1].Text = "Creditcards";
            grid.Model[row, col + 2].Text = "Antonio Moreno Taquería";
            grid.Model[row, col + 1].ImageIndex = row;
            row++;
            grid.Model[row, col].Text = "Franklin";
            grid.Model[row, col + 1].Text = "FinanceCheque";
            grid.Model[row, col + 2].Text = "Around the Horn";
            grid.Model[row, col + 1].ImageIndex = row;

            grid.Model.RowHeights.DefaultLineSize = 30;
            grid.Model.ColumnWidths[1] = 100d;
            grid.Model.ColumnWidths[2] = 160d;
            grid.Model.ColumnWidths[3] = 120d;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            base.Dispose(disposing);
        }
    }
}
