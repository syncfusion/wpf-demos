#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Getting_Started_Commands.Viewmodel
{
    public class CustomNodeViewModel : NodeViewModel
    {
        private Brush _FillColor;
        public CustomNodeViewModel()
        {

        }

        [DataMember]
        public Brush FillColor
        {
            get
            {
                return _FillColor;
            }
            set
            {
                if(_FillColor != value)
                {
                    _FillColor = value;
                    OnPropertyChanged("FillColor");
                }
            }
        }
    }
}
