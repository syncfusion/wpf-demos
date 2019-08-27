#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace PDFExportingDemo
{
    public class SfTreeGridBehavior : Behavior<SfTreeGrid>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.CurrentCellRequestNavigate += TreeGrid_CurrentCellRequestNavigate;            
        }

        private void TreeGrid_CurrentCellRequestNavigate(object sender, Syncfusion.UI.Xaml.Grid.CurrentCellRequestNavigateEventArgs args)
        {
            string address = "https://en.wikipedia.org/wiki/" + args.NavigateText;
            Process.Start(new ProcessStartInfo(address));
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.CurrentCellRequestNavigate -= TreeGrid_CurrentCellRequestNavigate;           
        }
    }
}
