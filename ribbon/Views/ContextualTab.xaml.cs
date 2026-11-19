
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Code behind logic for MainWindow.xaml
    /// </summary>
    public partial class ContextualTab
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ContextualTab" /> class.
        /// </summary>
        public ContextualTab()
        {
            InitializeComponent();         
        }

        public ContextualTab(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.ribbon != null)
            {
                this.ribbon.Dispose();
                this.ribbon = null;
            }

            if (this.editor != null)
            {               
                this.editor = null;
            }

            base.OnClosing(e);
        }
    }
}


