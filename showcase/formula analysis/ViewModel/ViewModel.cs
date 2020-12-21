#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Calculate;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.formulaanalysis.wpf
{
    public class ViewModel : NotificationObject
    {
        #region Properties

        internal List<Model> dt1 = new List<Model>();
        internal List<Model> dbdt = new List<Model>();
        internal DataTable dt = new DataTable();
        internal DataTable dbDT = new DataTable();
        internal List<string> dbfunction = new List<string>();
        internal CalcEngine engine; 

        private string descriptionText;

        public string DescriptionText
        {
            get { return descriptionText; }
            set
            {
                descriptionText = value;
                RaisePropertyChanged("DescriptionText");
            }
        }

        private string syntaxText;

        public string SyntaxText
        {
            get { return syntaxText; }
            set
            {
                syntaxText = value;
                RaisePropertyChanged("SyntaxText");
            }
        }

        private string sumText = "=SUM(A2,A3,A5,A5)";

        public string SumText
        {
            get { return sumText; }
            set
            {
                sumText = value;
                this.RaisePropertyChanged(() => this.SumText);  
            }
        }

        private string resultText;

        public string ResultText
        {
            get { return resultText; }
            set
            {
                resultText = value;
                RaisePropertyChanged("ResultText");
            }
        }

        #endregion

        #region Methods
        
        internal void PopulateDataTableValues()
        {
            dt1.Add(new Model { A = "6", B = "58", C = "35", D = "0.01", E = "7/18/2011 7:45:05 AM", F = "7500", G = "-120000" });
            dt1.Add(new Model { A = "25", B = "11", C = "25", D = "6", E = "TRUE", F = "4", G = "39000" });
            dt1.Add(new Model { A = "0.15", B = "10", C = "23", D = "4", E = "FALSE", F = "3.5", G = "30000" });
            dt1.Add(new Model { A = "0.75", B = "45.35", C = "47.65", D = "0.06", E = "8", F = "1.2", G = "21000" });
            dt1.Add(new Model { A = "0.05", B = "17.56", C = "18.44", D = "10", E = "20", F = "0.908789", G = "37000" });
            dt1.Add(new Model { A = "0.85", B = "16.09", C = "16.91", D = "-200", E = "3", F = "40", G = "46000" });
            dt1.Add(new Model { A = "50", B = "2400", C = "15.20", D = "-500", E = "3", F = "1.5", G = "0.1" });
            dt1.Add(new Model { A = "0.09", B = "300", C = "6", D = "0.068094", E = "8000", F = "10", G = "0.12" });
            dt1.Add(new Model { A = "30", B = "10", C = "4", D = "0.01", E = "FLUID FLOW", F = "2", G = "#NULL!" });
            dt1.Add(new Model { A = "125000", B = "STREET", C = "-200", D = "2", E = "$1000", F = "2000", G = "http://en.wikipedia.org/w/api.php?action=query&list=recentchanges&rcnamespace=0&format=xml" });

            dt = ConvertToDatatable<Model>(dt1);


            dbdt.Add(new Model { A = "Tree", B = "Height", C = "Age", D = "Yield", E = "Profit", F = "Height", G = "13" });
            dbdt.Add(new Model { A = "=\"=Apple\"", B = ">10", C = string.Empty, D = string.Empty, E = string.Empty, F = "<16", G = "12" });
            dbdt.Add(new Model { A = "=\"=Pear\"", B = "", C = string.Empty, D = string.Empty, E = string.Empty, F = string.Empty, G = "11" });
            dbdt.Add(new Model { A = "Tree", B = "Height", C = "Age", D = "Yield", E = "Profit", F = string.Empty, G = "8" });
            dbdt.Add(new Model { A = "Apple", B = "18", C = "20", D = "14", E = "105.00", F = "-$10,000", G = "4" });
            dbdt.Add(new Model { A = "Pear", B = "12", C = "12", D = "10", E = "96.00", F = "$2,750", G = "3" });
            dbdt.Add(new Model { A = "Cherry", B = "13", C = "14", D = "9", E = "105.00", F = "4,250", G = "2" });
            dbdt.Add(new Model { A = "Apple", B = "14", C = "15", D = "10", E = "75.00", F = "1-Jan-08", G = "1" });
            dbdt.Add(new Model { A = "Pear", B = "9", C = "8", D = "8", E = "76.80", F = "1-Mar-08", G = "1" });
            dbdt.Add(new Model { A = "Apple", B = "8", C = "9", D = "6", E = "45.00", F = "30-Oct-08", G = "1" });

            dbDT = ConvertToDatatable<Model>(dbdt);


            dbfunction.Add("DCOUNT");
            dbfunction.Add("DCOUNTA");
            dbfunction.Add("DMIN");
            dbfunction.Add("DMAX");
            dbfunction.Add("DSUM");
            dbfunction.Add("DPRODUCT");
            dbfunction.Add("DAVERAGE");
            dbfunction.Add("DSTDEV");
            dbfunction.Add("DSTDEVP");
            dbfunction.Add("DVAR");
            dbfunction.Add("DVARP");
            dbfunction.Add("DGET");
            dbfunction.Add("FORMULATEXT");
            dbfunction.Add("COUNTBLANK");
            dbfunction.Add("PERCENTRANK.INC");
            dbfunction.Add("PERCENTRANK.EXC");
            dbfunction.Add("PERCENTRANK");
            dbfunction.Add("XIRR");
        }

        private DataTable ConvertToDatatable<sample>(List<sample> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(sample));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (sample item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #endregion

        #region Command

        private ICommand buttonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                if (buttonCommand == null)
                {
                    buttonCommand = new DelegateCommand<object>(ButtonClick);
                }
                return buttonCommand;
            }

        }
        public void ButtonClick(object param)
        {
            this.DescriptionText = "";
            this.SyntaxText = "";
            this.ResultText = "";

            this.engine.UseDependencies = false;
            this.ResultText = this.engine.ParseAndComputeFormula((this.SumText));
            this.engine.UseDependencies = true;
        }

        #endregion
    }
}
