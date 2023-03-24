#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.ComponentModel;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for ExportasImage.xaml
    /// </summary>
    public partial class ExportAsImage : ChromelessWindow
    {
        public ExportAsImage()
        {
            InitializeComponent();
        }
        public ExportAsImage(string themeName)
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            var viewModel = this.DataContext as ExportAsImageViewModel;
            if(viewModel != null)
            {
                viewModel.PageNumbers.Clear();
                viewModel.StartPageNumber = 0;
                viewModel.EndPageNumber = 0;
            }
            this.DataContext = null;
            base.OnClosing(e);
        }
    }
}
