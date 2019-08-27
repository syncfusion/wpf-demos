#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using VisualDataEditing.Annotations;
using Syncfusion.UI.Xaml.Charts;

namespace VisualDataEditing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void XySegmentDraggingBase_OnDragDelta(object sender, DragDelta e)
        {
            var info = e as XySegmentDragEventArgs;
            if (info == null) return;
            info.Cancel = info.NewYValue < 1;
        }
        private void XySegmentDraggingBase_OnDragStart(object sender, ChartDragStartEventArgs e)
        {
            e.Cancel = !(ReferenceEquals(e.BaseXValue, "2013") 
                       || ReferenceEquals(e.BaseXValue, "2014") 
                       || ReferenceEquals(e.BaseXValue, "2015") 
                       || ReferenceEquals(e.BaseXValue, "2016"));
        }

        private void XySegmentDraggingBase_OnSegmentMouseOver(object sender, XySegmentEnterEventArgs e)
        {
            e.CanDrag = (ReferenceEquals(e.XValue, "2013") 
                        || ReferenceEquals(e.XValue, "2014") 
                        || ReferenceEquals(e.XValue, "2015") 
                        || ReferenceEquals(e.XValue, "2016"));
        }
    }


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

    public class SalesAnalysisModel : INotifyPropertyChanged
    {

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private double income;

        public double Income
        {
            get { return income; }
            set { income = value; }
        }

        private double noOfCustomer;

        public double NoOfCustomer
        {
            get { return noOfCustomer; }
            set { noOfCustomer = value; }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public SalesAnalysisModel(string year, double count, double income, string text)
        {
            Year = year;
            NoOfCustomer = count;
            Income = income;
            Text = text;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
