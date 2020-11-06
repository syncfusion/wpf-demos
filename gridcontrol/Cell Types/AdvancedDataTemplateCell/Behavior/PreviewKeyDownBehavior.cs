#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.gridcontroldemos.wpf
{
    public class PreviewKeyDownBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.CurrentCellPreviewKeyDown += new GridCellKeyEventHandler(AssociatedObject_CurrentCellPreviewKeyDown);
        }

        void AssociatedObject_CurrentCellPreviewKeyDown(object sender, GridCellKeyEventArgs args)
        {
            if (this.AssociatedObject.CurrentCell.Renderer is GridCellDataTemplateRenderer)
            {
                args.Handled = true;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.CurrentCellPreviewKeyDown -= new GridCellKeyEventHandler(AssociatedObject_CurrentCellPreviewKeyDown);
        }
    }
}
