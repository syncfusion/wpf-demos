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
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class TestingViewModel : NotificationObject
    {
        ObservableCollection<TestingModel> testing;

        public TestingViewModel()
        {
            this.TestingModels = new ObservableCollection<TestingModel>();
            Random rd = new Random();
            for (int i = 0; i < 250; i++)
            {
                this.TestingModels.Add(new TestingModel() { X = i, Y = rd.Next(0, 100) });
                this.TestingModels.Add(new TestingModel() { X = i, Y = rd.Next(0, 100) });
            }
        }

        public ObservableCollection<TestingModel> TestingModels
        {
            get
            {
                return testing;
            }
            set
            {
                testing = value;
                RaisePropertyChanged("TestingModel");
            }
        }
    }
}