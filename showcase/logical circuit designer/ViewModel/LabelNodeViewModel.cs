using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class LabelNodeViewModel : GateViewModel
    {
        public LabelNodeViewModel() : base()
        {
            this.UnitWidth = double.NaN;
            this.UnitHeight = double.NaN;
        }
    }
}
