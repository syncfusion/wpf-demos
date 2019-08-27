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
using System.Collections.ObjectModel;

namespace VS2010DockingManager
{
    class ViewModel
    {
        public ViewModel()
        {
            items = new ObservableCollection<Model>()
            {
          new Model { Number = "1", Description = "Method must have a return type", File = "MainWindow.xaml.cs", Column = "66", Line = "16", Project = "VS2010DockingManagerDemo_2010" },
            new Model { Number = "2", Description = "Key Value not found", File = "MainWindow.xaml", Column = "26", Line = "23", Project = "VS2010DockingManagerDemo_2010" },
            };
        }
        private ObservableCollection<Model> items;

        public ObservableCollection<Model> Items
        {
            get { return items; }
            set { items = value; }
        }


    }
}

