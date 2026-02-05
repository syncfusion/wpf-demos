#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MenuGettingStartedDemosView.xaml
    /// </summary>
    public partial class MenuGettingStartedDemosView: DemoControl
    {
        public MenuGettingStartedDemosView()
        {
            InitializeComponent();                       
        }

        public MenuGettingStartedDemosView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.MenuAdv != null)
            {
                this.MenuAdv.Dispose();
                this.MenuAdv = null;
            }

            if (this.DataContext != null)
            {
                this.DataContext = null;
            }

            if (this.richtextbox != null)
                this.richtextbox = null;

            this.Resources.Clear();

            if (this.expandMode != null)
            {
                this.expandMode.Dispose();
                this.expandMode = null;
            }              

            if (this.menuOrientation != null)
            {
                this.menuOrientation.Dispose();
                this.menuOrientation = null;
            }               

            if (this.popupAnimationType != null)
            {
                this.popupAnimationType.Dispose();
                this.popupAnimationType = null;
            }              

            if (this.Options != null)
                this.Options = null;
            
            if (this.gettingStartedGrid != null)
            {
                this.gettingStartedGrid.Children.Clear();
                this.gettingStartedGrid = null;
            }

            if (this.optionsGrid != null)
            {
                this.optionsGrid.Children.Clear();
                this.optionsGrid = null;
            }
            base.Dispose(disposing);
        }

        private void menuOrientation_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (MenuAdv != null && richtextbox != null)
            {
                switch (menuOrientation.SelectedIndex)
                {
                    case 0:
                        MenuAdv.Width = 1000;
                        richtextbox.Margin = new System.Windows.Thickness(0, 30, 0, 0);
                        break;
                    case 1:
                        MenuAdv.Width = 75;
                        MenuAdv.MinHeight = 200;
                        MenuAdv.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        richtextbox.Margin = new System.Windows.Thickness(75, 0, 0, 0);
                        break;
                }
            }                   
        }
    } 
}
