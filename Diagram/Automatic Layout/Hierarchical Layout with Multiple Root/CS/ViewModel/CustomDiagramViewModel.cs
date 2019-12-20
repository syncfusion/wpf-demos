#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Hierarchical_Layout_with_Multiple_Root.Utility;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hierarchical_Layout_with_Multiple_Root.ViewModel
{
    public class CustomDiagramViewModel : DiagramViewModel
    {
        public CustomDiagramViewModel()
        {
            ViewPortChangedCommand = new Command(OnViewPortChanged);                
        }

        private void OnViewPortChanged(object obj)
        {
            ChangeEventArgs<object,ScrollChanged> args = obj as ChangeEventArgs<object,ScrollChanged>;
            Rect bounds = args.NewValue.ContentBounds;
            if (Info != null)
            {
                (Info as IGraphInfo).BringIntoCenter(bounds);
            }
        }
    }
}
