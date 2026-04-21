#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    public class Root : Syncfusion.UI.Xaml.Diagram.Node
    {
        public Root()
        {
            SetResourceReference(StyleProperty, typeof(Root));
        }
    }
}
