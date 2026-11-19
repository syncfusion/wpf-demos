using System.Collections.ObjectModel;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
