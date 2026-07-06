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
    public class XORGateViewModel : GateViewModel
    {
        public XORGateViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void GenerateLogic()
        {
            int? state = null;
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null)
            {
                foreach (WireViewModel connector in nodeInfo.InConnectors)
                {
                    if (state.HasValue)
                    {
                        state = (int)connector.State ^ state.Value;
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
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.XORGate] as DataTemplate;
        }
    }
}
