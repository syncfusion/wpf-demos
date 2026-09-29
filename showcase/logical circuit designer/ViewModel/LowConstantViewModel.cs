using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class LowConstantViewModel : BaseGateViewModel
    {
        public LowConstantViewModel() : base()
        {
            this.RefreshTemplate();
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["LowConstantNode"] as DataTemplate;
        }
    }
}
