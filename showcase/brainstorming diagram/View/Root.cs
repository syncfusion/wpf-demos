using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    public class Root : Syncfusion.UI.Xaml.Diagram.Node
    {
        public Root()
        {
            SetResourceReference(StyleProperty, typeof(Root));
        }
    }
}
