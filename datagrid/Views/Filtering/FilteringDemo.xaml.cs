#region Copyright Syncfusion Inc. 2001 - 2022
// Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for FilteringDemo.xaml
    /// </summary>
    public partial class FilteringDemo : DemoControl
    {
        public FilteringDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            //Release all managed resources
            if (this.sfGrid != null)
            {
                //Release managed resources in EmployeeInfoViewModel.
                if (this.sfGrid.DataContext != null)
                {
                    var dataContext = this.sfGrid.DataContext as EmployeeInfoViewModel;
                    dataContext.Dispose();
                }
                this.sfGrid.Dispose();
                this.sfGrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.textBlock3 != null)
                this.textBlock3 = null;

            if (this.FilterBox != null)
                this.FilterBox = null;

            if (this.columnCombo != null)
                this.columnCombo = null;

            if (this.stringCombo != null)
                this.stringCombo = null;

            if (this.numericCombo != null)
                this.numericCombo = null;

            base.Dispose(disposing);
        }
    }
}
