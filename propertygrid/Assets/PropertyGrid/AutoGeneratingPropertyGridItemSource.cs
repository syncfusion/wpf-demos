//Hook AutoGeneratingPropertyGridItem event to configure properties.
this.propertygrid.AutoGeneratingPropertyGridItem += AutoGeneratingPropertyGridItemEventArgs

private void Propertygrid_AutoGeneratingPropertyGridItem
    (object sender, AutoGeneratingPropertyGridItemEventArgs e)
{
    if (e.DisplayName == "FirstName") {
        e.Order = 1;
    }
    else if (e.DisplayName == "LastName") {
        e.Description = "Last Name of the actual person.";
    }
    else if (e.DisplayName == "MaritalStatus") {
        //Restrict "MaritalStatus" property to load into the PorpertyGrid
        e.Cancel = true;
    }
    else if (e.DisplayName == "IsPermanent") {
        e.DisplayName = "Permanent Employee";
    }
    else if (e.DisplayName == "Bank") {
        e.ReadOnly = true;
    }
    else if (e.DisplayName == "DOB") {
        //Restrict expanding of nested proerties
        e.ExpandMode = PropertyExpandModes.FlatMode;
    }
    else if (e.DisplayName == "Mobile") {
        e.Category = "Additional Info";
    }
}
