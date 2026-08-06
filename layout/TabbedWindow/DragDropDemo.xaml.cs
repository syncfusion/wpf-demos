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
        }

        private void SfChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var theme = SfSkinManager.GetTheme(this);
            window = new TargetChromelessWindow(theme.ThemeName);
            window.Topmost = true;
            window.Show();
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
