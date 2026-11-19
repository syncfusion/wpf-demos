using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class HighConstantViewModel : BaseGateViewModel
    {
        public HighConstantViewModel() : base()
        {
            this.ContentTemplate = Application.Current.MainWindow.Resources["High_ConstantNode"] as DataTemplate;
        }
    }
}
