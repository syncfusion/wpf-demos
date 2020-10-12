#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationChart.ViewModel
{
    public class OrganizationChartConnectorVM : DiagramBuilder.ViewModel.ConnectorVM
    {
        #region Constructor
        public OrganizationChartConnectorVM()
        {
            this.ThemeStyleId = Syncfusion.UI.Xaml.Diagram.Theming.StyleId.Accent1 | Syncfusion.UI.Xaml.Diagram.Theming.StyleId.Subtly;
            this.Constraints = ConnectorConstraints.Default;
            if (Annotations != null && Annotations is List<IAnnotation>)
            {
                foreach (IAnnotation annotation in Annotations as List<IAnnotation>)
                {
                    annotation.ReadOnly = true;
                }
            }
        }
        #endregion
        
        
    }
}
