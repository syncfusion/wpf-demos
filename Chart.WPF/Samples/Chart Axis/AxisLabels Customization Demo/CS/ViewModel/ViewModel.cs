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
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;
using System.Windows;
using System.Reflection;

namespace AxisLabelsCustomizationDemo
{
    public class ViewModel  : INotifyPropertyChanged
    {

        public ViewModel()
        {
            this.SalesDetails = new ObservableCollection<DataModel>();
            GenerateData();
            
        }

        private void GenerateData()
        {
            this.SalesDetails.Add(new DataModel() { Frequency = 30,MinimumWaveLength=1000, MaximumWaveLength = 10000});
            this.SalesDetails.Add(new DataModel() { Frequency = 300,MinimumWaveLength=100, MaximumWaveLength = 1000});
            this.SalesDetails.Add(new DataModel() { Frequency = 3000,MinimumWaveLength=10, MaximumWaveLength = 100});
            this.SalesDetails.Add(new DataModel() { Frequency =30000,MinimumWaveLength=3, MaximumWaveLength = 10});
            this.SalesDetails.Add(new DataModel() { Frequency = 300000,MinimumWaveLength=1, MaximumWaveLength = 2});
        }


        public Array ThicknessCollection
        {
            get { return new double[] { 0.5, 1, 1.5, 2, 2.5, 3 }; }
        }
        public ObservableCollection<object> FontWeightsCollection
        {
            get
            {
                return EnumHelper.GetValues(typeof(FontWeights));
            }
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
