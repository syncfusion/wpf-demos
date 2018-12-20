#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DManhattanChart
{
    public class ChartWindowModel
    {
        public ChartViewModel ChartViewModel
        {
            get;
            set;
        }

        public ChartWindowModel()
        {
            this.UserOptionsModel = new UserOptionsViewModel();
            this.ChartViewModel = new ChartViewModel();
            this.UserOptionsModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(UserOptionsModel_PropertyChanged);
        }

        void UserOptionsModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Type")
            {
                ChartViewModel.Type = UserOptionsModel.Type;
            }
            else if (e.PropertyName == "Allow3DRotate")
            {
                ChartViewModel.Allow3DRotate = UserOptionsModel.Allow3DRotate;
            }
            else if (e.PropertyName == "Allow3DView")
            {
                ChartViewModel.Allow3DView = UserOptionsModel.Allow3DView;
            }
            else if (e.PropertyName == "IsClusteredView")
            {
                ChartViewModel.IsClusteredView = UserOptionsModel.IsClusteredView;
            }
        }

        public UserOptionsViewModel UserOptionsModel
        {
            get;
            set;
        }
    }
}
