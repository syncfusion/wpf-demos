#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.logicalcircuitdesigner.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class OutputViewModel : GateViewModel
    {
        public OutputViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void RefreshTemplate()
        {
            var resourceName = this.State == BinaryState.Zero ? Constants.DefaultLightBulb : Constants.ActiveLightBulb;
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[resourceName] as DataTemplate;
        }
    }
}
