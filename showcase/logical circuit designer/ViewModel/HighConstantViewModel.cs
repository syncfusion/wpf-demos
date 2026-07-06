using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class HighConstantViewModel : BaseGateViewModel
    {
        public HighConstantViewModel() : base()
        {
            this.State = Model.BinaryState.One;
        }

        protected override void RefreshTemplate()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["High_ConstantNode"] as DataTemplate;
        }
    }
}
