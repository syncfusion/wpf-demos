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

namespace CustomTooltip
{
    public class ViewModel : INotifyPropertyChanged
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
                OnPropertyChanged("HorizontalOffset");
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
                OnPropertyChanged("VerticalOffset");
            }
        }

        public Array VerticalAlignments
        {
            get
            {
                return new string[] { "Top", "Center", "Bottom" };
            }
        }

        public ObservableCollection<CompanyDetail> CompanyDetails { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string horizontalOffset;
        private string verticalOffset;

        public ViewModel()
        {
            CompanyDetails = new ObservableCollection<CompanyDetail>();

            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Mercedes",
                YTD = 983.502,
                Rank = 16,
                ImagePath = new Uri(@"\Image\benz.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Audi",
                YTD = 1030.393,
                Rank = 12,
                ImagePath = new Uri(@"\Image\audi.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "BMW",
                YTD = 1061.330,
                Rank = 11,
                ImagePath = new Uri(@"\Image\bmw.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Skoda",
                YTD = 590.897,
                Rank = 24,
                ImagePath = new Uri(@"\Image\skoda.png", UriKind.RelativeOrAbsolute)
            });

            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Volvo",
                YTD = 250.758,
                Rank = 43,
                ImagePath = new Uri(@"\Image\volvo.png", UriKind.RelativeOrAbsolute)
            });

            HorizontalOffset = "10";
            VerticalOffset = "10";
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
