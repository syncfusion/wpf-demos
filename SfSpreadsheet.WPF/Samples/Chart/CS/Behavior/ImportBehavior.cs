#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.IO;
using System.Windows;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Spreadsheet.GraphicCells;
using Syncfusion.UI.Xaml.SpreadsheetHelper;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;

namespace ChartDemo.Behavior
{
    class ImportBehavior : Behavior<SfSpreadsheet>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.AddGraphicChartCellRenderer(new GraphicChartCellRenderer());
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                using (FileStream fileStream = new FileStream(@"..\..\..\..\..\..\Common\Data\Spreadsheet\Chart.xlsx", FileMode.Open))
                {
                    this.AssociatedObject.Open(fileStream);
                }
            }
            catch (Exception)
            { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
