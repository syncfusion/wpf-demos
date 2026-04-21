#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.layoutdemos.wpf.ViewModel
{
    public class DragDropViewModel : NotificationObject
    {
        public ObservableCollection<TabItemModel> TopTabs { get; } = new ObservableCollection<TabItemModel>();

        public DragDropViewModel()
        {
            TopTabs.Add(new TabItemModel(
                header: "✨ Curious Pane",
                content: "Try dragging this tab out and docking into another window.",
                description: "You can drag and drop tabs between different tabbed windows. Drag a tab out of the source window, then dock it into the target window. This demo handles the PreviewMerge event to enable cross-window docking and supports seamless reordering within a window."
            ));

            TopTabs.Add(new TabItemModel(
                header: "🔍 Mystery Slot",
                content: "Reorder me inside the window by dragging my tab header.",
                description: "Tip: While dragging, watch the preview to see where the tab will land. Use this demo to explore in-window reordering and cross-window docking behavior."
            ));

            TopTabs.Add(new TabItemModel(
                header: "🎛️ Lab Not-Tab",
                content: "This one demonstrates merging across windows.",
                description: "Behavior: PreviewMerge is handled so tabs dragged from one tabbed window can be accepted by another. Try dragging this tab to the target window to observe the merge behavior."
            ));
        }
    }
}
