#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
public class TableCompany {
    public string CompanyName { get; set; }

    public int CompanyID { get; set; }

    [Browsable(false)]
    public DateTime CompanyStartedDate { get; set; }

    public string ProductName { get; set; }

    [Bindable(false)]
    public string OwnerName { get; set; }

    public List<CollectionCustomerDetails> Customers { get; set; }

    public string EmailID { get; set; }

    [Browsable(false)]
    public long NetIncome { get; set; }

    public ObservableCollection<DeliveryAgent> DeliveryAgents { get; set; }

    public long EmployeeCount { get; set; }

    [Bindable(false)]
    public Bank Bank { get; set; }

    private List<Employee> employees;

    [Display(Name = "Employees(ReadOnly)")]
    //Readonly collection type property
    public ReadOnlyCollection<Employee> Employees {
        get {
            return employees.AsReadOnly();
        }
    }

    public Address Address { get; set; }
}
  