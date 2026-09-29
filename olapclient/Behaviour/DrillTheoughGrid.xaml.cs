#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Data;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interaction logic for DrillTheoughGrid.xaml
    /// </summary>
    public partial class DrillThroughGrid : Window
    {
        #region Members

        DataTable datasource;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a boolean value to get hierarchy selector.
        /// </summary>

        public bool IsHierarchySelectorNeeded
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public DrillThroughGrid(DataTable source)
        {
            InitializeComponent();
            datasource = source;
            if (datasource != null && datasource.Rows.Count > 0 && datasource.Columns.Count > 0)
            {
                this.testGrid.Model.RowCount = datasource.Rows.Count;
                this.testGrid.Model.ColumnCount = datasource.Columns.Count + 1;
                this.testGrid.Model.RowHeights.DefaultLineSize = 30;
                this.testGrid.QueryCellInfo += testGrid_QueryCellInfo;
                this.testGrid.Loaded += testGrid_Loaded;
            }
        }

        #endregion

        #region Methods

        void testGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.testGrid.SetColumnWidth(0, 0);
        }

        void testGrid_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
            if (e.Style.ColumnIndex != 0)
            {

                if (e.Style.RowIndex < this.testGrid.Model.RowCount && e.Style.ColumnIndex < this.testGrid.Model.ColumnCount)
                {
                    e.Style.CellValue = datasource.Rows[e.Style.RowIndex][e.Style.ColumnIndex - 1];

                }
                Size size = GetSize(e.Style.CellValue);
                if (this.testGrid.Model.ColumnWidths[e.Style.ColumnIndex] < size.Width)
                    this.testGrid.Model.ColumnWidths[e.Style.ColumnIndex] = size.Width;
            }
        }

        private Size GetSize(object cellValue)
        {
            string value = Regex.Replace(cellValue.ToString(), @"\s+", "@");
            TextBlock txtBlock = new TextBlock();
            txtBlock.Text = value;
            txtBlock.Measure(new Size(double.MaxValue, double.MaxValue));
            return txtBlock.DesiredSize;
        }

        private void hierachySelector_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.IsHierarchySelectorNeeded = true;
        }

        #endregion
    }
}