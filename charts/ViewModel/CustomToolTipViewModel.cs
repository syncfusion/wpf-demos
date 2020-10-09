#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class CustomToolTipViewModel : NotificationObject
    {
        public Array HorizontalAlignments
        {
            get
            {
                return new string[] { "Left", "Center", "Right" };
            }
        }

        public string HorizontalOffset
        {
            get
            {
                return horizontalOffset;
            }

            set
            {
                double result;
                if (double.TryParse(value, out result) || value == ".")
                    horizontalOffset = value;
                RaisePropertyChanged(nameof(this.HorizontalOffset));
            }
        }

        public string VerticalOffset
        {
            get
            {
                return verticalOffset;
            }

            set
            {
                double result;
                if (double.TryParse(value, out result) || value == ".")
                    verticalOffset = value;
                RaisePropertyChanged(nameof(this.VerticalOffset));
            }
        }

        public Array VerticalAlignments
        {
            get
            {
                return new string[] { "Top", "Center", "Bottom" };
            }
        }

        public ObservableCollection<CustomToolTipModel> CompanyDetails { get; set; }

        private string horizontalOffset;
        private string verticalOffset;

        public CustomToolTipViewModel()
        {
            CompanyDetails = new ObservableCollection<CustomToolTipModel>();

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Mercedes",
                YTD = 983.502,
                Rank = 16,
                ImagePath = new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/benz.png", UriKind.Relative)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Audi",
                YTD = 1030.393,
                Rank = 12,
                ImagePath = new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/audi.png", UriKind.Relative)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "BMW",
                YTD = 1061.330,
                Rank = 11,
                ImagePath = new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/bmw.png", UriKind.Relative)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Skoda",
                YTD = 590.897,
                Rank = 24,
                ImagePath = new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/skoda.png", UriKind.Relative)
            });

            CompanyDetails.Add(new CustomToolTipModel()
            {
                CompanyName = "Volvo",
                YTD = 250.758,
                Rank = 43,
                ImagePath = new Uri(@"/syncfusion.chartdemos.wpf;component/Assets/Chart/volvo.png", UriKind.Relative)
            });

            HorizontalOffset = "10";
            VerticalOffset = "10";
        }
    }
}
