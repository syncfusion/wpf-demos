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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using Syncfusion.Windows.Controls.Input;
using System.Windows.Threading;

namespace SfAutoCompleteDemo
{
    /// <summary>
    /// Interaction logic for AutoCompleteDemo.xaml
    /// </summary>
    public partial class AutoCompleteDemo : UserControl
    {
        public AutoCompleteDemo()
        {
            InitializeComponent();

            customFilter.Filter = MyFilter;
        }

        public bool MyFilter(string search, object item)
        {
            Person model = item as Person;

            if (model != null)
            {
                if (model.Name.ToLower().Contains(search))
                {
                    return true;
                }
                else if (model.Designation.ToLower().Contains(search))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

  
