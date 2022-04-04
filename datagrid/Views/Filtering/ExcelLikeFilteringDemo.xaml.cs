#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelLikeFilteringDemo.xaml
    /// </summary>
    public partial class ExcelLikeFilteringDemo : DemoControl
    {
        public ExcelLikeFilteringDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            //Release all managed resources
            if (this.syncgrid != null)
            {
                this.syncgrid.Dispose();
                this.syncgrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.textBlock3 != null)
                this.textBlock3 = null;

            if (this.textBlock4 != null)
                this.textBlock4 = null;

            if (this.textBlock5 != null)
                this.textBlock5 = null;

            if (this.textBlock6 != null)
                this.textBlock6 = null;

            if (this.textBlock7 != null)
                this.textBlock7 = null;

            if (this.ckbAllowFilters != null)
                this.ckbAllowFilters = null;

            if (this.ckbAllowFilterOrderID != null)
                this.ckbAllowFilterOrderID = null;

            if (this.ckbImmediateUpdateColumnFilterOrderID != null)
                this.ckbImmediateUpdateColumnFilterOrderID = null;

            if (this.ckbAllowBlankFiltersOrderID != null)
                this.ckbAllowBlankFiltersOrderID = null;

            if (this.ckbAllowFilterProductName != null)
                this.ckbAllowFilterProductName = null;

            if (this.ckbImmediateUpdateColumnFilterProductName != null)
                this.ckbImmediateUpdateColumnFilterProductName = null;

            if (this.ckbAllowBlankFiltersProductName != null)
                this.ckbAllowBlankFiltersProductName = null;

            if (this.FilterModeforProductName != null)
                this.FilterModeforProductName = null;

            if (this.ckbAllowFilterShippedDate != null)
                this.ckbAllowFilterShippedDate = null;

            if (this.ckbImmediateUpdateColumnFilterShippedDate != null)
                this.ckbImmediateUpdateColumnFilterShippedDate = null;

            if (this.ckbAllowBlankFiltersShippedDate != null)
                this.ckbAllowBlankFiltersShippedDate = null;

            if (this.FilterModeforShippedDate != null)
                this.FilterModeforShippedDate = null;

            base.Dispose(disposing);
        }
    }
}
