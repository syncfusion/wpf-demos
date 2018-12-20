#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Collections.ObjectModel;
using System.Windows;
using Syncfusion.Windows.Chart;
using System.Windows.Controls;
using System.Reflection;

namespace ChartAxisElementsConfigurationDemo
{
    public class DataViewModel : INotifyPropertyChanged
    {

        public DataViewModel()
        {
            this.SalesDetails = new ObservableCollection<DataModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            this.SalesDetails.Add(new DataModel() {CarsSold=20, Date=new DateTime(2012,1,1), EstimatedCost = 60, ProfitPercentage = 10, AverageRaise = 50, InvestedAmount = 100 });
            this.SalesDetails.Add(new DataModel() {CarsSold=40, Date = new DateTime(2012,4, 1), EstimatedCost = 80, ProfitPercentage = 20, AverageRaise = 50, InvestedAmount = 200 });
            this.SalesDetails.Add(new DataModel() {CarsSold=60, Date = new DateTime(2012, 7, 1), EstimatedCost = 100, ProfitPercentage = 30, AverageRaise = 50, InvestedAmount = 300 });
            this.SalesDetails.Add(new DataModel() {CarsSold=80, Date = new DateTime(2012,10,1), EstimatedCost = 120, ProfitPercentage = 80, AverageRaise = 50, InvestedAmount = 800 });
            this.SalesDetails.Add(new DataModel() {CarsSold =100, Date = new DateTime(2012, 12, 1), EstimatedCost = 160, ProfitPercentage = 50, AverageRaise = 50, InvestedAmount = 500 });
            //this.SalesDetails.Add(new DataModel() {CarsSold=60,CarBrand = "Mercedes-Benz", SalesAmount = 184, ProfitPercentage = 95, AverageRaise = 50, InvestedAmount = 1000 });
        }

        public ObservableCollection<DataModel> salesdetails;
        public ObservableCollection<DataModel> SalesDetails
        {
            get
            {
                return salesdetails;
            }
            set
            {
                salesdetails = value;
                OnPropertyChanged("SalesDetails");
            }
        }

        public ObservableCollection<object> FontWeightsCollection
        {
            get
            {
                return EnumHelper.GetValues(typeof(FontWeights));
            }
        }

        public Array rangepaddingCollection
        {
            get { return Enum.GetValues(typeof(ChartRangePaddingType)); }
        }

        public Array TickLinesPositioning
        {
            get { return Enum.GetValues(typeof(AxisPositions)); }
        }

        public Array ThicknessCollection
        {
            get { return new double[]{0.5,1,1.5,2,2.5,3}; }
        }


        public Array HeaderAlignmentCollection
        {
            get { return Enum.GetValues(typeof(ChartAlignment)); }
        }

        public Array VisibilityCollection
        {
            get { return Enum.GetValues(typeof(Visibility)); }
        }

        public Array IntersectActionCollection
        {
            get { return Enum.GetValues(typeof(ChartLabelIntersectAction)); }
        }

        public Array OrientationCollection
        {
            get { return Enum.GetValues(typeof(Orientation)); }
        }

        public Array ValueTypeCollection
        {
            get { return Enum.GetValues(typeof(Syncfusion.Windows.Chart.ChartValueType)); }
        }

        public static class EnumHelper
        {

            public static ObservableCollection<object> GetValues(Type enumtype)
            {
                ObservableCollection<object> ItemSourceValues = new ObservableCollection<object>();

                PropertyInfo[] properties = enumtype.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                foreach (PropertyInfo property in properties)
                {
                    ItemSourceValues.Add(property.Name);
                }

                return ItemSourceValues;
            }

        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property.ToString()));
            }
        }
        #endregion
    }
}
