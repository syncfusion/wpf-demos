#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class SRFlipFlopViewModel : GateViewModel
    {
        public SRFlipFlopViewModel() : base()
        {
            this.RefreshTemplate(); 
        }

        protected override void GenerateLogic()
        {
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null && nodeInfo.InConnectors.Count() == 3)
            {
                int sinput = (int)(nodeInfo.InConnectors.ElementAt(0) as WireViewModel).State;
                int clockinput = (int)(nodeInfo.InConnectors.ElementAt(1) as WireViewModel).State;
                int rinput = (int)(nodeInfo.InConnectors.ElementAt(2) as WireViewModel).State;
                FindOutput(sinput,clockinput,rinput);
            }
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.SRFlipFlop] as DataTemplate;
        }

        private void FindOutput(int sinput, int clockinput, int rinput)
        {
            string value = sinput.ToString() + clockinput.ToString() + rinput.ToString();
            if (this.Info is INodeInfo nodeInfo && nodeInfo.OutConnectors != null && nodeInfo.OutConnectors.Count() == 2)
            {
                switch (value)
                {
                    case ("000"):
                    case ("001"):
                    case ("010"):
                    case ("011"):
                    case ("100"):
                    case ("101"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.Zero;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.One;
                        break;
                    case ("110"):
                    case ("111"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.One;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.Zero;
                        break;
                }
            }
        }
    }
}
