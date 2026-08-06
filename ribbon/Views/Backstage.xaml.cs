
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Code behind logic for MainWindow.xaml
    /// </summary>
    public partial class Backstage
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="Backstage" /> class.
        /// </summary>
        public Backstage()
        {
            InitializeComponent();           
        }

        public Backstage(string themename)
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
            if (this.Editor != null)
                this.Editor = null;

            BackstageViewModel.Dispose();
            base.OnClosing(e);
        }
    }
}
