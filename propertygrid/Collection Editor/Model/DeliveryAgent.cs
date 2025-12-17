using Syncfusion.Windows.PropertyGrid;
using System.Collections.Generic;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class DeliveryAgent
    {
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
