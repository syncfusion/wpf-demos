#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.UI.Xaml.MindMapDiagram.ViewModel
{
    public class MindMapNodeStyle : DiagramElementViewModel, IMindMapNodeStyle
    {
        #region Private Fields
        private StyleId styleId;
        private string shape;
        #endregion
        #region Public Properties
        public StyleId StyleId
        {
            get { return styleId; }
            set
            {
                if (styleId != value)
                {
                    styleId = value;
                    OnPropertyChanged("StyleId");
                }
            }
        }
        public string Shape
        {
            get { return shape; }
            set
            {
                if (shape != value)
                {
                    shape = value;
                    OnPropertyChanged("Shape");
                }
            }
        }


        #endregion
    }
}
