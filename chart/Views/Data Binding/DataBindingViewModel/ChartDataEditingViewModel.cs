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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class ChartDataEditingViewModel : NotificationObject
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
                    RaisePropertyChanged(nameof(this.SelectedIndex));

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
                RaisePropertyChanged(nameof(this.SelectedXValue));
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
                RaisePropertyChanged(nameof(this.SelectedYValue));
            }
        }

        private int selectedIndex;
        private string selectedXValue;
        private string selectedYValue;

        public ChartDataEditingViewModel()
        {
            var date = new DateTime(2015, 1, 1);
            var random = new Random();

            Data = new ObservableCollection<ChartDataEditingModel>();

            Data.Add(new ChartDataEditingModel() { XValue = date.AddYears(0), YValue = 35, Scatter = 94 });
            Data.Add(new ChartDataEditingModel() { XValue = date.AddYears(1), YValue = 18, Scatter = 20 });
            Data.Add(new ChartDataEditingModel() { XValue = date.AddYears(2), YValue = 60, Scatter = 65 });
            Data.Add(new ChartDataEditingModel() { XValue = date.AddYears(3), YValue = 75, Scatter = 30 });
            Data.Add(new ChartDataEditingModel() { XValue = date.AddYears(4), YValue = 65, Scatter = 85 });

            SelectedIndex = 1;
        }

        public ObservableCollection<ChartDataEditingModel> Data { get; set; }

    }
}
