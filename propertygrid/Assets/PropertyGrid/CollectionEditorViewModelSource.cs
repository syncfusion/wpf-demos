#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
public class CollectionEditorViewModel : NotificationObject
{
    private ObservableCollection<string> hidePropertyItems;

    public ObservableCollection<string> HidePropertyItems
    {
        get
        {
            return hidePropertyItems;
        }
        set
        {
            hidePropertyItems = value;
        }
    }

    public CollectionEditorViewModel()
    {
        //Properties which are need to be hide from PropertyGrid
        hidePropertyItems = new ObservableCollection<string>();
        hidePropertyItems.Add(nameof(TableCompany.Address));
        hidePropertyItems.Add(nameof(TableCompany.EmailID));
        hidePropertyItems.Add(nameof(TableCompany.EmployeeCount));
    }
}