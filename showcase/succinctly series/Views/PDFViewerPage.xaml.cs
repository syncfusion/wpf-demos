#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using System.Windows.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.succinctlyseries.wpf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PDFViewerPage : Page
    {
        public PDFViewerPage()
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Office2019Black" });
            this.InitializeComponent();
        }

        private void BackButton_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Button backButton = sender as Button;
            if (backButton.Command.CanExecute(true))
                backButton.Command.Execute(true);
        }

        public void Unload()
        {
            PDFViewer.Unload(true);
        }
    }
}
