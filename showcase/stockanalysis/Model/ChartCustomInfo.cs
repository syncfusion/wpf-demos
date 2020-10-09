#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System.Collections.Generic;
using System.Windows;

namespace syncfusion.stockanalysisdemo.wpf
{
    public class ChartCustomInfo : ChartPointInfo
    {
        private IList<double> yValues;
        private Visibility visibility;
        private List<string> ylabelValues;
        private string labelX;
        private string labelY;

        public IList<double> YValues
        {
            get
            {
                return yValues;
            }
            set
            {
                if (value == yValues) return;
                yValues = value;
                OnPropertyChanged("YValues");
            }
        }

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                if (value != visibility)
                {
                    visibility = value;
                    OnPropertyChanged("Visibility");
                }
            }
        }

        public List<string> LabelYValues
        {
            get
            {
                return ylabelValues;
            }
            set
            {
                if (value != ylabelValues)
                {
                    ylabelValues = value;
                    OnPropertyChanged("LabelYValues");
                }
            }
        }
    
        /// <summary>
        /// Gets or Sets the x label.
        /// </summary>
        public string LabelX
        {
            get
            {
                return labelX;
            }
            set
            {
                if (value != labelX)
                {
                    labelX = value;
                    OnPropertyChanged("LabelX");
                }
            }
        }

        /// <summary>
        /// Gets or Sets the y label.
        /// </summary>
        public string LabelY
        {
            get
            {
                return labelY;
            }
            set
            {
                if (value != labelY)
                {
                    labelY = value;
                    OnPropertyChanged("LabelY");
                }
            }
        }
    }
}
