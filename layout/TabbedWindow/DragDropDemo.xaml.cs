#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.layoutdemos.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using static syncfusion.layoutdemos.wpf.TabConversionHelpers;

namespace syncfusion.layoutdemos.wpf
{
    public partial class DragDropDemo : Syncfusion.Windows.Controls.SfChromelessWindow
    {
        private bool _spawnedSecond;
        TargetChromelessWindow window;

        private static bool s_hasSpawnedB = false;
        public DragDropDemo()
        {
            InitializeComponent();
            this.Topmost = true;
            Application.Current.Activated += Current_Activated;
            Application.Current.Deactivated += Current_Deactivated;
        }

        private void SfChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var theme = SfSkinManager.GetTheme(this);
            window = new TargetChromelessWindow(theme.ThemeName);
            window.Show();
            window.Topmost = true;
        }

        private void MainTabControl_PreviewMerge(object sender, TabMergePreviewEventArgs e)
        {
            if (!ReferenceEquals(e.TargetControl, MainTabControl))
                return;

            var inlineFromTarget = e.DraggedItem as SfTabItem;
            if (inlineFromTarget == null || !(DataContext is DragDropViewModel vm))
                return;

            var model = ToModel(inlineFromTarget);
            e.ResultingItem = model;
        }

        private void Current_Activated(object sender, EventArgs e)
        {
            this.Topmost = true;
            window.Topmost = true;
        }

        private void Current_Deactivated(object sender, EventArgs e)
        {
            this.Topmost = false;
            window.Topmost = false;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (MainTabControl != null)
            {
                if (MainTabControl.ItemTemplate != null)
                {
                    MainTabControl.ItemTemplate = null;
                }
                if (MainTabControl.ContentTemplate != null)
                {
                    MainTabControl.ContentTemplate = null;
                }

                MainTabControl.Dispose();
                MainTabControl = null;
            }
            base.OnClosing(e);
        }
    }
}
