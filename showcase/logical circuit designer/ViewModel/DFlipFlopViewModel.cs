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
    public class DFlipFlopViewModel : GateViewModel
    {
        public DFlipFlopViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void GenerateLogic()
        {
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null && nodeInfo.InConnectors.Count() == 4)
            {
                int dinput = (int)(nodeInfo.InConnectors.ElementAt(0) as WireViewModel).State;
                int clockinput = (int)(nodeInfo.InConnectors.ElementAt(1) as WireViewModel).State;
                int presetinput = (int)(nodeInfo.InConnectors.ElementAt(2) as WireViewModel).State;
                int clearinput = (int)(nodeInfo.InConnectors.ElementAt(3) as WireViewModel).State;
                FindOutput(dinput, clockinput, presetinput, clearinput);
            }
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.DFlipFlop] as DataTemplate;
        }

        private void FindOutput(int dinput, int clockinput, int presetinput, int clearinput)
        {
            string value = dinput.ToString() + clockinput.ToString() + presetinput.ToString() + clearinput.ToString();
            if (this.Info is INodeInfo nodeInfo && nodeInfo.OutConnectors != null && nodeInfo.OutConnectors.Count() == 2)
            {
                switch (value)
                {
                    case ("0000"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.Zero;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.Zero;
                        break;
                    case ("0001"):
                    case ("1000"):
                    case ("1001"):
                    case ("1010"):
                    case ("1011"):
                    case ("1110"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.Zero;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.One;
                        break;
                    case ("0010"):
                    case ("0100"):
                    case ("0101"):
                    case ("0110"):
                    case ("0111"):
                    case ("1101"):
                    case ("1111"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.One;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.Zero;
                        break;
                    case ("0011"):
                    case ("1100"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.One;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.One;
                        break;
                }
            }
        }
    }
}
