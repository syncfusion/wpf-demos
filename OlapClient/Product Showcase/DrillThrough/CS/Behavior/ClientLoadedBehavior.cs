#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace DrillThrough.Behavior
{
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Client.Olap;
    using System.Windows.Media;
    using System.Windows;

    class ClientLoadedBehavior : Behavior<OlapClient>
    {
        #region Members

        DependencyObject mainwindow;

        #endregion

        #region Methods

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            base.OnDetaching();
        }
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.OlapTabControl.EnableLabelEdit = false;
            this.AssociatedObject.OlapChartTab.TabIndex = 1;
            this.AssociatedObject.OlapGridTab.TabIndex = 0;
            this.AssociatedObject.OlapGrid.EnableDrillThrough = true;
            this.AssociatedObject.OlapDataManager.CurrentReport.GridSettings.ShowHyperlink = true;
            this.AssociatedObject.DrillThroughOccurred += AssociatedObject_DrillThroughOccurred;
        }

        private void GetMainWindow(DependencyObject obj)
        {
            DependencyObject parent = null;
            parent = VisualTreeHelper.GetParent(obj);
            if (parent is MainWindow)
                mainwindow = parent;
            else
            GetMainWindow(parent);
        }

        void AssociatedObject_DrillThroughOccurred(object sender, DrillThroughOccurredEventArgs e)
        {
            if (e.DrillThroughData != null)
            {
                GetMainWindow(this.AssociatedObject);
                DrillThroughGrid.DrillThroughGrid grid = new DrillThroughGrid.DrillThroughGrid(e.DrillThroughData);
                Syncfusion.Windows.Shared.SkinStorage.SetVisualStyle(grid, Syncfusion.Windows.Shared.SkinStorage.GetVisualStyle(this.AssociatedObject));
                grid.Focusable = true;
                grid.Owner = this.mainwindow as MainWindow;
                grid.ShowDialog();
                if (grid.IsHierarchySelectorNeeded)
                    this.AssociatedObject.ShowHierarchySelectorDialog(e.DrillThroughQuery);

            }
        }

        #endregion
    }
}