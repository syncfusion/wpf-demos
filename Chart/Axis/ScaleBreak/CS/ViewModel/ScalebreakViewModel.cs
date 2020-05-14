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

namespace Scalebreak_Demo_2015
{
    public class ScalebreakViewModel : INotifyPropertyChanged
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
                OnPropertyChanged("CurrentBreakPosition");

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
                OnPropertyChanged("PercentageVisibility");
            }
        }
        
        public ObservableCollection<ScalebreakModel> ScalebreakDatas { get; set; }      

        public Array LineType
        {
            get { return Enum.GetValues(typeof(BreakLineType)); }
        }     

        public Array BreakPositions
        {
            get { return Enum.GetValues(typeof(ScaleBreakPosition)); }
        }

        private ScaleBreakPosition currentBreakPosition;
        private Visibility percentageVisibility;

        public event PropertyChangedEventHandler PropertyChanged;

        public ScalebreakViewModel()
        {
            ScalebreakDatas = new ObservableCollection<ScalebreakModel>();
            ScalebreakDatas.Add(new ScalebreakModel { XData = "Britton Hill", YData = 105 });
            ScalebreakDatas.Add(new ScalebreakModel { XData = "Yeomposan", YData = 203 });
            ScalebreakDatas.Add(new ScalebreakModel { XData = "Mount Everest", YData = 8848 });
            ScalebreakDatas.Add(new ScalebreakModel { XData = "Diamond Head", YData = 232 });
            ScalebreakDatas.Add(new ScalebreakModel { XData = "Nanda Devi", YData = 7816 });
            ScalebreakDatas.Add(new ScalebreakModel { XData = "Hwajangsan", YData = 285 });
            ScalebreakDatas.Add(new ScalebreakModel { XData = "Arma Konda", YData = 1680 });        
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
