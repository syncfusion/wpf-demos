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