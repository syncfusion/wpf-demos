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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace syncfusion.calculatedemos.wpf
{
    public class BindList: INotifyPropertyChanged
    {
        #region Constructor
        public BindList()
        {
            //this.Formula = string.Empty;
        }
        #endregion 

        public string formula;
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void Onpropertychagned(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
