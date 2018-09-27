
using System.Windows;
using System.Windows.Data;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramBuilder.View
{
    class ConnectorView : Connector
    {
        public ConnectorView()
        {
            this.SetBinding(VisibilityProperty,
                new Binding()
                {
                    Path = new PropertyPath("Visibility"),
                    Mode = BindingMode.TwoWay
                });
        }
    }
}
