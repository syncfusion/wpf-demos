#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Globalization;
using Syncfusion.UI.Xaml.Grid;
using syncfusion.demoscommon.wpf;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ConditionalFormattingDetailsViewDataGridDemo.xaml
    /// </summary>
    public partial class ConditionalFormattingDetailsViewDataGridDemo : DemoControl
    {
        public ConditionalFormattingDetailsViewDataGridDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;


            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.textBlock3 != null)
                this.textBlock3 = null;

            //Release all managed resources
            if (this.Resources["unitpricestyle"] != null)
                (this.Resources["unitpricestyle"] as StyleConverterforUnitPrice).detailsViewDataGridDemo = null;
            if (this.Resources["quantitystyle"] != null)
                (this.Resources["quantitystyle"] as StyleConverterforQuantity).detailsViewDataGridDemo = null;

            this.Resources.Clear();

            base.Dispose(disposing);
        }
    }    
}
