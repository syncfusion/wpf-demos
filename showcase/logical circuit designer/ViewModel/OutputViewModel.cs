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
