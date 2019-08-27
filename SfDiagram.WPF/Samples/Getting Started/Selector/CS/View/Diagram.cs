#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingStarted_Selector.View
{    
    public class Diagram : SfDiagram
    {       
        //Apply Selectors

        public Selector SFSelector = new Selector();
        protected override Selector GetSelectorForItemOverride(object item)
        {
            return SFSelector;
        }
    }
}
