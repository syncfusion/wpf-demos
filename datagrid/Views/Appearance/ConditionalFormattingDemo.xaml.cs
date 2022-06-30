#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    /// Interaction logic for ConditionalFormattingDemo.xaml
    /// </summary>
    public partial class ConditionalFormattingDemo : DemoControl
    {
        public ConditionalFormattingDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as SalesInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

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

            if (this.Resources["tableSummaryStyleSelector"] != null)
                (this.Resources["tableSummaryStyleSelector"] as ConditionalFormattingStyleSelector).conditionalFormattingDemo = null;
            if (this.Resources["customstyle_QS2"] != null)
                (this.Resources["customstyle_QS2"] as StyleConverterforQS2).conditionalFormattingDemo = null;
            if (this.Resources["customstyle_QS3"] != null)
                (this.Resources["customstyle_QS3"] as StyleConverterforQS3).conditionalFormattingDemo = null;
            if (this.Resources["customstyle_QS4"] != null)
                (this.Resources["customstyle_QS4"] as StyleConverterforQS4).conditionalFormattingDemo = null;

            this.Resources.Clear();

            base.Dispose(disposing);
        }
    }
}
