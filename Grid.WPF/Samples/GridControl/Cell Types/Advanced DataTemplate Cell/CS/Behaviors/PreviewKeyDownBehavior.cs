using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;

namespace PortfolioManager1.Behaviors
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
