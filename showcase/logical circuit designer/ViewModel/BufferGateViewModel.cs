using syncfusion.logicalcircuitdesigner.wpf.Model;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class BufferGateViewModel : GateViewModel
    {
        public BufferGateViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[Constants.BufferGate] as DataTemplate;
        }
    }
}
