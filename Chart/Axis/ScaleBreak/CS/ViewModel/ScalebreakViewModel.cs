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
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;

namespace Scalebreak_Demo_2015
{
    public class ScalebreakViewModel
    {
        public ObservableCollection<ScalebreakModel> ScalebreakDatas { get; set; }      

        public Array LineType
        {
            get { return Enum.GetValues(typeof(BreakLineType)); }
        }     

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
    }
}
