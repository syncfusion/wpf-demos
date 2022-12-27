#region Copyright Syncfusion Inc. 2001 - 2022
// Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
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

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for SortingDemo.xaml
    /// </summary>
    public partial class SortingDemo : DemoControl
    {
        public SortingDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as EmployeeInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if (this.CkbAllowSort != null)
                this.CkbAllowSort = null;

            if (this.CkbEnableTriStateSorting != null)
                this.CkbEnableTriStateSorting = null;

            if (this.CkbShowSortNumbers != null)
                this.CkbShowSortNumbers = null;

            if (this.textBlock != null)
                this.textBlock = null;

            if (this.CmbSortClickAction != null)
                this.CmbSortClickAction = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.CkbSalary != null)
                this.CkbSalary = null;

            if (this.CkbTitle != null)
                this.CkbTitle = null;

            base.Dispose(disposing);
        }
    }
}
