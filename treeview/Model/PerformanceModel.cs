using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.treeviewdemos.wpf
{
    public class Model : INotifyPropertyChanged
    {
        public Model()
        {
            subItems = new ObservableCollection<Model>();
        }

        private ObservableCollection<Model> subItems;
        public ObservableCollection<Model> SubItems
        {
            get
            {
                return subItems;
            }

            set
            {
                subItems = value;
                RaisePropertyChanged("SubItems");
            }
        }

        private string header;

        /// <summary>
        /// Gets or sets a value indicating the Header of the TreeViewItemAdv.
        /// </summary>        
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                this.RaisePropertyChanged("Header");
            }
        }      


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
