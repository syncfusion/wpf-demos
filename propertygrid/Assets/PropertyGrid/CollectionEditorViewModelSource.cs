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