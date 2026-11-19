
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Class represents the code behind logic for Window1.xaml
    /// </summary>
    public partial class Touch
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="Touch" /> class.
        /// </summary>
        public Touch()
        {
            InitializeComponent();
        }

        public Touch(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.Resources != null)
                this.Resources.Clear();
            if (this.mainRibbon != null)
            {
                this.mainRibbon.Dispose();
                this.mainRibbon = null;
            }

            if (this.ribbonStatusBar != null)
                this.ribbonStatusBar = null;

            if (this.titleEditor != null)
                this.titleEditor = null;

            if (this.secondraryEditor != null)
                this.secondraryEditor = null;

            if (this.itempreview != null)
                this.itempreview = null;

            if(this.DataContext != null)
                this.DataContext = null;

            if (mainGrid != null)
            {
                mainGrid.Children.Clear();
                mainGrid = null;
            }
            TouchViewModel.Dispose();
            base.OnClosing(e);
        }
    }
}