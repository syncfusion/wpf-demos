#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    public partial class DrawerContentView : UserControl
    {
        public DrawerContentView(ObservableCollection<Message> items, string title)
        {
            InitializeComponent();
            listView.ItemsSource = items;
        }
    }
}