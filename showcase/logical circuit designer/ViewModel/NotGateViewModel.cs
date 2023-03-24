#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class NotGateViewModel : GateViewModel
    {
        public NotGateViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void GenerateLogic()
        {
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null)
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
                    this.State = state == 0 ? BinaryState.One : BinaryState.Zero;
            }
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.NOTGate] as DataTemplate;
        }
    }
}
