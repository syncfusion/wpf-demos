using Syncfusion.Windows.Shared;

namespace syncfusion.visualstudiodemo.wpf
{
    public class PropertiesViewModel : NotificationObject
    {
        private Person person = null;

        public Person SelectedObject
        {
            get { return person; }
            set { person = value; }
        }

        public PropertiesViewModel()
        {
            SelectedObject = new Person();
            EnableGrouping = true;
        }

        private bool enableGroup;

        public bool EnableGrouping
        {
            get { return enableGroup; }
            set { enableGroup = value; this.RaisePropertyChanged(nameof(EnableGrouping)); }
        }

    }
}
