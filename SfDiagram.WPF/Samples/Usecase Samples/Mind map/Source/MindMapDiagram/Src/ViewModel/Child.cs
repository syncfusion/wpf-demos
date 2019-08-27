#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.UI.Xaml.MindMapDiagram.ViewModel
{
    public class Child : RootChild
    {
        #region Private Fields
        private RootChild parent;
        #endregion
        public Child()
        {

        }
        public Child(RootChild parent): base(parent.Direction)
        {
            Parent = parent;
        }

        #region Public properties
        
        public RootChild Parent
        {
            get { return parent; }
            set
            {
                if (parent != value)
                {
                    parent = value;
                    OnPropertyChanged("Parent");
                }
            }
        }
        #endregion
    }
}
