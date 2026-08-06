//Restrict expanding of nested proerties
[PropertyGridAttribute(NestedPropertyDisplayMode = NestedPropertyDisplayMode.None,
                           PropertyName = "DOB,FavoriteColor")]
[TypeConverter(typeof(ExpandableObjects))]
public class Person
{
    [Display(Order = 1)]
    public string FirstName { get; set; }

    [DescriptionAttribute("Last Name of the actual person.")]
    public string LastName { get; set; }

    //Not populated in PropertyGrid 
    [Browsable(false)]
    public string MaritalStatus { get; set; }

    [DisplayNameAttribute("Permanent Employee")]
    public bool IsPermanent { get; set; }

    //Cannot be editable(readonly)  
    [ReadOnly(true)]
    public Bank Bank { get; set; }

    //Valid and restrict email-id input using MaskAttribute   
    [Mask(MaskAttribute.EmailId)]
    public string Email { get; set; }

    [CategoryAttribute("Additional Info")]
    public long Mobile { get; set; }
}