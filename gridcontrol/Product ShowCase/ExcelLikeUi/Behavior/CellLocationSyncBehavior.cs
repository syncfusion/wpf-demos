using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.gridcontroldemos.wpf
{
    public class CellLocationSyncBehavior : Behavior<SampleGridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.CellLocationTextChanged += new EventHandler(AssociatedObject_CellLocationTextChanged);
        }

        void AssociatedObject_CellLocationTextChanged(object sender, EventArgs e)
        {
            var dataContext = AssociatedObject.DataContext as ExcelLikeUiViewModel;
            if (dataContext != null)
            {
                dataContext.CellLocationText = this.AssociatedObject.CellLocationText;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.CellLocationTextChanged -= new EventHandler(AssociatedObject_CellLocationTextChanged);
        }
    }
}
