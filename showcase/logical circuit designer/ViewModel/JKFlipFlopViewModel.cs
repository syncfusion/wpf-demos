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
    public class JKFlipFlopViewModel : GateViewModel
    {
        public JKFlipFlopViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void GenerateLogic()
        {
            if (this.Info is INodeInfo nodeInfo && nodeInfo.InConnectors != null && nodeInfo.InConnectors.Count() == 5)
            {
                int jinput = (int)(nodeInfo.InConnectors.ElementAt(0) as WireViewModel).State;
                int clockinput = (int)(nodeInfo.InConnectors.ElementAt(1) as WireViewModel).State;
                int kinput = (int)(nodeInfo.InConnectors.ElementAt(2) as WireViewModel).State;
                int presetinput = (int)(nodeInfo.InConnectors.ElementAt(3) as WireViewModel).State;
                int clearinput = (int)(nodeInfo.InConnectors.ElementAt(4) as WireViewModel).State;
                FindOutput(jinput, clockinput, kinput, presetinput, clearinput);
            }
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.JKFlipFlop] as DataTemplate;
        }

        private void FindOutput(int jinput, int clockinput, int kinput, int presetinput, int clearinput)
        {
            string value = jinput.ToString() + clockinput.ToString() + kinput.ToString() + presetinput.ToString() + clearinput.ToString();
            if (this.Info is INodeInfo nodeInfo && nodeInfo.OutConnectors != null && nodeInfo.OutConnectors.Count() == 2)
            {
                switch (value)
                {
                    case ("00110"):
                    case ("00010"):
                    case ("01010"):
                    case ("01011"):
                    case ("01110"):
                    case ("01111"):
                    case ("10010"):
                    case ("10110"):
                    case ("11010"):
                    case ("11110"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.Zero;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.One;
                        break;
                    case ("00001"):
                    case ("00101"):
                    case ("00111"):
                    case ("01001"):
                    case ("01101"):
                    case ("10001"):
                    case ("10011"):
                    case ("10101"):
                    case ("10111"):
                    case ("11001"):
                    case ("11011"):
                    case ("11101"):
                    case ("11111"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.One;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.Zero;
                        break;
                    case ("00000"):
                    case ("00100"):
                    case ("01000"):
                    case ("01100"):
                    case ("10000"):
                    case ("10100"):
                    case ("11000"):
                    case ("11100"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.One;
                        (nodeInfo.OutConnectors.ElementAt(1) as WireViewModel).State = BinaryState.One;
                        break;
                    case ("00011"):
                        (nodeInfo.OutConnectors.ElementAt(0) as WireViewModel).State = BinaryState.Zero;
                        break;
                }
            }
        }
    }
}
