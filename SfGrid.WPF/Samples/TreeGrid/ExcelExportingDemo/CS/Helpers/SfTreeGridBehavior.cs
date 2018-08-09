using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace ExcelExportingDemo
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
