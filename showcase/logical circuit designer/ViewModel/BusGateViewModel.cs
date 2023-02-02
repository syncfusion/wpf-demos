#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.logicalcircuitdesigner.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class BusGateViewModel : GateViewModel
    {
        public BusGateViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void GenerateLogic()
        {
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null)
            {
                int? state = null;
                //  (this.Ports[0] as IPortInfo).InConnectors
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

                if (nodeInfo.InConnectors.Count() == 2)
                {
                    if (this.State == BinaryState.One)
                    {
                        foreach (WireViewModel connector in nodeInfo.OutConnectors)
                        {
                            connector.ConnectorGeometryStyle = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["ActiveConnectorStyle"] as Style;
                        }
                    }

                    if (this.State == BinaryState.Zero)
                    {
                        if(!((nodeInfo.InConnectors.ElementAt(0) as WireViewModel).State == BinaryState.Zero &&
                        (nodeInfo.InConnectors.ElementAt(1) as WireViewModel).State == BinaryState.Zero))
                        {
                            foreach (WireViewModel connector in nodeInfo.OutConnectors)
                            {
                                connector.ConnectorGeometryStyle = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["InActiveConnectorStyle"] as Style;
                            }
                        }
                        else
                        {
                            foreach (WireViewModel connector in nodeInfo.OutConnectors)
                            {
                                connector.ConnectorGeometryStyle = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["DefaultConnectorStyle"] as Style;
                            }
                        }
                    }
                }
            }
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.BusGate] as DataTemplate;
        }
    }
}
