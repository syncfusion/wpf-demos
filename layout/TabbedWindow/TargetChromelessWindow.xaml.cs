#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.layoutdemos.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static syncfusion.layoutdemos.wpf.TabConversionHelpers;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for TargetChromelessWindow.xaml
    /// </summary>
    public partial class TargetChromelessWindow : SfChromelessWindow
    {
        public TargetChromelessWindow()
        {
            InitializeComponent();
        }

        public TargetChromelessWindow(string themeName)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themeName });
            InitializeComponent();
        }

        private void SfTabControl_PreviewMerge(object sender, TabMergePreviewEventArgs e)
        {
            if (!ReferenceEquals(e.TargetControl, sender)) return;

            var modelFromMain = e.DraggedItem as TabItemModel;
            if (modelFromMain != null)
            {
                e.ResultingItem = ToInlineTab(modelFromMain);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (targetTabControl != null)
            {
                targetTabControl.Dispose();
                targetTabControl = null;
            }
            base.OnClosing(e);
        }
    }
}
