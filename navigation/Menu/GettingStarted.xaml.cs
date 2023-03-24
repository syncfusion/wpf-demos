#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
                MenuGettingStartedViewModel dataContext = DataContext as MenuGettingStartedViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if (this.richtextbox != null)
                this.richtextbox = null;

            this.Resources.Clear();

            if (this.expandMode != null)
                this.expandMode = null;

            if (this.richtextbox != null)
                this.richtextbox = null;

            if (this.menuOrientation != null)
                this.menuOrientation = null;

            if (this.popupAnimationType != null)
                this.popupAnimationType = null;

            if (this.Options != null)
                this.Options = null;

            base.Dispose(disposing);
        }
    } 
}
