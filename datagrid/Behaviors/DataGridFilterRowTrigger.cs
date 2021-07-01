#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Class for representing the trigger for clearing the filter and remove the default renderer and
    /// assign the custom renderer
    /// </summary>
    public class DataGridFilterRowTrigger : TargetedTriggerAction<SfDataGrid>
    {
        protected override void Invoke(object parameter)
        {
            this.Target.MoveCurrentCell(new RowColumnIndex(this.Target.GetFilterRowIndex(), this.Target.GetFirstColumnIndex()));
            this.Target.SelectionController.CurrentCellManager.BeginEdit();
        }
    }
}
