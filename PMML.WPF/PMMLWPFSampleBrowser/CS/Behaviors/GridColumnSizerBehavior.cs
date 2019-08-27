#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace PMMLWPFSampleBrowser
{
    class GridColumnSizerExt : GridColumnSizer
    {
        public GridColumnSizerExt(SfDataGrid dataGrid)
            : base(dataGrid)
        {

        }

        protected override void SetStarWidth(double remainingColumnWidth, IEnumerable<GridColumn> remainingColumns)
        {
            if (remainingColumnWidth >= 150)
            {
                base.SetStarWidth(remainingColumnWidth, remainingColumns);
                return;
            }

            foreach (var column in remainingColumns)
            {
                this.SetNoneWidth(column, column.ActualWidth);
            }
        }

        protected override double SetNoneWidth(GridColumn column, double width)
        {
            if (width <= 150 || double.IsNaN(width))
            {
                var autowidth = CalculateAutoFitWidth(column, true);
                return base.SetNoneWidth(column, autowidth);
            }
            return base.SetNoneWidth(column, width);
        }
    }

    public class GridColumnSizerBehvaior : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {            
            base.OnAttached();
            this.AssociatedObject.GridColumnSizer = new GridColumnSizerExt(this.AssociatedObject);
        }

    }
}
