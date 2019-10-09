#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Data;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;

namespace TraderGridTest
{
    public class SampleGridControl : FlatDataViewGridControl
    {
        internal DispatcherTimer timer;
        private DataTable table;
        private System.Random rand;
        DataSet ds;

        // adjust settings below to modify scenario
        bool sortByThirdColumn = false;
        bool insertAndRemoveRecords = true;
        bool insertAndRemoveColumns = false;
        TimeSpan timerInterval = new TimeSpan(0, 0, 0, 0, 30);
        int numberOfChangesEachTimer = 100;
        int _blinkTime = 700;
        
        // enable timer, stop when and measure?
        bool startTimer = true;
        bool measureTime = false;
        int stopAtTimerCount = -1;

        // more detailed settings to modify scenario
        int initialRowCount = 200;
        int toggleInsertRemove = 10;// toggle between inserting and removing after n inserts/n removals.
        int insertRemoveModulus = 5; // frequency of insert / remove : every n timer ticks
        int insertRemoveCount = 1; // use 1 if you want to check out inserting and removing rows

        // internal
        int icount = 0;
        int timerCount = 0;
        bool shouldInsert = false;
        int ti = 0;
        long startTickCount;
        int addedColumns = 0;


        /// <summary>
        /// Initializes a new instance of the <see cref="SampleGridControl"/> class.
        /// </summary>
        public SampleGridControl()
        {
   
            GridStyleInfo footerStyle = Model.FooterStyle;
            footerStyle.Background = Brushes.Wheat;

            InitializeDataTable();
            SetupTimer();
            SourceList = this.table.DefaultView;

            RowHeights[10] = 40;
            RowHeights[15] = 60;

            BlinkTime = _blinkTime;

            this.Model.ColumnWidths[0] = 40;
            this.CurrentCell.Move(GridDirectionType.TopLeft, 1, false);
            this.Focus();
            this.Model.Options.AllowSelection = GridSelectionFlags.Cell;
        }

        private void SetupTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 2, 1);
            startTickCount = Environment.TickCount;
            if (startTimer)
                timer.Start();
        }

        void InitializeDataTable()
        {
            ds = new DataSet();
            table = new DataTable("RandomData");
            table.Columns.Add("Product", typeof(string));
            for (int n = 1; n <= 20; n++)
            {
                table.Columns.Add(n.ToString(), typeof(System.Double));
            }
            ds.Tables.Add(table);

            if (sortByThirdColumn)
                table.DefaultView.Sort = "3";

            rand = new Random(0);

            for (int i = 0; i < initialRowCount; i++)
            {
                double next = rand.Next(100);
                object[] values = new object[table.Columns.Count];
                values[0] = "P" + i.ToString("00000");
                for (int n = 1; n < table.Columns.Count; n++)
                    values[n] = next + n;
                table.Rows.Add(values);
            }
        }

        protected override void OnCellClick(GridCellClickEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex > 1)
            {
                table.DefaultView.Sort = (e.ColumnIndex - 1).ToString();
                e.Handled = true;
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (timerCount == 0)
            {
                timer.Interval = timerInterval;
                startTickCount = Environment.TickCount;
            }

            timerCount++;
            if (stopAtTimerCount > 0)
            {
                if (timerCount == stopAtTimerCount)
                {
                    timer.Tick -= new EventHandler(timer_Tick);
                    timer.Stop();

                    if (measureTime)
                        MessageBox.Show((Environment.TickCount - startTickCount).ToString());
                    return;
                }
                else if (timerCount > stopAtTimerCount)
                    return;
            }

            for (int i = 0; i < numberOfChangesEachTimer; i++)
            {
                int recNum = rand.Next(table.Rows.Count - 1);
                int col = rand.Next(table.Columns.Count - 1) + 1;
                DataRow drow = table.Rows[recNum];
                if (!(drow[col] is DBNull))
                {
                    double value = (int)(Convert.ToDouble(drow[col]) * (rand.Next(50) / 100.0f + 0.8));
                    drow[col] = value;
                }
            }

            if (insertAndRemoveColumns)
            {
                if (timerCount % 100 == 29)
                {
                    table.Columns.Add("A" + (addedColumns++).ToString(), typeof(double));
                }

                if (timerCount % 100 == 59)
                {
                    table.Columns.Remove(table.Columns[5]);
                }
            }

            // Insert or remove a row
            if (insertRemoveCount == 0 || !insertAndRemoveRecords)
                return;

            if (toggleInsertRemove > 0 && (timerCount % insertRemoveModulus) == 0)
            {
                icount = ++icount % (toggleInsertRemove * 2);
                shouldInsert = icount < toggleInsertRemove;

                if (shouldInsert)
                {
                    for (int ri = 0; ri < insertRemoveCount; ri++)
                    {
                        int recNum = rand.Next(Math.Min(30, table.Rows.Count));

                        double next = rand.Next(100);

                        object[] values = new object[table.Columns.Count];
                        values[0] = "H" + ti.ToString("00000");
                        for (int n = 1; n < table.Columns.Count; n++)
                            values[n] = next + n;

                        DataRow drow = table.NewRow();
                        drow.ItemArray = values;
                        table.Rows.InsertAt(drow, recNum);

                        ti++;
                    }
                }
                else
                {
                    for (int ri = 0; ri < insertRemoveCount; ri++)
                    {
                        int recNum = 5;
                        int rowNum = recNum + 1;

                        // Underlying data structure (this could be a datatable or whatever structure
                        // you use behind a virtual grid).

                        if (table.Rows.Count > 10)
                            table.Rows.RemoveAt(recNum);
                    }
                }
            }
        }

        protected override void OnPrepareRenderCell(GridPrepareRenderCellEventArgs e)
        {
            if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex > 0)
            {
                string s = Model[e.Cell.RowIndex, 1].Text;

                if (s.Contains("10"))
                    e.Style.Background = Brushes.LightSkyBlue;
                else if (s.Contains("20") || s.Contains("44"))
                    e.Style.Background = Brushes.LightSlateGray;
                else if (s.Contains("30") || s.Contains("11"))
                    e.Style.Background = Brushes.LightGoldenrodYellow;
            }

            base.OnPrepareRenderCell(e);
        }
    }

}
