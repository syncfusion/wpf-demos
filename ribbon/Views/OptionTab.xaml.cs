
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Code behind logic for Window1.xaml
    /// </summary>
    public partial class OptionTab
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionTab"/> class.
        /// </summary>
        public OptionTab()
        {
            InitializeComponent();
        }

        public OptionTab(string themename)
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
            {
                this.ribbonStatusBar = null;
            }

            if (this.editor != null)
            {
                this.editor = null;
            }

            var viewModel = this.DataContext as OptionTabViewModel;
            if (viewModel != null)
            {
                viewModel.Dispose();
                viewModel = null;
            }
            base.OnClosing(e);
        }
    }
}