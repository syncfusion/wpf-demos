#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;

namespace ColorPickerPaletteDemo_2008
{
    public class ForegroundBehavior : Behavior<RichTextBox>
    {
        protected override void OnAttached()
        {
            var vm = this.AssociatedObject.DataContext as ViewModel;
            vm.ApplyForeground = new DelegateCommand<object>(OnApplyForeGroup);
            base.OnAttached();
            TextPointer startPointer = (this.AssociatedObject as RichTextBox).Document.ContentStart.GetPositionAtOffset(0);
            TextPointer endPointer = (this.AssociatedObject as RichTextBox).Document.ContentStart.GetPositionAtOffset(22);
            (this.AssociatedObject as RichTextBox).Selection.Select(startPointer, endPointer);
            (this.AssociatedObject as RichTextBox).Focus();
        }

        private void OnApplyForeGroup(object param)
        {
            var text = AssociatedObject;
            if (param != null && text != null)
            {
                var groupItem = (ColorSelectedCommandArgs)param;
                TextRange range = new TextRange(text.Selection.Start, text.Selection.End);
                range.ApplyPropertyValue(FlowDocument.ForegroundProperty, groupItem.Brush);
            }

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
