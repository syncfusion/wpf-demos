#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;

namespace CustomizedToolBarDemo
{
    public class FileOpeningAction : TargetedTriggerAction<RichTextBoxAdv>
    {
        protected override void Invoke(object parameter)
        {
            FileOpeningEventArgs args = parameter as FileOpeningEventArgs;
            if (args != null)
            {
                ((RichTextBoxAdv)Target).Document = DocxImporting.ConvertToDocumentAdv(args.DocumentStream, args.FormatType);
            }
        }
    }
}
