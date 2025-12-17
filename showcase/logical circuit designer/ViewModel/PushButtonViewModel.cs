using syncfusion.logicalcircuitdesigner.wpf.Model;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class PushButtonViewModel : BaseGateViewModel
    {
        public PushButtonViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void RefreshTemplate()
        {
            var resourceName = this.State == BinaryState.Zero ? Constants.DefaultPushButton : Constants.ActivePushButton;
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[resourceName] as DataTemplate;
        }
    }
}
