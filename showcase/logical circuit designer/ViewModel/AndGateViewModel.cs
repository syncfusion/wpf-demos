#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.logicalcircuitdesigner.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using System.Linq;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class AndGateViewModel : GateViewModel
    {
        public AndGateViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void GenerateLogic()
        {
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null && nodeInfo.InConnectors.Count() == 2)
            {
                int? state = null;
                foreach (WireViewModel connector in nodeInfo.InConnectors)
                {
                    if (state.HasValue)
                    {
                        state = (int)connector.State & state.Value;
                    }
                    else
                    {
                        state = (int)connector.State;
                    }
                }
                if (state.HasValue)
                    this.State = (BinaryState)state;
            }
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.AndGate] as DataTemplate;
        }
    }
}
