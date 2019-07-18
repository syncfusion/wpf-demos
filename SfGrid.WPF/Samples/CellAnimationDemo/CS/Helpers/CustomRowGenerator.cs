#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace CellAnimationDemo
{
    public class CustomRowGenerator : RowGenerator
    {
        public CustomRowGenerator(SfDataGrid dataGrid)
            : base(dataGrid)
        {
        }

        protected override GridCell GetGridCell<T>()
        {
            if (typeof(T) == typeof(GridCell))
                return new CustomGridCell();
            return base.GetGridCell<GridCell>();
        }
    }
}
