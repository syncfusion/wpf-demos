#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Windows.Data;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DateSelectorDemo : DemoControl
    {
        public DateSelectorDemo()
        {
            InitializeComponent();
        }

        public DateSelectorDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.DataContext = null;
            BindingOperations.ClearAllBindings(this);

            if (this.DateSelector != null)
            {
                this.DateSelector.Dispose();
                this.DateSelector = null;
            }

            if (this.MinMaxRangeDateSelector != null)
            {
                this.MinMaxRangeDateSelector.Dispose();
                this.MinMaxRangeDateSelector = null;
            }

            if (this.CustomDateSelector != null)
            {
                this.CustomDateSelector.Dispose();
                this.CustomDateSelector = null;
            }

            this.DateSelectorGrid.Children.Clear();
            this.DateSelectorGrid = null;

            base.Dispose(disposing);
        }
    }
}
