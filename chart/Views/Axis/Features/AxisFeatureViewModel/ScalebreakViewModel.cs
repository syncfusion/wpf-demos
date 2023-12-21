#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class ScalebreakViewModel : NotificationObject
    {
        public ScaleBreakPosition CurrentBreakPosition
        {
            get 
            {
                return currentBreakPosition; 
            }

            set 
            {
                currentBreakPosition = value;
                RaisePropertyChanged(nameof(this.CurrentBreakPosition));

                if(currentBreakPosition == ScaleBreakPosition.Percent)
                {
                    PercentageVisibility = Visibility.Visible;
                }
                else
                {
                    PercentageVisibility = Visibility.Collapsed;
                }
            }
        }

        public Visibility PercentageVisibility
        {
            get
            {
                return percentageVisibility;
            }

            set
            {
                percentageVisibility = value;
                RaisePropertyChanged(nameof(this.PercentageVisibility));
            }
        }
        
        public ObservableCollection<ScalebreakModel> MountainsElevationsDetails { get; set; }      

        private ScaleBreakPosition currentBreakPosition;
        private Visibility percentageVisibility;

        public ScalebreakViewModel()
        {
            MountainsElevationsDetails = new ObservableCollection<ScalebreakModel>();
            MountainsElevationsDetails.Add(new ScalebreakModel { MountainsName = "Mount Everest", Height = 8848 });
            MountainsElevationsDetails.Add(new ScalebreakModel { MountainsName = "Gyala Peri", Height = 7294 });
            MountainsElevationsDetails.Add(new ScalebreakModel { MountainsName = "Denali", Height = 6191 });
            MountainsElevationsDetails.Add(new ScalebreakModel { MountainsName = "Mount Gongga", Height = 7556});
            MountainsElevationsDetails.Add(new ScalebreakModel { MountainsName = "Aconcagua", Height = 6960 });
            MountainsElevationsDetails.Add(new ScalebreakModel { MountainsName = "Tirich Mir", Height = 7708 });
            MountainsElevationsDetails.Add(new ScalebreakModel { MountainsName = "K2", Height = 8611 });
        }
    }
}
