#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
