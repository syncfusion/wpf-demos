using System.ComponentModel;

namespace syncfusion.expenseanalysis.wpf
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
