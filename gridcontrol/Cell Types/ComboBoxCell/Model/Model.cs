using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.gridcontroldemos.wpf
{
    public class CustomersInfo
    {
        public CustomersInfo() { }
        public string CustomerID { get; set; }
        public string ContactTitle { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ContactName { get; set; }
        public string Fax { get; set; }
    }

    public class EmployeesInfo
    {
        public EmployeesInfo() { }
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string HomePhone { get; set; }
    }
}
