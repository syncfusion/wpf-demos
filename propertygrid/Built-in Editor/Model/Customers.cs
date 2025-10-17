using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
       
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
