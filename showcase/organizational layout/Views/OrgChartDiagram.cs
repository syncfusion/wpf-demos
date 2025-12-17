using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.organizationallayout.wpf
{
    //Derived Diagram to Customize the Selector
   public class OrgChartDiagram:SfDiagram
    {
       public Syncfusion.UI.Xaml.Diagram.Selector SFSelector = new Syncfusion.UI.Xaml.Diagram.Selector();
       protected override Syncfusion.UI.Xaml.Diagram.Selector GetSelectorForItemOverride(object item)
       {
           return SFSelector;
       }
    }
}
