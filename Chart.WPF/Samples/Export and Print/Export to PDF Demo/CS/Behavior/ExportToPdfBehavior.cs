#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Chart.Converter;

namespace ChartExport
{
    class ExportToPdfBehavior:Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            this.AssociatedObject.ConvertBtn.Click += new System.Windows.RoutedEventHandler(ConvertBtn_Click);
        }

        void ConvertBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ChartPdfConverterControl control = new ChartPdfConverterControl();
            control.ChartPdfConverter(this.AssociatedObject.Chart1, "chartpdf.pdf");
        }

    }
}
