#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for DragDrop.xaml
    /// </summary>
    public partial class DragDropView  :DemoControl
    {
        public DragDropView()
        {
            InitializeComponent();
        }

        public DragDropView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.firstGroupBar != null)
            {
                this.firstGroupBar.Dispose();
                this.firstGroupBar = null;
            }

            if (this.secondGroupBar != null)
            {
                this.secondGroupBar.Dispose();
                this.secondGroupBar = null;
            }
            if (this.groupBarOrientationTextBlock != null)
                this.groupBarOrientationTextBlock = null;
            if (this.orientationTypes != null)
                this.orientationTypes = null;
            if (this.groupViewOrientationTextBlock != null)
                this.groupViewOrientationTextBlock = null;
            if (this.groupViewOrientationTypes != null)
                this.groupViewOrientationTypes = null;
            if (this.visualModeTextBlock != null)
                this.visualModeTextBlock = null;
            if (this.visualModeTypes != null)
                this.visualModeTypes = null;
            if (this.firstGroupBarVisibilityTextBlock != null)
                this.firstGroupBarVisibilityTextBlock = null;
            if (this.dragItemVisibility != null)
                this.dragItemVisibility = null;
            if (this.secondGroupBarVisibilityTextBlock != null)
                this.secondGroupBarVisibilityTextBlock = null;
            if (this.secondGroupBarDragItemVisibility != null)
                this.secondGroupBarDragItemVisibility = null;
            base.Dispose(disposing);
        }
    }
}
