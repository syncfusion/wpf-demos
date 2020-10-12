#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class DockHintsRestrictionBehavior : Behavior<DockHintsRestrictionDemo>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnAssociatedObjectLoaded;
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            this.UnloadEvents();
        }

        protected override void OnDetaching()
        {
            this.UnloadEvents();
        }

        private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;
            if (AssociatedObject.dockingManager != null)
            {
                AssociatedObject.dockingManager.Loaded += OnDockingManagerLoaded;
                (AssociatedObject.dockingManager.DocContainer as DocumentContainer).Loaded += OnDocumentContainerLoaded;
                AssociatedObject.dockingManager.PreviewDockHints += OnDockingManagerPreviewDockHints;
            }
        }

        private void UnloadEvents()
        {
            AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
            if (AssociatedObject.dockingManager != null)
            {
                AssociatedObject.dockingManager.Loaded -= OnDockingManagerLoaded;
                (AssociatedObject.dockingManager.DocContainer as DocumentContainer).Loaded -= OnDocumentContainerLoaded;
                AssociatedObject.dockingManager.PreviewDockHints -= OnDockingManagerPreviewDockHints;
            }
        }

        private void OnDocumentContainerLoaded(object sender, RoutedEventArgs e)
        {
            (sender as DocumentContainer).CreateVerticalTabGroup(AssociatedObject.features);
        }

        private void OnDockingManagerLoaded(object sender, RoutedEventArgs e)
        {
            DockingManager.SetState(AssociatedObject.properties, DockState.Float);
            DockingManager.SetFloatingWindowRect(AssociatedObject.properties, new Rect(590, 345, 250, 300));
        }

        private void OnDockingManagerPreviewDockHints(object sender, PreviewDockHintsEventArgs e)
        {
            if (e.DraggingTarget != null)
            {
                if (e.DraggingSource == AssociatedObject.properties)
                {
                    e.DockAbility = DockAbility.None;
                }
                else if (e.DraggingTarget == AssociatedObject.toolBox)
                {
                    e.DockAbility = DockAbility.Left;
                }
                else if (e.DraggingTarget == AssociatedObject.serverExplorer)
                {
                    e.DockAbility = DockAbility.Horizontal;
                }
                else if (e.DraggingTarget == AssociatedObject.bottomWindow)
                {
                    e.DockAbility = DockAbility.All;
                }
                else if (e.DraggingTarget == AssociatedObject.solutionExplorer)
                {
                    e.DockAbility = DockAbility.Top;
                }
                else if (e.DraggingTarget == AssociatedObject.teamExplorer)
                {
                    e.DockAbility = DockAbility.None;
                }
                else if (e.DraggingTarget == AssociatedObject.startPage)
                {
                    e.DockAbility = DockAbility.DocumentAll;
                }
                else if (e.DraggingTarget == AssociatedObject.features)
                {
                    e.DockAbility = DockAbility.Horizontal | DockAbility.Vertical;
                }
                else if (e.DraggingTarget == AssociatedObject.integration)
                {
                    e.DockAbility = DockAbility.DockAll;
                }
                else if (e.DraggingTarget == AssociatedObject.tabbedWindow)
                {
                    e.DockAbility = DockAbility.DockTabbed;
                }
                else
                {
                    e.DockAbility = DockAbility.All;
                }
            }
        }
    }
}
