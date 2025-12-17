using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    public class Child : Syncfusion.UI.Xaml.Diagram.Node
    {
        public Child()
        {
            SetResourceReference(StyleProperty, typeof(Child));
        }
    }
}
