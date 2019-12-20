#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDataEditing
{
    public class ViewModel : INotifyPropertyChanged
    {
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    OnPropertyChanged("SelectedIndex");

                    if (Data != null && selectedIndex > -1 && selectedIndex < Data.Count)
                    {
                        SelectedXValue = "FY" + " " + Data[selectedIndex].XValue.ToString("yyyy");
                        SelectedYValue = Data[selectedIndex].YValue.ToString();
                    }
                }
            }
        }

        public string SelectedXValue
        {
            get
            {
                return selectedXValue;
            }

            set
            {
                selectedXValue = value;
                OnPropertyChanged("SelectedXValue");
            }
        }

        public string SelectedYValue
        {
            get
            {
                return selectedYValue;
            }

            set
            {
                selectedYValue = value;
                OnPropertyChanged("SelectedYValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int selectedIndex;
        private string selectedXValue;
        private string selectedYValue;

        public ViewModel()
        {
            var date = new DateTime(2015, 1, 1);
            var random = new Random();

            Data = new ObservableCollection<Model>();

            Data.Add(new Model() { XValue = date.AddYears(0), YValue = 35, Scatter = 94 });
            Data.Add(new Model() { XValue = date.AddYears(1), YValue = 18, Scatter = 20 });
            Data.Add(new Model() { XValue = date.AddYears(2), YValue = 60, Scatter = 65 });
            Data.Add(new Model() { XValue = date.AddYears(3), YValue = 75, Scatter = 30 });
            Data.Add(new Model() { XValue = date.AddYears(4), YValue = 65, Scatter = 85 });

            SelectedIndex = 1;
        }

        public ObservableCollection<Model> Data { get; set; }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
