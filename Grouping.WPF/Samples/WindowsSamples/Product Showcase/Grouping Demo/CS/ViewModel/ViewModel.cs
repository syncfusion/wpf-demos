#region Copyright Syncfusion Inc. 2001 - 2013
// Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
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
using System.Data;
using ISummary = Syncfusion.Collections.BinaryTree.ITreeTableSummary;
using Syncfusion.Grouping;
using System.Windows.Input;

namespace GroupingWithDataGrid
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Load();
        }

        public void Load()
        {
            //get a DataTable
            myTable = GetATable();

            //set it into the DataGrid
            //this.dataGrid1.ItemsSource = myTable.DefaultView;

            //create a new grouping engine and assign it a IList datasource
            engine = new Engine();
            engine.SetSourceList(myTable.DefaultView);
            engine.RecordAsDisplayElements = true;

            //enable the 2 summar

            //get a reference to the underlying grouping Table
            theTable = engine.Table;

            //add the Summaries that we want
            engine.TableDescriptor.Summaries.Add("AStats", "A", SummaryType.Int32Aggregate);
            engine.TableDescriptor.Summaries.Add("BStats", "B", SummaryType.Int32Aggregate);

            RefreshStatsPanel();
        }

        public string lblMaxA="A";
        public string lblMinA = "A";
        public string lblTotA = "A";
        public string lblCountA = "A";
        public string lblMaxB = "B";
        public string lblMinB = "B";
        public string lblTotB = "B";
        public string lblCountB = "B";
        public int nNum = 100;

        //our datasource
        private DataTable myTable;

        //grouping support objects 
        private Syncfusion.Grouping.Table theTable;
        private Syncfusion.Grouping.Engine engine;

        public int NNum
        {
            get { return nNum; }
            set
            {
                nNum = value;
                onPropertyChanged("NNum");
            }
        }
        //our datasource
        public DataTable MyTable
        {
            get { return myTable; }
            set
            {
                myTable = value;
                onPropertyChanged("MyTable");
            }
        }

        //grouping support objects 
        private Syncfusion.Grouping.Table TheTable
        {
            get { return theTable; }
            set
            {
                theTable = value;
                onPropertyChanged("TheTable");
            }
        }
        private Syncfusion.Grouping.Engine Engine
        {
            get { return engine; }
            set
            {
                engine = value;
                onPropertyChanged("Engine");
            }
        }

        public string LblMaxA
        {
            get { return lblMaxA; }
            set
            {
                lblMaxA = value;
                onPropertyChanged("LblMaxA");
            }
        }
        public string LblMinA
        {
            get { return lblMinA; }
            set
            {
                lblMinA = value;
                onPropertyChanged("LblMinA");
            }
        }
        public string LblTotA
        {
            get { return lblTotA; }
            set
            {
                lblTotA = value;
                onPropertyChanged("LblTotA");
            }
        }
        public string LblCountA
        {
            get { return lblCountA; }
            set
            {
                lblCountA = value;
                onPropertyChanged("LblCountA");
            }
        }

        public string LblMaxB
        {
            get { return lblMaxB; }
            set
            {
                lblMaxB = value;
                onPropertyChanged("LblMaxB");
            }
        }
        public string LblMinB
        {
            get { return lblMinB; }
            set
            {
                lblMinB = value;
                onPropertyChanged("LblMinB");
            }
        }
        public string LblTotB
        {
            get { return lblTotB; }
            set
            {
                lblTotB = value;
                onPropertyChanged("LblTotB");
            }
        }
        public string LblCountB
        {
            get { return lblCountB; }
            set
            {
                lblCountB = value;
                onPropertyChanged("LblCountB");
            }
        }

        private ICommand compute;
        public ICommand computeCommand
        {

            get
            {
                if (compute == null)
                    compute = new ComputeCmd(this);
                return compute;
            }
            set
            {
                compute = value;
            }
        }

        public DataTable GetATable()
        {
            DataTable dt = new DataTable("MyTable");
            dt.Columns.Add(new DataColumn("A", typeof(int)));
            dt.Columns.Add(new DataColumn("B", typeof(int)));

            PopulateDataTable(100, dt);

            return dt;
        }

        public void PopulateDataTable(int nRows, DataTable dt)
        {
            //if (this.dataGrid1.CurrentRowIndex >= 0)
            //    this.dataGrid1.CurrentRowIndex = 0;
            dt.Clear();
            dt.Rows.Clear();

            Random r = new Random();

            for (int i = 0; i < nRows; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = r.Next(1000);
                dr[1] = r.Next(1000);
                dt.Rows.Add(dr);
            }
        }

        public void RefreshStatsPanel()
        {
            ISummary[] summaries = this.theTable.TopLevelGroup.GetSummaries(this.theTable);
            SummaryDescriptorCollection sdc = this.theTable.TableDescriptor.Summaries;
            int index = sdc.IndexOf(sdc["AStats"]);
            Int32AggregateSummary summary = summaries[index] as Int32AggregateSummary;


            LblMaxA = summary.Maximum.ToString();
            LblMinA = summary.Minimum.ToString();
            LblTotA = summary.Sum.ToString();
            LblCountA = summary.Count.ToString(); ;

            index = sdc.IndexOf(sdc["BStats"]);
            summary = summaries[index] as Int32AggregateSummary;

            LblMaxB = summary.Maximum.ToString();
            LblMinB = summary.Minimum.ToString();
            LblTotB = summary.Sum.ToString();
            LblCountB = summary.Count.ToString();


        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
    }
}
