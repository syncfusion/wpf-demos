#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
public class Company
{
    [ReadOnly(true)]
    public string CompanyName { get; set; }

    [Editable(false)]
    public int CompanyID { get; set; }

    [ReadOnly(true)]
    public string ProductName { get; set; }

    public Bank Bank { get; set; }

    private List<Employee> employees;

    //Readonly collection type property
    public ReadOnlyCollection<Employee> Employees
    {
        get
        {
            return employees.AsReadOnly();
        }
    }

    public List<CollectionCustomerDetails> Customers { get; set; }

    public Address Address { get; set; }
}