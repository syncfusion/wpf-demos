#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class SalesAnalysisViewModel
    {
        public ObservableCollection<SalesAnalysisModel> SalesData { get; set; }

        public SalesAnalysisViewModel()
        {
            SalesData = GetRandomData();
        }

        private ObservableCollection<SalesAnalysisModel> GetRandomData()
        {
            ObservableCollection<SalesAnalysisModel> datas = new ObservableCollection<SalesAnalysisModel>();

            datas.Add(new SalesAnalysisModel("2009", 50, 6184, ""));
            datas.Add(new SalesAnalysisModel("2010", 56, 6384, ""));
            datas.Add(new SalesAnalysisModel("2011", 59, 6765, ""));
            datas.Add(new SalesAnalysisModel("2012", 63, 7343, ""));
            datas.Add(new SalesAnalysisModel("2013", 74, 8266, "Predicted No. Of Customers"));
            datas.Add(new SalesAnalysisModel("2014", 77, 8623, "Predicted No. Of Customers"));
            datas.Add(new SalesAnalysisModel("2015", 80, 8723, "Predicted No. Of Customers"));
            datas.Add(new SalesAnalysisModel("2016", 85, 8823, "Predicted No. Of Customers"));

            return datas;
        }
    }
}
