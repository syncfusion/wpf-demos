#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Printing.ViewModel
{
    using Model;
    using System.Windows;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows.Input;
    using Syncfusion.Windows.Controls.Grid;
    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    /// A class that serves as a view model for main window view.
    /// </summary>
    public class ViewModel
    {
        private object productSalesData;
        private ICommand printCommand, headerCommand, footerCommand;
        private DataTemplate headerTemplate, footerTemplate;

        /// <summary>
        /// Gets or sets the product sales data.
        /// </summary>
        public object ProductSalesData
        {
            get
            {
                this.productSalesData = this.productSalesData ?? ProductSales.GetSalesData();
                return this.productSalesData;
            }
            set { this.productSalesData = value; }
        }

        /// <summary>
        /// Gets or sets whether to export header or not.
        /// </summary>
        public bool IsHeaderChecked
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to export footer or not.
        /// </summary>
        public bool IsFooterChecked
        {
            get;
            set;
        }


        /// <summary>
        /// Gets the command on enabling the header export.
        /// </summary>
        public ICommand HeaderCommand
        {
            get
            {
                this.headerCommand = new PrintCommand(param => this.HeaderTemplate = (DataTemplate)param);
                return this.headerCommand;
            }
        }

        /// <summary>
        /// Gets the command on enabling the footer export.
        /// </summary>
        public ICommand FooterCommand
        {
            get
            {
                this.footerCommand = new PrintCommand(param => this.FooterTemplate = (DataTemplate)param);
                return this.footerCommand;
            }
        }

        /// <summary>
        /// Gets the command on enabling the print option.
        /// </summary>
        public ICommand PrintCommand
        {
            get
            {
                this.printCommand = new PrintCommand(this.Print);
                return this.printCommand;
            }

        }

        /// <summary>
        /// Gets or sets the header template.
        /// </summary>
        private DataTemplate HeaderTemplate
        {
            get { return this.headerTemplate; }
            set
            {
                this.headerTemplate = this.IsHeaderChecked ? value : null;
            }
        }

        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        private DataTemplate FooterTemplate
        {
            get { return this.footerTemplate; }
            set
            {
                this.footerTemplate = this.IsFooterChecked ? value : null;
            }
        }
        /// <summary>
        /// A method that performs print operation.
        /// </summary>
        /// <param name="obj"></param>
        private void Print(object obj)
        {
            PivotGridControl pivotGrid1 = obj as PivotGridControl; // obj refers to PivotGridControl object
            Window printWindow = new Window();
            if (pivotGrid1 != null)
            {
                pivotGrid1.InternalGrid.PrintRange = GridRangeInfo.Table();
                PivotGridPrintDocument printDocument = new PivotGridPrintDocument(pivotGrid1);
                printDocument.Margin = new Thickness(20);
                PrintPreviewControl navigationControl = new PrintPreviewControl(printDocument);
                navigationControl.HeaderTemplate = this.HeaderTemplate;
                navigationControl.FooterTemplate = this.FooterTemplate;
                printWindow.Title = "Print Preview";
                printWindow.Content = navigationControl;
            }
            printWindow.ShowDialog();
        }

    }
}
