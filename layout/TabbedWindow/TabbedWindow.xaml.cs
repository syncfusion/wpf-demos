using syncfusion.layoutdemos.wpf.ViewModel;
using Syncfusion.Windows.Controls;
using System;
using System.ComponentModel;
using System.Windows;

namespace syncfusion.layoutdemos.wpf
{
    public partial class TabbedWindow : Syncfusion.Windows.Controls.SfChromelessWindow
    {
        public TabbedWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (sfTabControl != null)
            {
                if (sfTabControl.ItemTemplate != null)
                {
                    sfTabControl.ItemTemplate = null;
                }
                if (sfTabControl.ContentTemplate != null)
                {
                    sfTabControl.ContentTemplate = null;
                }
                if (sfTabControl.ItemContainerStyle != null)
                {
                    sfTabControl.ItemContainerStyle = null;
                }

                sfTabControl.Dispose();
                sfTabControl = null;
            }
            base.OnClosing(e);
        }
    }
}
