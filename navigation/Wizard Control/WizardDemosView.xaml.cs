
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for WizardDemosView.xaml
    /// </summary>
    public partial class WizardDemosView
    {
        public WizardDemosView()
        {
            InitializeComponent();
        }

        public WizardDemosView(string themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.wizardControl != null)
            {
                this.wizardControl = null;
            }
            base.OnClosing(e);
        }
    }
}
