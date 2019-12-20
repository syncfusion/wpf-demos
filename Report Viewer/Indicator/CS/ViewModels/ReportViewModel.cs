#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Net;
using System.IO;
using Syncfusion.Windows.Reports;
using Syncfusion.Windows.Reports.Viewer;

namespace Syncfusion.Samples.ViewModel
{
    public class ReportViewModel 
    {
        public ReportModel Report { get; set; }
           
        #region Constructor

        public ReportViewModel()
        {
            this.Report = new ReportModel();
            this.Report.ReportPath = this.GetFullPath("IndicatorReport.rdlc");
        }

        public void Loaded(object sender, RoutedEventArgs e)
        {
            Window mainWindow = sender as Window;
            Syncfusion.Windows.Reports.Viewer.ReportViewer viewer= mainWindow.FindName("viewer") as Syncfusion.Windows.Reports.Viewer.ReportViewer;
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.DataSources.Add(new ReportDataSource { Name = "DataSet1", Value = Billionaires.GetList_2013() });
            viewer.DataSources.Add(new ReportDataSource { Name = "DataSet2", Value = Billionaires.GetList_2012() });
            viewer.DataSources.Add(new ReportDataSource { Name = "DataSet3", Value = Indicator.GetIndicator() });
            viewer.RefreshReport();
        }

        private string GetFullPath(string report)
        {
            string templateDirectory = @"../../../../../Common/Data/ReportTemplate/RDLC";
            string dir = new DirectoryInfo(templateDirectory).FullName;
            return System.IO.Path.Combine(dir, report);  
        }

        #endregion
    }

    public class Billionaires
    {
        public int No { get; set; }
        public string Name { get; set; }
        public double NetWorth { get; set; }
        public int Age { get; set; }
        public string CitizenShip { get; set; }
        public string Source { get; set; }
        public int RankingStatus { get; set; }
        public int ProfitStatus { get; set; }

        public Billionaires(int no, string name, double netWorth, int age, string citizenShip, string source, int status, int profit)
        {
            this.No = no;
            this.Name = name;
            this.NetWorth = netWorth;
            this.Age = age;
            this.CitizenShip = citizenShip;
            this.Source = source;
            this.RankingStatus = status;
            this.ProfitStatus = profit;
        }

        public static List<Billionaires> GetList_2013()
        {
            List<Billionaires> list_2013 = new List<Billionaires>();
            list_2013.Add(new Billionaires(1, "Carlos Slim", 73.0, 73, "Mexico", "Telmex,América Móvil, Grupo Carso", 50, 75));
            list_2013.Add(new Billionaires(2, "Bill Gates", 67.0, 57, "United States", "Microsoft", 50, 75));
            list_2013.Add(new Billionaires(3, "Amancio Ortega", 57.0, 76, "Spain", "Inditex Group", 75, 75));
            list_2013.Add(new Billionaires(4, "Warren Buffett", 53.0, 82, "United States", "Berkshire Hathaway", 25, 75));
            list_2013.Add(new Billionaires(5, "Larry Ellison", 43.0, 68, "United States", "Oracle Corporation", 75, 75));
            list_2013.Add(new Billionaires(6, "Charles Koch", 34.0, 77, "United States", "Koch Industries", 75, 75));
            list_2013.Add(new Billionaires(7, "David Koch", 34.0, 72, "United States", "Koch Industries", 75, 75));
            list_2013.Add(new Billionaires(8, "Li Ka-shing", 32.0, 84, "Hong Kong/ Canada", "Cheung Kong Holdings", 75, 75));
            list_2013.Add(new Billionaires(9, "Liliane Bettencourt", 30.0, 90, "France", "L'Oréal", 75, 75));
            list_2013.Add(new Billionaires(10, "Bernard Arnault", 29.0, 63, "France", "LVMH Moët Hennessy Louis Vuitton", 25, 25));
            return list_2013;
        }

        public static List<Billionaires> GetList_2012()
        {
            List<Billionaires> list_2012 = new List<Billionaires>();
            list_2012.Add(new Billionaires(1, "Carlos Slim", 69.0, 72, "Mexico", "Telmex,América Móvil, Grupo Carso", 50, 25));
            list_2012.Add(new Billionaires(2, "Bill Gates", 61.0, 56, "United States", "Microsoft", 50, 75));
            list_2012.Add(new Billionaires(3, "Warren Buffett", 44.0, 81, "United States", "Berkshire Hathaway", 50, 25));
            list_2012.Add(new Billionaires(4, "Bernard Arnault", 41.0, 63, "France", "LVMH Moët Hennessy Louis Vuitton", 50, 75));
            list_2012.Add(new Billionaires(5, "Amancio Ortega", 37.5, 75, "Spain", "Inditex Group", 75, 75));
            list_2012.Add(new Billionaires(6, "Larry Ellison", 36.0, 67, "United States", "Oracle Corporation", 25, 75));
            list_2012.Add(new Billionaires(7, "Eike Batista", 30.0, 55, " Brazil", "EBX Group", 75, 75));
            list_2012.Add(new Billionaires(8, "Stefan Persson", 26.0, 64, "Sweden", "H&M", 75, 75));
            list_2012.Add(new Billionaires(9, "Li Ka-shing", 25.5, 83, "Hong Kong/ Canada", "Cheung Kong Holdings", 75, 75));
            list_2012.Add(new Billionaires(10, "Karl Albrecht", 25.4, 92, "Germany", "Aldi", 75, 75));
            return list_2012;
        }
    }

    public class Indicator
    {
        public int Status { get; set; }
        public string Description { get; set; }

        public Indicator(int status, string description)
        {
            this.Status = status;
            this.Description = description;
        }

        public static List<Indicator> GetIndicator()
        {
            List<Indicator> ind = new List<Indicator>();
            ind.Add(new Indicator(25, "Has not changed from the previous ranking."));
            ind.Add(new Indicator(50, "Has increased from the previous ranking."));
            ind.Add(new Indicator(75, "Has decreased from the previous ranking."));
            return ind;
        }
    }

}
