#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace syncfusion.succinctlyseries.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SuccinctlySeriesDemo : ChromelessWindow
    {
        FrontPage FrontPage = new FrontPage();
        public SuccinctlySeriesDemo()
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Office2019Black" });
            InitializeComponent();
            Navigator.Frame = MainFrame;
            Navigator.Frame.Navigate(FrontPage);
        }

        private void ChromelessWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            object frameContent = Navigator.Frame.Content;
            PDFViewerPage page = frameContent as PDFViewerPage;
            ViewModel viewModel=null;
            if(page!=null)
            {
                page.Unload();
                viewModel = page.DataContext as ViewModel;
                page = null;
            }
            else
            {
                FrontPage frontPage = frameContent as FrontPage;
                viewModel = frontPage.DataContext as ViewModel;
                frontPage = null;
            }
            if (viewModel != null)
                viewModel.Dispose();
            Navigator.Frame = null;
        }
    }
}
